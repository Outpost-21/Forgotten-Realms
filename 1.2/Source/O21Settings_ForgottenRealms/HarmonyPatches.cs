using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UnityEngine;
using RimWorld;
using Verse;
using Verse.AI;

using HarmonyLib;

using AlienRace;

namespace O21Settings_ForgottenRealms
{
    [StaticConstructorOnStartup]
    public static class HarmonyPatches
    {
        static HarmonyPatches()
        {
            Harmony ForgottenHarmony = new Harmony("com.neronix17.forgottenrealms.mod");

            ForgottenHarmony.PatchAll();
        }
    }

    [HarmonyPatch(typeof(MentalBreakWorker), "BreakCanOccur")]
    public static class Patch_CanBeResearchedAt_Postfix
    {
        [HarmonyPrefix]
        public static bool Prefix(MentalBreakWorker __instance, bool __result, Pawn pawn)
        {
            if (pawn.def.defName == "O21_Alien_Warforged")
            {
                __result = false;
                return false;
            }
            return true;
        }
    }

    [HarmonyPatch(typeof(Thing), "ButcherProducts")]
    static class Thing_ButcherProducts
    {

        [HarmonyPostfix]
        static void Postfix(Thing __instance, ref IEnumerable<Thing> __result, float efficiency)
        {
            if (ForgottenRealmsMod.settings.raceToggle_illithid)
            {
                Pawn pawn = __instance as Pawn;
                if (pawn != null && pawn.def.race.Humanlike && pawn.def.defName != "O21_Alien_Illithid" && pawn.RaceProps.body == BodyDefOf.Human && pawn.Corpse.GetRotStage() == RotStage.Fresh)
                {
                    ThingDef_AlienRace raceDef = (ThingDef_AlienRace)pawn.def ?? null;
                    if (raceDef != null && raceDef.alienRace.compatibility.HasBlood && raceDef.alienRace.compatibility.IsFlesh && raceDef.alienRace.compatibility.IsSentient)
                    {
                        BodyPartRecord brain = pawn?.health?.hediffSet?.GetNotMissingParts()?.Where(x => x.def.defName == "Brain")?.FirstOrDefault();
                        if (brain != null)
                        {
                            __result = GenerateExtraProducts(__result, pawn, efficiency);
                        }
                    }
                }
            }
        }

        private static IEnumerable<Thing> GenerateExtraProducts(IEnumerable<Thing> things, Pawn pawn, float efficiency)
        {
            if (!things.EnumerableNullOrEmpty())
            {
                foreach (Thing thing in things)
                {
                    yield return thing;
                }
            }

            Thing brain = ThingMaker.MakeThing(DefDatabase<ThingDef>.GetNamed("O21_Illithid_HumanoidBrain"), null);
            brain.stackCount = 1;
            yield return brain;
        }
    }
}
