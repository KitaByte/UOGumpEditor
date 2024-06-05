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

    public class BaseElement : TransparentControl
    {
        public ElementTypes ElementType { get; set; }

        private static readonly List<BaseElement> Z_Layer = [];

        public static void ResetGumpElements()
        {
            Z_Layer.Clear();
        }

        private int _TextMaxChar = -1;

        private Point _dragStartPoint;

        private bool _isDragging;

        public int GetLayer()
        {
            return Z_Layer.IndexOf(this);
        }

        public BaseElement()
        {
            BackColor = Color.Transparent;

            Z_Layer.Add(this);

            MouseDown += BaseElement_MouseDown;

            MouseMove += BaseElement_MouseMove;

            MouseUp += BaseElement_MouseUp;
        }

        private static void MakeTransparent(Bitmap bitmap)
        {
            bitmap.MakeTransparent(Color.Black);
        }

        private void BaseElement_MouseDown(object? sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _dragStartPoint = e.Location;

                _isDragging = true;

                BringToFront(); 
            }
        }

        private void BaseElement_MouseMove(object? sender, MouseEventArgs e)
        {
            if (_isDragging)
            {
                Location = new((Left + e.X - _dragStartPoint.X), (Top + e.Y - _dragStartPoint.Y));
            }
        }

        private void BaseElement_MouseUp(object? sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _isDragging = false;

                ReorderZLayers();
            }
        }

        private static void ReorderZLayers()
        {
            for (int i = 0; i < Z_Layer.Count; i++)
            {
                Z_Layer[i].SendToBack();
            }

            Z_Layer[0].Parent?.Invalidate();
        }

        public void SetElement(ArtEntity entity)
        {
            Bitmap? tempBitmap = entity.GetImage();

            if (tempBitmap != null)
            {
                MakeTransparent(tempBitmap);

                Image = tempBitmap;

                Width = entity.Width;

                Height = entity.Height;
            }
        }

        public void SetTextElement(string text, int max = -1)
        {
            Text = text;

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
            return Image;
        }
    }
}
