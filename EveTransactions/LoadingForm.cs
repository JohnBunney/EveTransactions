using System.ComponentModel;
using MaterialSkin;
using MaterialSkin.Controls;

namespace EveTransactions
{
    public partial class LoadingForm : MaterialForm
    {
        #region Constructors

        public LoadingForm()
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }

        public LoadingForm(BackgroundWorker worker)
        {
            worker.ProgressChanged += ProgressDialog_ProgressChanged;
        }

        #endregion

        #region Properties

        public int ProgressValue
        {
            set { progressBar1.Value = value; }
        }

        public string ProgressMessage
        {
            set
            {
                materialLabel1.Text = value;
            }
        }

        #endregion

        private void ProgressDialog_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            UpdateProgressBar(e.ProgressPercentage);
        }

        private void UpdateProgressBar(int percentage)
        {
            progressBar1.Value = percentage;
        }
    }
}
