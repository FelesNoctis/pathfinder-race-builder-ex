namespace PathfinderSpellDBParser
{
    partial class ParseForm
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
            this.btnGoCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtResults = new System.Windows.Forms.TextBox();
            this.prgProgress = new System.Windows.Forms.ProgressBar();
            this.bgwParseMe = new System.ComponentModel.BackgroundWorker();
            this.lblFinalCount = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnGoCancel
            // 
            this.btnGoCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnGoCancel.Location = new System.Drawing.Point(12, 499);
            this.btnGoCancel.Name = "btnGoCancel";
            this.btnGoCancel.Size = new System.Drawing.Size(54, 23);
            this.btnGoCancel.TabIndex = 0;
            this.btnGoCancel.Text = "Go!";
            this.btnGoCancel.UseVisualStyleBackColor = true;
            this.btnGoCancel.Click += new System.EventHandler(this.btnGoCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(859, 499);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(54, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtResults
            // 
            this.txtResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtResults.Enabled = false;
            this.txtResults.Location = new System.Drawing.Point(12, 12);
            this.txtResults.Multiline = true;
            this.txtResults.Name = "txtResults";
            this.txtResults.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtResults.Size = new System.Drawing.Size(901, 481);
            this.txtResults.TabIndex = 2;
            // 
            // prgProgress
            // 
            this.prgProgress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.prgProgress.Location = new System.Drawing.Point(72, 499);
            this.prgProgress.Name = "prgProgress";
            this.prgProgress.Size = new System.Drawing.Size(660, 22);
            this.prgProgress.TabIndex = 3;
            this.prgProgress.Visible = false;
            // 
            // bgwParseMe
            // 
            this.bgwParseMe.WorkerReportsProgress = true;
            this.bgwParseMe.WorkerSupportsCancellation = true;
            this.bgwParseMe.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwParseMe_DoWork);
            this.bgwParseMe.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgwParseMe_ProgressChanged);
            this.bgwParseMe.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwParseMe_RunWorkerCompleted);
            // 
            // lblFinalCount
            // 
            this.lblFinalCount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFinalCount.Location = new System.Drawing.Point(738, 499);
            this.lblFinalCount.Name = "lblFinalCount";
            this.lblFinalCount.Size = new System.Drawing.Size(115, 22);
            this.lblFinalCount.TabIndex = 4;
            this.lblFinalCount.Text = "9999 spells processed.";
            this.lblFinalCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblFinalCount.Visible = false;
            // 
            // ParseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(925, 534);
            this.Controls.Add(this.lblFinalCount);
            this.Controls.Add(this.prgProgress);
            this.Controls.Add(this.txtResults);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnGoCancel);
            this.Name = "ParseForm";
            this.Text = "Pathfinder CSV Spell Database Parser";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGoCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtResults;
        private System.Windows.Forms.ProgressBar prgProgress;
        private System.ComponentModel.BackgroundWorker bgwParseMe;
        private System.Windows.Forms.Label lblFinalCount;
    }
}

