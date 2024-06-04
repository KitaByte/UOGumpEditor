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

        public static ArtEntity? LoadGumpArt(int gumpID)
        {
            if (IsLoaded && AssetData.Gumps != null)
            {
                if (GumpArtDict.Count == 0)
                {
                    for (int i = 0; i < AssetData.Gumps.Length; i++)
                    {
                        Bitmap? gump = AssetData.Gumps.GetGump(i);

                        if (gump != null)
                        {
                            GumpArtDict.Add(i, new ArtEntity(i, GetGumpName(i), gump, gump.Width, gump.Height));
                        }
                        else
                        {
                            GumpArtDict.Add(i, new ArtEntity(i, "FREE_SLOT", null));
                        }
                    }
                }

                return GumpArtDict[gumpID];
            }
            else
            {
                return null;
            }
        }

        private static string GetGumpName(int i)
        {
            // Get Element Name for Art : ie: Button

            return $"Gump_{i}";
        }

        public static ArtEntity? LoadItemArt(int itemID)
        {
            try
            {
                if (IsLoaded && itemID < AssetData.Art.MaxItemID)
                {
                    if (ItemArtDict.Count == 0)
                    {
                        for (int i = 0; i < AssetData.Art.MaxItemID; i++)
                        {
                            Bitmap? itemBitmap = AssetData.Art.GetStatic(i);

                            if (itemBitmap != null)
                            {
                                AssetData.Art.Measure(itemBitmap, out int minX, out int minY, out int maxX, out int maxY);

                                ItemArtDict.Add(i, new ArtEntity(i, GetItemName(i), itemBitmap, maxX - minX, maxY - minY));
                            }
                            else
                            {
                                ItemArtDict.Add(i, new ArtEntity(i, "FREE_SLOT", null));
                            }
                        }
                    }

                    return ItemArtDict[itemID];
                }
            }
            catch
            {
                // do nothing!
            }

            if (ItemArtDict.Count > 0)
            {
                return ItemArtDict[0];
            }

            return null;
        }

        private static string GetItemName(int i)
        {
            return AssetData.Tiles.ItemTable[i].Name;
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

            return new ArtEntity(id, "BAD_ART", null);
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
