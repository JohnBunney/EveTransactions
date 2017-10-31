namespace EveTransactions
{
    partial class RecipeForm
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
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.txtNewRecipeName = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.btnRecipeCreate = new MaterialSkin.Controls.MaterialFlatButton();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.txtIngredientName = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.txtIngredientQuantity = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.btnIngredientAdd = new MaterialSkin.Controls.MaterialFlatButton();
            this.dataGridIngredients = new EveTransactions.Domain.FastGridView();
            this.materialLabel4 = new MaterialSkin.Controls.MaterialLabel();
            this.txtMultiplier = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.txtTargetStock = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.btnUpdate = new MaterialSkin.Controls.MaterialFlatButton();
            this.txtPrimary = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.materialLabel5 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel6 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel7 = new MaterialSkin.Controls.MaterialLabel();
            this.txtBuildTime = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.txtMaxRuns = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.materialLabel8 = new MaterialSkin.Controls.MaterialLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridIngredients)).BeginInit();
            this.SuspendLayout();
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(13, 79);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(49, 19);
            this.materialLabel1.TabIndex = 0;
            this.materialLabel1.Text = "Name";
            // 
            // txtNewRecipeName
            // 
            this.txtNewRecipeName.Depth = 0;
            this.txtNewRecipeName.Hint = "";
            this.txtNewRecipeName.Location = new System.Drawing.Point(77, 75);
            this.txtNewRecipeName.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtNewRecipeName.Name = "txtNewRecipeName";
            this.txtNewRecipeName.PasswordChar = '\0';
            this.txtNewRecipeName.SelectedText = "";
            this.txtNewRecipeName.SelectionLength = 0;
            this.txtNewRecipeName.SelectionStart = 0;
            this.txtNewRecipeName.Size = new System.Drawing.Size(430, 23);
            this.txtNewRecipeName.TabIndex = 1;
            this.txtNewRecipeName.UseSystemPasswordChar = false;
            // 
            // btnRecipeCreate
            // 
            this.btnRecipeCreate.AutoSize = true;
            this.btnRecipeCreate.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnRecipeCreate.Depth = 0;
            this.btnRecipeCreate.Location = new System.Drawing.Point(706, 71);
            this.btnRecipeCreate.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnRecipeCreate.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnRecipeCreate.Name = "btnRecipeCreate";
            this.btnRecipeCreate.Primary = false;
            this.btnRecipeCreate.Size = new System.Drawing.Size(62, 36);
            this.btnRecipeCreate.TabIndex = 2;
            this.btnRecipeCreate.Text = "Create";
            this.btnRecipeCreate.UseVisualStyleBackColor = true;
            this.btnRecipeCreate.Click += new System.EventHandler(this.btnRecipeCreate_Click);
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel2.Location = new System.Drawing.Point(13, 118);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(75, 19);
            this.materialLabel2.TabIndex = 3;
            this.materialLabel2.Text = "Ingredient";
            // 
            // txtIngredientName
            // 
            this.txtIngredientName.Depth = 0;
            this.txtIngredientName.Hint = "";
            this.txtIngredientName.Location = new System.Drawing.Point(94, 114);
            this.txtIngredientName.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtIngredientName.Name = "txtIngredientName";
            this.txtIngredientName.PasswordChar = '\0';
            this.txtIngredientName.SelectedText = "";
            this.txtIngredientName.SelectionLength = 0;
            this.txtIngredientName.SelectionStart = 0;
            this.txtIngredientName.Size = new System.Drawing.Size(413, 23);
            this.txtIngredientName.TabIndex = 4;
            this.txtIngredientName.UseSystemPasswordChar = false;
            // 
            // materialLabel3
            // 
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel3.Location = new System.Drawing.Point(542, 118);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(64, 19);
            this.materialLabel3.TabIndex = 5;
            this.materialLabel3.Text = "Quantity";
            // 
            // txtIngredientQuantity
            // 
            this.txtIngredientQuantity.Depth = 0;
            this.txtIngredientQuantity.Hint = "";
            this.txtIngredientQuantity.Location = new System.Drawing.Point(612, 118);
            this.txtIngredientQuantity.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtIngredientQuantity.Name = "txtIngredientQuantity";
            this.txtIngredientQuantity.PasswordChar = '\0';
            this.txtIngredientQuantity.SelectedText = "";
            this.txtIngredientQuantity.SelectionLength = 0;
            this.txtIngredientQuantity.SelectionStart = 0;
            this.txtIngredientQuantity.Size = new System.Drawing.Size(78, 23);
            this.txtIngredientQuantity.TabIndex = 6;
            this.txtIngredientQuantity.Text = "1";
            this.txtIngredientQuantity.UseSystemPasswordChar = false;
            // 
            // btnIngredientAdd
            // 
            this.btnIngredientAdd.AutoSize = true;
            this.btnIngredientAdd.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnIngredientAdd.Depth = 0;
            this.btnIngredientAdd.Location = new System.Drawing.Point(706, 114);
            this.btnIngredientAdd.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnIngredientAdd.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnIngredientAdd.Name = "btnIngredientAdd";
            this.btnIngredientAdd.Primary = false;
            this.btnIngredientAdd.Size = new System.Drawing.Size(39, 36);
            this.btnIngredientAdd.TabIndex = 7;
            this.btnIngredientAdd.Text = "Add";
            this.btnIngredientAdd.UseVisualStyleBackColor = true;
            this.btnIngredientAdd.Click += new System.EventHandler(this.btnIngredientAdd_Click);
            // 
            // dataGridIngredients
            // 
            this.dataGridIngredients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridIngredients.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridIngredients.Location = new System.Drawing.Point(0, 207);
            this.dataGridIngredients.Name = "dataGridIngredients";
            this.dataGridIngredients.Size = new System.Drawing.Size(783, 187);
            this.dataGridIngredients.TabIndex = 8;
            // 
            // materialLabel4
            // 
            this.materialLabel4.AutoSize = true;
            this.materialLabel4.Depth = 0;
            this.materialLabel4.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel4.Location = new System.Drawing.Point(534, 76);
            this.materialLabel4.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel4.Name = "materialLabel4";
            this.materialLabel4.Size = new System.Drawing.Size(72, 19);
            this.materialLabel4.TabIndex = 10;
            this.materialLabel4.Text = "Multiplier";
            // 
            // txtMultiplier
            // 
            this.txtMultiplier.Depth = 0;
            this.txtMultiplier.Hint = "";
            this.txtMultiplier.Location = new System.Drawing.Point(612, 76);
            this.txtMultiplier.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtMultiplier.Name = "txtMultiplier";
            this.txtMultiplier.PasswordChar = '\0';
            this.txtMultiplier.SelectedText = "";
            this.txtMultiplier.SelectionLength = 0;
            this.txtMultiplier.SelectionStart = 0;
            this.txtMultiplier.Size = new System.Drawing.Size(78, 23);
            this.txtMultiplier.TabIndex = 11;
            this.txtMultiplier.Text = "1";
            this.txtMultiplier.UseSystemPasswordChar = false;
            // 
            // txtTargetStock
            // 
            this.txtTargetStock.Depth = 0;
            this.txtTargetStock.Hint = "";
            this.txtTargetStock.Location = new System.Drawing.Point(612, 162);
            this.txtTargetStock.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtTargetStock.Name = "txtTargetStock";
            this.txtTargetStock.PasswordChar = '\0';
            this.txtTargetStock.SelectedText = "";
            this.txtTargetStock.SelectionLength = 0;
            this.txtTargetStock.SelectionStart = 0;
            this.txtTargetStock.Size = new System.Drawing.Size(78, 23);
            this.txtTargetStock.TabIndex = 12;
            this.txtTargetStock.Text = "100";
            this.txtTargetStock.UseSystemPasswordChar = false;
            // 
            // btnUpdate
            // 
            this.btnUpdate.AutoSize = true;
            this.btnUpdate.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnUpdate.Depth = 0;
            this.btnUpdate.Location = new System.Drawing.Point(706, 162);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnUpdate.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Primary = false;
            this.btnUpdate.Size = new System.Drawing.Size(64, 36);
            this.btnUpdate.TabIndex = 13;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // txtPrimary
            // 
            this.txtPrimary.Depth = 0;
            this.txtPrimary.Hint = "";
            this.txtPrimary.Location = new System.Drawing.Point(79, 162);
            this.txtPrimary.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtPrimary.Name = "txtPrimary";
            this.txtPrimary.PasswordChar = '\0';
            this.txtPrimary.SelectedText = "";
            this.txtPrimary.SelectionLength = 0;
            this.txtPrimary.SelectionStart = 0;
            this.txtPrimary.Size = new System.Drawing.Size(116, 23);
            this.txtPrimary.TabIndex = 14;
            this.txtPrimary.Text = "Tashaki";
            this.txtPrimary.UseSystemPasswordChar = false;
            // 
            // materialLabel5
            // 
            this.materialLabel5.AutoSize = true;
            this.materialLabel5.Depth = 0;
            this.materialLabel5.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel5.Location = new System.Drawing.Point(13, 162);
            this.materialLabel5.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel5.Name = "materialLabel5";
            this.materialLabel5.Size = new System.Drawing.Size(60, 19);
            this.materialLabel5.TabIndex = 15;
            this.materialLabel5.Text = "Primary";
            // 
            // materialLabel6
            // 
            this.materialLabel6.AutoSize = true;
            this.materialLabel6.Depth = 0;
            this.materialLabel6.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel6.Location = new System.Drawing.Point(201, 162);
            this.materialLabel6.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel6.Name = "materialLabel6";
            this.materialLabel6.Size = new System.Drawing.Size(80, 19);
            this.materialLabel6.TabIndex = 16;
            this.materialLabel6.Text = "Build Time";
            // 
            // materialLabel7
            // 
            this.materialLabel7.AutoSize = true;
            this.materialLabel7.Depth = 0;
            this.materialLabel7.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel7.Location = new System.Drawing.Point(526, 162);
            this.materialLabel7.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel7.Name = "materialLabel7";
            this.materialLabel7.Size = new System.Drawing.Size(80, 19);
            this.materialLabel7.TabIndex = 17;
            this.materialLabel7.Text = "Max Stock";
            // 
            // txtBuildTime
            // 
            this.txtBuildTime.Depth = 0;
            this.txtBuildTime.Hint = "";
            this.txtBuildTime.Location = new System.Drawing.Point(287, 162);
            this.txtBuildTime.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtBuildTime.Name = "txtBuildTime";
            this.txtBuildTime.PasswordChar = '\0';
            this.txtBuildTime.SelectedText = "";
            this.txtBuildTime.SelectionLength = 0;
            this.txtBuildTime.SelectionStart = 0;
            this.txtBuildTime.Size = new System.Drawing.Size(65, 23);
            this.txtBuildTime.TabIndex = 18;
            this.txtBuildTime.Text = "2.5";
            this.txtBuildTime.UseSystemPasswordChar = false;
            // 
            // txtMaxRuns
            // 
            this.txtMaxRuns.Depth = 0;
            this.txtMaxRuns.Hint = "";
            this.txtMaxRuns.Location = new System.Drawing.Point(442, 162);
            this.txtMaxRuns.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtMaxRuns.Name = "txtMaxRuns";
            this.txtMaxRuns.PasswordChar = '\0';
            this.txtMaxRuns.SelectedText = "";
            this.txtMaxRuns.SelectionLength = 0;
            this.txtMaxRuns.SelectionStart = 0;
            this.txtMaxRuns.Size = new System.Drawing.Size(65, 23);
            this.txtMaxRuns.TabIndex = 19;
            this.txtMaxRuns.Text = "99999";
            this.txtMaxRuns.UseSystemPasswordChar = false;
            // 
            // materialLabel8
            // 
            this.materialLabel8.AutoSize = true;
            this.materialLabel8.Depth = 0;
            this.materialLabel8.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel8.Location = new System.Drawing.Point(358, 162);
            this.materialLabel8.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel8.Name = "materialLabel8";
            this.materialLabel8.Size = new System.Drawing.Size(74, 19);
            this.materialLabel8.TabIndex = 20;
            this.materialLabel8.Text = "Max Runs";
            // 
            // RecipeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(783, 394);
            this.Controls.Add(this.materialLabel8);
            this.Controls.Add(this.txtMaxRuns);
            this.Controls.Add(this.txtBuildTime);
            this.Controls.Add(this.materialLabel7);
            this.Controls.Add(this.materialLabel6);
            this.Controls.Add(this.materialLabel5);
            this.Controls.Add(this.txtPrimary);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.txtTargetStock);
            this.Controls.Add(this.txtMultiplier);
            this.Controls.Add(this.materialLabel4);
            this.Controls.Add(this.dataGridIngredients);
            this.Controls.Add(this.btnIngredientAdd);
            this.Controls.Add(this.txtIngredientQuantity);
            this.Controls.Add(this.materialLabel3);
            this.Controls.Add(this.txtIngredientName);
            this.Controls.Add(this.materialLabel2);
            this.Controls.Add(this.btnRecipeCreate);
            this.Controls.Add(this.txtNewRecipeName);
            this.Controls.Add(this.materialLabel1);
            this.Name = "RecipeForm";
            this.Text = "Recipe";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridIngredients)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtNewRecipeName;
        private MaterialSkin.Controls.MaterialFlatButton btnRecipeCreate;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtIngredientName;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtIngredientQuantity;
        private MaterialSkin.Controls.MaterialFlatButton btnIngredientAdd;
        private Domain.FastGridView dataGridIngredients;
        private MaterialSkin.Controls.MaterialLabel materialLabel4;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtMultiplier;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtTargetStock;
        private MaterialSkin.Controls.MaterialFlatButton btnUpdate;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtPrimary;
        private MaterialSkin.Controls.MaterialLabel materialLabel5;
        private MaterialSkin.Controls.MaterialLabel materialLabel6;
        private MaterialSkin.Controls.MaterialLabel materialLabel7;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtBuildTime;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtMaxRuns;
        private MaterialSkin.Controls.MaterialLabel materialLabel8;
    }
}