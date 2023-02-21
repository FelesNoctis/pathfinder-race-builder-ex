using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PathfinderSystem
{
    public partial class AboutBoxGeneric : Form
    {
        public AboutBoxGeneric()
        {
            InitializeComponent();
        }

        public void SetInfo(string programName, string version, Image programImage)
        {
            lblProgramName.Text = programName;
            lblProgramVersion.Text = "v. " + version;
            pbxProgramImage.Image = programImage;

            Width = 239 + lblProgramName.Width + lblProgramVersion.Width;
        }

        private void lnkMailMe_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
                Process.Start("mailto://" + lnkMailMe.Text);
            else if (e.Button == System.Windows.Forms.MouseButtons.Right)
                Clipboard.SetText(lnkMailMe.Text);
        }

        private void richTextBox1_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            Process.Start(e.LinkText);
        }

        private void richTextBox1_Enter(object sender, EventArgs e)
        {
            btnOkay.Focus();
        }
    }
}
