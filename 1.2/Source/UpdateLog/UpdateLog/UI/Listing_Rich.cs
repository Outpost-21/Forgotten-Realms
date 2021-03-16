using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Verse;
using RimWorld;
using UnityEngine;

namespace UpdateInfo
{
    public class Listing_Rich : Listing_Standard
    {
        private const string LineBreakTag = "<br/>";
        private static readonly GUIContent tmpTextGUIContent = new GUIContent();

        public UpdateInfo CurrentLog { get; set; }

        public Listing_Rich()
        {
        }

        public Listing_Rich(GameFont font) : base(font)
        {
        }

        public void DrawTexture(Texture2D texture, float height)
        {
            float imageWidth = ((float)texture.width / texture.height) * height;
            NewColumnIfNeeded(height);
            Rect rect = GetRect(height);
            Rect imageRect = new Rect(rect)
            {
                x = (rect.width - imageWidth) / 2,
                height = height,
                width = imageWidth
            };
            GUI.DrawTexture(imageRect, texture);
        }

        public void RichText(DescriptionData segment)
        {
            string text = segment.text;
            if (!segment.underlineText.NullOrEmpty())
            {
                text = Regex.Replace(segment.text, @"(<u>.*?<\/u>)|(<link>.*?<\/link>)|(<b>.*?<\/b>)|(<color>.*?<\/color>)", "", RegexOptions.Singleline, TimeSpan.FromMilliseconds(5));
                DrawUnderlines(segment, text);
            }
            if (!segment.hyperlinks.NullOrEmpty())
            {
                text = Regex.Replace(segment.text, @"(<u>.*?<\/u>)|(<b>.*?<\/b>)|(<color>.*?<\/color>)", "", RegexOptions.Singleline, TimeSpan.FromMilliseconds(5));
                bool[] mouseovers = DrawHyperlinks(segment, text);
                for (int i = 0; i < segment.hyperlinks.Length; i++)
                {
                    string hyperlinkText = segment.hyperlinks[i];
                    string nameText = Regex.Match(hyperlinkText, @"(\(.*?\))", RegexOptions.Singleline, TimeSpan.FromMilliseconds(2)).Value;
                    string colorCode = "#99D9EA";
                    if (mouseovers[i])
                    {
                        colorCode = "#4DB3E6";
                    }
                    nameText = nameText.Replace("(", $"<color={colorCode}>").Replace(")", "</color>");
                    text = text.Replace(hyperlinkText, nameText);
                }
            }
            Label(text);
        }

        private void DrawUnderlines(DescriptionData segment, string bracketText)
        {
            string lineBreakParsedText = bracketText.Replace(Environment.NewLine, LineBreakTag);
            foreach (string uSegment in segment.underlineText)
            {
                string uSegmentInner = uSegment.Replace(EnhancedText.underlineTag, "").Replace(EnhancedText.underlineEndTag, "");
                int indexOf = bracketText.IndexOf(uSegmentInner);
                try
                {
                    tmpTextGUIContent.text = uSegmentInner;
                    Vector2 segmentSize = Text.CurFontStyle.CalcSize(tmpTextGUIContent);
                    tmpTextGUIContent.text = " ";
                    float fontHeight = Text.CurFontStyle.CalcHeight(tmpTextGUIContent, 9999);
                    string preSegment = bracketText.Substring(0, indexOf);

                    string[] words = Regex.Matches(lineBreakParsedText, $@"({LineBreakTag})|(.*?(?=\s|{LineBreakTag}|$))", RegexOptions.Singleline, TimeSpan.FromSeconds(1)).Cast<Match>().Select(m => m.Value).ToArray();
                    float startX = 0;
                    float startY = Text.CalcHeight(preSegment, ColumnWidth) + CurHeight - fontHeight * 0.25f;
                    foreach (string word in words)
                    {
                        if (word == LineBreakTag)
                        {
                            startX = 0;
                            continue;
                        }
                        else if (word.NullOrEmpty())
                        {
                            continue;
                        }
                        if (word == uSegment)
                        {
                            break;
                        }
                        float wordWidth = Text.CalcSize(word + " ").x;
                        startX += wordWidth;
                        if (startX >= ColumnWidth)
                        {
                            startX = wordWidth;
                        }
                    }
                    Widgets.DrawLineHorizontal(startX, startY, segmentSize.x);
                }
                catch (ArgumentOutOfRangeException)
                {
                    Log.Error($"Failed to find {uSegmentInner} in {segment.text}");
                }
            }
        }

        private bool[] DrawHyperlinks(DescriptionData segment, string bracketText)
        {
            bool[] mouseovers = new bool[segment.hyperlinks.Length];
            int i = 0;
            foreach (string hyperlinkUnparsed in segment.hyperlinks)
            {
                string url = Regex.Match(hyperlinkUnparsed, @"((?<=<link>).*?(?=<\/link>))").Value;
                string name = Regex.Match(hyperlinkUnparsed, @"((?<=\().*?(?=\)))").Value;
                for (int h = 0; h < i; h++)
                {
                    string prevHyperLink = segment.hyperlinks[h];
                    string prevName = Regex.Match(prevHyperLink, @"((?<=\().*?(?=\)))").Value;
                    bracketText = bracketText.Replace(prevHyperLink, prevName);
                }
                string lineBreakParsedText = bracketText.Replace(Environment.NewLine, LineBreakTag);
                int indexOf = bracketText.IndexOf(hyperlinkUnparsed);
                try
                {
                    tmpTextGUIContent.text = name;
                    Vector2 segmentSize = Text.CurFontStyle.CalcSize(tmpTextGUIContent);
                    tmpTextGUIContent.text = " ";
                    float fontHeight = Text.CurFontStyle.CalcHeight(tmpTextGUIContent, 9999);
                    string preSegment = bracketText.Substring(0, indexOf);

                    string[] words = Regex.Matches(lineBreakParsedText, $@"({LineBreakTag})|(.*?(?={LineBreakTag}|\s|$))", RegexOptions.Singleline, TimeSpan.FromSeconds(1)).Cast<Match>().Select(m => m.Value).ToArray();
                    float startX = 0;
                    float startY = Text.CalcHeight(preSegment + Text.CalcSize(name + " ").x, ColumnWidth) + CurHeight - fontHeight * 0.25f;
                    foreach (string word in words)
                    {
                        if (word.Contains(EnhancedText.hyperlinkTag))
                        {
                            float nameWidth = Text.CalcSize(name + " ").x;
                            if (startX + nameWidth >= ColumnWidth)
                            {
                                startX = 0;
                            }
                            break;
                        }
                        else if (word == LineBreakTag)
                        {
                            startX = 0;
                            continue;
                        }
                        else if (word.NullOrEmpty())
                        {
                            continue;
                        }
                        float wordWidth = Text.CalcSize(word + " ").x;
                        startX += wordWidth;
                        if (startX >= ColumnWidth)
                        {
                            startX = wordWidth;
                        }
                    }
                    Rect linkRect = new Rect(startX, startY - fontHeight, segmentSize.x, fontHeight);
                    if (Mouse.IsOver(linkRect))
                    {
                        mouseovers[i] = true;

                        Widgets.DrawLine(new Vector2(startX, startY), new Vector2(startX + segmentSize.x, startY), GenUI.MouseoverColor, 1);
                        if (Widgets.ButtonInvisible(linkRect))
                        {
                            Application.OpenURL(url);
                        }
                    }
                    else
                    {
                        mouseovers[i] = false;
                    }
                }
                catch (ArgumentOutOfRangeException)
                {
                    Log.Error($"Failed to find {hyperlinkUnparsed} in {bracketText}");
                }
                i++;
            }
            return mouseovers;
        }

        public void HyperlinkNewline(string name, string url)
        {
            var color = GUI.color;
            var textSize = Text.CalcSize(name);
            Rect rect = GetRect(textSize.y);
            rect.width = textSize.x;
            if (Mouse.IsOver(rect))
            {
                GUI.color = GenUI.MouseoverColor;
                Widgets.DrawLineHorizontal(rect.x, rect.y + rect.height * 0.75f, textSize.x);
            }
            else
            {
                GUI.color = new Color(0.6f, .85f, 1);
            }
            Widgets.Label(rect, name);
            
            if (Widgets.ButtonInvisible(rect))
            {
                Application.OpenURL(url);
            }
            GUI.color = color;
        }
    }
}
