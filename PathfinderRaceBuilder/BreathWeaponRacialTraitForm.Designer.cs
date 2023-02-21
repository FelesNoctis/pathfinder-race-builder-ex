namespace PathfinderRaceBuilder
{
    partial class BreathWeaponRacialTraitForm
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
            System.Windows.Forms.Label lblDamageType;
            System.Windows.Forms.Label lblArea;
            System.Windows.Forms.Label lblExtraTimes;
            System.Windows.Forms.Label lblIncreasedDamage;
            System.Windows.Forms.Label label1;
            this.btnOkay = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.cbxDamageType = new System.Windows.Forms.ComboBox();
            this.cbxArea = new System.Windows.Forms.ComboBox();
            this.nudExtraTimes = new System.Windows.Forms.NumericUpDown();
            this.nudIncreasedDamage = new System.Windows.Forms.NumericUpDown();
            this.chkPowerful = new System.Windows.Forms.CheckBox();
            lblDamageType = new System.Windows.Forms.Label();
            lblArea = new System.Windows.Forms.Label();
            lblExtraTimes = new System.Windows.Forms.Label();
            lblIncreasedDamage = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudExtraTimes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudIncreasedDamage)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDamageType
            // 
            lblDamageType.AutoSize = true;
            lblDamageType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblDamageType.Location = new System.Drawing.Point(12, 15);
            lblDamageType.Name = "lblDamageType";
            lblDamageType.Size = new System.Drawing.Size(89, 13);
            lblDamageType.TabIndex = 5;
            lblDamageType.Text = "Damage Type:";
            // 
            // lblArea
            // 
            lblArea.AutoSize = true;
            lblArea.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblArea.Location = new System.Drawing.Point(64, 42);
            lblArea.Name = "lblArea";
            lblArea.Size = new System.Drawing.Size(37, 13);
            lblArea.TabIndex = 8;
            lblArea.Text = "Area:";
            // 
            // lblExtraTimes
            // 
            lblExtraTimes.AutoSize = true;
            lblExtraTimes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblExtraTimes.Location = new System.Drawing.Point(217, 15);
            lblExtraTimes.Name = "lblExtraTimes";
            lblExtraTimes.Size = new System.Drawing.Size(126, 13);
            lblExtraTimes.TabIndex = 9;
            lblExtraTimes.Text = "Extra Times Per Day:";
            // 
            // lblIncreasedDamage
            // 
            lblIncreasedDamage.AutoSize = true;
            lblIncreasedDamage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblIncreasedDamage.Location = new System.Drawing.Point(226, 42);
            lblIncreasedDamage.Name = "lblIncreasedDamage";
            lblIncreasedDamage.Size = new System.Drawing.Size(117, 13);
            lblIncreasedDamage.TabIndex = 10;
            lblIncreasedDamage.Text = "Increased Damage:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label1.Location = new System.Drawing.Point(208, 69);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(135, 13);
            label1.TabIndex = 14;
            label1.Text = "Half Damage on Save:";
            // 
            // btnOkay
            // 
            this.btnOkay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOkay.Location = new System.Drawing.Point(266, 108);
            this.btnOkay.Name = "btnOkay";
            this.btnOkay.Size = new System.Drawing.Size(56, 23);
            this.btnOkay.TabIndex = 4;
            this.btnOkay.Text = "Ok";
            this.btnOkay.UseVisualStyleBackColor = true;
            this.btnOkay.Click += new System.EventHandler(this.btnOkay_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(328, 108);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(56, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // cbxDamageType
            // 
            this.cbxDamageType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxDamageType.FormattingEnabled = true;
            this.cbxDamageType.Items.AddRange(new object[] {
            "Acid",
            "Cold",
            "Electricity",
            "Fire"});
            this.cbxDamageType.Location = new System.Drawing.Point(107, 12);
            this.cbxDamageType.Name = "cbxDamageType";
            this.cbxDamageType.Size = new System.Drawing.Size(104, 21);
            this.cbxDamageType.TabIndex = 6;
            this.cbxDamageType.SelectedIndexChanged += new System.EventHandler(this.cbxDamageType_SelectedIndexChanged);
            // 
            // cbxArea
            // 
            this.cbxArea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxArea.FormattingEnabled = true;
            this.cbxArea.Location = new System.Drawing.Point(107, 39);
            this.cbxArea.Name = "cbxArea";
            this.cbxArea.Size = new System.Drawing.Size(104, 21);
            this.cbxArea.TabIndex = 7;
            this.cbxArea.SelectedIndexChanged += new System.EventHandler(this.cbxArea_SelectedIndexChanged);
            // 
            // nudExtraTimes
            // 
            this.nudExtraTimes.Location = new System.Drawing.Point(349, 13);
            this.nudExtraTimes.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.nudExtraTimes.Name = "nudExtraTimes";
            this.nudExtraTimes.Size = new System.Drawing.Size(30, 20);
            this.nudExtraTimes.TabIndex = 11;
            this.nudExtraTimes.ValueChanged += new System.EventHandler(this.nudExtraTimes_ValueChanged);
            // 
            // nudIncreasedDamage
            // 
            this.nudIncreasedDamage.Location = new System.Drawing.Point(349, 39);
            this.nudIncreasedDamage.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.nudIncreasedDamage.Name = "nudIncreasedDamage";
            this.nudIncreasedDamage.Size = new System.Drawing.Size(30, 20);
            this.nudIncreasedDamage.TabIndex = 12;
            this.nudIncreasedDamage.ValueChanged += new System.EventHandler(this.nudIncreasedDamage_ValueChanged);
            // 
            // chkPowerful
            // 
            this.chkPowerful.AutoSize = true;
            this.chkPowerful.Location = new System.Drawing.Point(356, 69);
            this.chkPowerful.Name = "chkPowerful";
            this.chkPowerful.Size = new System.Drawing.Size(15, 14);
            this.chkPowerful.TabIndex = 13;
            this.chkPowerful.UseVisualStyleBackColor = true;
            this.chkPowerful.CheckedChanged += new System.EventHandler(this.chkPowerful_CheckedChanged);
            // 
            // BreathWeaponRacialTraitForm
            // 
            this.AcceptButton = this.btnOkay;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(396, 143);
            this.ControlBox = false;
            this.Controls.Add(label1);
            this.Controls.Add(this.chkPowerful);
            this.Controls.Add(this.nudIncreasedDamage);
            this.Controls.Add(this.nudExtraTimes);
            this.Controls.Add(lblIncreasedDamage);
            this.Controls.Add(lblExtraTimes);
            this.Controls.Add(lblArea);
            this.Controls.Add(this.cbxArea);
            this.Controls.Add(this.cbxDamageType);
            this.Controls.Add(lblDamageType);
            this.Controls.Add(this.btnOkay);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BreathWeaponRacialTraitForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Breath Weapon Settings";
            ((System.ComponentModel.ISupportInitialize)(this.nudExtraTimes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudIncreasedDamage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOkay;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ComboBox cbxDamageType;
        private System.Windows.Forms.ComboBox cbxArea;
        private System.Windows.Forms.NumericUpDown nudExtraTimes;
        private System.Windows.Forms.NumericUpDown nudIncreasedDamage;
        private System.Windows.Forms.CheckBox chkPowerful;
    }
}