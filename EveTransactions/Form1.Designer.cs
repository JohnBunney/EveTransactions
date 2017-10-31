using EveTransactions.Domain;
namespace EveTransactions
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnLoadNew = new System.Windows.Forms.Button();
            this.btnBestSellers = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabBestSellers = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new EveTransactions.Domain.FastGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panelStockHeader = new System.Windows.Forms.Panel();
            this.stockGridView = new EveTransactions.Domain.FastGridView();
            this.ButtonColumn = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panelStock = new System.Windows.Forms.Panel();
            this.txtStockSearch = new System.Windows.Forms.TextBox();
            this.btnStockSearch = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.panelGroupedStockHeader = new System.Windows.Forms.Panel();
            this.groupedStockGridView = new EveTransactions.Domain.FastGridView();
            this.panelGroupedStock = new System.Windows.Forms.Panel();
            this.chkOnlyTrackedPrices = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnGroupedStockSearch = new System.Windows.Forms.Button();
            this.txtGroupedStockSearch = new System.Windows.Forms.TextBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.panelSales = new System.Windows.Forms.Panel();
            this.salesDataGridView = new EveTransactions.Domain.FastGridView();
            this.panelSalesHeader = new System.Windows.Forms.Panel();
            this.txtSearchSales = new System.Windows.Forms.TextBox();
            this.radioSalesToday = new System.Windows.Forms.RadioButton();
            this.btnSearchSales = new System.Windows.Forms.Button();
            this.radioSalesDay = new System.Windows.Forms.RadioButton();
            this.radioSalesAllTime = new System.Windows.Forms.RadioButton();
            this.radioSalesPastWeek = new System.Windows.Forms.RadioButton();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.dailyGridView = new EveTransactions.Domain.FastGridView();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.dailyGraph = new ZedGraph.ZedGraphControl();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.journalDataGridView = new EveTransactions.Domain.FastGridView();
            this.tabPage8 = new System.Windows.Forms.TabPage();
            this.panelMonthlyBestHeader = new System.Windows.Forms.Panel();
            this.dailyRewardsDataGridView = new EveTransactions.Domain.FastGridView();
            this.panelMonthlyBest = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblPerDay = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblProjected = new System.Windows.Forms.Label();
            this.chkLastMonth = new System.Windows.Forms.CheckBox();
            this.chkIncludeLoot = new System.Windows.Forms.CheckBox();
            this.btnRefreshMonthlyBestSeller = new System.Windows.Forms.Button();
            this.tabPage10 = new System.Windows.Forms.TabPage();
            this.txtSetStockQuantity = new System.Windows.Forms.TextBox();
            this.txtSetStockName = new System.Windows.Forms.TextBox();
            this.btnSetStock = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtAddStockPrice = new System.Windows.Forms.TextBox();
            this.txtAddStockQuantity = new System.Windows.Forms.TextBox();
            this.txtAddStockName = new System.Windows.Forms.TextBox();
            this.btnAddStock = new System.Windows.Forms.Button();
            this.tabPage11 = new System.Windows.Forms.TabPage();
            this.panelRecipesHeader = new System.Windows.Forms.Panel();
            this.dataGridRecipes = new EveTransactions.Domain.FastGridView();
            this.panelRecipes = new System.Windows.Forms.Panel();
            this.bntNewRecipe = new MaterialSkin.Controls.MaterialFlatButton();
            this.tabPage9 = new System.Windows.Forms.TabPage();
            this.panelRecipeStockBottom = new System.Windows.Forms.Panel();
            this.dataGridViewRecipeStock = new EveTransactions.Domain.FastGridView();
            this.panelRecipeStockTop = new System.Windows.Forms.Panel();
            this.txtRuns = new System.Windows.Forms.TextBox();
            this.cmbGetStock = new System.Windows.Forms.ComboBox();
            this.btnGetStock = new System.Windows.Forms.Button();
            this.tabPage12 = new System.Windows.Forms.TabPage();
            this.btnAddGuidanceSystems = new System.Windows.Forms.Button();
            this.txtGuidanceSystemsTaxRate = new System.Windows.Forms.TextBox();
            this.txtGuidanceSystemsQuantity = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnAddRobotics = new System.Windows.Forms.Button();
            this.txtRoboticsTaxRate = new System.Windows.Forms.TextBox();
            this.txtRoboticsQuantity = new System.Windows.Forms.TextBox();
            this.lblRobotics = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtChiralPrice = new System.Windows.Forms.TextBox();
            this.txtReactivePrice = new System.Windows.Forms.TextBox();
            this.txtPreciousPrice = new System.Windows.Forms.TextBox();
            this.txtToxicPrice = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAddChiralStructures = new System.Windows.Forms.Button();
            this.btnAddReactiveMetals = new System.Windows.Forms.Button();
            this.btnAddPreciousMetals = new System.Windows.Forms.Button();
            this.btnAddToxicMetals = new System.Windows.Forms.Button();
            this.txtChiralQuantity = new System.Windows.Forms.TextBox();
            this.txtReactiveQuantity = new System.Windows.Forms.TextBox();
            this.txtPreciousQuantity = new System.Windows.Forms.TextBox();
            this.lblChiralStructures = new System.Windows.Forms.Label();
            this.lblReactiveMetals = new System.Windows.Forms.Label();
            this.lblPreciousMetals = new System.Windows.Forms.Label();
            this.lblToxicMetals = new System.Windows.Forms.Label();
            this.txtToxicQuantity = new System.Windows.Forms.TextBox();
            this.tabRecentSales = new System.Windows.Forms.TabPage();
            this.recentSalesDataGridView = new EveTransactions.Domain.FastGridView();
            this.tabPurchase = new System.Windows.Forms.TabPage();
            this.dataGridViewPurchase = new EveTransactions.Domain.FastGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabBuild = new System.Windows.Forms.TabPage();
            this.dataGridViewBuild = new EveTransactions.Domain.FastGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtBuildTimeLimit = new System.Windows.Forms.TextBox();
            this.btnBuildOrder = new System.Windows.Forms.Button();
            this.chkBuildLimit = new System.Windows.Forms.CheckBox();
            this.tabEveItems = new System.Windows.Forms.TabPage();
            this.dataGridEveItems = new EveTransactions.Domain.FastGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.chkNeedBuy = new System.Windows.Forms.CheckBox();
            this.btnGetEveCentralPrices = new System.Windows.Forms.Button();
            this.txtEveItemSearch = new System.Windows.Forms.TextBox();
            this.chkTrackedPrices = new System.Windows.Forms.CheckBox();
            this.btnEveItems = new System.Windows.Forms.Button();
            this.tabCharacters = new System.Windows.Forms.TabPage();
            this.dataGridViewCharacters = new System.Windows.Forms.DataGridView();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblKeyID = new System.Windows.Forms.Label();
            this.txtKeyID = new System.Windows.Forms.TextBox();
            this.btnClearCharacter = new System.Windows.Forms.Button();
            this.btnAddCharacter = new System.Windows.Forms.Button();
            this.txtVCode = new System.Windows.Forms.TextBox();
            this.txtCharacterID = new System.Windows.Forms.TextBox();
            this.lblVCode = new System.Windows.Forms.Label();
            this.lblCharacterID = new System.Windows.Forms.Label();
            this.lblCharacterName = new System.Windows.Forms.Label();
            this.txtCharacterName = new System.Windows.Forms.TextBox();
            this.tabStockCheck = new System.Windows.Forms.TabPage();
            this.dataGridStock = new FastGridView();
            this.panel5 = new System.Windows.Forms.Panel();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.tabControl1.SuspendLayout();
            this.tabBestSellers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.panelStockHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stockGridView)).BeginInit();
            this.panelStock.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.panelGroupedStockHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupedStockGridView)).BeginInit();
            this.panelGroupedStock.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.panelSales.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.salesDataGridView)).BeginInit();
            this.panelSalesHeader.SuspendLayout();
            this.tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dailyGridView)).BeginInit();
            this.tabPage6.SuspendLayout();
            this.tabPage7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.journalDataGridView)).BeginInit();
            this.tabPage8.SuspendLayout();
            this.panelMonthlyBestHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dailyRewardsDataGridView)).BeginInit();
            this.panelMonthlyBest.SuspendLayout();
            this.tabPage10.SuspendLayout();
            this.tabPage11.SuspendLayout();
            this.panelRecipesHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridRecipes)).BeginInit();
            this.panelRecipes.SuspendLayout();
            this.tabPage9.SuspendLayout();
            this.panelRecipeStockBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRecipeStock)).BeginInit();
            this.panelRecipeStockTop.SuspendLayout();
            this.tabPage12.SuspendLayout();
            this.tabRecentSales.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.recentSalesDataGridView)).BeginInit();
            this.tabPurchase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPurchase)).BeginInit();
            this.tabBuild.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBuild)).BeginInit();
            this.panel2.SuspendLayout();
            this.tabEveItems.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridEveItems)).BeginInit();
            this.panel3.SuspendLayout();
            this.tabCharacters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCharacters)).BeginInit();
            this.panel4.SuspendLayout();
            this.tabStockCheck.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridStock)).BeginInit();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnLoadNew
            // 
            this.btnLoadNew.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btnLoadNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoadNew.Location = new System.Drawing.Point(297, 32);
            this.btnLoadNew.Name = "btnLoadNew";
            this.btnLoadNew.Size = new System.Drawing.Size(75, 23);
            this.btnLoadNew.TabIndex = 2;
            this.btnLoadNew.Text = "Load New";
            this.btnLoadNew.UseVisualStyleBackColor = false;
            this.btnLoadNew.Click += new System.EventHandler(this.btnLoadNew_Click);
            // 
            // btnBestSellers
            // 
            this.btnBestSellers.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btnBestSellers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBestSellers.Location = new System.Drawing.Point(15, 12);
            this.btnBestSellers.Name = "btnBestSellers";
            this.btnBestSellers.Size = new System.Drawing.Size(133, 23);
            this.btnBestSellers.TabIndex = 3;
            this.btnBestSellers.Text = "Check Stock";
            this.btnBestSellers.UseVisualStyleBackColor = false;
            this.btnBestSellers.Click += new System.EventHandler(this.btnBestSellers_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabBestSellers);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Controls.Add(this.tabPage7);
            this.tabControl1.Controls.Add(this.tabPage8);
            this.tabControl1.Controls.Add(this.tabPage10);
            this.tabControl1.Controls.Add(this.tabPage11);
            this.tabControl1.Controls.Add(this.tabPage9);
            this.tabControl1.Controls.Add(this.tabPage12);
            this.tabControl1.Controls.Add(this.tabRecentSales);
            this.tabControl1.Controls.Add(this.tabPurchase);
            this.tabControl1.Controls.Add(this.tabBuild);
            this.tabControl1.Controls.Add(this.tabEveItems);
            this.tabControl1.Controls.Add(this.tabCharacters);
            this.tabControl1.Controls.Add(this.tabStockCheck);
            this.tabControl1.Location = new System.Drawing.Point(0, 61);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1127, 408);
            this.tabControl1.TabIndex = 4;
            // 
            // tabBestSellers
            // 
            this.tabBestSellers.BackColor = System.Drawing.Color.Black;
            this.tabBestSellers.Controls.Add(this.dataGridView1);
            this.tabBestSellers.Location = new System.Drawing.Point(4, 22);
            this.tabBestSellers.Name = "tabBestSellers";
            this.tabBestSellers.Size = new System.Drawing.Size(1119, 382);
            this.tabBestSellers.TabIndex = 0;
            this.tabBestSellers.Text = "Best Sellers";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(1119, 382);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.panelStockHeader);
            this.tabPage2.Controls.Add(this.panelStock);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1119, 382);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Stock";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panelStockHeader
            // 
            this.panelStockHeader.Controls.Add(this.stockGridView);
            this.panelStockHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelStockHeader.Location = new System.Drawing.Point(3, 35);
            this.panelStockHeader.Name = "panelStockHeader";
            this.panelStockHeader.Size = new System.Drawing.Size(1113, 344);
            this.panelStockHeader.TabIndex = 4;
            // 
            // stockGridView
            // 
            this.stockGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.stockGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ButtonColumn});
            this.stockGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stockGridView.Location = new System.Drawing.Point(0, 0);
            this.stockGridView.Margin = new System.Windows.Forms.Padding(3, 35, 3, 3);
            this.stockGridView.Name = "stockGridView";
            this.stockGridView.Size = new System.Drawing.Size(1113, 344);
            this.stockGridView.TabIndex = 0;
            this.stockGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.stockGridView_CellContentClick);
            this.stockGridView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.stockGridView_CellFormatting);
            // 
            // ButtonColumn
            // 
            this.ButtonColumn.HeaderText = "Delete";
            this.ButtonColumn.Name = "ButtonColumn";
            // 
            // panelStock
            // 
            this.panelStock.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panelStock.Controls.Add(this.txtStockSearch);
            this.panelStock.Controls.Add(this.btnStockSearch);
            this.panelStock.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelStock.Location = new System.Drawing.Point(3, 3);
            this.panelStock.Name = "panelStock";
            this.panelStock.Size = new System.Drawing.Size(1113, 32);
            this.panelStock.TabIndex = 3;
            // 
            // txtStockSearch
            // 
            this.txtStockSearch.Location = new System.Drawing.Point(6, 6);
            this.txtStockSearch.Name = "txtStockSearch";
            this.txtStockSearch.Size = new System.Drawing.Size(552, 20);
            this.txtStockSearch.TabIndex = 1;
            // 
            // btnStockSearch
            // 
            this.btnStockSearch.Location = new System.Drawing.Point(561, 3);
            this.btnStockSearch.Name = "btnStockSearch";
            this.btnStockSearch.Size = new System.Drawing.Size(75, 23);
            this.btnStockSearch.TabIndex = 2;
            this.btnStockSearch.Text = "Search";
            this.btnStockSearch.UseVisualStyleBackColor = true;
            this.btnStockSearch.Click += new System.EventHandler(this.btnStockSearch_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.panelGroupedStockHeader);
            this.tabPage3.Controls.Add(this.panelGroupedStock);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1119, 382);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Grouped Stock";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // panelGroupedStockHeader
            // 
            this.panelGroupedStockHeader.Controls.Add(this.groupedStockGridView);
            this.panelGroupedStockHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelGroupedStockHeader.Location = new System.Drawing.Point(3, 35);
            this.panelGroupedStockHeader.Name = "panelGroupedStockHeader";
            this.panelGroupedStockHeader.Size = new System.Drawing.Size(1113, 344);
            this.panelGroupedStockHeader.TabIndex = 2;
            // 
            // groupedStockGridView
            // 
            this.groupedStockGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.groupedStockGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupedStockGridView.Location = new System.Drawing.Point(0, 0);
            this.groupedStockGridView.Name = "groupedStockGridView";
            this.groupedStockGridView.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupedStockGridView.RowTemplate.Height = 26;
            this.groupedStockGridView.Size = new System.Drawing.Size(1113, 344);
            this.groupedStockGridView.TabIndex = 0;
            this.groupedStockGridView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.groupedStockGridView_CellFormatting);
            // 
            // panelGroupedStock
            // 
            this.panelGroupedStock.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panelGroupedStock.Controls.Add(this.chkOnlyTrackedPrices);
            this.panelGroupedStock.Controls.Add(this.button1);
            this.panelGroupedStock.Controls.Add(this.btnGroupedStockSearch);
            this.panelGroupedStock.Controls.Add(this.txtGroupedStockSearch);
            this.panelGroupedStock.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelGroupedStock.Location = new System.Drawing.Point(3, 3);
            this.panelGroupedStock.Name = "panelGroupedStock";
            this.panelGroupedStock.Size = new System.Drawing.Size(1113, 32);
            this.panelGroupedStock.TabIndex = 1;
            // 
            // chkOnlyTrackedPrices
            // 
            this.chkOnlyTrackedPrices.AutoSize = true;
            this.chkOnlyTrackedPrices.Checked = true;
            this.chkOnlyTrackedPrices.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkOnlyTrackedPrices.Location = new System.Drawing.Point(757, 7);
            this.chkOnlyTrackedPrices.Name = "chkOnlyTrackedPrices";
            this.chkOnlyTrackedPrices.Size = new System.Drawing.Size(122, 17);
            this.chkOnlyTrackedPrices.TabIndex = 3;
            this.chkOnlyTrackedPrices.Text = "Only Tracked Prices";
            this.chkOnlyTrackedPrices.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(675, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Oldest Price";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnGroupedStockSearch
            // 
            this.btnGroupedStockSearch.Location = new System.Drawing.Point(302, 4);
            this.btnGroupedStockSearch.Name = "btnGroupedStockSearch";
            this.btnGroupedStockSearch.Size = new System.Drawing.Size(75, 23);
            this.btnGroupedStockSearch.TabIndex = 1;
            this.btnGroupedStockSearch.Text = "Search";
            this.btnGroupedStockSearch.UseVisualStyleBackColor = true;
            this.btnGroupedStockSearch.Click += new System.EventHandler(this.btnGroupedStockSearch_Click);
            // 
            // txtGroupedStockSearch
            // 
            this.txtGroupedStockSearch.Location = new System.Drawing.Point(6, 6);
            this.txtGroupedStockSearch.Name = "txtGroupedStockSearch";
            this.txtGroupedStockSearch.Size = new System.Drawing.Size(290, 20);
            this.txtGroupedStockSearch.TabIndex = 0;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.panelSales);
            this.tabPage4.Controls.Add(this.panelSalesHeader);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(1119, 382);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Sales";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // panelSales
            // 
            this.panelSales.Controls.Add(this.salesDataGridView);
            this.panelSales.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSales.Location = new System.Drawing.Point(3, 34);
            this.panelSales.Name = "panelSales";
            this.panelSales.Size = new System.Drawing.Size(1113, 345);
            this.panelSales.TabIndex = 8;
            // 
            // salesDataGridView
            // 
            this.salesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.salesDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.salesDataGridView.Location = new System.Drawing.Point(0, 0);
            this.salesDataGridView.Name = "salesDataGridView";
            this.salesDataGridView.Size = new System.Drawing.Size(1113, 345);
            this.salesDataGridView.TabIndex = 0;
            this.salesDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.salesDataGridView_CellDoubleClick);
            this.salesDataGridView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.salesDataGridView_CellFormatting);
            // 
            // panelSalesHeader
            // 
            this.panelSalesHeader.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panelSalesHeader.Controls.Add(this.txtSearchSales);
            this.panelSalesHeader.Controls.Add(this.radioSalesToday);
            this.panelSalesHeader.Controls.Add(this.btnSearchSales);
            this.panelSalesHeader.Controls.Add(this.radioSalesDay);
            this.panelSalesHeader.Controls.Add(this.radioSalesAllTime);
            this.panelSalesHeader.Controls.Add(this.radioSalesPastWeek);
            this.panelSalesHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSalesHeader.Location = new System.Drawing.Point(3, 3);
            this.panelSalesHeader.Name = "panelSalesHeader";
            this.panelSalesHeader.Size = new System.Drawing.Size(1113, 31);
            this.panelSalesHeader.TabIndex = 7;
            // 
            // txtSearchSales
            // 
            this.txtSearchSales.Location = new System.Drawing.Point(3, 5);
            this.txtSearchSales.Name = "txtSearchSales";
            this.txtSearchSales.Size = new System.Drawing.Size(182, 20);
            this.txtSearchSales.TabIndex = 1;
            // 
            // radioSalesToday
            // 
            this.radioSalesToday.AutoSize = true;
            this.radioSalesToday.Location = new System.Drawing.Point(474, 3);
            this.radioSalesToday.Name = "radioSalesToday";
            this.radioSalesToday.Size = new System.Drawing.Size(55, 17);
            this.radioSalesToday.TabIndex = 6;
            this.radioSalesToday.TabStop = true;
            this.radioSalesToday.Text = "Today";
            this.radioSalesToday.UseVisualStyleBackColor = true;
            this.radioSalesToday.CheckedChanged += new System.EventHandler(this.radioSalesToday_CheckedChanged);
            // 
            // btnSearchSales
            // 
            this.btnSearchSales.Location = new System.Drawing.Point(191, 3);
            this.btnSearchSales.Name = "btnSearchSales";
            this.btnSearchSales.Size = new System.Drawing.Size(75, 23);
            this.btnSearchSales.TabIndex = 2;
            this.btnSearchSales.Text = "Search";
            this.btnSearchSales.UseVisualStyleBackColor = true;
            this.btnSearchSales.Click += new System.EventHandler(this.btnSearchSales_Click);
            // 
            // radioSalesDay
            // 
            this.radioSalesDay.AutoSize = true;
            this.radioSalesDay.Location = new System.Drawing.Point(400, 4);
            this.radioSalesDay.Name = "radioSalesDay";
            this.radioSalesDay.Size = new System.Drawing.Size(68, 17);
            this.radioSalesDay.TabIndex = 5;
            this.radioSalesDay.TabStop = true;
            this.radioSalesDay.Tag = "Sales";
            this.radioSalesDay.Text = "24 Hours";
            this.radioSalesDay.UseVisualStyleBackColor = true;
            this.radioSalesDay.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioSalesAllTime
            // 
            this.radioSalesAllTime.AutoSize = true;
            this.radioSalesAllTime.Checked = true;
            this.radioSalesAllTime.Location = new System.Drawing.Point(272, 3);
            this.radioSalesAllTime.Name = "radioSalesAllTime";
            this.radioSalesAllTime.Size = new System.Drawing.Size(62, 17);
            this.radioSalesAllTime.TabIndex = 3;
            this.radioSalesAllTime.TabStop = true;
            this.radioSalesAllTime.Tag = "Sales";
            this.radioSalesAllTime.Text = "All Time";
            this.radioSalesAllTime.UseVisualStyleBackColor = true;
            this.radioSalesAllTime.CheckedChanged += new System.EventHandler(this.radioSalesAllTime_CheckedChanged);
            // 
            // radioSalesPastWeek
            // 
            this.radioSalesPastWeek.AutoSize = true;
            this.radioSalesPastWeek.Location = new System.Drawing.Point(340, 4);
            this.radioSalesPastWeek.Name = "radioSalesPastWeek";
            this.radioSalesPastWeek.Size = new System.Drawing.Size(54, 17);
            this.radioSalesPastWeek.TabIndex = 4;
            this.radioSalesPastWeek.Tag = "Sales";
            this.radioSalesPastWeek.Text = "Week";
            this.radioSalesPastWeek.UseVisualStyleBackColor = true;
            this.radioSalesPastWeek.CheckedChanged += new System.EventHandler(this.radioSalesPastWeek_CheckedChanged);
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.dailyGridView);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(1119, 382);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Daily";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // dailyGridView
            // 
            this.dailyGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dailyGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dailyGridView.Location = new System.Drawing.Point(3, 3);
            this.dailyGridView.Name = "dailyGridView";
            this.dailyGridView.Size = new System.Drawing.Size(1113, 376);
            this.dailyGridView.TabIndex = 0;
            this.dailyGridView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dailyGridView_CellFormatting);
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.dailyGraph);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(1119, 382);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "Daily Graph";
            this.tabPage6.UseVisualStyleBackColor = true;
            this.tabPage6.Enter += new System.EventHandler(this.tabPage6_Enter);
            // 
            // dailyGraph
            // 
            this.dailyGraph.BackColor = System.Drawing.Color.Silver;
            this.dailyGraph.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dailyGraph.Location = new System.Drawing.Point(3, 3);
            this.dailyGraph.Name = "dailyGraph";
            this.dailyGraph.ScrollGrace = 0D;
            this.dailyGraph.ScrollMaxX = 0D;
            this.dailyGraph.ScrollMaxY = 0D;
            this.dailyGraph.ScrollMaxY2 = 0D;
            this.dailyGraph.ScrollMinX = 0D;
            this.dailyGraph.ScrollMinY = 0D;
            this.dailyGraph.ScrollMinY2 = 0D;
            this.dailyGraph.Size = new System.Drawing.Size(1113, 376);
            this.dailyGraph.TabIndex = 0;
            // 
            // tabPage7
            // 
            this.tabPage7.Controls.Add(this.journalDataGridView);
            this.tabPage7.Location = new System.Drawing.Point(4, 22);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage7.Size = new System.Drawing.Size(1119, 382);
            this.tabPage7.TabIndex = 6;
            this.tabPage7.Text = "Rewards";
            this.tabPage7.UseVisualStyleBackColor = true;
            this.tabPage7.Enter += new System.EventHandler(this.tabPage7_Enter);
            // 
            // journalDataGridView
            // 
            this.journalDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.journalDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.journalDataGridView.Location = new System.Drawing.Point(3, 3);
            this.journalDataGridView.Name = "journalDataGridView";
            this.journalDataGridView.Size = new System.Drawing.Size(1113, 376);
            this.journalDataGridView.TabIndex = 0;
            // 
            // tabPage8
            // 
            this.tabPage8.Controls.Add(this.panelMonthlyBestHeader);
            this.tabPage8.Controls.Add(this.panelMonthlyBest);
            this.tabPage8.Location = new System.Drawing.Point(4, 22);
            this.tabPage8.Name = "tabPage8";
            this.tabPage8.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage8.Size = new System.Drawing.Size(1119, 382);
            this.tabPage8.TabIndex = 7;
            this.tabPage8.Text = "Monthly Best";
            this.tabPage8.UseVisualStyleBackColor = true;
            this.tabPage8.Enter += new System.EventHandler(this.tabPage8_Enter);
            // 
            // panelMonthlyBestHeader
            // 
            this.panelMonthlyBestHeader.Controls.Add(this.dailyRewardsDataGridView);
            this.panelMonthlyBestHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMonthlyBestHeader.Location = new System.Drawing.Point(3, 62);
            this.panelMonthlyBestHeader.Name = "panelMonthlyBestHeader";
            this.panelMonthlyBestHeader.Size = new System.Drawing.Size(1113, 317);
            this.panelMonthlyBestHeader.TabIndex = 2;
            // 
            // dailyRewardsDataGridView
            // 
            this.dailyRewardsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dailyRewardsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dailyRewardsDataGridView.Location = new System.Drawing.Point(0, 0);
            this.dailyRewardsDataGridView.Name = "dailyRewardsDataGridView";
            this.dailyRewardsDataGridView.Size = new System.Drawing.Size(1113, 317);
            this.dailyRewardsDataGridView.TabIndex = 0;
            this.dailyRewardsDataGridView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dailyRewardsDataGridView_CellFormatting);
            // 
            // panelMonthlyBest
            // 
            this.panelMonthlyBest.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panelMonthlyBest.Controls.Add(this.label9);
            this.panelMonthlyBest.Controls.Add(this.label8);
            this.panelMonthlyBest.Controls.Add(this.label5);
            this.panelMonthlyBest.Controls.Add(this.lblPerDay);
            this.panelMonthlyBest.Controls.Add(this.lblTotal);
            this.panelMonthlyBest.Controls.Add(this.lblProjected);
            this.panelMonthlyBest.Controls.Add(this.chkLastMonth);
            this.panelMonthlyBest.Controls.Add(this.chkIncludeLoot);
            this.panelMonthlyBest.Controls.Add(this.btnRefreshMonthlyBestSeller);
            this.panelMonthlyBest.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMonthlyBest.Location = new System.Drawing.Point(3, 3);
            this.panelMonthlyBest.Name = "panelMonthlyBest";
            this.panelMonthlyBest.Size = new System.Drawing.Size(1113, 59);
            this.panelMonthlyBest.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(602, 8);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(52, 13);
            this.label9.TabIndex = 8;
            this.label9.Text = "Projected";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(479, 8);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Per Day";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(350, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Current";
            // 
            // lblPerDay
            // 
            this.lblPerDay.AutoSize = true;
            this.lblPerDay.Location = new System.Drawing.Point(479, 30);
            this.lblPerDay.Name = "lblPerDay";
            this.lblPerDay.Size = new System.Drawing.Size(28, 13);
            this.lblPerDay.TabIndex = 5;
            this.lblPerDay.Text = "0.00";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(350, 30);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(28, 13);
            this.lblTotal.TabIndex = 4;
            this.lblTotal.Text = "0.00";
            // 
            // lblProjected
            // 
            this.lblProjected.AutoSize = true;
            this.lblProjected.Location = new System.Drawing.Point(602, 30);
            this.lblProjected.Name = "lblProjected";
            this.lblProjected.Size = new System.Drawing.Size(28, 13);
            this.lblProjected.TabIndex = 3;
            this.lblProjected.Text = "0.00";
            // 
            // chkLastMonth
            // 
            this.chkLastMonth.AutoSize = true;
            this.chkLastMonth.Location = new System.Drawing.Point(114, 12);
            this.chkLastMonth.Name = "chkLastMonth";
            this.chkLastMonth.Size = new System.Drawing.Size(79, 17);
            this.chkLastMonth.TabIndex = 2;
            this.chkLastMonth.Text = "Last Month";
            this.chkLastMonth.UseVisualStyleBackColor = true;
            // 
            // chkIncludeLoot
            // 
            this.chkIncludeLoot.AutoSize = true;
            this.chkIncludeLoot.Checked = true;
            this.chkIncludeLoot.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIncludeLoot.Location = new System.Drawing.Point(218, 12);
            this.chkIncludeLoot.Name = "chkIncludeLoot";
            this.chkIncludeLoot.Size = new System.Drawing.Size(85, 17);
            this.chkIncludeLoot.TabIndex = 1;
            this.chkIncludeLoot.Text = "Include Loot";
            this.chkIncludeLoot.UseVisualStyleBackColor = true;
            // 
            // btnRefreshMonthlyBestSeller
            // 
            this.btnRefreshMonthlyBestSeller.Location = new System.Drawing.Point(14, 8);
            this.btnRefreshMonthlyBestSeller.Name = "btnRefreshMonthlyBestSeller";
            this.btnRefreshMonthlyBestSeller.Size = new System.Drawing.Size(75, 23);
            this.btnRefreshMonthlyBestSeller.TabIndex = 0;
            this.btnRefreshMonthlyBestSeller.Text = "Refresh";
            this.btnRefreshMonthlyBestSeller.UseVisualStyleBackColor = true;
            this.btnRefreshMonthlyBestSeller.Click += new System.EventHandler(this.btnRefreshMonthlyBestSeller_Click);
            // 
            // tabPage10
            // 
            this.tabPage10.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.tabPage10.Controls.Add(this.txtSetStockQuantity);
            this.tabPage10.Controls.Add(this.txtSetStockName);
            this.tabPage10.Controls.Add(this.btnSetStock);
            this.tabPage10.Controls.Add(this.label2);
            this.tabPage10.Controls.Add(this.label1);
            this.tabPage10.Controls.Add(this.txtAddStockPrice);
            this.tabPage10.Controls.Add(this.txtAddStockQuantity);
            this.tabPage10.Controls.Add(this.txtAddStockName);
            this.tabPage10.Controls.Add(this.btnAddStock);
            this.tabPage10.Location = new System.Drawing.Point(4, 22);
            this.tabPage10.Name = "tabPage10";
            this.tabPage10.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage10.Size = new System.Drawing.Size(1119, 382);
            this.tabPage10.TabIndex = 9;
            this.tabPage10.Text = "Stock Management";
            // 
            // txtSetStockQuantity
            // 
            this.txtSetStockQuantity.Location = new System.Drawing.Point(211, 90);
            this.txtSetStockQuantity.Name = "txtSetStockQuantity";
            this.txtSetStockQuantity.Size = new System.Drawing.Size(100, 20);
            this.txtSetStockQuantity.TabIndex = 16;
            // 
            // txtSetStockName
            // 
            this.txtSetStockName.Location = new System.Drawing.Point(104, 90);
            this.txtSetStockName.Name = "txtSetStockName";
            this.txtSetStockName.Size = new System.Drawing.Size(100, 20);
            this.txtSetStockName.TabIndex = 15;
            // 
            // btnSetStock
            // 
            this.btnSetStock.Location = new System.Drawing.Point(22, 88);
            this.btnSetStock.Name = "btnSetStock";
            this.btnSetStock.Size = new System.Drawing.Size(75, 23);
            this.btnSetStock.TabIndex = 14;
            this.btnSetStock.Text = "Set Stock";
            this.btnSetStock.UseVisualStyleBackColor = true;
            this.btnSetStock.Click += new System.EventHandler(this.btnSetStock_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(318, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Price";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(211, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Quantity";
            // 
            // txtAddStockPrice
            // 
            this.txtAddStockPrice.Location = new System.Drawing.Point(318, 43);
            this.txtAddStockPrice.Name = "txtAddStockPrice";
            this.txtAddStockPrice.Size = new System.Drawing.Size(100, 20);
            this.txtAddStockPrice.TabIndex = 11;
            // 
            // txtAddStockQuantity
            // 
            this.txtAddStockQuantity.Location = new System.Drawing.Point(211, 43);
            this.txtAddStockQuantity.Name = "txtAddStockQuantity";
            this.txtAddStockQuantity.Size = new System.Drawing.Size(100, 20);
            this.txtAddStockQuantity.TabIndex = 10;
            // 
            // txtAddStockName
            // 
            this.txtAddStockName.Location = new System.Drawing.Point(104, 43);
            this.txtAddStockName.Name = "txtAddStockName";
            this.txtAddStockName.Size = new System.Drawing.Size(100, 20);
            this.txtAddStockName.TabIndex = 9;
            // 
            // btnAddStock
            // 
            this.btnAddStock.Location = new System.Drawing.Point(22, 41);
            this.btnAddStock.Name = "btnAddStock";
            this.btnAddStock.Size = new System.Drawing.Size(75, 23);
            this.btnAddStock.TabIndex = 8;
            this.btnAddStock.Text = "Add Stock";
            this.btnAddStock.UseVisualStyleBackColor = true;
            this.btnAddStock.Click += new System.EventHandler(this.btnAddStock_Click);
            // 
            // tabPage11
            // 
            this.tabPage11.Controls.Add(this.panelRecipesHeader);
            this.tabPage11.Controls.Add(this.panelRecipes);
            this.tabPage11.Location = new System.Drawing.Point(4, 22);
            this.tabPage11.Name = "tabPage11";
            this.tabPage11.Size = new System.Drawing.Size(1119, 382);
            this.tabPage11.TabIndex = 10;
            this.tabPage11.Text = "Recipes";
            this.tabPage11.UseVisualStyleBackColor = true;
            this.tabPage11.Enter += new System.EventHandler(this.tabPage11_Enter);
            // 
            // panelRecipesHeader
            // 
            this.panelRecipesHeader.Controls.Add(this.dataGridRecipes);
            this.panelRecipesHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRecipesHeader.Location = new System.Drawing.Point(0, 67);
            this.panelRecipesHeader.Name = "panelRecipesHeader";
            this.panelRecipesHeader.Size = new System.Drawing.Size(1119, 315);
            this.panelRecipesHeader.TabIndex = 1;
            // 
            // dataGridRecipes
            // 
            this.dataGridRecipes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridRecipes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridRecipes.Location = new System.Drawing.Point(0, 0);
            this.dataGridRecipes.MultiSelect = false;
            this.dataGridRecipes.Name = "dataGridRecipes";
            this.dataGridRecipes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridRecipes.Size = new System.Drawing.Size(1119, 315);
            this.dataGridRecipes.TabIndex = 0;
            this.dataGridRecipes.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridRecipes_CellDoubleClick);
            // 
            // panelRecipes
            // 
            this.panelRecipes.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panelRecipes.Controls.Add(this.bntNewRecipe);
            this.panelRecipes.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelRecipes.Location = new System.Drawing.Point(0, 0);
            this.panelRecipes.Name = "panelRecipes";
            this.panelRecipes.Size = new System.Drawing.Size(1119, 67);
            this.panelRecipes.TabIndex = 0;
            // 
            // bntNewRecipe
            // 
            this.bntNewRecipe.AutoSize = true;
            this.bntNewRecipe.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.bntNewRecipe.Depth = 0;
            this.bntNewRecipe.Location = new System.Drawing.Point(39, 13);
            this.bntNewRecipe.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.bntNewRecipe.MouseState = MaterialSkin.MouseState.HOVER;
            this.bntNewRecipe.Name = "bntNewRecipe";
            this.bntNewRecipe.Primary = false;
            this.bntNewRecipe.Size = new System.Drawing.Size(91, 36);
            this.bntNewRecipe.TabIndex = 6;
            this.bntNewRecipe.Text = "New Recipe";
            this.bntNewRecipe.UseVisualStyleBackColor = true;
            this.bntNewRecipe.Click += new System.EventHandler(this.bntNewRecipe_Click);
            // 
            // tabPage9
            // 
            this.tabPage9.Controls.Add(this.panelRecipeStockBottom);
            this.tabPage9.Controls.Add(this.panelRecipeStockTop);
            this.tabPage9.Location = new System.Drawing.Point(4, 22);
            this.tabPage9.Name = "tabPage9";
            this.tabPage9.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage9.Size = new System.Drawing.Size(1119, 382);
            this.tabPage9.TabIndex = 11;
            this.tabPage9.Text = "Recipe Stock";
            this.tabPage9.UseVisualStyleBackColor = true;
            // 
            // panelRecipeStockBottom
            // 
            this.panelRecipeStockBottom.Controls.Add(this.dataGridViewRecipeStock);
            this.panelRecipeStockBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRecipeStockBottom.Location = new System.Drawing.Point(3, 62);
            this.panelRecipeStockBottom.Name = "panelRecipeStockBottom";
            this.panelRecipeStockBottom.Size = new System.Drawing.Size(1113, 317);
            this.panelRecipeStockBottom.TabIndex = 1;
            // 
            // dataGridViewRecipeStock
            // 
            this.dataGridViewRecipeStock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRecipeStock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewRecipeStock.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewRecipeStock.Name = "dataGridViewRecipeStock";
            this.dataGridViewRecipeStock.Size = new System.Drawing.Size(1113, 317);
            this.dataGridViewRecipeStock.TabIndex = 0;
            // 
            // panelRecipeStockTop
            // 
            this.panelRecipeStockTop.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panelRecipeStockTop.Controls.Add(this.txtRuns);
            this.panelRecipeStockTop.Controls.Add(this.cmbGetStock);
            this.panelRecipeStockTop.Controls.Add(this.btnGetStock);
            this.panelRecipeStockTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelRecipeStockTop.Location = new System.Drawing.Point(3, 3);
            this.panelRecipeStockTop.Name = "panelRecipeStockTop";
            this.panelRecipeStockTop.Size = new System.Drawing.Size(1113, 59);
            this.panelRecipeStockTop.TabIndex = 0;
            // 
            // txtRuns
            // 
            this.txtRuns.Location = new System.Drawing.Point(409, 19);
            this.txtRuns.Name = "txtRuns";
            this.txtRuns.Size = new System.Drawing.Size(100, 20);
            this.txtRuns.TabIndex = 2;
            this.txtRuns.Text = "12";
            // 
            // cmbGetStock
            // 
            this.cmbGetStock.FormattingEnabled = true;
            this.cmbGetStock.Location = new System.Drawing.Point(27, 19);
            this.cmbGetStock.Name = "cmbGetStock";
            this.cmbGetStock.Size = new System.Drawing.Size(257, 21);
            this.cmbGetStock.TabIndex = 1;
            // 
            // btnGetStock
            // 
            this.btnGetStock.Location = new System.Drawing.Point(290, 19);
            this.btnGetStock.Name = "btnGetStock";
            this.btnGetStock.Size = new System.Drawing.Size(75, 23);
            this.btnGetStock.TabIndex = 0;
            this.btnGetStock.Text = "Get Stock";
            this.btnGetStock.UseVisualStyleBackColor = true;
            this.btnGetStock.Click += new System.EventHandler(this.btnGetStock_Click);
            // 
            // tabPage12
            // 
            this.tabPage12.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.tabPage12.Controls.Add(this.btnAddGuidanceSystems);
            this.tabPage12.Controls.Add(this.txtGuidanceSystemsTaxRate);
            this.tabPage12.Controls.Add(this.txtGuidanceSystemsQuantity);
            this.tabPage12.Controls.Add(this.label10);
            this.tabPage12.Controls.Add(this.label7);
            this.tabPage12.Controls.Add(this.label6);
            this.tabPage12.Controls.Add(this.btnAddRobotics);
            this.tabPage12.Controls.Add(this.txtRoboticsTaxRate);
            this.tabPage12.Controls.Add(this.txtRoboticsQuantity);
            this.tabPage12.Controls.Add(this.lblRobotics);
            this.tabPage12.Controls.Add(this.label4);
            this.tabPage12.Controls.Add(this.txtChiralPrice);
            this.tabPage12.Controls.Add(this.txtReactivePrice);
            this.tabPage12.Controls.Add(this.txtPreciousPrice);
            this.tabPage12.Controls.Add(this.txtToxicPrice);
            this.tabPage12.Controls.Add(this.label3);
            this.tabPage12.Controls.Add(this.btnAddChiralStructures);
            this.tabPage12.Controls.Add(this.btnAddReactiveMetals);
            this.tabPage12.Controls.Add(this.btnAddPreciousMetals);
            this.tabPage12.Controls.Add(this.btnAddToxicMetals);
            this.tabPage12.Controls.Add(this.txtChiralQuantity);
            this.tabPage12.Controls.Add(this.txtReactiveQuantity);
            this.tabPage12.Controls.Add(this.txtPreciousQuantity);
            this.tabPage12.Controls.Add(this.lblChiralStructures);
            this.tabPage12.Controls.Add(this.lblReactiveMetals);
            this.tabPage12.Controls.Add(this.lblPreciousMetals);
            this.tabPage12.Controls.Add(this.lblToxicMetals);
            this.tabPage12.Controls.Add(this.txtToxicQuantity);
            this.tabPage12.Location = new System.Drawing.Point(4, 22);
            this.tabPage12.Name = "tabPage12";
            this.tabPage12.Size = new System.Drawing.Size(1119, 382);
            this.tabPage12.TabIndex = 12;
            this.tabPage12.Text = "PI";
            // 
            // btnAddGuidanceSystems
            // 
            this.btnAddGuidanceSystems.Location = new System.Drawing.Point(337, 233);
            this.btnAddGuidanceSystems.Name = "btnAddGuidanceSystems";
            this.btnAddGuidanceSystems.Size = new System.Drawing.Size(99, 23);
            this.btnAddGuidanceSystems.TabIndex = 27;
            this.btnAddGuidanceSystems.Text = "Add";
            this.btnAddGuidanceSystems.UseVisualStyleBackColor = true;
            this.btnAddGuidanceSystems.Click += new System.EventHandler(this.btnAddGuidanceSystems_Click);
            // 
            // txtGuidanceSystemsTaxRate
            // 
            this.txtGuidanceSystemsTaxRate.Location = new System.Drawing.Point(231, 235);
            this.txtGuidanceSystemsTaxRate.Name = "txtGuidanceSystemsTaxRate";
            this.txtGuidanceSystemsTaxRate.Size = new System.Drawing.Size(83, 20);
            this.txtGuidanceSystemsTaxRate.TabIndex = 26;
            this.txtGuidanceSystemsTaxRate.Text = "9";
            // 
            // txtGuidanceSystemsQuantity
            // 
            this.txtGuidanceSystemsQuantity.Location = new System.Drawing.Point(143, 235);
            this.txtGuidanceSystemsQuantity.Name = "txtGuidanceSystemsQuantity";
            this.txtGuidanceSystemsQuantity.Size = new System.Drawing.Size(68, 20);
            this.txtGuidanceSystemsQuantity.TabIndex = 25;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(37, 238);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(95, 13);
            this.label10.TabIndex = 24;
            this.label10.Text = "Guidance Systems";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(234, 182);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 13);
            this.label7.TabIndex = 23;
            this.label7.Text = "Tax Rate";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(143, 183);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 13);
            this.label6.TabIndex = 22;
            this.label6.Text = "Quantity";
            // 
            // btnAddRobotics
            // 
            this.btnAddRobotics.Location = new System.Drawing.Point(337, 195);
            this.btnAddRobotics.Name = "btnAddRobotics";
            this.btnAddRobotics.Size = new System.Drawing.Size(99, 23);
            this.btnAddRobotics.TabIndex = 14;
            this.btnAddRobotics.Text = "Add";
            this.btnAddRobotics.UseVisualStyleBackColor = true;
            this.btnAddRobotics.Click += new System.EventHandler(this.btnAddRobotics_Click);
            // 
            // txtRoboticsTaxRate
            // 
            this.txtRoboticsTaxRate.Location = new System.Drawing.Point(231, 198);
            this.txtRoboticsTaxRate.Name = "txtRoboticsTaxRate";
            this.txtRoboticsTaxRate.Size = new System.Drawing.Size(83, 20);
            this.txtRoboticsTaxRate.TabIndex = 13;
            this.txtRoboticsTaxRate.Text = "10";
            // 
            // txtRoboticsQuantity
            // 
            this.txtRoboticsQuantity.Location = new System.Drawing.Point(143, 199);
            this.txtRoboticsQuantity.Name = "txtRoboticsQuantity";
            this.txtRoboticsQuantity.Size = new System.Drawing.Size(68, 20);
            this.txtRoboticsQuantity.TabIndex = 12;
            // 
            // lblRobotics
            // 
            this.lblRobotics.AutoSize = true;
            this.lblRobotics.Location = new System.Drawing.Point(34, 199);
            this.lblRobotics.Name = "lblRobotics";
            this.lblRobotics.Size = new System.Drawing.Size(49, 13);
            this.lblRobotics.TabIndex = 18;
            this.lblRobotics.Text = "Robotics";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(231, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Price";
            // 
            // txtChiralPrice
            // 
            this.txtChiralPrice.Location = new System.Drawing.Point(231, 134);
            this.txtChiralPrice.Name = "txtChiralPrice";
            this.txtChiralPrice.Size = new System.Drawing.Size(83, 20);
            this.txtChiralPrice.TabIndex = 10;
            this.txtChiralPrice.Text = "78900";
            // 
            // txtReactivePrice
            // 
            this.txtReactivePrice.Location = new System.Drawing.Point(231, 100);
            this.txtReactivePrice.Name = "txtReactivePrice";
            this.txtReactivePrice.Size = new System.Drawing.Size(83, 20);
            this.txtReactivePrice.TabIndex = 7;
            this.txtReactivePrice.Text = "78900";
            // 
            // txtPreciousPrice
            // 
            this.txtPreciousPrice.Location = new System.Drawing.Point(231, 66);
            this.txtPreciousPrice.Name = "txtPreciousPrice";
            this.txtPreciousPrice.Size = new System.Drawing.Size(83, 20);
            this.txtPreciousPrice.TabIndex = 4;
            this.txtPreciousPrice.Text = "78900";
            // 
            // txtToxicPrice
            // 
            this.txtToxicPrice.Location = new System.Drawing.Point(231, 36);
            this.txtToxicPrice.Name = "txtToxicPrice";
            this.txtToxicPrice.Size = new System.Drawing.Size(83, 20);
            this.txtToxicPrice.TabIndex = 1;
            this.txtToxicPrice.Text = "78900";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(143, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Quantity";
            // 
            // btnAddChiralStructures
            // 
            this.btnAddChiralStructures.Location = new System.Drawing.Point(337, 134);
            this.btnAddChiralStructures.Name = "btnAddChiralStructures";
            this.btnAddChiralStructures.Size = new System.Drawing.Size(99, 23);
            this.btnAddChiralStructures.TabIndex = 11;
            this.btnAddChiralStructures.Text = "Add";
            this.btnAddChiralStructures.UseVisualStyleBackColor = true;
            this.btnAddChiralStructures.Click += new System.EventHandler(this.btnAddChiralStructures_Click);
            // 
            // btnAddReactiveMetals
            // 
            this.btnAddReactiveMetals.Location = new System.Drawing.Point(337, 101);
            this.btnAddReactiveMetals.Name = "btnAddReactiveMetals";
            this.btnAddReactiveMetals.Size = new System.Drawing.Size(99, 23);
            this.btnAddReactiveMetals.TabIndex = 8;
            this.btnAddReactiveMetals.Text = "Add";
            this.btnAddReactiveMetals.UseVisualStyleBackColor = true;
            this.btnAddReactiveMetals.Click += new System.EventHandler(this.btnAddReactiveMetals_Click);
            // 
            // btnAddPreciousMetals
            // 
            this.btnAddPreciousMetals.Location = new System.Drawing.Point(337, 67);
            this.btnAddPreciousMetals.Name = "btnAddPreciousMetals";
            this.btnAddPreciousMetals.Size = new System.Drawing.Size(99, 23);
            this.btnAddPreciousMetals.TabIndex = 5;
            this.btnAddPreciousMetals.Text = "Add";
            this.btnAddPreciousMetals.UseVisualStyleBackColor = true;
            this.btnAddPreciousMetals.Click += new System.EventHandler(this.btnAddPreciousMetals_Click);
            // 
            // btnAddToxicMetals
            // 
            this.btnAddToxicMetals.Location = new System.Drawing.Point(337, 36);
            this.btnAddToxicMetals.Name = "btnAddToxicMetals";
            this.btnAddToxicMetals.Size = new System.Drawing.Size(99, 23);
            this.btnAddToxicMetals.TabIndex = 2;
            this.btnAddToxicMetals.Text = "Add";
            this.btnAddToxicMetals.UseVisualStyleBackColor = true;
            this.btnAddToxicMetals.Click += new System.EventHandler(this.btnAddToxicMetals_Click);
            // 
            // txtChiralQuantity
            // 
            this.txtChiralQuantity.Location = new System.Drawing.Point(143, 134);
            this.txtChiralQuantity.Name = "txtChiralQuantity";
            this.txtChiralQuantity.Size = new System.Drawing.Size(68, 20);
            this.txtChiralQuantity.TabIndex = 9;
            this.txtChiralQuantity.Text = "1315";
            // 
            // txtReactiveQuantity
            // 
            this.txtReactiveQuantity.Location = new System.Drawing.Point(143, 101);
            this.txtReactiveQuantity.Name = "txtReactiveQuantity";
            this.txtReactiveQuantity.Size = new System.Drawing.Size(68, 20);
            this.txtReactiveQuantity.TabIndex = 6;
            this.txtReactiveQuantity.Text = "1315";
            // 
            // txtPreciousQuantity
            // 
            this.txtPreciousQuantity.Location = new System.Drawing.Point(143, 67);
            this.txtPreciousQuantity.Name = "txtPreciousQuantity";
            this.txtPreciousQuantity.Size = new System.Drawing.Size(68, 20);
            this.txtPreciousQuantity.TabIndex = 3;
            this.txtPreciousQuantity.Text = "1315";
            // 
            // lblChiralStructures
            // 
            this.lblChiralStructures.AutoSize = true;
            this.lblChiralStructures.Location = new System.Drawing.Point(31, 142);
            this.lblChiralStructures.Name = "lblChiralStructures";
            this.lblChiralStructures.Size = new System.Drawing.Size(84, 13);
            this.lblChiralStructures.TabIndex = 4;
            this.lblChiralStructures.Text = "Chiral Structures";
            // 
            // lblReactiveMetals
            // 
            this.lblReactiveMetals.AutoSize = true;
            this.lblReactiveMetals.Location = new System.Drawing.Point(28, 109);
            this.lblReactiveMetals.Name = "lblReactiveMetals";
            this.lblReactiveMetals.Size = new System.Drawing.Size(84, 13);
            this.lblReactiveMetals.TabIndex = 3;
            this.lblReactiveMetals.Text = "Reactive Metals";
            // 
            // lblPreciousMetals
            // 
            this.lblPreciousMetals.AutoSize = true;
            this.lblPreciousMetals.Location = new System.Drawing.Point(28, 75);
            this.lblPreciousMetals.Name = "lblPreciousMetals";
            this.lblPreciousMetals.Size = new System.Drawing.Size(82, 13);
            this.lblPreciousMetals.TabIndex = 2;
            this.lblPreciousMetals.Text = "Precious Metals";
            // 
            // lblToxicMetals
            // 
            this.lblToxicMetals.AutoSize = true;
            this.lblToxicMetals.Location = new System.Drawing.Point(25, 39);
            this.lblToxicMetals.Name = "lblToxicMetals";
            this.lblToxicMetals.Size = new System.Drawing.Size(67, 13);
            this.lblToxicMetals.TabIndex = 1;
            this.lblToxicMetals.Text = "Toxic Metals";
            // 
            // txtToxicQuantity
            // 
            this.txtToxicQuantity.Location = new System.Drawing.Point(143, 36);
            this.txtToxicQuantity.Name = "txtToxicQuantity";
            this.txtToxicQuantity.Size = new System.Drawing.Size(68, 20);
            this.txtToxicQuantity.TabIndex = 0;
            this.txtToxicQuantity.Text = "1315";
            // 
            // tabRecentSales
            // 
            this.tabRecentSales.Controls.Add(this.recentSalesDataGridView);
            this.tabRecentSales.Location = new System.Drawing.Point(4, 22);
            this.tabRecentSales.Name = "tabRecentSales";
            this.tabRecentSales.Size = new System.Drawing.Size(1119, 382);
            this.tabRecentSales.TabIndex = 13;
            this.tabRecentSales.Text = "Recent Sales";
            this.tabRecentSales.UseVisualStyleBackColor = true;
            this.tabRecentSales.Enter += new System.EventHandler(this.tabRecentSales_Enter);
            // 
            // recentSalesDataGridView
            // 
            this.recentSalesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.recentSalesDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.recentSalesDataGridView.Location = new System.Drawing.Point(0, 0);
            this.recentSalesDataGridView.Name = "recentSalesDataGridView";
            this.recentSalesDataGridView.Size = new System.Drawing.Size(1119, 382);
            this.recentSalesDataGridView.TabIndex = 0;
            this.recentSalesDataGridView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.recentSalesDataGridView_CellFormatting);
            // 
            // tabPurchase
            // 
            this.tabPurchase.Controls.Add(this.dataGridViewPurchase);
            this.tabPurchase.Controls.Add(this.panel1);
            this.tabPurchase.Location = new System.Drawing.Point(4, 22);
            this.tabPurchase.Name = "tabPurchase";
            this.tabPurchase.Size = new System.Drawing.Size(1119, 382);
            this.tabPurchase.TabIndex = 14;
            this.tabPurchase.Text = "Purchase";
            this.tabPurchase.UseVisualStyleBackColor = true;
            // 
            // dataGridViewPurchase
            // 
            this.dataGridViewPurchase.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPurchase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewPurchase.Location = new System.Drawing.Point(0, 59);
            this.dataGridViewPurchase.Name = "dataGridViewPurchase";
            this.dataGridViewPurchase.Size = new System.Drawing.Size(1119, 323);
            this.dataGridViewPurchase.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1119, 59);
            this.panel1.TabIndex = 0;
            // 
            // tabBuild
            // 
            this.tabBuild.Controls.Add(this.dataGridViewBuild);
            this.tabBuild.Controls.Add(this.panel2);
            this.tabBuild.Location = new System.Drawing.Point(4, 22);
            this.tabBuild.Name = "tabBuild";
            this.tabBuild.Size = new System.Drawing.Size(1119, 382);
            this.tabBuild.TabIndex = 15;
            this.tabBuild.Text = "Build";
            this.tabBuild.UseVisualStyleBackColor = true;
            // 
            // dataGridViewBuild
            // 
            this.dataGridViewBuild.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewBuild.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewBuild.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewBuild.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewBuild.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewBuild.Location = new System.Drawing.Point(0, 56);
            this.dataGridViewBuild.Name = "dataGridViewBuild";
            this.dataGridViewBuild.Size = new System.Drawing.Size(1119, 326);
            this.dataGridViewBuild.TabIndex = 1;
            this.dataGridViewBuild.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridViewBuild_CellFormatting);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtBuildTimeLimit);
            this.panel2.Controls.Add(this.btnBuildOrder);
            this.panel2.Controls.Add(this.chkBuildLimit);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1119, 56);
            this.panel2.TabIndex = 0;
            // 
            // txtBuildTimeLimit
            // 
            this.txtBuildTimeLimit.Location = new System.Drawing.Point(184, 17);
            this.txtBuildTimeLimit.Name = "txtBuildTimeLimit";
            this.txtBuildTimeLimit.Size = new System.Drawing.Size(46, 20);
            this.txtBuildTimeLimit.TabIndex = 6;
            this.txtBuildTimeLimit.Text = "5";
            // 
            // btnBuildOrder
            // 
            this.btnBuildOrder.Location = new System.Drawing.Point(24, 16);
            this.btnBuildOrder.Name = "btnBuildOrder";
            this.btnBuildOrder.Size = new System.Drawing.Size(75, 23);
            this.btnBuildOrder.TabIndex = 5;
            this.btnBuildOrder.Text = "Build Order";
            this.btnBuildOrder.UseVisualStyleBackColor = true;
            this.btnBuildOrder.Click += new System.EventHandler(this.btnBuildOrder_Click);
            // 
            // chkBuildLimit
            // 
            this.chkBuildLimit.AutoSize = true;
            this.chkBuildLimit.Checked = true;
            this.chkBuildLimit.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBuildLimit.Location = new System.Drawing.Point(131, 20);
            this.chkBuildLimit.Name = "chkBuildLimit";
            this.chkBuildLimit.Size = new System.Drawing.Size(47, 17);
            this.chkBuildLimit.TabIndex = 7;
            this.chkBuildLimit.Text = "Limit";
            this.chkBuildLimit.UseVisualStyleBackColor = true;
            // 
            // tabEveItems
            // 
            this.tabEveItems.Controls.Add(this.dataGridEveItems);
            this.tabEveItems.Controls.Add(this.panel3);
            this.tabEveItems.Location = new System.Drawing.Point(4, 22);
            this.tabEveItems.Name = "tabEveItems";
            this.tabEveItems.Size = new System.Drawing.Size(1119, 382);
            this.tabEveItems.TabIndex = 16;
            this.tabEveItems.Text = "Eve Items";
            this.tabEveItems.UseVisualStyleBackColor = true;
            // 
            // dataGridEveItems
            // 
            this.dataGridEveItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridEveItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridEveItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridEveItems.Location = new System.Drawing.Point(0, 52);
            this.dataGridEveItems.Name = "dataGridEveItems";
            this.dataGridEveItems.Size = new System.Drawing.Size(1119, 330);
            this.dataGridEveItems.TabIndex = 1;
            this.dataGridEveItems.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridEveItems_CellDoubleClick);
            this.dataGridEveItems.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridEveItems_CellFormatting);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.chkNeedBuy);
            this.panel3.Controls.Add(this.btnGetEveCentralPrices);
            this.panel3.Controls.Add(this.txtEveItemSearch);
            this.panel3.Controls.Add(this.chkTrackedPrices);
            this.panel3.Controls.Add(this.btnEveItems);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1119, 52);
            this.panel3.TabIndex = 0;
            // 
            // chkNeedBuy
            // 
            this.chkNeedBuy.AutoSize = true;
            this.chkNeedBuy.Location = new System.Drawing.Point(147, 32);
            this.chkNeedBuy.Name = "chkNeedBuy";
            this.chkNeedBuy.Size = new System.Drawing.Size(116, 17);
            this.chkNeedBuy.TabIndex = 5;
            this.chkNeedBuy.Text = "Items I need to buy";
            this.chkNeedBuy.UseVisualStyleBackColor = true;
            // 
            // btnGetEveCentralPrices
            // 
            this.btnGetEveCentralPrices.Location = new System.Drawing.Point(879, 16);
            this.btnGetEveCentralPrices.Name = "btnGetEveCentralPrices";
            this.btnGetEveCentralPrices.Size = new System.Drawing.Size(90, 23);
            this.btnGetEveCentralPrices.TabIndex = 4;
            this.btnGetEveCentralPrices.Text = "Update Prices";
            this.btnGetEveCentralPrices.UseVisualStyleBackColor = true;
            this.btnGetEveCentralPrices.Click += new System.EventHandler(this.btnGetEveCentralPrices_Click);
            // 
            // txtEveItemSearch
            // 
            this.txtEveItemSearch.Location = new System.Drawing.Point(348, 16);
            this.txtEveItemSearch.Name = "txtEveItemSearch";
            this.txtEveItemSearch.Size = new System.Drawing.Size(465, 20);
            this.txtEveItemSearch.TabIndex = 2;
            // 
            // chkTrackedPrices
            // 
            this.chkTrackedPrices.AutoSize = true;
            this.chkTrackedPrices.Checked = true;
            this.chkTrackedPrices.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTrackedPrices.Location = new System.Drawing.Point(147, 9);
            this.chkTrackedPrices.Name = "chkTrackedPrices";
            this.chkTrackedPrices.Size = new System.Drawing.Size(143, 17);
            this.chkTrackedPrices.TabIndex = 1;
            this.chkTrackedPrices.Text = "Items with tracked prices";
            this.chkTrackedPrices.UseVisualStyleBackColor = true;
            // 
            // btnEveItems
            // 
            this.btnEveItems.Location = new System.Drawing.Point(28, 14);
            this.btnEveItems.Name = "btnEveItems";
            this.btnEveItems.Size = new System.Drawing.Size(75, 23);
            this.btnEveItems.TabIndex = 0;
            this.btnEveItems.Text = "Eve Items";
            this.btnEveItems.UseVisualStyleBackColor = true;
            this.btnEveItems.Click += new System.EventHandler(this.btnEveItems_Click);
            // 
            // tabCharacters
            // 
            this.tabCharacters.Controls.Add(this.dataGridViewCharacters);
            this.tabCharacters.Controls.Add(this.panel4);
            this.tabCharacters.Location = new System.Drawing.Point(4, 22);
            this.tabCharacters.Name = "tabCharacters";
            this.tabCharacters.Size = new System.Drawing.Size(1119, 382);
            this.tabCharacters.TabIndex = 17;
            this.tabCharacters.Text = "Characters";
            this.tabCharacters.UseVisualStyleBackColor = true;
            // 
            // dataGridViewCharacters
            // 
            this.dataGridViewCharacters.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCharacters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewCharacters.Location = new System.Drawing.Point(0, 129);
            this.dataGridViewCharacters.Name = "dataGridViewCharacters";
            this.dataGridViewCharacters.Size = new System.Drawing.Size(1119, 253);
            this.dataGridViewCharacters.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.lblKeyID);
            this.panel4.Controls.Add(this.txtKeyID);
            this.panel4.Controls.Add(this.btnClearCharacter);
            this.panel4.Controls.Add(this.btnAddCharacter);
            this.panel4.Controls.Add(this.txtVCode);
            this.panel4.Controls.Add(this.txtCharacterID);
            this.panel4.Controls.Add(this.lblVCode);
            this.panel4.Controls.Add(this.lblCharacterID);
            this.panel4.Controls.Add(this.lblCharacterName);
            this.panel4.Controls.Add(this.txtCharacterName);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1119, 129);
            this.panel4.TabIndex = 0;
            // 
            // lblKeyID
            // 
            this.lblKeyID.AutoSize = true;
            this.lblKeyID.Location = new System.Drawing.Point(406, 69);
            this.lblKeyID.Name = "lblKeyID";
            this.lblKeyID.Size = new System.Drawing.Size(39, 13);
            this.lblKeyID.TabIndex = 9;
            this.lblKeyID.Text = "Key ID";
            // 
            // txtKeyID
            // 
            this.txtKeyID.Location = new System.Drawing.Point(462, 62);
            this.txtKeyID.Name = "txtKeyID";
            this.txtKeyID.Size = new System.Drawing.Size(238, 20);
            this.txtKeyID.TabIndex = 8;
            // 
            // btnClearCharacter
            // 
            this.btnClearCharacter.Location = new System.Drawing.Point(872, 60);
            this.btnClearCharacter.Name = "btnClearCharacter";
            this.btnClearCharacter.Size = new System.Drawing.Size(75, 23);
            this.btnClearCharacter.TabIndex = 7;
            this.btnClearCharacter.Text = "Clear";
            this.btnClearCharacter.UseVisualStyleBackColor = true;
            // 
            // btnAddCharacter
            // 
            this.btnAddCharacter.Location = new System.Drawing.Point(872, 22);
            this.btnAddCharacter.Name = "btnAddCharacter";
            this.btnAddCharacter.Size = new System.Drawing.Size(75, 23);
            this.btnAddCharacter.TabIndex = 6;
            this.btnAddCharacter.Text = "Add";
            this.btnAddCharacter.UseVisualStyleBackColor = true;
            this.btnAddCharacter.Click += new System.EventHandler(this.btnAddCharacter_Click);
            // 
            // txtVCode
            // 
            this.txtVCode.Location = new System.Drawing.Point(462, 22);
            this.txtVCode.Name = "txtVCode";
            this.txtVCode.Size = new System.Drawing.Size(238, 20);
            this.txtVCode.TabIndex = 5;
            // 
            // txtCharacterID
            // 
            this.txtCharacterID.Location = new System.Drawing.Point(103, 63);
            this.txtCharacterID.Name = "txtCharacterID";
            this.txtCharacterID.Size = new System.Drawing.Size(238, 20);
            this.txtCharacterID.TabIndex = 4;
            // 
            // lblVCode
            // 
            this.lblVCode.AutoSize = true;
            this.lblVCode.Location = new System.Drawing.Point(403, 29);
            this.lblVCode.Name = "lblVCode";
            this.lblVCode.Size = new System.Drawing.Size(38, 13);
            this.lblVCode.TabIndex = 3;
            this.lblVCode.Text = "vCode";
            // 
            // lblCharacterID
            // 
            this.lblCharacterID.AutoSize = true;
            this.lblCharacterID.Location = new System.Drawing.Point(20, 69);
            this.lblCharacterID.Name = "lblCharacterID";
            this.lblCharacterID.Size = new System.Drawing.Size(67, 13);
            this.lblCharacterID.TabIndex = 2;
            this.lblCharacterID.Text = "Character ID";
            // 
            // lblCharacterName
            // 
            this.lblCharacterName.AutoSize = true;
            this.lblCharacterName.Location = new System.Drawing.Point(20, 22);
            this.lblCharacterName.Name = "lblCharacterName";
            this.lblCharacterName.Size = new System.Drawing.Size(35, 13);
            this.lblCharacterName.TabIndex = 1;
            this.lblCharacterName.Text = "Name";
            // 
            // txtCharacterName
            // 
            this.txtCharacterName.Location = new System.Drawing.Point(103, 22);
            this.txtCharacterName.Name = "txtCharacterName";
            this.txtCharacterName.Size = new System.Drawing.Size(238, 20);
            this.txtCharacterName.TabIndex = 0;
            // 
            // tabStockCheck
            // 
            this.tabStockCheck.Controls.Add(this.dataGridStock);
            this.tabStockCheck.Controls.Add(this.panel5);
            this.tabStockCheck.Location = new System.Drawing.Point(4, 22);
            this.tabStockCheck.Name = "tabStockCheck";
            this.tabStockCheck.Padding = new System.Windows.Forms.Padding(3);
            this.tabStockCheck.Size = new System.Drawing.Size(1119, 382);
            this.tabStockCheck.TabIndex = 18;
            this.tabStockCheck.Text = "Stock Check";
            this.tabStockCheck.UseVisualStyleBackColor = true;
            // 
            // dataGridStock
            // 
            this.dataGridStock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridStock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridStock.Location = new System.Drawing.Point(3, 51);
            this.dataGridStock.Name = "dataGridStock";
            this.dataGridStock.Size = new System.Drawing.Size(1113, 328);
            this.dataGridStock.TabIndex = 1;
            this.dataGridStock.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridStock_CellDoubleClick);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.btnBestSellers);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(3, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1113, 48);
            this.panel5.TabIndex = 0;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1124, 467);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnLoadNew);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Eve Transactions";
            this.tabControl1.ResumeLayout(false);
            this.tabBestSellers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.panelStockHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.stockGridView)).EndInit();
            this.panelStock.ResumeLayout(false);
            this.panelStock.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.panelGroupedStockHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupedStockGridView)).EndInit();
            this.panelGroupedStock.ResumeLayout(false);
            this.panelGroupedStock.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.panelSales.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.salesDataGridView)).EndInit();
            this.panelSalesHeader.ResumeLayout(false);
            this.panelSalesHeader.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dailyGridView)).EndInit();
            this.tabPage6.ResumeLayout(false);
            this.tabPage7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.journalDataGridView)).EndInit();
            this.tabPage8.ResumeLayout(false);
            this.panelMonthlyBestHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dailyRewardsDataGridView)).EndInit();
            this.panelMonthlyBest.ResumeLayout(false);
            this.panelMonthlyBest.PerformLayout();
            this.tabPage10.ResumeLayout(false);
            this.tabPage10.PerformLayout();
            this.tabPage11.ResumeLayout(false);
            this.panelRecipesHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridRecipes)).EndInit();
            this.panelRecipes.ResumeLayout(false);
            this.panelRecipes.PerformLayout();
            this.tabPage9.ResumeLayout(false);
            this.panelRecipeStockBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRecipeStock)).EndInit();
            this.panelRecipeStockTop.ResumeLayout(false);
            this.panelRecipeStockTop.PerformLayout();
            this.tabPage12.ResumeLayout(false);
            this.tabPage12.PerformLayout();
            this.tabRecentSales.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.recentSalesDataGridView)).EndInit();
            this.tabPurchase.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPurchase)).EndInit();
            this.tabBuild.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBuild)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tabEveItems.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridEveItems)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.tabCharacters.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCharacters)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.tabStockCheck.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridStock)).EndInit();
            this.panel5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private FastGridView dataGridView1;
        private System.Windows.Forms.Button btnLoadNew;
        private System.Windows.Forms.Button btnBestSellers;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabBestSellers;
        private System.Windows.Forms.TabPage tabPage2;
        private FastGridView stockGridView;
        private System.Windows.Forms.DataGridViewButtonColumn ButtonColumn;
        private System.Windows.Forms.TabPage tabPage3;
        private FastGridView groupedStockGridView;
        private System.Windows.Forms.TabPage tabPage4;
        private FastGridView salesDataGridView;
        private System.Windows.Forms.TabPage tabPage5;
        private FastGridView dailyGridView;
        private System.Windows.Forms.TabPage tabPage6;
        private ZedGraph.ZedGraphControl dailyGraph;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.TabPage tabPage7;
        private FastGridView journalDataGridView;
        private System.Windows.Forms.TabPage tabPage8;
        private FastGridView dailyRewardsDataGridView;
        private System.Windows.Forms.Button btnSearchSales;
        private System.Windows.Forms.TextBox txtSearchSales;
        private System.Windows.Forms.RadioButton radioSalesAllTime;
        private System.Windows.Forms.RadioButton radioSalesPastWeek;
        private System.Windows.Forms.RadioButton radioSalesDay;
        private System.Windows.Forms.RadioButton radioSalesToday;
        private System.Windows.Forms.TabPage tabPage10;
        private System.Windows.Forms.Panel panelStockHeader;
        private System.Windows.Forms.Panel panelStock;
        private System.Windows.Forms.TextBox txtStockSearch;
        private System.Windows.Forms.Button btnStockSearch;
        private System.Windows.Forms.Panel panelGroupedStockHeader;
        private System.Windows.Forms.Panel panelGroupedStock;
        private System.Windows.Forms.Button btnGroupedStockSearch;
        private System.Windows.Forms.TextBox txtGroupedStockSearch;
        private System.Windows.Forms.TabPage tabPage11;
        private System.Windows.Forms.Panel panelRecipesHeader;
        private System.Windows.Forms.Panel panelRecipes;
        private FastGridView dataGridRecipes;
        private System.Windows.Forms.Panel panelSales;
        private System.Windows.Forms.Panel panelSalesHeader;
        private System.Windows.Forms.TextBox txtAddStockPrice;
        private System.Windows.Forms.TextBox txtAddStockQuantity;
        private System.Windows.Forms.TextBox txtAddStockName;
        private System.Windows.Forms.Button btnAddStock;
        private System.Windows.Forms.TextBox txtSetStockQuantity;
        private System.Windows.Forms.TextBox txtSetStockName;
        private System.Windows.Forms.Button btnSetStock;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage9;
        private System.Windows.Forms.Panel panelRecipeStockBottom;
        private System.Windows.Forms.Panel panelRecipeStockTop;
        private System.Windows.Forms.ComboBox cmbGetStock;
        private System.Windows.Forms.Button btnGetStock;
        private FastGridView dataGridViewRecipeStock;
        private System.Windows.Forms.TextBox txtRuns;
        private System.Windows.Forms.Panel panelMonthlyBest;
        private System.Windows.Forms.CheckBox chkLastMonth;
        private System.Windows.Forms.CheckBox chkIncludeLoot;
        private System.Windows.Forms.Button btnRefreshMonthlyBestSeller;
        private System.Windows.Forms.Panel panelMonthlyBestHeader;
        private System.Windows.Forms.TabPage tabPage12;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnAddRobotics;
        private System.Windows.Forms.TextBox txtRoboticsTaxRate;
        private System.Windows.Forms.TextBox txtRoboticsQuantity;
        private System.Windows.Forms.Label lblRobotics;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtChiralPrice;
        private System.Windows.Forms.TextBox txtReactivePrice;
        private System.Windows.Forms.TextBox txtPreciousPrice;
        private System.Windows.Forms.TextBox txtToxicPrice;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAddChiralStructures;
        private System.Windows.Forms.Button btnAddReactiveMetals;
        private System.Windows.Forms.Button btnAddPreciousMetals;
        private System.Windows.Forms.Button btnAddToxicMetals;
        private System.Windows.Forms.TextBox txtChiralQuantity;
        private System.Windows.Forms.TextBox txtReactiveQuantity;
        private System.Windows.Forms.TextBox txtPreciousQuantity;
        private System.Windows.Forms.Label lblChiralStructures;
        private System.Windows.Forms.Label lblReactiveMetals;
        private System.Windows.Forms.Label lblPreciousMetals;
        private System.Windows.Forms.Label lblToxicMetals;
        private System.Windows.Forms.TextBox txtToxicQuantity;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblProjected;
        private System.Windows.Forms.Label lblPerDay;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private MaterialSkin.Controls.MaterialFlatButton bntNewRecipe;
        private System.Windows.Forms.TabPage tabRecentSales;
        private FastGridView recentSalesDataGridView;
        private System.Windows.Forms.Button btnAddGuidanceSystems;
        private System.Windows.Forms.TextBox txtGuidanceSystemsTaxRate;
        private System.Windows.Forms.TextBox txtGuidanceSystemsQuantity;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox chkOnlyTrackedPrices;
        private System.Windows.Forms.Button btnGetEveCentralPrices;
        private System.Windows.Forms.Button btnBuildOrder;
        private System.Windows.Forms.CheckBox chkBuildLimit;
        private System.Windows.Forms.TextBox txtBuildTimeLimit;
        private System.Windows.Forms.TabPage tabPurchase;
        private FastGridView dataGridViewPurchase;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabPage tabBuild;
        private FastGridView dataGridViewBuild;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TabPage tabEveItems;
        private EveTransactions.Domain.FastGridView dataGridEveItems;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.CheckBox chkTrackedPrices;
        private System.Windows.Forms.Button btnEveItems;
        private System.Windows.Forms.TextBox txtEveItemSearch;
        private System.Windows.Forms.CheckBox chkNeedBuy;
        private System.Windows.Forms.TabPage tabCharacters;
        private System.Windows.Forms.DataGridView dataGridViewCharacters;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnClearCharacter;
        private System.Windows.Forms.Button btnAddCharacter;
        private System.Windows.Forms.TextBox txtVCode;
        private System.Windows.Forms.TextBox txtCharacterID;
        private System.Windows.Forms.Label lblVCode;
        private System.Windows.Forms.Label lblCharacterID;
        private System.Windows.Forms.Label lblCharacterName;
        private System.Windows.Forms.TextBox txtCharacterName;
        private System.Windows.Forms.Label lblKeyID;
        private System.Windows.Forms.TextBox txtKeyID;
        private System.Windows.Forms.TabPage tabStockCheck;
        private FastGridView dataGridStock;
        private System.Windows.Forms.Panel panel5;
    }
}

