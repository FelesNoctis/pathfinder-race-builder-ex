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
    public partial class LanguageSelectionForm : Form
    {
        private static readonly string dragTooltip = "Drag and drop each language into the desired category.";

        private readonly List<string> languageOptions = new List<string>(new string[]
        {
            "Abyssal",
            "Aklo",
            "Aquan",
            "Auran",
            "Boggard",
            "Celestial",
            "Common",
            "Draconic",
            "Drow Sign Language",
            "Dwarven",
            "Elven",
            "Giant",
            "Gnoll",
            "Gnome",
            "Goblin",
            "Halfling",
            "Ignan",
            "Infernal",
            "Orc",
            "Racial",
            "Sylvan",
            "Terran",
            "Undercommon",
        });

        int languagesInUse;
        ListBox dragSource;

        public LanguageSelectionForm()
        {
            InitializeComponent();

            ttpGeneric.SetToolTip(lstAvailableLanguages, dragTooltip);
            ttpGeneric.SetToolTip(lstRacialLanguages, dragTooltip);
            ttpGeneric.SetToolTip(lstOptionalLanguages, dragTooltip);

            FillLanguageSelections();
        }

        private void FillLanguageSelections()
        {
            int i, temp;

            languagesInUse = 0;

            if ((!Globals.character.race.name.ToLower().Contains("drow")) || (!Globals.character.race.subtype.ToLower().Contains("elf")))
                languageOptions.Remove("Drow Sign Language");

            if (languageOptions.Contains(Utils.Capitalize(Globals.character.race.nameAdjective, true)))
                languageOptions.Remove("Racial");
            else if (!string.IsNullOrEmpty(Globals.character.race.subtype))
            {
                bool keepRacial = false;
                string tmpStr;

                foreach (string curType in Globals.character.race.subtype.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    tmpStr = curType.Trim().ToLower();

                    if (Array.Exists<string>(Race.commonSubtypes, testType => testType == tmpStr))
                        keepRacial = true;
                }

                if (!keepRacial)
                    languageOptions.Remove("Racial");
            }

            if (Globals.character.race.startingLanguages != null)
            {
                for (i = 0; i < Globals.character.race.startingLanguages.Length; i++)
                {
                    temp = languageOptions.IndexOf(Globals.character.race.startingLanguages[i]);

                    if ((temp > -1) && ((languagesInUse & (1 << temp)) == 0))
                    {
                        lstRacialLanguages.Items.Add(Globals.character.race.startingLanguages[i]);
                        languagesInUse |= (1 << temp);
                    }
                }
            }

            if (Globals.character.race.availableLanguages != null)
            {
                if (Globals.character.race.languageQuality == Race.LanguageQualityOptions.Linguist)
                {
                    lstOptionalLanguages.Enabled = false;
                    lstOptionalLanguages.Items.Add("All");
                    lstOptionalLanguages.BackColor = BackColor;
                }
                else
                {
                    for (i = 0; i < Globals.character.race.availableLanguages.Length; i++)
                    {
                        temp = languageOptions.IndexOf(Globals.character.race.availableLanguages[i]);

                        if ((temp > -1) && ((languagesInUse & (1 << temp)) == 0))
                        {
                            lstOptionalLanguages.Items.Add(Globals.character.race.availableLanguages[i]);
                            languagesInUse |= (1 << temp);
                        }
                    }
                }
            }

            PopulateAvailableList();
            ValidateSelections();
        }

        private void PopulateAvailableList()
        {
            for (int i = 0; i < languageOptions.Count; i++)
            {
                if ((languagesInUse & (1 << i)) == 0)
                    lstAvailableLanguages.Items.Add(languageOptions[i]);
            }
        }

        private void ValidateSelections()
        {
            bool result = true;

            if ((lstRacialLanguages.Items.Count == 0) || (lstRacialLanguages.Items.Count > 3))
                result = false;
            else if ((Globals.character.race.languageQuality == Race.LanguageQualityOptions.Xenophobe) && ((lstRacialLanguages.Items.Contains("Common")) || (lstRacialLanguages.Items.Contains("Undercommon"))))
                result = false;
            else if ((Globals.character.race.languageQuality != Race.LanguageQualityOptions.Xenophobe) && ((!lstRacialLanguages.Items.Contains("Common")) && (!lstRacialLanguages.Items.Contains("Undercommon"))))
                result = false;
            else if (lstOptionalLanguages.Enabled)
            {
                switch (Globals.character.race.languageQuality)
                {
                    case Race.LanguageQualityOptions.Standard:
                        if (lstOptionalLanguages.Items.Count > 7)
                            result = false;
                        break;
                    case Race.LanguageQualityOptions.Xenophobe:
                        if (lstOptionalLanguages.Items.Count > 4)
                            result = false;
                        else if ((!lstOptionalLanguages.Items.Contains("Common")) && (!lstOptionalLanguages.Items.Contains("Undercommon")))
                            result = false;
                        break;
                }
            }

            btnOkay.Enabled = result;
        }

        private void btnOkay_Click(object sender, EventArgs e)
        {
            int i;

            if (lstRacialLanguages.Items.Count > 0)
            {
                Globals.character.race.startingLanguages = new string[lstRacialLanguages.Items.Count];

                for (i = 0; i < lstRacialLanguages.Items.Count; i++)
                    Globals.character.race.startingLanguages[i] = lstRacialLanguages.Items[i].ToString();
            }
            else
                Globals.character.race.startingLanguages = null;

            if (lstOptionalLanguages.Items.Count > 0)
            {
                Globals.character.race.availableLanguages = new string[lstOptionalLanguages.Items.Count];

                for (i = 0; i < lstOptionalLanguages.Items.Count; i++)
                    Globals.character.race.availableLanguages[i] = lstOptionalLanguages.Items[i].ToString();
            }
            else
                Globals.character.race.availableLanguages = null;

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
            else if (sender == lstRacialLanguages)
            {
                if (lstRacialLanguages.Items.Count >= 3)
                    result = false;
                else if ((Globals.character.race.languageQuality == Race.LanguageQualityOptions.Xenophobe) && ((e.Data.GetData(typeof(string)) as string == "Common") || (e.Data.GetData(typeof(string)) as string == "Undercommon")))
                    result = false;
            }
            else if (sender == lstOptionalLanguages)
            {
                if ((e.Data.GetData(typeof(string)) as string == "Racial") || (e.Data.GetData(typeof(string)) as string == Globals.character.race.nameAdjective))
                    result = false;
            }

            e.Effect = (result) ? DragDropEffects.Move : DragDropEffects.None;
        }

        private void ListBoxDragDrop(object sender, DragEventArgs e)
        {
            if (e.Effect == DragDropEffects.Move)
            {
                ListBox curBox = sender as ListBox;

                if (curBox != null)
                {
                    int languageIndex = languageOptions.IndexOf(e.Data.GetData(typeof(string)) as string);

                    if (languageIndex > -1)
                    {
                        if (dragSource == lstAvailableLanguages)
                        {
                            if ((languagesInUse & (1 << languageIndex)) == 0)
                            {
                                dragSource.Items.Remove(languageOptions[languageIndex]);
                                curBox.Items.Add(languageOptions[languageIndex]);
                                languagesInUse |= (1 << languageIndex);
                            }
                        }
                        else if (curBox == lstAvailableLanguages)
                        {
                            if ((languagesInUse & (1 << languageIndex)) > 0)
                            {
                                dragSource.Items.Remove(languageOptions[languageIndex]);
                                curBox.Items.Add(languageOptions[languageIndex]);
                                languagesInUse &= ~(1 << languageIndex);
                            }
                        }
                        else
                        {
                            dragSource.Items.Remove(languageOptions[languageIndex]);
                            curBox.Items.Add(languageOptions[languageIndex]);
                        }
                    }

                    ValidateSelections();
                }
            }
        }
    }
}
