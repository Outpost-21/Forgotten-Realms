using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UnityEngine;
using RimWorld;
using Verse;

namespace ForgottenRealms
{
    public class ForgottenRealmsSettings : ModSettings
    {
        public bool verboseLogging = false;

        public override void ExposeData()
        {
            base.ExposeData();
        }
    }
}
