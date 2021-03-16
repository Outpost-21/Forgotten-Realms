using System;
using Verse;

namespace UpdateInfo
{
    public class FontSegment : TaggedSegment
    {
        public override (string, string) Tags => ("<font>", "</font>");

        public override int HeightOccupied(string innerText)
        {
            Text.Font = (GameFont)Enum.Parse(typeof(GameFont), innerText, true);
            return 0;
        }

        public override void SegmentAction(Listing_Rich lister, string innerText)
        {
            Text.Font = (GameFont)Enum.Parse(typeof(GameFont), innerText, true);
        }
    }
}
