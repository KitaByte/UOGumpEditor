namespace UOGumpEditor.UOElements
{
    public enum ElementTypes
    {
        AlphaRegion,
        Background,
        Image,
        TiledImage,
        Item,
        Button,
        RadioButton,
        CheckBox,
        TextEntry,
        TextEntryLimited,
        Html,
        Label,
        LabelCropped
    }

    public class BaseElement : Button
    {
        public ElementTypes ElementType { get; set; }

        private static List<BaseElement> Z_Layer = [];

        private int _TextMaxChar = -1;

        public int GetLayer()
        {
            return Z_Layer.IndexOf(this);
        }

        public BaseElement()
        {
            Z_Layer.Add(this);
        }

        public void SetElement(ArtEntity entity)
        {
            BackgroundImage = entity.GetImage();

            Width = entity.Width;

            Height = entity.Height;
        }

        public void SetTextElement(string text, int max = -1)
        {
            Text = text;

            TextAlign = ContentAlignment.MiddleCenter;

            Width = text.Length * 3;

            Height = 16;

            if (max > -1)
            {
                _TextMaxChar = max;
            }
        }

        public (int X, int Y) GetLocation()
        {
            if (Parent != null && Parent is Panel panel)
            {
                return (Location.X + panel.Location.X, Location.Y + panel.Location.Y);
            }
            else
            {
                return (Location.X + 5, Location.Y + 50);
            }
        }

        public Image? GetImage()
        {
            return BackgroundImage;
        }
    }
}
