namespace EveTransactions
{
    partial class EveItemForm
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
            this.lblTargetStock = new MaterialSkin.Controls.MaterialLabel();
            this.chkTrackPrices = new System.Windows.Forms.CheckBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtTargetStock = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.SuspendLayout();
            // 
            // lblItemName
            // 
            this.lblItemName.AutoSize = true;
            this.lblItemName.Depth = 0;
            this.lblItemName.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblItemName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblItemName.Location = new System.Drawing.Point(25, 88);
            this.lblItemName.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblItemName.Name = "lblItemName";
            this.lblItemName.Size = new System.Drawing.Size(91, 19);
            this.lblItemName.TabIndex = 0;
            this.lblItemName.Text = "[Item Name]";
            // 
            // lblTargetStock
            // 
            this.lblTargetStock.AutoSize = true;
            this.lblTargetStock.Depth = 0;
            this.lblTargetStock.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblTargetStock.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTargetStock.Location = new System.Drawing.Point(28, 138);
            this.lblTargetStock.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblTargetStock.Name = "lblTargetStock";
            this.lblTargetStock.Size = new System.Drawing.Size(95, 19);
            this.lblTargetStock.TabIndex = 1;
            this.lblTargetStock.Text = "Target Stock";
            // 
            // chkTrackPrices
            // 
            this.chkTrackPrices.AutoSize = true;
            this.chkTrackPrices.Location = new System.Drawing.Point(301, 138);
            this.chkTrackPrices.Name = "chkTrackPrices";
            this.chkTrackPrices.Size = new System.Drawing.Size(86, 17);
            this.chkTrackPrices.TabIndex = 3;
            this.chkTrackPrices.Text = "Track Prices";
            this.chkTrackPrices.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(407, 137);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(104, 23);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtTargetStock
            // 
            this.txtTargetStock.Depth = 0;
            this.txtTargetStock.Hint = "";
            this.txtTargetStock.Location = new System.Drawing.Point(143, 138);
            this.txtTargetStock.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtTargetStock.Name = "txtTargetStock";
            this.txtTargetStock.PasswordChar = '\0';
            this.txtTargetStock.SelectedText = "";
            this.txtTargetStock.SelectionLength = 0;
            this.txtTargetStock.SelectionStart = 0;
            this.txtTargetStock.Size = new System.Drawing.Size(136, 23);
            this.txtTargetStock.TabIndex = 13;
            this.txtTargetStock.Text = "100";
            this.txtTargetStock.UseSystemPasswordChar = false;
            // 
            // EveItemForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(547, 193);
            this.Controls.Add(this.txtTargetStock);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.chkTrackPrices);
            this.Controls.Add(this.lblTargetStock);
            this.Controls.Add(this.lblItemName);
            this.Name = "EveItemForm";
            this.Text = "Item Details";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialLabel lblItemName;
        private MaterialSkin.Controls.MaterialLabel lblTargetStock;
        private System.Windows.Forms.CheckBox chkTrackPrices;
        private System.Windows.Forms.Button btnSave;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtTargetStock;
    }
}