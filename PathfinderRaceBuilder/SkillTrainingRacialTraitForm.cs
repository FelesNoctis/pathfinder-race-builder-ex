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
    public partial class SkillTrainingRacialTraitForm : Form
    {
        public SkillTrainingRacialTraitForm()
        {
            string curName;

            InitializeComponent();

            foreach (Skill curSkill in Globals.skillDB)
            {
                switch (curSkill.key)
                {
                    case Skill.SkillKey.CraftPrimary:
                    case Skill.SkillKey.CraftAncillary:
                        continue;
                    default:
                        curName = curSkill.displayName;
                        break;
                }

                lstAvailable.Items.Add(curName);
            }
        }

        public string GetSelections()
        {
            return lstSelected.Items[0].ToString() + ';' + lstSelected.Items[1].ToString();
        }

        public void SetSelections(string info)
        {
            string[] split = info.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

            if (split.Length > 0)
            {
                lstSelected.Items.Add(split[0]);

                if (split.Length > 1)
                    lstSelected.Items.Add(split[1]);
            }

            ValidateEntries();
        }

        private void ValidateEntries()
        {
            btnOkay.Enabled = (lstSelected.Items.Count == 2);
        }

        private void SelectSkill(string skillName)
        {
            if (lstAvailable.Items.Contains(skillName))
            {
                lstAvailable.Items.Remove(skillName);
                lstSelected.Items.Add(skillName);
            }
        }

        private void RemoveSkill(string skillName)
        {
            lstSelected.Items.Remove(skillName);
            lstAvailable.Items.Add(skillName);
        }

        private void lstAvailable_DoubleClick(object sender, EventArgs e)
        {
            if (lstAvailable.SelectedIndex > -1)
            {
                SelectSkill(lstAvailable.SelectedItem.ToString());
                ValidateEntries();
            }
        }

        private void lstSelected_DoubleClick(object sender, EventArgs e)
        {
            if (lstSelected.SelectedIndex > -1)
            {
                RemoveSkill(lstSelected.SelectedItem.ToString());
                ValidateEntries();
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
