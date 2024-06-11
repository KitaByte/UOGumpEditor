namespace UOGumpEditor.UOElements
{
    public class ElementControl : Control
    {
        private Image? _image;
        private Font _font;
        private Brush _textBrush;
        private ContentAlignment _textAlign;
        private Point _dragStartPoint;
        private Point _startingPoint;

        private bool _isDragging;

        public bool IsSelected { get; private set; }

        public ElementTypes ElementType { get; set; }

        public ImageLayout BGImageLayout { get; set; }

        public int GetLayer()
        {
            if (UOEditorCore.MainUI != null && UOEditorCore.MainUI.CanvasPanel.Controls.Contains(this))
            {
                return UOEditorCore.MainUI.CanvasPanel.Controls.IndexOf(this);
            }
            else
            {
                return 0;
            }
        }

        public ElementControl()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);

            BackColor = Color.Transparent;

            _font = new Font("Arial", UOSettings.Default.FontSize);

            _textBrush = Brushes.White;

            _textAlign = ContentAlignment.MiddleCenter;

            // Events
            MouseDown += ElementControl_MouseDown;
            MouseMove += ElementControl_MouseMove;
            MouseUp += ElementControl_MouseUp;
            MouseHover += ElementControl_MouseHover;
            MouseDoubleClick += ElementControl_MouseDoubleClick;
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;

                cp.ExStyle |= 0x20;

                return cp;
            }
        }

        protected override void OnMove(EventArgs e)
        {
            Update();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            var displayImage = Image;

            if (displayImage != null)
            {
                switch (BGImageLayout)
                {
                    case ImageLayout.None:
                        {
                            e.Graphics.DrawImage(displayImage, 0, 0);

                            break;
                        }

                    case ImageLayout.Tile:
                        {
                            using TextureBrush brush = new(displayImage);

                            e.Graphics.FillRectangle(brush, this.ClientRectangle);

                            break;
                        }

                    case ImageLayout.Center:
                        {
                            e.Graphics.DrawImage(displayImage, (Width - displayImage.Width) / 2, (Height - displayImage.Height) / 2);

                            break;
                        }

                    case ImageLayout.Stretch:
                        {
                            e.Graphics.DrawImage(displayImage, 0, 0, Width, Height);

                            break;
                        }

                    case ImageLayout.Zoom:
                        {
                            Size imageSize = displayImage.Size;

                            float ratio = Math.Min((float)Width / imageSize.Width, (float)Height / imageSize.Height);

                            int newWidth = (int)(imageSize.Width * ratio);

                            int newHeight = (int)(imageSize.Height * ratio);

                            e.Graphics.DrawImage(displayImage, (Width - newWidth) / 2, (Height - newHeight) / 2, newWidth, newHeight);

                            break;
                        }
                }
            }

            if (!string.IsNullOrEmpty(Text))
            {
                var textSize = e.Graphics.MeasureString(Text, _font);

                PointF textLocation = GetTextLocation(textSize);

                e.Graphics.DrawString(Text, _font, _textBrush, textLocation);
            }

            if (IsSelected)
            {
                using Pen pen = new(Color.Gold, 2);

                e.Graphics.DrawRectangle(pen, 0, 0, Width - 1, Height - 1);
            }
        }

        private PointF GetTextLocation(SizeF textSize)
        {
            float x = 0;
            float y = 0;

            switch (_textAlign)
            {
                case ContentAlignment.TopLeft:
                    {
                        x = 0;
                        y = 0;

                        break;
                    }

                case ContentAlignment.TopCenter:
                    {
                        x = (Width - textSize.Width) / 2;
                        y = 0;

                        break;
                    }

                case ContentAlignment.TopRight:
                    {
                        x = Width - textSize.Width;
                        y = 0;

                        break;
                    }

                case ContentAlignment.MiddleLeft:
                    {
                        x = 0;
                        y = (Height - textSize.Height) / 2;

                        break;
                    }

                case ContentAlignment.MiddleCenter:
                    {
                        x = (Width - textSize.Width) / 2;
                        y = (Height - textSize.Height) / 2;

                        break;
                    }

                case ContentAlignment.MiddleRight:
                    {
                        x = Width - textSize.Width;
                        y = (Height - textSize.Height) / 2;

                        break;
                    }

                case ContentAlignment.BottomLeft:
                    {
                        x = 0;
                        y = Height - textSize.Height;

                        break;
                    }

                case ContentAlignment.BottomCenter:
                    {
                        x = (Width - textSize.Width) / 2;
                        y = Height - textSize.Height;

                        break;
                    }

                case ContentAlignment.BottomRight:
                    {
                        x = Width - textSize.Width;
                        y = Height - textSize.Height;

                        break;
                    }
            }

            return new PointF(x, y);
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            // Do not paint background
        }

        public Image? Image
        {
            get
            {
                if (_image != null && (Width > _image.Width || Height > _image.Height) && ElementType != ElementTypes.Background)
                {
                    return UOEditorCore.TileImage((Bitmap)_image, new Size(Width, Height));
                }

                return _image;
            }
            set
            {
                _image = value;

                Update();
            }
        }

        public Font TextFont
        {
            get { return _font; }
            set
            {
                _font = value;

                Update();
            }
        }

        public Brush TextBrush
        {
            get { return _textBrush; }
            set
            {
                _textBrush = value;

                Update();
            }
        }

        public ContentAlignment TextAlign
        {
            get { return _textAlign; }
            set
            {
                _textAlign = value;

                Update();
            }
        }

        private static void MakeTransparent(Bitmap bitmap)
        {
            bitmap.MakeTransparent(Color.Black);
        }

        private void ElementControl_MouseDown(object? sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && UOEditorCore.MainUI != null)
            {
                _dragStartPoint = e.Location;

                _startingPoint = Location;

                _isDragging = true;

                UOEditorCore.StoreElementIndices();

                BringToFront();
            }
        }

        private void ElementControl_MouseMove(object? sender, MouseEventArgs e)
        {
            if (_isDragging)
            {
                Location = new Point(Left + e.X - _dragStartPoint.X, Top + e.Y - _dragStartPoint.Y);
            }
        }

        private void ElementControl_MouseUp(object? sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _isDragging = false;

                UOEditorCore.RestoreElementIndices();

                if (_startingPoint != Location)
                {
                    UOEditorCore.MainUI?.ElementListbox.SetSelected(GetLayer(), true);
                }
                else
                {
                    UOEditorCore.MainUI?.ElementListbox.SetSelected(GetLayer(), !IsSelected);
                }
            }
        }

        private void ElementControl_MouseHover(object? sender, EventArgs e)
        {
            if (Tag is ArtEntity entity)
            {
                UOEditorCore.MainUI?.UpdateElementInfo(entity);
            }
        }

        private void ElementControl_MouseDoubleClick(object? sender, MouseEventArgs e)
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

                tempBitmap = null;
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
            if (Parent is Panel panel)
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

        public void SetSelected(bool isSelected)
        {
            IsSelected = isSelected;

            Update();
        }

        public List<ArtEntity>? BackgroundArt { get; private set; }

        public void LoadBackground()
        {
            BackgroundArt = [];

            if (Tag is ArtEntity entity)
            {
                if (UOArtLoader.SearchArtByName(entity.Name[..^1], true, out List<ArtEntity> searchList))
                {
                    if (searchList.Count > 0)
                    {
                        foreach (ArtEntity ae in searchList)
                        {
                            if (entity.Name.Length == ae.Name.Length)
                            {
                                BackgroundArt.Add(ae);
                            }
                        }

                        if (BackgroundArt.Count > 0)
                        {
                            BackgroundArt.Sort();

                            Image = UOEditorCore.CombineBitmaps(UOEditorCore.GetImages(BackgroundArt));

                            BGImageLayout = ImageLayout.Stretch;
                        }
                    }
                }
            }
        }

        public List<ArtEntity>? ButtonArt { get; private set; }

        public void LoadButton()
        {
            ButtonArt = [];

            if (Tag is ArtEntity entity)
            {
                ButtonArt.Add(entity);

                ButtonArt.Add(UOArtLoader.GetArtEntity(entity.ID + 1, true));
            }
        }

        public override string ToString()
        {
            if (Tag is ArtEntity ae)
            {
                return $"{GetLayer()} : {(ae.IsGump ? $"G-{ae.Name}" : $"I-{ae.Name}")}";
            }
            else
            {
                return $"{GetLayer()} : {ElementType}";
            }
        }
    }
}

