namespace EveTransactions
{
    partial class StockForm
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
            this.lblItemName = new MaterialSkin.Controls.MaterialLabel();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblAssumedStock = new MaterialSkin.Controls.MaterialLabel();
            this.lblAssumedStockValue = new MaterialSkin.Controls.MaterialLabel();
            this.lblChange = new MaterialSkin.Controls.MaterialLabel();
            this.txtChangeBy = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.lblActualStock = new MaterialSkin.Controls.MaterialLabel();
            this.lblActualStockValue = new MaterialSkin.Controls.MaterialLabel();
            this.lblPrice = new MaterialSkin.Controls.MaterialLabel();
            this.txtPrice = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.SuspendLayout();
            // 
            // lblItemName
            // 
            this.lblItemName.AutoSize = true;
            this.lblItemName.Depth = 0;
            this.lblItemName.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblItemName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblItemName.Location = new System.Drawing.Point(35, 99);
            this.lblItemName.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblItemName.Name = "lblItemName";
            this.lblItemName.Size = new System.Drawing.Size(95, 19);
            this.lblItemName.TabIndex = 0;
            this.lblItemName.Text = "lblItemName";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(406, 230);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblAssumedStock
            // 
            this.lblAssumedStock.AutoSize = true;
            this.lblAssumedStock.Depth = 0;
            this.lblAssumedStock.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblAssumedStock.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblAssumedStock.Location = new System.Drawing.Point(35, 144);
            this.lblAssumedStock.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblAssumedStock.Name = "lblAssumedStock";
            this.lblAssumedStock.Size = new System.Drawing.Size(115, 19);
            this.lblAssumedStock.TabIndex = 2;
            this.lblAssumedStock.Text = "Assumed Stock";
            // 
            // lblAssumedStockValue
            // 
            this.lblAssumedStockValue.AutoSize = true;
            this.lblAssumedStockValue.Depth = 0;
            this.lblAssumedStockValue.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblAssumedStockValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblAssumedStockValue.Location = new System.Drawing.Point(181, 144);
            this.lblAssumedStockValue.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblAssumedStockValue.Name = "lblAssumedStockValue";
            this.lblAssumedStockValue.Size = new System.Drawing.Size(55, 19);
            this.lblAssumedStockValue.TabIndex = 3;
            this.lblAssumedStockValue.Text = "[Value]";
            // 
            // lblChange
            // 
            this.lblChange.AutoSize = true;
            this.lblChange.Depth = 0;
            this.lblChange.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblChange.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblChange.Location = new System.Drawing.Point(35, 190);
            this.lblChange.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblChange.Name = "lblChange";
            this.lblChange.Size = new System.Drawing.Size(79, 19);
            this.lblChange.TabIndex = 4;
            this.lblChange.Text = "Change By";
            // 
            // txtChangeBy
            // 
            this.txtChangeBy.Depth = 0;
            this.txtChangeBy.Hint = "";
            this.txtChangeBy.Location = new System.Drawing.Point(185, 188);
            this.txtChangeBy.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtChangeBy.Name = "txtChangeBy";
            this.txtChangeBy.PasswordChar = '\0';
            this.txtChangeBy.SelectedText = "";
            this.txtChangeBy.SelectionLength = 0;
            this.txtChangeBy.SelectionStart = 0;
            this.txtChangeBy.Size = new System.Drawing.Size(100, 23);
            this.txtChangeBy.TabIndex = 5;
            this.txtChangeBy.UseSystemPasswordChar = false;
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(35, 144);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(115, 19);
            this.materialLabel1.TabIndex = 2;
            this.materialLabel1.Text = "Assumed Stock";
            // 
            // lblActualStock
            // 
            this.lblActualStock.AutoSize = true;
            this.lblActualStock.Depth = 0;
            this.lblActualStock.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblActualStock.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblActualStock.Location = new System.Drawing.Point(285, 144);
            this.lblActualStock.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblActualStock.Name = "lblActualStock";
            this.lblActualStock.Size = new System.Drawing.Size(95, 19);
            this.lblActualStock.TabIndex = 6;
            this.lblActualStock.Text = "Actual Stock";
            // 
            // lblActualStockValue
            // 
            this.lblActualStockValue.AutoSize = true;
            this.lblActualStockValue.Depth = 0;
            this.lblActualStockValue.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblActualStockValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblActualStockValue.Location = new System.Drawing.Point(402, 144);
            this.lblActualStockValue.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblActualStockValue.Name = "lblActualStockValue";
            this.lblActualStockValue.Size = new System.Drawing.Size(55, 19);
            this.lblActualStockValue.TabIndex = 7;
            this.lblActualStockValue.Text = "[Value]";
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Depth = 0;
            this.lblPrice.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblPrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblPrice.Location = new System.Drawing.Point(35, 234);
            this.lblPrice.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(43, 19);
            this.lblPrice.TabIndex = 8;
            this.lblPrice.Text = "Price";
            // 
            // txtPrice
            // 
            this.txtPrice.Depth = 0;
            this.txtPrice.Hint = "";
            this.txtPrice.Location = new System.Drawing.Point(185, 234);
            this.txtPrice.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.PasswordChar = '\0';
            this.txtPrice.SelectedText = "";
            this.txtPrice.SelectionLength = 0;
            this.txtPrice.SelectionStart = 0;
            this.txtPrice.Size = new System.Drawing.Size(100, 23);
            this.txtPrice.TabIndex = 9;
            this.txtPrice.Text = "0";
            this.txtPrice.UseSystemPasswordChar = false;
            // 
            // StockForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 293);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.lblActualStockValue);
            this.Controls.Add(this.lblActualStock);
            this.Controls.Add(this.txtChangeBy);
            this.Controls.Add(this.lblChange);
            this.Controls.Add(this.lblAssumedStockValue);
            this.Controls.Add(this.materialLabel1);
            this.Controls.Add(this.lblAssumedStock);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblItemName);
            this.Name = "StockForm";
            this.Text = "StockForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialLabel lblItemName;
        private System.Windows.Forms.Button btnSave;
        private MaterialSkin.Controls.MaterialLabel lblAssumedStock;
        private MaterialSkin.Controls.MaterialLabel lblAssumedStockValue;
        private MaterialSkin.Controls.MaterialLabel lblChange;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtChangeBy;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialLabel lblActualStock;
        private MaterialSkin.Controls.MaterialLabel lblActualStockValue;
        private MaterialSkin.Controls.MaterialLabel lblPrice;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtPrice;
    }
}