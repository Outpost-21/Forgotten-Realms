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
    public class CompProperties_TargetEffectIllithidTadpole : CompProperties_Usable
    {
        public CompProperties_TargetEffectIllithidTadpole()
        {
            compClass = typeof(CompTargetEffect_IllithidTadpole);
        }
    }
}
