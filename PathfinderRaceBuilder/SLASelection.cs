using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using PathfinderSystem;

namespace PathfinderRaceBuilder
{
    public partial class SLASelection : UserControl
    {
        public SLASelection()
        {
            InitializeComponent();
        }

        public void SetOptions(string[] optionList, string selectedOption)
        {
            cbxSpellName.Items.AddRange(optionList);
            cbxSpellName.SelectedItem = selectedOption;
        }

        private void cbxSpellName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Globals.spellDB.Keys.Contains(cbxSpellName.Text))
            {
                lblSpellLevel.Text = "lvl " + Globals.spellDB[cbxSpellName.Text].spellLikeLevel;
                lblSpellDescription.Text = Globals.spellDB[cbxSpellName.Text].shortDescription;
                ttpGeneric.SetToolTip(lblSpellDescription, lblSpellDescription.Text);
                lblSpellLevel.Visible = lblSpellDescription.Visible = true;
            }
            else
            {
                ttpGeneric.SetToolTip(lblSpellDescription, null);
                lblSpellLevel.Visible = lblSpellDescription.Visible = false;
            }
        }
    }
}
