using UOGumpEditor.Assets;

namespace UOGumpEditor.UOElements
{
    public class TextElement : Label
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

        private void ImageElement_MouseDoubleClick(object? sender, MouseEventArgs e)
        {
            UOEditorCore.MainUI?.OpenTextEntry(this);
        }

        public void SetText(string text, int hue = 0)
        {
            Text = text;

            Font = new Font(FontFamily.GenericSerif, 9.75f, FontStyle.Bold);

            if (hue > 0)
            {
                var color = AssetData.Hues.GetHue(hue);

                ForeColor = AssetData.Hues.Entries[53].Colors.First();
            }
            else
            {
                ForeColor = Color.White;
            }

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
