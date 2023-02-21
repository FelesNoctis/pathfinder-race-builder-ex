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
    public partial class RaceDeletionForm : Form
    {
        public RaceDeletionForm()
        {
            InitializeComponent();

            Race raceHolder = Globals.character.race;

            foreach (Race curRace in Globals.raceDB.Values)
            {
                if ((!curRace.custom) && (!curRace.paizo))
                {
                    Globals.character.race = curRace;
                    lstAvailableRaces.Items.Add(curRace.name + " - " + curRace.raceBuilderPoints + " pts");
                }
            }

            Globals.character.race = raceHolder;
        }

        private void SetOkayButton()
        {
            btnOkay.Enabled = (lstSelectedRaces.Items.Count > 0);
        }

        private void lstAvailableRaces_DoubleClick(object sender, EventArgs e)
        {
            if (lstAvailableRaces.SelectedIndex > -1)
            {
                string moveMe = lstAvailableRaces.SelectedItem.ToString();
                lstAvailableRaces.Items.Remove(moveMe);
                lstSelectedRaces.Items.Add(moveMe);
                SetOkayButton();
            }
        }

        private void lstSelectedRaces_DoubleClick(object sender, EventArgs e)
        {
            if (lstAvailableRaces.SelectedIndex > -1)
            {
                string moveMe = lstAvailableRaces.SelectedItem.ToString();
                lstAvailableRaces.Items.Remove(moveMe);
                lstSelectedRaces.Items.Add(moveMe);
                SetOkayButton();
            }
        }

        private void btnOkay_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you SURE you want to delete " + ((lstSelectedRaces.Items.Count == 1) ? "this race" : "these races") +" forever?", "This is genocide!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
            {
                DialogResult = System.Windows.Forms.DialogResult.OK;
                //Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            //Close();
        }
    }
}
