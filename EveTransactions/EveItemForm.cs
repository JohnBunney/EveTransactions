using System;
using System.Linq;
using EveTransactions.Repository;
using MaterialSkin;
using MaterialSkin.Controls;

namespace EveTransactions
{
    public partial class EveItemForm : MaterialForm
    {
        private string m_Item;

        public EveItemForm()
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }

        public EveItemForm(string eveItemName) : this()
        {
            var repository = new EveRepository();
            var item = repository.EveItems.FirstOrDefault(x => x.ItemName == eveItemName);

            if (item == null) return;

            m_Item = eveItemName;

            lblItemName.Text = item.ItemName;
            txtTargetStock.Text = item.TargetStock.ToString();
            chkTrackPrices.Checked = item.TrackPrices;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var repository = new EveRepository();

            var item = repository.EveItems.FirstOrDefault(x => x.ItemName == m_Item);

            if (item == null)
            {
                this.Close();
            }

            item.TrackPrices = chkTrackPrices.Checked;
            
            long targetStock;

            if (long.TryParse(txtTargetStock.Text, out targetStock))
            {
                item.TargetStock = targetStock;
            }


            repository.SaveChanges();
            this.Close();
        }

    }
}
