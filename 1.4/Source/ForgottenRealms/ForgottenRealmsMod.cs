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

        internal static string VersionDir => Path.Combine(ModLister.GetActiveModWithIdentifier("neronix17.fr.compilation").RootDir.FullName, "Version.txt");
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

            Harmony ForgottenHarmony = new Harmony("com.neronix17.forgottenrealms.mod");
            ForgottenHarmony.PatchAll();
        }

        public override string SettingsCategory() => "Forgotten Realms";

        public override void DoSettingsWindowContents(Rect inRect)
        {
            bool flag = optionsViewRectHeight > inRect.height;
            Rect viewRect = new Rect(inRect.x, inRect.y, inRect.width - (flag ? 26f : 0f), optionsViewRectHeight);
            Widgets.BeginScrollView(inRect, ref optionsScrollPosition, viewRect);
            Listing_Standard listing = new Listing_Standard();
            Rect rect = new Rect(viewRect.x, viewRect.y, viewRect.width, 999999f);
            listing.Begin(rect);
            // ============================ CONTENTS ================================
            DoOptionsCategoryContents(listing);
            // ======================================================================
            optionsViewRectHeight = listing.CurHeight;
            listing.End();
            Widgets.EndScrollView();
        }

        public void DoOptionsCategoryContents(Listing_Standard listing)
        {
            listing.Note("You will need to restart the game changing any settings as some code is only run on startup. Spawn rates and if they can spawn naturally through vanilla factions can be controlled through Tabula Rasa's settings.", GameFont.Tiny);
            listing.GapLine();
            listing.CheckboxLabeled("Chitine", ref settings.raceToggle_chitine, "Enables/Disables the Chitine race.");
            listing.CheckboxLabeled("Dwarf", ref settings.raceToggle_dwarf, "Enables/Disables the Dwarf race.");
            listing.CheckboxLabeled("Elves", ref settings.raceToggle_elf, "Enables/Disables the Elven races (Dark Elf, Moon Elf, Sun Elf and Wood Elf are all rolled into this setting).");
            listing.CheckboxLabeled("Firbolg", ref settings.raceToggle_firbolg, "Enables/Disables the Firbolg race.");
            listing.CheckboxLabeled("Gith", ref settings.raceToggle_gith, "Enables/Disables the Gith race.");
            listing.CheckboxLabeled("Goblins", ref settings.raceToggle_goblin, "Enables/Disables the Goblins race.");
            listing.CheckboxLabeled("Half-Orcs", ref settings.raceToggle_halforc, "Enables/Disables this Half-Orc race.");
            listing.CheckboxLabeled("Halfling", ref settings.raceToggle_halfling, "Enables/Disables the Halfling race.");
            listing.CheckboxLabeled("Hobgoblins", ref settings.raceToggle_hobgoblin, "Enables/Disables the Hobgoblin race.");
            listing.CheckboxLabeled("Illithids", ref settings.raceToggle_illithid, "Enables/Disables the Illithid race.");
            listing.CheckboxLabeled("Killoren", ref settings.raceToggle_killoren, "Enables/Disables the Killoren race.");
            listing.CheckboxLabeled("Kobolds", ref settings.raceToggle_kobold, "Enables/Disables the Kobold race.");
            listing.CheckboxLabeled("Orcs", ref settings.raceToggle_orc, "Enables/Disables the Orc race.");
            listing.CheckboxLabeled("Tabaxi", ref settings.raceToggle_tabaxi, "Enables/Disables the Tabaxi race.");
            listing.CheckboxLabeled("Tieflings", ref settings.raceToggle_tiefling, "Enables/Disables the Tiefling race.");
            listing.CheckboxLabeled("Warforged", ref settings.raceToggle_warforged, "Enables/Disables the Warforged race.");
        }
    }
}
