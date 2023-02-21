namespace PathfinderRaceBuilder
{
    partial class AttributeControl
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
            this.lblAttribute = new System.Windows.Forms.Label();
            this.chkNegFour = new System.Windows.Forms.CheckBox();
            this.chkNegTwo = new System.Windows.Forms.CheckBox();
            this.chkPlusTwo = new System.Windows.Forms.CheckBox();
            this.chkPlusFour = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // lblAttribute
            // 
            this.lblAttribute.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAttribute.Location = new System.Drawing.Point(62, 3);
            this.lblAttribute.Name = "lblAttribute";
            this.lblAttribute.Size = new System.Drawing.Size(39, 23);
            this.lblAttribute.TabIndex = 0;
            this.lblAttribute.Text = "XXX";
            this.lblAttribute.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chkNegFour
            // 
            this.chkNegFour.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkNegFour.Location = new System.Drawing.Point(3, 3);
            this.chkNegFour.Margin = new System.Windows.Forms.Padding(0);
            this.chkNegFour.Name = "chkNegFour";
            this.chkNegFour.Size = new System.Drawing.Size(27, 23);
            this.chkNegFour.TabIndex = 1;
            this.chkNegFour.Text = "-4";
            this.chkNegFour.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkNegFour.UseVisualStyleBackColor = true;
            this.chkNegFour.CheckedChanged += new System.EventHandler(this.Generic_CheckedChanged);
            // 
            // chkNegTwo
            // 
            this.chkNegTwo.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkNegTwo.Location = new System.Drawing.Point(32, 3);
            this.chkNegTwo.Margin = new System.Windows.Forms.Padding(0);
            this.chkNegTwo.Name = "chkNegTwo";
            this.chkNegTwo.Size = new System.Drawing.Size(27, 23);
            this.chkNegTwo.TabIndex = 2;
            this.chkNegTwo.Text = "-2";
            this.chkNegTwo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkNegTwo.UseVisualStyleBackColor = true;
            this.chkNegTwo.CheckedChanged += new System.EventHandler(this.Generic_CheckedChanged);
            // 
            // chkPlusTwo
            // 
            this.chkPlusTwo.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkPlusTwo.Location = new System.Drawing.Point(104, 3);
            this.chkPlusTwo.Margin = new System.Windows.Forms.Padding(0);
            this.chkPlusTwo.Name = "chkPlusTwo";
            this.chkPlusTwo.Size = new System.Drawing.Size(27, 23);
            this.chkPlusTwo.TabIndex = 3;
            this.chkPlusTwo.Text = "+2";
            this.chkPlusTwo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkPlusTwo.UseVisualStyleBackColor = true;
            this.chkPlusTwo.CheckedChanged += new System.EventHandler(this.Generic_CheckedChanged);
            // 
            // chkPlusFour
            // 
            this.chkPlusFour.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkPlusFour.Location = new System.Drawing.Point(133, 3);
            this.chkPlusFour.Margin = new System.Windows.Forms.Padding(0);
            this.chkPlusFour.Name = "chkPlusFour";
            this.chkPlusFour.Size = new System.Drawing.Size(27, 23);
            this.chkPlusFour.TabIndex = 4;
            this.chkPlusFour.Text = "+4";
            this.chkPlusFour.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkPlusFour.UseVisualStyleBackColor = true;
            this.chkPlusFour.CheckedChanged += new System.EventHandler(this.Generic_CheckedChanged);
            this.chkPlusFour.EnabledChanged += new System.EventHandler(this.Generic_CheckedChanged);
            // 
            // AttributeControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chkPlusFour);
            this.Controls.Add(this.chkPlusTwo);
            this.Controls.Add(this.chkNegTwo);
            this.Controls.Add(this.chkNegFour);
            this.Controls.Add(this.lblAttribute);
            this.MaximumSize = new System.Drawing.Size(163, 31);
            this.MinimumSize = new System.Drawing.Size(163, 31);
            this.Name = "AttributeControl";
            this.Size = new System.Drawing.Size(163, 31);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox chkNegFour;
        private System.Windows.Forms.CheckBox chkNegTwo;
        private System.Windows.Forms.CheckBox chkPlusTwo;
        private System.Windows.Forms.CheckBox chkPlusFour;
        private System.Windows.Forms.Label lblAttribute;

    }
}
