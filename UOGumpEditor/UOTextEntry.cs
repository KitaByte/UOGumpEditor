using UOGumpEditor.UOElements;

namespace UOGumpEditor
{
    public partial class UOTextEntry : Form
    {
        private readonly UOGumpEditorUI UI;

        private readonly TextElement? ELEMENT;

        private int HUE = 0;

        public UOTextEntry(UOGumpEditorUI ui, TextElement? element = null)
        {
            InitializeComponent();

            UI = ui;

            ELEMENT = element;
        }

        private void UOTextEntry_Load(object sender, EventArgs e)
        {
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TextEntryBox.Text))
            {
                UI.AddTextElement(TextEntryBox.Text, HUE);

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
                UI.RemoveFromCanvas(ELEMENT);
            }
        }
    }
}
