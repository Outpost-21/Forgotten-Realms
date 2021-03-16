using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UnityEngine;
using RimWorld;
using Verse;

namespace O21Settings_ForgottenRealms
{
    public class ForgottenRealmsSettings : ModSettings
    {
        public string lastLoadedVersion = "0.0.0";

        // Other
        public bool settingToggle_raceIntegration = true;
        public bool settingToggle_scenarios = true;

        // Creatures
        public bool creatureToggle_rustMonster = true;
        public bool creatureToggle_gelatinousCube = true;
        public bool creatureToggle_Bullywugs = true;
        public bool creatureToggle_Darkmantle = true;

        // Races
        public bool raceToggle_elfDark = true;
        public bool raceToggle_elfMoon = true;
        public bool raceToggle_elfSun = true;
        public bool raceToggle_elfWood = true;

        public bool raceToggle_dwarf = true;
        public bool raceToggle_gith = true;
        public bool raceToggle_goblin = true;
        public bool raceToggle_halforc = true;
        public bool raceToggle_hobgoblin = true;
        public bool raceToggle_illithid = true;
        public bool raceToggle_killoren = true;
        public bool raceToggle_kobold = true;
        public bool raceToggle_orc = true;
        public bool raceToggle_tabaxi = true;
        public bool raceToggle_tiefling = true;
        public bool raceToggle_warforged = true;

        // Factions
        public bool factionToggle_elfDark = true;
        public bool factionToggle_elfMoon = true;
        public bool factionToggle_elfSun = true;
        public bool factionToggle_elfWood = true;

        public bool factionToggle_dwarf = true;
        public bool factionToggle_gith = true;
        public bool factionToggle_goblin = true;
        public bool factionToggle_halforc = true;
        public bool factionToggle_hobgoblin = true;
        public bool factionToggle_illithid = true;
        public bool factionToggle_killoren = true;
        public bool factionToggle_kobold = true;
        public bool factionToggle_orc = true;
        public bool factionToggle_tabaxi = true;
        public bool factionToggle_tiefling = true;
        public bool factionToggle_warforged = true;

        // Legacy Toggles, ignored entirely.
        public bool faction_elfDark = true;
        public bool faction_elfMoon = true;
        public bool faction_elfSun = true;
        public bool faction_elfWood = true;

        public bool faction_dwarf = true;
        public bool faction_gith = true;
        public bool faction_goblin = true;
        public bool faction_hobgoblin = true;
        public bool faction_illithid = true;
        public bool faction_kobold = true;
        public bool faction_orc = true;
        public bool faction_tiefling = true;
        public bool faction_warforged = true;

        public override void ExposeData()
        {
            base.ExposeData();
            Scribe_Values.Look(ref lastLoadedVersion, "lastLoadedVersion", "0.0.0");
            // Other
            Scribe_Values.Look(ref settingToggle_raceIntegration, "settingToggle_raceIntegration", true);
            Scribe_Values.Look(ref settingToggle_scenarios, "settingToggle_scenarios", true);

            // Creatures
            Scribe_Values.Look(ref creatureToggle_rustMonster, "creatureToggle_rustMonster", true);
            Scribe_Values.Look(ref creatureToggle_gelatinousCube, "creatureToggle_gelatinousCube", true);
            Scribe_Values.Look(ref creatureToggle_Bullywugs, "creatureToggle_Bullywugs", true);
            Scribe_Values.Look(ref creatureToggle_Darkmantle, "creatureToggle_Darkmantle", true);

            //Races
            Scribe_Values.Look(ref raceToggle_elfDark, "raceToggle_elfDark", true);
            Scribe_Values.Look(ref raceToggle_elfMoon, "raceToggle_elfMoon", true);
            Scribe_Values.Look(ref raceToggle_elfSun, "raceToggle_elfSun", true);
            Scribe_Values.Look(ref raceToggle_elfWood, "raceToggle_elfWood", true);

            Scribe_Values.Look(ref raceToggle_dwarf, "raceToggle_dwarf", true);
            Scribe_Values.Look(ref raceToggle_gith, "raceToggle_gith", true);
            Scribe_Values.Look(ref raceToggle_goblin, "raceToggle_goblin", true);
            Scribe_Values.Look(ref raceToggle_halforc, "raceToggle_halforc", true);
            Scribe_Values.Look(ref raceToggle_hobgoblin, "raceToggle_hobgoblin", true);
            Scribe_Values.Look(ref raceToggle_illithid, "raceToggle_illithid", true);
            Scribe_Values.Look(ref raceToggle_killoren, "raceToggle_killoren", true);
            Scribe_Values.Look(ref raceToggle_kobold, "raceToggle_kobold", true);
            Scribe_Values.Look(ref raceToggle_orc, "raceToggle_orc", true);
            Scribe_Values.Look(ref raceToggle_tabaxi, "raceToggle_tabaxi", true);
            Scribe_Values.Look(ref raceToggle_tiefling, "raceToggle_tiefling", true);
            Scribe_Values.Look(ref raceToggle_warforged, "raceToggle_warforged", true);
            // Factions
            Scribe_Values.Look(ref factionToggle_elfDark, "factionToggle_elfDark", true);
            Scribe_Values.Look(ref factionToggle_elfMoon, "factionToggle_elfMoon", true);
            Scribe_Values.Look(ref factionToggle_elfSun, "factionToggle_elfSun", true);
            Scribe_Values.Look(ref factionToggle_elfWood, "factionToggle_elfWood", true);

            Scribe_Values.Look(ref factionToggle_dwarf, "factionToggle_dwarf", true);
            Scribe_Values.Look(ref factionToggle_gith, "factionToggle_gith", true);
            Scribe_Values.Look(ref factionToggle_goblin, "factionToggle_goblin", true);
            Scribe_Values.Look(ref factionToggle_halforc, "factionToggle_halforc", true);
            Scribe_Values.Look(ref factionToggle_hobgoblin, "factionToggle_hobgoblin", true);
            Scribe_Values.Look(ref factionToggle_illithid, "factionToggle_illithid", true);
            Scribe_Values.Look(ref factionToggle_killoren, "factionToggle_killoren", true);
            Scribe_Values.Look(ref factionToggle_kobold, "factionToggle_kobold", true);
            Scribe_Values.Look(ref factionToggle_orc, "factionToggle_orc", true);
            Scribe_Values.Look(ref factionToggle_tabaxi, "factionToggle_tabaxi", true);
            Scribe_Values.Look(ref factionToggle_tiefling, "factionToggle_tiefling", true);
            Scribe_Values.Look(ref factionToggle_warforged, "factionToggle_warforged", true);

            // Legacy Toggles, ignored entirely.
            Scribe_Values.Look(ref faction_elfDark, "faction_elfDark", true);
            Scribe_Values.Look(ref faction_elfMoon, "faction_elfMoon", true);
            Scribe_Values.Look(ref faction_elfSun, "faction_elfSun", true);
            Scribe_Values.Look(ref faction_elfWood, "faction_elfWood", true);

            Scribe_Values.Look(ref faction_dwarf, "faction_dwarf", true);
            Scribe_Values.Look(ref faction_gith, "faction_gith", true);
            Scribe_Values.Look(ref faction_goblin, "faction_goblin", true);
            Scribe_Values.Look(ref faction_hobgoblin, "faction_hobgoblin", true);
            Scribe_Values.Look(ref faction_illithid, "faction_illithid", true);
            Scribe_Values.Look(ref faction_kobold, "faction_kobold", true);
            Scribe_Values.Look(ref faction_orc, "faction_orc", true);
            Scribe_Values.Look(ref faction_tiefling, "faction_tiefling", true);
            Scribe_Values.Look(ref faction_warforged, "faction_warforged", true);
        }

        public IEnumerable<string> GetEnabledSettings
        {
            get
            {
                return GetType().GetFields().Where(p => p.FieldType == typeof(bool) && (bool)p.GetValue(this)).Select(p => p.Name);
            }
        }
    }
}
