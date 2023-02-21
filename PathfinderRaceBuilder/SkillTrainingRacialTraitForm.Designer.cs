namespace PathfinderRaceBuilder
{
    partial class SkillTrainingRacialTraitForm
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
            System.Windows.Forms.Label lblSelected;
            System.Windows.Forms.Label lblReminder;
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOkay = new System.Windows.Forms.Button();
            this.lstAvailable = new System.Windows.Forms.ListBox();
            this.lstSelected = new System.Windows.Forms.ListBox();
            this.ttpGeneric = new System.Windows.Forms.ToolTip(this.components);
            lblAvailable = new System.Windows.Forms.Label();
            lblSelected = new System.Windows.Forms.Label();
            lblReminder = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblAvailable
            // 
            lblAvailable.AutoSize = true;
            lblAvailable.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblAvailable.Location = new System.Drawing.Point(12, 9);
            lblAvailable.Name = "lblAvailable";
            lblAvailable.Size = new System.Drawing.Size(59, 13);
            lblAvailable.TabIndex = 4;
            lblAvailable.Text = "Available";
            // 
            // lblSelected
            // 
            lblSelected.AutoSize = true;
            lblSelected.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblSelected.Location = new System.Drawing.Point(178, 9);
            lblSelected.Name = "lblSelected";
            lblSelected.Size = new System.Drawing.Size(57, 13);
            lblSelected.TabIndex = 6;
            lblSelected.Text = "Selected";
            // 
            // lblReminder
            // 
            lblReminder.ForeColor = System.Drawing.SystemColors.GrayText;
            lblReminder.Location = new System.Drawing.Point(181, 58);
            lblReminder.Name = "lblReminder";
            lblReminder.Size = new System.Drawing.Size(160, 35);
            lblReminder.TabIndex = 8;
            lblReminder.Text = "Double click an item to transfer it between lists.";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(285, 208);
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
            this.btnOkay.Location = new System.Drawing.Point(223, 208);
            this.btnOkay.Name = "btnOkay";
            this.btnOkay.Size = new System.Drawing.Size(56, 23);
            this.btnOkay.TabIndex = 3;
            this.btnOkay.Text = "Ok";
            this.btnOkay.UseVisualStyleBackColor = true;
            this.btnOkay.Click += new System.EventHandler(this.btnOkay_Click);
            // 
            // lstAvailable
            // 
            this.lstAvailable.FormattingEnabled = true;
            this.lstAvailable.Location = new System.Drawing.Point(12, 25);
            this.lstAvailable.Name = "lstAvailable";
            this.lstAvailable.Size = new System.Drawing.Size(160, 173);
            this.lstAvailable.Sorted = true;
            this.lstAvailable.TabIndex = 5;
            this.ttpGeneric.SetToolTip(this.lstAvailable, "Double click a skill to add it to the selected skills.");
            this.lstAvailable.DoubleClick += new System.EventHandler(this.lstAvailable_DoubleClick);
            // 
            // lstSelected
            // 
            this.lstSelected.FormattingEnabled = true;
            this.lstSelected.Location = new System.Drawing.Point(181, 25);
            this.lstSelected.Name = "lstSelected";
            this.lstSelected.Size = new System.Drawing.Size(160, 30);
            this.lstSelected.Sorted = true;
            this.lstSelected.TabIndex = 7;
            this.ttpGeneric.SetToolTip(this.lstSelected, "Double click a skill to remove it from the selected skills.");
            this.lstSelected.DoubleClick += new System.EventHandler(this.lstSelected_DoubleClick);
            // 
            // SkillTrainingRacialTraitForm
            // 
            this.AcceptButton = this.btnOkay;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(353, 243);
            this.ControlBox = false;
            this.Controls.Add(lblReminder);
            this.Controls.Add(this.lstSelected);
            this.Controls.Add(lblSelected);
            this.Controls.Add(this.lstAvailable);
            this.Controls.Add(lblAvailable);
            this.Controls.Add(this.btnOkay);
            this.Controls.Add(this.btnCancel);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SkillTrainingRacialTraitForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Skill Training Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOkay;
        private System.Windows.Forms.ListBox lstAvailable;
        private System.Windows.Forms.ListBox lstSelected;
        private System.Windows.Forms.ToolTip ttpGeneric;
    }
}