using UOGumpEditor.Assets;
using UOGumpEditor.UOElements;

namespace UOGumpEditor
{
    public class SessionEntity(UOGumpEditorUI ui)
    {
        public UOGumpEditorUI MainUI { get; init; } = ui;

        public ArtCache? ArtCacheHandle { get; set; } = null;

        public ExportUI? ExportUIHandle { get; set; }

        public UOGECanvasPanel CanvasUI { get; init; } = new UOGECanvasPanel();

        public UOGEDisplayPanel DisplayUI { get; init; } = new UOGEDisplayPanel();

        public UOGEElementPanel ElementUI { get; init; } = new UOGEElementPanel();

        public UOGESearchPanel SearchUI { get; init; } = new UOGESearchPanel();

        public ElementControl? CurrentElement { get; set; } = null;

        public ElementTypes CurrentElementType { get; set; } = ElementTypes.AlphaRegion;

        public readonly Dictionary<ElementControl, Point> SelectedElements = [];

        private readonly Dictionary<ElementControl, Point> ElementCopyList = [];

        private ElementControl? _CopyiedElement;

        private (int x, int y, int z) _elementPos;

        public void UpdateSelected(ElementControl control, Point point)
        {
            if (control.IsSelected)
            {
                SelectedElements.TryAdd(control, point);
            }
            else
            {
                SelectedElements.Remove(control);
            }
        }

        public void UpdateCopyList()
        {
            if (ElementUI.ElementListbox.SelectedItems.Count > 0)
            {
                ElementCopyList.Clear();

                foreach (ElementEntity entity in ElementUI.ElementListbox.SelectedItems)
                {
                    if (entity != null && entity.Element != null)
                    {
                        _CopyiedElement = entity.Element.Copy();

                        if (_CopyiedElement != null)
                        {
                            ElementCopyList.TryAdd
                                (
                                    _CopyiedElement, 
                                    new Point
                                    (
                                        entity.Element.Location.X + (entity.Element.Width / 2) + 5, 
                                        entity.Element.Location.Y + (entity.Element.Height / 2) + 5
                                    )
                                );
                        }
                    }
                }
            }
        }

        public void PlaceCopyList()
        {
            if (ElementCopyList.Count > 0)
            {
                ElementUI.ElementListbox.ClearSelected();

                foreach (var kvp in ElementCopyList)
                {
                    AddToCanvas(kvp.Key, kvp.Value);
                }

                UpdateCopyList();
            }
        }

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

        public void SetSearchDisplay()
        {
            if (ArtCacheHandle != null)
            {
                DisplayUI.PrevButton.Visible = ArtCacheHandle.CanScrollPrev();

                DisplayUI.NextButton.Visible = ArtCacheHandle.CanScrollNext();

                DisplaySearchResults(ArtCacheHandle.GetCurrentWindow(DisplayUI.DisplayFlowPanel));

                SetMainDisplay(DisplayUI);
            }

            UOEditorCore.IsSearching = false;
        }

        private void DisplaySearchResults(List<ArtEntity> results)
        {
            if (results.Count > 0)
            {
                DisplayUI.DisplayFlowPanel.Controls.Clear();

                DisplayUI.DisplayFlowPanel.SuspendLayout();

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

                DisplayUI.DisplayFlowPanel.ResumeLayout();

                DisplayUI.DisplayFlowPanel.Visible = true;
            }
        }

        public bool IsGump()
        {
            return SearchUI.GumpArtButton.BackColor == Color.DodgerBlue;
        }

        public bool IsSingleSelected(out ElementControl? element)
        {
            if (ElementUI.ElementListbox.SelectedItems.Count == 1 && ElementUI.ElementListbox.SelectedItem is ElementEntity ee)
            {
                element = ee.Element;

                return true;
            }
            else
            {
                element = null;

                return false;
            }
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

                UpdateElementPosition(element);
            }
        }

        public void UpdateElementPosition(ElementControl element)
        {
            _elementPos = element.GetLocation();

            MainUI.ElementLocationLabel.Text = $"Position [ X {_elementPos.x} | Y {_elementPos.y} | Z {_elementPos.z} ]";
        }

        public void ReloadListBox(bool raise)
        {
            int index;

            if (raise)
            {
                index = ElementUI.ElementListbox.SelectedIndex + 1;
            }
            else
            {
                index = ElementUI.ElementListbox.SelectedIndex - 1;
            }

            if (ElementUI.ElementListbox.SelectedItem != null && ElementUI.ElementListbox.SelectedItem is ElementEntity ee)
            {
                ElementEntity tempEntity = ee;

                ElementUI.ElementListbox.Items.Remove(tempEntity);

                ElementUI.ElementListbox.Items.Insert(index, tempEntity);

                ElementUI.ElementListbox.SelectedIndex = index;
            }
        }

        public void SetElementID(string text)
        {
            if (CurrentElement?.Tag is ArtEntity)
            {
                if (int.TryParse(text, out int id))
                {
                    CurrentElement.Tag = UOArtLoader.GetArtEntity(id, CurrentElementType != ElementTypes.Item);

                    if (CurrentElement.Tag is ArtEntity ae)
                    {
                        CurrentElement.SetImage(ae);
                    }
                }
            }
        }

        public void SetElementText(string text, Color color)
        {
            if (!string.IsNullOrEmpty(text))
            {
                if (CurrentElement == null)
                {
                    AddTextElement(text, Color.White, CurrentElementType);
                }
                else
                {
                    CurrentElement.Text = text;

                    CurrentElement.TextColor = color;
                }
            }
        }

        public void SetElementHue(string text, out Color color)
        {
            if (CurrentElement != null && int.TryParse(text, out int hue))
            {
                if (CurrentElement.Tag is ArtEntity ae && hue != 0)
                {
                    Bitmap? image = ae.GetImage();

                    if (image != null)
                    {
                        ae.Hue = hue;

                        AssetData.Hues.ApplyTo(image, hue, false);

                        CurrentElement.Image = image;
                    }
                }
                else
                {
                    CurrentElement.TextColor = UOEditorCore.GetColorFromNumber(hue);

                    color = CurrentElement.TextColor;

                    return;
                }
            }

            color = Color.WhiteSmoke;
        }

        public void UpdateElementSize(string inWidth, string inHeight)
        {
            if (CurrentElement != null && int.TryParse(inWidth, out int width))
            {
                CurrentElement.Width = width;
            }

            if (CurrentElement != null && int.TryParse(inHeight, out int height))
            {
                CurrentElement.Height = height;
            }

            if (CurrentElement?.Tag is ArtEntity entity)
            {
                if (CurrentElementType == ElementTypes.Image && (entity.Width < CurrentElement.Width || entity.Height < CurrentElement.Height))
                {
                    CurrentElement.ElementType = ElementTypes.TiledImage;
                }
                else if (CurrentElement.ElementType == ElementTypes.TiledImage && (entity.Width >= CurrentElement.Width && entity.Height >= CurrentElement.Height))
                {
                    CurrentElement.ElementType = ElementTypes.Image;
                }

                if (CurrentElementType == ElementTypes.Background)
                {
                    CurrentElement.LoadBackground();
                }
            }

            CurrentElement?.Invalidate();
        }

        public void DeleteElement()
        {
            if (CurrentElement != null)
            {
                if (CanvasUI.Controls.Contains(CurrentElement))
                {
                    if (MessageBox.Show("Delete element?", "Warning!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                    {
                        RemoveFromCanvas(CurrentElement);
                    }
                }
            }
        }
    }
}
