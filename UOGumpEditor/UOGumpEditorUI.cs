using System.Collections;
using UOGumpEditor.UOElements;

namespace UOGumpEditor
{
    public partial class UOGumpEditorUI : Form
    {
        public UOGumpEditorUI()
        {
            InitializeComponent();
        }

        private void UOGumpEditorUI_Load(object sender, EventArgs e)
        {
            if (UOEditorCore.ArtLoader == null && !string.IsNullOrEmpty(UOSettings.Default.UO_Folder))
            {
                UOEditorCore.LoadArt();

                LoadArtAsync();
            }
            else
            {
                using var dlg = new FolderBrowserDialog() { Description = "Select UO Folder!" };

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    UOSettings.Default.UO_Folder = dlg.SelectedPath;

                    UOSettings.Default.Save();
                }
            }
        }

        private async void LoadArtAsync()
        {
            SetLoadingState(true);

            GumpInfoLabel.Text = "Loading Art ...";

            await UltimaArtLoader.LoadAllGumpArtAsync();

            UOProgressBar.Value = 50;

            await UltimaArtLoader.LoadAllItemArtAsync();

            SetLoadingState(false);

            UOEditorCore.ReLoadArt();

            DisplayArt(UltimaArtLoader.GetArtEntity(0, IsGump()));
        }

        private void SetLoadingState(bool isLoading)
        {
            ArtIDSearchBox.Enabled = !isLoading;
            ArtNameSearchBox.Enabled = !isLoading;
            ArtSizeSearchBox.Enabled = !isLoading;

            UOProgressBar.Value = isLoading ? 10 : 100;
        }

        private void NewButton_Click(object sender, EventArgs e)
        {
            ArrayList elements = [];

            foreach (var control in Controls)
            {
                if (control is BaseElement)
                {
                    elements.Add(control);
                }
            }

            if (elements.Count > 0)
            {
                foreach (var element in elements)
                {
                    if (element is Control c)
                    {
                        Controls.Remove(c);
                    }
                }
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {

        }

        private void LoadButton_Click(object sender, EventArgs e)
        {

        }

        private void Settings_Click(object sender, EventArgs e)
        {
            // Set Language

            // Edit Gump Names List

            UOSettings.Default.Reset();

            UOSettings.Default.Save();
        }

        private void ExportButton_Click(object sender, EventArgs e)
        {

        }

        private void EditorHelpButton_Click(object sender, EventArgs e)
        {

        }

        private void GumpArtButton_Click(object sender, EventArgs e)
        {
            UOEditorCore.SwapButtonOn(GumpArtButton, ItemArtButton);

            DisplayArt(UltimaArtLoader.GetArtEntity(0, IsGump()));
        }

        private void ItemArtButton_Click(object sender, EventArgs e)
        {
            UOEditorCore.SwapButtonOn(ItemArtButton, GumpArtButton);

            DisplayArt(UltimaArtLoader.GetArtEntity(0, IsGump()));
        }

        private bool IsGump()
        {
            return GumpArtButton.BackColor == Color.DodgerBlue;
        }

        private void ArtIDSearchBox_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ArtIDSearchBox.Text) && int.TryParse(ArtIDSearchBox.Text, out int val))
            {
                if (UltimaArtLoader.SearchArtByID(val, IsGump(), out List<ArtEntity> results))
                {
                    DisplaySearchResults(results);
                }
                else
                {
                    DisplayArt(UltimaArtLoader.GetArtEntity(0, IsGump()));
                }
            }
            else
            {
                ArtPicturebox.Image = null;
            }
        }

        private void ArtNameSearchBox_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ArtNameSearchBox.Text))
            {
                if (UltimaArtLoader.SearchArtByName(ArtNameSearchBox.Text, IsGump(), out List<ArtEntity> results))
                {
                    DisplaySearchResults(results);
                }
                else
                {
                    DisplayArt(UltimaArtLoader.GetArtEntity(0, IsGump()));
                }
            }
        }

        private void ArtSizeSearchBox_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ArtSizeSearchBox.Text))
            {
                if (int.TryParse(ArtSizeSearchBox.Text, out int size) && size > 0)
                {
                    if (UltimaArtLoader.SearchArtBySize(size, IsGump(), out List<ArtEntity> results))
                    {
                        DisplaySearchResults(results);
                    }
                    else
                    {
                        DisplayArt(UltimaArtLoader.GetArtEntity(0, IsGump()));
                    }
                }
                else
                {
                    ArtSizeSearchBox.Clear();
                }
            }
        }

        private void HistoryListbox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ClearHistoryButton_Click(object sender, EventArgs e)
        {
            HistoryListbox.Items.Clear();
        }

        private void DisplaySearchResults(List<ArtEntity> results)
        {
            if (results.Count > 0)
            {
                SearchFlowPanel.Controls.Clear();

                foreach (var entity in results)
                {
                    var picBox = new PictureBox
                    {
                        Image = entity.GetImage(),
                        Size = new Size(100, 100),
                        SizeMode = entity.Width > 100 || entity.Height > 100 ? PictureBoxSizeMode.Zoom : PictureBoxSizeMode.Normal,
                        Tag = entity
                    };

                    picBox.Click += PicBox_Click;

                    SearchFlowPanel.Controls.Add(picBox);
                }

                SearchFlowPanel.Visible = true;
            }
        }

        private void PicBox_Click(object? sender, EventArgs e)
        {
            if (sender != null && sender is PictureBox picBox)
            {
                if (picBox.Tag is ArtEntity entity)
                {
                    DisplayArt(entity);
                }
            }

            SearchFlowPanel.Visible = false;
        }

        private void DisplayArt(ArtEntity entity)
        {
            ResetIDSearch();

            UOEditorCore.SetImageRenderer(ArtPicturebox, entity, GumpInfoLabel);
        }

        private void ResetIDSearch()
        {
            ArtIDSearchBox.Clear();

            ArtNameSearchBox.Clear();

            ArtSizeSearchBox.Clear();

            SearchFlowPanel.Visible = false;

            ArtIDSearchBox.Focus();
        }
    }
}
