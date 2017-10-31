using System;
using System.Linq;
using EveTransactions.Repository;
using EveTransactions.Services;
using MaterialSkin;
using MaterialSkin.Controls;

namespace EveTransactions
{
    public partial class StockForm : MaterialForm
    {
        public StockForm()
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }

        public StockForm(string eveItemName, string assumedStock, string actualStock) : this()
        {
            lblItemName.Text = eveItemName;
            lblAssumedStockValue.Text = assumedStock;
            lblActualStockValue.Text = actualStock;

            int assumed = 0;
            int actual = 0;
            int.TryParse(assumedStock, out assumed);
            int.TryParse(actualStock, out actual);

            var difference = (actual - assumed);

            txtChangeBy.Text = difference.ToString();

            txtPrice.Text = string.Format("{0:f2}", GetAveragePrice(eveItemName));
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var repository = new EveRepository();
            var item = repository.EveItems.FirstOrDefault(x => x.ItemName == lblItemName.Text);

            if (item == null) return;

            
            long changeBy;
            if (!long.TryParse(txtChangeBy.Text, out changeBy)) return;

            decimal price;
            if (!decimal.TryParse(txtPrice.Text, out price)) return;

            if (changeBy > 0)
            {
                StockManagementService.AddStock(lblItemName.Text, DateTime.Now, changeBy, price);
            }
            else
            {
                changeBy = changeBy*-1;  // Convert to a positive number
                StockManagementService.RemoveStock(lblItemName.Text, changeBy);
            }

            this.Close();
        }

        private decimal GetAveragePrice(string itemName)
        {
            decimal result = 0;
            using (var repository = new EveRepository())
            {
                var query = from stock in repository.Stocks
                            where stock.TypeName.Contains(itemName)
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
                    if (item.Item == itemName)
                    {
                        result = item.AverageValue;
                    }
                }

            }

            return result;
        }
    }
}
