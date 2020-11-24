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
    [StaticConstructorOnStartup]
    public static class FactionControl
    {
        static FactionControl()
        {
            ForgottenRealmsSettings settings = ForgottenRealmsMod.settings;

            if (!settings.raceToggle_dwarf)
            {
                settings.factionToggle_dwarf = false;
            }
            if (!settings.raceToggle_elfDark)
            {
                settings.factionToggle_elfDark = false;
            }
            if (!settings.raceToggle_elfMoon)
            {
                settings.factionToggle_elfMoon = false;
            }
            if (!settings.raceToggle_elfSun)
            {
                settings.factionToggle_elfSun = false;
            }
            if (!settings.raceToggle_elfWood)
            {
                settings.factionToggle_elfWood = false;
            }
            if (!settings.raceToggle_gith)
            {
                settings.factionToggle_gith = false;
            }
            if (!settings.raceToggle_goblin)
            {
                settings.factionToggle_goblin = false;
            }
            if (!settings.raceToggle_halforc)
            {
                settings.factionToggle_halforc = false;
            }
            if (!settings.raceToggle_hobgoblin)
            {
                settings.factionToggle_hobgoblin = false;
            }
            if (!settings.raceToggle_illithid)
            {
                settings.factionToggle_illithid = false;
            }
            if (!settings.raceToggle_kobold)
            {
                settings.factionToggle_kobold = false;
            }
            if (!settings.raceToggle_orc)
            {
                settings.factionToggle_orc = false;
            }
            if (!settings.raceToggle_tiefling)
            {
                settings.factionToggle_tiefling = false;
            }
            if (!settings.raceToggle_warforged)
            {
                settings.factionToggle_warforged = false;
            }
        }
    }
}
