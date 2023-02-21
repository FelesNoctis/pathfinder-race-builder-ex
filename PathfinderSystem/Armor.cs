using System;
using System.Collections.Generic;
using System.Text;

namespace PathfinderSystem
{
    public class Armor : Equipment
    {
        [Flags]
        public enum ArmorType
        {
            None = 0,
            Light = 1,
            Medium = 2,
            Heavy = 4,
            TowerShield = 8, // Note - this must come before regular shields to proficiency can be parsed properly!
            Shield = 16,
        }
    }
}
