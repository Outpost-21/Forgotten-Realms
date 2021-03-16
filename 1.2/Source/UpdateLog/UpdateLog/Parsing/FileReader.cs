using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using Verse;
using RimWorld;
using HarmonyLib;

namespace UpdateInfo
{
    public static class FileReader
    {
        public const string UpdateLogFolder = "UpdateLog";
        public const string UpdateLogImageFolder = "Images";
        public const string UpdateLogFileName = "UpdateLog.xml";

        public static string UpdateLogDirectory(ModContentPack mod, string folderName) => Path.Combine(mod.RootDir, folderName, UpdateLogFolder);
        public static string UpdateImagesDirectory(ModContentPack mod, string folderName) => Path.Combine(mod.RootDir, folderName, UpdateLogFolder, UpdateLogImageFolder);
        public static string UpdateImagesDirectory(UpdateInfo log) => UpdateImagesDirectory(log.Mod, log.CurrentFolder);

        public static UpdateInfo ReadFile(this ModContentPack mod)
        {
            try
            {
                var loadFolders = ModFoldersForVersion(mod);
                if (!loadFolders.NullOrEmpty())
                {
                    foreach (string folder in loadFolders)
                    {
                        if (File.Exists(Path.Combine(UpdateLogDirectory(mod, folder), UpdateLogFileName)))
                        {
                            return new UpdateInfo(mod, folder);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                Log.Error($"Exception thrown while attempting to read in UpdateLog data for {mod.Name}.\nException=\"{ex.Message}\" StackTrace=\"{ex.StackTrace}\"");
            }
            return null;
        }

        public static List<string> ModFoldersForVersion(ModContentPack mod)
        {
            ModMetaData metaData = ModLister.GetModWithIdentifier(mod.PackageId);
            List<LoadFolder> loadFolders = new List<LoadFolder>();
            if ((metaData?.loadFolders) != null && metaData.loadFolders.DefinedVersions().Count > 0)
            {
                loadFolders = metaData.LoadFoldersForVersion(VersionControl.CurrentVersionStringWithoutBuild);
                if (!loadFolders.NullOrEmpty())
		        {
                    return loadFolders.Select(lf => lf.folderName).ToList();
		        }
            }
            
            loadFolders = new List<LoadFolder>();

            int num = VersionControl.CurrentVersion.Major;
	        int num2 = VersionControl.CurrentVersion.Minor;
	        do
	        {
		        if (num2 == 0)
		        {
			        num--;
			        num2 = 9;
		        }
		        else
		        {
			        num2--;
		        }
		        if (num < 1)
		        {
                    loadFolders = metaData.LoadFoldersForVersion("default");
                    if (loadFolders != null)
                    {
                        return loadFolders.Select(lf => lf.folderName).ToList();
                    }
                    return DefaultFoldersForVersion(mod).ToList();
		        }
		        loadFolders = metaData.LoadFoldersForVersion(num + "." + num2);
	        }
            while (loadFolders.NullOrEmpty());
            return loadFolders.Select(lf => lf.folderName).ToList();
        }

        public static IEnumerable<string> DefaultFoldersForVersion(ModContentPack mod)
        {
            ModMetaData metaData = ModLister.GetModWithIdentifier(mod.PackageId);

            string rootDir = mod.RootDir;
            string text = Path.Combine(rootDir, VersionControl.CurrentVersionStringWithoutBuild);
			if (Directory.Exists(text))
			{
                yield return text;
			}
			else
			{
				Version version = new Version(0, 0);
				DirectoryInfo[] directories = metaData.RootDir.GetDirectories();
				for (int i = 0; i < directories.Length; i++)
				{
					Version version2;
					if (VersionControl.TryParseVersionString(directories[i].Name, out version2) && version2 > version)
					{
						version = version2;
					}
				}
				if (version.Major > 0)
				{
                    yield return Path.Combine(rootDir, version.ToString());
				}
			}
			string text2 = Path.Combine(rootDir, ModContentPack.CommonFolderName);
			if (Directory.Exists(text2))
			{
                yield return text2;
			}
            yield return rootDir;
        }

        /// <summary>
        /// Manually parsing UpdateLog.UpdateLogData due to issue with ObjectFromXml<T> parsing lists in direct DocumentElement object
        /// </summary>
        /// <param name="filePath"></param>
        public static UpdateInfo.UpdateLogData ParseUpdateData(string filePath)
		{
            string xmlContent = File.ReadAllText(filePath);
            UpdateInfo.UpdateLogData data = new UpdateInfo.UpdateLogData();
			try
			{
				XmlDocument xmlDocument = new XmlDocument();
				xmlDocument.LoadXml(xmlContent);
                foreach (XmlNode node in xmlDocument.DocumentElement.ChildNodes)
                {
                    switch (node.Name)
                    {
                        case "currentVersion":
                            data.currentVersion = node.InnerText;
                            break;
                        case "updateOn":
                            data.updateOn = (UpdateFor)Enum.Parse(typeof(UpdateFor), node.InnerText);
                            break;
                        case "description":
                            data.description = node.InnerText;
                            break;
                        case "rightIconBar":
                            data.rightIconBar = ListFromXml(node);
                            break;
                        case "leftIconBar":
                            data.leftIconBar = ListFromXml(node);
                            break;
                        case "actionOnUpdate":
                            data.actionOnUpdate = node.InnerText;
                            break;
                        case "testing":
                            {
                                data.testing = bool.TryParse(node.InnerText, out bool result) && result;
                            }
                            break;
                        case "update":
                            {
                                data.update = bool.TryParse(node.InnerText, out bool result) && result;
                            }
                            break;
                        case "#comment":
                            continue;
                        default:
                            Log.Error($"Failed to find {node.Name} in manual parsing.");
                            break;
                    }
                }
			}
			catch (Exception ex)
			{
				Log.Error("Exception loading file at " + filePath + ". Loading defaults instead. Exception was: " + ex.ToString(), false);
			}
			return data;
		}

        private static List<UpdateInfo.UpdateLogData.HyperlinkedIcon> ListFromXml(XmlNode listRootNode)
        {
	        List<UpdateInfo.UpdateLogData.HyperlinkedIcon> list = new List<UpdateInfo.UpdateLogData.HyperlinkedIcon>();
	        try
	        {
		        foreach (object obj in listRootNode.ChildNodes)
		        {
			        XmlNode xmlNode = (XmlNode)obj;
			        try
					{
						list.Add(DirectXmlToObject.ObjectFromXml<UpdateInfo.UpdateLogData.HyperlinkedIcon>(xmlNode, true));
					}
					catch (Exception ex)
					{
						Log.Error(string.Concat(new object[]
						{
							"Exception loading list element from XML: ",
							ex,
							"\nXML:\n",
							listRootNode.OuterXml
						}), false);
					}
		        }
	        }
	        catch (Exception ex2)
	        {
		        Log.Error(string.Concat(new object[]
		        {
			        "Exception loading list from XML: ",
			        ex2,
			        "\nXML:\n",
			        listRootNode.OuterXml
		        }), false);
	        }
	        return list;
        }
    }
}
