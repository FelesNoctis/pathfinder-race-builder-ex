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
    public partial class EnergyTypeMultipleRacialTraitForm : Form
    {
        int maxSelections = 0;

        public EnergyTypeMultipleRacialTraitForm()
        {
            InitializeComponent();
        }

        public void SetSelections(int ranks, string[] info)
        {
            maxSelections = ranks;

            for (int i = 0; i < ranks; i++)
            {
                if (lstAvailable.Items.Contains(info[i]))
                    AddEnergyType(info[i]);
            }

            ValidateSelections();
        }

        public string GetSelection(int index)
        {
            return lstSelected.Items[index].ToString();
        }

        public bool ValidateSelections()
        {
            btnOkay.Enabled = lstSelected.Items.Count == maxSelections;

            return btnOkay.Enabled;
        }

        private void AddEnergyType(string type)
        {
            lstAvailable.Items.Remove(type);
            lstSelected.Items.Add(type);
            ValidateSelections();
        }

        private void RemoveEnergyType(string type)
        {
            lstAvailable.Items.Add(type);
            lstSelected.Items.Remove(type);
            ValidateSelections();
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

        private void lstAvailable_DoubleClick(object sender, EventArgs e)
        {
            if ((lstAvailable.SelectedIndex > -1) && (lstSelected.Items.Count < maxSelections))
                AddEnergyType(lstAvailable.SelectedItem.ToString());
        }

        private void lstSelected_DoubleClick(object sender, EventArgs e)
        {
            if (lstSelected.SelectedIndex > -1)
                RemoveEnergyType(lstSelected.SelectedItem.ToString());
        }

        private void lstAvailable_MouseMove(object sender, MouseEventArgs e)
        {
            if ((lstAvailable.IndexFromPoint(e.X, e.Y) == lstAvailable.SelectedIndex) && (lstSelected.Items.Count >= maxSelections))
                lstAvailable.Cursor = Cursors.No;
            else
                lstAvailable.Cursor = Cursors.Default;
        }
    }
}
