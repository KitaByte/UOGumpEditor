using UOGumpEditor.UOElements;

namespace UOGumpEditor
{
    public partial class UOTextEntry : Form
    {
        private readonly TextElement? TEXTELEMENT;

        private readonly ElementTypes ELEMENT;

        private Color HUE = Color.White;

        public UOTextEntry(ElementTypes element, TextElement? textElement = null)
        {
            InitializeComponent();

            TEXTELEMENT = textElement;

            ELEMENT = element;
        }

        private void UOTextEntry_Load(object sender, EventArgs e)
        {
            switch (ELEMENT)
            {
                case ElementTypes.Label:
                    {
                        TextEntryBox.Multiline = false;

                        Size = new Size(300, 116);

                        break;
                    }

                case ElementTypes.Html:
                    {
                        TextEntryBox.Multiline = true;

                        Text = "HTML Entry";

                        break;
                    }
            }
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TextEntryBox.Text))
            {
                UOEditorCore.MainUI?.AddTextElement(TextEntryBox.Text, HUE);
            }

            Close();
        }

        private void HueButton_Click(object sender, EventArgs e)
        {
            using ColorDialog colorDialog = new();

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                HUE = colorDialog.Color;
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (TEXTELEMENT != null && UOEditorCore.Z_Layer.Contains(TEXTELEMENT))
            {
                UOEditorCore.MainUI?.RemoveFromCanvas(TEXTELEMENT);
            }
        }
    }
}
