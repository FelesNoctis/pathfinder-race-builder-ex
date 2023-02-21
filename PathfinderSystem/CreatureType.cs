using System;
using System.Collections.Generic;
using System.Text;

namespace PathfinderSystem
{
    public sealed class CreatureType
    {
        private string nameInternal;
        public string name
        {
            get { return nameInternal; }
        }
        private string namePluralInternal;
        public string namePlural
        {
            get { return namePluralInternal; }
        }
        private string entryNameInternal;
        public string entryName
        {
            get { return entryNameInternal; }
        }
        private string entryPluralInternal;
        public string entryPlural
        {
            get { return entryPluralInternal; }
        }
        private string intrinsicSubtypesInternal;
        public string intrinsicSubtypes
        {
            get { return intrinsicSubtypesInternal; }
        }
        private string descriptionInternal;
        public string description
        {
            get { return descriptionInternal; }
        }
        private string additionalEntryInfoInternal;
        public string additionalEntryInfo
        {
            get { return additionalEntryInfo; }
        }
        private int buildPointsInternal;
        public int buildPoints
        {
            get { return buildPointsInternal; }
        }
        public List<RacialTrait> intrinsicTraits = new List<RacialTrait>();

        public CreatureType(string myName, string myPlural, string myInfo, string myDescription, int myBP)
        {
            nameInternal = entryNameInternal = myName;
            namePluralInternal = entryPluralInternal = myPlural;
            additionalEntryInfoInternal = myInfo;
            descriptionInternal = myDescription;
            buildPointsInternal = myBP;
        }

        public CreatureType(string myName, string myPlural, string myEntry, string myEntryPlural, string mySubtypes, string myInfo, string myDescription, int myBP)
        {
            nameInternal = myName;
            namePluralInternal = myPlural;
            entryNameInternal = myEntry;
            entryPluralInternal = myEntryPlural;
            intrinsicSubtypesInternal = mySubtypes;
            additionalEntryInfoInternal = myInfo;
            descriptionInternal = myDescription;
            buildPointsInternal = myBP;
        }
    }

    public sealed class CreatureTypeDatabase : SortedList<string, CreatureType>
    {
        public CreatureTypeDatabase()
        {
            Add(new CreatureType("Aberration", "aberrations", string.Empty, "Aberrations have bizarre anatomies, strange abilities, alien mindsets, or any combination of the three." + System.Environment.NewLine + System.Environment.NewLine + "Aberrations have the darkvision 60 feet racial trait." + System.Environment.NewLine + "Aberrations breathe, eat, and sleep.", 3));
            this["Aberration"].intrinsicTraits.Add(Globals.raceTraitDB["Darkvision 60 ft."]);
            Add(new CreatureType("Construct", "constructs", string.Empty, "A construct race is a group of animated objects or artificially created creatures." + System.Environment.NewLine + System.Environment.NewLine + "Constructs have no Constitution score. Any DCs or other statistics that rely on a Constitution score treat a construct as having a score of 10 (no bonus or penalty)." + System.Environment.NewLine + "Constructs have the low-light vision racial trait." + System.Environment.NewLine + "Constructs have the darkvision 60 feet racial trait." + System.Environment.NewLine + "Constructs are immune to all mind-affecting effects (charms, compulsions, morale effects, patterns, and phantasms)." + System.Environment.NewLine + "Constructs cannot heal damage on their own, but can often be repaired via exposure to a certain kind of effect (depending on the construct's racial abilities) or through the use of the Craft Construct feat. Constructs can also be healed through spells such as make whole. A construct with the fast healing special quality still benefits from that quality." + System.Environment.NewLine + "Constructs are not subject to ability damage, ability drain, fatigue, exhaustion, energy drain, or nonlethal damage." + System.Environment.NewLine + "Constructs are immune to any effect that requires a Fortitude save (unless the effect also works on objects or is harmless)." + System.Environment.NewLine + "Constructs do not risk death due to massive damage, but they are immediately destroyed when reduced to 0 hit points or fewer." + System.Environment.NewLine + "Constructs cannot be raised or resurrected." + System.Environment.NewLine + "Constructs are hard to destroy, and gain bonus hit points based on their size." + System.Environment.NewLine + "Constructs do not breathe, eat, or sleep, unless they want to gain some beneficial effect from one of these activities. This means that a construct can drink potions to benefit from their effects and can sleep in order to regain spells, but neither of these activities is required to survive or stay in good health.", 20));
            this["Construct"].intrinsicTraits.Add(Globals.raceTraitDB["Low-Light Vision"]);
            this["Construct"].intrinsicTraits.Add(Globals.raceTraitDB["Darkvision 60 ft."]);
            Add(new CreatureType("Dragon", "dragons", string.Empty, "A dragon is a reptilian creature with magical or unusual abilities." + System.Environment.NewLine + System.Environment.NewLine + "Dragons have the darkvision 60 feet racial trait." + System.Environment.NewLine + "Dragons have the low-light vision racial trait." + System.Environment.NewLine + "Dragons are immune to magical sleep effects and paralysis effects." + System.Environment.NewLine + "Dragons breathe, eat, and sleep.",  10));
            this["Dragon"].intrinsicTraits.Add(Globals.raceTraitDB["Low-Light Vision"]);
            this["Dragon"].intrinsicTraits.Add(Globals.raceTraitDB["Darkvision 60 ft."]);
            Add(new CreatureType("Fey", "fey", string.Empty, "A fey is a creature with supernatural abilities and connections to nature or to some other force or place." + System.Environment.NewLine + System.Environment.NewLine + "Fey have the low-light vision racial trait." + System.Environment.NewLine + "Fey breathe, eat, and sleep.", 2));
            this["Fey"].intrinsicTraits.Add(Globals.raceTraitDB["Low-Light Vision"]);
            Add(new CreatureType("Half-Construct", "half-constructs", "Humanoid", "Humanoids", "half-construct", string.Empty, "A half-construct race is a group of creatures that are artificially enhanced or have parts replaced by constructed mechanisms, be they magical or mechanical." + System.Environment.NewLine + System.Environment.NewLine + "Half-constructs gain a +2 racial bonus on saving throws against disease, mind-affecting effects, poison, and effects that cause either exhaustion or fatigue." + System.Environment.NewLine + "Half-constructs cannot be raised or resurrected." + System.Environment.NewLine + "Half-constructs do not breathe, eat, or sleep, unless they want to gain some beneficial effect from one of these activities. This means that a half-construct can drink potions to benefit from their effects and can sleep in order to regain spells, but neither of these activities is required for the construct to survive or stay in good health.", 7));
            Add(new CreatureType("Half-Undead", "half-undead", "Humanoid", "Humanoids", "half-undead", string.Empty, "Half-undead races are strange or unholy fusions of the living and the undead. Players interested in playing a half-undead race might also consider the dhampir, the progeny of a vampire and a human." + System.Environment.NewLine + System.Environment.NewLine + "Half-undead have the darkvision 60 feet racial trait." + System.Environment.NewLine + "Half-undead gain a +2 racial bonus on saving throws against disease and mind-affecting effects." + System.Environment.NewLine + "Half-undead take no penalties from energy-draining effects, though they can still be killed if they accrue more negative levels than they have Hit Dice. After 24 hours, any negative levels they've gained are removed without any additional saving throws." + System.Environment.NewLine + "Half-undead creatures are harmed by positive energy and healed by negative energy. A half-undead creature with the fast healing special quality still benefits from that quality.", 5));
            this["Half-Undead"].intrinsicTraits.Add(Globals.raceTraitDB["Darkvision 60 ft."]);
            Add(new CreatureType("Humanoid", "humanoids", string.Empty, "Humanoid races have few or no supernatural or spell-like abilities, but most can speak and have well-developed societies. Humanoids are usually Small or Medium, unless they have the giant subtype, in which case they are Large. Every humanoid creature also has a subtype to match its race, such as human, giant, goblinoid, reptilian, or tengu. If you are making a new humanoid race, you should either find an existing subtype to match or make a new one by using the name of the race as the subtype. If you are making a half-breed race, it should have the racial type of both parent races. For example, a half-elf has both the human and the elf subtypes. Subtypes are often important to qualify for other racial abilities and feats. If a humanoid has a racial subtype, it is considered a member of that race in the case of race prerequisites." + System.Environment.NewLine + System.Environment.NewLine + "Humanoids breathe, eat, and sleep.", 0));
            Add(new CreatureType("Monstrous Humanoid", "Monstrous Humanoids", string.Empty, "Monstrous humanoids are similar to humanoids, but have monstrous or animalistic features. They often have magical abilities as well." + System.Environment.NewLine + System.Environment.NewLine + "Monstrous humanoids have the darkvision 60 feet racial trait" + System.Environment.NewLine + "Monstrous humanoids breathe, eat, and sleep.", 3));
            this["Monstrous Humanoid"].intrinsicTraits.Add(Globals.raceTraitDB["Darkvision 60 ft."]);
            Add(new CreatureType("Outsider (Native)", "outsiders", "Outsider", "Outsiders", "native", string.Empty, "A native outsider is at least partially composed of the essence (but not necessarily the matter) of some plane other than the Material Plane. Some creatures start out as some other type and become outsiders when they attain a higher (or lower) state of spiritual existence. When making a native outsider race, it is sometimes important to pick a single Outer Planes that race is tied to. For example, tieflings are tied to Abaddon, the Abyss, or Hell. Such ties can be important for qualifying for other racial abilities, but it's not required that a native outsider be tied to another plane. A native outsider race has the followings features." + System.Environment.NewLine + System.Environment.NewLine + "Native outsiders have the darkvision 60 feet racial trait." + System.Environment.NewLine + "Native outsiders breathe, eat, and sleep.", 3));
            this["Outsider (Native)"].intrinsicTraits.Add(Globals.raceTraitDB["Darkvision 60 ft."]);
            Add(new CreatureType("Plant", "plants", string.Empty, "This type encompasses humanoid-shaped vegetable creatures. Note that regular plants, such as those found in ordinary gardens and fields, lack Wisdom and Charisma scores and are not creatures, but objects, even though they are alive." + System.Environment.NewLine + System.Environment.NewLine + "Plants have the low-light vision racial trait." + System.Environment.NewLine + "Plants are immune to all mind-affecting effects (charms, compulsions, morale effects, patterns, and phantasms)." + System.Environment.NewLine +  "Plants are immune to paralysis, poison, polymorph, sleep effects, and stunning." + System.Environment.NewLine + "Plants breathe and eat, but do not sleep, unless they want to gain some beneficial effect from this activity. This means that a plant creature can sleep in order to regain spells, but sleep is not required to survive or stay in good health.", 10));
            this["Plant"].intrinsicTraits.Add(Globals.raceTraitDB["Low-Light Vision"]);
            Add(new CreatureType("Undead", "undead", string.Empty, "Undead races are once-living creatures animated by spiritual or supernatural forces." + System.Environment.NewLine + System.Environment.NewLine + "Undead have no Constitution score. Undead use their Charisma score in place of their Constitution score when calculating hit points, Fortitude saves, and any special ability that relies on Constitution (such as when calculating a breath weapon's DC)." + System.Environment.NewLine + "Undead have the darkvision 60 feet racial trait." + System.Environment.NewLine + "Undead are immune to all mind-affecting effects (charms, compulsions, morale effects, patterns, and phantasms)." + System.Environment.NewLine + "Undead are immune to bleed damage, death effects, disease, paralysis, poison, sleep effects, and stunning." + System.Environment.NewLine + "Undead are not subject to nonlethal damage, ability drain, or energy drain, and are immune to damage to physical ability scores (Constitution, Dexterity, and Strength), as well as to exhaustion and fatigue effects." + System.Environment.NewLine + "Undead are harmed by positive energy and healed by negative energy. An undead creature with the fast healing special quality still benefits from that quality." + System.Environment.NewLine + "Undead are immune to any effect that requires a Fortitude save (unless the effect also works on objects or is harmless)." + System.Environment.NewLine + "Undead do not risk death from massive damage, but are immediately destroyed when reduced to 0 hit points or fewer." + System.Environment.NewLine + "Undead are not affected by raise dead and reincarnate spells or abilities. Resurrection and true resurrection can affect undead creatures. These spells turn undead creatures back into the living creatures they were before becoming undead." + System.Environment.NewLine + "Undead do not breathe, eat, or sleep, unless they want to gain some beneficial effect from one of these activities. This means that an undead creature can drink potions to benefit from their effects and can sleep in order to regain spells, but neither of these activities is required to survive or stay in good health.", 16));
            this["Undead"].intrinsicTraits.Add(Globals.raceTraitDB["Darkvision 60 ft."]);
        }

        public void Add(CreatureType addMe)
        {
            Add(addMe.name, addMe);
        }
    }
}
