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
    public partial class SpellLikeAbilitySelectionForm : Form
    {
        SLASelection[] selections;

        public SpellLikeAbilitySelectionForm()
        {
            InitializeComponent();
        }

        public void SetSelections(int minLevel, int maxLevel, int ranks, string[] traitData)
        {
            int i;
            string[] finalizedOptions;

            selections = new SLASelection[ranks];

            List<string> options = new List<string>();

            foreach (Spell curSpell in Globals.spellDB.Values)
            {
                if ((curSpell.spellLikeLevel >= minLevel) && (curSpell.spellLikeLevel <= maxLevel))
                    options.Add(curSpell.name);
            }

            finalizedOptions = options.ToArray();

            for (i = 0; i < ranks; i++)
            {
                selections[i] = new SLASelection();
                selections[i].SetOptions(finalizedOptions, traitData[i]);

                selections[i].Location = new Point(4, 4 + i * (selections[i].Height + 4));
                selections[i].Width = ClientSize.Width - 8;

                selections[i].cbxSpellName.SelectedIndexChanged += ValidateSelections;

                Controls.Add(selections[i]);

                Height += 4 + selections[i].Height;
            }

            Height += 16; // Why!?

            ValidateSelections(null, null);
        }

        public string GetSelection(int index)
        {
            return selections[index].cbxSpellName.Text;
        }

        public void ValidateSelections(object sender, EventArgs e)
        {
            bool result = true;

            for (int i = 0; i < selections.Length; i++)
            {
                if (!Globals.spellDB.Keys.Contains(selections[i].cbxSpellName.Text))
                {
                    result = false;
                    break;
                }
            }

            btnOkay.Enabled = result;
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
