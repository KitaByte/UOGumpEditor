using UOGumpEditor.UOElements;

namespace UOGumpEditor
{
    public partial class UOGumpEditorUI : Form
    {
        private ArtCache? _artCache;

        public UOGumpEditorUI()
        {
            InitializeComponent();

            UOEditorCore.SetMainHandle(this);

            KeyPreview = true;
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

                    UOEditorCore.LoadArt();

                    LoadArtAsync();
                }
            }

            LayerListbox.DisplayMember = "ToString";
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
            NewButton.Enabled = !isLoading;
            SaveButton.Enabled = !isLoading;
            LoadButton.Enabled = !isLoading;
            ExportButton.Enabled = !isLoading;
            ModeButton.Enabled = !isLoading;
            SettingsButton.Enabled = !isLoading;
            ElementStrip.Enabled = !isLoading;
            GumpArtButton.Enabled = !isLoading;
            ItemArtButton.Enabled = !isLoading;
            ArtIDSearchBox.Enabled = !isLoading;
            ArtNameSearchBox.Enabled = !isLoading;
            ArtWidthSearchBox.Enabled = !isLoading;
            ArtHeightSearchBox.Enabled = !isLoading;

            UOProgressBar.Value = isLoading ? 10 : 100;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (UOEditorCore.CurrentEleControl != null)
            {
                switch (keyData)
                {
                    case Keys.Up:
                        UOEditorCore.MoveElement(0, -1);
                        return true;
                    case Keys.Down:
                        UOEditorCore.MoveElement(0, 1);
                        return true;
                    case Keys.Left:
                        UOEditorCore.MoveElement(-1, 0);
                        return true;
                    case Keys.Right:
                        UOEditorCore.MoveElement(1, 0);
                        return true;
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void NewButton_Click(object sender, EventArgs e)
        {
            CanvasPanel.Controls.Clear();

            HistoryListbox.Items.Clear();

            LayerListbox.Items.Clear();

            UOEditorCore.ResetGumpElements();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {

        }

        private void LoadButton_Click(object sender, EventArgs e)
        {

        }

        private void ExportButton_Click(object sender, EventArgs e)
        {

        }

        private void ModeButton_Click(object sender, EventArgs e)
        {
            CanvasPanel.BackColor = CanvasPanel.BackColor == Color.Black ? Color.Transparent : Color.Black;
        }

        private void Settings_Click(object sender, EventArgs e)
        {
            // Set Language

            // Edit Gump Names List

            // Search Display Max

            // Background Image

            // Art Viewer Background Color

            // Font Size

            UOSettings.Default.Reset();

            UOSettings.Default.Save();
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

        private void ArtPicturebox_MouseDown(object sender, MouseEventArgs e)
        {
            if (UOEditorCore.CurrentArtDisplayed != null)
            {
                UpdateElementInfo(UOEditorCore.CurrentArtDisplayed);
            }

            if (sender is PictureBox picBox)
            {
                if (picBox.Tag is ArtEntity entity && e.Button == MouseButtons.Left)
                {
                    picBox.DoDragDrop(entity, DragDropEffects.Copy);
                }
            }
        }

        private bool IsGump()
        {
            return GumpArtButton.BackColor == Color.DodgerBlue;
        }

        private void ArtIDSearchBox_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ArtIDSearchBox.Text) && ArtIDSearchBox.Text.Length < 6)
            {
                if (int.TryParse(ArtIDSearchBox.Text, out int val))
                {
                    if (UltimaArtLoader.SearchArtByID(val, IsGump(), out List<ArtEntity> results))
                    {
                        _artCache = new ArtCache(results);

                        DisplayArtWindow();
                    }
                }
            }
            else
            {
                DisplayArt(UltimaArtLoader.GetArtEntity(0, IsGump()));
            }
        }

        private void ArtNameSearchBox_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ArtNameSearchBox.Text) && ArtNameSearchBox.Text.Length < 25)
            {
                if (UltimaArtLoader.SearchArtByName(ArtNameSearchBox.Text, IsGump(), out List<ArtEntity> results))
                {
                    _artCache = new ArtCache(results);

                    DisplayArtWindow();
                }
            }
            else
            {
                DisplayArt(UltimaArtLoader.GetArtEntity(0, IsGump()));
            }
        }

        private void ArtSizeSearchBox_TextChanged(object sender, EventArgs e)
        {
            if (sender is TextBox tb)
            {
                if (tb.Name == nameof(ArtWidthSearchBox))
                {
                    if (!string.IsNullOrEmpty(ArtWidthSearchBox.Text) && ArtWidthSearchBox.Text.Length < 6)
                    {
                        if (int.TryParse(ArtWidthSearchBox.Text, out int size) && size > 0)
                        {
                            if (UltimaArtLoader.SearchArtBySize(size, IsGump(), out List<ArtEntity> results, true))
                            {
                                _artCache = new ArtCache(results);

                                DisplayArtWindow();
                            }
                        }
                    }
                    else
                    {
                        DisplayArt(UltimaArtLoader.GetArtEntity(0, IsGump()));
                    }
                }
                else if (tb.Name == nameof(ArtHeightSearchBox))
                {
                    if (!string.IsNullOrEmpty(ArtHeightSearchBox.Text) && ArtHeightSearchBox.Text.Length < 6)
                    {
                        if (int.TryParse(ArtHeightSearchBox.Text, out int size) && size > 0)
                        {
                            if (UltimaArtLoader.SearchArtBySize(size, IsGump(), out List<ArtEntity> results, false))
                            {
                                _artCache = new ArtCache(results);

                                DisplayArtWindow();
                            }
                        }
                    }
                    else
                    {
                        DisplayArt(UltimaArtLoader.GetArtEntity(0, IsGump()));
                    }
                }
            }
        }

        private void ArtSearchBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (sender is TextBox box && box.Text.Length == 0)
            {
                ResetIDSearch();
            }
        }

        private void HistoryListbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (HistoryListbox.SelectedItem != null && HistoryListbox.SelectedItem is ArtEntity ae)
            {
                DisplayArt(ae);
            }
        }

        private void ClearHistoryButton_Click(object sender, EventArgs e)
        {
            HistoryListbox.Items.Clear();
        }

        private void DisplayArtWindow()
        {
            if (_artCache != null)
            {
                var results = _artCache.GetCurrentWindow(SearchFlowPanel);

                if (_artCache.CanScrollPrev())
                {
                    PreviousButton.Visible = true;
                }

                if (_artCache.CanScrollNext())
                {
                    NextButton.Visible = true;
                }

                DisplaySearchResults(results);

                SetMainDisplay(SearchPanel);
            }
        }

        private void SetMainDisplay(Panel panel)
        {
            CanvasPanel.Dock = DockStyle.None;

            SearchPanel.Dock = DockStyle.None;

            panel.Dock = DockStyle.Fill;

            FocusPanel.Visible = CanvasPanel.Dock == DockStyle.Fill;

            panel.BringToFront();
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

                    picBox.MouseHover += PicBox_MouseHover;

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

            PreviousButton.Visible = false;

            NextButton.Visible = false;
        }

        private void PicBox_MouseHover(object? sender, EventArgs e)
        {
            if (sender != null && sender is PictureBox picBox)
            {
                if (picBox.Tag is ArtEntity entity)
                {
                    UpdateElementInfo(entity);
                }
            }
        }

        private void DisplayArt(ArtEntity entity)
        {
            ResetIDSearch();

            UOEditorCore.SetImageRenderer(ArtPicturebox, entity);

            SetMainDisplay(CanvasPanel);
        }

        private void PreviousButton_Click(object sender, EventArgs e)
        {
            PreviousButton.Visible = false;

            if (_artCache != null && _artCache.CanScrollPrev())
            {
                _artCache.ScrollPrev();

                DisplayArtWindow();
            }
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            NextButton.Visible = false;

            if (_artCache != null && _artCache.CanScrollNext())
            {
                _artCache.ScrollNext();

                DisplayArtWindow();
            }
        }

        private void ResetIDSearch()
        {
            ArtIDSearchBox.Clear();

            ArtNameSearchBox.Clear();

            ArtWidthSearchBox.Clear();

            ArtHeightSearchBox.Clear();

            SearchFlowPanel.Visible = false;
        }

        private void LayerListbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LayerListbox.SelectedItem is ElementEntity entity)
            {
                UOEditorCore.UpdateElementMove(entity.Element);
            }
        }

        private void CanvasPanel_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data != null && e.Data.GetDataPresent(typeof(ArtEntity)))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void CanvasPanel_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data != null)
            {
                if (e.Data.GetDataPresent(typeof(ArtEntity)))
                {
                    if (e.Data.GetData(typeof(ArtEntity)) is ArtEntity entity)
                    {
                        var dropLocation = CanvasPanel.PointToClient(new Point(e.X, e.Y));

                        BaseElement element = new()
                        {
                            Tag = entity
                        };

                        UOEditorCore.AddElement(element);

                        if (IsGump())
                        {
                            if (entity.Name.StartsWith("Background"))
                            {
                                element.ElementType = ElementTypes.Background;

                                element.LoadBackground();
                            }
                            else
                            {
                                switch (entity.Name)
                                {
                                    case "Button":
                                        {
                                            element.ElementType = ElementTypes.Button;

                                            element.LoadButton();

                                            break;
                                        }

                                    case "Radio":
                                        {
                                            element.ElementType = ElementTypes.RadioButton;

                                            element.LoadButton();

                                            break;
                                        }

                                    case "Check":
                                        {
                                            element.ElementType = ElementTypes.CheckBox;

                                            element.LoadButton();

                                            break;
                                        }

                                    case "TextEntry":
                                        {
                                            element.ElementType = ElementTypes.TextEntry;

                                            break;
                                        }

                                    case "AlphaRegion":
                                        {
                                            element.ElementType = ElementTypes.AlphaRegion;

                                            break;
                                        }

                                    default:
                                        {
                                            element.ElementType = ElementTypes.Image;

                                            break;
                                        }
                                }
                            }
                        }
                        else
                        {
                            element.ElementType = ElementTypes.Item;
                        }

                        element.SetImage(entity);

                        AddArtToCanvas(element, dropLocation);
                    }
                }
            }
        }

        private void AddLabelButton_Click(object sender, EventArgs e)
        {
            OpenTextEntry(ElementTypes.Label);
        }

        private void AddHTMLButton_Click(object sender, EventArgs e)
        {
            OpenTextEntry(ElementTypes.Html);
        }

        private UOImageEditor? editor;

        internal void OpenImageEditor(ElementTypes element, BaseElement imageElement)
        {
            if (editor != null && editor.Visible)
            {
                return;
            }

            if (imageElement != null)
            {
                editor = new(element, imageElement);
            }
            else
            {
                editor = new(element);
            }

            editor.Show();
        }

        private UOTextEntry? entry;

        public void OpenTextEntry(ElementTypes element, BaseElement? textElement = null)
        {
            if (entry != null && entry.Visible)
            {
                return;
            }

            if (textElement != null)
            {
                entry = new(element, textElement);
            }
            else
            {
                entry = new(element);
            }

            entry.Show();
        }

        public void AddTextElement(string text, Color hue)
        {
            BaseElement element = new()
            {
                ElementType = ElementTypes.Label
            };

            UOEditorCore.AddElement(element);

            element.SetText(text, hue);

            AddArtToCanvas(element, new(50, 50));
        }

        private void AddArtToCanvas(Control element, Point location)
        {
            element.Location = new Point(location.X - (element.Width / 2), location.Y - (element.Height / 2));

            CanvasPanel.Controls.Add(element);

            if (element is BaseElement be)
            {
                UpdateLayerList(be, true);
            }
        }

        public void RemoveFromCanvas(Control element)
        {
            UOEditorCore.Z_Layer.Remove(element);

            if (CanvasPanel.Controls.Contains(element))
            {
                CanvasPanel.Controls.Remove(element);

                if (element is BaseElement be)
                {
                    UpdateLayerList(be, false);
                }
            }
        }

        // Add Method to reorder LayerList

        private void UpdateLayerList(BaseElement element, bool add)
        {
            if (!add)
            {
                ElementEntity? entity = null;

                foreach (var item in LayerListbox.Items)
                {
                    if (item is ElementEntity ee && ee.Element == element)
                    {
                        entity = ee;

                        break;
                    }
                }

                if (entity != null)
                {
                    LayerListbox.Items.Remove(entity);
                }
            }
            else
            {
                LayerListbox.Items.Add(new ElementEntity(element));
            }

            LayerListbox.Invalidate();
        }

        public void AddToHistory(ArtEntity entity)
        {
            HistoryListbox.Items.Add(entity);

            HistoryListbox.Invalidate();
        }

        public void UpdateElementInfo(ArtEntity entity)
        {
            GumpInfoLabel.Text = $"{(entity.IsGump ? "Gump" : "Item")} {entity.ID} : [{entity.Name}] - width: {entity.Width} / hieght: {entity.Height}";
        }

        private void UOGumpEditorUI_Resize(object sender, EventArgs e)
        {
            if (SearchFlowPanel.Visible)
            {
                DisplayArtWindow();
            }
            else
            {
                SetMainDisplay(CanvasPanel);
            }
        }

        private void RaiseLayerButton_Click(object sender, EventArgs e)
        {
            UOEditorCore.MoveLayerUp();
        }

        private void LowerLayerButton_Click(object sender, EventArgs e)
        {
            UOEditorCore.MoveLayerDown();
        }
    }
}
