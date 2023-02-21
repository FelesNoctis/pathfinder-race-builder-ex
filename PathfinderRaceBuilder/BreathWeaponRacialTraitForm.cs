using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PathfinderRaceBuilder
{
    public partial class BreathWeaponRacialTraitForm : Form
    {
        private int rankCount;
        public BreathWeaponRacialTraitForm()
        {
            InitializeComponent();
        }

        public void SetSelections(int ranks, string[] info)
        {
            rankCount = ranks;

            cbxArea.Items.Add("15-foot cone");
            cbxArea.Items.Add("20-foot line");

            cbxDamageType.SelectedItem = info[0];

            if (ranks > 1)
            {
                int tmpVal;

                cbxArea.Items.Add("30-foot cone");
                cbxArea.Items.Add("50-foot line");

                tmpVal = 0;
                int.TryParse(info[1], out tmpVal);
                nudExtraTimes.Value = Math.Min(tmpVal, nudExtraTimes.Maximum);

                tmpVal = 0;
                int.TryParse(info[3], out tmpVal);
                nudIncreasedDamage.Value = Math.Min(tmpVal, nudIncreasedDamage.Maximum);

                tmpVal = 0;
                int.TryParse(info[4], out tmpVal);
                chkPowerful.Checked = (tmpVal == 1);
            }
            else
                nudExtraTimes.Enabled = nudIncreasedDamage.Enabled = chkPowerful.Enabled = false;

            for (int i = 0; i < cbxArea.Items.Count; i++)
            {
                if (cbxArea.Items[i].ToString().StartsWith(info[2].ToString()))
                {
                    cbxArea.SelectedIndex = i;
                    break;
                }
            }

            ValidateSelections();
        }

        public string GetSelection(int index)
        {
            switch (index)
            {
                case 0:
                    return cbxDamageType.SelectedItem.ToString();
                case 1:
                    return nudExtraTimes.Value.ToString();
                case 2:
                    if (cbxArea.SelectedIndex > -1)
                        return cbxArea.SelectedItem.ToString().Substring(0, 2);
                    else
                        return string.Empty;
                case 3:
                    return nudIncreasedDamage.Value.ToString();
                case 4:
                    if (chkPowerful.Checked)
                        return "1";
                    else
                        return "0";
                default:
                    return string.Empty;
            }
        }

        public bool ValidateSelections()
        {
            bool result = true;

            int ranks = 1;

            if (cbxDamageType.SelectedIndex == -1)
                result = false;

            if ((rankCount > 1) && (cbxArea.SelectedIndex > 1))
                ranks++;
            else if (cbxArea.SelectedIndex == -1)
                result = false;

            ranks += (int)nudExtraTimes.Value + (int)nudIncreasedDamage.Value;

            if (chkPowerful.Checked)
                ranks++;

            if (ranks < rankCount)
            {
                nudExtraTimes.Enabled = nudIncreasedDamage.Enabled = chkPowerful.Enabled = true;

                nudExtraTimes.Maximum = nudExtraTimes.Value + (rankCount - ranks);
                nudIncreasedDamage.Maximum = nudIncreasedDamage.Value + (rankCount - ranks);

                btnOkay.Enabled = false;
            }
            else if (ranks == rankCount)
            {
                nudExtraTimes.Enabled = nudIncreasedDamage.Enabled = chkPowerful.Enabled = true;

                if (nudExtraTimes.Value == 0)
                    nudExtraTimes.Enabled = false;
                else
                    nudExtraTimes.Maximum = nudExtraTimes.Value;

                if (nudIncreasedDamage.Value == 0)
                    nudIncreasedDamage.Enabled = false;
                else
                    nudIncreasedDamage.Maximum = nudIncreasedDamage.Value;

                if (!chkPowerful.Checked)
                    chkPowerful.Enabled = false;

                btnOkay.Enabled = result;
            }
            else // ranks > rankCount
            {
                nudExtraTimes.Enabled = nudIncreasedDamage.Enabled = chkPowerful.Enabled = true;

                if (nudExtraTimes.Value == 0)
                    nudExtraTimes.Enabled = false;
                else
                    nudExtraTimes.Maximum = nudExtraTimes.Value;

                if (nudIncreasedDamage.Value == 0)
                    nudIncreasedDamage.Enabled = false;
                else
                    nudIncreasedDamage.Maximum = nudIncreasedDamage.Value;

                chkPowerful.Enabled = chkPowerful.Checked;
                btnOkay.Enabled = false;
            }

            return (ranks <= rankCount);
        }

        private void cbxDamageType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ValidateSelections();
        }

        private void cbxArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((!ValidateSelections()) && (cbxArea.SelectedIndex > 1))
                cbxArea.SelectedIndex = -1;
        }

        private void nudExtraTimes_ValueChanged(object sender, EventArgs e)
        {
            ValidateSelections();
        }

        private void nudIncreasedDamage_ValueChanged(object sender, EventArgs e)
        {
            ValidateSelections();
        }

        private void chkPowerful_CheckedChanged(object sender, EventArgs e)
        {
            ValidateSelections();
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
