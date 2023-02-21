using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using PathfinderSystem;

namespace PathfinderRaceBuilder
{
    public partial class RaceBuilderForm : Form
    {
        public const int tooltipWordWrap = 120;

        private static readonly string[] attributePackageDescription =
        {
            // Advanced
            "Pick either mental or physical ability scores. Members of this race gain a +2 bonus to all of those scores, a +4 bonus to one score of the other type, and a -2 penalty to one other ability score of the other type.",
            // Flexible
            "Members of this race gain a +2 bonus to any two ability scores.",
            // Greater Paragon
            "Members of this race gain a +4 bonus to one ability score, a -2 penalty to one physical ability score, and a -2 penalty to one mental ability score.",
            // Greater Weakness
            "Pick either mental or physical ability scores. Members of this race take a -4 penalty to one of those ability scores, a -2 penalty to another of those ability scores, and a +2 bonus to the other ability score.",
            // Human Heritage
            "Members of this race gain a +2 to any single ability score of your choice during character creation. (Prerequisite: Human subtype.)",
            // Mixed Weakness
            "Pick either mental or physical ability scores. Members of this race gain a +2 bonus to one ability score of that type and a –2 penalty to another ability score of that type. They also gain a +2 bonus to one ability score of the other type and a -4 penalty to another ability score of the other type.",
            // Paragon
            "Members of this race gain a +4 bonus to a single ability score, and a -2 penalty to either all physical or all mental ability scores. If the bonus is to a single physical ability score, the penalties apply to all mental ability scores, and vice versa.",
            // Specialized
            "Pick either mental or physical ability scores. Members of this race gain a +2 bonus to two ability scores of the chosen type, and a -2 penalty to one ability score of the other type.",
            // Standard
            "Members of this race gain a +2 bonus to one physical ability score, a +2 bonus to one mental ability score, and a -2 penalty to any other ability score.",
            // Weakness
            "Members of this race gain a +2 bonus to one physical ability score, a +2 bonus to one mental ability score, and a -4 penalty to any other ability score.",
        };

        private bool changed
        {
            get
            {
                return changedInt;
            }

            set
            {
                changedInt = value;

                Text = "Pathfinder Race Builder";
                if (value)
                    Text += '*';
            }
        }
        internal bool changedInt = false;
        private bool setPlural = false;
        private AttributeControl[] attributePanels;
        private int[] attributeValues = new int[6];

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, Int32 wMsg, bool wParam, Int32 lParam);

        private const int WM_SETREDRAW = 11;

        public void SuspendDrawing()
        {
            SendMessage(Handle, WM_SETREDRAW, false, 0);
        }

        public void ResumeDrawing()
        {
            SendMessage(Handle, WM_SETREDRAW, true, 0);
            Refresh();
        }

        public RaceBuilderForm()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.PFRBIcon;

            atcSTR.SetAbility("STR");
            atcDEX.SetAbility("DEX");
            atcCON.SetAbility("CON");
            atcINT.SetAbility("INT");
            atcWIS.SetAbility("WIS");
            atcCHA.SetAbility("CHA");

            attributePanels = new AttributeControl[6];
            attributePanels[0] = atcSTR;
            attributePanels[1] = atcDEX;
            attributePanels[2] = atcCON;
            attributePanels[3] = atcINT;
            attributePanels[4] = atcWIS;
            attributePanels[5] = atcCHA;

            foreach (CreatureType curType in Globals.raceTypeDB.Values)
                cbxCreatureType.Items.Add(curType.name + " - " + curType.buildPoints + " pts.");

            txtSubtype.AutoCompleteCustomSource.AddRange(Race.commonSubtypes);

            TraitCallbacks.SetCallbacks();

            UpdateRaceDeletion();
            ClearTraitInfo();
        }

        /// <summary>
        /// Saves the race database to file.
        /// </summary>
        private void CommitRaceDatabase()
        {
            XmlTextWriter saveMe = new XmlTextWriter(System.Environment.CurrentDirectory + "\\Data\\Custom" + Globals.raceDB.path, Encoding.UTF8);
            saveMe.Formatting = Formatting.Indented;
            saveMe.Indentation = 4;

            saveMe.WriteStartDocument();

            saveMe.WriteStartElement("RaceDatabase");

            foreach (Race curRace in Globals.raceDB.Values)
            {
                if (!curRace.paizo)
                    curRace.Save(saveMe);
            }

            saveMe.WriteEndElement();

            saveMe.WriteEndDocument();
            saveMe.Close();

            UpdateRaceDeletion();
        }

        /// <summary>
        /// Checks the race database and enables the 'Delete Race...' menu item if it contains any custom ones.
        /// </summary>
        private void UpdateRaceDeletion()
        {
            foreach (Race curRace in Globals.raceDB.Values)
            {
                if (!curRace.paizo)
                {
                    mniDeleteRaces.Enabled = true;
                    return;
                }
            }

            mniDeleteRaces.Enabled = false;
        }

        /// <summary>
        /// Clears the current race information and calls ResetFields.
        /// </summary>
        private void ClearRace()
        {
            SuspendDrawing();
            Globals.character.race = new Race();
            ResetFields();
            changed = setPlural = mniSave.Enabled = false;
            ResumeDrawing();
        }

        /// <summary>
        /// Saves the current race to the race database and calls CommitRaceDatabase.
        /// </summary>
        private void SaveRace()
        {
            if (Globals.raceDB.Keys.Contains(Globals.character.race.name))
            {
                if (Globals.raceDB[Globals.character.race.name].paizo)
                {
                    MessageBox.Show(Globals.character.race.namePlural + " are a Paizo race and may not be overwritten." + System.Environment.NewLine + System.Environment.NewLine + "Please save this race under a different name.");
                    return;
                }
                else
                    Globals.raceDB.Remove(Globals.character.race.name);
            }

            Globals.raceDB.Add(Globals.character.race);

            CommitRaceDatabase();

            changed = false;
        }

        /// <summary>
        /// Fills all of the fields based on the current race.  Used after loading a race.
        /// </summary>
        private void FillRaceFields()
        {
            SuspendDrawing();
            txtRaceName.Text = Globals.character.race.name;
            txtRacePlural.Text = Globals.character.race.namePlural;
            txtRaceAdjective.Text = Globals.character.race.nameAdjective;
            txtRaceFlavorText.Text = Globals.character.race.flavorText;
            txtPhysicalAppearance.Text = Globals.character.race.appearanceDescription;
            cbxPowerLevel.SelectedIndex = Math.Max(0, Math.Min((Globals.character.race.raceBuilderPoints - 1) / 10, cbxPowerLevel.Items.Count - 1));
            FillComboBox(cbxLanguages, Globals.character.race.languageQuality.ToString().Substring(0, 3)); // Fill languages box early to get around automatic filling logic.
            FillComboBox(cbxCreatureType, Globals.character.race.type.name.Replace(" ", string.Empty));
            FillComboBox(cbxSize, Globals.character.race.size.ToString());
            txtSubtype.Text = Globals.character.race.subtype;
            cbxSpeedQuality.SelectedIndex = (Globals.character.race.baseSpeed == 20) ? 1 : 0;
            FillComboBox(cbxAttributeSelection, Globals.character.race.attributePackage.ToString());
            
            SetLanguageButton(ValidateLanguages());
            DetermineAttributeParameters(null);

            for (int i = 0; i < 6; i++)
            {
                attributePanels[i].SetValue(Globals.character.race.attributeModifiers[i]);
                DetermineAttributeParameters(null);
            }

            foreach (RaceTraitLink curLink in Globals.character.race.traits)
                AddTraitToRace(curLink.trait.name, false, true);

            changed = mniSave.Enabled = false;

            ResumeDrawing();
        }

        /// <summary>
        /// Subroutine for FillRaceFields that tries to select a combobox item if it can.
        /// </summary>
        private void FillComboBox(ComboBox fillMe, string matchMe)
        {
            for (int i = 0; i < fillMe.Items.Count; i++)
            {
                if (((string)fillMe.Items[i]).Replace(" ", string.Empty).StartsWith(matchMe))
                {
                    fillMe.SelectedIndex = i;
                    return;
                }
            }
        }

        /// <summary>
        /// Resets all the fields on the form.
        /// </summary>
        private void ResetFields()
        {
            tbcMain.SelectedTab = tabDesign;
            txtRaceName.Text = txtRacePlural.Text = txtRaceAdjective.Text = txtSubtype.Text = txtRaceFlavorText.Text = txtPhysicalAppearance.Text = string.Empty;
            cbxPowerLevel.SelectedIndex = cbxCreatureType.SelectedIndex = cbxSize.SelectedIndex = cbxSpeedQuality.SelectedIndex = cbxAttributeSelection.SelectedIndex = cbxLanguages.SelectedIndex = cbxTraitCategory.SelectedIndex = lstTraitPool.SelectedIndex = -1;
            pnlSelectedTraits.Controls.Clear();
            txtTotalPoints.Text = "0";
        }

        /// <summary>
        /// Marks the race changed, recalculates race point total, and validates race.  Called any time a change is made to the race.
        /// </summary>
        private void ProcessChange()
        {
            changed = true;
            txtTotalPoints.Text = Globals.character.race.raceBuilderPoints.ToString();
            ValidateRace();
        }

        /// <summary>
        /// Shows the dialog to choose from the existing races.
        /// </summary>
        /// <param name="newForm">Whether the dialog will use the startup version that has the 'New' button.</param>
        private void ShowRaceSelection(bool newForm)
        {
            RaceSelectionForm selectRace = new RaceSelectionForm();
            selectRace.btnCancel.Enabled = !newForm;
            selectRace.btnNew.Visible = newForm;

            switch (selectRace.ShowDialog())
            {
                case System.Windows.Forms.DialogResult.OK:
                    string raceName = selectRace.cbxSelectedRace.Text.Substring(0, selectRace.cbxSelectedRace.Text.LastIndexOf(" - ")).Trim();
                    ResetFields();
                    Globals.character.race = Globals.raceDB[raceName].Duplicate();
                    FillRaceFields();
                    break;
                case System.Windows.Forms.DialogResult.Retry:
                    ClearRace();
                    break;
            }
        }

        /// <summary>
        /// A simple function to be used when leaving this race (by loading or starting anew), ensuring the user can save changes if desired.
        /// </summary>
        /// <returns>Whether the user wishes to proceed.</returns>
        private bool ConfirmChanges()
        {
            if ((changed) && (mniSave.Enabled))
            {
                switch (MessageBox.Show("Save Changes?", "You have unsaved changes.  Would you like to save them now?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation))
                {
                    case System.Windows.Forms.DialogResult.Yes:
                        SaveRace();
                        return true;
                    case System.Windows.Forms.DialogResult.No:
                        return true;
                    default:
                        return false;
                }
            }

            return true;
        }

        #region AttributeLogic
        /// <summary>
        /// Enforces logic for Advanced attributes:
        /// Pick either mental or physical ability scores. Members of this race gain a +2 bonus to all of those scores, a +4 bonus to one score of the other type, and a –2 penalty to one other ability score of the other type.
        /// </summary>
        /// <param name="e">Callback so we can tell if the user is trying to deselect the scores that all received +2.</param>
        /// <returns>Whether the attribute selections are valid or not.</returns>
        private bool AttributeLogic_Advanced(int lowest, int highest, EventArgs e)
        {
            int i, j;
            bool complete = false;

            // If 4 is picked somewhere, lock the other att type into +2's, and only allow -2/+4 in the att type that has it.
            if (attributeValues[highest] == 4)
            {
                j = (attributePanels[highest].physical) ? 3 : 0;

                for (i = j; i < j + 3; i++)
                    attributePanels[i].LockControls(true, 2);

                j = (attributePanels[highest].physical) ? 0 : 3;

                for (i = j; i < j + 3; i++)
                {
                    if (i == highest)
                        attributePanels[i].SetControls(AttributeControl.ValidValues.PlusFour);
                    else
                        attributePanels[i].SetControls(AttributeControl.ValidValues.NegTwo);
                }
            }
            // If 2 is the highest we have, then selection isn't complete.  But we can see if we need to lock down the side that has it.
            else if (attributeValues[highest] == 2)
            {
                // Alternatively, the user may be trying to turn off the +2's, in which case we reset them.
                if ((e != null) && (((ItemCheckEventArgs)e).Index == 2) && (((ItemCheckEventArgs)e).CurrentValue == CheckState.Unchecked))
                {
                    j = (attributePanels[highest].physical) ? 0 : 3;

                    for (i = j; i < j + 3; i++)
                    {
                        attributePanels[i].SetControls(AttributeControl.ValidValues.PlusTwo);
                        attributePanels[i].SetValue(0);
                    }

                    for (i = 0; i < 6; i++)
                    {
                        attributeValues[i] = attributePanels[i].GetModifier();

                        if (attributeValues[i] > attributeValues[highest])
                            highest = i;

                        if (attributeValues[i] < attributeValues[lowest])
                            lowest = i;
                    }
                }
                else
                {
                    j = (attributePanels[highest].physical) ? 0 : 3;

                    for (i = j; i < j + 3; i++)
                    {
                        attributePanels[i].SetControls(AttributeControl.ValidValues.PlusTwo);
                        attributePanels[i].SetValue(2);
                    }

                    j = (attributePanels[highest].physical) ? 3 : 0;

                    for (i = j; i < j + 3; i++)
                        attributePanels[i].SetControls(AttributeControl.ValidValues.NegTwo | AttributeControl.ValidValues.PlusFour);
                }
            }

            // If -2 is picked somewhere, lock the other att type into +2's, and only allow -2/+4 in the att type that has it.
            if (attributeValues[lowest] == -2)
            {
                j = (attributePanels[lowest].physical) ? 3 : 0;

                for (i = j; i < j + 3; i++)
                    attributePanels[i].LockControls(true, 2);

                j = (attributePanels[lowest].physical) ? 0 : 3;

                for (i = j; i < j + 3; i++)
                {
                    if (i == lowest)
                        attributePanels[i].SetControls(AttributeControl.ValidValues.NegTwo);
                    else
                        attributePanels[i].SetControls(attributePanels[i].valid & ~(AttributeControl.ValidValues.NegTwo | AttributeControl.ValidValues.PlusTwo));
                }

                complete = (attributeValues[highest] == 4);
            }

            // If nothing is picked, default everything to -2/+2/+4.
            if ((attributeValues[lowest] == 0) && (attributeValues[highest] == 0))
            {
                for (i = 0; i < 6; i++)
                    attributePanels[i].SetControls(AttributeControl.ValidValues.NegTwo | AttributeControl.ValidValues.PlusTwo | AttributeControl.ValidValues.PlusFour);
            }

            return complete;
        }

        /// <summary>
        /// Enforces logic for Flexible attributes:
        /// Members of this race gain a +2 bonus to any two ability scores.
        /// </summary>
        /// <returns>Whether the attribute selections are valid or not.</returns>
        private bool AttributeLogic_Flexible(int highest)
        {
            int i, j = 0;

            for (i = 0; i < 6; i++)
            {
                if (attributeValues[i] != 0)
                    j++;
            }

            if (j < 2)
            {
                for (i = 0; i < 6; i++)
                    attributePanels[i].SetControls(AttributeControl.ValidValues.PlusTwo);
            }
            else
            {
                for (i = 0; i < 6; i++)
                {
                    if (attributeValues[i] > 0)
                        attributePanels[i].SetControls(AttributeControl.ValidValues.PlusTwo);
                    else
                        attributePanels[i].SetControls(AttributeControl.ValidValues.None);
                }

                return true;
            }

            return false;
        }

        /// <summary>
        /// Enforces logic for Greater Paragon attributes:
        /// Members of this race gain a +4 bonus to one ability score, a –2 penalty to one physical ability score, and a –2 penalty to one mental ability score.
        /// </summary>
        /// <returns>Whether the attribute selections are valid or not.</returns>
        private bool AttributeLogic_GreaterParagon(int lowest, int highest)
        {
            int i, j;
            bool complete = false;

            if (attributeValues[highest] == 4)
            {
                for (i = 0; i < 6; i++)
                {
                    if (i == highest)
                        attributePanels[i].SetControls(AttributeControl.ValidValues.PlusFour);
                    else
                        attributePanels[i].SetControls(AttributeControl.ValidValues.NegTwo);
                }
            }
            else if (attributeValues[highest] == 0)
            {
                for (i = 0; i < 6; i++)
                {
                    if (attributeValues[i] == -2)
                        attributePanels[i].SetControls(AttributeControl.ValidValues.NegTwo);
                    else
                        attributePanels[i].SetControls(attributePanels[i].valid | AttributeControl.ValidValues.PlusFour);
                }
            }

            if (attributeValues[lowest] == -2)
            {
                j = (attributePanels[lowest].physical) ? 0 : 3;

                for (i = j; i < j + 3; i++)
                {
                    if (i == lowest)
                        attributePanels[i].SetControls(AttributeControl.ValidValues.NegTwo);
                    else
                        attributePanels[i].SetControls(attributePanels[i].valid & ~(AttributeControl.ValidValues.NegTwo));
                }

                // Check to see if -2 is also selected in the other group.
                j = (attributePanels[lowest].physical) ? 3 : 0;

                for (i = j; i < j + 3; i++)
                {
                    if (attributeValues[i] == -2)
                        break;
                }

                if (i != j + 3)
                {
                    lowest = i;

                    for (i = j; i < j + 3; i++)
                    {
                        if (i == lowest)
                            attributePanels[i].SetControls(AttributeControl.ValidValues.NegTwo);
                        else
                            attributePanels[i].SetControls(attributePanels[i].valid & ~(AttributeControl.ValidValues.NegTwo));
                    }

                    complete = (attributeValues[highest] == 4);
                }
                else
                {
                    for (i = j; i < j + 3; i++)
                    {
                        if (attributeValues[i] == 4)
                            attributePanels[i].SetControls(AttributeControl.ValidValues.PlusFour);
                        else
                            attributePanels[i].SetControls(attributePanels[i].valid | AttributeControl.ValidValues.NegTwo);
                    }
                }
            }

            // If nothing is picked, default everything to -2/+4.
            if ((attributeValues[lowest] == 0) && (attributeValues[highest] == 0))
            {
                for (i = 0; i < 6; i++)
                    attributePanels[i].SetControls(AttributeControl.ValidValues.NegTwo | AttributeControl.ValidValues.PlusFour);
            }

            return complete;
        }

        /// <summary>
        /// Enforces logic for Greater Weakness attributes:
        /// Members of this race take a –4 penalty to one of those ability scores, a –2 penalty to another of those ability scores, and a +2 bonus to the other ability score.
        /// </summary>
        /// <returns>Whether the attribute selections are valid or not.</returns>
        private bool AttributeLogic_GreaterWeakness(int lowest, int highest, EventArgs e)
        {
            int i, j;
            bool complete = false;

            /*
            if (attributeValues[highest] == 2)
            {
                j = (attributePanels[highest].physical) ? 0 : 3;

                for (i = j; i < j + 3; i++)
                {
                    if (i == highest)
                        attributePanels[i].SetControls(AttributeControl.ValidValues.PlusTwo);
                    else
                        attributePanels[i].SetControls(AttributeControl.ValidValues.None);
                }

                j = (attributePanels[highest].physical) ? 3 : 0;

                for (i = j; i < j + 3; i++)
                    attributePanels[i].SetControls(AttributeControl.ValidValues.NegFour | AttributeControl.ValidValues.NegTwo);
            }

            if (attributeValues[lowest] == -4)
            {
                j = (attributePanels[lowest].physical) ? 0 : 3;

                for (i = j; i < j + 3; i++)
                {
                    if (i == lowest)
                        attributePanels[i].SetControls(AttributeControl.ValidValues.NegFour);
                    else
                        attributePanels[i].SetControls(AttributeControl.ValidValues.NegTwo);
                }

                j = (attributePanels[lowest].physical) ? 3 : 0;

                if (attributeValues[highest] == 2)
                {
                    for (i = j; i < j + 3; i++)
                        attributePanels[i].SetControls(attributePanels[i].valid & AttributeControl.ValidValues.PlusTwo);
                }
                else
                    for (i = j; i < j + 3; i++)
                        attributePanels[i].SetControls(AttributeControl.ValidValues.PlusTwo);

                // Look to see if we have a -2 selected
                j = (attributePanels[lowest].physical) ? 0 : 3;

                for (i = j; i < j + 3; i++)
                {
                    if (attributeValues[i] == -2)
                        break;
                }

                // If we found one, jump right back into a loop to cleanup valid options.
                if (i < j + 3)
                {
                    for (i = j; i < j + 3; i++)
                    {
                        if (attributeValues[i] == -2)
                            attributePanels[i].SetControls(AttributeControl.ValidValues.NegTwo);
                        else if (attributeValues[i] == -4)
                            attributePanels[i].SetControls(AttributeControl.ValidValues.NegFour);
                        else
                            attributePanels[i].SetControls(AttributeControl.ValidValues.None);
                    }

                    complete = (attributeValues[highest] == 2);
                }
            }
            else if (attributeValues[lowest] == -2)
            {
                j = (attributePanels[lowest].physical) ? 0 : 3;

                for (i = j; i < j + 3; i++)
                {
                    if (i == lowest)
                        attributePanels[i].SetControls(AttributeControl.ValidValues.NegTwo);
                    else
                        attributePanels[i].SetControls(AttributeControl.ValidValues.NegFour);
                }

                j = (attributePanels[lowest].physical) ? 3 : 0;

                if (attributeValues[highest] == 2)
                {
                    for (i = j; i < j + 3; i++)
                        attributePanels[i].SetControls(attributePanels[i].valid & AttributeControl.ValidValues.PlusTwo);
                }
                else
                    for (i = j; i < j + 3; i++)
                        attributePanels[i].SetControls(AttributeControl.ValidValues.PlusTwo);
            }
            */

            if (attributeValues[highest] == 2)
            {
                j = (attributePanels[highest].physical) ? 0 : 3;

                for (i = j; i < j + 3; i++)
                {
                    if (i == highest)
                        attributePanels[i].SetControls(AttributeControl.ValidValues.PlusTwo);
                    else
                        attributePanels[i].SetControls(AttributeControl.ValidValues.NegFour | AttributeControl.ValidValues.NegTwo);
                }
            }

            if (attributeValues[lowest] == -4)
            {
                j = (attributePanels[lowest].physical) ? 0 : 3;

                if (attributeValues[highest] > 0)
                {
                    for (i = j; i < j + 3; i++)
                    {
                        if (i == lowest)
                            attributePanels[i].SetControls(AttributeControl.ValidValues.NegFour);
                        else
                            attributePanels[i].SetControls(attributePanels[i].valid & ~(AttributeControl.ValidValues.NegFour));
                    }
                }
                else
                {
                    for (i = j; i < j + 3; i++)
                    {
                        if (i == lowest)
                            attributePanels[i].SetControls(AttributeControl.ValidValues.NegFour);
                        else
                            attributePanels[i].SetControls(AttributeControl.ValidValues.NegTwo | AttributeControl.ValidValues.PlusTwo);
                    }
                }

                // Check for completeness if the user hasn't just deselected an item.
                if ((e == null) || !(((((ItemCheckEventArgs)e).Index == 2) || (((ItemCheckEventArgs)e).Index == -2)) && (((ItemCheckEventArgs)e).CurrentValue == CheckState.Unchecked)))
                {
                    if (attributeValues[highest] > 0)
                        complete = true;
                    else
                    {
                        for (i = j; i < j + 3; i++)
                        {
                            if (attributeValues[i] == -2)
                            {
                                complete = true;
                                break;
                            }
                        }
                    }

                    // Make sure the last selection is set.
                    if (complete)
                    {
                        for (i = j; i < j + 3; i++)
                        {
                            if (attributeValues[i] == 0)
                            {
                                if (attributeValues[highest] > 0)
                                    attributePanels[i].SetValue(-2);
                                else
                                    attributePanels[i].SetValue(2);
                            }
                        }
                    }
                }
            }
            else if (attributeValues[lowest] == -2)
            {
                j = (attributePanels[lowest].physical) ? 0 : 3;

                for (i = j; i < j + 3; i++)
                {
                    if (i == lowest)
                        attributePanels[i].SetControls(AttributeControl.ValidValues.NegTwo);
                    else
                        attributePanels[i].SetControls(attributePanels[i].valid & ~(AttributeControl.ValidValues.NegTwo));
                }
            }

            // If nothing is picked, default everything to -4/-2/+2.
            if ((attributeValues[lowest] == 0) && (attributeValues[highest] == 0))
            {
                for (i = 0; i < 6; i++)
                    attributePanels[i].SetControls(AttributeControl.ValidValues.NegFour | AttributeControl.ValidValues.NegTwo | AttributeControl.ValidValues.PlusTwo);
            }
            else // ...if something is picked, disable the opposite attribute group.
            {
                if (highest > 0)
                    j = (attributePanels[highest].physical) ? 3 : 0;
                else
                    j = (attributePanels[lowest].physical) ? 3 : 0;

                for (i = j; i < j + 3; i++)
                    attributePanels[i].SetControls(AttributeControl.ValidValues.None);
            }

            return complete;
        }

        /// <summary>
        /// Enforces logic for Human Heritage attributes:
        /// Members of this race gain a +2 to any single ability score of your choice during character creation.
        /// </summary>
        /// <returns>Always true.</returns>
        private bool AttributeLogic_HumanHeritage()
        {
            for (int i = 0; i < 6; i++)
                attributePanels[i].SetControls(AttributeControl.ValidValues.None);

            return true;
        }

        /// <summary>
        /// Enforces logic for Mixed Weakness attributes:
        /// Members of this race gain a +2 bonus to one ability score of that type and a –2 penalty to another ability score of that type. They also gain a +2 bonus to one ability score of the other type and a –4 penalty to another ability score of the other type.
        /// </summary>
        /// <returns>Whether the attribute selections are valid or not.</returns>
        private bool AttributeLogic_MixedWeakness(int lowest, int highest)
        {
            int i, j;
            bool complete = false;

            if (attributeValues[highest] == 2)
            {
                j = (attributePanels[highest].physical) ? 0 : 3;

                for (i = j; i < j + 3; i++)
                {
                    if (i == highest)
                        attributePanels[i].SetControls(AttributeControl.ValidValues.PlusTwo);
                    else
                        attributePanels[i].SetControls(AttributeControl.ValidValues.NegFour | AttributeControl.ValidValues.NegTwo);
                }

                j = (attributePanels[highest].physical) ? 3 : 0;

                for (i = j; i < j + 3; i++)
                {
                    if (attributeValues[i] == 2)
                        break;
                }

                if (i < j + 3)
                {
                    for (i = j; i < j + 3; i++)
                    {
                        if (attributeValues[i] == 2)
                            attributePanels[i].SetControls(AttributeControl.ValidValues.PlusTwo);
                        else
                            attributePanels[i].SetControls(attributePanels[i].valid & ~(AttributeControl.ValidValues.PlusTwo));
                    }
                }
                else
                {
                    for (i = j; i < j + 3; i++)
                    {
                        if (attributeValues[i] == 0)
                            attributePanels[i].SetControls(attributePanels[i].valid | AttributeControl.ValidValues.PlusTwo);
                    }
                }
            }
            else if (attributeValues[highest] == 0)
            {
                for (i = 0; i < 6; i++)
                {
                    if (attributeValues[i] == 0)
                        attributePanels[i].SetControls(AttributeControl.ValidValues.NegFour | AttributeControl.ValidValues.NegTwo | AttributeControl.ValidValues.PlusTwo);
                }
            }

            if (attributeValues[lowest] == -4)
            {
                j = (attributePanels[lowest].physical) ? 0 : 3;

                for (i = j; i < j + 3; i++)
                {
                    if (i == lowest)
                        attributePanels[i].SetControls(AttributeControl.ValidValues.NegFour);
                    else
                        attributePanels[i].SetControls(attributePanels[i].valid & ~(AttributeControl.ValidValues.NegFour | AttributeControl.ValidValues.NegTwo));
                }

                j = (attributePanels[lowest].physical) ? 3 : 0;

                for (i = j; i < j + 3; i++)
                {
                    attributePanels[i].SetControls(attributePanels[i].valid & ~(AttributeControl.ValidValues.NegFour));
                }

                // Look to see if we have a -2 selected
                for (i = j; i < j + 3; i++)
                {
                    if (attributeValues[i] == -2)
                        break;
                }

                // If we found one, jump right back into a loop to cleanup valid options.
                if (i < j + 3)
                {
                    for (i = j; i < j + 3; i++)
                    {
                        if (attributeValues[i] == -2)
                            attributePanels[i].SetControls(AttributeControl.ValidValues.NegTwo);
                        else
                            attributePanels[i].SetControls(attributePanels[i].valid & ~(AttributeControl.ValidValues.NegTwo));
                    }

                    j = 0;

                    // Tally the +2's to see if we're done!
                    for (i = 0; i < 6; i++)
                    {
                        if (attributeValues[i] > 0)
                            j++;
                    }

                    complete = (j == 2);
                }
                else
                {
                    for (i = j; i < j + 3; i++)
                    {
                        if (attributeValues[i] == 0)
                            attributePanels[i].SetControls(attributePanels[i].valid | AttributeControl.ValidValues.NegTwo);
                    }
                }

            }
            else if (attributeValues[lowest] == -2)
            {
                j = (attributePanels[lowest].physical) ? 0 : 3;

                for (i = j; i < j + 3; i++)
                {
                    if (i == lowest)
                        attributePanels[i].SetControls(AttributeControl.ValidValues.NegTwo);
                    else
                        attributePanels[i].SetControls(attributePanels[i].valid & ~(AttributeControl.ValidValues.NegFour | AttributeControl.ValidValues.NegTwo));
                }

                j = (attributePanels[lowest].physical) ? 3 : 0;

                for (i = j; i < j + 3; i++)
                {
                    attributePanels[i].SetControls(attributePanels[i].valid & ~(AttributeControl.ValidValues.NegTwo));
                }

            }
            else if (attributeValues[lowest] == 0)
            {
                for (i = 0; i < 6; i++)
                {
                    if (attributeValues[i] == 0)
                        attributePanels[i].SetControls(attributePanels[i].valid | AttributeControl.ValidValues.NegFour | AttributeControl.ValidValues.NegTwo);
                }
            }

            // If nothing is picked, default everything to -4/-2/+2.
            if ((attributeValues[lowest] == 0) && (attributeValues[highest] == 0))
            {
                for (i = 0; i < 6; i++)
                    attributePanels[i].SetControls(AttributeControl.ValidValues.NegFour | AttributeControl.ValidValues.NegTwo | AttributeControl.ValidValues.PlusTwo);
            }

            return complete;
        }

        /// <summary>
        /// Enforces logic for Paragon attributes:
        /// Members of this race gain a +4 bonus to a single ability score, and a –2 penalty to either all physical or all mental ability scores. If the bonus is to a single physical ability score, the penalties apply to all mental ability scores, and vice versa.
        /// </summary>
        /// <param name="e">Callback so we can tell if the user is trying to deselect the scores that all received -2.</param>
        /// <returns>Whether the attribute selections are valid or not.</returns>
        private bool AttributeLogic_Paragon(int lowest, int highest, EventArgs e)
        {
            int i, j;
            bool complete = false;

            // If 4 is picked somewhere, lock the other att type into +2's, and only allow -2/+4 in the att type that has it.
            if (attributeValues[highest] == 4)
            {
                j = (attributePanels[highest].physical) ? 3 : 0;

                for (i = j; i < j + 3; i++)
                    attributePanels[i].LockControls(true, -2);

                j = (attributePanels[highest].physical) ? 0 : 3;

                for (i = j; i < j + 3; i++)
                {
                    if (i == highest)
                        attributePanels[i].SetControls(AttributeControl.ValidValues.PlusFour);
                    else
                        attributePanels[i].SetControls(AttributeControl.ValidValues.None);
                }

                complete = true;
            }
            else if (attributeValues[lowest] == -2)
            {
                // The user may be trying to turn off the -2's, in which case we reset them.
                if ((e != null) && (((ItemCheckEventArgs)e).Index == -2) && (((ItemCheckEventArgs)e).CurrentValue == CheckState.Unchecked))
                {
                    j = (attributePanels[lowest].physical) ? 0 : 3;

                    for (i = j; i < j + 3; i++)
                    {
                        attributePanels[i].SetControls(AttributeControl.ValidValues.NegTwo);
                        attributePanels[i].SetValue(0);
                    }

                    for (i = 0; i < 6; i++)
                    {
                        attributeValues[i] = attributePanels[i].GetModifier();

                        if (attributeValues[i] > attributeValues[highest])
                            highest = i;

                        if (attributeValues[i] < attributeValues[lowest])
                            lowest = i;
                    }
                }
                else
                {
                    j = (attributePanels[lowest].physical) ? 0 : 3;

                    for (i = j; i < j + 3; i++)
                    {
                        attributePanels[i].SetControls(AttributeControl.ValidValues.NegTwo);
                        attributePanels[i].SetValue(-2);
                    }

                    j = (attributePanels[lowest].physical) ? 3 : 0;

                    for (i = j; i < j + 3; i++)
                        attributePanels[i].SetControls(AttributeControl.ValidValues.PlusFour);
                }
            }

            // If nothing is picked, default everything to -2/+4.
            if ((attributeValues[lowest] == 0) && (attributeValues[highest] == 0))
            {
                for (i = 0; i < 6; i++)
                    attributePanels[i].SetControls(AttributeControl.ValidValues.NegTwo | AttributeControl.ValidValues.PlusFour);
            }

            return complete;
        }

        /// <summary>
        /// Enforces logic for Specialized attributes:
        /// Members of this race gain a +2 bonus to two ability scores of the chosen type, and a –2 penalty to one ability score of the other type.
        /// </summary>
        /// <returns>Whether the attribute selections are valid or not.</returns>
        private bool AttributeLogic_Specialized(int lowest, int highest)
        {
            int i, j;
            bool complete = false;

            if (attributeValues[highest] == 2)
            {
                int cnt = 0;

                j = (attributePanels[highest].physical) ? 0 : 3;

                for (i = j; i < j + 3; i++)
                {
                    attributePanels[i].SetControls(AttributeControl.ValidValues.PlusTwo);

                    if (attributeValues[i] > 0)
                        cnt++;
                }

                if (cnt > 1)
                {
                    for (i = j; i < j + 3; i++)
                    {
                        if (attributeValues[i] == 0)
                            attributePanels[i].SetControls(AttributeControl.ValidValues.None);
                    }

                    complete = (attributeValues[lowest] == -2);
                }

                j = (attributePanels[highest].physical) ? 3 : 0;

                for (i = j; i < j + 3; i++)
                    attributePanels[i].SetControls(AttributeControl.ValidValues.NegTwo);
            }

            if (attributeValues[lowest] == -2)
            {
                j = (attributePanels[lowest].physical) ? 0 : 3;

                for (i = j; i < j + 3; i++)
                {
                    if (attributeValues[i] == -2)
                        attributePanels[i].SetControls(AttributeControl.ValidValues.NegTwo);
                    else
                        attributePanels[i].SetControls(AttributeControl.ValidValues.None);
                }

                j = (attributePanels[lowest].physical) ? 3 : 0;

                for (i = j; i < j + 3; i++)
                {
                    attributePanels[i].SetControls(attributePanels[i].valid & ~AttributeControl.ValidValues.NegTwo);
                }
            }

            // If nothing is picked, default everything to -2/+2.
            if ((attributeValues[lowest] == 0) && (attributeValues[highest] == 0))
            {
                for (i = 0; i < 6; i++)
                    attributePanels[i].SetControls(AttributeControl.ValidValues.NegTwo | AttributeControl.ValidValues.PlusTwo);
            }

            return complete;
        }

        /// <summary>
        /// Enforces logic for Standard attributes:
        /// Members of this race gain a +2 bonus to one physical ability score, a +2 bonus to one mental ability score, and a –2 penalty to any other ability score.
        /// </summary>
        /// <returns>Whether the attribute selections are valid or not.</returns>
        private bool AttributeLogic_Standard(int lowest, int highest, AttributeControl.ValidValues dumpStat)
        {
            int i, j;
            bool complete = false;

            if (attributeValues[highest] == 2)
            {
                j = (attributePanels[highest].physical) ? 0 : 3;

                for (i = j; i < j + 3; i++)
                {
                    if (i == highest)
                        attributePanels[i].SetControls(AttributeControl.ValidValues.PlusTwo);
                    else
                        attributePanels[i].SetControls(dumpStat);
                }

                j = (attributePanels[highest].physical) ? 3 : 0;

                for (i = j; i < j + 3; i++)
                {
                    if (attributeValues[i] > 0)
                        break;
                }

                if (i < j + 3)
                {
                    for (i = j; i < j + 3; i++)
                    {
                        if (attributeValues[i] > 0)
                            attributePanels[i].SetControls(AttributeControl.ValidValues.PlusTwo);
                        else
                            attributePanels[i].SetControls(attributePanels[i].valid & ~AttributeControl.ValidValues.PlusTwo);
                    }

                    complete = (attributeValues[lowest] < 0);
                }
                else
                {
                    for (i = j; i < j + 3; i++)
                    {
                        if (attributeValues[i] == 0)
                            attributePanels[i].SetControls(attributePanels[i].valid | AttributeControl.ValidValues.PlusTwo);
                    }

                }
            }

            if (attributeValues[lowest] < 0)
            {
                for (i = 0; i < 6; i++)
                {
                    if (i == lowest)
                        attributePanels[i].SetControls(dumpStat);
                    else
                        attributePanels[i].SetControls(attributePanels[i].valid & ~dumpStat);
                }

                if (attributeValues[highest] == 0)
                {
                    for (i = 0; i < 6; i++)
                    {
                        if (i != lowest)
                            attributePanels[i].SetControls(AttributeControl.ValidValues.PlusTwo);
                    }
                }
            }
            else if (attributeValues[lowest] == 0)
            {
                for (i = 0; i < 6; i++)
                {
                    if (attributeValues[i] == 0)
                        attributePanels[i].SetControls(attributePanels[i].valid | dumpStat);
                }
            }

            // If nothing is picked, default everything to -dump/+2.
            if ((attributeValues[lowest] == 0) && (attributeValues[highest] == 0))
            {
                for (i = 0; i < 6; i++)
                    attributePanels[i].SetControls(dumpStat | AttributeControl.ValidValues.PlusTwo);
            }

            return complete;
        }
        #endregion AttributeLogic

        /// <summary>
        /// Enforces the special race creation rule that large-sized humanoids must have the giant subtype.
        /// </summary>
        private void CheckSubtypeEligibility()
        {
            if ((cbxCreatureType.SelectedIndex > -1) && (Array.Exists<string>(new string[] { "Human", "Half-" }, curString => cbxCreatureType.Text.StartsWith(curString))))
            {
                if ((cbxSize.SelectedIndex > -1) && (cbxSize.SelectedItem.ToString() == "Large - 7 pts."))
                {
                    txtSubtype.Text = "giant";
                    txtSubtype.Enabled = false;
                }
                else
                    txtSubtype.Enabled = true;
            }
            else
            {
                txtSubtype.Text = string.Empty;
                txtSubtype.Enabled = false;
                Globals.character.race.subtype = string.Empty;
            }
        }

        /// <summary>
        /// Called when the attribute settings are changed; funnels the validation logic through the proper function.
        /// </summary>
        /// <param name="e">Callback from the original caller, to be passed to the logic functions if they need it.</param>
        /// <returns>Whether the current attribute selections are valid.</returns>
        private bool DetermineAttributeParameters(EventArgs e)
        {
            int highest = 0;
            int lowest = 0;
            bool complete = false;

            for (int i = 0; i < 6; i++)
            {
                attributeValues[i] = attributePanels[i].GetModifier();

                if (attributeValues[i] > attributeValues[highest])
                    highest = i;

                if (attributeValues[i] < attributeValues[lowest])
                    lowest = i;
            }

            switch (cbxAttributeSelection.Text.Substring(0, Math.Max(cbxAttributeSelection.Text.IndexOf(" - "), 0)))
            {
                // Advanced
                case "Advanced":
                    complete = AttributeLogic_Advanced(lowest, highest, e);
                    break;
                // Flexible
                case "Flexible":
                    complete = AttributeLogic_Flexible(highest);
                    break;
                // Greater Paragon
                case "Greater Paragon":
                    complete = AttributeLogic_GreaterParagon(lowest, highest);
                    break;
                // Greater Weakness
                case "Greater Weakness":
                    complete = AttributeLogic_GreaterWeakness(lowest, highest, e);
                    break;
                // Mixed Weakness
                case "Mixed Weakness":
                    complete = AttributeLogic_MixedWeakness(lowest, highest);
                    break;
                // Paragon
                case "Paragon":
                    complete = AttributeLogic_Paragon(lowest, highest, e);
                    break;
                // Specialized
                case "Specialized":
                    complete = AttributeLogic_Specialized(lowest, highest);
                    break;
                // Standard
                case "Standard":
                    complete = AttributeLogic_Standard(lowest, highest, AttributeControl.ValidValues.NegTwo);
                    break;
                // Weakness
                case "Weakness":
                    complete = AttributeLogic_Standard(lowest, highest, AttributeControl.ValidValues.NegFour);
                    break;
                // Human Heritage
                case "Human Heritage":
                default:
                    complete = AttributeLogic_HumanHeritage();
                    break;
            }

            complete &= (cbxAttributeSelection.SelectedIndex > -1);

            if (complete)
            {
                for (int i = 0; i < 6; i++)
                    Globals.character.race.attributeModifiers[i] = attributePanels[i].GetModifier();

                gbxAttributes.ForeColor = Color.Green;
            }
            else
                gbxAttributes.ForeColor = Color.Red;

            ProcessChange();

            return complete;
        }

        /// <summary>
        /// Fills the trait pool listbox using the current category and power level.
        /// </summary>
        private void LoadTraitPoolList()
        {
            if (cbxTraitCategory.SelectedIndex > -1)
            {
                string tmpCat = cbxTraitCategory.SelectedItem.ToString();

                if (cbxTraitCategory.SelectedIndex > 0)
                    tmpCat = tmpCat.Substring(0, tmpCat.IndexOf(" Racial Traits")).Replace(" ", string.Empty);

                RacialTrait.TraitType getType = Utils.ToEnum<RacialTrait.TraitType>(tmpCat, RacialTrait.TraitType.Other);
                RacialTrait.RequiredPowerLevel powerLevel = (RacialTrait.RequiredPowerLevel)cbxPowerLevel.SelectedIndex;

                ClearTraitInfo();
                lstTraitPool.Items.Clear();

                foreach (RacialTrait curTrait in Globals.raceTraitDB.Values)
                {
                    if (((cbxTraitCategory.SelectedIndex == 0) || (curTrait.type == getType)) && (curTrait.powerLevel <= powerLevel))
                    {
                        int traitCount = 0;

                        traitCount += Globals.character.race.type.intrinsicTraits.FindAll(myTrait => myTrait.name == curTrait.name).Count;
                        traitCount += Globals.character.race.HasTrait(curTrait);

                        if (traitCount < curTrait.repeatLimit)
                            lstTraitPool.Items.Add(curTrait.name);
                    }
                }
            }
            else
                lstTraitPool.Items.Clear();
        }

        /// <summary>
        /// Fills the items in the Trait Info panel.
        /// </summary>
        private void SetTraitInfo()
        {
            if (lstTraitPool.SelectedIndex > -1)
            {
                RacialTrait selectedTrait = Globals.raceTraitDB[lstTraitPool.SelectedItem.ToString()];
                int points = 0;
                int ranks = Globals.character.race.HasTrait(lstTraitPool.SelectedItem.ToString());

                if ((ranks > 1) && (selectedTrait.repeatCostIncrease < 0))
                    points = -1 * selectedTrait.repeatCostIncrease;
                else
                    points = selectedTrait.pointCost + selectedTrait.repeatCostIncrease * (ranks);

                lblSelectedTraitName.Text = selectedTrait.name + " - " + points + ((points == 1) ? " pt." : " pts.");
                txtSelectedTraitPrerequisites.Text = selectedTrait.prerequisites;
                txtSelectedTraitDescription.Text = selectedTrait.GetDescription(Globals.character.race.HasTrait(lstTraitPool.SelectedItem.ToString()));
                txtSelectedTraitSpecial.Text = selectedTrait.special;

                ttpQuickReference.SetToolTip(txtSelectedTraitPrerequisites, Utils.SimpleWordWrap(txtSelectedTraitPrerequisites.Text, tooltipWordWrap));
                ttpQuickReference.SetToolTip(txtSelectedTraitSpecial, Utils.SimpleWordWrap(txtSelectedTraitSpecial.Text, tooltipWordWrap));

                lblSelectedTraitPrerequisites.Enabled = txtSelectedTraitPrerequisites.Enabled = (txtSelectedTraitPrerequisites.Text.Length > 0);
                lblSelectedTraitSpecial.Enabled = txtSelectedTraitSpecial.Enabled = (txtSelectedTraitSpecial.Text.Length > 0);

                pnlTraitInfo.Enabled = true;
            }
            else
                ClearTraitInfo();
        }

        /// <summary>
        /// Clears the Trait Info panel.
        /// </summary>
        private void ClearTraitInfo()
        {
            lblSelectedTraitName.Text = txtSelectedTraitDescription.Text = txtSelectedTraitPrerequisites.Text = txtSelectedTraitSpecial.Text = string.Empty;
            pnlTraitInfo.Enabled = false;
        }

        /// <summary>
        /// Adds traits that are automatically included with the race due to its creature type.
        /// </summary>
        /// <param name="traits">The intrinsic traits of the current creature type.</param>
        private void AddReadOnlyTraits(List<RacialTrait> traits)
        {
            foreach (RacialTrait curTrait in traits)
                AddTraitToRace(curTrait.name, true);
        }

        /// <summary>
        /// Removes the TraitManagers that were included automatically due to the race's creature type.  This is mainly used when the user selects a different type.
        /// </summary>
        private void RemoveReadOnlyTraits()
        {
            SuspendDrawing();

            for (int i = 0; i < pnlSelectedTraits.Controls.Count; i++)
            {
                if (((TraitManager)pnlSelectedTraits.Controls[i]).readOnly)
                {
                    pnlSelectedTraits.Controls.RemoveAt(i);
                    i--;
                }
            }

            SortSelectedTraits();
            ResumeDrawing();
        }

        /// <summary>
        /// Gets the TraitManager UserControl for the given trait.
        /// </summary>
        /// <param name="traitName">The name of the trait to use.</param>
        /// <returns>The associated TraitManager or null if not found.</returns>
        private TraitManager GetTraitManager(string traitName)
        {
            foreach (Control curPanel in pnlSelectedTraits.Controls)
            {
                if (((TraitManager)curPanel).myLink.trait.name == traitName)
                    return (TraitManager)curPanel;
            }

            return null;
        }

        /// <summary>
        /// Adds a trait to the race.
        /// </summary>
        /// <param name="traitName">The name of the trait to add.</param>
        /// <param name="readOnly">Whether the trait can be edited.</param>
        /// <param name="cosmeticOnly">Whether to skip actually adding the trait to the race object (used when loading a race from the database)</param>
        private void AddTraitToRace(string traitName, bool readOnly, bool cosmeticOnly = false)
        {
            bool newPanel = false;
            TraitManager traitPanel = null;

            traitPanel = GetTraitManager(traitName);

            if (traitPanel == null)
            {
                traitPanel = new TraitManager();
                newPanel = true;
            }

            if (readOnly)
                traitPanel.UpdateLink(new RaceTraitLink(Globals.raceTraitDB[traitName]), true);
            else if (cosmeticOnly)
                traitPanel.UpdateLink(Globals.character.race.GetLink(traitName));
            else
                traitPanel.UpdateLink(Globals.character.race.AddTrait(Globals.raceTraitDB[traitName]));

            traitPanel.SetTooltips(ttpInfo);

            if (newPanel)
            {
                traitPanel.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right;
                traitPanel.NotifyChange += Generic_ProcessChange;
                traitPanel.RemoveTrait += dynamicTraitManagerRemove_Click;
                traitPanel.ReValidate += ValidateRaceCallback;
                pnlSelectedTraits.Controls.Add(traitPanel);
            }

            LoadTraitPoolList();

            // Try to keep the same trait selected, in case it can be added multiple times.
            if (!readOnly)
                lstTraitPool.SelectedItem = traitName;

            SortSelectedTraits();
            ProcessChange();
        }

        /// <summary>
        /// Removes the given trait from the race.
        /// </summary>
        /// <param name="traitName">The name of the trait to remove.</param>
        private void RemoveTraitFromRace(string traitName)
        {
            int count = Globals.character.race.RemoveTrait(traitName);

            if (count > 0)
                GetTraitManager(traitName).UpdateDisplay();
            else
            {
                pnlSelectedTraits.Controls.Remove(GetTraitManager(traitName));
                SortSelectedTraits();
            }

            if ((lstTraitPool.SelectedIndex > -1) && (lstTraitPool.SelectedItem.ToString() == traitName))
                SetTraitInfo();
            else if ((cbxTraitCategory.SelectedIndex > -1) && (cbxTraitCategory.Text.Substring(0, cbxTraitCategory.Text.IndexOf(" Racial Traits")).Replace(" ", string.Empty) == Globals.raceTraitDB[traitName].type.ToString()))
            {
                object currentSelection = lstTraitPool.SelectedItem;
                LoadTraitPoolList();
                lstTraitPool.SelectedItem = currentSelection;
            }

            ProcessChange();
        }

        /// <summary>
        /// Customized sorter for TraitManager panels.
        /// </summary>
        private int TraitSorter(TraitManager x, TraitManager y)
        {
            if (x.readOnly)
            {
                if (!y.readOnly)
                    return -1;
            }
            else if (y.readOnly)
                return 1;

            return RacialTrait.Compare(x.myLink.trait, y.myLink.trait);
        }

        /// <summary>
        /// Sorts the TraitManager panels on the form - readonly comes first, then they're sorted by type and by name.
        /// </summary>
        private void SortSelectedTraits()
        {
            int savedOffset = 0;

            List<TraitManager> holder = new List<TraitManager>();

            cbxPowerLevel.Enabled = (holder.FindAll(curTrait => !curTrait.readOnly).Count == 0);

            while (pnlSelectedTraits.Controls.Count > 0)
            {
                holder.Add((TraitManager)pnlSelectedTraits.Controls[0]);
                pnlSelectedTraits.Controls.RemoveAt(0);
            }

            holder.Sort(TraitSorter);

            for (int i = 0; i < holder.Count; i++)
            {
                if (pnlSelectedTraits.Controls.Count == 0)
                    holder[i].Size = new System.Drawing.Size(pnlSelectedTraits.Size.Width - 8, holder[i].Size.Height);
                else
                    holder[i].Size = new System.Drawing.Size(pnlSelectedTraits.Controls[0].Size.Width, holder[i].Size.Height);

                holder[i].Location = new Point(holder[i].Location.X, savedOffset);
                pnlSelectedTraits.Controls.Add(holder[i]);

                savedOffset += holder[i].Size.Height;
            }
        }

        /// <summary>
        /// Ensures that every required field is filled with valid information.
        /// </summary>
        /// <returns>Whether the race is complete or not.</returns>
        private bool ValidateRace()
        {
            bool result = true;

            if ((cbxCreatureType.SelectedIndex == -1) ||
                    (cbxSize.SelectedIndex == -1) ||
                    (cbxSpeedQuality.SelectedIndex == -1) ||
                    (cbxAttributeSelection.SelectedIndex == -1) ||
                    (cbxLanguages.SelectedIndex == -1) ||
                    (gbxAttributes.ForeColor == Color.Red) ||
                    (!ValidateLanguages()) ||
                    (!ValidateTextFields()))
                result = false;
            else
            {
                foreach (Control curManager in pnlSelectedTraits.Controls)
                {
                    if (!((TraitManager)curManager).valid)
                        result = false;
                }
            }

            if (result)
            {
                lblRaceStatus.ForeColor = Color.Green;
                lblRaceStatus.Text = "ü"; // Wingdings checkmark.
                mniSave.Enabled = changed;
                ttpInfo.SetToolTip(lblRaceStatus, "All required information has been entered for this race.");
            }
            else
            {
                lblRaceStatus.ForeColor = Color.Maroon;
                lblRaceStatus.Text = "û"; // Wingdings X
                mniSave.Enabled = false;
                ttpInfo.SetToolTip(lblRaceStatus, "Your race is missing required information; you will not be able to save or leave the Design tab.");
            }

            return result;
        }

        /// <summary>
        /// EventHandler callback to ValidateRace.
        /// </summary>
        private void ValidateRaceCallback(object sender, EventArgs e)
        {
            ValidateRace();
        }

        /// <summary>
        /// Checks the racial language selections to ensure they're appropriate for the Language Quality selection.
        /// </summary>
        /// <returns>Whether the languages have been properly chosen.</returns>
        private bool ValidateLanguages()
        {
            if (Globals.character.race.startingLanguages == null)
                return false;

            switch (Globals.character.race.languageQuality)
            {
                case Race.LanguageQualityOptions.Linguist:
                case Race.LanguageQualityOptions.Standard:
                    if (!Array.Exists<string>(Globals.character.race.startingLanguages, curString => ((curString == "Common") || (curString == "Undercommon"))))
                        return false;
                    break;
                case Race.LanguageQualityOptions.Xenophobe:
                    if ((Globals.character.race.startingLanguages.Length == 0) || (Array.Exists<string>(Globals.character.race.startingLanguages, curString => ((curString == "Common") || (curString == "Undercommon")))))
                        return false;
                    break;
            }

            // Only validate available languages if we have some.
            if (Globals.character.race.availableLanguages != null)
            {
                switch (Globals.character.race.languageQuality)
                {
                    case Race.LanguageQualityOptions.Linguist:
                        return ((Globals.character.race.availableLanguages.Length == 1) && (Globals.character.race.availableLanguages[0] == "All"));
                    case Race.LanguageQualityOptions.Standard:
                        return (Globals.character.race.availableLanguages.Length <= 7);
                    case Race.LanguageQualityOptions.Xenophobe:
                        return ((Globals.character.race.availableLanguages.Length <= 4) && (Array.Exists<string>(Globals.character.race.availableLanguages, curString => ((curString == "Common") || (curString == "Undercommon")))));
                }
            }

            return true;
        }

        /// <summary>
        /// Checks the values of text fields that support the race entry replacement feature.
        /// </summary>
        /// <returns>Whether the fields have valid information.</returns>
        public bool ValidateTextFields()
        {
            return ((CheckTextField(txtRaceFlavorText.Text)) && (CheckTextField(txtPhysicalAppearance.Text)));
        }

        /// <summary>
        /// Double checks a flavor text field to make sure it won't break string.Format when used.
        /// </summary>
        /// <param name="text">The text to validate.</param>
        /// <returns>Whether the text will work in string.Format or not.</returns>
        private bool CheckTextField(string text)
        {
            try
            {
                int tmpVal;
                int curIndex = text.IndexOf('{');
                int endIndex = text.IndexOf('}');

                if (((endIndex > -1) && (curIndex == -1)) || ((endIndex == -1) && (curIndex > -1)))
                    return false;

                while (curIndex > -1)
                {
                    if (endIndex <= curIndex + 1)
                        return false;

                    tmpVal = int.Parse(text.Substring(curIndex + 1, endIndex - curIndex - 1));

                    if ((tmpVal < 1) || (tmpVal > 6))
                        return false;

                    curIndex = text.IndexOf('{', curIndex + 1);
                    endIndex = text.IndexOf('}', endIndex + 1);
                }
            }
            catch
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Sets the button for editing languages to a color indicating its status.
        /// </summary>
        public void SetLanguageButton(bool status)
        {
            btnEditLanguages.ForeColor = (status) ? Color.Green : Color.Red;
        }

        /// <summary>
        /// Fill out the race's rules entry display.
        /// </summary>
        private void BuildRaceEntry()
        {
            Globals.character.race.BuildRaceEntry(brsDisplayWindow.Document);
        }

        #region EventHandlers
        private void RaceBuilderForm_Shown(object sender, EventArgs e)
        {
            ShowRaceSelection(true);
        }

        private void RaceBuilderForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!ConfirmChanges())
                e.Cancel = true;
        }

        private void RaceBuilderForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Process.Start(@"http://www.d20pfsrd.com/gamemastering/other-rules/creating-new-races");
                e.Handled = true;
            }
        }

        private void mniNew_Click(object sender, EventArgs e)
        {
            if (ConfirmChanges())
                ClearRace();
        }

        private void mniSave_Click(object sender, EventArgs e)
        {
            SaveRace();
        }

        private void mniLoad_Click(object sender, EventArgs e)
        {
            if (ConfirmChanges())
                ShowRaceSelection(false);
        }

        private void mniDeleteRaces_Click(object sender, EventArgs e)
        {
            RaceDeletionForm frmDeletion = new RaceDeletionForm();

            if (frmDeletion.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string curName;

                for (int i = 0; i < frmDeletion.lstSelectedRaces.Items.Count; i++)
                {
                    curName = frmDeletion.lstSelectedRaces.Items[i].ToString();
                    curName = curName.Substring(0, curName.LastIndexOf(" - ")).Trim();

                    if (Globals.raceDB.Keys.Contains(curName))
                        Globals.raceDB.Remove(curName);
                }

                CommitRaceDatabase();
                UpdateRaceDeletion();
            }
        }

        private void mniExit_Click(object sender, EventArgs e)
        {
            if (ConfirmChanges())
                Close();
        }

        private void Generic_ProcessChange(object sender, EventArgs e)
        {
            ProcessChange();
        }

        private void txtRacePlural_Enter(object sender, EventArgs e)
        {
            setPlural = true;
        }

        private void txtRaceName_TextChanged(object sender, EventArgs e)
        {
            if (!setPlural)
            {
                if (txtRaceName.Text != string.Empty)
                    txtRacePlural.Text = txtRaceName.Text + 's';
                else
                    txtRacePlural.Text = string.Empty;
            }

            ProcessChange();

            if (tbcMain.SelectedTab == tabDisplay)
                BuildRaceEntry();
        }

        private void txtRaceName_Leave(object sender, EventArgs e)
        {
            txtRaceName.Text = txtRaceName.Text.Trim();
            Globals.character.race.name = txtRaceName.Text;

            if (!setPlural)
                Globals.character.race.namePlural = txtRacePlural.Text;

            if (tbcMain.SelectedTab == tabDisplay)
                BuildRaceEntry();
        }

        private void txtRacePlural_TextChanged(object sender, EventArgs e)
        {
            ProcessChange();

            if ((setPlural) && (tbcMain.SelectedTab == tabDisplay))
                BuildRaceEntry();
        }

        private void txtRacePlural_Leave(object sender, EventArgs e)
        {
            txtRacePlural.Text = txtRacePlural.Text.Trim();
            Globals.character.race.namePlural = txtRacePlural.Text;

            if (tbcMain.SelectedTab == tabDisplay)
                BuildRaceEntry();
        }

        private void txtRaceAdjective_Leave(object sender, EventArgs e)
        {
            txtRaceAdjective.Text = txtRaceAdjective.Text.Trim();
            Globals.character.race.nameAdjective = txtRaceAdjective.Text;

            if (tbcMain.SelectedTab == tabDisplay)
                BuildRaceEntry();
        }

        private void txtRaceFlavorText_Leave(object sender, EventArgs e)
        {
            Globals.character.race.flavorText = txtRaceFlavorText.Text;
            ProcessChange();
        }

        private void txtPhysicalAppearance_Leave(object sender, EventArgs e)
        {
            Globals.character.race.appearanceDescription = txtPhysicalAppearance.Text;
            ProcessChange();
        }

        private void txtSubtype_Leave(object sender, EventArgs e)
        {
            Globals.character.race.subtype = txtSubtype.Text;
        }

        private void cbxCreatureType_SelectedIndexChanged(object sender, EventArgs e)
        {
            SuspendDrawing();

            RemoveReadOnlyTraits();

            if (cbxCreatureType.SelectedIndex > -1)
            {
                Globals.character.race.type = Globals.raceTypeDB[cbxCreatureType.Text.Substring(0, cbxCreatureType.Text.IndexOf(" - "))];
                AddReadOnlyTraits(Globals.character.race.type.intrinsicTraits);

                ttpInfo.SetToolTip(cbxCreatureType, Utils.SimpleWordWrap(Globals.raceTypeDB.Values[cbxCreatureType.SelectedIndex].description, tooltipWordWrap));

                if (cbxLanguages.SelectedIndex == -1)
                    FillComboBox(cbxLanguages, "Standard");
            }
            else
                ttpInfo.SetToolTip(cbxCreatureType, string.Empty);

            CheckSubtypeEligibility();

            gbxRacialTraits.Enabled = ((cbxPowerLevel.SelectedIndex > -1) && (cbxCreatureType.SelectedIndex > -1));

            ProcessChange();
            ResumeDrawing();
        }

        private void cbxAttributeSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < 6; i++)
                attributePanels[i].ResetControls();

            DetermineAttributeParameters(null);

            if (cbxAttributeSelection.SelectedIndex > -1)
            {
                Globals.character.race.attributePackage = Utils.ToEnum<Race.AttributePackages>(cbxAttributeSelection.Text.Substring(0, cbxAttributeSelection.Text.IndexOf(" - ")).Replace(" ", string.Empty), Race.AttributePackages.HumanHeritage);
                ttpInfo.SetToolTip(cbxAttributeSelection, Utils.SimpleWordWrap(attributePackageDescription[cbxAttributeSelection.SelectedIndex], 120));
            }
            else
                ttpInfo.SetToolTip(cbxAttributeSelection, null);

            ProcessChange();
        }

        private void AttributeControl_SelectionUpdated(object sender, EventArgs e)
        {
            DetermineAttributeParameters(e);
        }

        private void tbcMain_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPage == tabDisplay)
                e.Cancel = !ValidateRace();
        }

        private void tbcMain_Selected(object sender, TabControlEventArgs e)
        {
            if (e.TabPage == tabDisplay)
                BuildRaceEntry();
        }

        private void cbxSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckSubtypeEligibility();

            if (cbxSize.SelectedIndex > -1)
                Globals.character.race.size = Utils.ToEnum<Globals.Size>(cbxSize.Text.Substring(0, cbxSize.Text.IndexOf(" - ")), Globals.Size.Medium);

            foreach (Control curControl in pnlSelectedTraits.Controls)
                ((TraitManager)curControl).UpdateDisplay();

            ProcessChange();
        }

        private void cbxPowerLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbxPowerLevel.SelectedIndex)
            {
                case 0:
                    if (cbxAttributeSelection.Items[0].ToString() == "Advanced - 4 pts.")
                    {
                        bool reset = cbxAttributeSelection.SelectedIndex == 0;
                        cbxAttributeSelection.Items.RemoveAt(0);

                        if (reset)
                            cbxAttributeSelection.SelectedIndex = 0;
                    }

                    int index = cbxTraitCategory.Items.IndexOf("Ability Score Racial Traits");

                    if (index > -1)
                    {
                        bool reset = cbxTraitCategory.SelectedIndex == index;
                        cbxTraitCategory.Items.RemoveAt(index);

                        if (reset)
                            cbxTraitCategory.SelectedIndex = 0;
                    }
                    break;
                default:
                    if (cbxAttributeSelection.Items[0].ToString() != "Advanced - 4 pts.")
                        cbxAttributeSelection.Items.Insert(0, "Advanced - 4 pts.");

                    if (!cbxTraitCategory.Items.Contains("Ability Score Racial Traits"))
                        cbxTraitCategory.Items.Insert(1, "Ability Score Racial Traits");
                    break;
            }

            gbxRacialTraits.Enabled = ((cbxPowerLevel.SelectedIndex > -1) && (cbxCreatureType.SelectedIndex > -1));

            if (cbxTraitCategory.SelectedIndex > -1)
                LoadTraitPoolList();
        }

        private void cbxLanguages_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxLanguages.SelectedIndex > -1)
            {
                if (Globals.character.race.languageQuality == Race.LanguageQualityOptions.Linguist)
                    Globals.character.race.availableLanguages = null;

                Globals.character.race.languageQuality = (Race.LanguageQualityOptions)cbxLanguages.SelectedIndex;

                if (Globals.character.race.startingLanguages == null)
                {
                    switch (Globals.character.race.languageQuality)
                    {
                        case Race.LanguageQualityOptions.Standard:
                        case Race.LanguageQualityOptions.Linguist:
                            Globals.character.race.startingLanguages = new string[] { "Common" };
                            break;
                    }
                }

                if (Globals.character.race.languageQuality == Race.LanguageQualityOptions.Linguist)
                    Globals.character.race.availableLanguages = new string[] { "All" };
            }
            else
                Globals.character.race.languageQuality = Race.LanguageQualityOptions.Standard;

            btnEditLanguages.Enabled = (cbxLanguages.SelectedIndex > -1);

            SetLanguageButton(ValidateLanguages());
            ProcessChange();
        }

        private void cbxTraitCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadTraitPoolList();
        }

        private void lstTraitPool_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetTraitInfo();
        }

        private void lstTraitPool_DoubleClick(object sender, EventArgs e)
        {
            if (lstTraitPool.SelectedIndex > -1)
            {
                SuspendDrawing();
                AddTraitToRace(lstTraitPool.SelectedItem.ToString(), false);
                ResumeDrawing();
            }
        }

        private void btnAddSelectedTrait_Click(object sender, EventArgs e)
        {
            SuspendDrawing();
            AddTraitToRace(lstTraitPool.SelectedItem.ToString(), false);
            ResumeDrawing();
        }

        private void dynamicTraitManagerRemove_Click(object sender, EventArgs e)
        {
            SuspendDrawing();
            RemoveTraitFromRace(((TraitManager)sender).myLink.trait.name);
            ResumeDrawing();
        }

        private void cbxSpeedQuality_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbxSpeedQuality.SelectedIndex)
            {
                case 0:
                    Globals.character.race.baseSpeed = 30;
                    break;
                case 1:
                    Globals.character.race.baseSpeed = 20;
                    break;
            }
        }

        private void mniAbout_Click(object sender, EventArgs e)
        {
            AboutBoxGeneric aboutBox = new AboutBoxGeneric();
            aboutBox.SetInfo("Pathfinder Race Builder", Application.ProductVersion, Properties.Resources.VitruvianIcon);
            aboutBox.ShowDialog();
        }

        private void btnEditLanguages_Click(object sender, EventArgs e)
        {
            LanguageSelectionForm langForm = new LanguageSelectionForm();

            langForm.ShowDialog();

            SetLanguageButton(ValidateLanguages());
            ProcessChange();
        }
        #endregion // EventHandlers
    }
}
