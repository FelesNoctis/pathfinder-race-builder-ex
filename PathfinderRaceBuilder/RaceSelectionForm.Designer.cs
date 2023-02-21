namespace PathfinderRaceBuilder
{
    partial class RaceSelectionForm
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
            this.cbxSelectedRace = new System.Windows.Forms.ComboBox();
            this.btnOkay = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.dudFilterSelection = new System.Windows.Forms.DomainUpDown();
            this.SuspendLayout();
            // 
            // cbxSelectedRace
            // 
            this.cbxSelectedRace.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxSelectedRace.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSelectedRace.FormattingEnabled = true;
            this.cbxSelectedRace.Location = new System.Drawing.Point(12, 12);
            this.cbxSelectedRace.Name = "cbxSelectedRace";
            this.cbxSelectedRace.Size = new System.Drawing.Size(272, 21);
            this.cbxSelectedRace.TabIndex = 0;
            this.cbxSelectedRace.SelectedIndexChanged += new System.EventHandler(this.cbxSelectedRace_SelectedIndexChanged);
            // 
            // btnOkay
            // 
            this.btnOkay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOkay.Enabled = false;
            this.btnOkay.Location = new System.Drawing.Point(166, 43);
            this.btnOkay.Name = "btnOkay";
            this.btnOkay.Size = new System.Drawing.Size(56, 23);
            this.btnOkay.TabIndex = 3;
            this.btnOkay.Text = "Ok";
            this.btnOkay.UseVisualStyleBackColor = true;
            this.btnOkay.Click += new System.EventHandler(this.btnOkay_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(228, 43);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(56, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnNew
            // 
            this.btnNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnNew.Location = new System.Drawing.Point(12, 43);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(56, 23);
            this.btnNew.TabIndex = 1;
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // dudFilterSelection
            // 
            this.dudFilterSelection.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dudFilterSelection.Items.Add("Show All");
            this.dudFilterSelection.Items.Add("Custom Only");
            this.dudFilterSelection.Items.Add("Paizo Only");
            this.dudFilterSelection.Location = new System.Drawing.Point(74, 44);
            this.dudFilterSelection.Name = "dudFilterSelection";
            this.dudFilterSelection.Size = new System.Drawing.Size(86, 20);
            this.dudFilterSelection.TabIndex = 2;
            this.dudFilterSelection.Text = "Show All";
            this.dudFilterSelection.Wrap = true;
            this.dudFilterSelection.SelectedItemChanged += new System.EventHandler(this.dudFilterSelection_SelectedItemChanged);
            // 
            // RaceSelectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(296, 70);
            this.ControlBox = false;
            this.Controls.Add(this.dudFilterSelection);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOkay);
            this.Controls.Add(this.cbxSelectedRace);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RaceSelectionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Select Race";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOkay;
        public System.Windows.Forms.Button btnCancel;
        public System.Windows.Forms.ComboBox cbxSelectedRace;
        public System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.DomainUpDown dudFilterSelection;
    }
}