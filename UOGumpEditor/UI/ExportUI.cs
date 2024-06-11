using UOGumpEditor.UOElements;

namespace UOGumpEditor
{
    public partial class ExportUI : Form
    {
        private readonly ElementControl[] _elements;

        public ExportUI(ElementControl[] list)
        {
            InitializeComponent();

            _elements = list;
        }

        private void ExportUI_Load(object sender, EventArgs e)
        {
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(NameTextbox.Text))
            {
                GumpExport.ExportGump(_elements, NameTextbox.Text);

                Close();
            }
            else
            {
                MessageBox.Show("Missing Name!", "Required!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ExportUI_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (UOEditorCore.MainUI != null)
            {
                UOEditorCore.MainUI.ExportUIHandle = null;
            }
        }
    }
}
