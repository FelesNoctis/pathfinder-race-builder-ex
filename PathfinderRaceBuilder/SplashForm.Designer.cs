namespace PathfinderRaceBuilder
{
    partial class SplashForm
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
            this.pnlTextBackground = new System.Windows.Forms.Panel();
            this.lblLoadingText = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.bgwInitialize = new System.ComponentModel.BackgroundWorker();
            this.tmrFireMe = new System.Windows.Forms.Timer(this.components);
            this.pnlTextBackground.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTextBackground
            // 
            this.pnlTextBackground.BackColor = System.Drawing.Color.Black;
            this.pnlTextBackground.Controls.Add(this.lblLoadingText);
            this.pnlTextBackground.Location = new System.Drawing.Point(0, 96);
            this.pnlTextBackground.Name = "pnlTextBackground";
            this.pnlTextBackground.Size = new System.Drawing.Size(200, 32);
            this.pnlTextBackground.TabIndex = 0;
            // 
            // lblLoadingText
            // 
            this.lblLoadingText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoadingText.ForeColor = System.Drawing.Color.White;
            this.lblLoadingText.Location = new System.Drawing.Point(12, 9);
            this.lblLoadingText.Name = "lblLoadingText";
            this.lblLoadingText.Size = new System.Drawing.Size(176, 14);
            this.lblLoadingText.TabIndex = 0;
            this.lblLoadingText.Text = "Loading...";
            this.lblLoadingText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::PathfinderRaceBuilder.Properties.Resources.VitruvianIcon;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(200, 200);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // bgwInitialize
            // 
            this.bgwInitialize.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwInitialize_DoWork);
            this.bgwInitialize.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwInitialize_RunWorkerCompleted);
            // 
            // tmrFireMe
            // 
            this.tmrFireMe.Enabled = true;
            this.tmrFireMe.Tick += new System.EventHandler(this.tmrFireMe_Tick);
            // 
            // SplashForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(200, 200);
            this.ControlBox = false;
            this.Controls.Add(this.pnlTextBackground);
            this.Controls.Add(this.pictureBox1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SplashForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Shown += new System.EventHandler(this.SplashForm_Shown);
            this.pnlTextBackground.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTextBackground;
        private System.Windows.Forms.Label lblLoadingText;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.ComponentModel.BackgroundWorker bgwInitialize;
        private System.Windows.Forms.Timer tmrFireMe;

    }
}