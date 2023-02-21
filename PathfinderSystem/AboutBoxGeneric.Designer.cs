namespace PathfinderSystem
{
    partial class AboutBoxGeneric
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutBoxGeneric));
            this.pbxProgramImage = new System.Windows.Forms.PictureBox();
            this.btnOkay = new System.Windows.Forms.Button();
            this.lblProgramName = new System.Windows.Forms.Label();
            this.lblProgramVersion = new System.Windows.Forms.Label();
            this.lblByTheBobbyLlama = new System.Windows.Forms.Label();
            this.lnkMailMe = new System.Windows.Forms.LinkLabel();
            this.gbxAcknowledgements = new System.Windows.Forms.GroupBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.ttpGeneric = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pbxProgramImage)).BeginInit();
            this.gbxAcknowledgements.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbxProgramImage
            // 
            this.pbxProgramImage.Location = new System.Drawing.Point(12, 12);
            this.pbxProgramImage.Name = "pbxProgramImage";
            this.pbxProgramImage.Size = new System.Drawing.Size(200, 200);
            this.pbxProgramImage.TabIndex = 0;
            this.pbxProgramImage.TabStop = false;
            // 
            // btnOkay
            // 
            this.btnOkay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOkay.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnOkay.Location = new System.Drawing.Point(419, 189);
            this.btnOkay.Name = "btnOkay";
            this.btnOkay.Size = new System.Drawing.Size(56, 23);
            this.btnOkay.TabIndex = 1;
            this.btnOkay.Text = "Ok";
            this.btnOkay.UseVisualStyleBackColor = true;
            // 
            // lblProgramName
            // 
            this.lblProgramName.AutoSize = true;
            this.lblProgramName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProgramName.Location = new System.Drawing.Point(218, 12);
            this.lblProgramName.Name = "lblProgramName";
            this.lblProgramName.Size = new System.Drawing.Size(202, 24);
            this.lblProgramName.TabIndex = 2;
            this.lblProgramName.Text = "Program Name Here";
            // 
            // lblProgramVersion
            // 
            this.lblProgramVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblProgramVersion.AutoSize = true;
            this.lblProgramVersion.Location = new System.Drawing.Point(423, 20);
            this.lblProgramVersion.Name = "lblProgramVersion";
            this.lblProgramVersion.Size = new System.Drawing.Size(52, 13);
            this.lblProgramVersion.TabIndex = 3;
            this.lblProgramVersion.Text = "v. 0.0.0.0";
            // 
            // lblByTheBobbyLlama
            // 
            this.lblByTheBobbyLlama.AutoSize = true;
            this.lblByTheBobbyLlama.Location = new System.Drawing.Point(229, 36);
            this.lblByTheBobbyLlama.Name = "lblByTheBobbyLlama";
            this.lblByTheBobbyLlama.Size = new System.Drawing.Size(110, 13);
            this.lblByTheBobbyLlama.TabIndex = 4;
            this.lblByTheBobbyLlama.Text = "by The Bobby Llama -";
            // 
            // lnkMailMe
            // 
            this.lnkMailMe.AutoSize = true;
            this.lnkMailMe.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkMailMe.Location = new System.Drawing.Point(337, 36);
            this.lnkMailMe.Name = "lnkMailMe";
            this.lnkMailMe.Size = new System.Drawing.Size(137, 13);
            this.lnkMailMe.TabIndex = 5;
            this.lnkMailMe.TabStop = true;
            this.lnkMailMe.Text = "admin@thebobbyllama.com";
            this.ttpGeneric.SetToolTip(this.lnkMailMe, "Right-click to copy.");
            this.lnkMailMe.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkMailMe_LinkClicked);
            // 
            // gbxAcknowledgements
            // 
            this.gbxAcknowledgements.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbxAcknowledgements.Controls.Add(this.richTextBox1);
            this.gbxAcknowledgements.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.gbxAcknowledgements.Location = new System.Drawing.Point(218, 52);
            this.gbxAcknowledgements.Name = "gbxAcknowledgements";
            this.gbxAcknowledgements.Size = new System.Drawing.Size(257, 131);
            this.gbxAcknowledgements.TabIndex = 6;
            this.gbxAcknowledgements.TabStop = false;
            this.gbxAcknowledgements.Text = "Acknowledgements";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Cursor = System.Windows.Forms.Cursors.Default;
            this.richTextBox1.Location = new System.Drawing.Point(6, 19);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.richTextBox1.Size = new System.Drawing.Size(245, 106);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.TabStop = false;
            this.richTextBox1.Text = resources.GetString("richTextBox1.Text");
            this.richTextBox1.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.richTextBox1_LinkClicked);
            this.richTextBox1.Enter += new System.EventHandler(this.richTextBox1_Enter);
            // 
            // AboutBoxGeneric
            // 
            this.AcceptButton = this.btnOkay;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnOkay;
            this.ClientSize = new System.Drawing.Size(487, 224);
            this.ControlBox = false;
            this.Controls.Add(this.gbxAcknowledgements);
            this.Controls.Add(this.lnkMailMe);
            this.Controls.Add(this.lblByTheBobbyLlama);
            this.Controls.Add(this.lblProgramVersion);
            this.Controls.Add(this.lblProgramName);
            this.Controls.Add(this.btnOkay);
            this.Controls.Add(this.pbxProgramImage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutBoxGeneric";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            ((System.ComponentModel.ISupportInitialize)(this.pbxProgramImage)).EndInit();
            this.gbxAcknowledgements.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbxProgramImage;
        private System.Windows.Forms.Button btnOkay;
        private System.Windows.Forms.Label lblProgramName;
        private System.Windows.Forms.Label lblProgramVersion;
        private System.Windows.Forms.Label lblByTheBobbyLlama;
        private System.Windows.Forms.LinkLabel lnkMailMe;
        private System.Windows.Forms.GroupBox gbxAcknowledgements;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.ToolTip ttpGeneric;
    }
}