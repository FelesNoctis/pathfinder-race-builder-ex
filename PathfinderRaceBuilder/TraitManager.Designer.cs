namespace PathfinderRaceBuilder
{
    partial class TraitManager
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
            System.Windows.Forms.PictureBox pbxDivider;
            this.lblTraitDisplay = new System.Windows.Forms.Label();
            this.btnSettings = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.lblPoints = new System.Windows.Forms.Label();
            pbxDivider = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(pbxDivider)).BeginInit();
            this.SuspendLayout();
            // 
            // pbxDivider
            // 
            pbxDivider.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            pbxDivider.BackColor = System.Drawing.SystemColors.ControlDark;
            pbxDivider.ErrorImage = null;
            pbxDivider.InitialImage = null;
            pbxDivider.Location = new System.Drawing.Point(0, 51);
            pbxDivider.Name = "pbxDivider";
            pbxDivider.Size = new System.Drawing.Size(253, 1);
            pbxDivider.TabIndex = 4;
            pbxDivider.TabStop = false;
            // 
            // lblTraitDisplay
            // 
            this.lblTraitDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTraitDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTraitDisplay.Location = new System.Drawing.Point(3, 8);
            this.lblTraitDisplay.Name = "lblTraitDisplay";
            this.lblTraitDisplay.Size = new System.Drawing.Size(247, 18);
            this.lblTraitDisplay.TabIndex = 0;
            this.lblTraitDisplay.Text = "Trait Display";
            // 
            // btnSettings
            // 
            this.btnSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSettings.ForeColor = System.Drawing.Color.Red;
            this.btnSettings.Location = new System.Drawing.Point(130, 26);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(55, 23);
            this.btnSettings.TabIndex = 1;
            this.btnSettings.Text = "Settings";
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemove.Location = new System.Drawing.Point(191, 26);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(59, 23);
            this.btnRemove.TabIndex = 2;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // lblPoints
            // 
            this.lblPoints.AutoSize = true;
            this.lblPoints.Location = new System.Drawing.Point(3, 31);
            this.lblPoints.Name = "lblPoints";
            this.lblPoints.Size = new System.Drawing.Size(36, 13);
            this.lblPoints.TabIndex = 3;
            this.lblPoints.Text = "Points";
            // 
            // TraitManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(pbxDivider);
            this.Controls.Add(this.lblPoints);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnSettings);
            this.Controls.Add(this.lblTraitDisplay);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "TraitManager";
            this.Size = new System.Drawing.Size(253, 52);
            ((System.ComponentModel.ISupportInitialize)(pbxDivider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTraitDisplay;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Label lblPoints;
    }
}
