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

            UOEditorCore.InitElement(ELEMENT, ElementComboBox, HueButton);

            ElementComboBox.SelectedIndex = ElementComboBox.Items.IndexOf(ELEMENT);

            if (IMAGEELEMENT != null)
            {
                if (IMAGEELEMENT.Tag is ArtEntity entity)
                {
                    IDTextbox.Text = entity.ID.ToString();

                    WidthTextbox.Text = entity.Width.ToString();

                    HeightTextbox.Text = entity.Height.ToString();

                    HueTextbox.Text = entity.Hue.ToString();
                }
                else
                {
                    HueTextbox.Text = IMAGEELEMENT.ForeColor.ToArgb().ToString();
                }
            }
        }

        private void ElementComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IMAGEELEMENT != null)
            {
                if (ElementComboBox.SelectedItem is ElementTypes selectedElement)
                {
                    IMAGEELEMENT.ElementType = selectedElement;
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
            if (IMAGEELEMENT != null && int.TryParse(WidthTextbox.Text, out int val))
            {
                IMAGEELEMENT.Width = val;

                SendValueUpdatedMsg("Width");
            }
        }

        private void HeightButton_Click(object sender, EventArgs e)
        {
            if (IMAGEELEMENT != null && int.TryParse(HeightTextbox.Text, out int val))
            {
                IMAGEELEMENT.Height = val;

                SendValueUpdatedMsg("Height");
            }
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
            if (IMAGEELEMENT != null && UOEditorCore.Z_Layer.Contains(IMAGEELEMENT))
            {
                if (MessageBox.Show("Delete element?", "Warning!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    UOEditorCore.MainUI?.RemoveFromCanvas(IMAGEELEMENT);

                    Close();
                }
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
