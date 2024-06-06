namespace UOGumpEditor.UOElements
{
    public class TextElement : Label, IElement
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

        public TextElement()
        {
            BackColor = Color.Transparent;

            FlatStyle = FlatStyle.Flat;

            BorderStyle = BorderStyle.None;

            MouseDown += BaseElement_MouseDown;

            MouseMove += BaseElement_MouseMove;

            MouseUp += BaseElement_MouseUp;

            MouseDoubleClick += ImageElement_MouseDoubleClick;
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

                BringToFront();
            }
        }

        private void ImageElement_MouseDoubleClick(object? sender, MouseEventArgs e)
        {
            UOEditorCore.MainUI?.OpenTextEntry(ElementType, this);
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

        public string? GetText()
        {
            return Text;
        }
    }
}
