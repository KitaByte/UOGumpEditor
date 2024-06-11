using UOGumpEditor.UOElements;

namespace UOGumpEditor.UOGumps
{
    [Serializable]
    public class GumpElement
    {
        public string Text { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public Point Location { get; set; } = Point.Empty;
        public Size Size { get; set; } = Size.Empty;
        public int Layer { get; set; } = 0;
        public Color Color { get; set; } = Color.Empty;

        public int ArtID { get; set; } = 0;
        public string ArtName { get; set; } = string.Empty;
        public int ArtWidth { get; set; } = 0;
        public int ArtHeight { get; set; } = 0;
        public int ArtHue { get; set; } = 0;
        public bool IsGump { get; set; } = true;

        public GumpElement()
        {
        }

        public GumpElement(ElementControl control)
        {
            Text = control.Text;
            Type = control.ElementType.ToString();
            Location = control.Location;
            Size = control.Size;
            Layer = control.GetLayer();
            Color = control.ForeColor;

            if (control.Tag is ArtEntity ae)
            {
                ArtID = ae.ID;
                ArtName = ae.Name;
                ArtWidth = ae.Width;
                ArtHeight = ae.Height;
                ArtHue = ae.Hue;
                IsGump = ae.IsGump;
            }
        }

        public ArtEntity? ToArtEntity()
        {
            if (ArtID == 0 && ArtWidth == 0 && ArtHeight == 0)
            {
                return null;
            }

            return new ArtEntity(ArtID, ArtName, ArtWidth, ArtHeight, IsGump) { Hue = ArtHue };
        }
    }
}

