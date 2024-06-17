using UOGumpEditor.UOElements;

namespace UOGumpEditor
{
    public class SessionEntity(UOGumpEditorUI ui)
    {
        public UOGumpEditorUI MainUI { get; init; } = ui;

        public ArtCache? ArtCacheHandle { get; set; } = null;

        public UOGECanvasPanel CanvasUI { get; init; } = new UOGECanvasPanel();

        public UOGEDisplayPanel DisplayUI { get; init; } = new UOGEDisplayPanel();

        public UOGEElementPanel ElementUI { get; init; } = new UOGEElementPanel();

        public UOGESearchPanel SearchUI { get; init; } = new UOGESearchPanel();

        public void LoadMainControls()
        {
            MainUI.Controls.Add(ElementUI);

            MainUI.Controls.Add(SearchUI);

            MainUI.Controls.Add(CanvasUI);

            MainUI.Controls.Add(DisplayUI);
        }

        public void SetMainDisplay(Panel panel)
        {
            if (panel == CanvasUI)
            {
                DisplayUI.Visible = false;

                DisplayUI.Dock = DockStyle.None;

                ElementUI.Visible = true;

                ElementUI.BringToFront();
            }
            else
            {
                CanvasUI.Visible = false;

                CanvasUI.Dock = DockStyle.None;

                ElementUI.Visible = false;
            }

            SearchUI.BringToFront();

            panel.Dock = DockStyle.Fill;

            panel.Visible = true;

            panel.BringToFront();
        }

        public void DisplayArtWindow()
        {
            if (ArtCacheHandle != null)
            {
                var results = ArtCacheHandle.GetCurrentWindow(DisplayUI.DisplayFlowPanel);

                DisplayUI.PrevButton.Visible = ArtCacheHandle.CanScrollPrev();

                DisplayUI.NextButton.Visible = ArtCacheHandle.CanScrollNext();

                DisplaySearchResults(results);

                SetMainDisplay(DisplayUI);
            }
        }

        private void DisplaySearchResults(List<ArtEntity> results)
        {
            if (results.Count > 0)
            {
                DisplayUI.DisplayFlowPanel.Controls.Clear();

                Color color;

                Image? image;

                foreach (var entity in results)
                {
                    image = entity.GetImage();

                    if (image == null)
                    {
                        color = Color.Brown;
                    }
                    else
                    {
                        color = Color.Black;
                    }

                    DisplayUI.DisplayFlowPanel.Controls.Add(new UOGEArtPictureBox(entity, image, color));

                    image = null;
                }

                DisplayUI.DisplayFlowPanel.Visible = true;
            }
        }

        public bool IsGump()
        {
            return SearchUI.GumpArtButton.BackColor == Color.DodgerBlue;
        }

        public bool IsSingleSelected()
        {
            return ElementUI.ElementListbox.SelectedItems.Count == 1;
        }

        public void AddTextElement(string text, Color hue, ElementTypes textType)
        {
            ElementControl element = new()
            {
                ElementType = textType
            };

            element.SetText(text, hue);

            AddToCanvas(element, new(50, 50));
        }

        public void AddToCanvas(ElementControl element, Point location)
        {
            if (element.ElementType == ElementTypes.Background)
            {
                element.Width *= 3;

                element.Height *= 3;
            }

            element.Location = new Point(location.X - (element.Width / 2), location.Y - (element.Height / 2));

            CanvasUI.Controls.Add(element);
        }

        public void RemoveFromCanvas(ElementControl element)
        {
            if (CanvasUI.Controls.Contains(element))
            {
                CanvasUI.Controls.Remove(element);
            }
        }

        public void AddToHistory(ArtEntity entity)
        {
            SearchUI.HistoryListbox.Items.Add(entity);

            SearchUI.HistoryListbox.Invalidate();
        }

        public void UpdateElementInfo(ArtEntity entity, ElementControl? element = null)
        {
            MainUI.GumpInfoLabel.Text = $"{(entity.IsGump ? "Gump" : "Item")} {entity.ID} : [{entity.Name}] - width: {entity.Width} / height: {entity.Height}";

            if (element != null)
            {
                MainUI.GumpInfoLabel.Text += $" | width: {element.Width} / height: {element.Height}";
            }
        }

        public void ReloadListBox(int index)
        {
            ElementUI.ElementListbox.Items.Clear();

            foreach (Control control in CanvasUI.Controls)
            {
                if (control is ElementControl ec)
                {
                    ElementUI.ElementListbox.Items.Add(new ElementEntity(ec));
                }
            }

            ElementUI.ElementListbox.SelectedIndex = index;
        }
    }
}
