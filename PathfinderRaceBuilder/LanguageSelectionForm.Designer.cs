namespace PathfinderRaceBuilder
{
    partial class LanguageSelectionForm
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
            System.Windows.Forms.Label lblRacialLanguages;
            System.Windows.Forms.Label lblOptionalLanguages;
            System.Windows.Forms.Label lblReminder;
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOkay = new System.Windows.Forms.Button();
            this.lstRacialLanguages = new System.Windows.Forms.ListBox();
            this.lstOptionalLanguages = new System.Windows.Forms.ListBox();
            this.lstAvailableLanguages = new System.Windows.Forms.ListBox();
            this.ttpGeneric = new System.Windows.Forms.ToolTip(this.components);
            lblAvailable = new System.Windows.Forms.Label();
            lblRacialLanguages = new System.Windows.Forms.Label();
            lblOptionalLanguages = new System.Windows.Forms.Label();
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
            lblAvailable.TabIndex = 2;
            lblAvailable.Text = "Available";
            // 
            // lblRacialLanguages
            // 
            lblRacialLanguages.AutoSize = true;
            lblRacialLanguages.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblRacialLanguages.Location = new System.Drawing.Point(140, 9);
            lblRacialLanguages.Name = "lblRacialLanguages";
            lblRacialLanguages.Size = new System.Drawing.Size(43, 13);
            lblRacialLanguages.TabIndex = 6;
            lblRacialLanguages.Text = "Racial";
            // 
            // lblOptionalLanguages
            // 
            lblOptionalLanguages.AutoSize = true;
            lblOptionalLanguages.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblOptionalLanguages.Location = new System.Drawing.Point(138, 74);
            lblOptionalLanguages.Name = "lblOptionalLanguages";
            lblOptionalLanguages.Size = new System.Drawing.Size(54, 13);
            lblOptionalLanguages.TabIndex = 7;
            lblOptionalLanguages.Text = "Optional";
            // 
            // lblReminder
            // 
            lblReminder.AutoSize = true;
            lblReminder.ForeColor = System.Drawing.SystemColors.GrayText;
            lblReminder.Location = new System.Drawing.Point(12, 214);
            lblReminder.Name = "lblReminder";
            lblReminder.Size = new System.Drawing.Size(179, 13);
            lblReminder.TabIndex = 10;
            lblReminder.Text = "Drag items into the desired category.";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(205, 237);
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
            this.btnOkay.Enabled = false;
            this.btnOkay.Location = new System.Drawing.Point(143, 237);
            this.btnOkay.Name = "btnOkay";
            this.btnOkay.Size = new System.Drawing.Size(56, 23);
            this.btnOkay.TabIndex = 1;
            this.btnOkay.Text = "Ok";
            this.btnOkay.UseVisualStyleBackColor = true;
            this.btnOkay.Click += new System.EventHandler(this.btnOkay_Click);
            // 
            // lstRacialLanguages
            // 
            this.lstRacialLanguages.AllowDrop = true;
            this.lstRacialLanguages.FormattingEnabled = true;
            this.lstRacialLanguages.Location = new System.Drawing.Point(138, 25);
            this.lstRacialLanguages.Name = "lstRacialLanguages";
            this.lstRacialLanguages.Size = new System.Drawing.Size(120, 43);
            this.lstRacialLanguages.Sorted = true;
            this.lstRacialLanguages.TabIndex = 5;
            this.ttpGeneric.SetToolTip(this.lstRacialLanguages, "Drag items into the desired category.");
            this.lstRacialLanguages.DragDrop += new System.Windows.Forms.DragEventHandler(this.ListBoxDragDrop);
            this.lstRacialLanguages.DragEnter += new System.Windows.Forms.DragEventHandler(this.ListBoxDragEnter);
            this.lstRacialLanguages.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BeginListBoxDrag);
            // 
            // lstOptionalLanguages
            // 
            this.lstOptionalLanguages.AllowDrop = true;
            this.lstOptionalLanguages.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstOptionalLanguages.FormattingEnabled = true;
            this.lstOptionalLanguages.Location = new System.Drawing.Point(138, 90);
            this.lstOptionalLanguages.Name = "lstOptionalLanguages";
            this.lstOptionalLanguages.Size = new System.Drawing.Size(120, 121);
            this.lstOptionalLanguages.Sorted = true;
            this.lstOptionalLanguages.TabIndex = 8;
            this.ttpGeneric.SetToolTip(this.lstOptionalLanguages, "Drag items into the desired category.");
            this.lstOptionalLanguages.DragDrop += new System.Windows.Forms.DragEventHandler(this.ListBoxDragDrop);
            this.lstOptionalLanguages.DragEnter += new System.Windows.Forms.DragEventHandler(this.ListBoxDragEnter);
            this.lstOptionalLanguages.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BeginListBoxDrag);
            // 
            // lstAvailableLanguages
            // 
            this.lstAvailableLanguages.AllowDrop = true;
            this.lstAvailableLanguages.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lstAvailableLanguages.FormattingEnabled = true;
            this.lstAvailableLanguages.Location = new System.Drawing.Point(12, 25);
            this.lstAvailableLanguages.Name = "lstAvailableLanguages";
            this.lstAvailableLanguages.Size = new System.Drawing.Size(120, 186);
            this.lstAvailableLanguages.Sorted = true;
            this.lstAvailableLanguages.TabIndex = 9;
            this.ttpGeneric.SetToolTip(this.lstAvailableLanguages, "Drag items into the desired category.");
            this.lstAvailableLanguages.DragDrop += new System.Windows.Forms.DragEventHandler(this.ListBoxDragDrop);
            this.lstAvailableLanguages.DragEnter += new System.Windows.Forms.DragEventHandler(this.ListBoxDragEnter);
            this.lstAvailableLanguages.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BeginListBoxDrag);
            // 
            // LanguageSelectionForm
            // 
            this.AcceptButton = this.btnOkay;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(273, 272);
            this.ControlBox = false;
            this.Controls.Add(lblReminder);
            this.Controls.Add(this.lstAvailableLanguages);
            this.Controls.Add(this.lstOptionalLanguages);
            this.Controls.Add(lblOptionalLanguages);
            this.Controls.Add(lblRacialLanguages);
            this.Controls.Add(this.lstRacialLanguages);
            this.Controls.Add(lblAvailable);
            this.Controls.Add(this.btnOkay);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LanguageSelectionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Language Selection";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOkay;
        private System.Windows.Forms.ListBox lstRacialLanguages;
        private System.Windows.Forms.ListBox lstOptionalLanguages;
        private System.Windows.Forms.ListBox lstAvailableLanguages;
        private System.Windows.Forms.ToolTip ttpGeneric;
    }
}