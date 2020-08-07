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
    [DefOf]
    public static class ForgottenFactionsDefOf
    {
        static ForgottenFactionsDefOf()
        {
            DefOfHelper.EnsureInitializedInCtor(typeof(ForgottenFactionsDefOf));
        }

        public static FactionDef O21_DarkElfKingdoms;
        public static FactionDef O21_MoonElfKingdoms;
        public static FactionDef O21_SunElfKingdoms;
        public static FactionDef O21_WoodElfKingdoms;

        public static FactionDef O21_GithTribes;
        public static FactionDef O21_GoblinTribes;
        public static FactionDef O21_HobgoblinTribes;
        public static FactionDef O21_IllithidTribes;
        public static FactionDef O21_KoboldTribes;
        public static FactionDef O21_OrcTribes;
        public static FactionDef O21_TieflingTribes;
        public static FactionDef O21_WarforgedTribes;
    }
}
