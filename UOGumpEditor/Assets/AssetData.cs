namespace UOGumpEditor.Assets
{
    public static class AssetData
    {
        public static ArtData Art { get; } = new();

        public static ClilocData Clilocs { get; } = new();

        public static GumpData Gumps { get; } = new();

        public static HueData Hues { get; } = new();

        public static TileData Tiles { get; } = new();

        public static void Clear()
        {
            Art.Clear();

            Clilocs.Clear();

            Gumps.Clear();

            Hues.Clear();

            Tiles.Clear();
        }

        public static void Load(string directoryPath, string language, bool uop)
        {
            Art.Load(directoryPath, uop);

            Clilocs.Load(directoryPath, language);

            Gumps.Load(directoryPath, uop);

            Hues.Load(directoryPath);

            Tiles.Load(directoryPath);
        }
    }
}
