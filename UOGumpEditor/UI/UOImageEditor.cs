using UOGumpEditor.Assets;
using UOGumpEditor.UOElements;

namespace UOGumpEditor
{
    public partial class UOImageEditor : Form
    {
        private readonly ImageElement? IMAGEELEMENT;

        private readonly ElementTypes ELEMENT;

        private int MaxTextLength = 0;

        public UOImageEditor(ElementTypes element, ImageElement? imageElement = null)
        {
            InitializeComponent();

            IMAGEELEMENT = imageElement;

            ELEMENT = element;
        }

        private void UOImageEditor_Load(object sender, EventArgs e)
        {
            HueButton.Visible = false;
            MaxButton.Visible = false;

            switch (ELEMENT)
            {
                case ElementTypes.AlphaRegion:
                    ElementComboBox.Items.Add(ElementTypes.AlphaRegion);
                    break;
                case ElementTypes.Background:
                    ElementComboBox.Items.Add(ElementTypes.Background);
                    ElementComboBox.Items.Add(ElementTypes.TiledImage);
                    HueButton.Visible = true;
                    break;
                case ElementTypes.Button:
                    ElementComboBox.Items.Add(ElementTypes.Button);
                    break;
                case ElementTypes.CheckBox:
                    ElementComboBox.Items.Add(ElementTypes.CheckBox);
                    break;
                case ElementTypes.Image:
                    ElementComboBox.Items.Add(ElementTypes.Image);
                    ElementComboBox.Items.Add(ElementTypes.TiledImage);
                    HueButton.Visible = true;
                    break;
                case ElementTypes.Item:
                    ElementComboBox.Items.Add(ElementTypes.Item);
                    HueButton.Visible = true;
                    break;
                case ElementTypes.RadioButton:
                    ElementComboBox.Items.Add(ElementTypes.RadioButton);
                    break;
                case ElementTypes.TextEntry:
                    ElementComboBox.Items.Add(ElementTypes.TextEntry);
                    ElementComboBox.Items.Add(ElementTypes.TextEntryLimited);
                    break;
                case ElementTypes.TextEntryLimited:
                    ElementComboBox.Items.Add(ElementTypes.TextEntry);
                    ElementComboBox.Items.Add(ElementTypes.TextEntryLimited);
                    MaxButton.Visible = true;
                    break;
                case ElementTypes.TiledImage:
                    ElementComboBox.Items.Add(ElementTypes.Image);
                    ElementComboBox.Items.Add(ElementTypes.TiledImage);
                    HueButton.Visible = true;
                    break;
            }

            ElementComboBox.SelectedIndex = ElementComboBox.Items.IndexOf(ELEMENT);
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
            if (IMAGEELEMENT?.Tag is ArtEntity ae)
            {
                if (int.TryParse(PropertyTextBox.Text, out int val))
                {
                    IMAGEELEMENT.Tag = UltimaArtLoader.GetArtEntity(val, ELEMENT != ElementTypes.Item);

                    if (IMAGEELEMENT.Tag is ArtEntity nae)
                    {
                        IMAGEELEMENT.SetElement(nae);
                    }
                }
            }
        }

        private void WidthButton_Click(object sender, EventArgs e)
        {
            if (IMAGEELEMENT != null && int.TryParse(PropertyTextBox.Text, out int val))
            {
                IMAGEELEMENT.Width = val;
            }
        }

        private void HeightButton_Click(object sender, EventArgs e)
        {
            if (IMAGEELEMENT != null && int.TryParse(PropertyTextBox.Text, out int val))
            {
                IMAGEELEMENT.Height = val;
            }
        }

        private void HueButton_Click(object sender, EventArgs e)
        {
            if (IMAGEELEMENT != null && int.TryParse(PropertyTextBox.Text, out int val))
            {
                if (IMAGEELEMENT.Tag is ArtEntity ae)
                {
                    Bitmap? image = ae.GetImage();

                    if (image != null)
                    {
                        AssetData.Hues.ApplyTo(image, val, false);

                        IMAGEELEMENT.Image = image;
                    }
                }
            }
        }

        private void MaxButton_Click(object sender, EventArgs e)
        {
            if (int.TryParse(PropertyTextBox.Text, out int val))
            {
                MaxTextLength = val;
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (IMAGEELEMENT != null && UOEditorCore.Z_Layer.Contains(IMAGEELEMENT))
            {
                if (MessageBox.Show("Delete element?", "Warning!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    UOEditorCore.MainUI?.RemoveFromCanvas(IMAGEELEMENT);
                }
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
