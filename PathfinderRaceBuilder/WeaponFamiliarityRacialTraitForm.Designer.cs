namespace PathfinderRaceBuilder
{
    partial class WeaponFamiliarityRacialTraitForm
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
            System.Windows.Forms.Label lblAvailable;
            this.lblReminder = new System.Windows.Forms.Label();
            this.lblSelected = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOkay = new System.Windows.Forms.Button();
            this.lstAvailableWeapons = new System.Windows.Forms.ListBox();
            this.lstSelectedWeapons = new System.Windows.Forms.ListBox();
            this.ttpGeneric = new System.Windows.Forms.ToolTip(this.components);
            lblAvailable = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblAvailable
            // 
            lblAvailable.AutoSize = true;
            lblAvailable.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblAvailable.Location = new System.Drawing.Point(12, 9);
            lblAvailable.Name = "lblAvailable";
            lblAvailable.Size = new System.Drawing.Size(59, 13);
            lblAvailable.TabIndex = 2;
            lblAvailable.Text = "Available";
            // 
            // lblReminder
            // 
            this.lblReminder.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lblReminder.Location = new System.Drawing.Point(196, 110);
            this.lblReminder.Name = "lblReminder";
            this.lblReminder.Size = new System.Drawing.Size(178, 34);
            this.lblReminder.TabIndex = 8;
            this.lblReminder.Text = "Double click an item to transfer it between lists.";
            // 
            // lblSelected
            // 
            this.lblSelected.AutoSize = true;
            this.lblSelected.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelected.Location = new System.Drawing.Point(193, 9);
            this.lblSelected.Name = "lblSelected";
            this.lblSelected.Size = new System.Drawing.Size(57, 13);
            this.lblSelected.TabIndex = 6;
            this.lblSelected.Text = "Selected";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(320, 312);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(56, 23);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOkay
            // 
            this.btnOkay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOkay.Location = new System.Drawing.Point(258, 312);
            this.btnOkay.Name = "btnOkay";
            this.btnOkay.Size = new System.Drawing.Size(56, 23);
            this.btnOkay.TabIndex = 1;
            this.btnOkay.Text = "Ok";
            this.btnOkay.UseVisualStyleBackColor = true;
            this.btnOkay.Click += new System.EventHandler(this.btnOkay_Click);
            // 
            // lstAvailableWeapons
            // 
            this.lstAvailableWeapons.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lstAvailableWeapons.FormattingEnabled = true;
            this.lstAvailableWeapons.Location = new System.Drawing.Point(12, 25);
            this.lstAvailableWeapons.Name = "lstAvailableWeapons";
            this.lstAvailableWeapons.Size = new System.Drawing.Size(178, 264);
            this.lstAvailableWeapons.Sorted = true;
            this.lstAvailableWeapons.TabIndex = 3;
            this.ttpGeneric.SetToolTip(this.lstAvailableWeapons, "Double click an item to add it to the selected items.");
            this.lstAvailableWeapons.DoubleClick += new System.EventHandler(this.lstAvailableWeapons_DoubleClick);
            this.lstAvailableWeapons.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lstAvailableWeapons_MouseMove);
            // 
            // lstSelectedWeapons
            // 
            this.lstSelectedWeapons.FormattingEnabled = true;
            this.lstSelectedWeapons.Location = new System.Drawing.Point(196, 25);
            this.lstSelectedWeapons.Name = "lstSelectedWeapons";
            this.lstSelectedWeapons.Size = new System.Drawing.Size(178, 82);
            this.lstSelectedWeapons.Sorted = true;
            this.lstSelectedWeapons.TabIndex = 7;
            this.ttpGeneric.SetToolTip(this.lstSelectedWeapons, "Double click an item to remove it from the selected items.");
            this.lstSelectedWeapons.DoubleClick += new System.EventHandler(this.lstSelectedWeapons_DoubleClick);
            // 
            // WeaponFamiliarityRacialTraitForm
            // 
            this.AcceptButton = this.btnOkay;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(388, 347);
            this.ControlBox = false;
            this.Controls.Add(this.lblReminder);
            this.Controls.Add(this.lstSelectedWeapons);
            this.Controls.Add(this.lblSelected);
            this.Controls.Add(this.lstAvailableWeapons);
            this.Controls.Add(lblAvailable);
            this.Controls.Add(this.btnOkay);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WeaponFamiliarityRacialTraitForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Weapon Familiarity Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOkay;
        private System.Windows.Forms.ListBox lstAvailableWeapons;
        private System.Windows.Forms.ListBox lstSelectedWeapons;
        private System.Windows.Forms.Label lblSelected;
        private System.Windows.Forms.ToolTip ttpGeneric;
        private System.Windows.Forms.Label lblReminder;
    }
}