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
        // Other
        public bool settingToggle_raceIntegration = true;
        public bool settingToggle_scenarios = true;

        // Creatures
        public bool creatureToggle_rustMonster = true;
        public bool creatureToggle_gelatinousCube = true;
        public bool creatureToggle_Bullywugs = true;
        public bool creatureToggle_Darkmantle = true;

        // Races
        public bool raceToggle_aarakocra = true;
        public bool raceToggle_aasimar = true;
        public bool raceToggle_alaghi = true;
        public bool raceToggle_bullywug = true;
        public bool raceToggle_chitine = true;
        public bool raceToggle_dragonborn = true;
        public bool raceToggle_dwarf = true;
        public bool raceToggle_elan = true;
        public bool raceToggle_elf = true;
        public bool raceToggle_firbolg = true;
        public bool raceToggle_genasi = true;
        public bool raceToggle_gith = true;
        public bool raceToggle_gnoll = true;
        public bool raceToggle_goblin = true;
        public bool raceToggle_goliath = true;
        public bool raceToggle_grung = true;
        public bool raceToggle_halforc = true;
        public bool raceToggle_halfling = true;
        public bool raceToggle_harssaf = true;
        public bool raceToggle_hobgoblin = true;
        public bool raceToggle_illithid = true;
        public bool raceToggle_koalinth = true;
        public bool raceToggle_killoren = true;
        public bool raceToggle_kobold = true;
        public bool raceToggle_krinth = true;
        public bool raceToggle_kuatoa = true;
        public bool raceToggle_locathah = true;
        public bool raceToggle_orc = true;
        public bool raceToggle_satyr = true;
        public bool raceToggle_shadarkai = true;
        public bool raceToggle_tabaxi = true;
        public bool raceToggle_tiefling = true;
        public bool raceToggle_warforged = true;
        public bool raceToggle_yuanti = true;
        public bool raceToggle_yuantimalison = true;

        public override void ExposeData()
        {
            base.ExposeData();
            // Other
            Scribe_Values.Look(ref settingToggle_raceIntegration, "settingToggle_raceIntegration", true);
            Scribe_Values.Look(ref settingToggle_scenarios, "settingToggle_scenarios", true);

            // Creatures
            Scribe_Values.Look(ref creatureToggle_rustMonster, "creatureToggle_rustMonster", true);
            Scribe_Values.Look(ref creatureToggle_gelatinousCube, "creatureToggle_gelatinousCube", true);
            Scribe_Values.Look(ref creatureToggle_Bullywugs, "creatureToggle_Bullywugs", true);
            Scribe_Values.Look(ref creatureToggle_Darkmantle, "creatureToggle_Darkmantle", true);

            //Races
            Scribe_Values.Look(ref raceToggle_aarakocra, "raceToggle_aarakocra", true);
            Scribe_Values.Look(ref raceToggle_aasimar, "raceToggle_aasimar", true);
            Scribe_Values.Look(ref raceToggle_alaghi, "raceToggle_alaghi", true);
            Scribe_Values.Look(ref raceToggle_bullywug, "raceToggle_bullywug", true);
            Scribe_Values.Look(ref raceToggle_chitine, "raceToggle_chitine", true);
            Scribe_Values.Look(ref raceToggle_dragonborn, "raceToggle_dragonborn", true);
            Scribe_Values.Look(ref raceToggle_dwarf, "raceToggle_dwarf", true);
            Scribe_Values.Look(ref raceToggle_elan, "raceToggle_elan", true);
            Scribe_Values.Look(ref raceToggle_elf, "raceToggle_elf", true);
            Scribe_Values.Look(ref raceToggle_genasi, "raceToggle_genasi", true);
            Scribe_Values.Look(ref raceToggle_gith, "raceToggle_gith", true);
            Scribe_Values.Look(ref raceToggle_gnoll, "raceToggle_gnoll", true);
            Scribe_Values.Look(ref raceToggle_goblin, "raceToggle_goblin", true);
            Scribe_Values.Look(ref raceToggle_goliath, "raceToggle_goliath", true);
            Scribe_Values.Look(ref raceToggle_grung, "raceToggle_grung", true);
            Scribe_Values.Look(ref raceToggle_firbolg, "raceToggle_firbolg", true);
            Scribe_Values.Look(ref raceToggle_halforc, "raceToggle_halforc", true);
            Scribe_Values.Look(ref raceToggle_halfling, "raceToggle_halfling", true);
            Scribe_Values.Look(ref raceToggle_harssaf, "raceToggle_harssaf", true);
            Scribe_Values.Look(ref raceToggle_hobgoblin, "raceToggle_hobgoblin", true);
            Scribe_Values.Look(ref raceToggle_illithid, "raceToggle_illithid", true);
            Scribe_Values.Look(ref raceToggle_koalinth, "raceToggle_koalinth", true);
            Scribe_Values.Look(ref raceToggle_killoren, "raceToggle_killoren", true);
            Scribe_Values.Look(ref raceToggle_kobold, "raceToggle_kobold", true);
            Scribe_Values.Look(ref raceToggle_krinth, "raceToggle_krinth", true);
            Scribe_Values.Look(ref raceToggle_kuatoa, "raceToggle_kuatoa", true);
            Scribe_Values.Look(ref raceToggle_locathah, "raceToggle_locathah", true);
            Scribe_Values.Look(ref raceToggle_orc, "raceToggle_orc", true);
            Scribe_Values.Look(ref raceToggle_satyr, "raceToggle_satyr", true);
            Scribe_Values.Look(ref raceToggle_shadarkai, "raceToggle_shadarkai", true);
            Scribe_Values.Look(ref raceToggle_tabaxi, "raceToggle_tabaxi", true);
            Scribe_Values.Look(ref raceToggle_tiefling, "raceToggle_tiefling", true);
            Scribe_Values.Look(ref raceToggle_warforged, "raceToggle_warforged", true);
            Scribe_Values.Look(ref raceToggle_yuanti, "raceToggle_yuanti", true);
            Scribe_Values.Look(ref raceToggle_yuantimalison, "raceToggle_yuantimalison", true);
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
