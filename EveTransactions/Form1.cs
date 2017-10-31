using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using System.Xml;
using EveTransactions.Domain;
using EveTransactions.Repository;
using ZedGraph;
using MaterialSkin.Controls;
using MaterialSkin;
using EveTransactions.Domain.Esi;
using EveTransactions.Services;

namespace EveTransactions
{
    public partial class Form1 : MaterialForm
    {

        #region Constants

        private const double BrokerFeeMultiplier = 1.0217;

        private const string JitaRegionId = "30000142";
        private const string RensRegionId = "30002510";
        private const string HeimetarRegionId = "10000030";

        private const string EveCentralMarketStatUrl = "http://api.eve-central.com/api/marketstat?typeid={0}&usesystem={1}"; //&cachebuster=1"&A1, "//buy/max")";

        #endregion

        #region Private Members

        private LoadingForm _loadingForm;
        private RecipeForm _recipeForm;
        private SalesHistoryForm _salesHistoryForm;
        private EveItemForm _eveItemForm;
        private StockForm _stockForm;
        private readonly CharacterRefreshTokens _characterRefreshTokens;

        #endregion

        #region Form Constructor

        public Form1()
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.BlueGrey800, 
                Primary.BlueGrey900,
                Primary.BlueGrey500, 
                Accent.LightBlue200, 
                TextShade.WHITE);

            _characterRefreshTokens = new CharacterRefreshTokens();
        }

        #endregion

        #region UI Event Handlers

        private void btnLoadNew_Click(object sender, EventArgs e)
        {
            if (backgroundWorker1.IsBusy)
            {
                MessageBox.Show(@"Worker is already running");
                return;
            }

            _loadingForm = new LoadingForm();

            _loadingForm.Show();

            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.RunWorkerAsync();
        }

        private void btnBestSellers_Click(object sender, EventArgs e)
        {
            GetAllAssets();
        }

        private void btnSearchSales_Click(object sender, EventArgs e)
        {
            SearchSales();
        }

        private void btnStockSearch_Click(object sender, EventArgs e)
        {
            EveRepository repository = new EveRepository();

            stockGridView.DataSource =
                repository.Stocks.Where(stock => stock.TypeName.Contains(txtStockSearch.Text))
                    .OrderBy(stock => stock.Date)
                    .ToList();
        }

        private void btnGroupedStockSearch_Click(object sender, EventArgs e)
        {
            EveRepository repository = new EveRepository();

            var query = from stock in repository.Stocks
                where stock.TypeName.Contains(txtGroupedStockSearch.Text)
                group stock by stock.TypeName
                into g
                select
                    new
                    {
                        Item = g.Key,
                        Quantity = g.Sum(stock => stock.Quantity),
                        AverageValue = g.Average(stock => stock.Price)
                    };

            foreach (var item in query.ToList())
            {
                var eveItem = repository.EveItems.FirstOrDefault(x => x.ItemName == item.Item);
                if (eveItem == null) continue;
                eveItem.CurrentStock = item.Quantity;
                repository.SaveChanges();
            }

            groupedStockGridView.DataSource = query.OrderByDescending(s => s.Quantity).ToList();
        }

        private void btnGetStock_Click(object sender, EventArgs e)
        {
            var repository = new EveRepository();

            if (cmbGetStock.SelectedItem == null)
            {
                var recipes = repository.Recipes.Select(p => p.TypeName).ToList();

                cmbGetStock.DataSource = recipes;
            }
            else
            {
                var recipe = repository.Recipes.FirstOrDefault(x => x.TypeName == cmbGetStock.SelectedItem.ToString());

                if (recipe == null) return;

                var query = from recipeInput in repository.RecipeInputs
                    join stock in repository.Stocks
                        on recipeInput.TypeName equals stock.TypeName
                    where recipeInput.RecipeID == recipe.RecipeID
                    group stock by stock.TypeName
                    into g
                    select new {Item = g.Key, Quantity = g.Sum(stock => stock.Quantity)};

                var numberOfRuns = Int32.Parse(txtRuns.Text);

                var q =
                    from c in repository.RecipeInputs
                    join p in query on c.TypeName equals p.Item into ps
                    where c.RecipeID == recipe.RecipeID
                    from p in ps.DefaultIfEmpty()
                    select
                        new
                        {
                            Item = c.TypeName,
                            Needed = c.Quantity,
                            Stock = p == null ? "(No stock)" : p.Quantity.ToString(),
                            Days = p == null ? 0 : p.Quantity/(numberOfRuns*c.Quantity)
                        };

                dataGridViewRecipeStock.DataSource = q.ToList();
            }
        }

        private void btnRefreshMonthlyBestSeller_Click(object sender, EventArgs e)
        {
            MonthlyBestSellers();
        }

        private void btnAddToxicMetals_Click(object sender, EventArgs e)
        {
            StockManagementService.AddStockUsingTotalPrice("Toxic Metals", DateTime.Now, int.Parse(txtToxicQuantity.Text), double.Parse(txtToxicPrice.Text));
        }

        private void btnAddPreciousMetals_Click(object sender, EventArgs e)
        {
            StockManagementService.AddStockUsingTotalPrice("Precious Metals", DateTime.Now, int.Parse(txtPreciousQuantity.Text), double.Parse(txtPreciousPrice.Text));
        }

        private void btnAddReactiveMetals_Click(object sender, EventArgs e)
        {
            StockManagementService.AddStockUsingTotalPrice("Reactive Metals", DateTime.Now, int.Parse(txtReactiveQuantity.Text), double.Parse(txtReactivePrice.Text));
        }

        private void btnAddChiralStructures_Click(object sender, EventArgs e)
        {
            StockManagementService.AddStockUsingTotalPrice("Chiral Structures", DateTime.Now, int.Parse(txtChiralQuantity.Text), double.Parse(txtChiralPrice.Text));
        }

        private void btnAddRobotics_Click(object sender, EventArgs e)
        {
            // Robotics (P3) output is always a multiple of 3
            // Input = 
            //  10 * Mechanical Parts  (3.33 per unit of robotics)
            //      80 * Precious Metals (26.66 per unit of robotics)
            //      80 * Reactive Metals
            //  10 * Consumer Electronics
            //      80 * Toxic Metals
            //      80 * Chiral Structures

            int roboticsNeeded = int.Parse(txtRoboticsQuantity.Text);
            decimal taxRate = decimal.Parse(txtRoboticsTaxRate.Text)/100;

            var builder = new RoboticsBuilder
            {
                ToxicMetalsStock = StockManagementService.GetStockCount("Toxic Metals"),
                ChiralStructuresStock = StockManagementService.GetStockCount("Chiral Structures"),
                PreciousMetalsStock = StockManagementService.GetStockCount("Precious Metals"),
                ReactiveMetalsStock = StockManagementService.GetStockCount("Reactive Metals"),
                //MechanicalPartsStock = StockManagementService.GetStockCount("Mechanical Parts"),
                //ConsumerElectronicsStock = StockManagementService.GetStockCount("Consumer Electronics"),
                RoboticsRequired = roboticsNeeded
            };


            // Return value is the tax cost
            var buildCost = builder.Build(taxRate);

            // Add in the cost of the underlying goods
            buildCost += StockManagementService.RemoveStock("Toxic Metals", builder.ToxicMetalsUsed);
            buildCost += StockManagementService.RemoveStock("Chiral Structures", builder.ChiralStructuresUsed);
            buildCost += StockManagementService.RemoveStock("Reactive Metals", builder.ReactiveMetalsUsed);
            buildCost += StockManagementService.RemoveStock("Precious Metals", builder.PreciousMetalsUsed);
            //buildCost += StockManagementService.RemoveStock("Consumer Electronics", builder.ConsumerElectronicsUsed);
            //buildCost += StockManagementService.RemoveStock("Mechanical Parts", builder.MechanicalPartsUsed);

            decimal costPerUnit = buildCost/builder.RoboticsBuilt;
            StockManagementService.AddStock("Robotics", DateTime.Now, (int) builder.RoboticsBuilt, costPerUnit);
        }

        private void btnAddGuidanceSystems_Click(object sender, EventArgs e)
        {
            int needed = int.Parse(txtGuidanceSystemsQuantity.Text);
            decimal taxRate = decimal.Parse(txtGuidanceSystemsTaxRate.Text)/100;

            var builder = new GuidanceSystemsBuilder
            {
                WaterCooledCPUStock = StockManagementService.GetStockCount("Water-Cooled CPU"),
                TransmitterStock = StockManagementService.GetStockCount("Transmitter"),
                GuidanceSystemsRequired = needed
            };


            // Return value is the tax cost
            var buildCost = builder.Build(taxRate);

            // Add in the cost of the underlying goods
            buildCost += StockManagementService.RemoveStock("Water-Cooled CPU", builder.WaterCooledCPUUsed);
            buildCost += StockManagementService.RemoveStock("Transmitter", builder.TransmitterUsed);

            decimal costPerUnit = buildCost/builder.GuidanceSystemsBuilt;
            StockManagementService.AddStock("Guidance Systems", DateTime.Now, (int) builder.GuidanceSystemsBuilt, costPerUnit);
        }

        private void bntNewRecipe_Click(object sender, EventArgs e)
        {
            _recipeForm = new RecipeForm();
            _recipeForm.Show();
        }

        private void dataGridRecipes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string cellValue = dataGridRecipes.Rows[e.RowIndex].Cells[1].Value.ToString();

            _recipeForm = new RecipeForm(cellValue);
            _recipeForm.Show();
        }

        private void salesDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string cellValue = salesDataGridView.Rows[e.RowIndex].Cells[0].Value.ToString();

            _salesHistoryForm = new SalesHistoryForm(cellValue);
            _salesHistoryForm.Show();
        }

        private void radioSalesToday_CheckedChanged(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            DateFilteredSales(new DateTime(now.Year, now.Month, now.Day, 0, 0, 0));
        }

        private void radioSalesAllTime_CheckedChanged(object sender, EventArgs e)
        {
            SearchSales();
        }

        private void radioSalesPastWeek_CheckedChanged(object sender, EventArgs e)
        {
            DateFilteredSales(DateTime.Now.AddDays(-7));
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            DateFilteredSales(DateTime.Now.AddDays(-1));
        }

        private void dataGridStock_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string itemName = dataGridStock.Rows[e.RowIndex].Cells[0].Value.ToString();
            string assumedStock = dataGridStock.Rows[e.RowIndex].Cells[1].Value.ToString();
            string actualStock = dataGridStock.Rows[e.RowIndex].Cells[2].Value.ToString();

            _stockForm = new StockForm(itemName, assumedStock, actualStock);
            _stockForm.Show();
        }

        #region Tab Events

        private void tabPage11_Enter(object sender, EventArgs e)
        {
            Recipes();
        }

        private void tabRecentSales_Enter(object sender, EventArgs e)
        {
            EveRepository repository = new EveRepository();

            var results = repository.Sales.GroupBy(p => p.TypeName)
                .Select(p => p.FirstOrDefault(w => w.SaleID == p.Max(m => m.SaleID)))
                .Where(p => p.TypeName.EndsWith("II"))
                .OrderBy(p => p.TypeName).ToList();

            var names = new[]
            {
                "Acolyte II", "Hobgoblin II", "Hornet II", "Warrior II", "Hammerhead II", "Infiltrator II", "Vespa II",
                "Valkyrie II", "Praetor II", "Ogre II", "Wasp II", "Berserker II", "Warden II", "Garde II", "Curator II",
                "Bouncer II", "Strip Miner I"
            };

            var matches = from sale in results
                where names.Contains(sale.TypeName) && sale.BuyPrice > 0
                select sale;

            recentSalesDataGridView.DataSource =
                matches.Select(
                    x =>
                        new
                        {
                            x.TypeName,
                            x.SellDate,
                            x.BuyPrice,
                            x.SellPrice,
                            x.Quantity,
                            x.NetProfit,
                            PC = ((x.SellPrice/x.BuyPrice)*100) - 100
                        })
                    .Where(x => x.BuyPrice > 0)
                    .OrderBy(x => x.PC).ToList();
        }

        private void tabPage6_Enter(object sender, EventArgs e)
        {
            DailyGraph();
        }

        private void tabPage7_Enter(object sender, EventArgs e)
        {
            Rewards();
        }

        private void tabPage8_Enter(object sender, EventArgs e)
        {
            MonthlyBestSellers();
        }

        #endregion

        #endregion

        #region Methods

        private void GetAllAssets()
        {
            IList<StockCheck> stockCheck = new List<StockCheck>();
            //stockCheck.Add(new StockCheck("Test Name", 100, 200));
            //dataGridStock.DataSource = stockCheck.Where(x => x.AssumedStock > 0).ToList(); // .Where(x => x.Difference != 0);
            //return;

            EveRepository repository = new EveRepository();

            var characters = repository.Characters;

            Dictionary<long, long> assets = new Dictionary<long, long>();

            foreach (var character in characters)
            {
                GetAssets(character, ref assets);
            }

            // Get assets currently in Market Sell Orders
            foreach (var character in characters)
            {
                GetSellOrders(character, ref assets);
            }

            // Add assets in pending build orders (we pre-emptively claim the stock when the job starts, but it won't be in station)
            // So the "group by" stock count will include that stock, but the live count won't
            // So we'll reduce the asset count so it matches the live count
            foreach (var character in characters)
            {
                GetIndustryJobs(character, ref assets, false);
            }

            // Loop through the asset IDs and match them to EveItems
            foreach (var asset in assets)
            {
                var item = repository.EveItems.FirstOrDefault(x => x.ItemID == asset.Key);
                if (item != null)
                {
                    stockCheck.Add(new StockCheck(item.ItemName, item.CurrentStock, asset.Value));
                }
            }

           dataGridStock.DataSource = stockCheck
                .Where(x => x.AssumedStock > 0)
                .Where(x => x.Difference != 0)
                .OrderByDescending(x => x.Difference)
                .ToList(); 
        }

        private void SaveIndustryTransactionsEsi(BackgroundWorker worker, Character character)
        {
            EveRepository repository = new EveRepository();

            UpdateProgressMessage("Downloading industry job data");

            var items = new Dictionary<long, long>();
            var industryJobs = GetIndustryJobs(character, ref items, true);

            // Industry - Tashaki 3,200 jobs going back to 10th Nov (90 days max)

            var total = industryJobs.Count;
            if (total < 1) return;

            double processed = 0;

            UpdateProgressMessage("Processing industry jobs");

            // Get minimum Job ID
            var min = industryJobs.Min(x => x.job_id);
                //jobs.Jobs.OrderBy(x => x.EveJobID).First().EveJobID;

            // Get all higher transaction ID's that we've already processed
            var knownTransactions = repository.Jobs.Where(x => x.EveJobID >= min).Select(x => x.EveJobID).ToArray();


            //foreach (Job job in jobs.Jobs.OrderBy(x => x.JobID).Where(x => x.Status == 101))
            //foreach (var esiIndustryJob in industryJobs.Where(x => x.status == "delivered"))
            foreach (var esiIndustryJob in industryJobs)
            {
                processed++;
                int percentProcessed = int.Parse(Math.Round(processed * 100 / total).ToString(CultureInfo.InvariantCulture));
                worker.ReportProgress(percentProcessed);

                // Check the job hasn't been processed before
                if (knownTransactions.Contains(esiIndustryJob.job_id)) continue;

                // Create a job from the esiJob
                Job job = new Job(esiIndustryJob);

                // Don't process invention jobs that haven't completed
                // But it's fine to process manufacturing jobs since we know the outcome (and want to consume the stock of raw mats)
                if (job.Activity == JobType.Invention && job.Status != 101) continue;

                // Save the job
                repository.Jobs.Add(job);
                try
                {
                    repository.SaveChanges();
                }
                catch (Exception ex)
                {
                    var x = ex.InnerException;
                    Console.WriteLine(x);
                    throw;
                }

                if (job.Activity == JobType.Invention)
                {
                    ProcessInventionJob(job);
                }

                if (job.Activity == JobType.Manufacturing)
                {
                    ProcessManufacturingJob(job);
                }
            }
        }

        private void SaveIndustryTransactions(BackgroundWorker worker, Character character)
        {
            EveRepository repository = new EveRepository();

            UpdateProgressMessage("Downloading industry job data");

            // Industry - Tashaki 3,200 jobs going back to 10th Nov (90 days max)

            var industryUrl =
                string.Format(
                    "https://api.eveonline.com/char/IndustryJobsHistory.xml.aspx?keyID={0}&vCode={1}&characterID={2}",
                    character.KeyID, character.vCode, character.EveCharacterID);

            if (CacheService.IsUrlCached(industryUrl, true))
            {
                return;
            }

            var response = HttpServices.MakeHttpRequest(industryUrl, "GET", new WebHeaderCollection());

            var xml = HttpServices.GetXmlStringFromStream(response.GetResponseStream());

            XmlReader xmlReader = XmlReader.Create(new StringReader(xml));

            DataSet dataSet = new DataSet();
            dataSet.ReadXml(xmlReader);

            if (dataSet.Tables.Count < 4) return;

            DateTime cacheUntil;
            if (DateTime.TryParse(dataSet.Tables[0].Rows[0].ItemArray[2].ToString(), out cacheUntil))
            {
                CacheService.SaveUrlCache(industryUrl, cacheUntil);
            }

            IndustryJobs jobs = new IndustryJobs(dataSet.Tables[3]);

            double total = jobs.Jobs.Count(x => x.Status == 101);

            if (total < 1) return;

            double processed = 0;

            UpdateProgressMessage("Processing industry jobs");

            // Get minimum Job ID
            var min = jobs.Jobs.OrderBy(x => x.EveJobID).First().EveJobID;

            // Get all higher transaction ID's that we've already processed
            var knownTransactions = repository.Jobs.Where(x => x.EveJobID >= min).Select(x => x.EveJobID).ToArray();


            foreach (Job job in jobs.Jobs.OrderBy(x => x.JobID).Where(x => x.Status == 101))
            {
                processed++;
                int percentProcessed = int.Parse(Math.Round(processed*100/total).ToString(CultureInfo.InvariantCulture));
                worker.ReportProgress(percentProcessed);

                // Check the job hasn't been processed before
                if (knownTransactions.Contains(job.EveJobID)) continue;

                // Save the job
                repository.Jobs.Add(job);
                try
                {
                    repository.SaveChanges();
                }
                catch (Exception ex)
                {
                    var x = ex.InnerException;
                    Console.WriteLine(x);
                    throw;
                }

                if (job.Activity == JobType.Invention)
                {
                    ProcessInventionJob(job);
                }

                if (job.Activity == JobType.Manufacturing)
                {
                    ProcessManufacturingJob(job);
                }
            }
        }

        private void SaveOngoingIndustryTransactions(BackgroundWorker worker, Character character)
        {
            EveRepository repository = new EveRepository();

            UpdateProgressMessage("Downloading ongoing industry job data");

            var industryUrl =
                string.Format(
                    "https://api.eveonline.com/char/IndustryJobs.xml.aspx?keyID={0}&vCode={1}&characterID={2}",
                    character.KeyID, character.vCode, character.EveCharacterID);

            if (CacheService.IsUrlCached(industryUrl, true))
            {
                return;
            }

            var response = HttpServices.MakeHttpRequest(industryUrl, "GET", new WebHeaderCollection());

            var xml = HttpServices.GetXmlStringFromStream(response.GetResponseStream());

            XmlReader xmlReader = XmlReader.Create(new StringReader(xml));

            DataSet dataSet = new DataSet();
            dataSet.ReadXml(xmlReader);

            if (dataSet.Tables.Count < 4) return;

            DateTime cacheUntil;
            if (DateTime.TryParse(dataSet.Tables[0].Rows[0].ItemArray[2].ToString(), out cacheUntil))
            {
                CacheService.SaveUrlCache(industryUrl, cacheUntil);
            }

            IndustryJobs jobs = new IndustryJobs(dataSet.Tables[3]);

            double total = jobs.Jobs.Count;

            if (total < 1) return;

            double processed = 0;

            UpdateProgressMessage("Processing industry jobs");

            // Get minimum Job ID
            var min = jobs.Jobs.OrderBy(x => x.EveJobID).First().EveJobID;

            // Get all higher transaction ID's that we've already processed
            var knownTransactions = repository.Jobs.Where(x => x.EveJobID >= min).Select(x => x.EveJobID).ToArray();


            foreach (Job job in jobs.Jobs.OrderBy(x => x.EveJobID)) //.Where(x => x.Status == 101))
            {
                processed++;
                int percentProcessed = int.Parse(Math.Round(processed*100/total).ToString(CultureInfo.InvariantCulture));
                worker.ReportProgress(percentProcessed);

                // Check the job hasn't been processed before
                //if (repository.Jobs.Any(x => x.EveJobID == job.EveJobID)) continue;
                if (knownTransactions.Contains(job.EveJobID)) continue;

                if (job.Activity != JobType.Manufacturing) continue;

                // Save the job
                repository.Jobs.Add(job);
                try
                {
                    repository.SaveChanges();
                }
                catch (Exception ex)
                {
                    var x = ex.InnerException;
                    Console.WriteLine(x);
                    throw;
                }

                ProcessManufacturingJob(job);
            }
        }

        private void ProcessManufacturingJob(Job job)
        {
            EveRepository repository = new EveRepository();

            // Get the recipe for the thing we've invented
            Recipe recipe = repository.Recipes.FirstOrDefault(x => x.TypeName == job.ProductTypeName);

            if (recipe == null) return;

            // Get the ingredients for the recipe
            List<RecipeInput> inputs = repository.RecipeInputs.Where(x => x.RecipeID == recipe.RecipeID).ToList();

            decimal cost = (decimal) job.Cost;

            // Add the input costs and remove stock
            foreach (RecipeInput input in inputs)
            {
                var outstandingQuantity = input.Quantity*job.Runs;

                while (outstandingQuantity > 0)
                {
                    var matchingStock =
                        repository.Stocks.OrderBy(x => x.StockID).Where(s => s.TypeName == input.TypeName);

                    var stock = matchingStock.FirstOrDefault();

                    if (stock != null)
                    {
                        if (stock.Quantity > outstandingQuantity)
                        {
                            // Reduce the stock
                            stock.Quantity = stock.Quantity - outstandingQuantity;
                            repository.SaveChanges();

                            cost += stock.Price*outstandingQuantity;

                            outstandingQuantity = 0;
                        }
                        else if (stock.Quantity == outstandingQuantity)
                        {
                            // Remove the stock altogether
                            repository.Stocks.Remove(stock);
                            repository.SaveChanges();

                            cost += stock.Price*outstandingQuantity;

                            outstandingQuantity = 0;
                        }
                        else
                        {
                            // Use the entirity of the current stock item, and then we'll look for more stock

                            outstandingQuantity = outstandingQuantity - stock.Quantity;
                            cost += stock.Price*stock.Quantity;

                            // Remove the stock altogether
                            repository.Stocks.Remove(stock);
                            repository.SaveChanges();
                        }
                    }
                    else
                    {
                        // No stock, so probably loot
                        outstandingQuantity = 0;
                    }
                }
            }

            // Create new stock of manufacture goods
            var multiplier = recipe.OutputMultiplier == 0 ? 1 : recipe.OutputMultiplier;
            Stock manufacturedStock = new Stock(job.ProductTypeName, job.CompletedDate, job.Runs*multiplier)
            {
                Price = cost/(job.Runs*multiplier)
            };
            repository.Stocks.Add(manufacturedStock);
            repository.SaveChanges();
        }

        private void ProcessInventionJob(Job job)
        {
            EveRepository repository = new EveRepository();

            // Get the recipe for the thing we've invented
            Recipe recipe = repository.Recipes.FirstOrDefault(x => x.TypeName == job.ProductTypeName);

            if (recipe == null) return;

            // Get the ingredients for the recipe
            List<RecipeInput> inputs = repository.RecipeInputs.Where(x => x.RecipeID == recipe.RecipeID).ToList();

            decimal inventionCost = (decimal) job.Cost;

            // Add the input costs and remove stock
            foreach (RecipeInput input in inputs)
            {
                var outstandingQuantity = input.Quantity*job.Runs;

                while (outstandingQuantity > 0)
                {
                    var matchingStock =
                        repository.Stocks.OrderBy(x => x.StockID).Where(s => s.TypeName == input.TypeName);

                    var stock = matchingStock.FirstOrDefault();

                    if (stock != null)
                    {
                        if (stock.Quantity > outstandingQuantity)
                        {
                            // Reduce the stock
                            stock.Quantity = stock.Quantity - outstandingQuantity;
                            repository.SaveChanges();

                            inventionCost += stock.Price*outstandingQuantity;

                            outstandingQuantity = 0;
                        }
                        else if (stock.Quantity == outstandingQuantity)
                        {
                            // Remove the stock altogether
                            repository.Stocks.Remove(stock);
                            repository.SaveChanges();

                            inventionCost += stock.Price*outstandingQuantity;

                            outstandingQuantity = 0;
                        }
                        else
                        {
                            // Use the entirity of the current stock item, and then we'll look for more stock

                            outstandingQuantity = outstandingQuantity - stock.Quantity;
                            inventionCost += stock.Price*stock.Quantity;

                            // Remove the stock altogether
                            repository.Stocks.Remove(stock);
                            repository.SaveChanges();
                        }
                    }
                    else
                    {
                        // No stock, so probably loot
                        outstandingQuantity = 0;
                    }
                }
            }

            InventedBlueprint blueprint =
                repository.InventedBluePrints.FirstOrDefault(x => x.TypeName == job.ProductTypeName);

            decimal blueprintcost;
            if (blueprint == null)
            {
                InventedBlueprint newblueprint = new InventedBlueprint(job.ProductTypeName)
                {
                    OutputMultiplier = recipe.OutputMultiplier
                };

                newblueprint.AddAttempts(job.Runs, job.SuccessfulRuns, inventionCost);
                blueprintcost = newblueprint.AverageCost;
                repository.InventedBluePrints.Add(newblueprint);
                repository.SaveChanges();
            }
            else
            {
                blueprint.AddAttempts(job.Runs, job.SuccessfulRuns, inventionCost);
                blueprintcost = blueprint.AverageCost;
                repository.SaveChanges();
            }

            // Create new stock of blueprints
            // Create the number of blueprints equal to the total number of *runs* on the output
            // Manufacturing jobs will then consume 1 blueprint per run
            var multiplier = recipe.OutputMultiplier == 0 ? 1 : recipe.OutputMultiplier;
            Stock blueprintStock = new Stock(job.ProductTypeName, job.CompletedDate, job.SuccessfulRuns*multiplier)
            {
                Price = blueprintcost/multiplier
            };
            repository.Stocks.Add(blueprintStock);
            repository.SaveChanges();
        }

        private void ProcessCharacters(BackgroundWorker worker, DoWorkEventArgs e)
        {
            EveRepository repository = new EveRepository();

            var characters = repository.Characters;

            foreach (var character in characters)
            {
                ProcessCharacter(worker, character);
            }
        }

        private void ProcessCharacter(BackgroundWorker worker, Character character)
        {
            try
            {
                SaveJournalEntriesEsi(character);

                var esiWalletTransactions = GetWalletTransactions(character);

                // TODO - Record max transaction ID per character, so we can just get new ones each call
                var esiSortedWalletTransactions = esiWalletTransactions.OrderBy(w => w.date).Where(x => x.transaction_id > 4035379244).ToList();
                var esiBuyTransactions = esiSortedWalletTransactions.Where(t => t.is_buy);
                var esiSellTransactions = esiSortedWalletTransactions.Where(t => !t.is_buy);

                UpdateProgressMessage(string.Format("Processing...{0} Buy Transactions", character.Name));
                EsiRefreshToken token = GetRefreshToken(character);
                WalletService.ProcessBuyTransactions(esiBuyTransactions, token, worker);

                worker.ReportProgress(0);

                UpdateProgressMessage(string.Format("Processing...{0} Industry Jobs", character.Name));

                // TODO - Convert to ESI
                SaveIndustryTransactionsEsi(worker, character);

                // TODO - Convert to ESI
                //SaveOngoingIndustryTransactions(worker, character);

                worker.ReportProgress(0);

                UpdateProgressMessage(string.Format("Processing...{0} Sell Transactions", character.Name));
                token = GetRefreshToken(character);
                WalletService.ProcessSellTransactions(esiSellTransactions, token, worker);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void SaveJournalEntriesEsi(Character character)
        {
            var results = GetWalletJournal(character);

            var missionRewards = results.Where(x => x.ref_type == "agent_mission_reward");
            var missionBonus = results.Where(x => x.ref_type == "agent_mission_time_bonus_reward");
            var bounties = results.Where(x => x.ref_type == "bounty_prizes");

            var repository = new EveRepository();

            foreach (var esiWalletJournal in missionRewards)
            {
                if (JournalEntryExists(repository, esiWalletJournal.ref_id)) continue;

                var reward = CreateReward(esiWalletJournal, "Mission Reward");
                repository.Rewards.Add(reward);
            }

            foreach (var esiWalletJournal in missionBonus)
            {
                if (JournalEntryExists(repository, esiWalletJournal.ref_id)) continue;

                var reward = CreateReward(esiWalletJournal, "Mission Reward Bonus");
                repository.Rewards.Add(reward);
            }

            foreach (var esiWalletJournal in bounties)
            {
                if (JournalEntryExists(repository, esiWalletJournal.ref_id)) continue;

                var reward = CreateReward(esiWalletJournal, "Bounty Prize");
                repository.Rewards.Add(reward);
            }

            repository.SaveChanges();
        }

        private static Reward CreateReward(EsiWalletJournal journalEntry, string description)
        {
            Reward reward = new Reward();
            reward.Date = journalEntry.date;
            reward.Description = description;
            reward.Amount = journalEntry.amount;
            reward.EveJournalID = journalEntry.ref_id;

            return reward;
        }

        #region Update Data Grids

        public void BestSellers()
        {
            EveRepository repository = new EveRepository();

            var query = from sale in repository.Sales
                group sale by sale.TypeName
                into g
                select new {Item = g.Key, Profit = g.Sum(sale => sale.NetProfit)};

            dataGridView1.DataSource = query.OrderByDescending(s => s.Profit).ToList();
        }

        public void Stock()
        {
            EveRepository repository = new EveRepository();

            stockGridView.DataSource = repository.Stocks.OrderBy(stock => stock.Date).ToList();
        }

        public void StockByName()
        {
            try
            {
                EveRepository repository = new EveRepository();

                var query = from stock in repository.Stocks
                    group stock by stock.TypeName
                    into g
                    select
                        new
                        {
                            Item = g.Key,
                            Quantity = g.Sum(stock => stock.Quantity),
                            AverageValue = g.Average(stock => stock.Price)
                        };

                groupedStockGridView.DataSource = query.OrderByDescending(s => s.Quantity).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Sales()
        {
            EveRepository repository = new EveRepository();

            salesDataGridView.DataSource = repository.Sales.OrderBy(sale => sale.SellDate).ToList();
        }

        public void DailyGraph()
        {
            EveRepository repository = new EveRepository();

            dailyGraph.GraphPane.CurveList.Clear();
            dailyGraph.GraphPane.GraphObjList.Clear();

            var startDate = DateTime.Now.AddDays(-14);

            // Find sales of bought items
            var query = from sale in repository.Sales
                where sale.BuyPrice > 0
                      && sale.SellDate > startDate
                group sale by new {y = sale.SellDate.Year, m = sale.SellDate.Month, d = sale.SellDate.Day}
                into g
                select
                    new DateProfit
                    {
                        Day = g.Key.d,
                        Month = g.Key.m,
                        Year = g.Key.y,
                        Profit = g.Sum(sale => sale.NetProfit)
                    };

            var res = query.OrderBy(s => s.Year).ThenBy(s => s.Month).ThenBy(s => s.Day).ToList();

            var query2 = from x in res
                select new FullDateProfit {Date = x.Date, Profit = x.Profit};

            var fullDateProfits = query2 as IList<FullDateProfit> ?? query2.ToList();
            var profitList = fullDateProfits.ToDictionary(x => x.Date, x => x.Profit); // May contain gaps

            // Generate an array of dates to fill in the blanks
            //var sd = new DateTime(2012, 12, 20);
            var sd = new DateTime(startDate.Year, startDate.Month, startDate.Day);
            var now = DateTime.Now;
            var fullDateArray = new List<string>();
            while (sd < now)
            {
                fullDateArray.Add(string.Format("{0}-{1:00}-{2:00}", sd.Year, sd.Month, sd.Day));
                sd = sd.AddDays(1);
            }

            // This should plug the gaps in profitList (with missing days at the end?)
            foreach (var fullDate in fullDateArray)
            {
                if (!profitList.ContainsKey(fullDate))
                {
                    profitList.Add(fullDate, 1);
                }
            }

            dailyGridView.DataSource = fullDateProfits.ToList();

            // Graph stuff
            GraphPane graphPane = dailyGraph.GraphPane;

            // Add the sales bar to the graph
            BarItem profitBar = graphPane.AddBar("Sales", null,
                profitList.OrderBy(x => x.Key).Select(x => (double) x.Value).ToArray(), Color.Blue);
            profitBar.Bar.Fill = new Fill(Color.Blue, Color.Blue, Color.Blue);


            graphPane.XAxis.Scale.TextLabels = fullDateArray.ToArray();
            graphPane.XAxis.Type = AxisType.Text;

            #region Loot

            // Find sales of loot
            var queryLoot = from sale in repository.Sales
                where sale.BuyPrice < 0.01m
                      && sale.SellDate > startDate
                group sale by new {y = sale.SellDate.Year, m = sale.SellDate.Month, d = sale.SellDate.Day}
                into g
                select
                    new DateProfit
                    {
                        Day = g.Key.d,
                        Month = g.Key.m,
                        Year = g.Key.y,
                        Profit = g.Sum(sale => sale.NetProfit)
                    };

            var resLoot = queryLoot.OrderBy(s => s.Year).ThenBy(s => s.Month).ThenBy(s => s.Day).ToList();

            var query2Loot = from x in resLoot
                select new FullDateProfit {Date = x.Date, Profit = x.Profit};

            var profitListLoot = query2Loot.ToDictionary(x => x.Date, x => x.Profit);

            foreach (var fullDate in fullDateArray)
            {
                if (!profitListLoot.ContainsKey(fullDate))
                {
                    profitListLoot.Add(fullDate, 1);
                }
            }

            BarItem profitBarLoot = graphPane.AddBar("Loot", null,
                profitListLoot.OrderBy(x => x.Key).Select(x => (double) x.Value).ToArray(), Color.Red);
            profitBarLoot.Bar.Fill = new Fill(Color.Red, Color.Red, Color.Red);

            #endregion

            #region Mission

            // Find sales of loot
            var missionRewards = from reward in repository.Rewards
                where reward.Date > startDate
                group reward by new {y = reward.Date.Year, m = reward.Date.Month, d = reward.Date.Day}
                into g
                select
                    new DateProfit
                    {
                        Day = g.Key.d,
                        Month = g.Key.m,
                        Year = g.Key.y,
                        Profit = g.Sum(reward => reward.Amount)
                    };

            var resRewards = missionRewards.OrderBy(s => s.Year).ThenBy(s => s.Month).ThenBy(s => s.Day).ToList();

            var query2Reward = from x in resRewards
                select new FullDateProfit {Date = x.Date, Profit = (decimal) x.Profit};

            var profitListReward = query2Reward.ToDictionary(x => x.Date, x => x.Profit);

            foreach (var fullDate in fullDateArray)
            {
                if (!profitListReward.ContainsKey(fullDate))
                {
                    profitListReward.Add(fullDate, 1);
                }
            }

            BarItem profitBarReward = graphPane.AddBar("Mission", null,
                profitListReward.OrderBy(x => x.Key).Select(x => (double) x.Value).ToArray(), Color.Yellow);
            profitBarReward.Bar.Fill = new Fill(Color.Yellow, Color.Yellow, Color.Yellow);

            #endregion

            graphPane.BarSettings.Type = BarType.Stack;

            graphPane.XAxis.Scale.TextLabels = fullDateArray.ToArray();

            graphPane.AxisChange();

            graphPane.Title.IsVisible = false;
            graphPane.XAxis.Title.IsVisible = false;
            graphPane.XAxis.Title.Text = "Date";
            graphPane.YAxis.Title.Text = "Profit";
        }

        public void Rewards()
        {
            EveRepository repository = new EveRepository();
            journalDataGridView.DataSource = repository.Rewards.OrderBy(reward => reward.Date).ToList();
        }

        public void DailyRewards()
        {
            EveRepository repository = new EveRepository();

            var missionRewards = from reward in repository.Rewards
                group reward by new {y = reward.Date.Year, m = reward.Date.Month, d = reward.Date.Day}
                into g
                select
                    new DateProfit
                    {
                        Day = g.Key.d,
                        Month = g.Key.m,
                        Year = g.Key.y,
                        Profit = g.Sum(reward => reward.Amount)
                    };

            var resRewards = missionRewards.OrderBy(s => s.Year).ThenBy(s => s.Month).ThenBy(s => s.Day).ToList();

            var query2Reward = from x in resRewards
                select new FullDateProfit {Date = x.Date, Profit = x.Profit};

            var profitList = query2Reward.ToList();

            dailyRewardsDataGridView.DataSource = profitList;
        }

        public void MonthlyBestSellers()
        {
            EveRepository repository = new EveRepository();

            int month = chkLastMonth.Checked ? DateTime.Now.AddMonths(-1).Month : DateTime.Now.Month;
            int year = chkLastMonth.Checked ? DateTime.Now.AddMonths(-1).Year : DateTime.Now.Year;
            DateTime start = new DateTime(year, month, 1);
            DateTime end = start.AddMonths(1);

            if (chkIncludeLoot.Checked)
            {
                var query = from sale in repository.Sales
                    where sale.SellDate > start && sale.SellDate < end
                    group sale by sale.TypeName
                    into g
                    select
                        new {Item = g.Key, Profit = g.Sum(sale => sale.NetProfit), Units = g.Sum(sale => sale.Quantity)};

                dailyRewardsDataGridView.DataSource = query.OrderByDescending(s => s.Profit).ToList();

                var total = query.AsEnumerable().Sum(sale => sale.Profit);

                lblTotal.Text = string.Format("{0:C}", total);

                ShowProjection(total);
            }
            else
            {
                var query = from sale in repository.Sales
                    where sale.SellDate > start && sale.SellDate < end && sale.BuyPrice > 0
                    group sale by sale.TypeName
                    into g
                    select
                        new {Item = g.Key, Profit = g.Sum(sale => sale.NetProfit), Units = g.Sum(sale => sale.Quantity)};

                dailyRewardsDataGridView.DataSource = query.OrderByDescending(s => s.Profit).ToList();

                var total = query.AsEnumerable().Sum(sale => sale.Profit);

                lblTotal.Text = string.Format("{0:C}", total);

                ShowProjection(total);
            }
        }

        private void ShowProjection(decimal total)
        {
            if (chkLastMonth.Checked)
            {
                var day = DateTime.Now.Day;
                var perDay = total/day;
                lblPerDay.Text = string.Format("{0:C}", perDay);
                lblProjected.Text = string.Empty;
            }
            else
            {
                var day = DateTime.Now.Day;
                var perDay = total/day;
                lblPerDay.Text = string.Format("{0:C}", perDay);
                lblProjected.Text = string.Format("{0:C}", perDay*30);
            }
        }

        public void Recipes()
        {
            EveRepository repository = new EveRepository();

            dataGridRecipes.DataSource = repository.Recipes.OrderBy(x => x.TypeName).ToList();
        }

        #endregion

        #region Repository Helper Methods

        public bool WalletTransactionExists(EveRepository repository, long transactionId)
        {
            return repository.WalletTransactions.Any(x => x.TransactionIDFromEve == transactionId);
        }

        public bool JournalEntryExists(EveRepository repository, long transactionId)
        {
            return repository.Rewards.Any(x => x.EveJournalID == transactionId);
        }

        #endregion

        #region Stock Grid Events

        private void stockGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            EveRepository repository = new EveRepository();

            if (e.ColumnIndex == 0)
            {
                var id = (long) stockGridView.Rows[e.RowIndex].Cells["StockID"].Value;

                var stockToDelete = repository.Stocks.FirstOrDefault(stock => stock.StockID == id);

                if (stockToDelete != null)
                {
                    repository.Stocks.Remove(stockToDelete);

                    repository.SaveChanges();
                }
            }

            Stock();
        }

        #endregion

        #region Datagrid Formatting

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                decimal possibleDecimal;
                if (decimal.TryParse(e.Value.ToString(), out possibleDecimal))
                {
                    //decimal profit = (decimal) e.Value;
                    e.Value = possibleDecimal.ToString("#,###.00");
                    e.FormattingApplied = true;
                }
            }
        }

        private void recentSalesDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            int possibleInteger;
            if (int.TryParse(e.Value.ToString(), out possibleInteger))
            {
                e.Value = possibleInteger.ToString("#,###");
                e.FormattingApplied = true;
                return;
            }

            double profit;
            if (double.TryParse(e.Value.ToString(), out profit))
            {
                e.Value = profit.ToString("#,###.00");
                e.FormattingApplied = true;
            }

            if (e.ColumnIndex == 6)
            {
                if (profit > 0)
                {
                    var row = recentSalesDataGridView.Rows[e.RowIndex];
                    row.DefaultCellStyle.BackColor = Color.LightGray;
                }

                if (profit > 50)
                {
                    var row = recentSalesDataGridView.Rows[e.RowIndex];
                    row.DefaultCellStyle.BackColor = Color.Khaki;
                }

                if (profit > 100)
                {
                    var row = recentSalesDataGridView.Rows[e.RowIndex];
                    row.DefaultCellStyle.BackColor = Color.LightGreen;
                }

                e.FormattingApplied = true;
            }

        }

        private void salesDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            int possibleInteger;
            if (int.TryParse(e.Value.ToString(), out possibleInteger))
            {
                e.Value = possibleInteger.ToString("#,###");
                e.FormattingApplied = true;
                return;
            }

            double profit;
            if (double.TryParse(e.Value.ToString(), out profit))
            {
                e.Value = profit.ToString("#,###.00");
                e.FormattingApplied = true;
            }
        }

        private void dailyGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                double profit = (double) e.Value;
                e.Value = profit.ToString("#,###.00");
                e.FormattingApplied = true;
            }
        }

        private void stockGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                decimal profit = (decimal) e.Value;
                e.Value = profit.ToString("#,###.00");
                e.FormattingApplied = true;
            }
        }

        private void dailyRewardsDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                decimal profit = (decimal) e.Value;
                e.Value = profit.ToString("#,###.00");
                e.FormattingApplied = true;
            }
        }

        private void groupedStockGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            double profit;

            if (double.TryParse(e.Value.ToString(), out profit))
            {
                e.Value = profit.ToString("#,###.00");
                e.FormattingApplied = true;
            }

            if (e.ColumnIndex == 3 || e.ColumnIndex == 2)
            {
                var row = groupedStockGridView.Rows[e.RowIndex];
                var myPriceString = row.Cells[1].Value.ToString();
                double myPrice;
                if (double.TryParse(myPriceString, out myPrice))
                {
                    if (profit < myPrice)
                    {
                        row.Cells[e.ColumnIndex].Style.BackColor = Color.LightCoral;
                    }
                    else
                    {
                        if (profit > myPrice*1.1)
                        {
                            row.Cells[e.ColumnIndex].Style.BackColor = Color.Khaki;
                        }

                        if (profit > myPrice*1.5)
                        {
                            row.Cells[e.ColumnIndex].Style.BackColor = Color.LightGreen;
                        }
                    }
                    e.FormattingApplied = true;
                }

                //if (profit > 0)
                //{
                //    row.DefaultCellStyle.BackColor = Color.LightGray;
                //}

                //if (profit > 50)
                //{
                //    row.DefaultCellStyle.BackColor = Color.Khaki;
                //}

            }

        }

        #endregion

        #region Background Worker

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            ProcessCharacters(worker, e); // And Industry Jobs
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            _loadingForm.ProgressValue = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            _loadingForm.ProgressValue = 100;
            UpdateProgressMessage("Complete");
        }

        private void UpdateProgressMessage(string message)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => UpdateProgressMessage(message)));
            }
            else
            {
                _loadingForm.ProgressMessage = message;
            }
        }

        #endregion

        private void SearchSales()
        {
            EveRepository repository = new EveRepository();

            // ReSharper disable once ConvertIfStatementToConditionalTernaryExpression
            if (txtSearchSales.Text == string.Empty)
            {
                salesDataGridView.DataSource = repository.Sales.OrderBy(sale => sale.SellDate).ToList();
            }
            else
            {
                salesDataGridView.DataSource =
                    repository.Sales.Where(sale => sale.TypeName.Contains(txtSearchSales.Text))
                        .OrderBy(sale => sale.SellDate)
                        .ToList();
            }
        }

        private void DateFilteredSales(DateTime startDate)
        {
            EveRepository repository = new EveRepository();

            List<Sale> res;

            if (txtSearchSales.Text == string.Empty)
            {
                res = repository.Sales
                    .OrderBy(sale => sale.SellDate).ToList();
            }
            else
            {
                res = repository.Sales
                    .Where(sale => sale.TypeName.Contains(txtSearchSales.Text))
                    .OrderBy(sale => sale.SellDate).ToList();
            }

            var limitedRes = res.Where(s => s.SellDate > startDate);

            salesDataGridView.DataSource =
                limitedRes.Select(
                    x =>
                        new
                        {
                            x.TypeName,
                            x.SellDate,
                            x.BuyPrice,
                            x.SellPrice,
                            x.Quantity,
                            x.NetProfit,
                            PC = ((x.SellPrice/(x.BuyPrice == 0 ? 1 : x.BuyPrice))*100) - 100
                        }).ToList();
        }

        #region Stock Management

        private void btnAddStock_Click(object sender, EventArgs e)
        {
            StockManagementService.AddStock(txtAddStockName.Text, DateTime.Now, int.Parse(txtAddStockQuantity.Text), decimal.Parse(txtAddStockPrice.Text));
        }

        private void btnSetStock_Click(object sender, EventArgs e)
        {
            // Get the current stock
            EveRepository repository = new EveRepository();

            var query = from stock in repository.Stocks
                where stock.TypeName.Equals(txtSetStockName.Text)
                group stock by stock.TypeName
                into g
                select
                    new
                    {
                        Item = g.Key,
                        Quantity = g.Sum(stock => stock.Quantity),
                        AverageValue = g.Average(stock => stock.Price)
                    };

            var currentStock = query.FirstOrDefault();

            if (currentStock == null)
            {
                // Add stock if we don't have any
                StockManagementService.AddStock(txtSetStockName.Text, DateTime.Now, int.Parse(txtSetStockQuantity.Text), (decimal)0.01 );
                return;
            }

            var stockDifference = currentStock.Quantity - int.Parse(txtSetStockQuantity.Text);
            if (stockDifference > 0)
            {
                StockManagementService.RemoveStock(txtSetStockName.Text, stockDifference);
            }
            else
            {
                StockManagementService.AddStock(txtSetStockName.Text, DateTime.Now, stockDifference*-1, currentStock.AverageValue);
            }
        }

        #endregion

        #endregion

        #region Prices

        public void OldestStockPrice()
        {
            try
            {
                EveRepository repository = new EveRepository();

                var results = repository.Stocks
                    .GroupBy(p => p.TypeName,
                        (x, y) => new
                        {
                            TypeName = x,
                            Value = y.OrderBy(z => z.Date).FirstOrDefault()
                        })
                    .Select(i => new
                    {
                        i.TypeName,
                        i.Value.Price
                    });

                if (chkOnlyTrackedPrices.Checked)
                {
                    var filter = results.Join(repository.EveItems,
                        left => left.TypeName,
                        right => right.ItemName,
                        (left, right) => new {Left = left, Right = right})
                        .Where(x => x.Right.TrackPrices)
                        .Where(x => !x.Left.TypeName.Contains("Blueprint"))
                        .Select(a => new {a.Left.TypeName, a.Left.Price, a.Right.BuyPrice, a.Right.SellPrice});

                    groupedStockGridView.DataSource = filter.OrderBy(s => s.TypeName).ToList();
                }
                else
                {
                    var filter = results.Join(repository.EveItems,
                        left => left.TypeName,
                        right => right.ItemName,
                        (left, right) => new {Left = left, Right = right})
                        .Select(a => new {a.Left.TypeName, a.Left.Price, a.Right.BuyPrice, a.Right.SellPrice});

                    groupedStockGridView.DataSource = filter.OrderBy(s => s.TypeName).ToList();
                }

            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }



        private void GetPrices()
        {
            EveRepository repository = new EveRepository();

            var items = repository.EveItems.Where(x => x.TrackPrices)
                .Where(x => !x.ItemName.Contains("Blueprint"));
                //.Select(x => new { x.ItemID }).ToArray();

            //var character = repository.Characters.First();
            

            foreach (var item in items)
            {
                var prices = GetPricesEsi(item.ItemID);

                var minSell = prices
                    .Where(x => x.type_id == item.ItemID)
                    .Where(x => x.is_buy_order == false)
                    .Select(x => x.price)
                    .DefaultIfEmpty(0)
                    .Min();
                    //.Min(x => x.price);

                var maxBuy = prices
                    .Where(x => x.type_id == item.ItemID)
                    .Where(x => x.is_buy_order == true)
                    .Select(x => x.price)
                    .DefaultIfEmpty(0)
                    .Max();
                //.Max(x => x.price);
                //.FirstOrDefault();

                // TODO 
                item.SellPrice = minSell;
                item.BuyPrice = maxBuy;
            }

            //var iterations = Math.Floor((decimal)items.Length / 50) + 1;
            //for (int i = 0; i < iterations; i++)
            //{
            //    var batchitems = items.Skip(i * 50).Take(50);

            //    var result = string.Join(",", batchitems.AsEnumerable().Select(row => row.ItemID));

            //    var rensurl = string.Format(EveCentralMarketStatUrl, result, RensRegionId);
            //    GetPricesBatch(rensurl, RensRegionId);

            //    var jitaurl = string.Format(EveCentralMarketStatUrl, result, JitaRegionId);
            //    GetPricesBatch(jitaurl, JitaRegionId);
            //}

            //// Reset prices on things we no longer track
            //var reset = repository.EveItems.Where(x => x.TrackPrices == false)
            //    .Where(x => x.SellPrice > 0);

            //foreach (var item in reset)
            //{
            //    var eveItem = repository.EveItems.FirstOrDefault(x => x.ItemID == item.ItemID);
            //    if (eveItem != null)
            //    {
            //        eveItem.ResetPrices();
            //    }
            //}

            repository.SaveChanges();
        }

        private void GetPricesBatch(string url, string region)
        {
            EveRepository repository = new EveRepository();

            XmlDocument xmld = new XmlDocument();

            xmld.Load(url);

            XmlNodeList nodeList = xmld.SelectNodes("/evec_api/marketstat/type");

            if (nodeList == null) return;

            foreach (XmlNode node in nodeList)
            {
                Debug.Write(node);

                EveCentralPrice eveCentralPrice = new EveCentralPrice();

                eveCentralPrice.TypeID = Int32.Parse(node.Attributes.GetNamedItem("id").Value);

                var eveItem = repository.EveItems.FirstOrDefault(x => x.ItemID == eveCentralPrice.TypeID);

                if (eveItem == null) continue;

                foreach (XmlNode subNode in node.ChildNodes)
                {
                    if (subNode.Name == "buy")
                    {
                        // Max Buy
                        //eveCentralPrice.BuyPrice = subNode.ChildNodes.Item(2).InnerText;
                        var buyPriceString = subNode.ChildNodes.Item(2).InnerText;
                        double buyPrice;
                        if (double.TryParse(buyPriceString, out buyPrice))
                        {
                            if (region == RensRegionId)
                            {
                                eveItem.BuyPrice = buyPrice;
                            }

                            if (region == JitaRegionId)
                            {
                                eveItem.JitaBuyPrice = buyPrice;
                            }
                        }
                    }
                    if (subNode.Name == "sell")
                    {
                        // Min Sell
                        //eveCentralPrice.BuyPrice = subNode.ChildNodes.Item(3).InnerText;
                        var sellPriceString = subNode.ChildNodes.Item(3).InnerText;
                        double sellPrice;
                        if (double.TryParse(sellPriceString, out sellPrice))
                        {
                            if (region == RensRegionId)
                            {
                                eveItem.SellPrice = sellPrice;
                            }

                            if (region == JitaRegionId)
                            {
                                eveItem.JitaSellPrice = sellPrice;
                            }
                        }
                    }
                }

                repository.SaveChanges();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OldestStockPrice();
        }

        private void btnGetEveCentralPrices_Click(object sender, EventArgs e)
        {
            GetPrices();
        }

        #endregion

        #region Build

        private void btnBuildOrder_Click(object sender, EventArgs e)
        {
            bool limitBuildTime = chkBuildLimit.Checked;
            decimal maxBuildTime;

            decimal.TryParse(txtBuildTimeLimit.Text, out maxBuildTime);

            EveRepository repository = new EveRepository();

            IList<BuildItem> buildList = new List<BuildItem>();
            Dictionary<string, long> buyList = new Dictionary<string, long>();

            // Current stock of everything
            var query = from stock in repository.Stocks
                group stock by stock.TypeName
                into g
                select
                    new
                    {
                        Item = g.Key,
                        Quantity = g.Sum(stock => stock.Quantity),
                        AverageValue = g.Average(stock => stock.Price)
                    };

            var pricequery = from stock in repository.Stocks
                group stock by stock.TypeName
                into g
                select
                    new
                    {
                        Item = g.Key,
                        Quantity = g.Sum(stock => stock.Quantity),
                        AverageValue = g.Average(stock => stock.Price)
                    };


            var currentStock = query.OrderByDescending(s => s.Quantity).ToDictionary(v => v.Item, v => v.Quantity);
            var avgStockPrice = pricequery.ToDictionary(x => x.Item, x => x.AverageValue);
            var sellPrices = repository.EveItems.Where(x => x.TrackPrices)
                .ToDictionary(x => x.ItemName, x => x.SellPrice);
            var buyPrices = repository.EveItems.Where(x => x.TrackPrices).ToDictionary(x => x.ItemName, x => x.BuyPrice);
            var recipes = repository.Recipes.Where(x => x.MaximumStock > 0);
            var bpStockPrice = repository.InventedBluePrints.ToDictionary(x => x.TypeName, x => x.AverageCost);

            foreach (var recipe in recipes)
            {
                long stock = 0;
                if (currentStock.ContainsKey(recipe.TypeName))
                {
                    stock = currentStock[recipe.TypeName];
                }

                // Quit if we already have enough stock
                //if (stock >= recipe.MaximumStock) continue;

                // Quit if we can't find a market sell price
                //if (!sellPrices.ContainsKey(recipe.TypeName)) continue;

                var buildItem = new BuildItem(recipe.TypeName, recipe.OutputMultiplier)
                {
                    QuantityNeeded = recipe.MaximumStock - stock,
                    MarketSellPrice =
                        sellPrices.ContainsKey(recipe.TypeName) ? (decimal) sellPrices[recipe.TypeName] : 0,
                    UnitBuildTime = recipe.BuildTimeHours
                };

                if (limitBuildTime)
                {
                    if (recipe.BuildTimeHours > 0)
                    {
                        buildItem.BuildLimit =
                            (long)
                                Math.Min(Math.Floor(maxBuildTime/recipe.BuildTimeHours)*recipe.OutputMultiplier,
                                    buildItem.QuantityNeeded);

                        if (buildItem.BuildLimit > recipe.MaxRuns)
                        {
                            buildItem.BuildLimit = recipe.MaxRuns;
                        }
                    }
                }

                if (buyPrices.ContainsKey(recipe.TypeName))
                {
                    buildItem.MarketBuyPrice = (decimal) buyPrices[recipe.TypeName];
                }

                double unitBuildPrice = 0;

                // Get total buy prices of ingredients
                var inputs = repository.RecipeInputs.Where(x => x.RecipeID == recipe.RecipeID).ToList();

                foreach (var input in inputs)
                {
                    if (avgStockPrice.ContainsKey(input.TypeName))
                    {
                        // Calculate using the held stock price - assuming we have enough stock to cover the full amount
                        unitBuildPrice += (double) avgStockPrice[input.TypeName]*input.Quantity/recipe.OutputMultiplier;
                    }
                    else
                    {
                        if (bpStockPrice.ContainsKey(input.TypeName))
                        {
                            // If it's an invented blueprint, and we don't have stock, we know how much they generally cost
                            unitBuildPrice += (double) bpStockPrice[input.TypeName]*input.Quantity;
                        }
                        else
                        {
                            buildItem.Notes += string.Format("No stock price for {0}", input.TypeName);

                            if (buyPrices.ContainsKey(input.TypeName))
                            {
                                // Calculate using market buy price
                                unitBuildPrice += (double) buyPrices[input.TypeName]*BrokerFeeMultiplier*input.Quantity/
                                                  recipe.OutputMultiplier;
                            }
                            else
                            {
                                // Unknown price - log this somewhere
                                buildItem.Notes += string.Format("No price for {0}", input.TypeName);
                            }
                        }
                    }

                    // Check stock
                    if (currentStock.ContainsKey(input.TypeName))
                    {
                        var ingredientStock = currentStock[input.TypeName];
                        var missingStock = (buildItem.QuantityNeeded*input.Quantity) - ingredientStock;

                        if (input.TypeName.Contains("Blueprint"))
                        {
                            buildItem.Blueprints = ingredientStock;
                            if (missingStock > 0)
                            {
                                buildItem.Research = true;
                            }
                        }
                        else
                        {
                            if (missingStock > 0)
                            {
                                buildItem.Notes += string.Format("Need to buy {0} units of {1}", missingStock,
                                    input.TypeName);

                                if (buyList.ContainsKey(input.TypeName))
                                {
                                    buyList[input.TypeName] += missingStock;
                                }
                                else
                                {
                                    buyList.Add(input.TypeName, missingStock);
                                }
                            }
                        }
                    }
                    else
                    {
                        if (input.TypeName.Contains("Blueprint"))
                        {
                            // We don't have any BPCs
                            buildItem.Research = true;
                            buildItem.Blueprints = 0;
                        }
                        else
                        {
                            var missingStock = (buildItem.QuantityNeeded*input.Quantity);
                            buildItem.Notes += string.Format("Need to buy {0} units of {1}", missingStock,
                                input.TypeName);

                            if (buyList.ContainsKey(input.TypeName))
                            {
                                buyList[input.TypeName] += missingStock;
                            }
                            else
                            {
                                buyList.Add(input.TypeName, missingStock);
                            }

                        }
                    }
                }

                buildItem.BuildPrice = (decimal) unitBuildPrice;

                buildList.Add(buildItem);
            }

            SaveBuildPrices(buildList, repository);

            if (limitBuildTime)
            {
                dataGridViewBuild.DataSource =
                    buildList.Where(s => s.QuantityNeeded > 0).OrderByDescending(s => s.ProfitPerBuildLimit).ToList();
            }
            else
            {
                dataGridViewBuild.DataSource =
                    buildList.Where(s => s.QuantityNeeded > 0).OrderByDescending(s => s.ProfitPerHour).ToList();
            }

            dataGridViewPurchase.DataSource = buyList.ToList();
        }

        private void SaveBuildPrices(IList<BuildItem> buildItems, EveRepository repository)
        {
            foreach (var buildItem in buildItems)
            {
                var eveItem = repository.EveItems.First(x => x.ItemName == buildItem.TypeName);

                if (eveItem == null) continue;

                eveItem.BuildPrice = (double) buildItem.BuildPrice;

                repository.SaveChanges();
            }
        }

        private void dataGridViewBuild_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            double profit;

            if (double.TryParse(e.Value.ToString(), out profit))
            {
                e.Value = profit.ToString("#,###.00");
                e.FormattingApplied = true;

                if (profit < 0)
                {
                    var row = dataGridViewBuild.Rows[e.RowIndex];
                    row.DefaultCellStyle.BackColor = Color.LightCoral;
                }
            }

            bool isBool;
            if (bool.TryParse(e.Value.ToString(), out isBool))
            {
                if (isBool)
                {
                    e.CellStyle.BackColor = Color.LightGreen;
                }
            }
        }

        #endregion

        #region Eve Items

        private void btnEveItems_Click(object sender, EventArgs e)
        {
            EveRepository repository = new EveRepository();

            var eveItems = repository.EveItems
                .Where(x => x.ItemName.Contains(txtEveItemSearch.Text))
                .Select(
                    g =>
                        new
                        {
                            g.ItemName,
                            JitaBuy = g.JitaBuyPrice*BrokerFeeMultiplier,
                            JitaSell = g.JitaSellPrice,
                            RensBuy = g.BuyPrice*BrokerFeeMultiplier,
                            RensSell = g.SellPrice,
                            g.BuildPrice,
                            g.TrackPrices,
                            g.TargetStock,
                            g.CurrentStock,
                            NeedStock = g.TargetStock - g.CurrentStock
                        });

            // Note - no broker fee if using the Sell Price as it's an immediate purchase.
            // If Buy Price + Broker Fee is > Sell Price, may as well just buy immediately

            //const double BrokerFeeMultiplier = 1.0217;  2.17%
            //public const decimal SalesFeeMultiplier = 0.9688M;  3.12%


            if (chkTrackedPrices.Checked)
            {
                eveItems = eveItems.Where(x => x.TrackPrices);
            }

            if (chkNeedBuy.Checked)
            {
                eveItems = eveItems.Where(x => x.NeedStock > 0);
            }

            dataGridEveItems.DataSource = eveItems.OrderBy(x => x.ItemName).ToList();
        }

        private void dataGridEveItems_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string cellValue = dataGridEveItems.Rows[e.RowIndex].Cells[0].Value.ToString();

            _eveItemForm = new EveItemForm(cellValue);
            _eveItemForm.Show();
        }

        private void dataGridEveItems_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                var row = dataGridEveItems.Rows[e.RowIndex];

                Dictionary<int, double> prices = new Dictionary<int, double>
                {
                    {1, (double) row.Cells[1].Value},
                    {2, (double) row.Cells[2].Value},
                    {3, (double) row.Cells[3].Value},
                    {4, (double) row.Cells[4].Value},
                    {5, (double) row.Cells[5].Value}
                };


                var minValue = prices.Where(v => v.Value > 0).OrderBy(v => v.Value).FirstOrDefault().Key;

                row.Cells[1].Style.BackColor = Color.White;
                row.Cells[2].Style.BackColor = Color.White;
                row.Cells[3].Style.BackColor = Color.White;
                row.Cells[4].Style.BackColor = Color.White;
                row.Cells[5].Style.BackColor = Color.White;

                row.Cells[minValue].Style.BackColor = Color.LightGreen;
            }

            if (e.ColumnIndex >= 1 && e.ColumnIndex <= 5)
            {
                double price;

                if (double.TryParse(e.Value.ToString(), out price))
                {
                    e.Value = price.ToString("#,###.00");
                }
            }

            if (e.ColumnIndex > 6)
            {
                double price;

                if (double.TryParse(e.Value.ToString(), out price))
                {
                    e.Value = price.ToString("#,###");
                }
            }

        }

        #endregion

        #region Characters

        private void btnAddCharacter_Click(object sender, EventArgs e)
        {
            var repository = new EveRepository();

            // Just quit if any of the UI fields are't populated
            if (string.IsNullOrEmpty(txtCharacterName.Text)) return;
            if (string.IsNullOrEmpty(txtCharacterID.Text)) return;
            if (string.IsNullOrEmpty(txtVCode.Text)) return;
            if (string.IsNullOrEmpty(txtKeyID.Text)) return;

            var character = new Character
            {
                Name = txtCharacterName.Text,
                EveCharacterID = long.Parse(txtCharacterID.Text),
                vCode = txtVCode.Text,
                KeyID = txtKeyID.Text
            };

            repository.Characters.Add(character);

            repository.SaveChanges();
        }

        #endregion

        #region Eve ESI

        private EsiRefreshToken GetRefreshToken(Character character)
        {
            if (!_characterRefreshTokens.HasTokenExpired(character.Name))
            {
                return _characterRefreshTokens.GetToken(character.Name);
            }

            var token = EsiAccessService.GetRefreshToken(character);

            _characterRefreshTokens.AddToken(character.Name, token);

            return token;
        }

        public void GetAssets(Character character, ref Dictionary<long, long> assets)
        {
            var esiToken = GetRefreshToken(character);

            if (string.IsNullOrEmpty(esiToken.access_token)) return;

            WebHeaderCollection headers = new WebHeaderCollection
            {
                {"Authorization", string.Format("{0} {1}", esiToken.token_type, esiToken.access_token)},
                {"X-ConsumerKey", "IKzP5olthtinjAgyvhZAxk"}
            };

            var url = string.Format("https://esi.tech.ccp.is/latest/characters/{0}/assets/", character.EveCharacterID);

            if (CacheService.IsUrlCached(url, true))
            {
               return;
            }

            var response = HttpServices.MakeHttpRequest(url,"GET",headers);

            if (response == null) return;

            CacheService.CheckCacheResponse(response);

            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                var objText = reader.ReadToEnd();

                JavaScriptSerializer js = new JavaScriptSerializer();
                var myobj = js.Deserialize<List<EsiAsset>>(objText);

                var itemsWithQuantity = myobj.Where(x => x.quantity > 0);

                foreach (var item in itemsWithQuantity)
                {
                    // Add or update the quantity
                    if (assets.ContainsKey(item.type_id))
                    {
                        var current = assets[item.type_id];
                        assets[item.type_id] = current + item.quantity;
                    }
                    else
                    {
                        assets.Add(item.type_id, item.quantity);
                    }
                }
            }
        }

        public void GetSellOrders(Character character, ref Dictionary<long, long> assets)
        {
            var esiToken = GetRefreshToken(character);

            if (string.IsNullOrEmpty(esiToken.access_token)) return;

            WebHeaderCollection headers = new WebHeaderCollection
            {
                {"Authorization", string.Format("{0} {1}", esiToken.token_type, esiToken.access_token)},
                {"X-ConsumerKey", "IKzP5olthtinjAgyvhZAxk"}
            };

            var url = string.Format("https://esi.tech.ccp.is/latest/characters/{0}/orders/", character.EveCharacterID);

            if (CacheService.IsUrlCached(url, true))
            {
                return;
            }

            var response = HttpServices.MakeHttpRequest(url,"GET",headers);

            if (response == null) return;

            CacheService.CheckCacheResponse(response);

            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                var objText = reader.ReadToEnd();

                JavaScriptSerializer js = new JavaScriptSerializer();
                var myobj = js.Deserialize<List<EsiMarketOrder>>(objText);

                var sellOrders = myobj.Where(x => x.is_buy_order == false).Where(x => x.state == "open");

                foreach (var item in sellOrders)
                {
                    // Add or update the quantity
                    if (assets.ContainsKey(item.type_id))
                    {
                        var current = assets[item.type_id];
                        assets[item.type_id] = current + item.volume_remain;
                    }
                    else
                    {
                        assets.Add(item.type_id, item.volume_remain);
                    }
                }
            }
        }

        public IList<EsiIndustryJob> GetIndustryJobs(Character character, ref Dictionary<long, long> assets, bool includeCompleted)
        {
            IList<EsiIndustryJob> jobs = new List<EsiIndustryJob>();

            var esiToken = GetRefreshToken(character);

            if (string.IsNullOrEmpty(esiToken.access_token)) return jobs;

            WebHeaderCollection headers = new WebHeaderCollection
            {
                {"Authorization", string.Format("{0} {1}", esiToken.token_type, esiToken.access_token)},
                {"X-ConsumerKey", "IKzP5olthtinjAgyvhZAxk"}
            };

            var url = string.Format("https://esi.tech.ccp.is/latest/characters/{0}/industry/jobs/?include_completed={1}", character.EveCharacterID, includeCompleted ? "true" : "false");

            if (CacheService.IsUrlCached(url, true))
            {
                return jobs;
            }

            var response = HttpServices.MakeHttpRequest(url, "GET", headers);

            if (response == null) return jobs;

            CacheService.CheckCacheResponse(response);

            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                var objText = reader.ReadToEnd();

                JavaScriptSerializer js = new JavaScriptSerializer();
                jobs = js.Deserialize<List<EsiIndustryJob>>(objText);

                var activeJobs = jobs.Where(x => x.status == "active");

                foreach (var item in activeJobs)
                {
                    // Reduce the quantity, as we always treat them as delivered as soon as the job starts
                    // so our stock count will be too high
                    if (assets.ContainsKey(item.product_type_id))
                    {
                        var current = assets[item.product_type_id];
                        assets[item.product_type_id] = current - item.runs;
                    }
                }
            }

            return jobs;
        }

        public IList<EsiWalletTransaction> GetWalletTransactions(Character character)
        {
            // We don't store the transcations against specific characters, so we can't get the max ID
            //var maxID = repository.WalletTransactions.OrderByDescending(x => x.TransactionIDFromEve).Where(x => x.TransactionFor == character.Name).First();
            IList<EsiWalletTransaction> transactions = new List<EsiWalletTransaction>();

            var esiToken = GetRefreshToken(character);

            if (string.IsNullOrEmpty(esiToken.access_token)) return transactions;

            WebHeaderCollection headers = new WebHeaderCollection
            {
                {"Authorization", string.Format("{0} {1}", esiToken.token_type, esiToken.access_token)},
                {"X-ConsumerKey", "IKzP5olthtinjAgyvhZAxk"}
            };

            var url = string.Format("https://esi.tech.ccp.is/latest/characters/{0}/wallet/transactions/", character.EveCharacterID);

            if (CacheService.IsUrlCached(url, true))
            {
                return transactions;
            }

            var response = HttpServices.MakeHttpRequest(url, "GET", headers);

            if (response == null) return transactions;

            CacheService.CheckCacheResponse(response);

            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                var objText = reader.ReadToEnd();

                JavaScriptSerializer js = new JavaScriptSerializer();
                transactions = js.Deserialize<List<EsiWalletTransaction>>(objText);
            }

            return transactions;
        }

        public IList<EsiWalletJournal> GetWalletJournal(Character character)
        {
            // We don't store the transcations against specific characters, so we can't get the max ID
            //var maxID = repository.WalletTransactions.OrderByDescending(x => x.TransactionIDFromEve).Where(x => x.TransactionFor == character.Name).First();
            IList<EsiWalletJournal> journalEntries = new List<EsiWalletJournal>();

            var esiToken = GetRefreshToken(character);

            if (string.IsNullOrEmpty(esiToken.access_token)) return journalEntries;

            WebHeaderCollection headers = new WebHeaderCollection
            {
                {"Authorization", string.Format("{0} {1}", esiToken.token_type, esiToken.access_token)},
                {"X-ConsumerKey", "IKzP5olthtinjAgyvhZAxk"}
            };

            var url = string.Format("https://esi.tech.ccp.is/latest/characters/{0}/wallet/journal/", character.EveCharacterID);

            if (CacheService.IsUrlCached(url, true))
            {
                return journalEntries;
            }

            var response = HttpServices.MakeHttpRequest(url, "GET", headers);

            if (response == null) return journalEntries;

            CacheService.CheckCacheResponse(response);

            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                var objText = reader.ReadToEnd();

                JavaScriptSerializer js = new JavaScriptSerializer();
                journalEntries = js.Deserialize<List<EsiWalletJournal>>(objText);
            }

            return journalEntries;
        }

        private IList<EsiMarketOrder> GetPricesEsi(long typeId)
        {
            //EveRepository repository = new EveRepository();

            //var items = repository.EveItems.Where(x => x.TrackPrices)
            //    .Where(x => !x.ItemName.Contains("Blueprint"))
            //    .Select(x => new { x.ItemID }).ToArray();

            IList<EsiMarketOrder> marketOrders = new List<EsiMarketOrder> ();

            //var esiToken = GetRefreshToken(character);

            //if (string.IsNullOrEmpty(esiToken.access_token)) return marketOrders;

            WebHeaderCollection headers = new WebHeaderCollection();
            //{
            //    {"Authorization", string.Format("{0} {1}", esiToken.token_type, esiToken.access_token)},
            //    {"X-ConsumerKey", "IKzP5olthtinjAgyvhZAxk"}
            //};

            var url = string.Format("https://esi.tech.ccp.is/latest/markets/{0}/orders/?type_id={1}", HeimetarRegionId, typeId);

            if (CacheService.IsUrlCached(url, true))
            {
                return marketOrders;
            }

            var response = HttpServices.MakeHttpRequest(url, "GET", headers);

            if (response == null) return marketOrders;

            CacheService.CheckCacheResponse(response);

            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                var objText = reader.ReadToEnd();

                JavaScriptSerializer js = new JavaScriptSerializer();
                js.MaxJsonLength = Int32.MaxValue;
                marketOrders = js.Deserialize<List<EsiMarketOrder>>(objText);
            }

            return marketOrders;


            //var iterations = Math.Floor((decimal)items.Length / 50) + 1;
            //for (int i = 0; i < iterations; i++)
            //{
            //    var batchitems = items.Skip(i * 50).Take(50);

            //    var result = string.Join(",", batchitems.AsEnumerable().Select(row => row.ItemID));

            //    var rensurl = string.Format(EveCentralMarketStatUrl, result, RensRegionId);
            //    GetPricesBatch(rensurl, RensRegionId);

            //    var jitaurl = string.Format(EveCentralMarketStatUrl, result, JitaRegionId);
            //    GetPricesBatch(jitaurl, JitaRegionId);
            //}

            //// Reset prices on things we no longer track
            //var reset = repository.EveItems.Where(x => x.TrackPrices == false)
            //    .Where(x => x.SellPrice > 0);

            //foreach (var item in reset)
            //{
            //    var eveItem = repository.EveItems.FirstOrDefault(x => x.ItemID == item.ItemID);
            //    if (eveItem != null)
            //    {
            //        eveItem.ResetPrices();
            //    }
            //}

            //repository.SaveChanges();
        }

        #endregion

    }
}