using System;
using System.Collections.Generic;
using System.Text;

namespace PathfinderSystem
{
    public class Weapon : Equipment
    {
        [Flags]
        public enum WeaponDamage
        {
            NA = 0,
            Bludgeoning = 1,
            Piercing = 2,
            Slashing = 4,
            Fire = 8,
            And = 16,
            Or = 32,
        }

        [Flags]
        public enum WeaponSpecial
        {
            None = 0,
            Brace = 1,
            Disarm = 2,
            Double = 4,
            Finesse = 8,
            Fragile = 16,
            Grapple = 32,
            Improvised = 64,
            Monk = 128,
            NonLethal = 256,
            Performance = 512,
            Reach = 1024,
            Sunder = 2048,
            Trip = 4096,
            RangedAmmunition = 8192,
            RangedStrengthBonus = 16384,
        }

        public enum WeaponType
        {
            Light,
            OneHanded,
            TwoHanded,
        }

        public int damage;
        public WeaponDamage damageType;
        public int criticalRange; // 18, 19, or 20.
        public int criticalMultiplier;
        public int rangeIncrement;
        public WeaponType type;
        public WeaponSpecial special;

        public Weapon(string newName, string damageDice, int critRange, int critMult, int range, float newWeight, float newValue, WeaponDamage newDamageType, WeaponType newType, WeaponSpecial newSpecial)
        {
            name = newName;
            damage = Utils.DieToIntHash(damageDice);
            damageType = newDamageType;
            criticalRange = critRange;
            criticalMultiplier = critMult;
            rangeIncrement = range;
            weight = newWeight;
            value = newValue;
            type = newType;
            special = newSpecial;
        }

        public static void AddWeapons(EquipmentDatabase db)
        {
            // Unarmed Attacks
            db.Add(new Weapon("Unarmed Strike", "1d3", 20, 2, 0, 0, 0, WeaponDamage.Bludgeoning, WeaponType.Light, WeaponSpecial.Monk | WeaponSpecial.NonLethal));
            db.Add(new Weapon("Gauntlet", "1d3", 20, 2, 0, 1, 2, WeaponDamage.Bludgeoning, WeaponType.Light, WeaponSpecial.None));
            // SIMPLE - Light Weapons
            db.Add(new Weapon("Battler Aspergillum", "1d6", 20, 2, 0, 4, 5, WeaponDamage.Bludgeoning, WeaponType.Light, WeaponSpecial.None));
            db.Add(new Weapon("Brass Knife", "1d4", 19, 2, 10, 1, 2, WeaponDamage.Piercing | WeaponDamage.Or | WeaponDamage.Slashing, WeaponType.Light, WeaponSpecial.Fragile));
            db.Add(new Weapon("Brass Knuckles", "1d3", 20, 2, 0, 1, 1, WeaponDamage.Bludgeoning, WeaponType.Light, WeaponSpecial.Monk));
            db.Add(new Weapon("Cestus", "1d4", 19, 2, 0, 1, 5, WeaponDamage.Bludgeoning | WeaponDamage.Or | WeaponDamage.Piercing, WeaponType.Light, WeaponSpecial.Monk));
            db.Add(new Weapon("Dagger", "1d4", 19, 2, 10, 1, 2, WeaponDamage.Piercing | WeaponDamage.Or | WeaponDamage.Slashing, WeaponType.Light, WeaponSpecial.None));
            db.Add(new Weapon("Punching Dagger", "1d4", 20, 3, 0, 1, 2, WeaponDamage.Piercing, WeaponType.Light, WeaponSpecial.None));
            db.Add(new Weapon("Spiked Gauntlet", "1d4", 20, 2, 0, 1, 5, WeaponDamage.Piercing, WeaponType.Light, WeaponSpecial.None));
            db.Add(new Weapon("Hook Hand", "1d4", 20, 2, 0, 1, 10, WeaponDamage.Slashing, WeaponType.Light, WeaponSpecial.Disarm));
            db.Add(new Weapon("Light Mace", "1d6", 20, 2, 0, 4, 5, WeaponDamage.Bludgeoning, WeaponType.Light, WeaponSpecial.None));
            db.Add(new Weapon("Sickle", "1d6", 20, 2, 0, 2, 6, WeaponDamage.Slashing, WeaponType.Light, WeaponSpecial.Trip));
            db.Add(new Weapon("Wooden Stake", "1d4", 20, 2, 10, 1, 0, WeaponDamage.Piercing, WeaponType.Light, WeaponSpecial.None));
            // SIMPLE - One Handed Melee Weapons
            db.Add(new Weapon("Club", "1d6", 20, 2, 10, 3, 0, WeaponDamage.Bludgeoning, WeaponType.OneHanded, WeaponSpecial.None));
            db.Add(new Weapon("Mere Club", "1d4", 20, 2, 0, 2, 2, WeaponDamage.Bludgeoning | WeaponDamage.Or | WeaponDamage.Piercing, WeaponType.OneHanded, WeaponSpecial.Fragile));
            db.Add(new Weapon("Heavy Mace", "1d8", 20, 2, 0, 8, 12, WeaponDamage.Bludgeoning, WeaponType.OneHanded, WeaponSpecial.None));
            db.Add(new Weapon("Morningstar", "1d8", 20, 2, 0, 6, 8, WeaponDamage.Bludgeoning | WeaponDamage.And | WeaponDamage.Piercing, WeaponType.OneHanded, WeaponSpecial.None));
            db.Add(new Weapon("Shortspear", "1d6", 20, 2, 20, 3, 1, WeaponDamage.Piercing, WeaponType.OneHanded, WeaponSpecial.None));
            // SIMPLE - Two Handed Melee Weapons
            db.Add(new Weapon("Bayonet", "1d6", 20, 2, 0, 1, 5, WeaponDamage.Piercing, WeaponType.TwoHanded, WeaponSpecial.None));
            db.Add(new Weapon("Boarding Pike", "1d8", 20, 3, 0, 9, 8, WeaponDamage.Piercing, WeaponType.TwoHanded, WeaponSpecial.Brace | WeaponSpecial.Reach));
            db.Add(new Weapon("Longspear", "1d8", 20, 3, 0, 9, 5, WeaponDamage.Piercing, WeaponType.TwoHanded, WeaponSpecial.Brace | WeaponSpecial.Reach));
            db.Add(new DoubleWeapon("Quarterstaff", "1d6", 20, 2, "1d6", 20, 2, 0, 4, 0, WeaponDamage.Bludgeoning, WeaponDamage.Bludgeoning, WeaponType.TwoHanded, WeaponSpecial.Monk));
            db.Add(new Weapon("Spear", "1d8", 20, 3, 20, 6, 2, WeaponDamage.Piercing, WeaponType.TwoHanded, WeaponSpecial.Brace));
            db.Add(new Weapon("Boar Spear", "1d8", 20, 2, 0, 8, 5, WeaponDamage.Piercing, WeaponType.TwoHanded, WeaponSpecial.Brace));
            // SIMPLE - Ranged Weapons
            db.Add(new Weapon("Blowgun", "1d2", 20, 2, 20, 1, 2, WeaponDamage.Piercing, WeaponType.TwoHanded, WeaponSpecial.RangedAmmunition));
            db.Add(new Weapon("Heavy Crossbow", "1d10", 19, 2, 120, 8, 50, WeaponDamage.Piercing, WeaponType.TwoHanded, WeaponSpecial.RangedAmmunition));
            db.Add(new Weapon("Heavy Underwater Crossbow", "1d10", 19, 2, 120, 8, 100, WeaponDamage.Piercing, WeaponType.TwoHanded, WeaponSpecial.RangedAmmunition));
            db.Add(new Weapon("Light Crossbow", "1d8", 19, 2, 80, 4, 35, WeaponDamage.Piercing, WeaponType.TwoHanded, WeaponSpecial.RangedAmmunition));
            db.Add(new Weapon("Light Underwater Crossbow", "1d8", 19, 2, 80, 4, 70, WeaponDamage.Piercing, WeaponType.TwoHanded, WeaponSpecial.RangedAmmunition));
            db.Add(new Weapon("Dart", "1d4", 20, 2, 20, 0.5f, 0.5f, WeaponDamage.Piercing, WeaponType.Light, WeaponSpecial.None));
            db.Add(new Weapon("Javelin", "1d6", 20, 2, 30, 2, 1, WeaponDamage.Piercing, WeaponType.OneHanded, WeaponSpecial.None));
            db.Add(new Weapon("Sling", "1d4", 20, 2, 50, 0, 0, WeaponDamage.Bludgeoning, WeaponType.OneHanded, WeaponSpecial.RangedAmmunition));
            db.Add(new Weapon("Stingchuck", "1d4", 20, 2, 10, 9, 0, WeaponDamage.Bludgeoning, WeaponType.OneHanded, WeaponSpecial.None));
            // MARTIAL - Light Melee Weapons
            db.Add(new Weapon("Boarding Axe", "1d6", 20, 3, 0, 3, 6, WeaponDamage.Piercing | WeaponDamage.Or | WeaponDamage.Slashing, WeaponType.Light, WeaponSpecial.None));
            db.Add(new Weapon("Throwing Axe", "1d6", 20, 2, 10, 2, 8, WeaponDamage.Slashing, WeaponType.Light, WeaponSpecial.None));
            db.Add(new Weapon("Blade Boot", "1d4", 20, 2, 0, 2, 25, WeaponDamage.Piercing, WeaponType.Light, WeaponSpecial.None));
            db.Add(new Weapon("Cat-o'-Nine-Tails", "1d4", 20, 2, 0, 1, 1, WeaponDamage.Slashing, WeaponType.Light, WeaponSpecial.Disarm | WeaponSpecial.NonLethal));
            db.Add(new Weapon("Dogslicer", "1d6", 19, 2, 0, 1, 8, WeaponDamage.Slashing, WeaponType.Light, WeaponSpecial.Fragile));
            db.Add(new Weapon("Light Hammer", "1d4", 20, 2, 20, 2, 1, WeaponDamage.Bludgeoning, WeaponType.Light, WeaponSpecial.None));
            db.Add(new Weapon("Gladius", "1d6", 19, 2, 0, 3, 15, WeaponDamage.Piercing | WeaponDamage.Or | WeaponDamage.Slashing, WeaponType.Light, WeaponSpecial.Performance));
            db.Add(new Weapon("Handaxe", "1d6", 20, 3, 0, 3, 6, WeaponDamage.Slashing, WeaponType.Light, WeaponSpecial.None));
            db.Add(new Weapon("Switchblade", "1d4", 19, 2, 10, 1, 5, WeaponDamage.Piercing, WeaponType.Light, WeaponSpecial.None));
            // TODO - Kobold tail attachments?
            db.Add(new Weapon("Kukri", "1d4", 18, 2, 0, 2, 8, WeaponDamage.Slashing, WeaponType.Light, WeaponSpecial.None));
            db.Add(new Weapon("Light Pick", "1d4", 20, 4, 0, 3, 4, WeaponDamage.Piercing, WeaponType.Light, WeaponSpecial.None));
            // TODO - Ratfolk tailblade?
            db.Add(new Weapon("Sap", "1d6", 20, 2, 0, 2, 1, WeaponDamage.Bludgeoning, WeaponType.Light, WeaponSpecial.NonLethal));
            db.Add(new Weapon("Sea-Knife", "1d4", 19, 2, 0, 1, 8, WeaponDamage.Slashing, WeaponType.Light, WeaponSpecial.None));
            // TODO - Shields/Armor?
            db.Add(new Weapon("Starknife", "1d4", 20, 3, 20, 3, 24, WeaponDamage.Piercing, WeaponType.Light, WeaponSpecial.None));
            db.Add(new Weapon("Short Sword", "1d6", 19, 2, 0, 2, 10, WeaponDamage.Piercing, WeaponType.Light, WeaponSpecial.None));
            db.Add(new Weapon("War Razor", "1d4", 19, 2, 0, 1, 8, WeaponDamage.Slashing, WeaponType.Light, WeaponSpecial.None));
            // MARTIAL - One Handed Melee Weapons
            db.Add(new Weapon("Battleaxe", "1d8", 20, 3, 0, 6, 10, WeaponDamage.Slashing, WeaponType.OneHanded, WeaponSpecial.None));
            db.Add(new Weapon("Combat Scabbard", "1d6", 20, 2, 0, 1, 1, WeaponDamage.Bludgeoning, WeaponType.OneHanded, WeaponSpecial.Improvised));
            db.Add(new Weapon("Cutlass", "1d6", 18, 2, 0, 4, 15, WeaponDamage.Slashing, WeaponType.OneHanded, WeaponSpecial.None));
            db.Add(new Weapon("Flail", "1d8", 20, 2, 0, 5, 8, WeaponDamage.Bludgeoning, WeaponType.OneHanded, WeaponSpecial.Disarm | WeaponSpecial.Trip));
            db.Add(new Weapon("Klar", "1d6", 20, 2, 0, 6, 12, WeaponDamage.Slashing, WeaponType.OneHanded, WeaponSpecial.None));
            db.Add(new Weapon("Longsword", "1d8", 19, 2, 0, 4, 12, WeaponDamage.Slashing, WeaponType.OneHanded, WeaponSpecial.None));
            db.Add(new Weapon("Heavy Pick", "1d6", 20, 4, 0, 6, 8, WeaponDamage.Piercing, WeaponType.OneHanded, WeaponSpecial.None));
            db.Add(new Weapon("Rapier", "1d6", 18, 2, 0, 2, 20, WeaponDamage.Piercing, WeaponType.OneHanded, WeaponSpecial.Finesse));
            db.Add(new Weapon("Sharpened Combat Scabbard", "1d6", 18, 2, 0, 1, 10, WeaponDamage.Slashing, WeaponType.OneHanded, WeaponSpecial.None));
            db.Add(new Weapon("Scimitar", "1d6", 18, 2, 0, 4, 15, WeaponDamage.Slashing, WeaponType.OneHanded, WeaponSpecial.None));
            db.Add(new Weapon("Scizore", "1d10", 20, 2, 0, 3, 20, WeaponDamage.Piercing, WeaponType.OneHanded, WeaponSpecial.None));
            // TODO - Shields?
            db.Add(new Weapon("Sword Cane", "1d6", 20, 2, 0, 4, 45, WeaponDamage.Piercing, WeaponType.OneHanded, WeaponSpecial.None));
            db.Add(new Weapon("Terbutje", "1d8", 19, 2, 0, 2, 5, WeaponDamage.Slashing, WeaponType.OneHanded, WeaponSpecial.Fragile));
            db.Add(new Weapon("Steel Terbutje", "1d8", 19, 2, 0, 4, 20, WeaponDamage.Slashing, WeaponType.OneHanded, WeaponSpecial.None));
            db.Add(new Weapon("Trident", "1d8", 20, 2, 10, 4, 15, WeaponDamage.Piercing, WeaponType.OneHanded, WeaponSpecial.Brace));
            db.Add(new Weapon("Warhammer", "1d8", 20, 3, 0, 5, 12, WeaponDamage.Bludgeoning, WeaponType.OneHanded, WeaponSpecial.None));
            // MARTIAL - Two Handed Melee Weapons
            db.Add(new Weapon("Bardiche", "1d10", 19, 2, 0, 14, 13, WeaponDamage.Slashing, WeaponType.TwoHanded, WeaponSpecial.Brace | WeaponSpecial.Reach));
            db.Add(new Weapon("Bec de Corbin", "1d10", 20, 3, 0, 12, 15, WeaponDamage.Bludgeoning | WeaponDamage.Or | WeaponDamage.Piercing, WeaponType.TwoHanded, WeaponSpecial.Brace | WeaponSpecial.Reach));
            db.Add(new Weapon("Bill", "1d8", 20, 3, 0, 11, 11, WeaponDamage.Slashing, WeaponType.TwoHanded, WeaponSpecial.Brace | WeaponSpecial.Reach));
            db.Add(new Weapon("Earth Breaker", "2d6", 20, 3, 0, 14, 40, WeaponDamage.Bludgeoning, WeaponType.TwoHanded, WeaponSpecial.None));
            db.Add(new Weapon("Falchion", "2d4", 18, 2, 0, 8, 75, WeaponDamage.Slashing, WeaponType.TwoHanded, WeaponSpecial.None));
            db.Add(new Weapon("Heavy Flail", "1d10", 19, 2, 0, 10, 15, WeaponDamage.Bludgeoning, WeaponType.TwoHanded, WeaponSpecial.Disarm | WeaponSpecial.Trip));
            db.Add(new Weapon("Glaive", "1d10", 20, 3, 0, 10, 8, WeaponDamage.Slashing, WeaponType.TwoHanded, WeaponSpecial.Brace | WeaponSpecial.Reach));
            db.Add(new Weapon("Glaive-Guisarme", "1d10", 20, 3, 0, 10, 12, WeaponDamage.Slashing, WeaponType.TwoHanded, WeaponSpecial.Brace | WeaponSpecial.Reach));
            db.Add(new Weapon("Greataxe", "1d12", 20, 3, 0, 12, 20, WeaponDamage.Slashing, WeaponType.TwoHanded, WeaponSpecial.None));
            db.Add(new Weapon("Greatclub", "1d10", 20, 2, 0, 8, 5, WeaponDamage.Bludgeoning, WeaponType.TwoHanded, WeaponSpecial.None));
            db.Add(new Weapon("Greatsword", "2d6", 19, 2, 0, 8, 50, WeaponDamage.Slashing, WeaponType.TwoHanded, WeaponSpecial.None));
            db.Add(new Weapon("Guisarme", "2d4", 20, 3, 0, 12, 9, WeaponDamage.Slashing, WeaponType.TwoHanded, WeaponSpecial.Reach | WeaponSpecial.Trip));
            db.Add(new Weapon("Halberd", "1d10", 20, 3, 0, 12, 10, WeaponDamage.Piercing | WeaponDamage.Or | WeaponDamage.Slashing, WeaponType.TwoHanded, WeaponSpecial.Brace | WeaponSpecial.Trip));
            db.Add(new Weapon("Lucerne Hammer", "1d12", 20, 2, 0, 12, 15, WeaponDamage.Bludgeoning | WeaponDamage.Or | WeaponDamage.Piercing, WeaponType.TwoHanded, WeaponSpecial.Brace | WeaponSpecial.Reach));
            db.Add(new Weapon("Horsechopper", "1d10", 20, 3, 0, 12, 10, WeaponDamage.Piercing | WeaponDamage.Or | WeaponDamage.Slashing, WeaponType.TwoHanded, WeaponSpecial.Reach | WeaponSpecial.Trip));
            db.Add(new Weapon("Ogre Hook", "1d10", 20, 3, 0, 10, 24, WeaponDamage.Piercing, WeaponType.TwoHanded, WeaponSpecial.Trip));
            db.Add(new Weapon("Pickaxe", "1d8", 20, 4, 0, 12, 14, WeaponDamage.Piercing, WeaponType.TwoHanded, WeaponSpecial.None));
            db.Add(new Weapon("Ranseur", "2d4", 20, 3, 0, 12, 10, WeaponDamage.Piercing, WeaponType.TwoHanded, WeaponSpecial.Disarm | WeaponSpecial.Reach));
            db.Add(new Weapon("Scythe", "2d4", 20, 4, 0, 10, 18, WeaponDamage.Piercing | WeaponDamage.Or | WeaponDamage.Slashing, WeaponType.TwoHanded, WeaponSpecial.Trip));
            db.Add(new Weapon("Syringe Spear", "1d8", 20, 3, 0, 6, 100, WeaponDamage.Piercing, WeaponType.TwoHanded, WeaponSpecial.Brace));
            // MARTIAL - Ranged Weapons
            db.Add(new Weapon("Ammentum", "1d6", 20, 2, 50, 1, 0, WeaponDamage.Piercing, WeaponType.OneHanded, WeaponSpecial.Performance));
            db.Add(new Weapon("Chakram", "1d8", 20, 2, 30, 1, 1, WeaponDamage.Slashing, WeaponType.OneHanded, WeaponSpecial.None));
            db.Add(new Weapon("Jolting Dart", "1d4", 20, 2, 20, 0.5f, 100, WeaponDamage.Piercing, WeaponType.Light, WeaponSpecial.None));
            db.Add(new Weapon("Hunga Munga", "1d6", 20, 2, 15, 3, 4, WeaponDamage.Piercing, WeaponType.OneHanded, WeaponSpecial.None));
            db.Add(new Weapon("Longbow", "1d8", 20, 3, 100, 3, 75, WeaponDamage.Piercing, WeaponType.TwoHanded, WeaponSpecial.RangedAmmunition));
            db.Add(new Weapon("Composite Longbow", "1d8", 20, 3, 110, 3, 100, WeaponDamage.Piercing, WeaponType.TwoHanded, WeaponSpecial.RangedAmmunition));
            db.Add(new Weapon("Pilum", "1d8", 20, 2, 20, 4, 5, WeaponDamage.Piercing, WeaponType.OneHanded, WeaponSpecial.None));
            db.Add(new Weapon("Shortbow", "1d6", 20, 3, 60, 2, 30, WeaponDamage.Piercing, WeaponType.TwoHanded, WeaponSpecial.RangedAmmunition));
            db.Add(new Weapon("Composite Shortbow", "1d6", 20, 3, 70, 2, 75, WeaponDamage.Piercing, WeaponType.TwoHanded, WeaponSpecial.RangedAmmunition));
            // EXOTIC - Light Weapons
            db.Add(new Weapon("Aklys", "1d8", 20, 2, 20, 2, 5, WeaponDamage.Bludgeoning, WeaponType.Light, WeaponSpecial.Performance | WeaponSpecial.Trip));
            db.Add(new Weapon("Knuckle Axe", "1d6", 20, 3, 0, 2, 9, WeaponDamage.Slashing, WeaponType.Light, WeaponSpecial.Monk | WeaponSpecial.Performance));
            // Barbazu Beard?
            db.Add(new Weapon("Battle Poi", "1d4", 20, 2, 0, 2, 5, WeaponDamage.Fire, WeaponType.Light, WeaponSpecial.None));
            db.Add(new Weapon("Swordbreaker Dagger", "1d4", 20, 2, 0, 3, 10, WeaponDamage.Slashing, WeaponType.Light, WeaponSpecial.Disarm | WeaponSpecial.Sunder));
            db.Add(new Weapon("Flying Talon", "1d4", 20, 2, 10, 5, 15, WeaponDamage.Piercing, WeaponType.Light, WeaponSpecial.Disarm | WeaponSpecial.Trip));
            // Dwarven Boulder Helmet?
            db.Add(new Weapon("Kama", "1d6", 20, 2, 0, 2, 2, WeaponDamage.Slashing, WeaponType.Light, WeaponSpecial.Monk | WeaponSpecial.Trip));
            db.Add(new Weapon("Tri-Bladed Katar", "1d4", 20, 4, 0, 2, 6, WeaponDamage.Piercing, WeaponType.Light, WeaponSpecial.None));
            db.Add(new Weapon("Butterfly Knife", "1d4", 19, 2, 0, 1, 5, WeaponDamage.Piercing | WeaponDamage.Or | WeaponDamage.Slashing, WeaponType.Light, WeaponSpecial.None));
            db.Add(new Weapon("Dwarven Maulaxe", "1d6", 20, 3, 10, 5, 25, WeaponDamage.Bludgeoning | WeaponDamage.Or | WeaponDamage.Slashing, WeaponType.Light, WeaponSpecial.None));
            db.Add(new Weapon("Nunchaku", "1d6", 20, 2, 0, 2, 2, WeaponDamage.Bludgeoning, WeaponType.Light, WeaponSpecial.Disarm | WeaponSpecial.Monk));
            db.Add(new Weapon("Qadrens", "1d6", 19, 2, 0, 2, 8, WeaponDamage.Piercing, WeaponType.Light, WeaponSpecial.Performance));
            db.Add(new Weapon("Rope Gauntlet", "1d4", 20, 2, 0, 2, 0.2f, WeaponDamage.Bludgeoning | WeaponDamage.Or | WeaponDamage.Slashing, WeaponType.Light, WeaponSpecial.None));
            db.Add(new Weapon("Sai", "1d4", 20, 2, 0, 1, 1, WeaponDamage.Bludgeoning, WeaponType.Light, WeaponSpecial.Disarm | WeaponSpecial.Monk));
            db.Add(new Weapon("Siangham", "1d6", 20, 2, 0, 1, 3, WeaponDamage.Piercing, WeaponType.Light, WeaponSpecial.Monk));
            db.Add(new Weapon("Sica", "1d6", 20, 2, 0, 2, 10, WeaponDamage.Slashing, WeaponType.Light, WeaponSpecial.Performance));
            db.Add(new Weapon("Thorn Bracer", "1d6", 20, 2, 0, 3, 30, WeaponDamage.Piercing, WeaponType.Light, WeaponSpecial.None));
            db.Add(new Weapon("Scorpion Whip", "1d4", 20, 2, 0, 3, 4, WeaponDamage.Slashing, WeaponType.Light, WeaponSpecial.Disarm | WeaponSpecial.Performance | WeaponSpecial.Reach | WeaponSpecial.Trip));
            // EXOTIC - One Handed Melee Weapons
            db.Add(new Weapon("Hooked Axe", "1d8", 20, 3, 0, 7, 20, WeaponDamage.Slashing, WeaponType.OneHanded, WeaponSpecial.Disarm | WeaponSpecial.Performance | WeaponSpecial.Trip));
            db.Add(new Weapon("Falcata", "1d8", 19, 3, 0, 4, 18, WeaponDamage.Slashing, WeaponType.OneHanded, WeaponSpecial.None));
            // Flindbar?
            db.Add(new Weapon("Rhoka", "1d8", 18, 2, 0, 6, 6, WeaponDamage.Slashing, WeaponType.OneHanded, WeaponSpecial.None));
            db.Add(new Weapon("Sawtooth Saber", "1d8", 19, 2, 0, 2, 35, WeaponDamage.Slashing, WeaponType.OneHanded, WeaponSpecial.None));
            db.Add(new Weapon("Shotel", "1d8", 20, 3, 0, 3, 30, WeaponDamage.Piercing, WeaponType.OneHanded, WeaponSpecial.Performance));
            db.Add(new Weapon("Dueling Sword", "1d8", 19, 2, 0, 3, 20, WeaponDamage.Slashing, WeaponType.OneHanded, WeaponSpecial.None));
            db.Add(new Weapon("Bastard Sword", "1d10", 19, 2, 0, 6, 35, WeaponDamage.Slashing, WeaponType.OneHanded, WeaponSpecial.None));
            db.Add(new Weapon("Dwarven Waraxe", "1d10", 20, 3, 0, 8, 30, WeaponDamage.Slashing, WeaponType.OneHanded, WeaponSpecial.None));
            db.Add(new Weapon("Dwarven Double Waraxe", "1d10", 20, 3, 0, 12, 60, WeaponDamage.Slashing, WeaponType.OneHanded, WeaponSpecial.None));
            db.Add(new Weapon("Whip", "1d3", 20, 2, 0, 2, 1, WeaponDamage.Slashing, WeaponType.OneHanded, WeaponSpecial.Disarm | WeaponSpecial.Finesse | WeaponSpecial.NonLethal | WeaponSpecial.Reach | WeaponSpecial.Trip));
            // EXOTIC - Two Handed Melee Weapons
            db.Add(new DoubleWeapon("Orc Double Axe", "1d8", 20, 3, "1d8", 20, 3, 0, 15, 60, WeaponDamage.Slashing, WeaponDamage.Slashing, WeaponType.TwoHanded, WeaponSpecial.None));
            db.Add(new DoubleWeapon("Battle Ladder", "1d6", 20, 2, "1d6", 20, 2, 0, 8, 20, WeaponDamage.Bludgeoning, WeaponDamage.Bludgeoning, WeaponType.TwoHanded, WeaponSpecial.Trip));
            db.Add(new DoubleWeapon("Boarding Gaff", "1d6", 20, 2, "1d6", 20, 2, 0, 8, 8, WeaponDamage.Slashing, WeaponDamage.Slashing, WeaponType.TwoHanded, WeaponSpecial.Reach | WeaponSpecial.Trip));
            db.Add(new Weapon("Spiked Chain", "2d4", 20, 2, 0, 10, 25, WeaponDamage.Piercing, WeaponType.TwoHanded, WeaponSpecial.Disarm | WeaponSpecial.Trip));
            db.Add(new Weapon("Elven Curve Blade", "1d10", 18, 2, 0, 7, 80, WeaponDamage.Slashing, WeaponType.TwoHanded, WeaponSpecial.None));
            db.Add(new Weapon("Dwarven Dorn Dergar", "1d10", 20, 2, 0, 15, 50, WeaponDamage.Bludgeoning, WeaponType.TwoHanded, WeaponSpecial.Reach));
            db.Add(new Weapon("Fauchard", "1d10", 18, 2, 0, 10, 14, WeaponDamage.Slashing, WeaponType.TwoHanded, WeaponSpecial.Reach | WeaponSpecial.Trip));
            db.Add(new DoubleWeapon("Dire Flail", "1d8", 20, 2, "1d8", 20, 2, 0, 10, 90, WeaponDamage.Bludgeoning, WeaponDamage.Bludgeoning, WeaponType.TwoHanded, WeaponSpecial.Disarm | WeaponSpecial.Trip));
            db.Add(new Weapon("Flailpole", "1d8", 20, 2, 0, 10, 15, WeaponDamage.Slashing, WeaponType.TwoHanded, WeaponSpecial.Reach | WeaponSpecial.Trip));
            db.Add(new Weapon("Flambard", "1d10", 19, 2, 0, 6, 50, WeaponDamage.Slashing, WeaponType.TwoHanded, WeaponSpecial.Sunder));
            db.Add(new Weapon("Flying Blade", "1d12", 20, 3, 0, 12, 40, WeaponDamage.Slashing, WeaponType.TwoHanded, WeaponSpecial.Performance | WeaponSpecial.Reach));
            db.Add(new Weapon("Garrote", "1d6", 20, 2, 0, 1, 3, WeaponDamage.Slashing, WeaponType.TwoHanded, WeaponSpecial.Grapple));
            db.Add(new DoubleWeapon("Gnome Hooked Hammer", "1d8", 20, 3, "1d6", 20, 4, 0, 6, 20, WeaponDamage.Bludgeoning, WeaponDamage.Piercing, WeaponType.TwoHanded, WeaponSpecial.Trip));
            db.Add(new Weapon("Harpoon", "1d8", 20, 3, 10, 16, 5, WeaponDamage.Piercing, WeaponType.TwoHanded, WeaponSpecial.Grapple));
            db.Add(new Weapon("Dwarven Longaxe", "1d12", 20, 3, 0, 14, 50, WeaponDamage.Slashing, WeaponType.TwoHanded, WeaponSpecial.Reach));
            db.Add(new Weapon("Dwarven Longhammer", "2d6", 20, 3, 0, 20, 70, WeaponDamage.Bludgeoning, WeaponType.TwoHanded, WeaponSpecial.Reach));
            db.Add(new Weapon("Mancatcher", "1d2", 20, 2, 0, 10, 15, WeaponDamage.Piercing, WeaponType.TwoHanded, WeaponSpecial.Grapple | WeaponSpecial.Reach));
            db.Add(new Weapon("Snag Net", "0", 20, 1, 10, 10, 30, WeaponDamage.NA, WeaponType.TwoHanded, WeaponSpecial.Trip));
            db.Add(new Weapon("Piston Maul", "1d10", 20, 2, 0, 15, 70, WeaponDamage.Bludgeoning, WeaponType.TwoHanded, WeaponSpecial.None));
            // EXOTIC - Ranged Weapons
            db.Add(new Weapon("Bola", "1d4", 20, 2, 10, 2, 5, WeaponDamage.Bludgeoning, WeaponType.OneHanded, WeaponSpecial.NonLethal | WeaponSpecial.Trip));
            db.Add(new Weapon("Brutal Bola", "1d4", 20, 2, 10, 2, 15, WeaponDamage.Bludgeoning | WeaponDamage.And | WeaponDamage.Piercing, WeaponType.OneHanded, WeaponSpecial.Trip));
            db.Add(new Weapon("Boomerang", "1d6", 20, 2, 30, 3, 3, WeaponDamage.Bludgeoning, WeaponType.OneHanded, WeaponSpecial.None));
            db.Add(new Weapon("Thorn Bow", "1d6", 20, 3, 40, 2, 50, WeaponDamage.Piercing, WeaponType.TwoHanded, WeaponSpecial.None));
            db.Add(new Weapon("Double Crossbow", "1d8", 19, 2, 80, 18, 300, WeaponDamage.Piercing, WeaponType.TwoHanded, WeaponSpecial.RangedAmmunition));
            db.Add(new Weapon("Hand Crossbow", "1d4", 19, 2, 30, 2, 100, WeaponDamage.Piercing, WeaponType.OneHanded, WeaponSpecial.RangedAmmunition));
            db.Add(new Weapon("Heavy Repeating Crossbow", "1d10", 19, 2, 120, 12, 400, WeaponDamage.Piercing, WeaponType.TwoHanded, WeaponSpecial.RangedAmmunition));
            db.Add(new Weapon("Repeating Crossbow", "1d8", 19, 2, 80, 6, 250, WeaponDamage.Piercing, WeaponType.TwoHanded, WeaponSpecial.RangedAmmunition));
            // Flask Throwing?
            db.Add(new Weapon("Grappling Hook", "1d6", 20, 2, 10, 14, 6, WeaponDamage.Piercing, WeaponType.OneHanded, WeaponSpecial.Grapple));
            db.Add(new Weapon("Lasso", "0", 20, 1, 10, 5, 0.1f, WeaponDamage.NA, WeaponType.OneHanded, WeaponSpecial.None));
            db.Add(new Weapon("Net", "0", 20, 1, 10, 6, 20, WeaponDamage.NA, WeaponType.OneHanded, WeaponSpecial.None));
            // Throwing Shield?
            db.Add(new Weapon("Shrillshaft Javelin", "1d6", 20, 2, 30, 3, 35, WeaponDamage.Piercing, WeaponType.OneHanded, WeaponSpecial.None));
            db.Add(new Weapon("Shuriken", "1d2", 20, 2, 10, 0.1f, 0.2f, WeaponDamage.Piercing, WeaponType.Light, WeaponSpecial.Monk));
            db.Add(new DoubleWeapon("Double Sling", "1d4", 20, 2, "1d4", 20, 2, 50, 1, 10, WeaponDamage.Bludgeoning, WeaponDamage.Bludgeoning, WeaponType.TwoHanded, WeaponSpecial.RangedAmmunition));
            db.Add(new Weapon("Sling Glove", "1d4", 20, 2, 50, 2, 5, WeaponDamage.Bludgeoning, WeaponType.OneHanded, WeaponSpecial.RangedAmmunition | WeaponSpecial.RangedStrengthBonus));
            db.Add(new Weapon("Halfling Sling Staff", "1d8", 20, 3, 80, 3, 20, WeaponDamage.Bludgeoning, WeaponType.TwoHanded, WeaponSpecial.RangedAmmunition));
            db.Add(new Weapon("Stitched Sling", "1d6", 20, 2, 0, 1, 0, WeaponDamage.Bludgeoning, WeaponType.OneHanded, WeaponSpecial.Disarm | WeaponSpecial.Trip));
        }
    }

    public class DoubleWeapon : Weapon
    {
        public int damage2;
        public WeaponDamage damageType2;
        public int criticalRange2; // 18, 19, or 20.
        public int criticalMultiplier2;

        public DoubleWeapon(string newName, string damageDice, int critRange, int critMult, string damageDice2, int critRange2, int critMult2, int range, int newWeight, float newValue, WeaponDamage newDamageType, WeaponDamage newDamageType2, WeaponType newType, WeaponSpecial newSpecial)
            : base(newName, damageDice, critRange, critMult, range, newWeight, newValue, newDamageType, newType, newSpecial | WeaponSpecial.Double)
        {
            damage2 = Utils.DieToIntHash(damageDice2);
            damageType2 = newDamageType2;
            criticalRange2 = critRange2;
            criticalMultiplier2 = critMult2;
        }
    }
}
