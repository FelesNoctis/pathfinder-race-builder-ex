using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;

namespace PathfinderSystem
{
    public class Spell
    {
        [Flags]
        public enum School
        {
            Abjuration,
            Conjuration,
            Divination,
            Enchantment,
            Evocation,
            Illusion,
            Necromancy,
            Transmutation,
            Universal,
            Varies,
        }

        public enum SubSchool
        {
            None,
            Calling,
            Charm,
            Compulsion,
            Creation,
            Figment,
            Glamer,
            Healing,
            Pattern,
            Phantasm,
            Polymorph,
            Scrying,
            Shadow,
            Summoning,
            Teleportation,
        }

        [Flags]
        public enum Descriptor
        {
            None = 0,
            Acid = (1 << 0),
            Air = (1 << 1),
            Chaotic = (1 << 2),
            Cold = (1 << 3),
            Curse = (1 << 4),
            Darkness = (1 << 5),
            Death = (1 << 6),
            Disease = (1 << 7),
            Earth = (1 << 8),
            Electricity = (1 << 9),
            Emotion = (1 << 10),
            Evil = (1 << 11),
            Fear = (1 << 12),
            Fire = (1 << 13),
            Force = (1 << 14),
            Good = (1 << 15),
            LanguageDependent = (1 << 16),
            Lawful = (1 << 17),
            Light = (1 << 18),
            MindAffecting = (1 << 19),
            Pain = (1 << 20),
            Poison = (1 << 21),
            Shadow = (1 << 22),
            Sonic = (1 << 23),
            Water = (1 << 24),
            SeeText = (1 << 25),
        }

        [Flags]
        public enum Component
        {
            None = 0, // ?
            FocusArcane = 1,
            FocusDivine = 2,
            Material = 4,
            Somatic = 8,
            Verbal = 16,
        }

        public enum CastingTime
        {
            ImmediateAction,
            SwiftAction,
            StandardAction,
            FullRound,
            TwoRounds,
            ThreeRounds,
            SixRounds,
            OneMinute,
            TenMinutes,
            ThirtyMinutes,
            OneHour,
            TwoHours,
            FourHours,
            SixHours,
            TwelveHours,
            TwentyFourHours,
            SeeText,
        }

        // To be used by automated spell selection...
        [Flags]
        public enum Quality
        {
            NA = 0,
            // What the spell does.
            AbilityDamage = (1 << 0),
            Buff = (1 << 1),
            Control = (1 << 2),
            Damage = (1 << 3),
            Debuff = (1 << 4),
            Mobility = (1 << 5),
            NegativeEnergy = (1 << 6),
            Perception = (1 << 7),
            Pets = (1 << 8),
            PositiveEnergy = (1 << 9),
            Protection = (1 << 10),
            Utility = (1 << 11), // Generic catch-all for things like light, prestidigitation, etc.
            // How the spell functions.
            AreaOfEffectSelf = (1 << 12),
            AreaOfEffectTargeted = (1 << 13),
            Cone = (1 << 14),
            Dismissable = (1 << 15),
            Personal = (1 << 16),
            RangedTouch = (1 << 17),
            Ray = (1 << 18),
            Shaped = (1 << 19),
            Touch = (1 << 20),
        }

        public string name;
        public string displayName
        {
            get
            {
                int index = name.IndexOf(',');

                if (index > -1)
                {
                    string result = name.Substring(index + 1).Trim();
                    result += " " + name.Substring(0, index).Trim();
                    return result.ToLower();
                }
                else
                    return name.ToLower();
            }
        }
        public School school;
        public SubSchool subschool;
        public Descriptor descriptor;
        public string level;
        public CastingTime castingTime;
        public string castingTimeMultiplier;
        public Component components;
        public string materialComponent;
        public float? materialCost;
        public string focusComponent;
        public string range;
        public string area;
        public string target;
        public string duration;
        public string savingThrow;
        public bool? spellResistance;
        public string shortDescription;
        public string description;
        public int spellLikeLevel;
        public string link;

        public Quality qualities;

        public static Spell ParseSpellNode(XmlNode spellNode)
        {
            string nowLoading = null;
            Spell result = new Spell();

            try
            {
                nowLoading = "Name";
                result.name = Utils.GetXMLNodeValue(spellNode, nowLoading);
                nowLoading = "School";
                result.school = Utils.ToEnum<School>(Utils.GetXMLNodeValue(spellNode, nowLoading));

                nowLoading = "Subschool";
                if (spellNode.SelectSingleNode(nowLoading) == null)
                    result.subschool = SubSchool.None;
                else
                    result.subschool = Utils.ToEnum<SubSchool>(Utils.GetXMLNodeValue(spellNode, nowLoading));

                nowLoading = "Descriptor";
                result.descriptor = Descriptor.None;

                foreach (string curDescriptor in Utils.GetXMLNodeValue(spellNode, nowLoading).Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    nowLoading = "Descriptor - " + curDescriptor;
                    result.descriptor |= Utils.ToEnum<Descriptor>(curDescriptor);
                }

                nowLoading = "Level";
                result.level = Utils.GetXMLNodeValue(spellNode, nowLoading);
                nowLoading = "CastingTime";
                result.castingTime = Utils.ToEnum<CastingTime>(Utils.GetXMLNodeValue(spellNode, nowLoading));
                result.components = Component.None;

                nowLoading = "Components";
                foreach (string curComp in Utils.GetXMLNodeValue(spellNode, nowLoading).Split(new char[] { ',' }))
                {
                    nowLoading = "Components - " + curComp;
                    result.components |= Utils.ToEnum<Component>(curComp);
                }

                nowLoading = "MaterialComponent";
                result.materialComponent = Utils.GetXMLNodeValue(spellNode, nowLoading, null);

                nowLoading = "MaterialCost";
                switch (Utils.GetXMLNodeValue(spellNode, nowLoading))
                {
                    case "":
                        result.materialCost = null;
                        break;
                    default:
                        result.materialCost = float.Parse(Utils.GetXMLNodeValue(spellNode, nowLoading));
                        break;
                }

                nowLoading = "FocusComponent";
                result.focusComponent = Utils.GetXMLNodeValue(spellNode, nowLoading, null);
                nowLoading = "Range";
                result.range = Utils.GetXMLNodeValue(spellNode, nowLoading);
                nowLoading = "Area";
                result.area = Utils.GetXMLNodeValue(spellNode, nowLoading, null);
                nowLoading = "Target";
                result.target = Utils.GetXMLNodeValue(spellNode, nowLoading, null);
                nowLoading = "Duration";
                result.duration = Utils.GetXMLNodeValue(spellNode, nowLoading);
                nowLoading = "SavingThrow";
                result.savingThrow = Utils.GetXMLNodeValue(spellNode, nowLoading, null);

                nowLoading = "SpellResistance";
                switch (Utils.GetXMLNodeValue(spellNode, nowLoading).ToUpper())
                {
                    case "YES":
                    case "TRUE":
                        result.spellResistance = true;
                        break;
                    case "NO":
                    case "FALSE":
                        result.spellResistance = false;
                        break;
                    default:
                        result.spellResistance = null;
                        break;
                }

                nowLoading = "ShortDescription";
                result.shortDescription = Utils.GetXMLNodeValue(spellNode, nowLoading);
                nowLoading = "Description";
                result.description = Utils.GetXMLNodeValue(spellNode, nowLoading);
                nowLoading = "SpellLikeLevel";
                result.spellLikeLevel = int.Parse(Utils.GetXMLNodeValue(spellNode, nowLoading));
                nowLoading = "Link";
                result.link = Utils.GetXMLNodeValue(spellNode, nowLoading);
                result.qualities = Quality.NA;

                nowLoading = "Qualities";

                if (spellNode.SelectSingleNode(nowLoading) != null)
                {
                    foreach (string curQuality in Utils.GetXMLNodeValue(spellNode, nowLoading).Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                    {
                        nowLoading = "Qualities - " + curQuality;
                        result.qualities |= Utils.ToEnum<Quality>(curQuality);
                    }
                }

                return result;
            }
            catch (Exception e)
            {
                if ((result == null) || (nowLoading == null) || (nowLoading == "Name"))
                    Globals.DispatchMessage("An error occurred loading a spell!", "An error occurred loading this spell node:" + System.Environment.NewLine + e.Message + System.Environment.NewLine + System.Environment.NewLine + spellNode.OuterXml);
                else
                    Globals.DispatchMessage("An error occurred loading the \"" + result.name + "\" spell!", "An error occurred loading the \"" + result.name + "\" spell - unable to load " + nowLoading + " information:" + System.Environment.NewLine + System.Environment.NewLine + e.Message);

                return null;
            }
        }
    }

    public class SpellDatabase : SortedList<string, Spell>
    {
        public void LoadFromFile(string filePath)
        {
            Clear();

            XmlDocument spellDoc = new XmlDocument();
            spellDoc.Load(System.Environment.CurrentDirectory + "\\Data\\" + filePath);
            LoadFromXml(spellDoc);

            if (File.Exists(System.Environment.CurrentDirectory + "\\Data\\Custom" + filePath))
            {
                try
                {
                    spellDoc = new XmlDocument();
                    spellDoc.Load(System.Environment.CurrentDirectory + "\\Data\\Custom" + filePath);
                    LoadFromXml(spellDoc);
                }
                catch (Exception e)
                {
                    Globals.DispatchMessage("Error loading Custom" + filePath + "!", "Error loading Custom" + filePath + "!" + System.Environment.NewLine + System.Environment.NewLine + e.Message);
                }
            }
        }

        public void LoadFromXml(XmlDocument loadMe)
        {
            foreach (XmlNode curSpell in loadMe.SelectNodes("/SpellDatabase/Spell"))
                Add(Spell.ParseSpellNode(curSpell));
        }

        public void Add(Spell addMe)
        {
            if (addMe != null)
                Add(addMe.name, addMe);
        }
    }
}
