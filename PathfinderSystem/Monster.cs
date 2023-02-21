using System;
using System.Collections.Generic;
using System.Text;

namespace PathfinderSystem
{
    public sealed class Monster
    {
        public enum CreatureType
        {
            Abberation,
            Animal,
            Construct,
            Dragon,
            Fey,
            Humanoid,
            MagicalBeast,
            MonstrousHumanoid,
            Ooze,
            Outsider,
            Plant,
            Undead,
            Vermin,
        }

        public string name;
        public Globals.Alignment alignment;

        public static string TypeString(CreatureType type, bool plural = false)
        {
            if (plural)
            {
                switch (type)
                {
                    case CreatureType.MagicalBeast:
                        return "Magical Beasts";
                    case CreatureType.MonstrousHumanoid:
                        return "Monstrous Humanoids";
                    case CreatureType.Fey:
                    case CreatureType.Undead:
                    case CreatureType.Vermin:
                        return type.ToString();
                    default:
                        return type.ToString() + 's';
                }
            }
            else
            {
                switch (type)
                {
                    case CreatureType.MagicalBeast:
                        return "Magical Beast";
                    case CreatureType.MonstrousHumanoid:
                        return "Monstrous Humanoid";
                    default:
                        return type.ToString();
                }
            }
        }
    }
}
