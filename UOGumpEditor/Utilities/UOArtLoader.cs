using System.Text;
using UOGumpEditor.Assets;

namespace UOGumpEditor
{
    public class UOArtLoader
    {
        public static bool IsLoaded { get; private set; } = false;

        private static readonly string DataFolder = Path.Combine(Directory.GetCurrentDirectory(), "DataFiles");

        private static readonly string GumpNameFile = Path.Combine(DataFolder, "GumpNames.txt");

        private static readonly Dictionary<int, ArtEntity> GumpArtDict = [];

        private static readonly Dictionary<int, ArtEntity> ItemArtDict = [];

        private static readonly Dictionary<int, string> GumpNameList = [];

        public static List<string> GumpNames { get; private set; } = [];

        public static void UpdateGumpName(int key, string name)
        {
            if (GumpNameList.ContainsKey(key))
            {
                GumpNameList[key] = name;

                GumpNames[key] = $"{key}:{name}";
            }
        }

        public static ArtEntity GetArtEntity(int id, bool isGump)
        {
            if (isGump)
            {
                if (GumpArtDict.TryGetValue(id, out ArtEntity? entity))
                {
                    return entity;
                }
            }
            else
            {
                if (ItemArtDict.TryGetValue(id, out ArtEntity? entity))
                {
                    return entity;
                }
            }

            return new ArtEntity(0, "BAD_ART", 0, 0, isGump);
        }

        public UOArtLoader()
        {
            if (!string.IsNullOrEmpty(UOSettings.Default.UO_Folder))
            {
                AssetData.Load(UOSettings.Default.UO_Folder, "enu", true);

                IsLoaded = true;
            }
            else
            {
                MessageBox.Show("UO Directory Missing!", "Missing Files", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public static void ClearArt()
        {
            AssetData.Clear();
        }

        private static void LoadGumpNames()
        {
            if (!Directory.Exists(DataFolder))
            {
                Directory.CreateDirectory(DataFolder);
            }

            if (!File.Exists(GumpNameFile))
            {
                File.WriteAllText(GumpNameFile, GumpRes.GumpNames);
            }

            if (GumpNameList.Count == 0)
            {
                var names = File.ReadAllLines(GumpNameFile);

                if (names.Length > 0)
                {
                    foreach (var name in names)
                    {
                        var keyValPair = name.Split(':');

                        if (int.TryParse(keyValPair[0], out int key) && keyValPair.Length == 2)
                        {
                            if (!GumpNameList.ContainsKey(key))
                            {
                                GumpNameList.Add(key, keyValPair[1]);
                            }
                        }
                    }
                }
            }
        }

        public static void SaveGumpNames()
        {
            if (GumpNameList.Count > 0)
            {
                StringBuilder sb = new();

                foreach (var name in GumpNameList)
                {
                    sb.AppendLine($"{name.Key}:{name.Value}");
                }

                if (sb.Length > 0)
                {
                    File.WriteAllText(GumpNameFile, sb.ToString());
                }
            }
        }

        public static async Task LoadAllGumpArtAsync()
        {
            if (IsLoaded && AssetData.Gumps != null)
            {
                await Task.Run(() =>
                {
                    LoadGumpNames();

                    Bitmap? gump;

                    for (int i = 0; i < AssetData.Gumps.Length; i++)
                    {
                        gump = AssetData.Gumps.GetGump(i);

                        if (gump != null)
                        {
                            lock (GumpArtDict)
                            {
                                GumpArtDict[i] = new ArtEntity(i, GetGumpName(i), gump.Width, gump.Height, true);
                            }

                            gump.Dispose();

                            gump = null;
                        }
                        else
                        {
                            lock (GumpArtDict)
                            {
                                GumpArtDict[i] = new ArtEntity(i, "FREE_SLOT", 0, 0, true);
                            }
                        }

                        GumpNames.Add($"{GumpArtDict[i].ID}:{GumpArtDict[i].Name}");
                    }
                });
            }
        }

        public static async Task LoadAllItemArtAsync()
        {
            if (IsLoaded && AssetData.Art != null)
            {
                await Task.Run(() =>
                {
                    Bitmap? item;

                    for (int i = 0; i < AssetData.Art.MaxItemID; i++)
                    {
                        item = AssetData.Art.GetStatic(i);

                        if (item != null)
                        {
                            lock (ItemArtDict)
                            {
                                ItemArtDict[i] = new(i, GetItemName(i), item.Width, item.Height, false);
                            }

                            item.Dispose();

                            item = null;
                        }
                        else
                        {
                            lock (ItemArtDict)
                            {
                                ItemArtDict[i] = new ArtEntity(i, "FREE_SLOT", 0, 0, false);
                            }
                        }
                    }
                });
            }
        }

        private static string GetGumpName(int i)
        {
            if (GumpNameList.TryGetValue(i, out string? value))
            {
                return value;
            }
            else
            {
                return $"Image";
            }
        }

        private static string cachedName = "";

        private static string GetItemName(int i)
        {
            cachedName = AssetData.Tiles.ItemTable[i].Name;

            if (string.IsNullOrEmpty(cachedName))
            {
                return "NO_NAME";
            }
            else
            {
                return cachedName;
            }
        }

        private static List<ArtEntity>? tempEntityList;

        internal static bool GetAllArt(bool isGump, out List<ArtEntity> list)
        {
            if (isGump)
            {
                tempEntityList = [.. GumpArtDict.Values];

                return LoadList(tempEntityList, out list);
            }
            else
            {
                tempEntityList = [.. ItemArtDict.Values];

                return LoadList(tempEntityList, out list);
            }
        }

        public static bool SearchArtByID(int id, bool isGump, out List<ArtEntity> list)
        {
            int range = UOSettings.Default.DisplayMax / 2;

            if (id - range < 0)
            {
                range = id;
            }

            if (isGump)
            {
                if (id + range >= GumpArtDict.Count)
                {
                    range = Math.Abs(GumpArtDict.Count - id);
                }

                tempEntityList = GumpArtDict.Values.Where(a => a.ID <= id + range && a.ID >= id - range).ToList();

                return LoadList(tempEntityList, out list);
            }
            else
            {
                if (id + range >= ItemArtDict.Count)
                {
                    range = Math.Abs(ItemArtDict.Count - id);
                }

                tempEntityList = ItemArtDict.Values.Where(a => a.ID < id + range && a.ID > id - range).ToList();

                return LoadList(tempEntityList, out list);
            }
        }

        public static bool SearchArtByName(string name, bool isGump, out List<ArtEntity> list)
        {
            if (isGump)
            {
                tempEntityList = GumpArtDict.Values.Where(a => a.Name.Contains(name, StringComparison.CurrentCultureIgnoreCase)).ToList();

                return LoadList(tempEntityList, out list);
            }
            else
            {
                tempEntityList = ItemArtDict.Values.Where(a => a.Name.Contains(name, StringComparison.CurrentCultureIgnoreCase)).ToList();

                return LoadList(tempEntityList, out list);
            }
        }

        public static bool SearchArtBySize(int size, bool isGump, out List<ArtEntity> list, bool isWidth)
        {
            if (isGump)
            {
                if (isWidth)
                {
                    tempEntityList = GumpArtDict.Values.Where(a => a.Width == size).ToList();
                }
                else
                {
                    tempEntityList = GumpArtDict.Values.Where(a => a.Height == size).ToList();
                }

                return LoadList(tempEntityList, out list);
            }
            else
            {
                if (isWidth)
                {
                    tempEntityList = ItemArtDict.Values.Where(a => a.Width == size).ToList();
                }
                else
                {
                    tempEntityList = ItemArtDict.Values.Where(a => a.Height == size).ToList();
                }

                return LoadList(tempEntityList, out list);
            }
        }

        private static bool LoadList(List<ArtEntity> itemList, out List<ArtEntity> list )
        {
            if (itemList != null && itemList.Count > 0)
            {
                list = itemList;

                return true;
            }

            list = [];

            return false;
        }
    }
}
