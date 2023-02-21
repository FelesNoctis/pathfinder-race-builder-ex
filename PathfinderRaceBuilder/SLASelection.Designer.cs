namespace PathfinderRaceBuilder
{
    partial class SLASelection
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.cbxSpellName = new System.Windows.Forms.ComboBox();
            this.lblSpellLevel = new System.Windows.Forms.Label();
            this.lblSpellDescription = new System.Windows.Forms.Label();
            this.ttpGeneric = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // cbxSpellName
            // 
            this.cbxSpellName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxSpellName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbxSpellName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbxSpellName.FormattingEnabled = true;
            this.cbxSpellName.Location = new System.Drawing.Point(3, 3);
            this.cbxSpellName.Name = "cbxSpellName";
            this.cbxSpellName.Size = new System.Drawing.Size(301, 21);
            this.cbxSpellName.TabIndex = 0;
            this.cbxSpellName.SelectedIndexChanged += new System.EventHandler(this.cbxSpellName_SelectedIndexChanged);
            // 
            // lblSpellLevel
            // 
            this.lblSpellLevel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSpellLevel.Location = new System.Drawing.Point(310, 3);
            this.lblSpellLevel.Name = "lblSpellLevel";
            this.lblSpellLevel.Size = new System.Drawing.Size(33, 21);
            this.lblSpellLevel.TabIndex = 1;
            this.lblSpellLevel.Text = "lvl X";
            this.lblSpellLevel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSpellLevel.Visible = false;
            // 
            // lblSpellDescription
            // 
            this.lblSpellDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSpellDescription.Location = new System.Drawing.Point(3, 27);
            this.lblSpellDescription.Name = "lblSpellDescription";
            this.lblSpellDescription.Size = new System.Drawing.Size(340, 21);
            this.lblSpellDescription.TabIndex = 2;
            this.lblSpellDescription.Text = "Spell Description Goes Here.";
            this.lblSpellDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblSpellDescription.Visible = false;
            // 
            // SLASelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.lblSpellDescription);
            this.Controls.Add(this.lblSpellLevel);
            this.Controls.Add(this.cbxSpellName);
            this.Name = "SLASelection";
            this.Size = new System.Drawing.Size(346, 52);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblSpellLevel;
        private System.Windows.Forms.Label lblSpellDescription;
        public System.Windows.Forms.ComboBox cbxSpellName;
        private System.Windows.Forms.ToolTip ttpGeneric;
    }
}
