using System;
using Verse;
using UnityEngine;

namespace UpdateInfo
{
    public class TitleSegment : TaggedSegment
    {
        public override (string, string) Tags => ("<title>", "</title>");

        public override int HeightOccupied(string innerText)
        {
            Text.Font = GameFont.Small;
            return (int)Text.CalcHeight(innerText, Dialog_NewUpdate.DialogWidth);
        }

        public override void SegmentAction(Listing_Rich lister, string innerText)
        {
            var font = Text.Font;
            Text.Font = GameFont.Small;
            innerText = "<b>" + innerText + "</b>";
            Rect labelRect = lister.Label(innerText);
            Widgets.DrawLineHorizontal(0, labelRect.y + Text.CalcHeight(innerText, 9999), labelRect.width);
            Text.Font = font;
        }
    }
}
