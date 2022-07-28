using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Verse;
using TabulaRasa;

namespace ForgottenRealms
{
    [StaticConstructorOnStartup]
    public static class ForgottenRealmsStartup
    {
        static ForgottenRealmsStartup()
        {
            OnDemandUtil.FixOnDemandDefs("O21_FR_", ForgottenRealmsMod.mod.Content);
        }
    }
}
