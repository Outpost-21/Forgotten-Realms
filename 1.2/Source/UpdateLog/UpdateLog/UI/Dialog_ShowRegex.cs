using System;
using System.Collections.Generic;
using Verse;
using UnityEngine;

namespace UpdateInfo
{
    public class Dialog_ShowRegex : Window
    {
        private readonly string regex;

        public Dialog_ShowRegex(string regex)
        {
            this.regex = regex;
        }

        public override void DoWindowContents(Rect inRect)
        {
            
        }

        public override void PostOpen()
        {
            base.PostOpen();
            Vector2 size = Text.CalcSize(regex);
            windowRect = new Rect(0, size.y * 3, size.x, size.y).Rounded();
        }
    }
}
