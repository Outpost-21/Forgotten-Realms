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
    public class ForgottenRealmsMod : Mod
    {
        public ForgottenRealmsSettings settings;
        public static ForgottenRealmsMod mod;

        public ForgottenRealmsMod(ModContentPack content) : base(content)
        {
            settings = GetSettings<ForgottenRealmsSettings>();
            mod = this;
        }

        public override void DoSettingsWindowContents(Rect inRect)
        {
            Listing_Standard listingStandard = new Listing_Standard();
            listingStandard.Begin(inRect);
            listingStandard.Label("Faction Settings - Changing any of these requires a restart to take effect.");
            listingStandard.CheckboxLabeled("Dark Elves", ref settings.faction_elfDark, "Dark Elf Faction");
            listingStandard.CheckboxLabeled("Moon Elves", ref settings.faction_elfMoon, "Moon Elf Faction");
            listingStandard.CheckboxLabeled("Sun Elves", ref settings.faction_elfSun, "Sun Elf Faction");
            listingStandard.CheckboxLabeled("Wood Elves", ref settings.faction_elfWood, "Wood Elf Faction");
            listingStandard.CheckboxLabeled("Gith", ref settings.faction_gith, "Gith Faction");
            listingStandard.CheckboxLabeled("Goblin", ref settings.faction_goblin, "Goblin Faction");
            listingStandard.CheckboxLabeled("Hobgoblin", ref settings.faction_hobgoblin, "Hobgoblin Faction");
            listingStandard.CheckboxLabeled("Illithid", ref settings.faction_illithid, "Illithid Faction");
            listingStandard.CheckboxLabeled("Kobold", ref settings.faction_kobold, "Kobold Faction");
            listingStandard.CheckboxLabeled("Orc", ref settings.faction_orc, "Orc Faction");
            listingStandard.CheckboxLabeled("Tiefling", ref settings.faction_tiefling, "Tiefling Faction");
            listingStandard.CheckboxLabeled("Warforged", ref settings.faction_warforged, "Warforged Faction");
            listingStandard.End();
            base.DoSettingsWindowContents(inRect);
        }

        public override string SettingsCategory()
        {
            return "Forgotten Realms";
        }
    }

    public class ForgottenRealmsSettings : ModSettings
    {
        public bool faction_elfDark = true;
        public bool faction_elfMoon = true;
        public bool faction_elfSun = true;
        public bool faction_elfWood = true;

        public bool faction_gith = true;
        public bool faction_goblin = true;
        public bool faction_hobgoblin = true;
        public bool faction_illithid = true;
        public bool faction_kobold = true;
        public bool faction_orc = true;
        public bool faction_tiefling = true;
        public bool faction_warforged = true;

        public override void ExposeData()
        {
            base.ExposeData();
            Scribe_Values.Look(ref faction_elfDark, "faction_elfDark", true);
            Scribe_Values.Look(ref faction_elfMoon, "faction_elfMoon", true);
            Scribe_Values.Look(ref faction_elfSun, "faction_elfSun", true);
            Scribe_Values.Look(ref faction_elfWood, "faction_elfWood", true);

            Scribe_Values.Look(ref faction_gith, "faction_gith", true);
            Scribe_Values.Look(ref faction_goblin, "faction_goblin", true);
            Scribe_Values.Look(ref faction_hobgoblin, "faction_hobgoblin", true);
            Scribe_Values.Look(ref faction_illithid, "faction_illithid", true);
            Scribe_Values.Look(ref faction_kobold, "faction_kobold", true);
            Scribe_Values.Look(ref faction_orc, "faction_orc", true);
            Scribe_Values.Look(ref faction_tiefling, "faction_tiefling", true);
            Scribe_Values.Look(ref faction_warforged, "faction_warforged", true);
        }
    }
}
