using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.IO;
using Verse;
using RimWorld;
using UnityEngine;

namespace UpdateInfo
{
    public class Dialog_NewUpdate : Window
    {
        public const float DialogWidth = 600;
        public const float DialogHeight = 740;

        public const float PreviewImageHeight = 200;
        public const float PaginationButtonHeight = 15;
        public const int BarIconSize = 25;

        private readonly UpdateInfo[] logs;
        private int selectedLogIndex;

        private Vector2 scrollPosition = new Vector2(0, 0);
        private float cachedViewHeight;
        private bool cachedHeightDirty;

        /* Currently Displayed */
        private ModContentPack mod;
        private ModMetaData metaData;
        private UpdateInfo log;
        /* ------------------- */

        private Listing_Rich lister = new Listing_Rich();
        private List<DescriptionData> segments = new List<DescriptionData>();

        private readonly List<Tuple<string, string, Texture2D>> cachedLeftIconBar = new List<Tuple<string, string, Texture2D>>();
        private readonly List<Tuple<string, string, Texture2D>> cachedRightIconBar = new List<Tuple<string, string, Texture2D>>();

        public Dialog_NewUpdate(HashSet<UpdateInfo> logs)
        {
            if (logs.EnumerableNullOrEmpty())
            {
                Close();
                return;
            }
            this.logs = logs.ToArray();
            selectedLogIndex = 0;
            CurrentLog = logs.FirstOrDefault();

            forcePause = true;
            doCloseX = true;
            closeOnClickedOutside = true;
            absorbInputAroundWindow = true;
        }

        public override Vector2 InitialSize => new Vector2(DialogWidth, DialogHeight);

        public UpdateInfo CurrentLog
        {
            get
            {
                return log;
            }
            set
            {
                if (log == value)
                {
                    return;
                }
                log = value;
                mod = log.Mod;
                metaData = ModLister.GetModWithIdentifier(mod.PackageId);
                segments = EnhancedText.ParseDescriptionData(log).ToList();
                RecacheHyperlinks();
                cachedHeightDirty = true;
                lister.CurrentLog = CurrentLog;
            }
        }

        public void RecacheHyperlinks()
        {
            cachedRightIconBar.Clear();
            cachedLeftIconBar.Clear();
            if (CurrentLog.UpdateData.rightIconBar.Any())
            {
                foreach (var iconObj in CurrentLog.UpdateData.rightIconBar)
                {
                    if (CurrentLog.cachedTextures.TryGetValue(iconObj.icon, out Texture2D texture))
                    {
                        cachedRightIconBar.Add(new Tuple<string, string, Texture2D>(iconObj.name, iconObj.url, texture));
                    }
                    else
                    {
                        Log.ErrorOnce($"Unable to retrieve cached texture for icon: {iconObj.icon}", iconObj.icon.GetHashCode());
                    }
                }
            }
            if (CurrentLog.UpdateData.leftIconBar.Any())
            {
                foreach (var iconObj in CurrentLog.UpdateData.leftIconBar)
                {
                    if (CurrentLog.cachedTextures.TryGetValue(iconObj.icon, out Texture2D texture))
                    {
                        cachedLeftIconBar.Add(new Tuple<string, string, Texture2D>(iconObj.name, iconObj.url, texture));
                    }
                    else
                    {
                        Log.ErrorOnce($"Unable to retrieve cached texture for icon: {iconObj.icon}", iconObj.icon.GetHashCode());
                    }
                }
            }
        }

        public void RecacheHeight()
        {
            float height = 0;
            var font = Text.Font;
            var anchor = Text.Anchor;
            var color = GUI.color;
            foreach (DescriptionData data in segments)
            {
                if (data.tag is TaggedSegment tag)
                {
                    height += tag.HeightOccupied(data.text);
                }
                else
                {
                    height += Text.CalcHeight(data.text, DialogWidth);
                }
            }
            GUI.color = color;
            Text.Anchor = anchor;
            Text.Font = font;
            cachedViewHeight = height - 10;
        }

        public override void DoWindowContents(Rect inRect)
        {
            if (cachedHeightDirty)
            {
                RecacheHeight();
            }
            var anchor = Text.Anchor;
            Text.Anchor = TextAnchor.MiddleCenter;
            var font = Text.Font;
            Text.Font = GameFont.Medium;
            var color = GUI.color;

            Texture2D previewImage = metaData.PreviewImage;

            float pWidth = previewImage?.width ?? 0;
            float pHeight = previewImage?.height ?? 0;
            float imageWidth = ((float)pWidth / pHeight) * PreviewImageHeight;
            Rect previewRect = new Rect(inRect)
            {
                x = (inRect.width - imageWidth) / 2,
                height = PreviewImageHeight,
                width = imageWidth
            };
            if (previewImage != null)
            {
                GUI.DrawTexture(previewRect, previewImage);
            }

            Rect modLabelRect = new Rect(inRect)
            {
                y = previewRect.y + previewRect.height + 5,
                height = Text.CalcHeight(mod.Name, inRect.width)
            };
            Widgets.Label(modLabelRect, mod.Name);

            Widgets.DrawLineHorizontal(0, modLabelRect.y + modLabelRect.height, modLabelRect.width);

            Rect rightIconBarRect = new Rect(inRect.width - BarIconSize, modLabelRect.y, BarIconSize, BarIconSize);
            foreach (var barIcon in cachedRightIconBar)
            {
                if (!barIcon.Item2.NullOrEmpty())
                {
                    if (Mouse.IsOver(rightIconBarRect))
                    {
                        GUI.color = GenUI.MouseoverColor;
                        if (!barIcon.Item1.NullOrEmpty())
                        {
                            TooltipHandler.TipRegion(rightIconBarRect, barIcon.Item1);
                        }
                    }
                    if (Widgets.ButtonInvisible(rightIconBarRect))
                    {
                        Application.OpenURL(barIcon.Item2);
                    }
                }
                Widgets.DrawTextureFitted(rightIconBarRect, barIcon.Item3, 1);
                rightIconBarRect.x -= BarIconSize + 10;
                GUI.color = color;
            }

            Rect leftIconBarRect = new Rect(0, modLabelRect.y, BarIconSize, BarIconSize);
            foreach (var barIcon in cachedLeftIconBar)
            {
                if (!barIcon.Item2.NullOrEmpty())
                {
                    if (Mouse.IsOver(leftIconBarRect))
                    {
                        GUI.color = GenUI.MouseoverColor;
                        if (!barIcon.Item1.NullOrEmpty())
                        {
                            TooltipHandler.TipRegion(leftIconBarRect, barIcon.Item1);
                        }
                    }
                    if (Widgets.ButtonInvisible(leftIconBarRect))
                    {
                        Application.OpenURL(barIcon.Item2);
                    }
                }
                Widgets.DrawTextureFitted(leftIconBarRect, barIcon.Item3, 1);
                leftIconBarRect.x += BarIconSize + 10;
                GUI.color = color;
            }

            float descY = modLabelRect.y + modLabelRect.height + 5;

            Rect lowerRect = new Rect(inRect.x, descY, inRect.width, inRect.height - descY);

            Rect viewRect = new Rect(inRect.x, inRect.y, inRect.width - 16, cachedViewHeight);

            lister.BeginScrollView(lowerRect, ref scrollPosition, ref viewRect);
            
            foreach (DescriptionData segment in segments)
            {
                if (segment.tag is TaggedSegment tag)
                {
                    tag.SegmentAction(lister, segment.text);
                }
                else
                {
                    lister.RichText(segment);
                }
            }

            lister.EndScrollView(ref viewRect);

            Rect bottomButtonsRect = new Rect(0, inRect.height - PaginationButtonHeight * 2, PaginationButtonHeight * 2, PaginationButtonHeight);
            if (selectedLogIndex > 0 && Widgets.ButtonText(bottomButtonsRect, "<"))
            {
                selectedLogIndex--;
                CurrentLog = logs[selectedLogIndex];
            }
            bottomButtonsRect.x = inRect.width - PaginationButtonHeight * 2;
            if (selectedLogIndex < (logs.Length - 1) && Widgets.ButtonText(bottomButtonsRect, ">"))
            {
                selectedLogIndex++;
                CurrentLog = logs[selectedLogIndex];
            }
            Text.Anchor = anchor;
            Text.Font = font;
            GUI.color = color;
        }
    }
}
