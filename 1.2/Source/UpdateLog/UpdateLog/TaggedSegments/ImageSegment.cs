using System;
using System.IO;
using Verse;
using UnityEngine;

namespace UpdateInfo
{
    public class ImageSegment : TaggedSegment
    {
        public override (string, string) Tags => ("<img>", "</img>");

        public override int HeightOccupied(string innerText)
        {
            return (int)Dialog_NewUpdate.PreviewImageHeight;
        }

        public override void SegmentAction(Listing_Rich lister, string innerText)
        {
            if (lister.CurrentLog is UpdateInfo log && log.cachedTextures.TryGetValue(innerText, out Texture2D tex))
            {
                lister.DrawTexture(tex, 100);
            }
            else
            {
                Log.ErrorOnce($"Failed to retrieve cached texture for {innerText}.", innerText.GetHashCode());
            }
        }
    }
}
