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
            //listingStandard.CheckboxLabeled("Aarakocra", ref settings.raceToggle_aarakocra, "Enables/Disables the Aarakocra race.");
            //listingStandard.CheckboxLabeled("Aasimar", ref settings.raceToggle_aasimar, "Enables/Disables the Aasimar race.");
            //listingStandard.CheckboxLabeled("Alaghi", ref settings.raceToggle_alaghi, "Enables/Disables the Alaghi race.");
            //listingStandard.CheckboxLabeled("Bullywug", ref settings.raceToggle_bullywug, "Enables/Disables the Bullywug race.");
            //listingStandard.CheckboxLabeled("Chitine", ref settings.raceToggle_chitine, "Enables/Disables the Chitine race.");
            //listingStandard.CheckboxLabeled("Dragonborn", ref settings.raceToggle_dragonborn, "Enables/Disables the Dragonborn race.");
            listingStandard.CheckboxLabeled("Dwarf", ref settings.raceToggle_dwarf, "Enables/Disables the Dwarf race.");
            //listingStandard.CheckboxLabeled("Elan", ref settings.raceToggle_elan, "Enables/Disables the Elan race.");
            listingStandard.CheckboxLabeled("Elves", ref settings.raceToggle_elf, "Enables/Disables the Elven races (Dark Elf, Moon Elf, Sun Elf and Wood Elf are all rolled into this setting).");
            //listingStandard.CheckboxLabeled("Firbolg", ref settings.raceToggle_firbolg, "Enables/Disables the Firbolg race.");
            //listingStandard.CheckboxLabeled("Genasi", ref settings.raceToggle_genasi, "Enables/Disables the Genasi races (Several elemental variations of the same race).");
            listingStandard.CheckboxLabeled("Gith", ref settings.raceToggle_gith, "Enables/Disables the Gith race.");
            //listingStandard.CheckboxLabeled("Gnoll", ref settings.raceToggle_gnoll, "Enables/Disables the Gnoll race.");
            listingStandard.CheckboxLabeled("Goblins", ref settings.raceToggle_goblin, "Enables/Disables the Goblins race.");
            //listingStandard.CheckboxLabeled("Goliath", ref settings.raceToggle_goliath, "Enables/Disables the Goliath race.");
            //listingStandard.CheckboxLabeled("Grung", ref settings.raceToggle_grung, "Enables/Disables the Grung race.");
            listingStandard.CheckboxLabeled("Half-Orcs", ref settings.raceToggle_halforc, "Enables/Disables this Half-Orc race.");
            //listingStandard.CheckboxLabeled("Halfling", ref settings.raceToggle_halfling, "Enables/Disables the Halfling race.");
            //listingStandard.CheckboxLabeled("Harssaf", ref settings.raceToggle_harssaf, "Enables/Disables the Harssaf race.");
            listingStandard.CheckboxLabeled("Hobgoblins", ref settings.raceToggle_hobgoblin, "Enables/Disables the Hobgoblin race.");
            listingStandard.CheckboxLabeled("Illithids", ref settings.raceToggle_illithid, "Enables/Disables the Illithid race.");
            //listingStandard.CheckboxLabeled("Koalinth", ref settings.raceToggle_koalinth, "Enables/Disables the Koalinth race.");
            listingStandard.CheckboxLabeled("Killoren", ref settings.raceToggle_killoren, "Enables/Disables the Killoren race.");
            listingStandard.CheckboxLabeled("Kobolds", ref settings.raceToggle_kobold, "Enables/Disables the Kobold race.");
            //listingStandard.CheckboxLabeled("Krinth", ref settings.raceToggle_krinth, "Enables/Disables the Krinth race.");
            //listingStandard.CheckboxLabeled("Kua-toa", ref settings.raceToggle_kuatoa, "Enables/Disables the Kua-toa race.");
            //listingStandard.CheckboxLabeled("Locathah", ref settings.raceToggle_locathah, "Enables/Disables the Locathah race.");
            listingStandard.CheckboxLabeled("Orcs", ref settings.raceToggle_orc, "Enables/Disables the Orc race.");
            //listingStandard.CheckboxLabeled("Satyr", ref settings.raceToggle_satyr, "Enables/Disables the Satyr race.");
            //listingStandard.CheckboxLabeled("Shadar-kai", ref settings.raceToggle_shadarkai, "Enables/Disables the Shadar-kai race.");
            listingStandard.CheckboxLabeled("Tabaxi", ref settings.raceToggle_tabaxi, "Enables/Disables the Tabaxi race.");
            listingStandard.CheckboxLabeled("Tieflings", ref settings.raceToggle_tiefling, "Enables/Disables the Tiefling race.");
            listingStandard.CheckboxLabeled("Warforged", ref settings.raceToggle_warforged, "Enables/Disables the Warforged race.");
            //listingStandard.CheckboxLabeled("Yuan-ti", ref settings.raceToggle_yuanti, "Enables/Disables the Yuan-ti race.");
            //listingStandard.CheckboxLabeled("Yuan-ti Malison", ref settings.raceToggle_yuantimalison, "Enables/Disables the Yuan-ti Malison race.");
        }

        public void DoGeneralSettingsPage(Listing_Standard listingStandard, Rect inRect)
        {
            listingStandard.CheckboxEnhanced("Race Integration", "If enabled, all enabled races will have a chance of spawning among the vanilla factions. If this is disabled you'll have a hard time ever finding them.", ref settings.settingToggle_raceIntegration);

            listingStandard.NewColumn();

            //listingStandard.Label("Creatures");
            //listingStandard.GapLine();
            //listingStandard.CheckboxLabeled("Bullywugs", ref settings.creatureToggle_Bullywugs, "Spawn from water, in groups. It'll happen as an unnanounced event if the location they choose to emerge from isn't visible to a pawn or turret. Yes they'll be playable, shut up already.");
            //listingStandard.CheckboxLabeled("Darkmantles", ref settings.creatureToggle_Darkmantle, "Darkmantles will spawn from roof collapses (negating the roof collapse if it can as a silver lining) and attempt to trap and suffocate nearby pawns.");
            //listingStandard.CheckboxLabeled("Gelatinous Cubes", ref settings.creatureToggle_gelatinousCube, "You'll only really see these if the game decides to launch a 'Fuck you in particular' event at you. Gelatinous Cubes can only be harmed by fire, and will consume anything else they touch so...have fun with that.");
            //listingStandard.CheckboxLabeled("Rust Monsters", ref settings.creatureToggle_rustMonster, "Rust Monsters are a rare event creature, they will occasionally show up and begin devouring any metal they can find, even if that metal is already part of something like an item or structure.");
        }
    }

    public enum ForgottenRealmsSettingsPage
    {
        Races,
        Other
    }
}
