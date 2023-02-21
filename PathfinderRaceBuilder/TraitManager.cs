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
    public partial class TraitManager : UserControl
    {
        public RaceTraitLink myLink = null;
        public bool readOnly;
        public event EventHandler NotifyChange;
        public event EventHandler RemoveTrait;
        public event EventHandler ReValidate;

        public bool valid
        {
            get
            {
                return ((btnSettings == null) || (btnSettings.ForeColor != Color.Red));
            }
        }

        public TraitManager()
        {
            InitializeComponent();
        }

        public void UpdateLink(RaceTraitLink linkMe, bool locked = false)
        {
            readOnly = locked;

            // If readonly and we're linking for the first time, remove user controls.
            if ((readOnly) && (myLink == null))
            {
                Controls.Remove(lblPoints);
                Controls.Remove(btnRemove);
                lblPoints = null;
                btnRemove = null;
                Size = new Size(Size.Width, 25);
            }

            myLink = linkMe;

            UpdateDisplay();

            if (myLink.trait.settingsFunction == null)
            {
                Controls.Remove(btnSettings);
                btnSettings = null;
            }
            /*else
            {
                btnSettings.ForeColor = (myLink.ValidateLink())? Color.Green : Color.Red;
            }*/
        }

        public void UpdateDisplay()
        {
            lblTraitDisplay.Text = myLink.trait.name;

            if (myLink.count > 1)
                lblTraitDisplay.Text += " (" + myLink.count + ')';

            if (lblPoints != null)
                lblPoints.Text = myLink.racePoints.ToString() + " pt" + ((myLink.racePoints == 1) ? "." : "s.");

            if (btnSettings != null)
                btnSettings.ForeColor = (myLink.ValidateLink()) ? Color.Green : Color.Red;
        }

        public void SetTooltips(ToolTip tipMe)
        {
            string tmpDescription = Utils.SimpleWordWrap(myLink.trait.GetDescription(myLink.count - 1), RaceBuilderForm.tooltipWordWrap);
            tipMe.SetToolTip(this, tmpDescription);
            tipMe.SetToolTip(lblTraitDisplay, tmpDescription);
            if (!readOnly)
                tipMe.SetToolTip(lblPoints, tmpDescription);
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            if (myLink.trait.settingsFunction(myLink.trait, myLink.count, ref myLink.traitData))
                NotifyChange(null, null);

            btnSettings.ForeColor = (myLink.trait.Validate(myLink.count, myLink.traitData)) ? Color.Green : Color.Red;

            UpdateDisplay();

            ReValidate(null, null);
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            RemoveTrait(this, e);
        }
    }
}
