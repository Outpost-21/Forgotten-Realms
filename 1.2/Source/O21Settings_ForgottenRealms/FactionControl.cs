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
        }
    }
}
