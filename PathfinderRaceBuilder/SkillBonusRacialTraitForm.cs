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
    public partial class SkillBonusRacialTraitForm : Form
    {
        private int skillBonusRanks;
        private ListBox dragSource = null;

        public SkillBonusRacialTraitForm()
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

        public void SetSelections(int count, string[] info)
        {
            string[] split;

            skillBonusRanks = count;

            for (int i = 0; i < count; i++)
            {
                if (info[i].IndexOf(';') == -1)
                {
                    if (lstAvailable.Items.Contains(info[i]))
                    {
                        lstAvailable.Items.Remove(info[i]);
                        lstFullBonus.Items.Add(info[i]);
                    }
                }
                else
                {
                    split = info[i].Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

                    foreach (string curSkill in split)
                    {
                        lstAvailable.Items.Remove(curSkill);
                        lstHalfBonus.Items.Add(curSkill);
                    }
                }
            }

            ValidateSelections();
        }

        private int GetSelectedCount()
        {
            return 2 * lstFullBonus.Items.Count + lstHalfBonus.Items.Count;
        }

        public bool ValidateSelections()
        {
            btnOK.Enabled = (GetSelectedCount() == 2 * skillBonusRanks);

            return btnOK.Enabled;
        }

        public string GetSelectionString(int index)
        {
            if (index < lstFullBonus.Items.Count)
            {
                return lstFullBonus.Items[index].ToString();
            }
            else
            {
                return lstHalfBonus.Items[2 * (index - lstFullBonus.Items.Count)].ToString() + ';' + lstHalfBonus.Items[2 * (index - lstFullBonus.Items.Count) + 1].ToString();
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;
            //Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            //Close();
        }

        private void BeginListBoxDrag(object sender, MouseEventArgs e)
        {
            ListBox curBox = sender as ListBox;

            if (curBox != null)
            {
                int indexOfItem = curBox.IndexFromPoint(e.X, e.Y);
                if (indexOfItem >= 0 && indexOfItem < curBox.Items.Count)
                {
                    dragSource = curBox;
                    curBox.DoDragDrop(curBox.Items[indexOfItem], DragDropEffects.Move);
                }
            }
        }

        private void ListBoxDragEnter(object sender, DragEventArgs e)
        {
            bool result = true;

            if (sender == dragSource)
                result = false;
            else if ((dragSource == lstAvailable) && (GetSelectedCount() >= 2 * skillBonusRanks))
                result = false;
            else if ((sender == lstFullBonus) && (GetSelectedCount() >= 2 * skillBonusRanks))
                result = false;
            else if ((sender == lstHalfBonus) && (dragSource != lstFullBonus) && (GetSelectedCount() >= 2 * skillBonusRanks))
                result = false;

            e.Effect = (result) ? DragDropEffects.Move : DragDropEffects.None;
        }

        private void ListBoxDragDrop(object sender, DragEventArgs e)
        {
            if (e.Effect == DragDropEffects.Move)
            {
                ListBox curBox = sender as ListBox;

                if (curBox != null)
                {
                    dragSource.Items.Remove(e.Data.GetData(typeof(string)));
                    curBox.Items.Add(e.Data.GetData(typeof(string)));

                    ValidateSelections();
                }
            }
        }
    }
}
