using EveTransactions.Domain;
using EveTransactions.Repository;
using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EveTransactions
{
    public partial class RecipeForm : MaterialForm
    {

        private string m_RecipeName;

        public RecipeForm()
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);

        }

        public RecipeForm(string recipeName)
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);

            m_RecipeName = recipeName;
            txtNewRecipeName.Text = recipeName;
            txtNewRecipeName.Enabled = false;
            btnRecipeCreate.Enabled = false;

            var repository = new EveRepository();
            var recipe = repository.Recipes.FirstOrDefault(x => x.TypeName == m_RecipeName);

            if (recipe == null) return;

            dataGridIngredients.DataSource = repository.RecipeInputs.Where(x => x.RecipeID == recipe.RecipeID).ToList();

            txtPrimary.Text = recipe.PrimaryManufacturer;
            txtTargetStock.Text = recipe.MaximumStock.ToString();
            txtBuildTime.Text = recipe.BuildTimeHours.ToString();
            txtMultiplier.Text = recipe.OutputMultiplier.ToString();
            txtMaxRuns.Text = recipe.MaxRuns.ToString();
        }


        private void btnRecipeCreate_Click(object sender, EventArgs e)
        {
            var repository = new EveRepository();

            if (string.IsNullOrEmpty(txtNewRecipeName.Text))
            {
                return;
            }
            
            int multiplier;
            if (!Int32.TryParse(txtMultiplier.Text, out multiplier))
            {
                return;
            }

            var recipe = new Recipe(txtNewRecipeName.Text);
            recipe.OutputMultiplier = multiplier;
            
            repository.Recipes.Add(recipe);
            repository.SaveChanges();

            txtNewRecipeName.Enabled = false;
            btnRecipeCreate.Enabled = false;

            m_RecipeName = txtNewRecipeName.Text;

        }

        private void btnIngredientAdd_Click(object sender, EventArgs e)
        {
            var repository = new EveRepository();

            if (string.IsNullOrEmpty(txtIngredientName.Text)) return;
            if (string.IsNullOrEmpty(txtIngredientQuantity.Text)) return;

            int quantity = 0;
            Int32.TryParse(txtIngredientQuantity.Text, out quantity);

            var recipe = repository.Recipes.FirstOrDefault(x => x.TypeName == m_RecipeName);

            if (recipe == null) return;

            var recipeItem = new RecipeInput(recipe.RecipeID, txtIngredientName.Text, quantity);
            repository.RecipeInputs.Add(recipeItem);
            repository.SaveChanges();

            dataGridIngredients.DataSource = repository.RecipeInputs.Where(x => x.RecipeID == recipe.RecipeID).ToList();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var repository = new EveRepository();

            if (string.IsNullOrEmpty(txtTargetStock.Text)) return;
            if (string.IsNullOrEmpty(txtMultiplier.Text)) return;

            int target = 0;
            int multiplier = 0;
            decimal buildtime = 0;
            long maxruns = 0;
            Int32.TryParse(txtTargetStock.Text, out target);
            Int32.TryParse(txtMultiplier.Text, out multiplier);
            Decimal.TryParse(txtBuildTime.Text, out buildtime);
            long.TryParse(txtMaxRuns.Text, out maxruns);

            var recipe = repository.Recipes.FirstOrDefault(x => x.TypeName == m_RecipeName);

            if (recipe == null) return;

            recipe.MaximumStock = target;
            recipe.OutputMultiplier = multiplier;
            recipe.PrimaryManufacturer = txtPrimary.Text;
            recipe.BuildTimeHours = buildtime;
            recipe.MaxRuns = maxruns;

            repository.SaveChanges();

            this.Close();
        }
    }
}
