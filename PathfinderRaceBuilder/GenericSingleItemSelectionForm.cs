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
    public partial class GenericSingleItemSelectionForm : Form
    {
        public GenericSingleItemSelectionForm()
        {
            InitializeComponent();
        }

        public void Setup(string title, string[] options)
        {
            Text = title;

            cbxSelection.Items.AddRange(options);
        }

        public void SetSelection(string pickMe)
        {
            cbxSelection.SelectedItem = pickMe;

            ValidateSelection();
        }

        public string GetSelection()
        {
            return cbxSelection.Text;
        }

        private bool ValidateSelection()
        {
            btnOkay.Enabled = (cbxSelection.SelectedIndex > -1);

            return btnOkay.Enabled;
        }

        private void cbxSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            ValidateSelection();
        }

        private void btnOkay_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;
            //Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            //Close();
        }
    }
}
