namespace PathfinderRaceBuilder
{
    partial class FavoredTerrainRacialTraitForm
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
            this.cbxTerrainType = new System.Windows.Forms.ComboBox();
            this.lblTerrainDescription = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOkay = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cbxTerrainType
            // 
            this.cbxTerrainType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxTerrainType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxTerrainType.FormattingEnabled = true;
            this.cbxTerrainType.Location = new System.Drawing.Point(12, 12);
            this.cbxTerrainType.Name = "cbxTerrainType";
            this.cbxTerrainType.Size = new System.Drawing.Size(204, 21);
            this.cbxTerrainType.TabIndex = 0;
            this.cbxTerrainType.SelectedIndexChanged += new System.EventHandler(this.cbxTerrainType_SelectedIndexChanged);
            // 
            // lblTerrainDescription
            // 
            this.lblTerrainDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTerrainDescription.Location = new System.Drawing.Point(12, 40);
            this.lblTerrainDescription.Name = "lblTerrainDescription";
            this.lblTerrainDescription.Size = new System.Drawing.Size(204, 40);
            this.lblTerrainDescription.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(160, 83);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(56, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOkay
            // 
            this.btnOkay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOkay.Location = new System.Drawing.Point(98, 83);
            this.btnOkay.Name = "btnOkay";
            this.btnOkay.Size = new System.Drawing.Size(56, 23);
            this.btnOkay.TabIndex = 3;
            this.btnOkay.Text = "Ok";
            this.btnOkay.UseVisualStyleBackColor = true;
            this.btnOkay.Click += new System.EventHandler(this.btnOkay_Click);
            // 
            // FavoredTerrainRacialTraitForm
            // 
            this.AcceptButton = this.btnOkay;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(228, 118);
            this.ControlBox = false;
            this.Controls.Add(this.btnOkay);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblTerrainDescription);
            this.Controls.Add(this.cbxTerrainType);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FavoredTerrainRacialTraitForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Trait Settings";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbxTerrainType;
        private System.Windows.Forms.Label lblTerrainDescription;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOkay;
    }
}