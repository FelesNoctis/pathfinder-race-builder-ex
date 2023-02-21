using System;
using System.Collections.Generic;
using System.Text;

namespace PathfinderSystem
{
    public sealed class Prerequisite
    {
        public enum PrerequisiteLogic
        {
            And,
            Or,
        }

        private PrerequisiteLogic logic = PrerequisiteLogic.And;
        private List<KeyValuePair<string, string>> criteria = new List<KeyValuePair<string, string>>();

        public Prerequisite(PrerequisiteLogic newLogic = PrerequisiteLogic.And)
        {
            logic = newLogic;
        }

        public void Add(string attribute, string text)
        {
            criteria.Add(new KeyValuePair<string, string>(attribute, text));
        }

        public bool MeetsCriteria(Character curChar, int atLevel)
        {
            bool tmpResult = false;
            int tmpValue;

            foreach (KeyValuePair<string, string> criterion in criteria)
            {
                // if ((criterion.Key.StartsWith("Skill")) && (Enum.GetNames(typeof(Skill.SkillKey)).Contains(criterion.Key.Substring(5))))
                if ((criterion.Key.StartsWith("Skill")) && (Utils.ArrayContains(Enum.GetNames(typeof(Skill.SkillKey)), criterion.Key.Substring(5))))
                {
                    tmpResult = (curChar.SkillRank(Globals.AttributeList[criterion.Key], atLevel) >= int.Parse(criterion.Value));
                }
                else
                {
                    switch (criterion.Key)
                    {
                        case "Alignment":
                            tmpResult = (curChar.alignment.ToString() == criterion.Value);
                            break;
                        case "BaseAttackBonus":
                            tmpResult = (curChar.BaseAttackBonus(atLevel) >= int.Parse(criterion.Value));
                            break;
                        case "Darkvision":
                            tmpResult = (curChar.GetAllBonuses(Globals.AttributeList["DarkVision"], atLevel) == int.Parse(criterion.Value));
                            break;
                        case "Feat":
                            tmpResult = curChar.HasFeat(criterion.Value, atLevel);
                            break;
                        case "Level":
                            tmpResult = (atLevel >= int.Parse(criterion.Value));
                            break;
                        case "Race":
                            tmpResult = (curChar.race.name.ToUpper() == criterion.Value.ToUpper());
                            break;
                        case "Size":
                            tmpResult = (curChar.race.size.ToString() == criterion.Value);
                            break;
                        default:
                            if (!int.TryParse(criterion.Value, out tmpValue))
                            {
                                tmpValue = 0;
                            }

                            tmpResult = (curChar.GetAllBonuses(Globals.AttributeList[criterion.Key], atLevel) >= tmpValue);

                            break;
                    }
                }

                if (tmpResult)
                {
                    if (logic == PrerequisiteLogic.Or)
                        return true;
                }
                else if (logic == PrerequisiteLogic.And)
                    return false;
            }

            if (logic == PrerequisiteLogic.And)
                return true;
            else
                return false;
        }

        public override string ToString()
        {
            string result = string.Empty;

            for (int i = 0; i < criteria.Count; i++)
            {
                if (i > 0)
                {
                    if (logic == PrerequisiteLogic.Or)
                    {
                        if (i == criteria.Count - 1)
                        {
                            if (criteria.Count == 2)
                                result += " or ";
                            else
                                result += ", or ";
                        }
                        else
                            result += ", ";
                    }
                    else
                        result += "; ";
                }

                //if ((criteria[i].Key.StartsWith("Skill")) && (Enum.GetNames(typeof(Skill.SkillKey)).Contains(criteria[i].Key.Substring(5))))
                if ((criteria[i].Key.StartsWith("Skill")) && (Utils.ArrayContains(Enum.GetNames(typeof(Skill.SkillKey)), criteria[i].Key.Substring(5))))
                {
                    Skill.SkillKey skill;

                    skill = Utils.ToEnum<Skill.SkillKey>(criteria[i].Key.Substring(5), Skill.SkillKey.Acrobatics);

                    result += Globals.skillDB[skill].displayName + ' ' + criteria[i].Value + " rank";

                    if (criteria[i].Value != "1")
                        result += 's';
                }
                else
                {
                    switch (criteria[i].Key)
                    {
                        case "Alignment":
                        case "Feat":
                        case "Race":
                            result += criteria[i].Value;
                            break;
                        case "BaseAttackBonus":
                            result += "Base attack bonus +" + criteria[i].Value;
                            break;
                        case "Darkvision":
                            result += criteria[i].Key + ' ' + criteria[i].Value + " feet";
                            break;
                        case "Level":
                            result += "Character level " + criteria[i].Value;

                            if (criteria[i].Value == "1")
                                result += "st";
                            else if (criteria[i].Value == "2")
                                result += "nd";
                            else if (criteria[i].Value == "3")
                                result += "rd";
                            else
                                result += "th";
                            break;
                        case "Size":
                            if (result.StartsWith("Size"))
                                result += criteria[i].Value;
                            else
                                result += criteria[i].Key + ' ' + criteria[i].Value;
                            break;
                        default:
                            result += criteria[i].Key + ' ' + criteria[i].Value;
                            break;
                    }
                }
            }

            return result;
        }
    }
}
