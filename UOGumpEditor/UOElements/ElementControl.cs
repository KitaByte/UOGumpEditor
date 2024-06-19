namespace UOGumpEditor.UOElements
{
    public class ElementControl : Control
    {
        private Image? _image;
        private Font _font;
        private Brush _textBrush;
        private ContentAlignment _textAlign;

        private bool _isDragging;
        private Point _dragStartPoint;
        private Point _startingPoint;

        private Bitmap? tempBitmap;

        public bool IsSelected { get; private set; }

        public void SetSelected(bool isSelected)
        {
            IsSelected = isSelected;

            UOEditorCore.Session.UpdateSelected(this, Location);

            Update();
        }

        public ElementTypes ElementType { get; set; }

        public ImageLayout BGImageLayout { get; set; }

        public List<ArtEntity>? BackgroundList { get; private set; }

        public List<ArtEntity>? ButtonList { get; private set; }

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

        public Color TextColor
        {
            get { return (_textBrush as SolidBrush)?.Color ?? Color.White; }
            set
            {
                _textBrush = new SolidBrush(value);

                ForeColor = value;

                Invalidate();
            }
        }

        public ElementControl()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);

            BackColor = Color.Transparent;

            _font = new Font("Arial", UOSettings.Default.FontSize);

            _textBrush = Brushes.White;

            _textAlign = ContentAlignment.MiddleCenter;

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
                PointF textLocation = GetTextLocation(e.Graphics.MeasureString(Text, _font));

                e.Graphics.DrawString(Text, _font, _textBrush, textLocation);
            }

            if (IsSelected)
            {
                using Pen pen = new(Color.Gold, 2);

                e.Graphics.DrawRectangle(pen, 0, 0, Width - 1, Height - 1);
            }
        }

        public int GetLayer()
        {
            if (UOEditorCore.Session.CanvasUI.Controls.Contains(this))
            {
                return UOEditorCore.Session.CanvasUI.Controls.IndexOf(this);
            }
            else
            {
                return 0;
            }
        }

        public (int X, int Y, int Z) GetLocation(int z = -1)
        {
            if (z == -1)
            {
                z = GetLayer();
            }

            if (Parent is Panel panel)
            {
                return (Location.X + panel.Location.X, Location.Y + panel.Location.Y, z);
            }
            else
            {
                return (Location.X, Location.Y + 26, z);
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

        private static void MakeTransparent(Bitmap bitmap)
        {
            bitmap.MakeTransparent(Color.Black);
        }

        private void ElementControl_MouseDown(object? sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _dragStartPoint = e.Location;

                _startingPoint = Location;

                _isDragging = true;
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

                if (_startingPoint != Location)
                {
                    UOEditorCore.Session.ElementUI.ElementListbox.SetSelected(GetLayer(), true);
                }
                else
                {
                    UOEditorCore.Session.ElementUI.ElementListbox.SetSelected(GetLayer(), !IsSelected);
                }

                Invalidate();
            }
        }

        private void ElementControl_MouseHover(object? sender, EventArgs e)
        {
            if (Tag is ArtEntity entity)
            {
                UOEditorCore.Session.UpdateElementInfo(entity, this);
            }
        }

        private void ElementControl_MouseDoubleClick(object? sender, MouseEventArgs e)
        {
            UOEditorCore.OpenElementEditor(ElementType, this);
        }

        public void SetImage(ArtEntity entity)
        {
            tempBitmap = entity.GetImage();

            if (tempBitmap != null)
            {
                MakeTransparent(tempBitmap);

                Image = tempBitmap;

                if (Width < entity.Width)
                {
                    Width = entity.Width;
                }

                if (Height < entity.Height)
                {
                    Height = entity.Height;
                }

                tempBitmap = null;
            }

            Invalidate();
        }

        public void SetText(string text, Color hue)
        {
            Text = text;

            TextFont = new Font(FontFamily.GenericSansSerif, 11.25f, FontStyle.Bold);

            TextColor = hue;

            TextAlign = ContentAlignment.MiddleCenter;

            Size size = UOEditorCore.GetTextSize(text, Font);

            Width = size.Width + 20;

            Height = size.Height + 10;

            Invalidate();
        }

        public async void LoadBackground()
        {
            BackgroundList = [];

            if (Tag is ArtEntity entity)
            {
                List<ArtEntity> searchList = await UOArtLoader.SearchArtByNameAsync(entity.Name[..^1], true);

                if (searchList.Count > 0)
                {
                    foreach (ArtEntity ae in searchList)
                    {
                        if (entity.Name.Length == ae.Name.Length)
                        {
                            BackgroundList.Add(ae);
                        }
                    }

                    if (BackgroundList.Count > 0)
                    {
                        BackgroundList.Sort();

                        Image = UOEditorCore.CombineBitmaps(UOEditorCore.GetImages(BackgroundList));

                        BGImageLayout = ImageLayout.Stretch;
                    }
                }
            }

            Invalidate();
        }

        public void LoadButton()
        {
            ButtonList = [];

            if (Tag is ArtEntity entity)
            {
                ButtonList.Add(entity);

                ButtonList.Add(UOArtLoader.GetArtEntity(entity.ID + 1, true));
            }

            Invalidate();
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

        public ElementControl? Copy()
        {
            ElementControl copy = new()
            {
                Size = Size, 
                ElementType = ElementType,
                BGImageLayout = BGImageLayout,
                Font = Font,
                TextAlign = TextAlign,
                TextColor = TextColor,
                Text = Text
            };

            if (Image != null)
            {
                copy.Image = new Bitmap(Image); 
            }

            if (Tag is ArtEntity entity)
            {
                ArtEntity newEntity = new(entity.ID, entity.Name, entity.Width, entity.Height, entity.IsGump);

                copy.Tag = newEntity;
            }

            return copy;
        }
    }
}

