using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Xml;
using System.Windows.Forms;

namespace PathfinderSystem
{
    public sealed class Race
    {
        public static readonly string[] commonSubtypes =
        {
            "aquatic",
            "catfolk",
            "changeling",
            "dhampir",
            "dwarf",
            "elf",
            "giant",
            "goblinoid",
            "gnoll",
            "gnome",
            "grippli",
            "halfling",
            "human",
            "kitsune",
            "orc",
            "ratfolk",
            "reptilian",
            "samsaran",
            "strix",
            "tengu",
            "vanara",
            "vishkanya",
            "wayang",
        };

        public static readonly string[,] subtypeRacialWeaponConversions =
        {
            { "dwarf", "dwarven" },
            { "elf", "elven" },
            { "gnome", "gnome" },
            { "orc", "orc" },
        };

        public enum AttributePackages
        {
            Advanced = 0,
            Flexible = 1,
            GreaterParagon = 2,
            GreaterWeakness = 3,
            HumanHeritage = 4,
            MixedWeakness = 5,
            Paragon = 6,
            Specialized = 7,
            Standard = 8,
            Weakness = 9,
        }

        public enum LanguageQualityOptions
        {
            Linguist = 0,
            Standard = 1,
            Xenophobe = 2,
        }
        public string name = string.Empty;
        public string namePlural = string.Empty;
        public string nameAdjective = string.Empty;
        /// <summary>
        /// Paizo race (read only)
        /// </summary>
        public bool paizo = false;
        /// <summary>
        /// Flags the race as custom-built (i.e. incompatible with the ARG rules)
        /// </summary>
        public bool custom = false;
        public string flavorText = string.Empty;
        public string appearanceDescription = string.Empty;
        public CreatureType type;
        public string subtype = string.Empty;
        public Globals.Size size = Globals.Size.Medium;
        public int baseSpeed;
        public AttributePackages attributePackage = AttributePackages.HumanHeritage;
        public int[] attributeModifiers = { 0, 0, 0, 0, 0, 0 };
        public LanguageQualityOptions languageQuality = LanguageQualityOptions.Standard;
        public string[] startingLanguages = null;
        public string[] availableLanguages = null;
        public List<RaceTraitLink> traits = new List<RaceTraitLink>();
        public List<Bonus> bonuses = null;

        private int racePointsStatic = 0;

        public int raceBuilderPoints
        {
            get
            {
                if (custom)
                    return racePointsStatic;

                int total = 0;

                if (type != null)
                    total += type.buildPoints;

                switch (size)
                {
                    case Globals.Size.Large:
                        total += 7;
                        break;
                    case Globals.Size.Tiny:
                        total += 4;
                        break;
                }

                if (baseSpeed == 20)
                    total--;

                switch (attributePackage)
                {
                    case AttributePackages.Advanced:
                        total += 4;
                        break;
                    case AttributePackages.Flexible:
                    case AttributePackages.GreaterParagon:
                        total += 2;
                        break;
                    case AttributePackages.Paragon:
                    case AttributePackages.Specialized:
                        total += 1;
                        break;
                    case AttributePackages.Weakness:
                        total -= 1;
                        break;
                    case AttributePackages.MixedWeakness:
                        total -= 2;
                        break;
                    case AttributePackages.GreaterWeakness:
                        total -= 3;
                        break;

                }

                if (languageQuality == LanguageQualityOptions.Linguist)
                    total++;

                foreach (RaceTraitLink curLink in traits)
                    total += curLink.racePoints;

                return total;
            }
        }

        public int HasTrait(string traitName)
        {
            foreach (RaceTraitLink curLink in traits)
            {
                if (curLink.trait.name == traitName)
                    return curLink.count;
            }

            return 0;
        }

        public int HasTrait(RacialTrait testMe)
        {
            return HasTrait(testMe.name);
        }

        public RaceTraitLink GetLink(string traitName)
        {
            foreach (RaceTraitLink curLink in traits)
            {
                if (curLink.trait.name == traitName)
                    return curLink;
            }

            return null;
        }

        public RaceTraitLink AddTrait(RacialTrait addMe)
        {
            foreach (RaceTraitLink curLink in traits)
            {
                if (curLink.trait.name == addMe.name)
                {
                    curLink.count++;
                    return curLink;
                }
            }

            RaceTraitLink newLink = new RaceTraitLink(addMe);
            traits.Add(newLink);
            return newLink;
        }

        public int RemoveTrait(string removeMe)
        {
            foreach (RaceTraitLink curLink in traits)
            {
                if (curLink.trait.name == removeMe)
                {
                    curLink.count--;

                    if (curLink.count <= 0)
                        traits.Remove(curLink);

                    return curLink.count;
                }
            }

            return -1;
        }

        public void TryBonus(int key, Globals.ModifierDescriptor modifier, ref int bonus, ref int penalty)
        {
            foreach (RacialTrait curTrait in type.intrinsicTraits)
            {
                foreach (Bonus curBonus in curTrait.bonuses)
                    curBonus.TryBonus(key, modifier, ref bonus, ref penalty);
            }

            foreach (RaceTraitLink curLink in traits)
                curLink.trait.TryBonus(curLink.count, curLink.traitData, key, modifier, ref bonus, ref penalty);
        }

        /// <summary>
        /// Creates a deep copy of this race for editing.
        /// </summary>
        public Race Duplicate()
        {
            int i, j;

            // Start with a shallow clone...
            Race result = (Race)MemberwiseClone();

            result.paizo = false; // The editing copy is never considered core!

            // ...then fill in any instanced objects.
            if (startingLanguages != null)
            {
                result.startingLanguages = new string[startingLanguages.Length];

                for (i = 0; i < startingLanguages.Length; i++)
                    result.startingLanguages[i] = startingLanguages[i];
            }

            if (availableLanguages != null)
            {
                result.availableLanguages = new string[availableLanguages.Length];

                for (i = 0; i < availableLanguages.Length; i++)
                    result.availableLanguages[i] = availableLanguages[i];
            }

            result.traits = new List<RaceTraitLink>(traits.Count);

            for (i = 0; i < traits.Count; i++)
            {
                RaceTraitLink newLink = new RaceTraitLink(traits[i].trait);
                newLink.count = traits[i].count;

                for (j = 0; j < traits[i].count; j++)
                    newLink.traitData[j] = traits[i].traitData[j];

                result.traits.Add(newLink);
            }

            return result;
        }

        public void Save(XmlTextWriter save)
        {
            int i;

            save.WriteStartElement("Race");

            save.WriteAttributeString("Points", raceBuilderPoints.ToString());

            save.WriteElementString("Name", name);
            save.WriteElementString("NamePlural", namePlural);
            save.WriteElementString("NameAdjective", nameAdjective);
            save.WriteElementString("FlavorText", flavorText);
            save.WriteElementString("AppearanceDescription", appearanceDescription);
            save.WriteElementString("Type", type.name);
            save.WriteElementString("Subtype", subtype);
            save.WriteElementString("Size", size.ToString());
            save.WriteElementString("BaseSpeed", baseSpeed.ToString());
            save.WriteElementString("AttributePackage", attributePackage.ToString());
            
            save.WriteStartElement("AttributeModifiers");

            for(i = 0; i < 6; i++)
                save.WriteElementString(Globals.AttributeList[Globals.AttributeList["Strength"] + i], attributeModifiers[i].ToString("+0;-0"));

            save.WriteEndElement();

            save.WriteElementString("LanguageQuality", languageQuality.ToString());
            save.WriteElementString("StartingLanguages", string.Join(",", startingLanguages));

            if (availableLanguages != null)
                save.WriteElementString("AvailableLanguages", string.Join(",", availableLanguages));

            save.WriteStartElement("RacialTraits");

            foreach (RaceTraitLink curLink in traits)
            {
                save.WriteStartElement("Trait");

                save.WriteElementString("Name", curLink.trait.name);

                for (i = 0; i < curLink.count; i++)
                    save.WriteElementString("Rank", curLink.traitData[i]);

                save.WriteEndElement();
            }

            save.WriteEndElement();

            save.WriteEndElement();
        }

        public static Race ParseRaceNode(XmlNode raceNode)
        {
            string nowLoading = null;
            Race result = new Race();

            try
            {
                int i, q;

                nowLoading = "Name";
                result.name = Utils.GetXMLNodeValue(raceNode, nowLoading);
                nowLoading = "NamePlural";
                result.namePlural = Utils.GetXMLNodeValue(raceNode, nowLoading);
                nowLoading = "NameAdjective";
                result.nameAdjective = Utils.GetXMLNodeValue(raceNode, nowLoading);
                nowLoading = "Paizo";
                result.paizo = Boolean.Parse(Utils.GetXMLNodeValue(raceNode, nowLoading, "False"));
                nowLoading = "Custom";
                result.custom = (raceNode.SelectSingleNode(nowLoading) != null);
                nowLoading = "@Points";
                result.racePointsStatic = int.Parse(Utils.GetXMLNodeValue(raceNode, nowLoading));
                nowLoading = "FlavorText";
                result.flavorText = Utils.GetXMLNodeValue(raceNode, nowLoading);
                nowLoading = "AppearanceDescription";
                result.appearanceDescription = Utils.GetXMLNodeValue(raceNode, nowLoading);
                nowLoading = "Type";
                result.type = Globals.raceTypeDB[Utils.GetXMLNodeValue(raceNode, nowLoading)];
                nowLoading = "Subtype";
                result.subtype = Utils.GetXMLNodeValue(raceNode, nowLoading);
                nowLoading = "Size";
                result.size = Utils.ToEnum<Globals.Size>(Utils.GetXMLNodeValue(raceNode, nowLoading));
                nowLoading = "BaseSpeed";
                result.baseSpeed = int.Parse(Utils.GetXMLNodeValue(raceNode, nowLoading));

                if ((result.baseSpeed != 20) && (result.baseSpeed != 30))
                    throw new Exception("Base speed must be either 20 or 30.");

                nowLoading = "AttributePackage";
                result.attributePackage = Utils.ToEnum<Race.AttributePackages>(Utils.GetXMLNodeValue(raceNode, nowLoading));

                for (i = 0; i < 6; i++)
                {
                    try
                    {
                        result.attributeModifiers[i] = int.Parse(Utils.GetXMLNodeValue(raceNode, "AttributeModifiers/*[" + (i + 1) + "]", "0"));
                    }
                    catch (Exception e)
                    {
                        nowLoading = "AttributeModifiers/" + Globals.AttributeList[Globals.AttributeList["Strength"] + i];
                        throw e;
                    }
                }

                nowLoading = "LanguageQuality";
                result.languageQuality = Utils.ToEnum<Race.LanguageQualityOptions>(Utils.GetXMLNodeValue(raceNode, nowLoading));
                nowLoading = "StartingLanguages";
                result.startingLanguages = Utils.GetXMLNodeValue(raceNode, nowLoading).Split(new char[] { ',' });

                nowLoading = "AvailableLanguages";
                if (raceNode.SelectSingleNode(nowLoading) != null)
                    result.availableLanguages = Utils.GetXMLNodeValue(raceNode, nowLoading).Split(new char[] { ',' });

                q = 0;

                foreach (XmlNode traitNode in raceNode.SelectNodes("RacialTraits/Trait"))
                {
                    RaceTraitLink newLink;

                    q++;
                    nowLoading = Utils.GetXMLNodeValue(traitNode, "Name");

                    if (nowLoading != string.Empty)
                        nowLoading = "Trait #" + q + " - \"" + nowLoading + '"';
                    else
                        nowLoading = "Trait #" + q;

                    try
                    {
                        newLink = new RaceTraitLink(Globals.raceTraitDB[Utils.GetXMLNodeValue(traitNode, "Name")]);
                    }
                    catch (KeyNotFoundException)
                    {
                        Globals.DispatchMessage("Race using invalid trait!", "The \"" + result.name + "\" race is using an invalid racial trait: " + nowLoading + System.Environment.NewLine + System.Environment.NewLine + "This trait will be removed from the race.");
                        continue;
                    }

                    nowLoading = newLink.trait.name + ": Rank Information";
                    newLink.count = traitNode.SelectNodes("Rank").Count;

                    for (i = 0; i < newLink.count; i++)
                        newLink.traitData[i] = Utils.GetXMLNodeValue(traitNode, "Rank[" + (i + 1) + "]");

                    result.traits.Add(newLink);
                }

                if (result.custom)
                {
                    nowLoading = "Custom BonusList";
                    result.bonuses = new List<Bonus>();

                    foreach (XmlNode bonusNode in raceNode.SelectNodes("BonusList/Bonus"))
                        result.bonuses.Add(Bonus.ParseBonusNode(bonusNode));
                }

                return result;
            }
            catch (Exception e)
            {
                if ((nowLoading == null) || (nowLoading == "Name"))
                    Globals.DispatchMessage("An error occurred loading a race!", "An error occurred loading this race node:" + System.Environment.NewLine + e.Message + System.Environment.NewLine + System.Environment.NewLine + raceNode.OuterXml);
                else
                    Globals.DispatchMessage("An error occurred loading the \"" + result.name + "\" race!", "An error occurred loading the \"" + result.name + "\" race - unable to load " + nowLoading + " information:" + System.Environment.NewLine + System.Environment.NewLine + e.Message + System.Environment.NewLine + System.Environment.NewLine + "This race will not appear in the program and will be lost if you save any changes!");

                return null;
            }
        }

        /// <summary>
        /// Subroutine for BuildRaceEntry.  Collects a count of each selection.
        /// </summary>
        /// <param name="summary">The collection to fill.</param>
        /// <param name="ranks">How many selections to check.</param>
        /// <param name="selections">The array of selections to look through.</param>
        private void TabulateSelections(SortedList<string, int> summary, int ranks, string[] selections)
        {
            for (int i = 0; i < ranks; i++)
            {
                if (summary.ContainsKey(selections[i]))
                    summary[selections[i]]++;
                else
                    summary.Add(selections[i], 1);
            }
        }

        /// <summary>
        /// Subroutine for BuildRaceEntry.  Ensures proper display even if the racial adjective hasn't been filled in.
        /// </summary>
        /// <param name="language">The language to check.</param>
        /// <returns>A string to use for that language.</returns>
        private string RaceEntryGetLanguage(string language)
        {
            if (language == "Racial")
            {
                if (string.IsNullOrEmpty(nameAdjective))
                    return "their racial language";
                else
                    return nameAdjective;
            }
            else
                return language;
        }

        /// <summary>
        /// Subroutine for BuildRaceEntry that adds the given entry into a list.
        /// </summary>
        /// <param name="parent">The unordered list that will contain the new entry.</param>
        /// <param name="entry">The InnerHtml of the entry.</param>
        private void AddRaceEntry(HtmlElement parent, string entry)
        {
            HtmlElement tmpElement = parent.Document.CreateElement("li");
            tmpElement.InnerHtml = entry;

            parent.GetElementsByTagName("ul")[0].AppendChild(tmpElement);
        }

        /// <summary>
        /// Monster function that generates the rules entry to be shown on the Race Entry tab.
        /// I had considered breaking it up, but didn't think I could keep it efficient without unwieldy parameter lists.
        /// </summary>
        /// <param name="display">The Webbrowser control that will be showing the entry.</param>
        /// <param name="rulesOnly">Indicates whether we want the display to be just the rules (no flavor text).  Defaults to false.</param>
        public void BuildRaceEntry(HtmlDocument displayDoc, bool rulesOnly = false)
        {
            int i, j, bonus, penalty;
            int[] modifiers = new int[6];
            int nonZeroModifiers = 0;
            StringBuilder entryText = new StringBuilder();
            string tmpStr;
            RaceTraitLink tmpLink;

            string RaceName = Utils.Capitalize(name);
            if (RaceName == string.Empty) RaceName = "Member of this race";
            string racename = name.ToLower();
            if (racename == string.Empty) racename = "member of this race";
            string RacePlural = Utils.Capitalize(namePlural);
            if (RacePlural == string.Empty) RacePlural = "Members of this race";
            string raceplural = namePlural.ToLower();
            if (raceplural == string.Empty) raceplural = "members of this race";
            string RaceAdjective = Utils.Capitalize(nameAdjective);
            if (RaceAdjective == string.Empty) RaceAdjective = "Racial";
            string raceadjective = nameAdjective.ToLower();
            if (raceadjective == string.Empty) raceadjective = "racial";

            for (i = 0; i < 6; i++)
            {
                bonus = 0;
                penalty = 0;

                TryBonus(Globals.AttributeList["Strength"] + i, Globals.ModifierDescriptor.Inherent, ref bonus, ref penalty);

                modifiers[i] = attributeModifiers[i] + bonus - penalty;
            }

            switch (size)
            {
                case Globals.Size.Tiny:
                    modifiers[0] -= 2; // Strength
                    modifiers[1] += 2; // Dexterity
                    break;
                case Globals.Size.Large:
                    modifiers[0] += 2; // Strength
                    modifiers[1] -= 2; // Dexterity
                    break;
            }

            if ((type.name == "Construct") || (type.name == "Undead"))
                modifiers[2] = 0; // Constitution is irrelevent for constructs and undead.

            for (i = 0; i < 6; i++)
            {
                if (modifiers[i] != 0)
                    nonZeroModifiers++;
            }

            if (displayDoc.GetElementById("RaceHeader") == null)
                displayDoc.Write(new StreamReader(Assembly.GetExecutingAssembly().GetManifestResourceStream("PathfinderSystem.DefaultRaceDisplay.html")).ReadToEnd());

            displayDoc.GetElementById("RaceHeader").InnerText = Utils.Capitalize(namePlural, true);
            #region Flavor
            // FlavorText
            if ((!rulesOnly) && (flavorText != string.Empty))
            {
                displayDoc.GetElementById("FlavorText").Style = "display:block;";
                displayDoc.GetElementById("FlavorText").InnerHtml = string.Format(flavorText, "Pathfinder", RaceName, racename, RacePlural, raceplural, RaceAdjective, raceadjective).Replace(System.Environment.NewLine, "<br />");
            }
            else
                displayDoc.GetElementById("FlavorText").Style = "display:none;";

            // Appearance
            if ((!rulesOnly) && (appearanceDescription != string.Empty))
            {
                displayDoc.GetElementById("Appearance").Style = "display:block;";
                displayDoc.GetElementById("Appearance").InnerHtml = "<b>Physical Description:</b> " + string.Format(appearanceDescription, "Pathfinder", RaceName, racename, RacePlural, raceplural, RaceAdjective, raceadjective).Replace(System.Environment.NewLine, "<br />");
            }
            else
                displayDoc.GetElementById("Appearance").Style = "display:none;";
            #endregion
            #region AbilityScoresEntry
            // AbilityScoreRacialTraits
            entryText.Length = 0;

            if (nonZeroModifiers == 0)
            {
                if (attributePackage == Race.AttributePackages.HumanHeritage)
                    entryText.AppendFormat("{0} gain a +2 racial bonus to one ability score of their choice at creation to represent their varied nature.", RacePlural);
                else
                    entryText.AppendFormat("{0} have no ability score bonuses or penalties.", RacePlural);
            }
            else
            {
                int modifiersWritten = 0;

                entryText.Append(RacePlural).Append(" gain ");

                for (i = 0; i < 6; i++)
                {
                    if (modifiers[i] != 0)
                    {
                        tmpStr = string.Format("{0:+0;-0} {1}", modifiers[i], Globals.AttributeList[Globals.AttributeList["Strength"] + i].Substring(0, 3));

                        if (modifiersWritten == 0)
                            entryText.Append(tmpStr);
                        else if (modifiersWritten == (nonZeroModifiers - 1))
                        {
                            if (nonZeroModifiers > 2)
                                entryText.Append(',');

                            entryText.Append(" and ").Append(tmpStr);
                        }
                        else
                            entryText.Append(", ").Append(tmpStr);

                        modifiersWritten++;
                    }

                }

                entryText.Append('.');

                if (attributePackage == Race.AttributePackages.HumanHeritage)
                    entryText.Append(" They also gain a +2 racial bonus to one ability score of their choice at creation to represent their varied nature.");
            }

            switch (type.name)
            {
                case "Construct":
                    switch (size)
                    {
                        case Globals.Size.Tiny:
                        case Globals.Size.Small:
                            i = 10;
                            break;
                        case Globals.Size.Large:
                            i = 30;
                            break;
                        case Globals.Size.Medium:
                        default:
                            i = 20;
                            break;
                    }

                    entryText.Append(" As constructs, they have no Constitution score. Any DCs or other statistics that rely on a Constitution score treat a construct as having a score of 10 (no bonus or penalty). They also gain " + i + " bonus hit points due to their " + size.ToString() + " size.");
                    break;
                case "Undead":
                    entryText.Append(" As undead, they have no Constitution score. Undead use their Charisma score in place of their Constitution score when calculating hit points, Fortitude saves, and any special ability that relies on Constitution (such as when calculating a breath weapon's DC).");
                    break;
            }

            displayDoc.GetElementById("AbilityScoreRacialTraits").InnerText = entryText.ToString();
            #endregion
            #region CreatureTypeEntry
            // CreatureType
            entryText.Length = 0;
            tmpStr = subtype;

            if (!string.IsNullOrEmpty(type.intrinsicSubtypes))
                tmpStr += "," + type.intrinsicSubtypes;

            // Fire/cold subtypes...
            tmpLink = GetLink("Elemental Immunity");

            if (tmpLink != null)
            {
                if (Array.Exists<string>(tmpLink.traitData, curData => curData == "Cold"))
                {
                    tmpLink = GetLink("Elemental Vulnerability");

                    if ((tmpLink != null) && (Array.Exists<string>(tmpLink.traitData, curItem => curItem == "Fire")))
                        tmpStr += ",cold";
                }
                else if (Array.Exists<string>(tmpLink.traitData, curData => curData == "Fire"))
                {
                    tmpLink = GetLink("Elemental Vulnerability");

                    if ((tmpLink != null) && (Array.Exists<string>(tmpLink.traitData, curItem => curItem == "Cold")))
                        tmpStr += ",fire";
                }
            }

            if (tmpStr != string.Empty)
            {
                string[] subtypes = tmpStr.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                entryText.AppendFormat("{0} are {1} with the ", RacePlural, type.entryPlural.ToLower());

                for (i = 0; i < subtypes.Length; i++)
                {
                    if (i == 0)
                        entryText.Append(subtypes[i].ToLower().Trim());
                    else if (i == subtypes.Length - 1)
                    {
                        if (subtypes.Length == 2)
                            entryText.Append(" and ").Append(subtypes[i].ToLower().Trim());
                        else
                            entryText.Append(", and ").Append(subtypes[i].ToLower().Trim());
                    }
                    else
                        entryText.Append(", ").Append(subtypes[i].ToLower().Trim());
                }

                if (subtypes.Length == 1)
                    entryText.Append(" subtype.");
                else
                    entryText.Append(" subtypes.");
            }
            else
                entryText.AppendFormat("{0} are {1}.", RacePlural, type.namePlural);

            switch (type.name)
            {
                case "Construct":
                    entryText.Append("<ul><li>Constructs are immune to all mind-affecting effects (charms, compulsions, morale effects, patterns, and phantasms).</li><li>Constructs cannot heal damage on their own, but can often be repaired via exposure to a certain kind of effect (depending on the construct's racial abilities) or through the use of the Craft Construct feat. Constructs can also be healed through spells such as make whole. A construct with the fast healing special quality still benefits from that quality.</li><li>Constructs are not subject to ability damage, ability drain, fatigue, exhaustion, energy drain, or nonlethal damage.</li><li>Constructs are immune to any effect that requires a Fortitude save (unless the effect also works on objects or is harmless).</li><li>Constructs do not risk death due to massive damage, but they are immediately destroyed when reduced to 0 hit points or fewer.</li><li>Constructs cannot be raised or resurrected.</li><li>Constructs do not breathe, eat, or sleep, unless they want to gain some beneficial effect from one of these activities. This means that a construct can drink potions to benefit from their effects and can sleep in order to regain spells, but neither of these activities is required to survive or stay in good health.</li></ul>");
                    break;
                case "Dragon":
                    entryText.Append(" Dragons are immune to magical <i>sleep</i> effects and paralysis effects.");
                    break;
                case "Half-Construct":
                    entryText.Append("<ul><li>Half-constructs gain a +2 racial bonus on saving throws against disease, mind-affecting effects, poison, and effects that cause either exhaustion or fatigue.</li><li>Half-constructs cannot be raised or resurrected.</li><li>Half-constructs do not breathe, eat, or sleep, unless they want to gain some beneficial effect from one of these activities. This means that a half-construct can drink potions to benefit from their effects and can sleep in order to regain spells, but neither of these activities is required for the half-construct to survive or stay in good health.</li></ul>");
                    break;
                case "Half-Undead":
                    entryText.Append("<ul><li>Half-undead gain a +2 racial bonus on saving throws against disease and mind-affecting effects.</li><li>Half-undead take no penalties from energy-draining effects, though they can still be killed if they accrue more negative levels than they have Hit Dice. After 24 hours, any negative levels they've gained are removed without any additional saving throws.</li><li>Half-undead creatures are harmed by positive energy and healed by negative energy. A half-undead creature with the fast healing special quality still benefits from that quality.</li></ul>");
                    break;
                case "Plant":
                    entryText.Append("<ul><li>Plants are immune to all mind-affecting effects (charms, compulsions, morale effects, patterns, and phantasms).</li><li>Plants are immune to paralysis, poison, <i>polymorph</i>, <i>sleep</i> effects, and stunning.</li><li>Plants breathe and eat, but do not sleep, unless they want to gain some beneficial effect from this activity. This means that a plant creature can sleep in order to regain spells, but sleep is not required to survive or stay in good health.</li></ul>");
                    break;
                case "Undead":
                    entryText.Append("<ul><li>Undead are immune to all mind-affecting effects (charms, compulsions, morale effects, patterns, and phantasms).</li><li>Undead are immune to bleed damage, death effects, disease, paralysis, poison, sleep effects, and stunning.</li><li>Undead are not subject to nonlethal damage, ability drain, or energy drain, and are immune to damage to physical ability scores (Constitution, Dexterity, and Strength), as well as to exhaustion and fatigue effects.</li><li>Undead are harmed by positive energy and healed by negative energy. An undead creature with the fast healing special quality still benefits from that quality.</li><li>Undead are immune to any effect that requires a Fortitude save (unless the effect also works on objects or is harmless).</li><li>Undead do not risk death from massive damage, but are immediately destroyed when reduced to 0 hit points or fewer.</li><li>Undead are not affected by <i>raise dead</i> and <i>reincarnate</i> spells or abilities. <i>Resurrection</i> and <i>true resurrection</i> can affect undead creatures. These spells turn undead creatures back into the living creatures they were before becoming undead.</li><li>Undead do not breathe, eat, or sleep, unless they want to gain some beneficial effect from one of these activities. This means that an undead creature can drink potions to benefit from their effects and can sleep in order to regain spells, but neither of these activities is required to survive or stay in good health.</li></ul>");
                    break;
            }

            displayDoc.GetElementById("CreatureType").InnerHtml = entryText.ToString();
            #endregion
            #region SizeEntry
            // RaceSize
            entryText.Length = 0;

            switch (size)
            {
                case Globals.Size.Tiny:
                    entryText.AppendFormat("{0} are Tiny creatures and thus gain a +2 size bonus to their AC, a +2 size bonus on attack rolls, a -2 penalty to their CMB and CMD, and a +8 size bonus on Stealth checks. Tiny characters take up a space of 2-1/2 feet by 2-1/2 feet, so up to four of these characters can fit into a single square. Tiny races typically have a natural reach of 0 feet, meaning they can't reach into adjacent squares. They must enter an opponent's square to attack it in melee. This provokes an attack of opportunity from the opponent. Since they have no natural reach, they do not threaten the squares around them. Other creatures can move through those squares without provoking attacks of opportunity. Tiny creatures typically cannot flank an enemy.", RacePlural);
                    break;
                case Globals.Size.Small:
                    entryText.AppendFormat("{0} are Small creatures and thus gain a +1 size bonus to their AC, a +1 size bonus on attack rolls, a -1 penalty to their CMB and CMD, and a +4 size bonus on Stealth checks.", RacePlural);
                    break;
                case Globals.Size.Large:
                    entryText.AppendFormat("{0} are Large creatures and thus take a -1 size penalty to their AC, a -1 size penalty on attack rolls, a +1 bonus to their CMB and CMD, and a -4 size penalty on Stealth checks. They take up a space that is 10 feet by 10 feet and have a reach of {1} feet.", RacePlural, (HasTrait("Reach") > 0) ? 10 : 5);
                    break;
                case Globals.Size.Medium:
                default:
                    entryText.AppendFormat("{0} are Medium creatures and thus receive no bonuses or penalties due to their size.", RacePlural);
                    break;
            }

            displayDoc.GetElementById("RaceSize").InnerText = entryText.ToString();
            #endregion
            #region RaceSpeedEntry
            // RaceSpeed
            entryText.Length = 0;
            bonus = penalty = 0;
            TryBonus(Globals.AttributeList["MovementSpeed"], Globals.ModifierDescriptor.Racial, ref bonus, ref penalty);
            TryBonus(Globals.AttributeList["MovementSpeed"], Globals.ModifierDescriptor.Inherent, ref bonus, ref penalty);
            i = baseSpeed + bonus + penalty;

            if ((i == 20) && (size > Globals.Size.Small))
                entryText.AppendFormat("{0} have a base speed of {1} feet, but their speed is never modified by armor or encumbrance.", RacePlural, i);
            else
                entryText.AppendFormat("{0} have a base speed of {1} feet.", RacePlural, i);

            bonus = penalty = 0;
            TryBonus(Globals.AttributeList["ClimbSpeed"], Globals.ModifierDescriptor.Racial, ref bonus, ref penalty);
            TryBonus(Globals.AttributeList["ClimbSpeed"], Globals.ModifierDescriptor.Inherent, ref bonus, ref penalty);

            if (bonus > 0)
                entryText.AppendFormat("They also have a climb speed of {0} feet, which also grants them a +8 racial bonus on Climb checks.", i);

            bonus = penalty = 0;
            TryBonus(Globals.AttributeList["SwimSpeed"], Globals.ModifierDescriptor.Racial, ref bonus, ref penalty);
            TryBonus(Globals.AttributeList["SwimSpeed"], Globals.ModifierDescriptor.Inherent, ref bonus, ref penalty);

            if (bonus > 0)
                entryText.AppendFormat("They also have a swim speed of {0} feet, which also grants them a +8 racial bonus on Swim checks.", bonus);

            bonus = penalty = 0;
            TryBonus(Globals.AttributeList["FlySpeed"], Globals.ModifierDescriptor.Racial, ref bonus, ref penalty);
            TryBonus(Globals.AttributeList["FlySpeed"], Globals.ModifierDescriptor.Inherent, ref bonus, ref penalty);

            if (bonus > 0)
            {
                i = bonus;
                bonus = penalty = 0;
                TryBonus(Globals.AttributeList["FlyManeuverability"], Globals.ModifierDescriptor.Racial, ref bonus, ref penalty);
                TryBonus(Globals.AttributeList["FlyManeuverability"], Globals.ModifierDescriptor.Inherent, ref bonus, ref penalty);

                entryText.AppendFormat("They also have a fly speed of {0} feet with {1} maneuverability.", i, Globals.GetFlightManeuverability(bonus + penalty).ToLower());
            }

            bonus = penalty = 0;
            TryBonus(Globals.AttributeList["BurrowSpeed"], Globals.ModifierDescriptor.Racial, ref bonus, ref penalty);
            TryBonus(Globals.AttributeList["BurrowSpeed"], Globals.ModifierDescriptor.Inherent, ref bonus, ref penalty);

            if (bonus > 0)
                entryText.AppendFormat("They also have a burrow speed of {0} feet.", bonus);

            displayDoc.GetElementById("RaceSpeed").InnerText = entryText.ToString();
            #endregion
            #region RaceLanguagesEntry
            // Languages
            entryText.Length = 0;
            entryText.AppendFormat("{0} begin play speaking {1}", RacePlural, RaceEntryGetLanguage(startingLanguages[0]));

            switch (startingLanguages.Length)
            {
                case 2:
                    entryText.AppendFormat(" and {0}.", RaceEntryGetLanguage(startingLanguages[1]));
                    break;
                case 3:
                    entryText.AppendFormat(", {0}, and {1}.", RaceEntryGetLanguage(startingLanguages[1]), RaceEntryGetLanguage(startingLanguages[2]));
                    break;
                default:
                    entryText.Append('.');
                    break;
            }

            if (languageQuality == Race.LanguageQualityOptions.Linguist)
                entryText.AppendFormat(" {0} with high Intelligence scores can choose any languages they want (except secret languages, such as Druidic).", RacePlural);
            else if (availableLanguages != null)
            {
                entryText.AppendFormat(" {0} with high intelligence scores can choose from the following: ", RacePlural);

                for (i = 0; i < availableLanguages.Length; i++)
                {
                    tmpStr = RaceEntryGetLanguage(availableLanguages[i]);

                    if (i == 0)
                        entryText.Append(tmpStr);
                    else if (i == (availableLanguages.Length - 1))
                    {
                        if (availableLanguages.Length > 2)
                            entryText.Append(',');

                        entryText.Append(" or ").Append(tmpStr);
                    }
                    else
                        entryText.Append(", ").Append(tmpStr);
                }
            }

            displayDoc.GetElementById("Languages").InnerText = entryText.ToString();
            #endregion
            #region RaceTraitsEntry
            List<RaceTraitLink> masterLinkDB = new List<RaceTraitLink>();

            foreach (RacialTrait curTrait in type.intrinsicTraits)
                masterLinkDB.Add(new RaceTraitLink(curTrait));

            foreach (RaceTraitLink curLink in traits)
                masterLinkDB.Add(curLink);

            // Trait Categories
            foreach (HtmlElement curElement in displayDoc.GetElementsByTagName("div"))
            {
                if (Enum.IsDefined(typeof(RacialTrait.TraitType), curElement.Id))
                {
                    int count = 0;
                    curElement.GetElementsByTagName("ul")[0].InnerHtml = string.Empty;
                    List<RaceTraitLink> links = masterLinkDB.FindAll(curLink => curLink.trait.type.ToString() == curElement.Id);

                    #region CustomizedTraitEntries
                    // Special handling for items that may be stacked - natural armor, energy resistance, etc.                 
                    if (curElement.Id == "Defense")
                    {
                        if ((HasTrait("Damage Reduction") > 0) || (HasTrait("Improved Damage Reduction") > 0))
                        {
                            bonus = penalty = 0;
                            TryBonus(Globals.AttributeList["DamageReductionMagic"], Globals.ModifierDescriptor.Racial, ref bonus, ref penalty);

                            if (bonus > 0)
                            {
                                AddRaceEntry(curElement, string.Format("<b>Damage Reduction:</b> {0} have DR{1}/magic.", RacePlural, bonus));
                                count++;
                            }
                        }

                        nonZeroModifiers = 0; // Used to count any resistances we've found.

                        for (i = 0; i < 4; i++)
                        {
                            bonus = penalty = 0;
                            TryBonus(Globals.AttributeList["Resist" + Enum.GetNames(typeof(Globals.EnergyTypes))[i]], Globals.ModifierDescriptor.Racial, ref bonus, ref penalty);
                            modifiers[i] = bonus; // Modifiers array reused to hold resistance values.

                            if (bonus > 0)
                                nonZeroModifiers++;
                        }

                        if (nonZeroModifiers > 0)
                        {
                            tmpStr = "Energy Resistance";

                            foreach (RaceTraitLink curLink in traits)
                            {
                                bonus = penalty = 0;
                                for (i = 0; i < 4; i++)
                                    curLink.trait.TryBonus(curLink.count, curLink.traitData, Globals.AttributeList["Resist" + Enum.GetNames(typeof(Globals.EnergyTypes))[i]], Globals.ModifierDescriptor.Racial, ref bonus, ref penalty);

                                if ((bonus > 0) && (!"Energy ResistanceImproved Resistance".Contains(curLink.trait.name)))
                                {
                                    tmpStr = curLink.trait.name;
                                    break;
                                }
                            }

                            entryText.Length = 0;
                            entryText.AppendFormat("<b>{0}:</b> {1} have ", tmpStr, RacePlural);
                            bonus = 0; // Bonus used as a holder for how many we've printed.

                            for (i = 0; i < 4; i++)
                            {
                                if (modifiers[i] > 0)
                                {
                                    tmpStr = string.Format("{0} resistance {1}", Enum.GetNames(typeof(Globals.EnergyTypes))[i].ToLower(), modifiers[i]);

                                    if (bonus == 0)
                                        entryText.Append(tmpStr);
                                    else if (bonus == (nonZeroModifiers - 1))
                                    {
                                        if (bonus > 2)
                                            entryText.Append(',');

                                        entryText.Append(" and ").Append(tmpStr);
                                    }
                                    else
                                        entryText.Append(", ").Append(tmpStr);

                                    bonus++;
                                }
                            }

                            entryText.Append('.');

                            AddRaceEntry(curElement, entryText.ToString());
                            count++;
                        }

                        if (HasTrait("Elemental Immunity") > 0)
                        {
                            entryText.Length = 0;
                            int ranks = HasTrait("Elemental Immunity");
                            entryText.AppendFormat("<b>Elemental Immunity:</b> {0} are immune to ", RacePlural);

                            for (i = 0; i < ranks; i++)
                            {
                                tmpStr = GetLink("Elemental Immunity").traitData[i].ToLower();

                                if (i == 0)
                                    entryText.Append(tmpStr);
                                else if (i == ranks - 1)
                                {
                                    if (ranks == 2)
                                        entryText.Append(" and ").Append(tmpStr);
                                    else
                                        entryText.Append(", and ").Append(tmpStr);
                                }
                                else
                                    entryText.Append(", ").Append(tmpStr);
                            }

                            entryText.Append('.');

                            AddRaceEntry(curElement, entryText.ToString());
                            count++;
                        }

                        if (HasTrait("Natural Armor") > 0)
                        {
                            bonus = penalty = 0;
                            TryBonus(Globals.AttributeList["NaturalArmor"], Globals.ModifierDescriptor.Inherent, ref bonus, ref penalty);

                            if (bonus > 0)
                            {
                                AddRaceEntry(curElement, string.Format("<b>Natural Armor:</b> {0} have a +{1} natural armor bonus to their Armor Class.", RacePlural, bonus));
                                count++;
                            }
                        }
                    }
                    else if (curElement.Id == "Magical")
                    {
                        SortedList<string, int> mySpells = new SortedList<string, int>();

                        tmpLink = GetLink("Spell-Like Ability, Lesser");

                        if (tmpLink != null)
                            TabulateSelections(mySpells, tmpLink.count, tmpLink.traitData);

                        tmpLink = GetLink("Spell-Like Ability, Greater");

                        if (tmpLink != null)
                            TabulateSelections(mySpells, tmpLink.count, tmpLink.traitData);

                        tmpLink = GetLink("Spell-Like Ability, At-Will");

                        if (tmpLink != null)
                        {
                            for (i = 0; i < tmpLink.count; i++)
                            {
                                if (mySpells.ContainsKey(tmpLink.traitData[i]))
                                    mySpells[tmpLink.traitData[i]] = 99;
                                else
                                    mySpells.Add(tmpLink.traitData[i], 99);
                            }
                        }

                        switch (mySpells.Count)
                        {
                            case 0:
                                break;
                            case 1:
                                switch (mySpells.Values[0])
                                {
                                    case 1:
                                        tmpStr = "once per day";
                                        break;
                                    case 99:
                                        tmpStr = "at-will";
                                        break;
                                    default:
                                        tmpStr = mySpells.Values[0] + " times per day";
                                        break;
                                }

                                AddRaceEntry(curElement, string.Format("<b>Spell-like ability:</b> {0} can cast <i>{2}</i> {3} as a spell-like ability. The caster level for this ability equals the {1}'s class level.", RacePlural, racename, Globals.spellDB[mySpells.Keys[0]].displayName, tmpStr));
                                count++;
                                break;
                            default:
                                entryText.Length = 0;
                                entryText.AppendFormat("<b>Spell-like abilities:</b> {0} have the following spell-like abilities:", RacePlural);

                                // tmpLink will still be pointing to the at-will trait, so we can use it as a shortcut.
                                if ((tmpLink != null) && (tmpLink.count > 0))
                                {
                                    bonus = 0;

                                    entryText.Append("<p>At-will — ");

                                    for (i = 0; i < mySpells.Count; i++)
                                    {
                                        if (mySpells.Values[i] == 99)
                                        {
                                            tmpStr = "<i>" + Globals.spellDB[mySpells.Keys[i]].displayName + "</i>";

                                            if (bonus == 0)
                                                entryText.Append(tmpStr);
                                            else
                                                entryText.Append(", ").Append(tmpStr);

                                            bonus++;
                                        }
                                    }

                                    entryText.Append("</p>");
                                }

                                // Create entries for spell-likes that can be case 1 to 3 times per day.
                                for (j = 1; j <= 3; j++)
                                {
                                    // Count how many spell-likes are cast this many times per day.
                                    bonus = 0;

                                    for (i = 0; i < mySpells.Count; i++)
                                    {
                                        if (mySpells.Values[i] == j)
                                            bonus++;
                                    }

                                    if (bonus > 0)
                                    {
                                        bonus = 0;
                                        entryText.AppendFormat("<p>{0}/day — ", j);

                                        for (i = 0; i < mySpells.Count; i++)
                                        {
                                            if (mySpells.Values[i] == j)
                                            {
                                                tmpStr = "<i>" + Globals.spellDB[mySpells.Keys[i]].displayName + "</i>";

                                                if (bonus == 0)
                                                    entryText.Append(tmpStr);
                                                else
                                                    entryText.Append(", ").Append(tmpStr);

                                                bonus++;
                                            }
                                        }

                                        entryText.Append("</p>");
                                    }
                                }

                                entryText.AppendFormat("The caster level for this ability equals the {0}'s class level.", racename);
                                AddRaceEntry(curElement, entryText.ToString());
                                count++;
                                break;
                        }

                    }
                    else if (curElement.Id == "Senses")
                    {
                        if ((type.intrinsicTraits.Exists(aTrait => aTrait.name.StartsWith("Darkvision"))) || (HasTrait("Darkvision 60 ft.") > 0) || (HasTrait("Darkvision 120 ft.") > 0))
                        {
                            bonus = penalty = 0;
                            TryBonus(Globals.AttributeList["Darkvision"], Globals.ModifierDescriptor.Racial, ref bonus, ref penalty);

                            if (bonus > 0)
                            {
                                AddRaceEntry(curElement, string.Format("<b>Darkvision:</b> {0} can see in the dark up to {1} feet.", RacePlural, bonus));
                                count++;
                            }
                        }
                    }
                    else if (curElement.Id == "Weakness")
                    {
                        if (HasTrait("Elemental Vulnerability") > 0)
                        {
                            entryText.Length = 0;
                            int ranks = HasTrait("Elemental Vulnerability");
                            entryText.AppendFormat("<b>Elemental Vulnerability:</b> {0} have vulnerability to ", RaceName);

                            for (i = 0; i < ranks; i++)
                            {
                                tmpStr = GetLink("Elemental Vulnerability").traitData[i].ToLower();

                                if (i == 0)
                                    entryText.Append(tmpStr);
                                else if (i == ranks - 1)
                                {
                                    if (ranks == 2)
                                        entryText.Append(" and ").Append(tmpStr);
                                    else
                                        entryText.Append(", and ").Append(tmpStr);
                                }
                                else
                                    entryText.Append(", ").Append(tmpStr);
                            }

                            entryText.Append('.');

                            AddRaceEntry(curElement, entryText.ToString());
                            count++;
                        }
                    }
                    #endregion

                    foreach (RaceTraitLink curLink in links)
                    {
                        tmpStr = curLink.trait.GetEntry(curLink.count, curLink.traitData);

                        if (tmpStr != null)
                        {
                            AddRaceEntry(curElement, string.Format(tmpStr, RacePlural, racename, raceplural));
                            count++;
                        }
                    }

                    if (count > 0)
                        curElement.Style = "display: block;";
                    else
                        curElement.Style = "display: none;";
                }
            }
            #endregion
        }
    }

    public sealed class RaceDatabase : SortedList<string, Race>
    {
        public string path;

        public void LoadFromFile(string filePath)
        {
            path = filePath;

            Clear();

            XmlDocument raceDoc = new XmlDocument();
            raceDoc.Load(System.Environment.CurrentDirectory + "\\Data\\" + filePath);
            LoadFromXml(raceDoc);

            if (File.Exists(System.Environment.CurrentDirectory + "\\Data\\Custom" + filePath))
            {
                try
                {
                    raceDoc = new XmlDocument();
                    raceDoc.Load(System.Environment.CurrentDirectory + "\\Data\\Custom" + filePath);
                    LoadFromXml(raceDoc);
                }
                catch (Exception e)
                {
                    Globals.DispatchMessage("Error loading Custom" + filePath + "!", "Error loading Custom" + filePath + "!" + System.Environment.NewLine + System.Environment.NewLine + e.Message);
                }
            }
        }

        private void LoadFromXml(XmlDocument loadMe)
        {
            foreach (XmlNode curRace in loadMe.SelectNodes("/RaceDatabase/Race"))
                Add(Race.ParseRaceNode(curRace));
        }

        public void Add(Race addMe)
        {
            if (addMe != null)
                Add(addMe.name, addMe);
        }
    }

    public sealed class RaceTraitLink
    {
        public RacialTrait trait;
        public int count;
        public string[] traitData;

        public int racePoints
        {
            get
            {
                return trait.GetCost(count, traitData);
            }
        }

        public RaceTraitLink(RacialTrait useMe)
        {
            trait = useMe;
            count = 1;
            traitData = new string[useMe.repeatLimit];

            for (int i = 0; i < traitData.Length; i++)
                traitData[i] = string.Empty;
        }

        public bool ValidateLink()
        {
            return trait.Validate(count, traitData);
        }
    }
}
