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
    public partial class HatredRacialTraitForm : Form
    {
        public HatredRacialTraitForm()
        {
            int i;
            InitializeComponent();

            for (i = 0; i < Race.commonSubtypes.Length; i++)
                lstAvailable.Items.Add(Utils.Capitalize(Race.commonSubtypes[i], true));

            foreach (Monster.CreatureType curType in Enum.GetValues(typeof(Monster.CreatureType)))
            {
                if ((curType != Monster.CreatureType.Humanoid) && (curType != Monster.CreatureType.Outsider))
                    lstAvailable.Items.Add(Monster.TypeString(curType, true));
            }
        }

        public void SetSelection(string input)
        {
            if (input.IndexOf(';') > -1)
            {
                foreach (string curInput in input.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries))
                    SelectItem(curInput);
            }
            else
                SelectItem(input);

            ValidateSelections();
        }

        public string GetSelection()
        {
            if (lstSelected.Items.Count == 1)
                return lstSelected.Items[0].ToString();
            else if (lstSelected.Items.Count == 2)
                return lstSelected.Items[0].ToString() + ';' + lstSelected.Items[1].ToString();
            else
                return string.Empty;
        }

        private void SelectItem(string item)
        {
            if (lstAvailable.Items.Contains(item))
            {
                lstAvailable.Items.Remove(item);
                lstSelected.Items.Add(item);
                ValidateSelections();
            }
        }

        private void DeselectItem(string item)
        {
            if (lstSelected.Items.Contains(item))
            {
                lstSelected.Items.Remove(item);
                lstAvailable.Items.Add(item);
                ValidateSelections();
            }
        }

        public void ValidateSelections()
        {
            bool result = false;

            switch (lstSelected.Items.Count)
            {
                case 1:
                    result = (!Array.Exists<string>(Race.commonSubtypes, curType => curType == lstSelected.Items[0].ToString().ToLower()));
                    break;
                case 2:
                    result = true;
                    break;
                default:
                    result = false;
                    break;
            }

            btnOkay.Enabled = result;
        }

        public bool ValidAvailableSelection(int selection)
        {
            if ((selection < 0) || (selection >= lstAvailable.Items.Count))
                return false;

            if (lstSelected.Items.Count == 2)
                return false;

            if ((lstSelected.Items.Count == 1)
                && ((!Array.Exists<string>(Race.commonSubtypes, curType => curType == lstSelected.Items[0].ToString().ToLower())) || (!Array.Exists<string>(Race.commonSubtypes, curType => curType == lstAvailable.Items[selection].ToString().ToLower()))))
                return false;

            return true;
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
            if (ValidAvailableSelection(lstAvailable.SelectedIndex))
                SelectItem(lstAvailable.SelectedItem.ToString());
        }

        private void lstSelected_DoubleClick(object sender, EventArgs e)
        {
            if (lstSelected.SelectedIndex > -1)
                DeselectItem(lstSelected.SelectedItem.ToString());
        }

        private void lstAvailable_MouseMove(object sender, MouseEventArgs e)
        {
            if ((lstSelected.Items.Count > 1) || ((lstAvailable.IndexFromPoint(e.X, e.Y) == lstAvailable.SelectedIndex) && (!ValidAvailableSelection(lstAvailable.SelectedIndex))))
                lstAvailable.Cursor = Cursors.No;
            else
                lstAvailable.Cursor =  Cursors.Default;
        }
    }
}
