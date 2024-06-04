using UOGumpEditor.Assets;

namespace UOGumpEditor
{
    public class UltimaArtLoader
    {
        public static bool IsLoaded { get; private set; } = false;

        private static readonly Dictionary<int, ArtEntity> GumpArtDict = [];

        private static readonly Dictionary<int, ArtEntity> ItemArtDict = [];

        public UltimaArtLoader()
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

        public void ClearArt()
        {
            AssetData.Clear();
        }

        public static async Task LoadAllGumpArtAsync()
        {
            if (IsLoaded && AssetData.Gumps != null)
            {
                await Task.Run(() =>
                {
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
                            AssetData.Art.Measure(item, out int minX, out int minY, out int maxX, out int maxY);

                            lock (ItemArtDict)
                            {
                                ItemArtDict[i] = new ArtEntity(i, GetItemName(i), maxX - minX, maxY - minY, false);
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
            // Get Element Name for Art : ie: Button

            return $"Gump_{i}";
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

        public static ArtEntity? LoadGumpArt(int gumpID)
        {
            if (IsLoaded && GumpArtDict.TryGetValue(gumpID, out ArtEntity? value))
            {
                return value;
            }
            else
            {
                return null;
            }
        }

        public static ArtEntity? LoadItemArt(int itemID)
        {
            if (IsLoaded && ItemArtDict.TryGetValue(itemID, out ArtEntity? value))
            {
                return value;
            }
            else
            {
                return null;
            }
        }

        public static ArtEntity GetArtByID(int id, bool isGump)
        {
            if (isGump)
            {
                if (GumpArtDict.TryGetValue(id, out var entity))
                {
                    return entity;
                }
            }
            else
            {
                if (ItemArtDict.TryGetValue(id, out var entity))
                {
                    return entity;
                }
            }

            return new ArtEntity(id, "BAD_ART", 0, 0, isGump);
        }

        public static bool SearchArtByName(string name, bool isGump, out List<ArtEntity> list)
        {
            if (isGump)
            {
                var gumpList = GumpArtDict.Values.Where(a => a.Name.Contains(name, StringComparison.CurrentCultureIgnoreCase)).ToList();

                return LoadList(gumpList, out list);
            }
            else
            {
                var itemList = ItemArtDict.Values.Where(a => a.Name.Contains(name, StringComparison.CurrentCultureIgnoreCase)).ToList();

                return LoadList(itemList, out list);
            }
        }

        public static bool SearchArtBySize(int size, bool isGump, out List<ArtEntity> list)
        {
            if (isGump)
            {
                var gumpList = GumpArtDict.Values.Where(a => a.Width == size).ToList();

                return LoadList(gumpList, out list);
            }
            else
            {
                var itemList = ItemArtDict.Values.Where(a => a.Width == size).ToList();

                return LoadList(itemList, out list);
            }
        }

        private const int MaxLoad = 40;

        private static bool LoadList(List<ArtEntity> itemList, out List<ArtEntity> list )
        {
            if (itemList != null && itemList.Count > 0)
            {
                if (itemList.Count > MaxLoad)
                {
                    list = itemList.GetRange(0, MaxLoad);
                }
                else
                {
                    list = itemList;
                }

                return true;
            }

            list = [];

            return false;
        }
    }
}
