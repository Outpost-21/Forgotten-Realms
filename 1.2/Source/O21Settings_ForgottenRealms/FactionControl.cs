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
            ForgottenRealmsSettings settings = ForgottenRealmsMod.mod.settings;

            if (!settings.faction_elfDark)
            {
                ForgottenFactionsDefOf.O21_DarkElfKingdoms.requiredCountAtGameStart = 0;
                ForgottenFactionsDefOf.O21_DarkElfKingdoms.maxCountAtGameStart = 0;
            }
            if (!settings.faction_elfMoon)
            {
                ForgottenFactionsDefOf.O21_MoonElfKingdoms.requiredCountAtGameStart = 0;
                ForgottenFactionsDefOf.O21_MoonElfKingdoms.maxCountAtGameStart = 0;
            }
            if (!settings.faction_elfSun)
            {
                ForgottenFactionsDefOf.O21_SunElfKingdoms.requiredCountAtGameStart = 0;
                ForgottenFactionsDefOf.O21_SunElfKingdoms.maxCountAtGameStart = 0;
            }
            if (!settings.faction_elfWood)
            {
                ForgottenFactionsDefOf.O21_WoodElfKingdoms.requiredCountAtGameStart = 0;
                ForgottenFactionsDefOf.O21_WoodElfKingdoms.maxCountAtGameStart = 0;
            }

            if (!settings.faction_gith)
            {
                ForgottenFactionsDefOf.O21_GithTribes.requiredCountAtGameStart = 0;
                ForgottenFactionsDefOf.O21_GithTribes.maxCountAtGameStart = 0;
            }
            if (!settings.faction_goblin)
            {
                ForgottenFactionsDefOf.O21_GoblinTribes.requiredCountAtGameStart = 0;
                ForgottenFactionsDefOf.O21_GoblinTribes.maxCountAtGameStart = 0;
            }
            if (!settings.faction_hobgoblin)
            {
                ForgottenFactionsDefOf.O21_HobgoblinTribes.requiredCountAtGameStart = 0;
                ForgottenFactionsDefOf.O21_HobgoblinTribes.maxCountAtGameStart = 0;
            }
            if (!settings.faction_illithid)
            {
                ForgottenFactionsDefOf.O21_IllithidTribes.requiredCountAtGameStart = 0;
                ForgottenFactionsDefOf.O21_IllithidTribes.maxCountAtGameStart = 0;
            }
            if (!settings.faction_kobold)
            {
                ForgottenFactionsDefOf.O21_KoboldTribes.requiredCountAtGameStart = 0;
                ForgottenFactionsDefOf.O21_KoboldTribes.maxCountAtGameStart = 0;
            }
            if (!settings.faction_orc)
            {
                ForgottenFactionsDefOf.O21_OrcTribes.requiredCountAtGameStart = 0;
                ForgottenFactionsDefOf.O21_OrcTribes.maxCountAtGameStart = 0;
            }
            if (!settings.faction_tiefling)
            {
                ForgottenFactionsDefOf.O21_TieflingTribes.requiredCountAtGameStart = 0;
                ForgottenFactionsDefOf.O21_TieflingTribes.maxCountAtGameStart = 0;
            }
            if (!settings.faction_warforged)
            {
                ForgottenFactionsDefOf.O21_WarforgedTribes.requiredCountAtGameStart = 0;
                ForgottenFactionsDefOf.O21_WarforgedTribes.maxCountAtGameStart = 0;
            }
        }
    }
}
