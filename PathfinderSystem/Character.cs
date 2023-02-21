using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace PathfinderSystem
{
    public sealed class Character
    {
        public string name;
        public Race race;
        public Globals.Alignment alignment;
        public int baseStrength;
        public int baseDexterity;
        public int baseConstitution;
        public int baseIntelligence;
        public int baseWisdom;
        public int baseCharisma;
        public int currentLevel = 0;
        public List<CharacterLevel> levels = new List<CharacterLevel>(20);

        public int LevelInClass(Type classType, int upToLevel = 20)
        {
            // TODO - GetRange might not work properly?
            return levels.GetRange(0, Math.Min(levels.Count, upToLevel)).FindAll(curLevel => curLevel.chosenClass.GetType() == classType).Count;
            /*int count = 0;

            for (int i = 0; i < Math.Min(levels.Count, upToLevel); i++)
            {
                if (levels[i].chosenClass.GetType() == classType)
                    count++;
            }

            return count;*/
            //return levels.Take(upToLevel).Count(curLevel => curLevel.chosenClass.GetType() == classType);
        }

        public int GetBaseAbilityScore(string ability, int upToLevel = 20)
        {
            int result;

            switch (ability)
            {
                case "Strength":
                    result = baseStrength;
                    break;
                case "Dexterity":
                    result = baseDexterity;
                    break;
                case "Constitution":
                    result = baseConstitution;
                    break;
                case "Intelligence":
                    result = baseIntelligence;
                    break;
                case "Wisdom":
                    result = baseWisdom;
                    break;
                case "Charisma":
                    result = baseCharisma;
                    break;
                default:
                    MessageBox.Show("Bad character attribute name: \"" + ability + "\"");
                    return 0;
            }

            // Attribute point for every 4 levels.
            if (levels.Count >= 4)
            {
                // Determine if we're on the most frequent favored attribute.
                int i;
                int highestCount = 0;
                int ourAttribute = Globals.AttributeList[ability] - Globals.AttributeList["Strength"];
                int[] attribCount = { 0, 0, 0, 0, 0, 0 };

                // Tally totals
                for (i = 0; i < Math.Min(levels.Count, upToLevel); i++)
                    attribCount[Globals.AttributeList[levels[i].chosenClass.favoredAttribute] - Globals.AttributeList["Strength"]]++;

                // Find highest count among the totals.
                for (i = 1; i < attribCount.Length; i++)
                {
                    if (attribCount[i] > attribCount[highestCount])
                        highestCount = i;
                }

                // Our attribute has or shares the highest count, advance to the semifinals!
                if (attribCount[ourAttribute] == attribCount[highestCount])
                {
                    bool tiedForHighest = false;
                    
                    // See if there is a tie for highest
                    for (i = 0; i < attribCount.Length; i++)
                    {
                        if ((attribCount[i] == attribCount[highestCount]) && (i != highestCount))
                            tiedForHighest = true;
                    }

                    // In the event of a tie, first level taken will be the tiebreaker
                    // TODO - Will not work if first level doesn't correspond to highest count!!!
                    if ((tiedForHighest == false) || (levels[0].chosenClass.favoredAttribute == ability))
                        result += Math.Min(levels.Count, upToLevel) / 4;
                }

                /*
                var counting = levels.GroupBy(item => item.chosenClass).OrderByDescending(item => item.Count());

                if (ability == counting.First().Key.favoredAttribute)
                    result += upToLevel / 4;
                */
            }

            return result;
        }

        public int GetTotalAbilityScore(string ability, int upToLevel = 20)
        {
            int result = GetBaseAbilityScore(ability, upToLevel);

            // TODO - Get all bonuses!

            return result;
        }

        public int GetBonus(string attribute, Globals.ModifierDescriptor modifier, int upToLevel = 20)
        {
            return GetBonus(Globals.AttributeList[attribute], modifier, upToLevel);
        }

        public int GetBonus(int key, Globals.ModifierDescriptor modifier, int upToLevel = 20)
        {
            int bonus = 0, penalty = 0;

            race.TryBonus(key, modifier, ref bonus, ref penalty);

            // TODO - GetRange might not work properly?
            //foreach (CharacterLevel curLevel in levels.Take(upToLevel))
            foreach (CharacterLevel curLevel in levels.GetRange(0, Math.Min(levels.Count, upToLevel)))
            {
                int classLevel = LevelInClass(curLevel.chosenClass.GetType(), upToLevel);

                foreach (ClassFeature curFeature in curLevel.chosenClass.selectedArchetype.features)
                {
                    foreach (ClassAbility curAbility in curFeature.grantedAbilities.FindAll(ability => ability.level == classLevel))
                        curAbility.bonus.TryBonus(key, modifier, ref bonus, ref penalty);
                }

                foreach(Feat curFeat in curLevel.feats)
                    curFeat.TryBonusesAtLevel(key, modifier, Math.Min(levels.Count, upToLevel), this, ref bonus, ref penalty);
            }

            return bonus + penalty;
        }

        public int GetAllBonuses(int key, int upToLevel = 20)
        {
            int result = 0;

            foreach (Globals.ModifierDescriptor curDesc in Enum.GetValues(typeof(Globals.ModifierDescriptor)))
            {
                //if (Globals.excludeFromTotal.Contains(curDesc))
                if (Utils.ArrayContains(Globals.excludeFromTotal, curDesc))
                    continue;

                result += GetBonus(key, curDesc, upToLevel);
            }

            return result;
        }

        public int BaseAttackBonus(int atLevel = 20)
        {
            int i;
            int tmpBonus = 0;

            List<LeveledClass> classes = new List<LeveledClass>();

            for (i = 0; i < Math.Min(levels.Count, atLevel); i++)
            {
                if (!classes.Contains(levels[i].chosenClass))
                    classes.Add(levels[i].chosenClass);
            }

            foreach (LeveledClass curClass in classes)
            {
                switch (curClass.baseAttack)
                {
                    case LeveledClass.BaseAttack.High:
                        tmpBonus += levels.GetRange(0, Math.Min(levels.Count, atLevel)).FindAll(curLevel => curLevel.chosenClass == curClass).Count;
                        break;
                    case LeveledClass.BaseAttack.Medium:
                        tmpBonus += (int)(0.75 * levels.GetRange(0, Math.Min(levels.Count, atLevel)).FindAll(curLevel => curLevel.chosenClass == curClass).Count);
                        break;
                    case LeveledClass.BaseAttack.Low:
                        tmpBonus += (int)(0.5 * levels.GetRange(0, Math.Min(levels.Count, atLevel)).FindAll(curLevel => curLevel.chosenClass == curClass).Count);
                        break;
                }
            }

            return tmpBonus;
        }

        public int SkillRank(int key, int upToLevel = 20)
        {
            return levels.GetRange(0, Math.Min(levels.Count, upToLevel)).FindAll(curLevel => curLevel.skillPointAllocation.Contains(key)).Count;
            //return levels.Take(upToLevel).Count(curLevel => curLevel.skillPointAllocation.Contains(key));
        }

        public bool HasFeat(string featName, int upToLevel = 20)
        {
            return ((levels.GetRange(0, Math.Min(levels.Count, upToLevel)).Exists(curLevel => curLevel.feats.Exists(curFeat => curFeat.name == featName))));
            //                    || (levels.Take(upToLevel).Any(curLevel => curLevel.feats.Exists(curFeat => curFeat.name == featName))));
        }
    }

    public sealed class CharacterLevel
    {
        public LeveledClass chosenClass;
        public List<int> skillPointAllocation = new List<int>();
        public List<Feat> feats = new List<Feat>();
    }
}
