using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Verse;
using HarmonyLib;

namespace ForgottenRealms
{

    [HarmonyPatch(typeof(Thing), "ButcherProducts")]
    public static class Patch_Thing_ButcherProducts
    {

        [HarmonyPostfix]
        public static void Postfix(Thing __instance, ref IEnumerable<Thing> __result, float efficiency)
        {
            Pawn pawn = __instance as Pawn;
            if (pawn != null && pawn.RaceProps.IsFlesh && !(pawn?.genes?.xenotype == ForgottenRealmsDefOf.Forgotten_Illithid) && pawn?.Corpse?.GetRotStage() == RotStage.Fresh)
            {
                BodyPartRecord brain = pawn?.health?.hediffSet?.GetBrain();
                if (brain != null)
                {
                    __result = GenerateExtraProducts(__result, pawn, efficiency);
                }
            }
        }

        public static IEnumerable<Thing> GenerateExtraProducts(IEnumerable<Thing> things, Pawn pawn, float efficiency)
        {
            if (!things.EnumerableNullOrEmpty())
            {
                foreach (Thing thing in things)
                {
                    yield return thing;
                }
            }

            Thing brain = ThingMaker.MakeThing(DefDatabase<ThingDef>.GetNamed("Forgotten_HumanoidBrain"), null);
            brain.stackCount = 1;
            yield return brain;
        }
    }
}
