namespace PathfinderRaceBuilder
{
    partial class RaceDeletionForm
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
            System.Windows.Forms.Label lblAvailableRaces;
            System.Windows.Forms.Label lblSelectedRaces;
            System.Windows.Forms.Label lblReminder;
            this.lstAvailableRaces = new System.Windows.Forms.ListBox();
            this.lstSelectedRaces = new System.Windows.Forms.ListBox();
            this.btnOkay = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            lblAvailableRaces = new System.Windows.Forms.Label();
            lblSelectedRaces = new System.Windows.Forms.Label();
            lblReminder = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lstAvailableRaces
            // 
            this.lstAvailableRaces.FormattingEnabled = true;
            this.lstAvailableRaces.Location = new System.Drawing.Point(12, 25);
            this.lstAvailableRaces.Name = "lstAvailableRaces";
            this.lstAvailableRaces.Size = new System.Drawing.Size(194, 212);
            this.lstAvailableRaces.TabIndex = 0;
            this.lstAvailableRaces.DoubleClick += new System.EventHandler(this.lstAvailableRaces_DoubleClick);
            // 
            // lblAvailableRaces
            // 
            lblAvailableRaces.AutoSize = true;
            lblAvailableRaces.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblAvailableRaces.Location = new System.Drawing.Point(13, 9);
            lblAvailableRaces.Name = "lblAvailableRaces";
            lblAvailableRaces.Size = new System.Drawing.Size(99, 13);
            lblAvailableRaces.TabIndex = 1;
            lblAvailableRaces.Text = "Available Races";
            // 
            // lblSelectedRaces
            // 
            lblSelectedRaces.AutoSize = true;
            lblSelectedRaces.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblSelectedRaces.Location = new System.Drawing.Point(209, 9);
            lblSelectedRaces.Name = "lblSelectedRaces";
            lblSelectedRaces.Size = new System.Drawing.Size(167, 13);
            lblSelectedRaces.TabIndex = 3;
            lblSelectedRaces.Text = "Races Selected for Deletion";
            // 
            // lstSelectedRaces
            // 
            this.lstSelectedRaces.FormattingEnabled = true;
            this.lstSelectedRaces.Location = new System.Drawing.Point(212, 25);
            this.lstSelectedRaces.Name = "lstSelectedRaces";
            this.lstSelectedRaces.Size = new System.Drawing.Size(194, 212);
            this.lstSelectedRaces.TabIndex = 2;
            this.lstSelectedRaces.DoubleClick += new System.EventHandler(this.lstSelectedRaces_DoubleClick);
            // 
            // lblReminder
            // 
            lblReminder.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblReminder.ForeColor = System.Drawing.SystemColors.GrayText;
            lblReminder.Location = new System.Drawing.Point(12, 240);
            lblReminder.Name = "lblReminder";
            lblReminder.Size = new System.Drawing.Size(269, 24);
            lblReminder.TabIndex = 11;
            lblReminder.Text = "Double click an item to transfer it between lists.";
            // 
            // btnOkay
            // 
            this.btnOkay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOkay.Enabled = false;
            this.btnOkay.Location = new System.Drawing.Point(287, 243);
            this.btnOkay.Name = "btnOkay";
            this.btnOkay.Size = new System.Drawing.Size(56, 23);
            this.btnOkay.TabIndex = 10;
            this.btnOkay.Text = "Ok";
            this.btnOkay.UseVisualStyleBackColor = true;
            this.btnOkay.Click += new System.EventHandler(this.btnOkay_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(349, 243);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(56, 23);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // RaceDeletionForm
            // 
            this.AcceptButton = this.btnOkay;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(417, 273);
            this.ControlBox = false;
            this.Controls.Add(lblReminder);
            this.Controls.Add(this.btnOkay);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(lblSelectedRaces);
            this.Controls.Add(this.lstSelectedRaces);
            this.Controls.Add(lblAvailableRaces);
            this.Controls.Add(this.lstAvailableRaces);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RaceDeletionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Race Deletion";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstAvailableRaces;
        private System.Windows.Forms.Button btnOkay;
        private System.Windows.Forms.Button btnCancel;
        public System.Windows.Forms.ListBox lstSelectedRaces;
    }
}