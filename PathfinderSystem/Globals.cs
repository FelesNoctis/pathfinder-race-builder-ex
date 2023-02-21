using System;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Xml;

namespace PathfinderSystem
{
    public static class Globals
    {
        public static KeyRegistry AttributeList;
        public static RaceTraitDatabase raceTraitDB = new RaceTraitDatabase();
        public static RaceDatabase raceDB = new RaceDatabase();
        public static CreatureTypeDatabase raceTypeDB; // Must be instantiated after we read racial traits!
        public static SkillDatabase skillDB;
        public static FeatDatabase featDB;
        public static EquipmentDatabase equipmentDB = new EquipmentDatabase();
        public static SpellDatabase spellDB = new SpellDatabase();
        public static ClassDatabase classDB = new ClassDatabase();
        public static ClassFeatureDatabase classFeatureDB = new ClassFeatureDatabase();
        public static Character character;

        public delegate void DisplayMessageCallback(string caption, string message);
        private static DisplayMessageCallback messageCallback = null;

        /// <summary>
        /// An enum to control which portions of the Pathfinder system are loaded into memory at runtime.
        /// Used by Globals.Initialize().
        /// </summary>
        [Flags]
        public enum LoadItems
        {
            Basics = 1, // Races, skills, and feats.
            Spells = 2,
            All = -1,
        }

        public static void Initialize(LoadItems loadMe, DisplayMessageCallback showMessage)
        {
            messageCallback = showMessage;

            AttributeList = new KeyRegistry(StandardAttributes);

            if ((loadMe & (LoadItems.Basics)) != 0)
            {
                skillDB = new SkillDatabase();
                featDB = new FeatDatabase();
            }
            
            if (loadMe == LoadItems.All)
                LoadClassInfo();

            if ((loadMe & (LoadItems.Basics)) != 0)
                LoadDatabases();

            if ((loadMe & (LoadItems.Spells)) != 0)
                spellDB.LoadFromFile("SpellDatabase.xml");

            character = new Character();
        }

        private static void LoadDatabases()
        {
            raceTraitDB.LoadFromFile("RacialTraits.xml");
            raceTypeDB = new CreatureTypeDatabase();
            raceDB.LoadFromFile("Races.xml");
            featDB.LoadFromFile("FeatDatabase.xml");
        }

        private static void LoadClassInfo()
        {
            foreach (Type curType in Assembly.GetExecutingAssembly().GetTypes())
            {
                if ((curType.IsClass) && (curType.BaseType == typeof(LeveledClass)))
                {
                    LeveledClass holder = (LeveledClass)Activator.CreateInstance(curType);
                    holder.PopulateClassFeatureDatabase();
                    holder.CreateArchetypes();
                    classDB.Add(holder);
                }
            }
        }

        public static void DispatchMessage(string caption, string message)
        {
            if (messageCallback != null)
                messageCallback(caption, message);
        }

        public static string GetFlightManeuverability(int level)
        {
            return flyMobility[Math.Min(Math.Max(level, 0), flyMobility.Length - 1)];
        }

        private static readonly string[] StandardAttributes =
        {
            "Null", // Used for text-only bonuses
            "Strength",
            "Dexterity",
            "Constitution",
            "Intelligence",
            "Wisdom",
            "Charisma",
            "AbilityOfChoice",
            "HitPoints",
            "ArmorClass",
            "Initiative",
            "SaveFortitude",
            "SaveReflex",
            "SaveWill",
            "AttackRoll",
            "AttackRollMelee",
            "AttackRollRanged",
            "WeaponDamage",
            "WeaponCriticalRange",
            "WeaponCriticalDamage",
            "WeaponDamageMelee",
            "CombatManeuverBonus",
            "CombatManeuverDefense",
            "MovementSpeed",
            "SwimSpeed",
            "FlySpeed",
            "FlyManeuverability",
            "ClimbSpeed",
            "BurrowSpeed",
            "BonusSkillPointsPerLevel",
            Skill.CreateKey(Skill.SkillKey.Acrobatics),
            Skill.CreateKey(Skill.SkillKey.Appraise),
            Skill.CreateKey(Skill.SkillKey.Bluff),
            Skill.CreateKey(Skill.SkillKey.Climb),
            Skill.CreateKey(Skill.SkillKey.Craft),
            Skill.CreateKey(Skill.SkillKey.CraftPrimary),
            Skill.CreateKey(Skill.SkillKey.CraftAncillary),
            Skill.CreateKey(Skill.SkillKey.Diplomacy),
            Skill.CreateKey(Skill.SkillKey.DisableDevice),
            Skill.CreateKey(Skill.SkillKey.Disguise),
            Skill.CreateKey(Skill.SkillKey.EscapeArtist),
            Skill.CreateKey(Skill.SkillKey.Fly),
            Skill.CreateKey(Skill.SkillKey.HandleAnimal),
            Skill.CreateKey(Skill.SkillKey.Heal),
            Skill.CreateKey(Skill.SkillKey.Intimidate),
            Skill.CreateKey(Skill.SkillKey.KnowledgeArcana),
            Skill.CreateKey(Skill.SkillKey.KnowledgeDungeoneering),
            Skill.CreateKey(Skill.SkillKey.KnowledgeEngineering),
            Skill.CreateKey(Skill.SkillKey.KnowledgeGeography),
            Skill.CreateKey(Skill.SkillKey.KnowledgeHistory),
            Skill.CreateKey(Skill.SkillKey.KnowledgeLocal),
            Skill.CreateKey(Skill.SkillKey.KnowledgeNature),
            Skill.CreateKey(Skill.SkillKey.KnowledgeNobility),
            Skill.CreateKey(Skill.SkillKey.KnowledgePlanes),
            Skill.CreateKey(Skill.SkillKey.KnowledgeReligion),
            Skill.CreateKey(Skill.SkillKey.Linguistics),
            Skill.CreateKey(Skill.SkillKey.Perception),
            Skill.CreateKey(Skill.SkillKey.Perform),
            Skill.CreateKey(Skill.SkillKey.Profession),
            Skill.CreateKey(Skill.SkillKey.Ride),
            Skill.CreateKey(Skill.SkillKey.SenseMotive),
            Skill.CreateKey(Skill.SkillKey.SleightOfHand),
            Skill.CreateKey(Skill.SkillKey.Spellcraft),
            Skill.CreateKey(Skill.SkillKey.Stealth),
            Skill.CreateKey(Skill.SkillKey.Survival),
            Skill.CreateKey(Skill.SkillKey.Swim),
            Skill.CreateKey(Skill.SkillKey.UseMagicDevice),
            "MaxArmorDex",
            "ArmorCheck",
            "ArcaneSpellFailure",
            "SpellPenetration",
            "Concentration",
            "Feat",
            "LowLightVision",
            "Darkvision",
            "NaturalArmor",
            "DamageReduction",
            "DamageReductionBludgeoning",
            "DamageReductionPiercing",
            "DamageReductionSlashing",
            "DamageReductionMagic",
            "DamageReductionColdIron",
            "DamageReductionSilver",
            "FastHealing",
            "ResistAcid",
            "ResistCold",
            "ResistElectricity",
            "ResistFire",
            "ResistNegative",
            "ResistPositive",
        };

        [Flags]
        public enum ModifierDescriptor
        {
            Armor = (1 << 0),
            Circumstance = (1 << 1),
            Competence = (1 << 2),
            Conditional = (1 << 3), // Special type
            Deflection = (1 << 4),
            Dodge = (1 << 5),
            Inherent = (1 << 6), // Also used for untyped.
            Enhancement = (1 << 7),
            Luck = (1 << 8),
            Morale = (1 << 9),
            Natural = (1 << 10),
            Profane = (1 << 11),
            Racial = (1 << 12),
            Sacred = (1 << 13),
            Shield = (1 << 14),
            Size = (1 << 15),
            Synergy = (1 << 16),
        }

        public static readonly ModifierDescriptor[] excludeFromTotal =
        {
            ModifierDescriptor.Circumstance,
            ModifierDescriptor.Conditional,
        };

        public enum Size
        {
            Tiny,
            Small,
            Medium,
            Large,
        }

        public enum Alignment
        {
            LawfulGood = 1,
            NeutralGood = 2,
            ChaoticGood = 4,
            LawfulNeutral = 8,
            Neutral = 16,
            ChaoticNeutral = 32,
            LawfulEvil = 64,
            NeutralEvil = 128,
            ChaoticEvil = 256,
        }

        private static readonly string[] flyMobility =
        {
            "Clumsy",
            "Poor",
            "Average",
            "Good",
            "Perfect",
        };

        public enum EnergyTypes
        {
            Acid,
            Cold,
            Electricity,
            Fire,
        }
    }

    public sealed class Bonus
    {
        public int attributeKey;
        public Globals.ModifierDescriptor type;
        public int internalValue;
        public string valueSpecial;
        public int statKey;
        public string specialCategory;
        public string statText;

        public Bonus(string attribute, string typeString, string valueString, string statHeading = "", string specialText = "")
        {
            attributeKey = Globals.AttributeList[attribute];

            type = Utils.ToEnum<Globals.ModifierDescriptor>(typeString, Globals.ModifierDescriptor.Inherent);

            if (valueString.StartsWith("Special:", true, System.Globalization.CultureInfo.CurrentCulture))
            {
                internalValue = 0;
                valueSpecial = valueString.Substring(8);
            }
            else
            {
                if (!int.TryParse(valueString, out internalValue))
                    internalValue = 0;

                valueSpecial = string.Empty;
            }

            statKey = -1; // TODO!!!

            specialCategory = statHeading;
            statText = specialText;
        }

        public int value
        {
            get
            {
                if (valueSpecial != string.Empty)
                {
                    switch (valueSpecial)
                    {
                        case "StrengthBonus":
                        case "DexterityBonus":
                        case "ConstitutionBonus":
                        case "IntelligenceBonus":
                        case "WisdomBonus":
                        case "CharismaBonus":
                            return Globals.character.GetAllBonuses(Globals.AttributeList[valueSpecial.Substring(0, valueSpecial.Length - 5)], Globals.character.currentLevel) / 2 - 5;
                        default:
                            return 0;
                    }
                }
                else
                    return internalValue;
            }
        }

        public static Bonus ParseBonusNode(XmlNode bonusNode)
        {
            return new Bonus(Utils.GetXMLNodeValue(bonusNode, "Key"), Utils.GetXMLNodeValue(bonusNode, "Type"), Utils.GetXMLNodeValue(bonusNode, "Value", "0"), Utils.GetXMLNodeValue(bonusNode, "Category"), Utils.GetXMLNodeValue(bonusNode, "Text"));
        }

        public bool TryBonus(string attribute, Globals.ModifierDescriptor modifier, ref int bonus, ref int penalty)
        {
            return TryBonus(Globals.AttributeList[attribute], modifier, ref bonus, ref penalty);
        }

        public bool TryBonus(int key, Globals.ModifierDescriptor modifier, ref int bonus, ref int penalty)
        {
            if ((key == attributeKey) && (modifier == type))
            {
                Bonus.ModifierLogic(modifier, value, ref bonus, ref penalty);
                return true;
            }

            return false;
        }

        public static void ModifierLogic(Globals.ModifierDescriptor modifier, int value, ref int bonus, ref int penalty)
        {
            switch (modifier)
            {
                // Dodge, and inherent bonuses stack.
                case Globals.ModifierDescriptor.Dodge:
                case Globals.ModifierDescriptor.Inherent:
                    if (value >= 0)
                        bonus += value;
                    else
                        penalty += value;
                    break;
                default:
                    if (value > bonus)
                        bonus = value;
                    else if (value < penalty)
                        penalty = value;
                    break;
            }
        }
    }
}
