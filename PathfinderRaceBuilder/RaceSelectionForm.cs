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
    public partial class RaceSelectionForm : Form
    {
        public enum FilterType
        {
            ShowAll = 0,
            CustomOnly = 1,
            PaizoOnly = 2,
        }

        public static FilterType filter = FilterType.ShowAll;

        public RaceSelectionForm()
        {
            InitializeComponent();

            dudFilterSelection.SelectedIndex = (int)filter;
            FillRaceSelectionOptions();
        }

        public void FillRaceSelectionOptions()
        {
            if (Globals.character == null)
                return;

            string raceString;
            Race raceHolder = Globals.character.race;

            cbxSelectedRace.Items.Clear();

            foreach (Race curRace in Globals.raceDB.Values)
            {
                if (!curRace.custom)
                {
                    Globals.character.race = curRace;
                    raceString = curRace.name + " - " + curRace.raceBuilderPoints + " pts";
                    
                    if ((filter == FilterType.ShowAll) ||
                        ((filter == FilterType.CustomOnly) && (!curRace.paizo)) ||
                        ((filter == FilterType.PaizoOnly) && (curRace.paizo)))
                        cbxSelectedRace.Items.Add(raceString);
                }
            }

            Globals.character.race = raceHolder;
        }

        private void cbxSelectedRace_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnOkay.Enabled = cbxSelectedRace.SelectedIndex != -1;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Retry;
            //Close();
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

        private void dudFilterSelection_SelectedItemChanged(object sender, EventArgs e)
        {
            filter = (FilterType)dudFilterSelection.SelectedIndex;
            FillRaceSelectionOptions();
        }
    }
}
