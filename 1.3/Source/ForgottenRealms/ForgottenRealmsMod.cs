using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UnityEngine;
using RimWorld;
using Verse;

using O21Toolbox;

namespace ForgottenRealms
{
    public class ForgottenRealmsMod : Mod
    {
        public static ForgottenRealmsSettings settings;
        public static ForgottenRealmsMod mod;

        public ForgottenRealmsSettingsPage currentSettingsPage;

        public ForgottenRealmsMod(ModContentPack content) : base(content)
        {
            settings = GetSettings<ForgottenRealmsSettings>();
            mod = this;
            Log.Message("O21 :: Forgotten Realms Initialised :: 3.2.0 [Final]");
        }

        public override string SettingsCategory()
        {
            return "Forgotten Realms";
        }

        public override void DoSettingsWindowContents(Rect inRect)
        {
            float secondStageHeight;
            Listing_Standard listingStandard = new Listing_Standard();
            listingStandard.Begin(inRect);
            listingStandard.ValueLabeled("Settings Page", "Cycle this setting to change page. Changing settings requires a restart to take effect. You should NEVER disable any of these mid-save, it's the same as disabling a mod if you disable something, however enabling them should be fine.", ref currentSettingsPage);
            listingStandard.GapLine();
            listingStandard.Gap(48);
            secondStageHeight = listingStandard.CurHeight;
            listingStandard.End();

            listingStandard = new Listing_Standard
            {
                ColumnWidth = (inRect.width - 30f) / 2f - 2f
            };
            inRect.yMin = secondStageHeight;
            listingStandard.Begin(inRect);

            if (currentSettingsPage == ForgottenRealmsSettingsPage.Races)
            {
                DoRaceSettingsPage(listingStandard, inRect);
            }
            if (currentSettingsPage == ForgottenRealmsSettingsPage.Other)
            {
                DoGeneralSettingsPage(listingStandard, inRect);
            }

            listingStandard.End();
            base.DoSettingsWindowContents(inRect);
        }

        public void DoRaceSettingsPage(Listing_Standard listingStandard, Rect inRect)
        {
            listingStandard.CheckboxLabeled("Chitine", ref settings.raceToggle_chitine, "Enables/Disables the Chitine race.");
            listingStandard.CheckboxLabeled("Dwarf", ref settings.raceToggle_dwarf, "Enables/Disables the Dwarf race.");
            listingStandard.CheckboxLabeled("Elves", ref settings.raceToggle_elf, "Enables/Disables the Elven races (Dark Elf, Moon Elf, Sun Elf and Wood Elf are all rolled into this setting).");
            listingStandard.CheckboxLabeled("Firbolg", ref settings.raceToggle_firbolg, "Enables/Disables the Firbolg race.");
            listingStandard.CheckboxLabeled("Gith", ref settings.raceToggle_gith, "Enables/Disables the Gith race.");
            listingStandard.CheckboxLabeled("Goblins", ref settings.raceToggle_goblin, "Enables/Disables the Goblins race.");
            listingStandard.CheckboxLabeled("Half-Orcs", ref settings.raceToggle_halforc, "Enables/Disables this Half-Orc race.");
            listingStandard.CheckboxLabeled("Halfling", ref settings.raceToggle_halfling, "Enables/Disables the Halfling race.");
            listingStandard.CheckboxLabeled("Hobgoblins", ref settings.raceToggle_hobgoblin, "Enables/Disables the Hobgoblin race.");
            listingStandard.CheckboxLabeled("Illithids", ref settings.raceToggle_illithid, "Enables/Disables the Illithid race.");
            listingStandard.CheckboxLabeled("Killoren", ref settings.raceToggle_killoren, "Enables/Disables the Killoren race.");
            listingStandard.CheckboxLabeled("Kobolds", ref settings.raceToggle_kobold, "Enables/Disables the Kobold race.");
            listingStandard.CheckboxLabeled("Orcs", ref settings.raceToggle_orc, "Enables/Disables the Orc race.");
            listingStandard.CheckboxLabeled("Tabaxi", ref settings.raceToggle_tabaxi, "Enables/Disables the Tabaxi race.");
            listingStandard.CheckboxLabeled("Tieflings", ref settings.raceToggle_tiefling, "Enables/Disables the Tiefling race.");
            listingStandard.CheckboxLabeled("Warforged", ref settings.raceToggle_warforged, "Enables/Disables the Warforged race.");
        }

        public void DoGeneralSettingsPage(Listing_Standard listingStandard, Rect inRect)
        {
            listingStandard.CheckboxEnhanced("Race Integration", "If enabled, all enabled races will have a chance of spawning among the vanilla factions. If this is disabled you'll have a hard time ever finding them.", ref settings.settingToggle_raceIntegration);
        }
    }

    public enum ForgottenRealmsSettingsPage
    {
        Races,
        Other
    }
}
