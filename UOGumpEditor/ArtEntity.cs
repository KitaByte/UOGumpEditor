using UOGumpEditor.Assets;

namespace UOGumpEditor
{
    public class ArtEntity(int id, string name, int w, int h, bool isGump)
    {
        public bool IsGump { get; set; } = isGump;
        public int ID { get; set; } = id;
        public string Name { get; set; } = name;
        public int Width { get; set; } = w;
        public int Height { get; set; } = h;

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
    }
}
