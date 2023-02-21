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
    public partial class WeaponFamiliarityRacialTraitForm : Form
    {
        private const string invalidSubtype = "XXX";
        private int maxSelections;

        public WeaponFamiliarityRacialTraitForm()
        {
            bool skipWeapon;
            int i, j;
            string[] subtypes = null;
            string tmpStr;

            InitializeComponent();

            lstAvailableWeapons.Items.Add("Bows");

            if (Globals.character.race.type.entryName == "Humanoid")
            {
                subtypes = Globals.character.race.subtype.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                for (i = 0; i < subtypes.Length; i++)
                {
                    subtypes[i] = subtypes[i].ToLower().Trim();

                    for (j = 0; j < Race.subtypeRacialWeaponConversions.GetLength(0); j++)
                    {
                        if (subtypes[i] == Race.subtypeRacialWeaponConversions[j, 0])
                        {
                            subtypes[i] = Race.subtypeRacialWeaponConversions[j, 1];
                            break;
                        }
                    }

                    if (j == Race.subtypeRacialWeaponConversions.GetLength(0))
                        subtypes[i] = invalidSubtype;
                }
            }

            List<Weapon> allWeapons = Globals.equipmentDB.GetAll<Weapon>();

            foreach (Weapon curWeapon in allWeapons)
            {
                skipWeapon = false;

                if (subtypes != null)
                {
                    for (i = 0; i < subtypes.Length; i++)
                    {
                        if ((curWeapon.name.ToLower().Contains(subtypes[i])) || ((!string.IsNullOrEmpty(Globals.character.race.nameAdjective)) && (curWeapon.name.ToLower().Contains(Globals.character.race.nameAdjective.ToLower()))))
                            skipWeapon = true;
                    }
                }

                if ((curWeapon.name.ToLower().Contains("shortbow")) || (curWeapon.name.ToLower().Contains("longbow")))
                    skipWeapon = true;

                if (!skipWeapon)
                    lstAvailableWeapons.Items.Add(curWeapon.name);
            }

            if (subtypes != null)
            {
                for (i = 0; i < subtypes.Length; i++)
                {
                    if (subtypes[i] != invalidSubtype)
                        lstAvailableWeapons.Items.Add(Utils.Capitalize(subtypes[i], true) + " Weapons");
                }
            }

            if (string.IsNullOrEmpty(Globals.character.race.nameAdjective))
                tmpStr = "Racial Weapons";
            else
                tmpStr = Utils.Capitalize(Globals.character.race.nameAdjective, true) + " Weapons";

            if (!lstAvailableWeapons.Items.Contains(tmpStr))
                lstAvailableWeapons.Items.Add(tmpStr);
        }

        public void SetSelections(int ranks, string[] info)
        {
            for (int i = 0; i < ranks; i++)
            {
                foreach (string curItem in info[i].Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    if (lstAvailableWeapons.Items.Contains(curItem))
                        AddWeapon(curItem);
                }
            }

            maxSelections = 2 * ranks;
            ValidateSelections();
        }

        public string GetSelections(int grouping)
        {
            if (lstSelectedWeapons.Items.Count > grouping * 2 + 1)
                return lstSelectedWeapons.Items[2 * grouping].ToString() + ';' + lstSelectedWeapons.Items[2 * grouping + 1].ToString();
            else
                return lstSelectedWeapons.Items[2 * grouping].ToString();
        }

        private bool ValidateSelections()
        {
            if (lstSelectedWeapons.Items.Count < maxSelections)
                lblSelected.Text = "Select up to " + (maxSelections - lstSelectedWeapons.Items.Count) + " more";
            else
                lblSelected.Text = "Selected";

            btnOkay.Enabled = ((lstSelectedWeapons.Items.Count >= maxSelections - 1) && (lstSelectedWeapons.Items.Count <= maxSelections));

            return btnOkay.Enabled;
        }

        private void AddWeapon(string weapon)
        {
            lstAvailableWeapons.Items.Remove(weapon);
            lstSelectedWeapons.Items.Add(weapon);

            ValidateSelections();
        }

        private void RemoveWeapon(string weapon)
        {
            lstSelectedWeapons.Items.Remove(weapon);
            lstAvailableWeapons.Items.Add(weapon);

            ValidateSelections();
        }

        public bool ValidAvailableSelection(int selection)
        {
            if ((selection < 0) || (selection >= lstAvailableWeapons.Items.Count))
                return false;

            if (lstSelectedWeapons.Items.Count >= maxSelections)
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

        private void lstAvailableWeapons_DoubleClick(object sender, EventArgs e)
        {
            if (ValidAvailableSelection(lstAvailableWeapons.SelectedIndex))
                AddWeapon(lstAvailableWeapons.SelectedItem.ToString());
        }

        private void lstSelectedWeapons_DoubleClick(object sender, EventArgs e)
        {
            if (lstSelectedWeapons.SelectedIndex > -1)
                RemoveWeapon(lstSelectedWeapons.SelectedItem.ToString());
        }

        private void lstAvailableWeapons_MouseMove(object sender, MouseEventArgs e)
        {
            if ((lstAvailableWeapons.IndexFromPoint(e.X, e.Y) == lstAvailableWeapons.SelectedIndex) && (!ValidAvailableSelection(lstAvailableWeapons.SelectedIndex)))
                lstAvailableWeapons.Cursor = Cursors.No;
            else
                lstAvailableWeapons.Cursor = Cursors.Default;
        }
    }
}
