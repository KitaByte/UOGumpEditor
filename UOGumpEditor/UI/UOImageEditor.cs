using UOGumpEditor.Assets;
using UOGumpEditor.UOElements;

namespace UOGumpEditor
{
    public partial class UOImageEditor : Form
    {
        private readonly ElementControl? _ElementControl;

        private readonly ElementTypes _ElementType;

        public UOImageEditor(ElementTypes element, ElementControl? elementControl = null)
        {
            InitializeComponent();

            _ElementControl = elementControl;

            _ElementType = element;
        }

        private void UOImageEditor_Load(object sender, EventArgs e)
        {
            IDPanel.Visible = false;

            TextPanel.Visible = false;

            HuePanel.Visible = false;

            UOEditorCore.InitElement(_ElementType, IDPanel, TextPanel, HuePanel);

            if (_ElementType == ElementTypes.Html)
            {
                TextPanel.Height *= 4;

                TextTextbox.ScrollBars = ScrollBars.Both;

                TextTextbox.AcceptsReturn = true;

                TextTextbox.Multiline = true;

                TextTextbox.MaxLength *= 10;

                TextTextbox.PlaceholderText = "HTML";
            }

            if (_ElementControl != null)
            {
                if (_ElementControl.Tag is ArtEntity entity)
                {
                    IDTextbox.Text = entity.ID.ToString();

                    HueTextbox.Text = entity.Hue.ToString();
                }
                else
                {
                    TextTextbox.Text = _ElementControl.Text;

                    TextTextbox.ForeColor = _ElementControl.TextColor;

                    HueTextbox.Text = UOEditorCore.GetNumberFromColor(_ElementControl.TextColor).ToString();

                    if (_ElementControl.TextColor == Color.White)
                    {
                        TextTextbox.BackColor = Color.Black;
                    }
                }

                WidthTextbox.Text = _ElementControl.Width.ToString();

                HeightTextbox.Text = _ElementControl.Height.ToString();
            }
        }

        private void IDButton_Click(object sender, EventArgs e)
        {
            if (_ElementControl?.Tag is ArtEntity)
            {
                if (int.TryParse(IDTextbox.Text, out int val))
                {
                    _ElementControl.Tag = UOArtLoader.GetArtEntity(val, _ElementType != ElementTypes.Item);

                    if (_ElementControl.Tag is ArtEntity nae)
                    {
                        _ElementControl.SetImage(nae);
                    }

                    SendValueUpdatedMsg("ID", _ElementControl);
                }
            }
        }

        private void TextButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TextTextbox.Text))
            {
                if (_ElementControl == null)
                {
                    UOEditorCore.MainUI?.AddTextElement(TextTextbox.Text, Color.White, _ElementType);

                    Close();
                }
                else
                {
                    _ElementControl.Text = TextTextbox.Text;

                    _ElementControl.TextColor = TextTextbox.ForeColor;
                }

                SendValueUpdatedMsg("Text", _ElementControl);
            }
        }

        private void WidthButton_Click(object sender, EventArgs e)
        {
            UpdateSize();
        }

        private void HeightButton_Click(object sender, EventArgs e)
        {
            UpdateSize();
        }

        private void UpdateSize()
        {
            if (_ElementControl != null && int.TryParse(WidthTextbox.Text, out int width))
            {
                _ElementControl.Width = width;
            }

            if (_ElementControl != null && int.TryParse(HeightTextbox.Text, out int height))
            {
                _ElementControl.Height = height;
            }

            if (_ElementControl?.Tag is ArtEntity entity)
            {
                if (_ElementControl.ElementType == ElementTypes.Image && (entity.Width < _ElementControl.Width || entity.Height < _ElementControl.Height))
                {
                    _ElementControl.ElementType = ElementTypes.TiledImage;
                }
                else if (_ElementControl.ElementType == ElementTypes.TiledImage && (entity.Width >= _ElementControl.Width && entity.Height >= _ElementControl.Height))
                {
                    _ElementControl.ElementType = ElementTypes.Image;
                }
            }

            SendValueUpdatedMsg("Size", _ElementControl);
        }

        private void HueButton_Click(object sender, EventArgs e)
        {
            if (_ElementControl != null && int.TryParse(HueTextbox.Text, out int val))
            {
                if (_ElementControl.Tag is ArtEntity ae)
                {
                    Bitmap? image = ae.GetImage();

                    if (image != null)
                    {
                        ae.Hue = val;

                        AssetData.Hues.ApplyTo(image, val, false);

                        _ElementControl.Image = image;
                    }
                }
                else
                {
                    _ElementControl.TextColor = UOEditorCore.GetColorFromNumber(val);

                    TextTextbox.ForeColor = _ElementControl.TextColor;
                }

                SendValueUpdatedMsg("Hue", _ElementControl);
            }
        }

        private static void SendValueUpdatedMsg(string name, ElementControl? element)
        {
            element?.Invalidate();

            MessageBox.Show($"{name} Updated!", "Element Editor", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (UOEditorCore.MainUI != null && _ElementControl != null)
            {
                if (UOEditorCore.MainUI.CanvasPanel.Controls.Contains(_ElementControl))
                {
                    if (MessageBox.Show("Delete element?", "Warning!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                    {
                        UOEditorCore.MainUI?.RemoveFromCanvas(_ElementControl);

                        Close();
                    }
                }
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
