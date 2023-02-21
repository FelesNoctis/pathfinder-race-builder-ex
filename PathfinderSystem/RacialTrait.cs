using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Windows.Forms;

namespace PathfinderSystem
{
    public class RacialTrait
    {
        public enum RequiredPowerLevel
        {
            Any = 0,
            Advanced = 1,
            Monstrous = 2,
        }

        public enum TraitType
        {
            AbilityScore,
            Defense,
            FeatAndSkill,
            Magical,
            Movement,
            Offense,
            Senses,
            Weakness,
            Other,
        }

        public delegate bool AdditionalSettingsCallback(RacialTrait trait, int ranks, ref string[] info);

        public string name;
        protected string[] descriptionList;
        public string description
        {
            get
            {
                return descriptionList[0];
            }
        }

        public string special;
        public string prerequisites;
        public RequiredPowerLevel powerLevel;
        public TraitType type;
        public int pointCost;
        public int repeatLimit;
        public int repeatCostIncrease;
        public List<Bonus> bonuses = new List<Bonus>();
        public string[] raceEntries = null;

        public AdditionalSettingsCallback settingsFunction = null;

        public static int Compare(RacialTrait x, RacialTrait y)
        {
            if (x.type < y.type)
                return -1;
            else if (x.type > y.type)
                return 1;

            return string.Compare(x.name, y.name);
        }

        public virtual int GetCost(int ranks, string[] extraData)
        {
            int total = pointCost;

            if (ranks > 1)
            {
                // Negative increase denotes fixed cost per increase that differs from the original cost
                if (repeatCostIncrease < 0)
                    total -= (ranks - 1) * repeatCostIncrease;
                else
                {
                    total += (ranks - 1) * pointCost;

                    total += repeatCostIncrease * ((ranks * (ranks - 1)) / 2);
                }
            }

            return total;
        }

        public virtual string GetDescription(int ranks)
        {
            return descriptionList[Math.Min(ranks, descriptionList.Length - 1)];
        }

        public virtual string GetEntry(int ranks, string[] extraData)
        {
            if (raceEntries != null)
            {
                int start, end;
                string tmpStr;
                string curEntry = raceEntries[ranks - 1];

                start = curEntry.IndexOf('[');

                while (start > -1)
                {
                    string[] split;
                    end = curEntry.IndexOf(']', start);
                    tmpStr = curEntry.Substring(start + 1, end - start - 1);

                    split = tmpStr.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);

                    switch (split[0])
                    {
                        case "DAMAGE":
                            curEntry = curEntry.Replace('[' + tmpStr + ']', Utils.ResizeDie(split[1], Globals.character.race.size));
                            break;
                    }

                    start = curEntry.IndexOf('[', end);
                }

                return curEntry;
            }
            else
                return null;
        }

        public virtual bool Validate(int ranks, string[] extraData)
        {
            return true;
        }

        public virtual void TryBonus(int ranks, string[] extraData, int key, Globals.ModifierDescriptor modifier, ref int bonus, ref int penalty)
        {
            for (int i = 0; i < ranks; i++)
            {
                foreach (Bonus curBonus in bonuses)
                    curBonus.TryBonus(key, modifier, ref bonus, ref penalty);
            }
        }

        public static RacialTrait ParseTraitNode(XmlNode traitNode)
        {
            string nowLoading = null;
            RacialTrait result = null;

            try
            {
                int i, temp;

                switch (traitNode.Name)
                {
                    case "BonusFeatTrait":
                        result = new BonusFeatTrait(Utils.GetXMLNodeValue(traitNode, "Feat"));
                        break;
                    case "BreathWeaponTrait":
                        result = new BreathWeaponTrait();
                        break;
                    case "EnergyTypeTrait":
                        result = new EnergyTypeTrait(Utils.GetXMLNodeValue(traitNode, "BonusInfo"));
                        break;
                    case "FavoredTerrainTrait":
                        result = new FavoredTerrainTrait();
                        break;
                    case "GenericSelectionTrait":
                        result = new GenericSelectionTrait(traitNode.SelectNodes("OptionList/Option"));
                        break;
                    case "HatredTrait":
                        result = new HatredTrait();
                        break;
                    case "SkillBonusTrait":
                        result = new SkillBonusTrait();
                        break;
                    case "SkillTrainingTrait":
                        result = new SkillTrainingTrait();
                        break;
                    case "SpellLikeAbilityTrait":
                        result = new SpellLikeAbilityTrait(int.Parse(Utils.GetXMLNodeValue(traitNode, "MinLevel", "0")), int.Parse(Utils.GetXMLNodeValue(traitNode, "MaxLevel", "2")));
                        break;
                    case "SwarmingTrait":
                        result = new SwarmingTrait();
                        break;
                    case "WeaponFamiliarityTrait":
                        result = new WeaponFamiliarityTrait();
                        break;
                    default:
                        result = new RacialTrait();
                        break;
                }

                nowLoading = "Name";
                result.name = Utils.GetXMLNodeValue(traitNode, nowLoading);

                nowLoading = "Advanced descriptions";
                temp = traitNode.SelectNodes("Advanced").Count;
                result.descriptionList = new string[temp + 1];

                nowLoading = "Description";
                result.descriptionList[0] = Utils.GetXMLNodeValue(traitNode, nowLoading);

                for (i = 1; i <= temp; i++)
                {
                    nowLoading = "Advanced description #" + i;
                    result.descriptionList[i] = Utils.GetXMLNodeValue(traitNode, "Advanced[" + i + ']');
                }

                nowLoading = "Special";
                result.special = Utils.GetXMLNodeValue(traitNode, nowLoading);
                nowLoading = "Prerequisite";
                result.prerequisites = Utils.GetXMLNodeValue(traitNode, nowLoading);
                nowLoading = "PowerLevel";
                result.powerLevel = Utils.ToEnum<RequiredPowerLevel>(Utils.GetXMLNodeValue(traitNode, nowLoading), RequiredPowerLevel.Any);
                nowLoading = "Type";
                result.type = Utils.ToEnum<TraitType>(Utils.GetXMLNodeValue(traitNode, nowLoading));
                nowLoading = "Cost";
                result.pointCost = int.Parse(Utils.GetXMLNodeValue(traitNode, nowLoading));
                nowLoading = "Limit";
                result.repeatLimit = int.Parse(Utils.GetXMLNodeValue(traitNode, nowLoading, "1"));
                nowLoading = "CostIncrease";
                result.repeatCostIncrease = int.Parse(Utils.GetXMLNodeValue(traitNode, nowLoading, "0"));

                nowLoading = "Entries";
                temp = traitNode.SelectNodes("Entry").Count;

                if (temp > 0)
                {
                    result.raceEntries = new string[temp];

                    for (i = 0; i < temp; i++)
                    {
                        nowLoading = "Entry #" + (i + 1).ToString();
                        result.raceEntries[i] = Utils.GetXMLNodeValue(traitNode, "Entry[" + (i + 1) + ']');
                    }
                }

                nowLoading = "BonusList";
                foreach (XmlNode curBonus in traitNode.SelectNodes("BonusList/Bonus"))
                    result.bonuses.Add(Bonus.ParseBonusNode(curBonus));

                return result;
            }
            catch (Exception e)
            {
                if ((result == null) || (nowLoading == null) || (nowLoading == "Name"))
                    Globals.DispatchMessage("An error occurred loading a racial trait!", "An error occurred loading this racial trait node:" + System.Environment.NewLine + e.Message + System.Environment.NewLine + System.Environment.NewLine + traitNode.OuterXml);
                else
                    Globals.DispatchMessage("An error occurred loading the \"" + result.name + "\" racial trait!", "An error occurred loading the \"" + result.name + "\" racial trait - unable to load " + nowLoading + " information:" + System.Environment.NewLine + System.Environment.NewLine + e.Message);

                return null;
            }
        }
    }

    public class GenericSelectionTrait : RacialTrait
    {
        public string[] options;
        private string[] optionInfo;

        public GenericSelectionTrait(XmlNodeList xmlOptions)
        {
            options = new string[xmlOptions.Count];
            optionInfo = new string[xmlOptions.Count];

            for (int i = 0; i < xmlOptions.Count; i++)
            {
                options[i] = xmlOptions[i].InnerText;
                optionInfo[i] = Utils.GetXMLNodeValue(xmlOptions[i], "@info");
            }
        }

        public override string GetEntry(int ranks, string[] extraData)
        {
            int selectedIndex = Array.IndexOf<string>(options, extraData[0]);

            return base.GetEntry(ranks, extraData).Replace("[SELECTEDITEM]", extraData[0]).Replace("[SELECTEDitem]", extraData[0].ToLower()).Replace("[SELECTEDINFO]", optionInfo[selectedIndex]).Replace("[SELECTEDinfo]", optionInfo[selectedIndex].ToLower());
        }

        public override bool Validate(int ranks, string[] extraData)
        {
            return (extraData[0] != string.Empty);
        }
    }

    public class EnergyTypeTrait : RacialTrait
    {
        public static readonly string[] planarOptions = { "Air", "Earth", "Fire", "Water" };
        string bonusKey;
        int bonusValue;
        Globals.ModifierDescriptor bonusType;

        public EnergyTypeTrait(string bonusInfo)
        {
            string[] split = bonusInfo.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

            if (split.Length == 3)
            {
                bonusKey = split[0];
                bonusValue = int.Parse(split[1]);
                bonusType = Utils.ToEnum<Globals.ModifierDescriptor>(split[2], Globals.ModifierDescriptor.Inherent);
            }
        }

        private string GetEnergyPlane(string energyType)
        {
            switch (energyType)
            {
                case "Acid":
                case "Earth":
                    return "Earth";
                case "Cold":
                case "Water":
                    return "Water";
                case "Electricity":
                case "Air":
                    return "Air";
                case "Fire":
                    return "Fire";
                default:
                    return string.Empty;
            }
        }

        private string StandardReplace(string input, string energyType)
        {
            if (input != null)
                return input.Replace("[ENERGYTYPE]", energyType).Replace("[ENERGYtype]", energyType.ToLower()).Replace("[ENERGYPLANE]", GetEnergyPlane(energyType)).Replace("[ENERGYplane]", GetEnergyPlane(energyType).ToLower());
            else
                return null;
        }

        public override void TryBonus(int ranks, string[] extraData, int key, Globals.ModifierDescriptor modifier, ref int bonus, ref int penalty)
        {
            for (int i = 0; i < ranks; i++)
            {
                if ((modifier == bonusType) && (Globals.AttributeList[key] == StandardReplace(bonusKey, extraData[i])))
                {
                    Bonus.ModifierLogic(modifier, bonusValue, ref bonus, ref penalty);
                    return;
                }
            }
        }

        public override string GetEntry(int ranks, string[] extraData)
        {
            return StandardReplace(base.GetEntry(ranks, extraData), extraData[0]);
        }

        public override bool Validate(int ranks, string[] extraData)
        {
            for (int i = 0; i < ranks; i++)
            {
                if (extraData[i] == string.Empty)
                    return false;
            }

            return true;
        }
    }

    public class SkillBonusTrait : RacialTrait
    {
        public Skill.SkillKey chosenSkill = Skill.SkillKey.None;

        /// <summary>
        ///     Special handling to fudge in fake bonuses, based on the user's selection
        /// </summary>
        public override void TryBonus(int ranks, string[] extraData, int key, Globals.ModifierDescriptor modifier, ref int bonus, ref int penalty)
        {
            if ((modifier == Globals.ModifierDescriptor.Racial) && (Globals.AttributeList[key].StartsWith("Skill")))
            {
                for (int i = 0; i < ranks; i++)
                {
                    foreach (string curString in (extraData[i]).Split(new char[] {';'}, StringSplitOptions.RemoveEmptyEntries))
                    {
                        int value = 0;

                        // Set value if we match a skill, or if the special value "Craft" was selected for this trait, use it for CraftPrimary
                        if ((Globals.AttributeList[key] == "Skill" + curString) || (curString == "Craft") && (Globals.AttributeList[key] == "SkillCraftPrimary"))
                            value = Math.Max(value, (curString.IndexOf(';') > -1) ? 1 : 2);

                        if (value > bonus)
                            bonus = value;
                    }
                }
            }
        }

        public override string GetEntry(int ranks, string[] extraData)
        {
            int curCount;
            int[] count = new int[2];
            string[] split;
            int value;
            string result, tmpValue;
            SortedList<string, int> tmpResults = new SortedList<string, int>();

            for (int i = 0; i < ranks; i++)
            {
                split = extraData[i].Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

                for (int j = 0; j < split.Length; j++)
                {
                    switch (split[j])
                    {
                        case "Craft":
                            tmpValue = "any single Craft skill";
                            break;
                        default:
                            //tmpValue = Globals.skillDB[Utils.ToEnum<Skill.SkillKey>(split[j], Skill.SkillKey.Acrobatics)].displayName;
                            tmpValue = split[j];
                            break;
                    }

                    value =  (split.Length) > 1 ? 1 : 2;

                    if (tmpResults.Keys.Contains(tmpValue))
                    {
                        if (tmpResults[tmpValue] < value)
                        {
                            tmpResults.Remove(tmpValue);
                            tmpResults.Add(tmpValue, value);
                            count[value - 1]++;
                        }
                    }
                    else
                    {
                        tmpResults.Add(tmpValue, value);
                        count[value - 1]++;
                    }
                }
            }

            result = "<b>Skill Bonus:</b> {0} have a ";

            curCount = 0;

            for (int i = 0; i < tmpResults.Count; i++)
            {
                if (tmpResults.Values[i] == 2)
                {
                    if (curCount == 0)
                        result += "+2 racial bonus on ";

                    if (curCount == 0)
                          result += tmpResults.Keys[i];
                    else if (curCount == count[1] - 1)
                      {
                          if (count[1] == 2)
                              result += " and " + tmpResults.Keys[i];
                          else
                              result += ", and " + tmpResults.Keys[i];
                      }
                      else
                          result += ", " + tmpResults.Keys[i];

                    curCount++;
                }
            }

            if (count[1] > 0)
            {
                result += " checks";

                if (count[0] > 0)
                    result += ", and a ";
            }

            curCount = 0;
            
            for (int i = 0; i < tmpResults.Count; i++)
            {
                if (tmpResults.Values[i] == 1)
                {
                    if (curCount == 0)
                        result += "+1 racial bonus on ";

                    if (curCount == 0)
                        result += tmpResults.Keys[i];
                    else if (curCount == count[0] - 1)
                    {
                        if (count[0] == 2)
                            result += " and " + tmpResults.Keys[i];
                        else
                            result += ", and " + tmpResults.Keys[i];
                    }
                    else
                        result += ", " + tmpResults.Keys[i];

                    curCount++;
                }
            }

            if (count[0] > 0)
                result += " checks";
            
            return result + '.';
        }

        public override bool Validate(int ranks, string[] extraData)
        {
            for (int i = 0; i < ranks; i++)
            {
                string temp = extraData[i];

                if (temp.IndexOf(';') > -1)
                {
                    if (temp.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries).Length != 2)
                        return false;
                }
                else if (temp == string.Empty)
                    return false;
            }

            return true;
        }
    }

    public class BreathWeaponTrait : RacialTrait
    {
        public override string GetEntry(int ranks, string[] extraData)
        {
            int times = 0;
            int area = 0;
            int damage = 0;
            int powerful = 0;

            int.TryParse(extraData[1], out times);
            times++;

            int.TryParse(extraData[2], out area);

            int.TryParse(extraData[3], out damage);
            damage++;

            int.TryParse(extraData[4], out powerful);

            string result = "<b>Breath Weapon (Su):</b> {0} have a breath weapon usable ";

            if (times == 1)
                result += "once";
            else
                result += times.ToString() + " times";

            result += " per day.  This breath weapon deals " + damage + "d6 " + extraData[0].ToLower() + " damage in a ";

            switch (area)
            {
                case 15:
                    result += "15-foot cone";
                    break;
                case 20:
                    result += "20-foot line";
                    break;
                case 30:
                    result += "30-foot cone";
                    break;
                case 50:
                    result += "50-foot line";
                    break;
                default:
                    result += "[ERROR: Invalid area; '" + area + "']";
                    break;
            }

            result += ". Creatures caught in the breath weapon must make a Reflex saving throw " + ((powerful > 0) ? "or take half" : "to avoid taking") + " damage. The save DC against this breath weapon is 10 + 1/2 the {1}'s character level + the {1}'s Constitution modifier.";

            return result;
        }

        public override bool Validate(int ranks, string[] extraData)
        {
            if (!Array.Exists<string>(Enum.GetNames(typeof(Globals.EnergyTypes)), curString => curString == extraData[0]))
                return false;

            if (ranks == 1)
            {
                extraData[1] = extraData[3] = extraData[4] = string.Empty;

                return ((extraData[2] == "15") || (extraData[2] == "20"));
            }

            int sum = 1;
            int value;

            value = 0;
            if (int.TryParse(extraData[1], out value))
                sum += value;

            value = 0;
            int.TryParse(extraData[2], out value);
            
            switch (value)
            {
                case 15:
                case 20:
                    break;
                case 30:
                case 50:
                    sum++;
                    break;
                default:
                    return false;
            }

            value = 0;
            if (int.TryParse(extraData[3], out value))
                sum += value;

            value = 0;
            if (int.TryParse(extraData[4], out value))
            {
                if (value > 1)
                    return false;
                else
                    sum += value;
            }

            return (sum == ranks);
        }
    }

    public class SkillTrainingTrait : RacialTrait
    {
        public override string GetEntry(int ranks, string[] extraData)
        {
            string[] split = extraData[0].Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            string result = "<b>Skill Training:</b> ";

            if (split.Length == 2)
            {
                for (int i = 0; i < 2; i++)
                {
                    switch (split[i])
                    {
                        case "Craft":
                            result += (i == 0)? 'A' : 'a';
                            result += "ny single Craft skill";
                            break;
                        default:
                            //result += Globals.skillDB[Utils.ToEnum<Skill.SkillKey>(split[i], Skill.SkillKey.Acrobatics)].displayName;
                            result += split[i];
                            break;
                    }

                    if (i == 0)
                        result += " and ";
                }

                result += " are always considered class skills for {2}.";
            }
            else
                result += "This trait was saved incorrectly!  Please try re-picking the skills.";

            return result;
        }

        public override bool Validate(int ranks, string[] extraData)
        {
            for (int i = 0; i < ranks; i++)
            {
                if (extraData[i].Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries).Length != 2)
                    return false;
            }

            return true;
        }
    }

    public class BonusFeatTrait : RacialTrait
    {
        string staticFeatName = string.Empty;

        public BonusFeatTrait(string bonusFeat)
        {
            if (bonusFeat != string.Empty)
                staticFeatName = bonusFeat;
        }

        public override string GetEntry(int ranks, string[] extraData)
        {
            string featName;

            if (staticFeatName != string.Empty)
                featName = staticFeatName;
            else
                featName = extraData[0];

            return "<b>" + ((name == "Static Bonus Feat") ? "Bonus Feat" : name) + "</b> {0} receive " + featName + " as a bonus feat.";
        }

        public override bool Validate(int ranks, string[] extraData)
        {
            return extraData[0] != string.Empty;
        }
    }

    public class FavoredTerrainTrait : RacialTrait
    {
        public override string GetEntry(int ranks, string[] extraData)
        {
            return base.GetEntry(ranks, extraData).Replace("[TERRAINTYPE]", ClassRanger.FavoredTerrain.Get(extraData[0]).name).Replace("[TERRAINSTRING]", ClassRanger.FavoredTerrain.Get(extraData[0]).sentenceText);
        }

        public override bool Validate(int ranks, string[] extraData)
        {
            return extraData[0] != string.Empty;
        }
    }

    public class HatredTrait : RacialTrait
    {
        public override string GetEntry(int ranks, string[] extraData)
        {
            string result = "<b>Hatred:</b> {0} receive a +1 racial bonus on attack rolls against ";

            if (extraData[0].Contains(";"))
            {
                result += string.Format("humanoids of the {0} and {1} subtypes.", extraData[0].Substring(0, extraData[0].IndexOf(';')).ToLower(), extraData[0].Substring(extraData[0].IndexOf(';') + 1).ToLower());
            }
            else
                result += extraData[0].ToLower() + '.';

            return result;
        }
        public override bool Validate(int ranks, string[] extraData)
        {
            return extraData[0] != string.Empty;
        }
    }

    public class WeaponFamiliarityTrait : RacialTrait
    {
        public override string GetEntry(int ranks, string[] extraData)
        {
            int i;
            string[] split;
            string tmpStr;
            string result = "<b>Weapon Familiarity:</b> {0}";
            List<string> weapons = new List<string>();
            List<string> racialWeapons = new List<string>();

            for (i = 0; i < ranks; i++)
            {
                split = extraData[i].Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

                for (int j = 0; j < split.Length; j++)
                {
                    switch (split[j])
                    {
                        case "Bows":
                            weapons.Add("longbows (including composite longbows)");
                            weapons.Add("shortbows (including composite shortbows)");
                            break;
                        default:
                            if (split[j].Contains(" Weapons"))
                                racialWeapons.Add(split[j].Substring(0, split[j].IndexOf(" Weapons")).ToLower());
                            else
                                weapons.Add(split[j].ToLower() + 's');
                            break;
                    }
                }
            }

            weapons.Sort();

            if (weapons.Count > 0)
                result +=  " are proficient with ";

            for (i = 0; i < weapons.Count; i++)
            {
                if (i == 0)
                    result += weapons[i];
                else if ((racialWeapons.Count == 0) && (i == weapons.Count - 1))
                {
                    if (weapons.Count == 2)
                        result += " and " + weapons[i] + '.';
                    else
                        result += ", and " + weapons[i] + '.';
                }
                else
                    result += ", " + weapons[i];
            }

            if (racialWeapons.Count > 0)
            {
                if (weapons.Count > 1)
                    result += ',';

                if (weapons.Count > 0)
                    result += " and";

                result += " treat any weapon with ";

                for (i = 0; i < racialWeapons.Count; i++)
                {
                    if (racialWeapons[i] == "racial")
                        tmpStr = "the race's name";
                    else
                        tmpStr = "the word \"" + racialWeapons[i] + "\"";

                    if (i == 0)
                        result += tmpStr;
                    else if (i == racialWeapons.Count - 1)
                    {
                        if (racialWeapons.Count == 2)
                            result += " or " + tmpStr;
                        else
                            result += ", or " + tmpStr;
                    }
                    else
                        result += ", " + tmpStr;
                }

                result += " in its name as a martial weapon.";
            }

            return result;
        }

        public override bool Validate(int ranks, string[] extraData)
        {
            for (int i = 0; i < ranks; i++)
            {
                if (extraData[i].Length <= 1) // Set the check level at 1 just in case a semicolon gets in there somehow?
                    return false;
            }

            return true;
        }
    }

    public class SwarmingTrait : RacialTrait
    {
        public override int GetCost(int ranks, string[] extraData)
        {
            if (Globals.character.race.size < Globals.Size.Medium)
                return pointCost;
            else
                return 2 * pointCost;
        }
    }

    public class SpellLikeAbilityTrait : RacialTrait
    {
        public int minLevel, maxLevel;

        public SpellLikeAbilityTrait(int levelMin, int levelMax)
        {
            minLevel = levelMin;
            maxLevel = levelMax;
        }

        public override int GetCost(int ranks, string[] extraData)
        {
            int total = 0;

            for (int i = 0; i < ranks; i++)
            {
                if (Globals.spellDB.Keys.Contains(extraData[i]))
                    total += pointCost * Math.Max(1, Globals.spellDB[extraData[i]].spellLikeLevel);
            }

            return total;
        }

        public override bool Validate(int ranks, string[] extraData)
        {
            for (int i = 0; i < ranks; i++)
            {
                if (!Globals.spellDB.Keys.Contains(extraData[i]))
                    return false;
            }

            return true;
        }
    }

    public sealed class RaceTraitDatabase : SortedList<string, RacialTrait>
    {
        public void LoadFromFile(string filePath)
        {
            Clear();

            XmlDocument traitDoc = new XmlDocument();
            traitDoc.Load(System.Environment.CurrentDirectory + "\\Data\\" + filePath);
            LoadFromXml(traitDoc);

            if (File.Exists(System.Environment.CurrentDirectory + "\\Data\\Custom" + filePath))
            {
                try
                {
                    traitDoc = new XmlDocument();
                    traitDoc.Load(System.Environment.CurrentDirectory + "\\Data\\Custom" + filePath);
                    LoadFromXml(traitDoc);
                }
                catch (Exception e)
                {
                    Globals.DispatchMessage("Error loading Custom" + filePath + "!", "Error loading Custom" + filePath + "!" + System.Environment.NewLine + System.Environment.NewLine + e.Message);
                }
            }
        }

        public void LoadFromXml(XmlDocument loadMe)
        {
            foreach (XmlNode curTrait in loadMe.SelectNodes("/RaceTraits/*"))
                Add(RacialTrait.ParseTraitNode(curTrait));
        }

        public void Add(RacialTrait addMe)
        {
            if (addMe != null)
                Add(addMe.name, addMe);
        }
    }
}
