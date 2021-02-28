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

namespace O21Settings_ForgottenRealms
{
    [StaticConstructorOnStartup]
    public static class HarmonyPatches
    {
        static HarmonyPatches()
        {
            Harmony StarTrekHarmony = new Harmony("com.neronix17.forgottenrealms.mod");

            StarTrekHarmony.PatchAll();
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
}
