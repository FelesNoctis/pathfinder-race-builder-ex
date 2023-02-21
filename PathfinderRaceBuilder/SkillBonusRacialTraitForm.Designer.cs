namespace PathfinderRaceBuilder
{
    partial class SkillBonusRacialTraitForm
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
            System.Windows.Forms.Label lbl2Bonus;
            System.Windows.Forms.Label lbl1Bonus;
            System.Windows.Forms.Label lblReminder;
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lstAvailable = new System.Windows.Forms.ListBox();
            this.lstFullBonus = new System.Windows.Forms.ListBox();
            this.lstHalfBonus = new System.Windows.Forms.ListBox();
            this.ttpGeneric = new System.Windows.Forms.ToolTip(this.components);
            lblAvailable = new System.Windows.Forms.Label();
            lbl2Bonus = new System.Windows.Forms.Label();
            lbl1Bonus = new System.Windows.Forms.Label();
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
            lblAvailable.TabIndex = 3;
            lblAvailable.Text = "Available";
            // 
            // lbl2Bonus
            // 
            lbl2Bonus.AutoSize = true;
            lbl2Bonus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lbl2Bonus.Location = new System.Drawing.Point(178, 9);
            lbl2Bonus.Name = "lbl2Bonus";
            lbl2Bonus.Size = new System.Drawing.Size(60, 13);
            lbl2Bonus.TabIndex = 6;
            lbl2Bonus.Text = "+2 Bonus";
            // 
            // lbl1Bonus
            // 
            lbl1Bonus.AutoSize = true;
            lbl1Bonus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lbl1Bonus.Location = new System.Drawing.Point(178, 71);
            lbl1Bonus.Name = "lbl1Bonus";
            lbl1Bonus.Size = new System.Drawing.Size(60, 13);
            lbl1Bonus.TabIndex = 8;
            lbl1Bonus.Text = "+1 Bonus";
            // 
            // lblReminder
            // 
            lblReminder.AutoSize = true;
            lblReminder.ForeColor = System.Drawing.SystemColors.GrayText;
            lblReminder.Location = new System.Drawing.Point(12, 175);
            lblReminder.Name = "lblReminder";
            lblReminder.Size = new System.Drawing.Size(179, 13);
            lblReminder.TabIndex = 9;
            lblReminder.Text = "Drag items into the desired category.";
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Enabled = false;
            this.btnOK.Location = new System.Drawing.Point(222, 197);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(56, 23);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "Ok";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(284, 197);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(56, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lstAvailable
            // 
            this.lstAvailable.AllowDrop = true;
            this.lstAvailable.FormattingEnabled = true;
            this.lstAvailable.Location = new System.Drawing.Point(12, 25);
            this.lstAvailable.Name = "lstAvailable";
            this.lstAvailable.Size = new System.Drawing.Size(160, 147);
            this.lstAvailable.Sorted = true;
            this.lstAvailable.TabIndex = 4;
            this.ttpGeneric.SetToolTip(this.lstAvailable, "Drag items into the desired category.");
            this.lstAvailable.DragDrop += new System.Windows.Forms.DragEventHandler(this.ListBoxDragDrop);
            this.lstAvailable.DragEnter += new System.Windows.Forms.DragEventHandler(this.ListBoxDragEnter);
            this.lstAvailable.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BeginListBoxDrag);
            // 
            // lstFullBonus
            // 
            this.lstFullBonus.AllowDrop = true;
            this.lstFullBonus.FormattingEnabled = true;
            this.lstFullBonus.Location = new System.Drawing.Point(178, 25);
            this.lstFullBonus.Name = "lstFullBonus";
            this.lstFullBonus.Size = new System.Drawing.Size(160, 43);
            this.lstFullBonus.Sorted = true;
            this.lstFullBonus.TabIndex = 5;
            this.ttpGeneric.SetToolTip(this.lstFullBonus, "Drag items into the desired category.");
            this.lstFullBonus.DragDrop += new System.Windows.Forms.DragEventHandler(this.ListBoxDragDrop);
            this.lstFullBonus.DragEnter += new System.Windows.Forms.DragEventHandler(this.ListBoxDragEnter);
            this.lstFullBonus.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BeginListBoxDrag);
            // 
            // lstHalfBonus
            // 
            this.lstHalfBonus.AllowDrop = true;
            this.lstHalfBonus.FormattingEnabled = true;
            this.lstHalfBonus.Location = new System.Drawing.Point(178, 90);
            this.lstHalfBonus.Name = "lstHalfBonus";
            this.lstHalfBonus.Size = new System.Drawing.Size(161, 82);
            this.lstHalfBonus.Sorted = true;
            this.lstHalfBonus.TabIndex = 7;
            this.ttpGeneric.SetToolTip(this.lstHalfBonus, "Drag items into the desired category.");
            this.lstHalfBonus.DragDrop += new System.Windows.Forms.DragEventHandler(this.ListBoxDragDrop);
            this.lstHalfBonus.DragEnter += new System.Windows.Forms.DragEventHandler(this.ListBoxDragEnter);
            this.lstHalfBonus.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BeginListBoxDrag);
            // 
            // SkillBonusRacialTraitForm
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(352, 232);
            this.ControlBox = false;
            this.Controls.Add(lblReminder);
            this.Controls.Add(lbl1Bonus);
            this.Controls.Add(this.lstHalfBonus);
            this.Controls.Add(lbl2Bonus);
            this.Controls.Add(this.lstFullBonus);
            this.Controls.Add(this.lstAvailable);
            this.Controls.Add(lblAvailable);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SkillBonusRacialTraitForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Skill Bonus Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ListBox lstAvailable;
        private System.Windows.Forms.ListBox lstFullBonus;
        private System.Windows.Forms.ListBox lstHalfBonus;
        private System.Windows.Forms.ToolTip ttpGeneric;
    }
}