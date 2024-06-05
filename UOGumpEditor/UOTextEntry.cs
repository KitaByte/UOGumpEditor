using UOGumpEditor.UOElements;

namespace UOGumpEditor
{
    public partial class UOTextEntry : Form
    {
        private readonly TextElement? ELEMENT;

        private int HUE = 0;

        public UOTextEntry(TextElement? element = null)
        {
            InitializeComponent();

            ELEMENT = element;
        }

        private void UOTextEntry_Load(object sender, EventArgs e)
        {
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TextEntryBox.Text))
            {
                UOEditorCore.MainUI?.AddTextElement(TextEntryBox.Text, HUE);

                Close();
            }
        }

        private void HueButton_Click(object sender, EventArgs e)
        {
            // Display Hue Picker!
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (ELEMENT != null && UOEditorCore.Z_Layer.Contains(ELEMENT))
            {
                UOEditorCore.MainUI?.RemoveFromCanvas(ELEMENT);
            }
        }
    }
}
