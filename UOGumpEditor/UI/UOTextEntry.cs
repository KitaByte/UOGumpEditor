using UOGumpEditor.UOElements;

namespace UOGumpEditor
{
    public partial class UOTextEntry : Form
    {
        private readonly ElementControl? TEXTELEMENT;

        private readonly ElementTypes ELEMENT;

        private Color HUE = Color.White;

        public UOTextEntry(ElementTypes element, ElementControl? textElement = null)
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

                        TextEntryBox.AcceptsReturn = true;

                        Text = "HTML Entry";

                        break;
                    }
            }

            if (TEXTELEMENT != null)
            {
                TextEntryBox.Text = TEXTELEMENT.Text;

                HUE = TEXTELEMENT.TextColor;

                TextEntryBox.ForeColor = HUE;
            }
        }

        private void SetTextButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TextEntryBox.Text))
            {
                if (TEXTELEMENT == null)
                {
                    UOEditorCore.MainUI?.AddTextElement(TextEntryBox.Text, HUE, ELEMENT);
                }
                else
                {
                    TEXTELEMENT.Text = TextEntryBox.Text;

                    TEXTELEMENT.TextColor = HUE;
                }
            }

            Close();
        }

        private void HueButton_Click(object sender, EventArgs e)
        {
            using ColorDialog colorDialog = new();

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                HUE = colorDialog.Color;

                TextEntryBox.ForeColor = HUE;
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (UOEditorCore.MainUI != null && TEXTELEMENT != null)
            {
                if (UOEditorCore.MainUI.CanvasPanel.Controls.Contains(TEXTELEMENT))
                {
                    if (MessageBox.Show("Delete element?", "Warning!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                    {
                        UOEditorCore.MainUI?.RemoveFromCanvas(TEXTELEMENT);
                    }
                }
            }
        }
    }
}
