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
            LoadGumpNames();

            FontTextbox.Text = UOSettings.Default.FontSize.ToString();

            MaxSearchTextbox.Text = UOSettings.Default.DisplayMax.ToString();

            ExportCombobox.SelectedIndex = 0;

            LanguageCombobox.SelectedIndex = 0;
        }

        private void LoadGumpNames()
        {
            GumpNameListbox.SuspendLayout();

            GumpNameListbox.DataSource = UOArtLoader.GumpNames;

            GumpNameListbox.ResumeLayout();
        }

        private void SetFontButton_Click(object sender, EventArgs e)
        {
            if (float.TryParse(FontTextbox.Text, out float size))
            {
                UOSettings.Default.FontSize = size;

                UOSettings.Default.Save();
            }
            else
            {
                FontTextbox.Text = UOSettings.Default.FontSize.ToString();
            }
        }

        private void SetNameButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(GumpNameTextbox.Text))
            {
                var nameInfo = GumpNameTextbox.Text.Split(':');

                if (nameInfo.Length == 2 && int.TryParse(nameInfo[0], out int val))
                {
                    UOArtLoader.UpdateGumpName(val, nameInfo[1]);

                    GumpNameListbox.Items.Clear();

                    LoadGumpNames();
                }
            }
        }

        private void GumpNameListbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (GumpNameListbox.SelectedValue != null)
            {
                GumpNameTextbox.Text = GumpNameListbox.SelectedValue.ToString();
            }
        }

        private void MaxSearchButton_Click(object sender, EventArgs e)
        {
            if (int.TryParse(MaxSearchTextbox.Text, out int size))
            {
                UOSettings.Default.DisplayMax = size;

                UOSettings.Default.Save();
            }
            else
            {
                FontTextbox.Text = UOSettings.Default.DisplayMax.ToString();
            }
        }

        private void PreviewButton_Click(object sender, EventArgs e)
        {

        }

        private void ExportCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void LanguageCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void BackgroundButton_Click(object sender, EventArgs e)
        {

        }

        private void ArtDisplayButton_Click(object sender, EventArgs e)
        {

        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            UOSettings.Default.Reset();

            UOSettings.Default.Save();
        }
    }
}
