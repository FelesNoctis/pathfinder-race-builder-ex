using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PathfinderSystem;

namespace PathfinderRaceBuilder
{
    public partial class SplashForm : Form
    {
        private DateTime startTime;

        public SplashForm()
        {
            InitializeComponent();

            this.Icon = Properties.Resources.PFRBIcon;
        }

        private void bgwInitialize_DoWork(object sender, DoWorkEventArgs e)
        {
            Globals.Initialize(Globals.LoadItems.Basics | Globals.LoadItems.Spells, ErrorPopup);
        }

        private void SplashForm_Shown(object sender, EventArgs e)
        {
            bgwInitialize.RunWorkerAsync();

            startTime = DateTime.Now;
        }

        private void bgwInitialize_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Close();
        }

        private void tmrFireMe_Tick(object sender, EventArgs e)
        {
            TimeSpan curSpan = startTime - DateTime.Now;

            int labelColor = (int)((0.5 * Math.Sin(curSpan.TotalMilliseconds / 500) + 0.5) * 255);

            lblLoadingText.ForeColor = Color.FromArgb(labelColor, labelColor, labelColor);
        }

        private void ErrorPopup(string caption, string message)
        {
            if (MessageBox.Show(message + System.Environment.NewLine + System.Environment.NewLine + "Press 'Ok' to continue or 'Cancel' to exit the program.", caption, MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == System.Windows.Forms.DialogResult.Cancel)
                Application.Exit();
        }
    }
}
