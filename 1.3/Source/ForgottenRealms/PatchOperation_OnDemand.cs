using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

using UnityEngine;
using RimWorld;
using Verse;

namespace ForgottenRealms
{
    public class PatchOperation_OnDemand : PatchOperation
    {

        private static readonly List<string> loaded = new List<string>();

        public string source = "OnDemand";

        public List<string> folders;

        [Unsaved(false)]
        private bool tested;

        [Unsaved(false)]
        private bool autoload;

        public override void Complete(string modIdentifier)
        {
        }
        public override bool ApplyWorker(XmlDocument xml)
        {
            if (tested)
            {
                return false;
            }
            tested = true;
            if (folders.NullOrEmpty())
            {
                autoload = true;
                folders = (from m in ModsConfig.ActiveModsInLoadOrder
                    select m.PackageId).ToList();
            }
            ModContentPack modContentPack = ForgottenRealmsMod.mod.Content;
            //ModContentPack modContentPack = LoadedModManager.RunningMods.First((ModContentPack mcp) => mcp.Patches.Any((PatchOperation p) => p == this));
            foreach (string text in folders)
            {
                if (LoadDefsInto(xml, modContentPack, text))
                {
                    Log.Message(modContentPack.Name + " :: Loading " + text, false);
                }
            }
            return true;
        }

        public bool LoadDefsInto(XmlDocument xml, ModContentPack content, string folder)
        {
            string text = Path.Combine(Path.Combine(content.RootDir, source), folder);
            if (loaded.Contains(text))
            {
                return false;
            }
            if (!Directory.Exists(text))
            {
                if (!autoload)
                {
                    Log.Warning(string.Concat(new string[]
                    {
                        content.Name,
                        " is trying to load non-existant folder ",
                        source,
                        "/",
                        folder
                    }), false);
                }
                return false;
            }
            foreach (object obj in LoadedModManager.CombineIntoUnifiedXML(DirectXmlLoader.XmlAssetsInModFolder(content, Path.Combine(source, folder), null).ToList(), new Dictionary<XmlNode, LoadableXmlAsset>()).DocumentElement.ChildNodes)
            {
                XmlNode node = (XmlNode)obj;
                xml.DocumentElement.AppendChild(xml.ImportNode(node, true));
            }
            loaded.Add(text);
            return true;
        }
    }
}
