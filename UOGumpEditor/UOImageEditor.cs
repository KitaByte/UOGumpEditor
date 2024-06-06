using UOGumpEditor.UOElements;

namespace UOGumpEditor
{
    public partial class UOImageEditor : Form
    {
        private readonly ImageElement? IMAGEELEMENT;

        private readonly ElementTypes ELEMENT;

        public UOImageEditor(ElementTypes element, ImageElement? imageElement = null)
        {
            InitializeComponent();

            IMAGEELEMENT = imageElement;

            ELEMENT = element;
        }

        private void UOImageEditor_Load(object sender, EventArgs e)
        {
            switch (ELEMENT)
            {
                case ElementTypes.AlphaRegion:
                    break;
                case ElementTypes.Background:
                    break;
                case ElementTypes.Button:
                    break;
                case ElementTypes.CheckBox:
                    break;
                case ElementTypes.Image:
                    break;
                case ElementTypes.Item:
                    break;
                case ElementTypes.RadioButton:
                    break;
                case ElementTypes.TextEntry:
                    break;
                case ElementTypes.TextEntryLimited:
                    break;
                case ElementTypes.TiledImage:
                    break;
            }
        }
    }
}
