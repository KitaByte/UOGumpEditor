using UOGumpEditor.Assets;
using UOGumpEditor.UOElements;

namespace UOGumpEditor
{
    public partial class UOImageEditor : Form
    {
        private readonly ElementControl? IMAGEELEMENT;

        private readonly ElementTypes ELEMENT;

        public UOImageEditor(ElementTypes element, ElementControl? imageElement = null)
        {
            InitializeComponent();

            IMAGEELEMENT = imageElement;

            ELEMENT = element;
        }

        private void UOImageEditor_Load(object sender, EventArgs e)
        {
            HueButton.Visible = false;

            UOEditorCore.InitElement(ELEMENT, HueButton);

            if (IMAGEELEMENT != null)
            {
                if (IMAGEELEMENT.Tag is ArtEntity entity)
                {
                    IDTextbox.Text = entity.ID.ToString();

                    WidthTextbox.Text = IMAGEELEMENT.Width.ToString();

                    HeightTextbox.Text = IMAGEELEMENT.Height.ToString();

                    HueTextbox.Text = entity.Hue.ToString();
                }
                else
                {
                    HueTextbox.Text = IMAGEELEMENT.ForeColor.ToArgb().ToString();
                }
            }
        }

        private void IDButton_Click(object sender, EventArgs e)
        {
            if (IMAGEELEMENT?.Tag is ArtEntity)
            {
                if (int.TryParse(IDTextbox.Text, out int val))
                {
                    IMAGEELEMENT.Tag = UOArtLoader.GetArtEntity(val, ELEMENT != ElementTypes.Item);

                    if (IMAGEELEMENT.Tag is ArtEntity nae)
                    {
                        IMAGEELEMENT.SetImage(nae);

                        IMAGEELEMENT.Invalidate();
                    }

                    SendValueUpdatedMsg("ID");
                }
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
            if (IMAGEELEMENT != null && int.TryParse(WidthTextbox.Text, out int width))
            {
                IMAGEELEMENT.Width = width;
            }

            if (IMAGEELEMENT != null && int.TryParse(HeightTextbox.Text, out int height))
            {
                IMAGEELEMENT.Height = height;
            }

            if (IMAGEELEMENT?.Tag is ArtEntity entity)
            {
                if (IMAGEELEMENT.ElementType == ElementTypes.Image && (entity.Width < IMAGEELEMENT.Width || entity.Height < IMAGEELEMENT.Height))
                {
                    IMAGEELEMENT.ElementType = ElementTypes.TiledImage;
                }
                else if (IMAGEELEMENT.ElementType == ElementTypes.TiledImage && (entity.Width >= IMAGEELEMENT.Width && entity.Height >= IMAGEELEMENT.Height))
                {
                    IMAGEELEMENT.ElementType = ElementTypes.Image;
                }
            }

            SendValueUpdatedMsg("Size");
        }

        private void HueButton_Click(object sender, EventArgs e)
        {
            if (IMAGEELEMENT != null && int.TryParse(HueTextbox.Text, out int val))
            {
                if (IMAGEELEMENT.Tag is ArtEntity ae)
                {
                    Bitmap? image = ae.GetImage();

                    if (image != null)
                    {
                        ae.Hue = val;

                        AssetData.Hues.ApplyTo(image, val, false);

                        IMAGEELEMENT.Image = image;

                        IMAGEELEMENT.Invalidate();
                    }
                }
                else
                {
                    IMAGEELEMENT.ForeColor = Color.FromArgb(val);
                }

                SendValueUpdatedMsg("Hue");
            }
        }

        private static void SendValueUpdatedMsg(string name)
        {
            MessageBox.Show($"{name} Updated!", "Element Editor", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (UOEditorCore.MainUI != null && IMAGEELEMENT != null)
            {
                if (UOEditorCore.MainUI.CanvasPanel.Controls.Contains(IMAGEELEMENT))
                {
                    if (MessageBox.Show("Delete element?", "Warning!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                    {
                        UOEditorCore.MainUI?.RemoveFromCanvas(IMAGEELEMENT);

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
