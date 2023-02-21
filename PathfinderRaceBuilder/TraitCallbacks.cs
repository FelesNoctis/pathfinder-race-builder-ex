using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using PathfinderSystem;

namespace PathfinderRaceBuilder
{
    public static class TraitCallbacks
    {
        public static void SetCallbacks()
        {
            foreach (RacialTrait curTrait in Globals.raceTraitDB.Values)
            {
                if (curTrait is BreathWeaponTrait)
                    curTrait.settingsFunction = ChooseBreathWeaponType;
                else if (curTrait is EnergyTypeTrait)
                    curTrait.settingsFunction = ChooseEnergyType;
                else if (curTrait is FavoredTerrainTrait)
                    curTrait.settingsFunction = ChooseFavoredTerrain;
                else if (curTrait is GenericSelectionTrait)
                    curTrait.settingsFunction = ChooseGenericOption;
                else if (curTrait is HatredTrait)
                    curTrait.settingsFunction = ChooseHatredOptions;
                else if (curTrait is SkillBonusTrait)
                    curTrait.settingsFunction = ChooseSkillBonusSkills;
                else if (curTrait is SkillTrainingTrait)
                    curTrait.settingsFunction = ChooseSkillTraingingSkills;
                else if (curTrait is SpellLikeAbilityTrait)
                    curTrait.settingsFunction = ChooseSpellLikeAbility;
                else if (curTrait is BonusFeatTrait)
                    curTrait.settingsFunction = ChooseStaticBonusFeat;
                else if (curTrait is WeaponFamiliarityTrait)
                    curTrait.settingsFunction = ChooseWeaponFamiliarityWeapons;
            }
        }

        public static bool ChooseBreathWeaponType(RacialTrait trait, int ranks, ref string[] info)
        {
            bool changed = false;
            BreathWeaponRacialTraitForm traitForm = new BreathWeaponRacialTraitForm();
            traitForm.SetSelections(ranks, info);

            if (traitForm.ShowDialog() == DialogResult.OK)
            {
                for (int i = 0; i < trait.repeatLimit; i++)
                    changed |= SetValue(ref info[i], traitForm.GetSelection(i));
            }

            return changed;
        }

        public static bool ChooseEnergyType(RacialTrait trait, int ranks, ref string[] info)
        {
            bool changed = false;

            if (trait.repeatLimit < 2)
            {
                GenericSingleItemSelectionForm traitForm = new GenericSingleItemSelectionForm();

                if (trait.name == "Elemental Summoner")
                    traitForm.Setup(trait.name + " Settings", EnergyTypeTrait.planarOptions);
                else
                    traitForm.Setup(trait.name + " Settings", Enum.GetNames(typeof(Globals.EnergyTypes)));

                traitForm.SetSelection(info[0]);

                if (traitForm.ShowDialog() == DialogResult.OK)
                    changed |= SetValue(ref info[0], traitForm.GetSelection());
            }
            else
            {
                EnergyTypeMultipleRacialTraitForm traitForm = new EnergyTypeMultipleRacialTraitForm();
                traitForm.Text = trait.name + " Settings";
                traitForm.SetSelections(ranks, info);

                if (traitForm.ShowDialog() == DialogResult.OK)
                {
                    for (int i = 0; i < ranks; i++)
                        changed |= SetValue(ref info[i], traitForm.GetSelection(i));
                }
            }

            return changed;
        }

        public static bool ChooseFavoredTerrain(RacialTrait trait, int ranks, ref string[] info)
        {
            FavoredTerrainRacialTraitForm traitForm = new FavoredTerrainRacialTraitForm();
            traitForm.Text = trait.name + " Settings";
            traitForm.SetSelection(info[0]);

            if (traitForm.ShowDialog() == DialogResult.OK)
                return SetValue(ref info[0], traitForm.GetSelection());
            else
                return false;
        }

        public static bool ChooseGenericOption(RacialTrait trait, int ranks, ref string[] info)
        {
            GenericSingleItemSelectionForm traitForm = new GenericSingleItemSelectionForm();
            traitForm.Setup(trait.name + " Settings", ((GenericSelectionTrait)trait).options);
            traitForm.SetSelection(info[0]);

            if (traitForm.ShowDialog() == DialogResult.OK)
                return SetValue(ref info[0], traitForm.GetSelection());
            else
                return false;
        }

        public static bool ChooseHatredOptions(RacialTrait trait, int ranks, ref string[] info)
        {
            HatredRacialTraitForm traitForm = new HatredRacialTraitForm();
            traitForm.Text = trait.name + " Settings";
            traitForm.SetSelection(info[0]);

            if (traitForm.ShowDialog() == DialogResult.OK)
                return SetValue(ref info[0], traitForm.GetSelection());
            else
                return false;
        }

        public static bool ChooseSkillBonusSkills(RacialTrait trait, int ranks, ref string[] info)
        {
            bool changed = false;
            SkillBonusRacialTraitForm skillForm = new SkillBonusRacialTraitForm();
            skillForm.SetSelections(ranks, info);

            if (skillForm.ShowDialog() == DialogResult.OK)
            {
                for (int i = 0; i < ranks; i++)
                    changed |= SetValue(ref info[i], skillForm.GetSelectionString(i));
            }

            return changed;
        }

        public static bool ChooseSkillTraingingSkills(RacialTrait trait, int ranks, ref string[] info)
        {
            SkillTrainingRacialTraitForm skillForm = new SkillTrainingRacialTraitForm();
            skillForm.SetSelections(info[0]);

            if (skillForm.ShowDialog() == DialogResult.OK)
                return SetValue(ref info[0], skillForm.GetSelections());
            else
                return false;
        }

        public static bool ChooseSpellLikeAbility(RacialTrait trait, int ranks, ref string[] info)
        {
            bool changed = false;
            SpellLikeAbilitySelectionForm spellForm = new SpellLikeAbilitySelectionForm();
            spellForm.Text = trait.name + " Settings";
            spellForm.SetSelections(((SpellLikeAbilityTrait)trait).minLevel, ((SpellLikeAbilityTrait)trait).maxLevel, ranks, info);

            if (spellForm.ShowDialog() == DialogResult.OK)
            {
                for (int i = 0; i < ranks; i++)
                    changed |= SetValue(ref info[i], spellForm.GetSelection(i));
            }

            return changed;
        }

        public static bool ChooseStaticBonusFeat(RacialTrait trait, int ranks, ref string[] info)
        {
            BonusFeatRacialTraitForm featForm = new BonusFeatRacialTraitForm();
            featForm.cbxFeatName.SelectedItem = info[0];

            if (featForm.ShowDialog() == DialogResult.OK)
                return SetValue(ref info[0], featForm.cbxFeatName.Text);
            else
                return false;
        }

        public static bool ChooseWeaponFamiliarityWeapons(RacialTrait trait, int ranks, ref string[] info)
        {
            bool changed = false;
            WeaponFamiliarityRacialTraitForm weaponForm = new WeaponFamiliarityRacialTraitForm();
            weaponForm.SetSelections(ranks, info);

            if (weaponForm.ShowDialog() == DialogResult.OK)
            {
                for (int i = 0; i < ranks; i++)
                    changed |= SetValue(ref info[i], weaponForm.GetSelections(i));
            }

            return changed;
        }

        private static bool SetValue(ref string input, string value)
        {
            if (input != value)
            {
                input = value;
                return true;
            }
            else
                return false;
        }
    }
}
