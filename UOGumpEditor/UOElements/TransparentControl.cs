namespace UOGumpEditor.UOElements
{
    public class TransparentControl : Control
    {
        private Image? _image;

        private Font _font;

        private Brush _textBrush;

        private ContentAlignment _textAlign;

        public TransparentControl()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);

            BackColor = Color.Transparent;

            _font = new Font("Arial", 10);

            _textBrush = Brushes.White;

            _textAlign = ContentAlignment.MiddleCenter;
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

            if (_image != null)
            {
                e.Graphics.DrawImage(_image, (Width / 2) - (_image.Width / 2), (Height / 2) - (_image.Height / 2));
            }

            if (!string.IsNullOrEmpty(Text))
            {
                var textSize = e.Graphics.MeasureString(Text, _font);

                PointF textLocation = GetTextLocation(textSize);

                e.Graphics.DrawString(Text, _font, _textBrush, textLocation);
            }
        }

        private PointF GetTextLocation(SizeF textSize)
        {
            float x = 0;
            float y = 0;

            switch (_textAlign)
            {
                case ContentAlignment.TopLeft:
                    x = 0;
                    y = 0;
                    break;

                case ContentAlignment.TopCenter:
                    x = (Width - textSize.Width) / 2;
                    y = 0;
                    break;

                case ContentAlignment.TopRight:
                    x = Width - textSize.Width;
                    y = 0;
                    break;

                case ContentAlignment.MiddleLeft:
                    x = 0;
                    y = (Height - textSize.Height) / 2;
                    break;

                case ContentAlignment.MiddleCenter:
                    x = (Width - textSize.Width) / 2;
                    y = (Height - textSize.Height) / 2;
                    break;

                case ContentAlignment.MiddleRight:
                    x = Width - textSize.Width;
                    y = (Height - textSize.Height) / 2;
                    break;

                case ContentAlignment.BottomLeft:
                    x = 0;
                    y = Height - textSize.Height;
                    break;

                case ContentAlignment.BottomCenter:
                    x = (Width - textSize.Width) / 2;
                    y = Height - textSize.Height;
                    break;

                case ContentAlignment.BottomRight:
                    x = Width - textSize.Width;
                    y = Height - textSize.Height;
                    break;
            }

            return new PointF(x, y);
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            // Do not paint background
        }

        public Image? Image
        {
            get { return _image; }
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
    }
}
