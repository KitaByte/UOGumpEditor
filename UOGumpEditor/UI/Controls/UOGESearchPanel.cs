namespace UOGumpEditor
{
    public class UOGESearchPanel : UOGEPanel
    {
        public readonly UOGEPanel ArtPanel = new() { Size = new Size(200, 35), Dock = DockStyle.Top, Padding = new Padding(0) };

        public readonly UOGEButton GumpArtButton = new()
        {
            Text = "Gump Art",
            Size = new Size(95, 35),
            BackColor = Color.DodgerBlue,
            Dock = DockStyle.Left,
        };

        public readonly UOGEButton ItemArtButton = new()
        {
            Text = "Item Art",
            Size = new Size(95, 35),
            BackColor = Color.RoyalBlue,
            ForeColor = Color.Black,
            Dock = DockStyle.Right
        };

        public readonly UOGEPictureBox ArtPicturebox = new () { Size = new Size(190, 190), BackColor = Color.Black, Dock = DockStyle.Top };

        public readonly UOGEButton SearchAllButton = new ()
        {
            Text = "Search All",
            BackColor = Color.Goldenrod,
            Dock = DockStyle.Top
        };

        public readonly UOGETextBox ArtIDSearchBox = new ()
        {
            PlaceholderText = "ID",
            BackColor = Color.LightGoldenrodYellow,
            Dock = DockStyle.Top
        };

        public readonly UOGETextBox ArtNameSearchBox = new ()
        {
            PlaceholderText = "Name",
            BackColor = Color.PaleGoldenrod,
            Dock = DockStyle.Top
        };

        public readonly UOGEPanel SizePanel = new () { Size = new Size(200, 25), Dock = DockStyle.Top, Padding = new Padding(0) };

        public readonly UOGETextBox ArtWidthSearchBox = new ()
        {
            PlaceholderText = "Width",
            Size = new Size(95, 25),
            BackColor = Color.LightGoldenrodYellow,
            Dock = DockStyle.Left
        };

        public readonly UOGETextBox ArtHeightSearchBox = new ()
        {
            PlaceholderText = "Height",
            Size = new Size(95, 25),
            BackColor = Color.LightGoldenrodYellow,
            Dock = DockStyle.Right
        };

        public readonly UOGETextBox ArtRangeSearchBox = new ()
        {
            PlaceholderText = "Size Range [Default 0]",
            BackColor = Color.PaleGoldenrod,
            Dock = DockStyle.Top
        };

        public readonly UOGEListBox HistoryListbox = new () { Dock = DockStyle.Fill };

        public readonly UOGEButton ClearHistoryButton = new ()
        {
            Text = "Clear History",
            BackColor = Color.Brown,
            Dock = DockStyle.Bottom
        };

        private int _SizeRange = 0;

        public UOGESearchPanel()
        {
            Size = new Size(200, 500);

            Dock = DockStyle.Right;

            GumpArtButton.Click += GumpArtButton_Click;

            ArtPanel.Controls.Add(GumpArtButton);

            ItemArtButton.Click += ItemArtButton_Click;

            ArtPanel.Controls.Add(ItemArtButton);

            ArtPicturebox.MouseDown += ArtPicturebox_MouseDown;

            SearchAllButton.Click += SearchAllButton_Click;

            ArtIDSearchBox.TextChanged += ArtIDSearchBox_TextChanged;

            ArtIDSearchBox.MouseClick += SearchBox_MouseClick;

            ArtNameSearchBox.TextChanged += ArtNameSearchBox_TextChanged;

            ArtNameSearchBox.MouseClick += SearchBox_MouseClick;

            SizePanel.Controls.Add(ArtWidthSearchBox);

            ArtWidthSearchBox.TextChanged += ArtSizeSearchBox_TextChanged;

            ArtWidthSearchBox.MouseClick += SearchBox_MouseClick;

            SizePanel.Controls.Add(ArtHeightSearchBox);

            ArtHeightSearchBox.TextChanged += ArtSizeSearchBox_TextChanged;

            ArtHeightSearchBox.MouseClick += SearchBox_MouseClick;

            Controls.Add(new UOGELabel() { Text = "History", BackColor = Color.Indigo, Dock = DockStyle.Top });

            Controls.Add(ArtRangeSearchBox);

            Controls.Add(SizePanel);

            Controls.Add(ArtNameSearchBox);

            Controls.Add(ArtIDSearchBox);

            Controls.Add(SearchAllButton);

            Controls.Add(ArtPicturebox);

            Controls.Add(ArtPanel);

            Controls.Add(HistoryListbox);

            HistoryListbox.SelectedIndexChanged += HistoryListbox_SelectedIndexChanged;

            Controls.Add(ClearHistoryButton);

            ClearHistoryButton.Click += ClearHistoryButton_Click;

            HistoryListbox.BringToFront();
        }

        private void GumpArtButton_Click(object? sender, EventArgs e)
        {
            UOEditorCore.SwapButtonOn(GumpArtButton, ItemArtButton);

            DisplayArt(UOArtLoader.GetArtEntity(0, UOEditorCore.Session.IsGump()));
        }

        private void ItemArtButton_Click(object? sender, EventArgs e)
        {
            UOEditorCore.SwapButtonOn(ItemArtButton, GumpArtButton);

            DisplayArt(UOArtLoader.GetArtEntity(0, UOEditorCore.Session.IsGump()));
        }

        private async void ArtPicturebox_MouseDown(object? sender, MouseEventArgs e)
        {
            if (UOEditorCore.CurrentArtDisplayed != null)
            {
                UOEditorCore.Session.UpdateElementInfo(UOEditorCore.CurrentArtDisplayed);
            }

            if (sender == ArtPicturebox)
            {
                if (ArtPicturebox.Tag is ArtEntity entity)
                {
                    if (e.Button == MouseButtons.Left)
                    {
                        ArtPicturebox.DoDragDrop(entity, DragDropEffects.Copy);
                    }

                    if (e.Button == MouseButtons.Right && !UOEditorCore.IsSearching)
                    {
                        UOEditorCore.IsSearching = true;

                        UOEditorCore.Session.ArtCacheHandle = new ArtCache(await UOArtLoader.SearchArtByIDAsync(entity.ID, UOEditorCore.Session.IsGump()));

                        UOEditorCore.Session.SetSearchDisplay();
                    }
                }
            }
        }

        private void SearchAllButton_Click(object? sender, EventArgs e)
        {
            if (UOEditorCore.IsSearching)
            {
                return;
            }

            if (UOArtLoader.GetAllArt(UOEditorCore.Session.IsGump(), out List<ArtEntity> results))
            {
                UOEditorCore.Session.ArtCacheHandle = new ArtCache(results);

                UOEditorCore.Session.SetSearchDisplay();
            }
            else
            {
                DisplayArt(UOArtLoader.GetArtEntity(0, UOEditorCore.Session.IsGump()));
            }
        }

        private async void ArtIDSearchBox_TextChanged(object? sender, EventArgs e)
        {
            if (UOEditorCore.IsSearching)
            {
                return;
            }

            if (!string.IsNullOrEmpty(ArtIDSearchBox.Text) && ArtIDSearchBox.Text.Length < 6)
            {
                if (int.TryParse(ArtIDSearchBox.Text, out int val))
                {
                    UOEditorCore.Session.ArtCacheHandle = new ArtCache(await UOArtLoader.SearchArtByIDAsync(val, UOEditorCore.Session.IsGump()));

                    UOEditorCore.Session.SetSearchDisplay();
                }
            }
            else
            {
                DisplayArt(UOArtLoader.GetArtEntity(0, UOEditorCore.Session.IsGump()));
            }
        }

        private async void ArtNameSearchBox_TextChanged(object? sender, EventArgs e)
        {
            if (UOEditorCore.IsSearching)
            {
                return;
            }

            if (!string.IsNullOrEmpty(ArtNameSearchBox.Text) && ArtNameSearchBox.Text.Length < 25)
            {
                UOEditorCore.Session.ArtCacheHandle = new ArtCache(await UOArtLoader.SearchArtByNameAsync(ArtNameSearchBox.Text, UOEditorCore.Session.IsGump()));

                UOEditorCore.Session.SetSearchDisplay();
            }
            else
            {
                DisplayArt(UOArtLoader.GetArtEntity(0, UOEditorCore.Session.IsGump()));
            }
        }

        private async void ArtSizeSearchBox_TextChanged(object? sender, EventArgs e)
        {
            if (UOEditorCore.IsSearching)
            {
                return;
            }

            if (sender is TextBox tb)
            {
                if (!string.IsNullOrEmpty(tb.Text) && tb.Text.Length < 6)
                {
                    if (int.TryParse(tb.Text, out int size) && size > 0)
                    {
                        _SizeRange = 0;

                        if (!string.IsNullOrEmpty(ArtRangeSearchBox.Text))
                        {
                            if (int.TryParse(ArtRangeSearchBox.Text, out int val))
                            {
                                _SizeRange = val;
                            }
                        }

                        UOEditorCore.Session.ArtCacheHandle = new ArtCache
                            (
                                await UOArtLoader.SearchArtBySizeAsync(size, _SizeRange, UOEditorCore.Session.IsGump(), sender == ArtWidthSearchBox)
                            );

                        UOEditorCore.Session.SetSearchDisplay();
                    }
                }
                else
                {
                    DisplayArt(UOArtLoader.GetArtEntity(0, UOEditorCore.Session.IsGump()));
                }
            }
        }

        private void SearchBox_MouseClick(object? sender, MouseEventArgs e)
        {
            if (sender is TextBox box && box.Text.Length == 0)
            {
                ResetIDSearch();
            }
        }

        private void HistoryListbox_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (HistoryListbox.SelectedItem != null && HistoryListbox.SelectedItem is ArtEntity entity)
            {
                DisplayArt(entity);
            }
        }

        private void ClearHistoryButton_Click(object? sender, EventArgs e)
        {
            HistoryListbox.Items.Clear();
        }

        public void DisplayArt(ArtEntity entity)
        {
            ResetIDSearch();

            UOEditorCore.SetImageRenderer(ArtPicturebox, entity);

            UOEditorCore.Session.SetMainDisplay(UOEditorCore.Session.CanvasUI);
        }

        private void ResetIDSearch()
        {
            ArtIDSearchBox.Clear();

            ArtNameSearchBox.Clear();

            ArtWidthSearchBox.Clear();

            ArtHeightSearchBox.Clear();

            UOEditorCore.Session.DisplayUI.DisplayFlowPanel.Visible = false;
        }
    }
}
