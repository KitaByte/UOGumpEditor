using UOGumpEditor.Assets;

namespace UOGumpEditor
{
    public class ArtEntity(int id, string name, int w, int h, bool isGump)
    {
        public bool IsGump { get; init; } = isGump;
        public int ID { get; init; } = id;
        public string Name { get; init; } = name;
        public int Width { get; init; } = w;
        public int Height { get; init; } = h;

        public Bitmap? GetImage()
        {
            if (IsGump)
            {
                return AssetData.Gumps.GetGump(ID);
            }
            else
            {
                return AssetData.Art.GetStatic(ID);
            }
        }

        public override string ToString()
        {
            return $"{(IsGump ? "Gump" : "Item")} : {ID}";
        }
    }
}
