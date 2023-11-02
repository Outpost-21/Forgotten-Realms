using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;

using UnityEngine;
using RimWorld;
using Verse;

using HarmonyLib;
using TabulaRasa;

namespace ForgottenRealms
{
    public class ForgottenRealmsMod : Mod
    {
        public static ForgottenRealmsSettings settings;
        public static ForgottenRealmsMod mod;

        public Vector2 optionsScrollPosition;
        public float optionsViewRectHeight;

        internal static string VersionDir => Path.Combine(mod.Content.ModMetaData.RootDir.FullName, "Version.txt");
        public static string CurrentVersion { get; private set; }

        public ForgottenRealmsMod(ModContentPack content) : base(content)
        {
            settings = GetSettings<ForgottenRealmsSettings>();
            mod = this;

            Version version = Assembly.GetExecutingAssembly().GetName().Version;
            CurrentVersion = $"{version.Major}.{version.Minor}.{version.Build}";

            LogUtil.LogMessage($"{CurrentVersion} ::");

            if (Prefs.DevMode)
            {
                File.WriteAllText(VersionDir, CurrentVersion);
            }

            Harmony ForgottenHarmony = new Harmony("RimWorld.Neronix17.ForgottenRealms");
            ForgottenHarmony.PatchAll();
        }

        //public override string SettingsCategory() => "Forgotten Realms";

        //public override void DoSettingsWindowContents(Rect inRect)
        //{
        //    bool flag = optionsViewRectHeight > inRect.height;
        //    Rect viewRect = new Rect(inRect.x, inRect.y, inRect.width - (flag ? 26f : 0f), optionsViewRectHeight);
        //    Widgets.BeginScrollView(inRect, ref optionsScrollPosition, viewRect);
        //    Listing_Standard listing = new Listing_Standard();
        //    Rect rect = new Rect(viewRect.x, viewRect.y, viewRect.width, 999999f);
        //    listing.Begin(rect);
        //    // ============================ CONTENTS ================================
        //    DoOptionsCategoryContents(listing);
        //    // ======================================================================
        //    optionsViewRectHeight = listing.CurHeight;
        //    listing.End();
        //    Widgets.EndScrollView();
        //}

        //public void DoOptionsCategoryContents(Listing_Standard listing)
        //{

        //}
    }
}
