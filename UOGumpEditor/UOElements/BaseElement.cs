
namespace UOGumpEditor.UOElements
{
    public class BaseElement : TransparentControl
    {
        public ElementTypes ElementType { get; set; }

        private Point _dragStartPoint;

        private bool _isDragging;

        public int GetLayer()
        {
            if (UOEditorCore.Z_Layer.Contains(this))
            {
                return UOEditorCore.Z_Layer.IndexOf(this);
            }
            else
            {
                return 0;
            }
        }

        public BaseElement()
        {
            MouseDown += BaseElement_MouseDown;

            MouseMove += BaseElement_MouseMove;

            MouseUp += BaseElement_MouseUp;

            MouseHover += BaseElement_MouseHover;

            MouseDoubleClick += BaseElement_MouseDoubleClick;
        }

        private static void MakeTransparent(Bitmap bitmap)
        {
            bitmap.MakeTransparent(Color.Black);
        }

        private void BaseElement_MouseDown(object? sender, MouseEventArgs e)
        {
            UOEditorCore.UpdateElementMove(this);

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

                UOEditorCore.ReorderZLayers();
            }
        }

        private void BaseElement_MouseHover(object? sender, EventArgs e)
        {
            if (Tag is ArtEntity ae)
            {
                UOEditorCore.MainUI?.UpdateElementInfo(ae);
            }
        }

        private void BaseElement_MouseDoubleClick(object? sender, MouseEventArgs e)
        {
            if (ElementType == ElementTypes.Label || ElementType == ElementTypes.Html)
            {
                UOEditorCore.MainUI?.OpenTextEntry(ElementType, this);
            }
            else
            {
                UOEditorCore.MainUI?.OpenImageEditor(ElementType, this);
            }
        }

        Bitmap? tempBitmap;

        public void SetImage(ArtEntity entity)
        {
            tempBitmap = entity.GetImage();

            if (tempBitmap != null)
            {
                MakeTransparent(tempBitmap);

                Image = tempBitmap;

                Width = entity.Width;

                Height = entity.Height;
            }

            Invalidate();
        }

        public void SetText(string text, Color hue)
        {
            Text = text;

            Font = new Font(FontFamily.GenericSansSerif, 11.25f, FontStyle.Bold);

            ForeColor = hue;

            Size size = UOEditorCore.GetTextSize(text, Font);

            Width = size.Width;

            Height = size.Height;
        }

        public (int X, int Y) GetLocation()
        {
            if (Parent != null && Parent is Panel panel)
            {
                return (Location.X + panel.Location.X, Location.Y + panel.Location.Y);
            }
            else
            {
                return (Location.X, Location.Y + 26);
            }
        }

        public Image? GetImage()
        {
            return Image;
        }

        private List<ArtEntity>? BackgroundArt;

        public void LoadBackground()
        {
            BackgroundArt = [];

            if (Tag != null && Tag is ArtEntity ae)
            {
                if (UltimaArtLoader.SearchArtByName(ae.Name[..^1], true, out List<ArtEntity> searchList))
                {
                    if (searchList.Count > 0)
                    {
                        foreach (ArtEntity entity in searchList)
                        {
                            BackgroundArt.Add(entity);
                        }

                        if (BackgroundArt.Count > 0)
                        {
                            BackgroundArt.Sort();
                        }
                    }
                }
            }
        }

        private List<ArtEntity>? ButtonArt;

        public void LoadButton()
        {
            ButtonArt = [];

            if (Tag != null && Tag is ArtEntity ae)
            {
                ButtonArt.Add(ae);

                ButtonArt.Add(UltimaArtLoader.GetArtEntity(ae.ID + 1, true));
            }
        }
    }
}
