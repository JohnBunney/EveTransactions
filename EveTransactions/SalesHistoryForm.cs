using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using EveTransactions.Repository;
using MaterialSkin;
using MaterialSkin.Controls;
using ZedGraph;

namespace EveTransactions
{
    public partial class SalesHistoryForm : MaterialForm
    {
        private string m_Item;

        public SalesHistoryForm()
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);

        }

        public SalesHistoryForm(string item)
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);

            m_Item = item;

            var repository = new EveRepository();

            var sales =
                repository.Sales.Where(x => x.TypeName == m_Item)
                          .Select(x => new {x.SellDate, x.BuyPrice, x.SellPrice, x.ProfitPerUnit});

            GraphPane graphPane = salesGraph.GraphPane;
            graphPane.XAxis.Type = AxisType.Date;
            salesGraph.GraphPane.CurveList.Clear();

























































































































































            salesGraph.GraphPane.GraphObjList.Clear();

            var dates = new List<double>();
            foreach (var sale in sales)
            {
                double x = (double) new XDate(sale.SellDate);
                dates.Add(x);
            }


            //LineItem buyLineItem = graphPane.AddCurve("Buy Price", dates.ToArray(), sales.Select(s => s.BuyPrice).ToArray(), Color.Brown);

            //LineItem sellLineItem = graphPane.AddCurve("Sell Price", dates.ToArray(), sales.Select(s => s.SellPrice).ToArray(), Color.Navy);

            //LineItem profitLineItem = graphPane.AddCurve("Profit", dates.ToArray(), sales.Select(s => s.ProfitPerUnit).ToArray(), Color.DarkGreen);

            //buyLineItem.Symbol.Type = SymbolType.None;
            //sellLineItem.Symbol.Type = SymbolType.None;
            //profitLineItem.Symbol.Type = SymbolType.None;

            //buyLineItem.Line.IsSmooth = true;

            graphPane.XAxis.Type = AxisType.Text;

            salesGraph.AxisChange();

        }

        private void SalesHistoryForm_Load(object sender, System.EventArgs e)
        {






































































































































































        }

    }
}
