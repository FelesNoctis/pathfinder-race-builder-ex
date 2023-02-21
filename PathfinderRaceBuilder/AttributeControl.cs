using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace PathfinderRaceBuilder
{
    public partial class AttributeControl : UserControl
    {
        [Flags]
        public enum ValidValues
        {
            None = 0,
            NegFour = 1,
            NegTwo = 2,
            PlusTwo = 4,
            PlusFour = 8,
        }

        public bool physical;
        public bool suppressEvents = false;
        public ValidValues valid;
        public event EventHandler SelectionUpdated;

        public AttributeControl()
        {
            InitializeComponent();

            SetControls(AttributeControl.ValidValues.None);
        }

        public void SetAbility(string ability)
        {
            switch (ability)
            {
                case "STR":
                case "DEX":
                case "CON":
                    physical = true;
                    break;
                default:
                    physical = false;
                    break;
            }

            lblAttribute.Text = ability;
        }

        public void ResetControls()
        {
            chkNegFour.Checked = chkNegTwo.Checked = chkPlusTwo.Checked = chkPlusFour.Checked = false;
        }

        public void SetControls(ValidValues changed)
        {
            suppressEvents = true;

            if ((changed & ValidValues.NegFour) != 0)
                chkNegFour.Enabled = true;
            else
                chkNegFour.Checked = chkNegFour.Enabled = false;

            if ((changed & ValidValues.NegTwo) != 0)
                chkNegTwo.Enabled = true;
            else
                chkNegTwo.Checked = chkNegTwo.Enabled = false;

            if ((changed & ValidValues.PlusTwo) != 0)
                chkPlusTwo.Enabled = true;
            else
                chkPlusTwo.Checked = chkPlusTwo.Enabled = false;

            if ((changed & ValidValues.PlusFour) != 0)
                chkPlusFour.Enabled = true;
            else
                chkPlusFour.Checked = chkPlusFour.Enabled = false;

            valid = changed;
            suppressEvents = false;
        }

        public void SetValue(int setButton)
        {
            suppressEvents = true;

            switch (setButton)
            {
                case -4:
                    if (chkNegFour.Enabled)
                        chkNegFour.Checked = true;

                    break;
                case -2:
                    if (chkNegTwo.Enabled)
                        chkNegTwo.Checked = true;

                    break;
                case 2:
                    if (chkPlusTwo.Enabled)
                        chkPlusTwo.Checked = true;

                    break;
                case 4:
                    if (chkPlusFour.Enabled)
                        chkPlusFour.Checked = true;

                    break;
                case 0:
                    chkNegFour.Checked = chkNegTwo.Checked = chkPlusTwo.Checked = chkPlusFour.Checked = false;
                    break;
            }

            suppressEvents = false;
        }

        public void LockControls(bool lockMe, int setButton)
        {
            if (lockMe)
            {
                SetValue(setButton);

                chkNegFour.Enabled = chkNegTwo.Enabled = chkPlusTwo.Enabled = chkPlusFour.Enabled = false;
            }
            else
                SetControls(valid);
        }

        public int GetModifier()
        {
            if (chkNegFour.Checked)
                return -4;
            else if (chkNegTwo.Checked)
                return -2;
            else if (chkPlusTwo.Checked)
                return 2;
            else if (chkPlusFour.Checked)
                return 4;
            else
                return 0;
        }

        private void Generic_CheckedChanged(object sender, EventArgs e)
        {
            if (((CheckBox)sender).Checked == true)
            {
                suppressEvents = true;

                if (chkNegFour != sender)
                    chkNegFour.Checked = false;

                if (chkNegTwo != sender)
                    chkNegTwo.Checked = false;

                if (chkPlusTwo != sender)
                    chkPlusTwo.Checked = false;

                if (chkPlusFour != sender)
                    chkPlusFour.Checked = false;

                suppressEvents = false;
            }

            if ((!suppressEvents) && (SelectionUpdated != null))
                SelectionUpdated(this, new ItemCheckEventArgs(ButtonModifier(sender), ((CheckBox)sender).CheckState, ((CheckBox)sender).CheckState));
        }

        private int ButtonModifier(object sender)
        {
            if (sender == chkNegFour)
                return -4;
            else if (sender == chkNegTwo)
                return -2;
            else if (sender == chkPlusTwo)
                return 2;
            else if (sender == chkPlusFour)
                return 4;
            else
                return 0;
        }
    }
}
