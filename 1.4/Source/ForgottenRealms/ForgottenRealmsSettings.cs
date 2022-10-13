using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UnityEngine;
using RimWorld;
using Verse;

namespace ForgottenRealms
{
    public class ForgottenRealmsSettings : ModSettings
    {
        public bool verboseLogging = false;

        // Other
        public bool settingToggle_raceIntegration = true;
        public bool settingToggle_scenarios = true;

        // Races
        public bool raceToggle_chitine = true;
        public bool raceToggle_dwarf = true;
        public bool raceToggle_elf = true;
        public bool raceToggle_firbolg = true;
        public bool raceToggle_gith = true;
        public bool raceToggle_goblin = true;
        public bool raceToggle_halforc = true;
        public bool raceToggle_halfling = true;
        public bool raceToggle_hobgoblin = true;
        public bool raceToggle_illithid = true;
        public bool raceToggle_killoren = true;
        public bool raceToggle_kobold = true;
        public bool raceToggle_orc = true;
        public bool raceToggle_tabaxi = true;
        public bool raceToggle_tiefling = true;
        public bool raceToggle_warforged = true;

        public override void ExposeData()
        {
            base.ExposeData();
            //Races
            Scribe_Values.Look(ref raceToggle_chitine, "raceToggle_chitine", true);
            Scribe_Values.Look(ref raceToggle_dwarf, "raceToggle_dwarf", true);
            Scribe_Values.Look(ref raceToggle_elf, "raceToggle_elf", true);
            Scribe_Values.Look(ref raceToggle_gith, "raceToggle_gith", true);
            Scribe_Values.Look(ref raceToggle_goblin, "raceToggle_goblin", true);
            Scribe_Values.Look(ref raceToggle_firbolg, "raceToggle_firbolg", true);
            Scribe_Values.Look(ref raceToggle_halforc, "raceToggle_halforc", true);
            Scribe_Values.Look(ref raceToggle_halfling, "raceToggle_halfling", true);
            Scribe_Values.Look(ref raceToggle_hobgoblin, "raceToggle_hobgoblin", true);
            Scribe_Values.Look(ref raceToggle_illithid, "raceToggle_illithid", true);
            Scribe_Values.Look(ref raceToggle_killoren, "raceToggle_killoren", true);
            Scribe_Values.Look(ref raceToggle_kobold, "raceToggle_kobold", true);
            Scribe_Values.Look(ref raceToggle_orc, "raceToggle_orc", true);
            Scribe_Values.Look(ref raceToggle_tabaxi, "raceToggle_tabaxi", true);
            Scribe_Values.Look(ref raceToggle_tiefling, "raceToggle_tiefling", true);
            Scribe_Values.Look(ref raceToggle_warforged, "raceToggle_warforged", true);
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
