namespace UOGumpEditor
{
    public partial class SettingsUI : Form
    {
        public SettingsUI()
        {
            InitializeComponent();
        }

        private void SettingsUI_Load(object sender, EventArgs e)
        {

        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            UOSettings.Default.Reset();

            UOSettings.Default.Save();
        }
    }
}
