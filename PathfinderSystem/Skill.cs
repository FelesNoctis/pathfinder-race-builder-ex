using System;
using System.Collections.Generic;
using System.Text;

namespace PathfinderSystem
{
    public sealed class Skill
    {
        private string displayNameInternal;
        public string displayName
        {
            get { return displayNameInternal; }
        }
        private SkillKey keyInternal;
        public SkillKey key
        {
            get { return keyInternal; }
        }
        private int attributeKeyInternal;
        public int attributeKey
        {
            get { return attributeKeyInternal; }
        }
        private int governingAttributeInternal;
        public int governingAttribute
        {
            get { return governingAttributeInternal; }
        }
        private bool trainedOnlyInternal;
        public bool trainedOnly
        {
            get { return trainedOnlyInternal; }
        }
        private bool armorCheckInternal;
        public bool armorCheck
        {
            get { return armorCheck; }
        }

        public enum SkillKey
        {
            None = 0,
            Acrobatics = 1,
            Appraise,
            Bluff,
            Climb,
            // Bit of a dilemma here - How to differentiate between bonuses that apply to all Craft checks
            // versus the ones the character cares about without making an entry for every crafting discipline?
            Craft,
            CraftPrimary,
            CraftAncillary,
            Diplomacy,
            DisableDevice,
            Disguise,
            EscapeArtist,
            Fly,
            HandleAnimal,
            Heal,
            Intimidate,
            KnowledgeArcana,
            KnowledgeDungeoneering,
            KnowledgeEngineering,
            KnowledgeGeography,
            KnowledgeHistory,
            KnowledgeLocal,
            KnowledgeNature,
            KnowledgeNobility,
            KnowledgePlanes,
            KnowledgeReligion,
            Linguistics,
            Perception,
            Perform,
            Profession,
            Ride,
            SenseMotive,
            SleightOfHand,
            Spellcraft,
            Stealth,
            Survival,
            Swim,
            UseMagicDevice,
        }

        public enum CraftDiscipline
        {
            Alchemy,
            Armor,
            Baskets,
            Books,
            Bows,
            Calligraphy,
            Carpentry,
            Cloth,
            Clothing,
            Glass,
            Jewelry,
            Leather,
            Locks,
            Paintings,
            Pottery,
            Sculptures,
            Ships,
            Shoes,
            Stonemasonry,
            Traps,
            Weapons,
        }

        public enum PerformanceType
        {
            Act,
            Comedy,
            Dance,
            KeyboardInstruments,
            Oratory,
            PercussionInstruments,
            StringInstruments,
            WindInstruments,
            Sing,
        }

        public Skill(string name, SkillKey keyID, string attributeString, bool trained, bool checkPenalty)
        {
            displayNameInternal = name;
            keyInternal = keyID;
            attributeKeyInternal = Globals.AttributeList[keyID.ToString()];
            governingAttributeInternal = Globals.AttributeList[attributeString];
            trainedOnlyInternal = trained;
            armorCheckInternal = checkPenalty;
        }

        public static string CreateKey(SkillKey input)
        {
            return "Skill" + input.ToString();
        }
    }

    public sealed class SkillDatabase : List<Skill>
    {
        public SkillDatabase()
        {
            Add(new Skill("Acrobatics", Skill.SkillKey.Acrobatics, "Dexterity", false, true));
            Add(new Skill("Appraise", Skill.SkillKey.Appraise, "Intelligence", false, false));
            Add(new Skill("Bluff", Skill.SkillKey.Bluff, "Charisma", false, false));
            Add(new Skill("Climb", Skill.SkillKey.Climb, "Strength", false, true));
            Add(new Skill("Craft", Skill.SkillKey.Craft, "Intelligence", false, false));
            Add(new Skill("Craft (Primary)", Skill.SkillKey.CraftPrimary, "Intelligence", false, false));
            Add(new Skill("Craft (Ancillary)", Skill.SkillKey.CraftAncillary, "Intelligence", false, false));
            Add(new Skill("Diplomacy", Skill.SkillKey.Diplomacy, "Charisma", false, false));
            Add(new Skill("Disable Device", Skill.SkillKey.DisableDevice, "Dexterity", true, true));
            Add(new Skill("Disguise", Skill.SkillKey.Disguise, "Charisma", false, false));
            Add(new Skill("Escape Artist", Skill.SkillKey.EscapeArtist, "Dexterity", false, true));
            Add(new Skill("Fly", Skill.SkillKey.Fly, "Dexterity", false, true));
            Add(new Skill("Handle Animal", Skill.SkillKey.HandleAnimal, "Charisma", true, false));
            Add(new Skill("Heal", Skill.SkillKey.Heal, "Wisdom", false, false));
            Add(new Skill("Intimidate", Skill.SkillKey.Intimidate, "Charisma", false, false));
            Add(new Skill("Knowledge (Arcana)", Skill.SkillKey.KnowledgeArcana, "Intelligence", true, false));
            Add(new Skill("Knowledge (Dungeoneering)", Skill.SkillKey.KnowledgeDungeoneering, "Intelligence", true, false));
            Add(new Skill("Knowledge (Engineering)", Skill.SkillKey.KnowledgeEngineering, "Intelligence", true, false));
            Add(new Skill("Knowledge (Geography)", Skill.SkillKey.KnowledgeGeography, "Intelligence", true, false));
            Add(new Skill("Knowledge (History)", Skill.SkillKey.KnowledgeHistory, "Intelligence", true, false));
            Add(new Skill("Knowledge (Local)", Skill.SkillKey.KnowledgeLocal, "Intelligence", true, false));
            Add(new Skill("Knowledge (Nature)", Skill.SkillKey.KnowledgeNature, "Intelligence", true, false));
            Add(new Skill("Knowledge (Nobility)", Skill.SkillKey.KnowledgeNobility, "Intelligence", true, false));
            Add(new Skill("Knowledge (Planes)", Skill.SkillKey.KnowledgePlanes, "Intelligence", true, false));
            Add(new Skill("Knowledge (Religion)", Skill.SkillKey.KnowledgeReligion, "Intelligence", true, false));
            Add(new Skill("Linguistics", Skill.SkillKey.Linguistics, "Intelligence", true, false));
            Add(new Skill("Perception", Skill.SkillKey.Perception, "Wisdom", false, false));
            Add(new Skill("Perform", Skill.SkillKey.Perform, "Charisma", false, false));
            Add(new Skill("Profession", Skill.SkillKey.Profession, "Wisdom", true, false));
            Add(new Skill("Ride", Skill.SkillKey.Ride, "Dexterity", false, true));
            Add(new Skill("Sense Motive", Skill.SkillKey.SenseMotive, "Wisdom", false, false));
            Add(new Skill("Sleight of Hand", Skill.SkillKey.SleightOfHand, "Dexterity", true, true));
            Add(new Skill("Spellcraft", Skill.SkillKey.Spellcraft, "Intelligence", true, false));
            Add(new Skill("Stealth", Skill.SkillKey.Stealth, "Dexterity", false, true));
            Add(new Skill("Survival", Skill.SkillKey.Survival, "Wisdom", false, false));
            Add(new Skill("Swim", Skill.SkillKey.Swim, "Strength", false, true));
            Add(new Skill("Use Magic Device", Skill.SkillKey.UseMagicDevice, "Charisma", true, false));
        }

        public Skill this[string key]
        {
            get
            {
                int searchKey = Globals.AttributeList[key];

                return Find(curSkill => curSkill.attributeKey == searchKey);
            }
        }

        public Skill this[Skill.SkillKey key]
        {
            get
            {
                return Find(curSkill => curSkill.key == key);
            }
        }
    }
}
