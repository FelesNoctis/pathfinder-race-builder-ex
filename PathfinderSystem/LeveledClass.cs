using System;
using System.Collections.Generic;
using System.Text;

namespace PathfinderSystem
{
    public abstract class LeveledClass
    {
        public enum BaseAttack
        {
            High,
            Medium,
            Low,
        }

        public enum SaveProgression
        {
            High,
            Low,
        }

        public string name;
        public string link;
        public ClassArchetype selectedArchetype;
        public int HitDie;
        public BaseAttack baseAttack;
        public SaveProgression fortitudeSave;
        public SaveProgression reflexSave;
        public SaveProgression willSave;
        public string favoredAttribute;
        public List<ClassArchetype> availableArchetypes = new List<ClassArchetype>();

        public List<Skill.SkillKey> classSkills
        {
            get
            {
                return selectedArchetype.classSkills;
            }
        }

        public int skillRanks
        {
            get
            {
                return selectedArchetype.skillRanks;
            }
        }

        public Armor.ArmorType armorProficiency
        {
            get
            {
                return selectedArchetype.armorProficiency;
            }
        }

        public Armor.ArmorType preferredArmor
        {
            get
            {
                return selectedArchetype.preferredArmor;
            }
        }

        public virtual void PopulateClassFeatureDatabase() { }
        public virtual void CreateArchetypes() { }
    }

    public class ClassDatabase : SortedList<string, LeveledClass>
    {
        public void Add(LeveledClass addMe)
        {
            Add(addMe.name, addMe);
        }
    }

    public class ClassArchetype
    {
        public string name;
        public List<Skill.SkillKey> classSkills = new List<Skill.SkillKey>();
        public int skillRanks;
        public Armor.ArmorType armorProficiency;
        public Armor.ArmorType preferredArmor;
        public List<ClassFeature> features = new List<ClassFeature>();
    }

    public class ClassFeature
    {
        public string name;
        public List<ClassAbility> grantedAbilities = new List<ClassAbility>();
    }

    public class ClassFeatureDatabase : SortedList<string, ClassFeature>
    {
        public void Add(ClassFeature addMe)
        {
            Add(addMe.name, addMe);
        }
    }

    public class ClassAbility
    {
        public int level;
        public Bonus bonus;

        public ClassAbility(int levelGranted, Bonus bonusGranted)
        {
            level = levelGranted;
            bonus = bonusGranted;
        }
    }
}
