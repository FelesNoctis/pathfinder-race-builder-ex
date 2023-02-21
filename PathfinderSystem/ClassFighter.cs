using System;
using System.Collections.Generic;
using System.Text;

namespace PathfinderSystem
{
    public class ClassFighter : LeveledClass
    {
        protected const string bonusFeatName = "Bonus Feats";
        protected const string braveryName = "Bravery";
        protected const string armorTrainingName = "Armor Training";
        protected const string weaponTrainingName = "Weapon Training";
        protected const string armorMasteryName = "Armor Mastery";
        protected const string weaponMasteryName = "Weapon Mastery";

        public static readonly Skill.SkillKey[] standardSkills =
        {
            Skill.SkillKey.Climb,
            Skill.SkillKey.CraftAncillary,
            Skill.SkillKey.CraftPrimary,
            Skill.SkillKey.HandleAnimal,
            Skill.SkillKey.Intimidate,
            Skill.SkillKey.KnowledgeDungeoneering,
            Skill.SkillKey.KnowledgeEngineering,
            Skill.SkillKey.Profession,
            Skill.SkillKey.Ride,
            Skill.SkillKey.Survival,
            Skill.SkillKey.Swim,
        };

        public static readonly Armor.ArmorType standardArmorProficiency = Armor.ArmorType.Light | Armor.ArmorType.Medium | Armor.ArmorType.Heavy | Armor.ArmorType.Shield | Armor.ArmorType.TowerShield;

        public ClassFighter()
        {
            name = "Fighter";
            link = "http://www.d20pfsrd.com/classes/core-classes/fighter";
            HitDie = 10;
            baseAttack = BaseAttack.High;
            fortitudeSave = SaveProgression.High;
            reflexSave = SaveProgression.Low;
            willSave = SaveProgression.Low;
            favoredAttribute = "Strength";
        }

        public override void PopulateClassFeatureDatabase()
        {
            Globals.classFeatureDB.Add(new CFBonusFeats());
            Globals.classFeatureDB.Add(new CFBravery());
            Globals.classFeatureDB.Add(new CFArmorTraining());
            Globals.classFeatureDB.Add(new CFWeaponTraining());
            Globals.classFeatureDB.Add(new CFArmorMastery());
            Globals.classFeatureDB.Add(new CFWeaponMastery());
        }

        public override void  CreateArchetypes()
        {
            ClassArchetype curAT;

            curAT = new ClassArchetype();
            curAT.name = "Standard";
            curAT.armorProficiency = standardArmorProficiency;
            curAT.preferredArmor = Armor.ArmorType.Heavy;
            curAT.classSkills.AddRange(standardSkills);
            curAT.skillRanks = 2;
            curAT.features.Add(Globals.classFeatureDB[bonusFeatName]);
            curAT.features.Add(Globals.classFeatureDB[braveryName]);
            curAT.features.Add(Globals.classFeatureDB[armorTrainingName]);
            curAT.features.Add(Globals.classFeatureDB[weaponTrainingName]);
            curAT.features.Add(Globals.classFeatureDB[armorMasteryName]);
            curAT.features.Add(Globals.classFeatureDB[weaponMasteryName]);
            availableArchetypes.Add(curAT);
        }

        protected class CFBonusFeats : ClassFeature
        {
            public CFBonusFeats()
            {
                name = bonusFeatName;
                grantedAbilities.Add(new ClassAbility(1, new Bonus("Feat", "Inherent", "1", string.Empty, "Type: Combat")));
                grantedAbilities.Add(new ClassAbility(2, new Bonus("Feat", "Inherent", "1", string.Empty, "Type: Combat")));
                grantedAbilities.Add(new ClassAbility(4, new Bonus("Feat", "Inherent", "1", string.Empty, "Type: Combat")));
                grantedAbilities.Add(new ClassAbility(6, new Bonus("Feat", "Inherent", "1", string.Empty, "Type: Combat")));
                grantedAbilities.Add(new ClassAbility(8, new Bonus("Feat", "Inherent", "1", string.Empty, "Type: Combat")));
                grantedAbilities.Add(new ClassAbility(10, new Bonus("Feat", "Inherent", "1", string.Empty, "Type: Combat")));
                grantedAbilities.Add(new ClassAbility(12, new Bonus("Feat", "Inherent", "1", string.Empty, "Type: Combat")));
                grantedAbilities.Add(new ClassAbility(14, new Bonus("Feat", "Inherent", "1", string.Empty, "Type: Combat")));
                grantedAbilities.Add(new ClassAbility(16, new Bonus("Feat", "Inherent", "1", string.Empty, "Type: Combat")));
                grantedAbilities.Add(new ClassAbility(18, new Bonus("Feat", "Inherent", "1", string.Empty, "Type: Combat")));
                grantedAbilities.Add(new ClassAbility(20, new Bonus("Feat", "Inherent", "1", string.Empty, "Type: Combat")));
            }
        }

        protected class CFBravery : ClassFeature
        {
            public CFBravery()
            {
                name = braveryName;
                grantedAbilities.Add(new ClassAbility(2, new Bonus("SaveWill", "Conditional", "1", string.Empty, "{0} vs. fear")));
                grantedAbilities.Add(new ClassAbility(6, new Bonus("SaveWill", "Conditional", "1", string.Empty, "{0} vs. fear")));
                grantedAbilities.Add(new ClassAbility(10, new Bonus("SaveWill", "Conditional", "1", string.Empty, "{0} vs. fear")));
                grantedAbilities.Add(new ClassAbility(14, new Bonus("SaveWill", "Conditional", "1", string.Empty, "{0} vs. fear")));
                grantedAbilities.Add(new ClassAbility(18, new Bonus("SaveWill", "Conditional", "1", string.Empty, "{0} vs. fear")));
            }
        }

        protected class CFArmorTraining : ClassFeature
        {
            public CFArmorTraining()
            {
                name = armorTrainingName;
                grantedAbilities.Add(new ClassAbility(3, new Bonus("ArmorCheck", "Inherent", "-1", string.Empty, string.Empty)));
                grantedAbilities.Add(new ClassAbility(7, new Bonus("ArmorCheck", "Inherent", "-1", string.Empty, string.Empty)));
                grantedAbilities.Add(new ClassAbility(11, new Bonus("ArmorCheck", "Inherent", "-1", string.Empty, string.Empty)));
                grantedAbilities.Add(new ClassAbility(15, new Bonus("ArmorCheck", "Inherent", "-1", string.Empty, string.Empty)));
                grantedAbilities.Add(new ClassAbility(3, new Bonus("MaxArmorDex", "Inherent", "1", string.Empty, string.Empty)));
                grantedAbilities.Add(new ClassAbility(7, new Bonus("MaxArmorDex", "Inherent", "1", string.Empty, string.Empty)));
                grantedAbilities.Add(new ClassAbility(11, new Bonus("MaxArmorDex", "Inherent", "1", string.Empty, string.Empty)));
                grantedAbilities.Add(new ClassAbility(15, new Bonus("MaxArmorDex", "Inherent", "1", string.Empty, string.Empty)));
            }
        }

        protected class CFWeaponTraining : ClassFeature
        {
            public CFWeaponTraining()
            {
                name = weaponTrainingName;
                grantedAbilities.Add(new ClassAbility(5, new Bonus("AttackRoll", "Conditional", "1", string.Empty, "{0} with weapon training")));
                grantedAbilities.Add(new ClassAbility(5, new Bonus("WeaponDamage", "Conditional", "1", string.Empty, "{0} with weapon training")));
                grantedAbilities.Add(new ClassAbility(5, new Bonus("CombatManeuverBonus", "Conditional", "1", string.Empty, "{0} with weapon training")));
            }
        }

        protected class CFArmorMastery : ClassFeature
        {
            public CFArmorMastery()
            {
                name = armorMasteryName;
                grantedAbilities.Add(new ClassAbility(19, new Bonus("DamageReduction", "Inherent", "5", string.Empty, string.Empty)));
            }
        }

        protected class CFWeaponMastery : ClassFeature
        {
            public CFWeaponMastery()
            {
                name = weaponMasteryName;
                grantedAbilities.Add(new ClassAbility(19, new Bonus("WeaponCriticalDamage", "Conditional", "1", string.Empty, "{0} with Weapon Mastery")));
            }
        }
    }
}
