using System;
using System.Collections.Generic;
using System.Text;

namespace PathfinderSystem
{
    public class ClassWarrior : LeveledClass
    {
                public static readonly Skill.SkillKey[] standardSkills =
        {
            Skill.SkillKey.Climb,
            Skill.SkillKey.CraftAncillary,
            Skill.SkillKey.CraftPrimary,
            Skill.SkillKey.HandleAnimal,
            Skill.SkillKey.Intimidate,
            Skill.SkillKey.Profession,
            Skill.SkillKey.Ride,
            Skill.SkillKey.Swim,
        };

        public static readonly Armor.ArmorType standardArmorProficiency = Armor.ArmorType.Light | Armor.ArmorType.Medium | Armor.ArmorType.Heavy | Armor.ArmorType.Shield | Armor.ArmorType.TowerShield;

        public ClassWarrior()
        {
            ClassArchetype curAT;

            name = "Warrior";
            link = "http://http://www.d20pfsrd.com/classes/npc-classes/warrior";
            HitDie = 10;
            baseAttack = BaseAttack.High;
            fortitudeSave = SaveProgression.High;
            reflexSave = SaveProgression.Low;
            willSave = SaveProgression.Low;
            favoredAttribute = "Strength";

            curAT = new ClassArchetype();
            curAT.name = "Standard";
            curAT.armorProficiency = standardArmorProficiency;
            curAT.preferredArmor = Armor.ArmorType.Heavy;
            curAT.classSkills.AddRange(standardSkills);
            curAT.skillRanks = 2;
            availableArchetypes.Add(curAT);
        }
    }
}
