using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Verse;

namespace ForgottenRealms
{
    [DefOf]
    public static class ForgottenRealmsDefOf
    {
        static ForgottenRealmsDefOf()
        {
            DefOfHelper.EnsureInitializedInCtor(typeof(ForgottenRealmsDefOf));
        }

        public static XenotypeDef Forgotten_Illithid;
    }
}
