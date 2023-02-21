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
    public partial class BonusFeatRacialTraitForm : Form
    {
        public BonusFeatRacialTraitForm()
        {
            InitializeComponent();

            foreach (Feat curFeat in Globals.featDB.Values)
            {
                if (curFeat.prerequisites.Count == 0)
                    cbxFeatName.Items.Add(curFeat.name);
            }
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

        private void cbxFeatName_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnOkay.Enabled = (cbxFeatName.SelectedIndex > -1);

            if (cbxFeatName.SelectedIndex > -1)
                txtFeatInfo.Text = Globals.featDB[cbxFeatName.Text].shortDescription;
            else
                txtFeatInfo.Text = string.Empty;
        }
    }
}
