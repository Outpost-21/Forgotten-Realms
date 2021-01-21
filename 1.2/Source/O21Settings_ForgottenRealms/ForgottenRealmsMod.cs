using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UnityEngine;
using RimWorld;
using Verse;

using O21Toolbox;

namespace O21Settings_ForgottenRealms
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

        public override void DoSettingsWindowContents(Rect inRect)
        {
            float secondStageHeight;
            Listing_Standard listingStandard = new Listing_Standard();
            listingStandard.Begin(inRect);
            listingStandard.ValueLabeled("Settings Page", "Cycle this setting to change page. Changing settings requires a restart to take effect. You should NEVER disable any of these mid-save, it's the same as uninstalling that part of the mod and can have severe consequences, no support will be provided if you do this because there is nothing I can do, and yes I will know.", ref currentSettingsPage);
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
            listingStandard.CheckboxLabeled("Dwarves", ref settings.raceToggle_dwarf, "Enables/Disables Dwarves.");
            listingStandard.CheckboxLabeled("Dark Elves", ref settings.raceToggle_elfDark, "Enables/Disables Dark Elves");
            listingStandard.CheckboxLabeled("Moon Elves", ref settings.raceToggle_elfMoon, "Enables/Disables Moon Elves");
            listingStandard.CheckboxLabeled("Sun Elves", ref settings.raceToggle_elfSun, "Enables/Disables Sun Elves");
            listingStandard.CheckboxLabeled("Wood Elves", ref settings.raceToggle_elfWood, "Enables/Disables Wood Elves");
            listingStandard.CheckboxLabeled("Gith", ref settings.raceToggle_gith, "Enables/Disables Gith");
            listingStandard.CheckboxLabeled("Goblins", ref settings.raceToggle_goblin, "Enables/Disables Goblins");
            listingStandard.CheckboxLabeled("Half-Orcs", ref settings.raceToggle_halforc, "Enables/Disables Half-Orcs");
            listingStandard.CheckboxLabeled("Hobgoblins", ref settings.raceToggle_hobgoblin, "Enables/Disables Hobgoblins");
            listingStandard.CheckboxLabeled("Illithids", ref settings.raceToggle_illithid, "Enables/Disables Illithids");
            listingStandard.CheckboxLabeled("Kobolds", ref settings.raceToggle_kobold, "Enables/Disables Kobolds");
            listingStandard.CheckboxLabeled("Orcs", ref settings.raceToggle_orc, "Enables/Disables Orcs");
            listingStandard.CheckboxLabeled("Tieflings", ref settings.raceToggle_tiefling, "Enables/Disables Tieflings");
            listingStandard.CheckboxLabeled("Warforged", ref settings.raceToggle_warforged, "Enables/Disables Warforged");

            listingStandard.NewColumn();

            if (settings.raceToggle_dwarf) { listingStandard.CheckboxLabeled("Dwarves Faction", ref settings.factionToggle_dwarf, "Controls spawning of the NPC Dwarf Faction"); }
            if (settings.raceToggle_elfDark) { listingStandard.CheckboxLabeled("Dark Elves Faction", ref settings.factionToggle_elfDark, "Controls spawning of the NPC Dark Elf Faction"); }
            if (settings.raceToggle_elfMoon) { listingStandard.CheckboxLabeled("Moon Elves Faction", ref settings.factionToggle_elfMoon, "Controls spawning of the NPC Moon Elf Faction"); }
            if (settings.raceToggle_elfSun) { listingStandard.CheckboxLabeled("Sun Elves Faction", ref settings.factionToggle_elfSun, "Controls spawning of the NPC Sun Elf Faction"); }
            if (settings.raceToggle_elfWood) { listingStandard.CheckboxLabeled("Wood Elves Faction", ref settings.factionToggle_elfWood, "Controls spawning of the NPC Wood Elf Faction"); }
            if (settings.raceToggle_gith) { listingStandard.CheckboxLabeled("Gith Faction", ref settings.factionToggle_gith, "Controls spawning of the NPC Gith Faction"); }
            if (settings.raceToggle_goblin) { listingStandard.CheckboxLabeled("Goblins Faction", ref settings.factionToggle_goblin, "Controls spawning of the NPC Goblin Faction"); }
            if (settings.raceToggle_halforc) { listingStandard.CheckboxLabeled("Half-Orc Faction", ref settings.factionToggle_halforc, "Controls the spawning of the NPC Half-Orc Faction"); }
            if (settings.raceToggle_hobgoblin) { listingStandard.CheckboxLabeled("Hobgoblins Faction", ref settings.factionToggle_hobgoblin, "Controls spawning of the NPC Hobgoblin Faction"); }
            if (settings.raceToggle_illithid) { listingStandard.CheckboxLabeled("Illithids Faction", ref settings.factionToggle_illithid, "Controls spawning of the NPC Illithid Faction"); }
            if (settings.raceToggle_kobold) { listingStandard.CheckboxLabeled("Kobolds Faction", ref settings.factionToggle_kobold, "Controls spawning of the NPC Kobold Faction"); }
            if (settings.raceToggle_orc) { listingStandard.CheckboxLabeled("Orcs Faction", ref settings.factionToggle_orc, "Controls spawning of the NPC Orc Faction"); }
            if (settings.raceToggle_tiefling) { listingStandard.CheckboxLabeled("Tieflings Faction", ref settings.factionToggle_tiefling, "Controls spawning of the NPC Tiefling Faction"); }
            if (settings.raceToggle_warforged) { listingStandard.CheckboxLabeled("Warforged Faction", ref settings.factionToggle_warforged, "Controls spawning of the NPC Warforged Faction"); }
        }

        public void DoGeneralSettingsPage(Listing_Standard listingStandard, Rect inRect)
        {
            listingStandard.CheckboxEnhanced("Race Integration", "If enabled, all races will have a chance of spawning among the vanilla factions.", ref settings.settingToggle_raceIntegration);
            listingStandard.CheckboxEnhanced("Enable Scenarios", "If enabled, scenarios for each individual race will be included, this is not recommended as it will not take into account any changes made to vanilla scenarios by other mods. The proper way is to change the faction type in the scenario editor yourself.", ref settings.settingToggle_scenarios);

            listingStandard.NewColumn();

            //listingStandard.Label("Creatures");
            //listingStandard.GapLine();
            //listingStandard.CheckboxLabeled("Bullywugs", ref settings.creatureToggle_Bullywugs, "Spawn from water, in groups. It'll happen as an unnanounced event if the location they choose to emerge from isn't visible to a pawn or turret. Yes they'll be playable, shut up already.");
            //listingStandard.CheckboxLabeled("Darkmantles", ref settings.creatureToggle_Darkmantle, "Darkmantles will spawn from roof collapses (negating the roof collapse if it can as a silver lining) and attempt to trap and suffocate nearby pawns.");
            //listingStandard.CheckboxLabeled("Gelatinous Cubes", ref settings.creatureToggle_gelatinousCube, "You'll only really see these if the game decides to launch a 'Fuck you in particular' event at you. Gelatinous Cubes can only be harmed by fire, and will consume anything else they touch so...have fun with that.");
            //listingStandard.CheckboxLabeled("Rust Monsters", ref settings.creatureToggle_rustMonster, "Rust Monsters are a rare event creature, they will occasionally show up and begin devouring any metal they can find, even if that metal is already part of something like an item or structure.");
        }

        public override string SettingsCategory()
        {
            return "Forgotten Realms";
        }
    }

    public enum ForgottenRealmsSettingsPage
    {
        Races,
        Other
    }
}
