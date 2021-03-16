using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Xml;
using System.Xml.Linq;
using RimWorld;
using Verse;
using UnityEngine;

namespace UpdateInfo
{
    public class UpdateInfo
    {
        public ModContentPack Mod { get; private set; }
        public UpdateLogData UpdateData { get; private set; }

        public string CurrentFolder { get; private set; }

        public Dictionary<string, Texture2D> cachedTextures;

        public UpdateInfo(ModContentPack mod, string loadFolder)
        {
            Mod = mod;
            CurrentFolder = loadFolder;
            UpdateData = FileReader.ParseUpdateData(Path.Combine(FileReader.UpdateLogDirectory(Mod, CurrentFolder), FileReader.UpdateLogFileName));
            if (UpdateData.rightIconBar is null)
            {
                UpdateData.rightIconBar = new List<UpdateLogData.HyperlinkedIcon>();
            }
            if (UpdateData.leftIconBar is null)
            {
                UpdateData.leftIconBar = new List<UpdateLogData.HyperlinkedIcon>();
            }
            cachedTextures = new Dictionary<string, Texture2D>();
            if (Directory.Exists(FileReader.UpdateImagesDirectory(mod, loadFolder)))
            {
                foreach (var file in Directory.GetFiles(FileReader.UpdateImagesDirectory(mod, loadFolder)))
                {
                    try
                    {
                        byte[] fileData = File.ReadAllBytes(file);
                        Texture2D tex = new Texture2D(2, 2, TextureFormat.Alpha8, true);
                        tex.LoadImage(fileData);
                        tex.name = file.Split('\\').Last();
                        cachedTextures.Add(tex.name, tex);
                    }
                    catch (Exception ex)
                    {
                        Log.Error($"Unable to load file {file} into Texture2D. Are you using an unsupported image type? Exception=\"{ex.Message}\"");
                    }
                }
            }
            
        }

        public void NotifyModUpdated()
        {
            if (!UpdateData.testing)
            {
                SaveUpdateStatus();
            }

            UpdateData.InvokeActionOnUpdate();
        }

        public void SaveUpdateStatus()
        {
            if (!Directory.Exists(FileReader.UpdateLogDirectory(Mod, CurrentFolder)))
            {
                Log.Error($"[{Mod.Name}] Unable to save UpdateLog info as directory {FileReader.UpdateLogDirectory(Mod, CurrentFolder)} does not exist.");
                return;
            }
            try
            {
                XDocument doc = new XDocument(new XElement("UpdateLog", 
                                              new XElement("currentVersion", UpdateData.currentVersion), 
                                              new XElement("updateOn", UpdateData.updateOn),
                                              new XElement("description", UpdateData.description),
                                              new XElement("actionOnUpdate", UpdateData.actionOnUpdate)));
                if (UpdateData.rightIconBar != null && UpdateData.rightIconBar.Any())
                {
                    doc.Element("UpdateLog").Add(new XElement("rightIconBar"));
                    foreach (var item in UpdateData.rightIconBar)
                    {
                        doc.Element("UpdateLog").Element("rightIconBar").Add(new XElement("li",
                                                                        new XElement("name", item.name),
                                                                        new XElement("icon", item.icon),
                                                                        new XElement("url", item.url)));
                    }
                }
                if (UpdateData.leftIconBar != null && UpdateData.leftIconBar.Any())
                {
                    doc.Element("UpdateLog").Add(new XElement("leftIconBar"));
                    foreach (var item in UpdateData.leftIconBar)
                    {
                        doc.Element("UpdateLog").Element("leftIconBar").Add(new XElement("li",
                                                                        new XElement("name", item.name),
                                                                        new XElement("icon", item.icon),
                                                                        new XElement("url", item.url)));
                    }
                }
                doc.Save(Path.Combine(FileReader.UpdateLogDirectory(Mod, CurrentFolder), FileReader.UpdateLogFileName));
            }
            catch (Exception ex)
            {
                Log.Error($"[UpdateLog] Unable to save UpdateLog config info. Exception=\"{ex.Message}\"");
            }
        }

        public class UpdateLogData
        {
            public string currentVersion;
            public UpdateFor updateOn = UpdateFor.GameInit;
            public string description;

            public string actionOnUpdate;

            public List<HyperlinkedIcon> rightIconBar;
            public List<HyperlinkedIcon> leftIconBar;

            public bool testing;
            public bool update;

            public void InvokeActionOnUpdate()
            {
                if (actionOnUpdate.NullOrEmpty())
                {
                    return;
                }
                try
                {
                    string[] methodFullName = actionOnUpdate.Split('.');
                    Type classType = GenTypes.GetTypeInAnyAssembly(methodFullName[0] + "." + methodFullName[1], methodFullName[0]);
                    classType.GetMethod(methodFullName[2]).Invoke(null, null);
                }
                catch (MissingMethodException)
                {
                    Log.Warning($"Unable to assign method on update. Method could not be found: {actionOnUpdate}");
                }
            }

            public string EnhancedDescription
            {
                get
                {
                    string enhancedDesc = description;
                    enhancedDesc = enhancedDesc.Replace('[', '<');
                    enhancedDesc = enhancedDesc.Replace(']', '>');
                    return enhancedDesc;
                }
            }

            public struct HyperlinkedIcon
            {
                /// <summary>
                /// Name of link to be displayed upon highlight
                /// </summary>
                public string name;
                /// <summary>
                /// Texture file name relative to UpgradeLog/Images files. Only include name, not additional file path
                /// </summary>
                public string icon;
                /// <summary>
                /// URL to webpage that will be linked upon clicking the icon
                /// </summary>
                public string url;
            }
        }
    }
}
