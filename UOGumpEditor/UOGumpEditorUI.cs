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

            GumpInfoLabel.Text = "Loading Gump Assets ...";

            await UltimaArtLoader.LoadAllGumpArtAsync();

            UOProgressBar.Value = 50;

            GumpInfoLabel.Text = "Loading Art Assets ...";

            await UltimaArtLoader.LoadAllItemArtAsync();

            UOEditorCore.ReLoadArt();

            SetLoadingState(false);

            DisplayArt(UltimaArtLoader.GetArtEntity(0, IsGump()));
        }

        private void SetLoadingState(bool isLoading)
        {
            ArtIDSearchBox.Enabled = !isLoading;
            ArtNameSearchBox.Enabled = !isLoading;
            ArtWidthSearchBox.Enabled = !isLoading;
            ArtHeightSearchBox.Enabled = !isLoading;

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

            // Search Display Max

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
                DisplayArt(UltimaArtLoader.GetArtEntity(0, IsGump()));
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
            else
            {
                DisplayArt(UltimaArtLoader.GetArtEntity(0, IsGump()));
            }
        }

        private void ArtSizeSearchBox_TextChanged(object sender, EventArgs e)
        {
            if (sender == ArtWidthSearchBox)
            {
                if (!string.IsNullOrEmpty(ArtWidthSearchBox.Text))
                {
                    if (int.TryParse(ArtWidthSearchBox.Text, out int size) && size > 0)
                    {
                        if (UltimaArtLoader.SearchArtBySize(size, IsGump(), out List<ArtEntity> results, true))
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
                        ArtWidthSearchBox.Clear();
                    }
                }
                else
                {
                    DisplayArt(UltimaArtLoader.GetArtEntity(0, IsGump()));
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(ArtHeightSearchBox.Text))
                {
                    if (int.TryParse(ArtHeightSearchBox.Text, out int size) && size > 0)
                    {
                        if (UltimaArtLoader.SearchArtBySize(size, IsGump(), out List<ArtEntity> results, false))
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
                        ArtHeightSearchBox.Clear();
                    }
                }
                else
                {
                    DisplayArt(UltimaArtLoader.GetArtEntity(0, IsGump()));
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

                Color color = Color.Black;

                Image? image;

                foreach (var entity in results)
                {
                    if (results.Count > 0 && results[results.Count / 2] == entity)
                    {
                        color = Color.WhiteSmoke;
                    }

                    image = entity.GetImage();

                    if (image == null)
                    {
                        color = Color.Red;
                    }

                    var picBox = new PictureBox
                    {
                        BorderStyle = BorderStyle.Fixed3D,
                        BackColor = color,
                        Image = image,
                        Size = new Size(100, 100),
                        SizeMode = entity.Width > 100 || entity.Height > 100 ? PictureBoxSizeMode.Zoom : PictureBoxSizeMode.CenterImage,
                        Tag = entity
                    };

                    color = Color.Black;

                    image = null;

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

            ArtWidthSearchBox.Clear();

            SearchFlowPanel.Visible = false;
        }

        private void ArtSearchBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (sender is TextBox box && box.Text.Length == 0)
            {
                ResetIDSearch();
            }
        }
    }
}
