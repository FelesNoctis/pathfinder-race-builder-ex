using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace PathfinderSpellDBParser
{
    public partial class ParseForm : Form
    {
        const int SpellName = 0;
        const int School = 1;
        const int Subschool = 2;
        const int Descriptor = 3;
        const int SpellLevel = 4;
        const int CastingTime = 5;
        const int Components = 6;
        const int CostlyComponents = 7;
        const int Range = 8;
        const int Area = 9;
        const int Effect = 10;
        const int Targets = 11;
        const int Duration = 12;
        const int Dismissible = 13;
        const int Shapeable = 14;
        const int SavingThrow = 15;
        const int SpellResistance = 16;
        const int Description = 17;
        const int DescriptionFormatted = 18;
        const int Source = 19;
        const int FullText = 20;
        const int Verbal = 21;
        const int Somatic = 22;
        const int Material = 23;
        const int ArcaneFocus = 24;
        const int DivineFocus = 25;
        const int Sorceror = 26;
        const int Wizard = 27;
        const int Cleric = 28;
        const int Druid = 29;
        const int Ranger = 30;
        const int Bard = 31;
        const int Palading = 32;
        const int Alchemist = 33;
        const int Summoner = 34;
        const int Witch = 35;
        const int Inquisitor = 36;
        const int Oracle = 37;
        const int Antipaladin = 38;
        const int Magus = 39;
        const int Deity = 40;
        const int SLALevel = 41;
        const int Domain = 42;
        const int ShortDescription = 43;
        const int Acid = 44;
        const int Air = 45;
        const int Chaotic = 46;
        const int Cold = 47;
        const int Curse = 48;
        const int Darkness = 49;
        const int Death = 50;
        const int Disease = 51;
        const int Earth = 52;
        const int Electricity = 53;
        const int Emotion = 54;
        const int Evil = 55;
        const int Fear = 56;
        const int Fire = 57;
        const int Force = 58;
        const int Good = 59;
        const int LanguageDependent = 60;
        const int Lawful = 61;
        const int Light = 62;
        const int MindAffecting = 63;
        const int Pain = 64;
        const int Poison = 65;
        const int Shadow = 66;
        const int Sonic = 67;
        const int Water = 68;
        const int LinkText = 69;
        const int Id = 70;
        const int MaterialCost = 71;
        const int Bloodline = 72;

        public int spellCount;
        public StringBuilder sb = new StringBuilder();
        public XmlWriter writer;

        public ParseForm()
        {
            InitializeWriter();
            InitializeComponent();
        }

        public void InitializeWriter()
        {
            sb.Clear();

            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Encoding = Encoding.UTF8;
            settings.Indent = true;
            settings.IndentChars = "	";

            writer = XmlTextWriter.Create(sb, settings);
        }

        public static readonly char[] separators = { ' ', '-', '_' };

        public string Capitalize(string capMe, bool removeNonAlpha = false)
        {
            switch (capMe.Length)
            {
                case 0:
                    return capMe;
                case 1:
                    return capMe.ToUpper();
                default:
                    StringBuilder result = new StringBuilder(capMe);
                    bool foundSpace = true;

                    for (int i = 0; i < result.Length; i++)
                    {
                        if (foundSpace)
                            result[i] = char.ToUpper(result[i]);

                        foundSpace = separators.Contains(result[i]);

                        if ((removeNonAlpha) && (!char.IsLetterOrDigit(result[i])))
                        {
                            result.Remove(i, 1);
                            i--;
                        }
                    }

                    return result.ToString();
            }
        }

        public string LinkifySpellName(string name)
        {
            StringBuilder result = new StringBuilder(name);

            for (int i = 0; i < result.Length; i++)
            {
                if (separators.Contains(result[i]))
                    result[i] = '-';
                else
                    result[i] = char.ToLower(result[i]);
            }

            return string.Format("http://www.d20pfsrd.com/magic/all-spells/{0}/{1}", result[0], result);
        }

        private void btnGoCancel_Click(object sender, EventArgs e)
        {
            if (btnGoCancel.Text == "Go!")
            {
                bgwParseMe.RunWorkerAsync();
                lblFinalCount.Visible = txtResults.Enabled = false;
                prgProgress.Visible = true;
                btnGoCancel.Text = "Cancel";
            }
            else
            {
                bgwParseMe.CancelAsync();
                btnGoCancel.Enabled = false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            StreamWriter writeMe = new StreamWriter(new FileStream("SpellDatabase.xml", FileMode.Create), Encoding.UTF8);
            writeMe.Write(txtResults.Text);
            writeMe.Close();
        }

        private void bgwParseMe_DoWork(object sender, DoWorkEventArgs e)
        {
            int progress = -1;
            int i, tmp;
            string tmpStr, result;
            string[] split;
            spellCount = 0;

            InitializeWriter();

            StreamReader sr = new StreamReader(new FileStream("spell_full.tsv", FileMode.Open));

            writer.WriteStartDocument();
            writer.WriteStartElement("SpellDatabase");

            sr.ReadLine(); // Eat the header line.

            while (!sr.EndOfStream)
            {
                string[] values = sr.ReadLine().Split(new char[] { '	' });

                writer.WriteStartElement("Spell");

                writer.WriteElementString("Name", values[SpellName]);
                writer.WriteElementString("School", Capitalize(values[School]));

                if (values[Subschool] != string.Empty)
                    writer.WriteElementString("Subschool", Capitalize(values[Subschool]));

                if (values[Descriptor] != string.Empty)
                    writer.WriteElementString("Descriptor", Capitalize(values[Descriptor], true));

                writer.WriteElementString("Level", values[SpellLevel]);

                // Casting Time
                if (values[CastingTime].StartsWith("1 immediate action"))
                    result = "ImmediateAction";
                else if (values[CastingTime].StartsWith("1 swift action"))
                    result = "Swift Action";
                else if ((values[CastingTime].StartsWith("1 standard")) || (values[CastingTime] == "?"))
                    result = "Standard Action";
                else if ((values[CastingTime].StartsWith("1 full")) || (values[CastingTime].StartsWith("1 round")))
                    result = "FullRound";
                else if (values[CastingTime].StartsWith("2 rounds"))
                    result = "TwoRounds";
                else if ((values[CastingTime] == "3 rounds") || (values[CastingTime] == "3 full rounds"))
                    result = "ThreeRounds";
                else if (values[CastingTime] == "6 rounds")
                    result = "SixRounds";
                else if (values[CastingTime].Contains("1 minute"))
                    result = "OneMinute";
                else if (values[CastingTime].Contains("10 minute"))
                    result = "TenMinutes";
                else if (values[CastingTime].StartsWith("30 minutes"))
                    result = "ThirtyMinutes";
                else if (values[CastingTime].StartsWith("1 hour"))
                    result = "OneHour";
                else if (values[CastingTime] == "2 hours")
                    result = "TwoHours";
                else if (values[CastingTime] == "4 hours")
                    result = "FourHours";
                else if (values[CastingTime] == "6 hours")
                    result = "SixHours";
                else if (values[CastingTime] == "12 hours")
                    result = "TwelveHours";
                else if (values[CastingTime] == "24 hours")
                    result = "TwentyFourHours";
                else
                    result = "TODO: Invalid casting time '" + values[CastingTime] + "'";

                writer.WriteElementString("CastingTime", result);

                if ((values[CastingTime].Contains("/lb. created")) || (values[CastingTime].Contains("/HD of target")))
                    result = values[CastingTime];
                else if (values[CastingTime].Contains("per page"))
                    result = "/page";
                else
                    result = string.Empty;

                if (result != string.Empty)
                    writer.WriteElementString("CastingTimeMultiplier", result);

                // Components
                result = string.Join(",", string.Join(",", (values[Verbal] == "1") ? "Verbal" : null, (values[Somatic] == "1") ? "Somatic" : null, (values[Material] == "1") ? "Material" : null, (values[ArcaneFocus] == "1") ? "FocusArcane" : null, (values[DivineFocus] == "1") ? "FocusDivine" : null).Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries));

                writer.WriteElementString("Components", result);

                // Material Component
                result = string.Empty;
                tmpStr = string.Empty;
                tmp = values[Components].IndexOf('(');

                while (tmp > -1)
                {
                    for (i = tmp - 1; i > 0; i--)
                    {
                        if (values[Components][i] == 'M')
                        {
                            result = values[Components].Substring(tmp + 1, values[Components].IndexOf(')', tmp) - tmp - 1);
                            break;
                        }
                        else if (values[Components][i] == 'F')
                        {
                            tmpStr = values[Components].Substring(tmp + 1, values[Components].IndexOf(')', tmp) - tmp - 1);
                            break;
                        }
                    }

                    tmp = values[Components].IndexOf('(', tmp + 1);
                }

                if (result != string.Empty)
                {
                    writer.WriteElementString("MaterialComponent", result);

                    if (values[MaterialCost] != "NULL")
                        writer.WriteElementString("MaterialCost", values[MaterialCost]);
                }

                if (tmpStr != string.Empty)
                    writer.WriteElementString("FocusComponent", tmpStr);

                if (values[Range] == "you")
                    result = "personal";
                else if (values[Range] == "5 feet")
                    result = "5 ft.";
                else if (values[Range] == "30 feet")
                    result = "30 ft.";
                else if (((values[Range].StartsWith("close")) && (!values[Range].StartsWith("close (25 ft. + 5 ft./2 levels)"))) || (values[Range].StartsWith("short")))
                    result = "close (25 ft. + 5 ft./2 levels)";
                else if (values[Range].StartsWith("medium"))
                    result = "medium (100 ft. + 10 ft./level)";
                else if (values[Range].StartsWith("long"))
                    result = "long (400 ft. + 40 ft./level)";
                else
                    result = values[Range];

                writer.WriteElementString("Range", result);
                
                if (values[Area] != string.Empty)
                    writer.WriteElementString("Area", values[Area].Replace("emanation,", "emanation"));
                
                if (values[Targets] != string.Empty)
                    writer.WriteElementString("Target", values[Targets]);

                writer.WriteElementString("Duration", values[Duration]);
                writer.WriteElementString("SavingThrow", values[SavingThrow]);
                if (values[SpellResistance] != string.Empty)
                    writer.WriteElementString("SpellResistance", values[SpellResistance]);

                writer.WriteElementString("ShortDescription", values[ShortDescription]);
                writer.WriteElementString("Description", values[Description]);


                writer.WriteElementString("SpellLikeLevel", values[SLALevel]);
                writer.WriteElementString("Link", LinkifySpellName(values[SpellName]));

                writer.WriteEndElement();

                spellCount++;

                if (bgwParseMe.CancellationPending)
                    break;
                else if ((int)(100 * sr.BaseStream.Position / ((float)sr.BaseStream.Length)) > progress)
                {
                    progress = (int)(100 * sr.BaseStream.Position / ((float)sr.BaseStream.Length));
                    bgwParseMe.ReportProgress(progress);
                }

            }

            writer.WriteEndElement();

            sr.Close();

            writer.Flush();

            bgwParseMe.ReportProgress(100);
        }

        private void bgwParseMe_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            prgProgress.Value = e.ProgressPercentage;
            lblFinalCount.Visible = true;
            lblFinalCount.Text = spellCount + " spells processed.";
        }

        private void bgwParseMe_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            lblFinalCount.Text = spellCount + " spells processed.";
            prgProgress.Visible = false;
            lblFinalCount.Visible = btnGoCancel.Enabled = btnSave.Enabled = txtResults.Enabled = true;
            btnGoCancel.Text = "Go!";
            txtResults.Text = sb.ToString().Replace("encoding=\"utf-16\"", "encoding=\"utf-8\"");
        }
    }
}
