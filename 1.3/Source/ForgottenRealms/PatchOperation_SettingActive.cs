using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

using UnityEngine;
using RimWorld;
using Verse;

namespace ForgottenRealms
{
    public class PatchOperation_SettingActive : PatchOperation
    {
        public override bool ApplyWorker(XmlDocument xml)
        {
            bool flag = false;
            for (int i = 0; i < settings.Count(); i++)
            {
                if (ForgottenRealmsMod.settings.GetEnabledSettings.Contains(settings[i]))
                {
                    flag = true;
                    break;
                }
            }

            if (flag)
            {
                if (active != null)
                {
                    return active.Apply(xml);
                }
            }
            else if (inactive != null)
            {
                return inactive.Apply(xml);
            }
            return true;
        }

        private List<string> settings;

        private PatchOperation active;

        private PatchOperation inactive;
    }
}
