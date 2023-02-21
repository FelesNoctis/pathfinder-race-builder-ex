using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;

namespace PathfinderSystem
{
    public class Feat
    {
        [Flags]
        public enum FeatType
        {
            General = 0,
            Combat = 1,
            Metamagic = 2,
            Teamwork = 4,
            Critical = 8,
            Luck = 16,
            Faction = 32,
            Local = 64,
        }

        public string name;
        public string shortDescription;
        public string description;
        public string link;
        public FeatType type;
        public List<Prerequisite> prerequisites = new List<Prerequisite>();
        public List<Bonus> bonuses = new List<Bonus>();

        public Feat(FeatType newType)
        {
            description = string.Empty;
            type = newType;
        }

        public virtual void TryBonusesAtLevel(int key, Globals.ModifierDescriptor modifier, int level, Character curChar, ref int bonus, ref int penalty)
        {
            foreach (Bonus curBonus in bonuses)
                curBonus.TryBonus(key, modifier, ref bonus, ref penalty);
        }

        public virtual bool Qualifies(Character character, int atLevel = 20)
        {
            foreach (Prerequisite current in prerequisites)
            {
                if (!current.MeetsCriteria(character, atLevel))
                    return false;
            }

            return true;
        }

        public static Feat ParseFeatNode(XmlNode featNode)
        {
            string nowLoading = null;
            Feat result = null;

            try
            {
                FeatType newType = (FeatType)Enum.Parse(typeof(FeatType), Utils.GetXMLNodeValue(featNode, "Type", "General"));

                switch (featNode.Name)
                {
                    case "ArmorFeat":
                        result = new ArmorProficiencyFeat(Utils.GetXMLNodeValue(featNode, "Name"));
                        break;
                    case "SkillFeat":
                        result = new SkillFeat(Utils.GetXMLNodeValue(featNode, "Skill[1]"), Utils.GetXMLNodeValue(featNode, "Skill[2]"));
                        break;
                    case "SkillFocusFeat":
                        result = new SkillFocusFeat();
                        break;
                    default:
                        result = new Feat(newType);
                        break;
                }

                nowLoading = "Name";
                result.name = Utils.GetXMLNodeValue(featNode, nowLoading);
                nowLoading = "Link";
                result.link = Utils.GetXMLNodeValue(featNode, nowLoading);
                nowLoading = "ShortDescription";
                result.shortDescription = Utils.GetXMLNodeValue(featNode, nowLoading);

                foreach (XmlNode prereqNode in featNode.SelectNodes("PrerequisiteList/Prerequisite"))
                {
                    Prerequisite curPrerequisite;
                    Prerequisite.PrerequisiteLogic logic;

                    logic = Utils.ToEnum<Prerequisite.PrerequisiteLogic>(Utils.GetXMLNodeValue(prereqNode, "@logic"), Prerequisite.PrerequisiteLogic.And);

                    curPrerequisite = new Prerequisite(logic);

                    foreach (XmlNode criterionNode in prereqNode.SelectNodes("Criterion"))
                    {
                        nowLoading = "Prerequisite Criterion (" + Utils.GetXMLNodeValue(criterionNode, "Key") + Utils.GetXMLNodeValue(criterionNode, "Value") + ')';
                        curPrerequisite.Add(Utils.GetXMLNodeValue(criterionNode, "Key"), Utils.GetXMLNodeValue(criterionNode, "Value"));
                    }

                    result.prerequisites.Add(curPrerequisite);
                }

                nowLoading = "Custom BonusList";
                foreach (XmlNode bonusNode in featNode.SelectNodes("BonusList/Bonus"))
                    result.bonuses.Add(Bonus.ParseBonusNode(bonusNode));

                return result;
            }
            catch (Exception e)
            {
                if ((result == null) || (nowLoading == null) || (nowLoading == "Name"))
                    Globals.DispatchMessage("An error occurred loading a feat!", "An error occurred loading this feat node:" + System.Environment.NewLine + e.Message + System.Environment.NewLine + System.Environment.NewLine + featNode.OuterXml);
                else
                    Globals.DispatchMessage("An error occurred loading the \"" + result.name + "\" feat!", "An error occurred loading the \"" + result.name + "\" feat - unable to load " + nowLoading + " information:" + System.Environment.NewLine + System.Environment.NewLine + e.Message);

                return null;
            }
        }
    }

    public class SkillFeat : Feat
    {
        int firstSkill;
        int secondSkill;

        public SkillFeat(string primarySkill, string secondarySkill)
            : base(Feat.FeatType.General)
        {
            if (!Globals.AttributeList.Contains("Skill" + primarySkill))
                throw new Exception("Invalid skill key \"" + primarySkill + '"');

            if (!Globals.AttributeList.Contains("Skill" + secondarySkill))
                throw new Exception("Invalid skill key \"" + secondarySkill + '"');

            firstSkill = Globals.AttributeList["Skill" + primarySkill];
            secondSkill = Globals.AttributeList["Skill" + secondarySkill];
        }

        public override void TryBonusesAtLevel(int key, Globals.ModifierDescriptor modifier, int level, Character curChar, ref int bonus, ref int penalty)
        {
            if ((modifier == Globals.ModifierDescriptor.Inherent) && ((key == firstSkill) || (key == secondSkill)))
            {
                if (curChar.SkillRank(key, level) < 10)
                    bonus += 2;
                else
                    bonus += 4;
            }
        }
    }

    public class SkillFocusFeat : Feat
    {
        public SkillFocusFeat() : base(Feat.FeatType.General) { }

        public override void TryBonusesAtLevel(int key, Globals.ModifierDescriptor modifier, int level, Character curChar, ref int bonus, ref int penalty)
        {
            /* TODO - Finish this once we can assign a skill to the feat!
            if ((modifier == Globals.ModifierDescriptor.Inherent) && (key == ???))
            {
                if (curChar.SkillRank(key, level) < 10)
                    bonus += 3;
                else
                    bonus += 6;
            }
            */
        }
    }

    public class ArmorProficiencyFeat : Feat
    {
        Armor.ArmorType grantsProficiency;

        public ArmorProficiencyFeat(string newName)
            : base(FeatType.Combat)
        {
            string stripName = newName.Replace(" ", string.Empty);

            foreach (Armor.ArmorType curType in Enum.GetValues(typeof(Armor.ArmorType)))
            {
                if (stripName.Contains(curType.ToString()))
                {
                    grantsProficiency = curType;
                    return;
                }
            }
        }

        public override bool Qualifies(Character character, int atLevel = 20)
        {
            foreach (CharacterLevel level in character.levels)
            {
                if ((level.chosenClass.armorProficiency & grantsProficiency) > 0)
                    return false;
            }

            return base.Qualifies(character, atLevel);
        }
    }

    public class FeatDatabase : SortedList<string, Feat>
    {
        public void LoadFromFile(string filePath)
        {
            Clear();

            XmlDocument featDoc = new XmlDocument();

            featDoc.Load(System.Environment.CurrentDirectory + "\\Data\\" + filePath);
            LoadFromXml(featDoc);

            if (File.Exists(System.Environment.CurrentDirectory + "\\Data\\Custom" + filePath))
            {
                try
                {
                    featDoc = new XmlDocument();
                    featDoc.Load(System.Environment.CurrentDirectory + "\\Data\\Custom" + filePath);
                    LoadFromXml(featDoc);
                }
                catch (Exception e)
                {
                    Globals.DispatchMessage("Error loading Custom" + filePath + "!", "Error loading Custom" + filePath + "!" + System.Environment.NewLine + System.Environment.NewLine + e.Message);
                }
            }
        }

        private void LoadFromXml(XmlDocument loadMe)
        {
            foreach (XmlNode curFeat in loadMe.SelectNodes("/FeatDatabase/*"))
                Add(Feat.ParseFeatNode(curFeat));
        }

        public void Add(Feat addMe)
        {
            if (addMe != null)
                Add(addMe.name, addMe);
        }
    }
}
