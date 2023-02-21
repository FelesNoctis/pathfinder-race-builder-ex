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
    public partial class FavoredTerrainRacialTraitForm : Form
    {
        public FavoredTerrainRacialTraitForm()
        {
            InitializeComponent();

            foreach (ClassRanger.FavoredTerrain curTerrain in ClassRanger.favoredTerrains)
                cbxTerrainType.Items.Add(curTerrain.name);
        }

        public void SetSelection(string pickMe)
        {
            cbxTerrainType.SelectedItem = pickMe;
        }

        public string GetSelection()
        {
            return cbxTerrainType.Text;
        }

        private void cbxTerrainType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxTerrainType.SelectedIndex > -1)
            {
                lblTerrainDescription.Text = string.Format("This trait will apply when the character is {0}.", ClassRanger.FavoredTerrain.Get(cbxTerrainType.Text).sentenceText);
                btnOkay.Enabled = true;
            }
            else
            {
                lblTerrainDescription.Text = string.Empty;
                btnOkay.Enabled = false;
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
    }
}
