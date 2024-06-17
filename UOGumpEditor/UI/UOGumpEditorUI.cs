using UOGumpEditor.UOElements;

namespace UOGumpEditor
{
    public partial class UOGumpEditorUI : Form
    {
        private ElementControl? _ElementCopy = null;

        private GumpHandler? _Handler;

        public ExportUI? ExportUIHandle { get; set; }

        private SettingsUI? _Settings;

        public UOGumpEditorUI()
        {
            InitializeComponent();

            KeyPreview = true;

            Text = $"{Text} - Ver 1.0.0.11";
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
                using FolderBrowserDialog dialog = new() { Description = "Select UO Folder!" };

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    UOSettings.Default.UO_Folder = dialog.SelectedPath;

                    UOSettings.Default.Save();

                    UOEditorCore.LoadArt();

                    LoadArtAsync();
                }
            }
        }

        private async void LoadArtAsync()
        {
            SetLoadingState(true);

            GumpInfoLabel.Text = "Loading Gump Assets ...";

            await UOArtLoader.LoadAllGumpArtAsync();

            UOProgressBar.Value = 50;

            GumpInfoLabel.Text = "Loading Art Assets ...";

            await UOArtLoader.LoadAllItemArtAsync();

            UOEditorCore.ReLoadArt();

            SetLoadingState(false);

            UOEditorCore.Session.LoadMainControls();

            UOEditorCore.Session.SetMainDisplay(UOEditorCore.Session.CanvasUI);

            UOEditorCore.ResetEditor();

            GumpInfoLabel.Text = "UO Gump Editor - Ready!";
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

            UOProgressBar.Value = isLoading ? 10 : 100;
        }

        private Dictionary<ElementControl, Point> moveElements = [];

        private bool isMoving = false;

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case (Keys.Control | Keys.S):
                    {
                        SaveButton_Click(this, EventArgs.Empty);
                        return true;
                    }

                case (Keys.Control | Keys.O):
                    {
                        LoadButton_Click(this, EventArgs.Empty);

                        return true;
                    }

                case (Keys.Control | Keys.C):
                    {
                        if (UOEditorCore.Session.IsSingleSelected() && UOEditorCore.Session.ElementUI.ElementListbox.SelectedItem is ElementEntity entity)
                        {
                            if (UOEditorCore.Session.CanvasUI.Controls.Contains(entity.Element))
                            {
                                _ElementCopy = entity.Element.Copy();
                            }
                        }

                        return true;
                    }

                case (Keys.Control | Keys.V):
                    {
                        if (_ElementCopy != null)
                        {
                            Panel panel = UOEditorCore.Session.CanvasUI;

                            UOEditorCore.Session.AddToCanvas(_ElementCopy, new(panel.Location.X + (panel.Width / 2), panel.Location.Y + (panel.Height / 2)));

                            _ElementCopy = _ElementCopy.Copy();
                        }

                        return true;
                    }

                case Keys.Delete:
                    {
                        if (UOEditorCore.Session.IsSingleSelected() && UOEditorCore.Session.ElementUI.ElementListbox.SelectedItem is ElementEntity entity)
                        {
                            if (UOEditorCore.Session.CanvasUI.Controls.Contains(entity.Element))
                            {
                                if (MessageBox.Show("Delete element?", "Warning!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                                {
                                    UOEditorCore.Session.RemoveFromCanvas(entity.Element);
                                }
                            }
                        }

                        return true;
                    }

                default:
                    {
                        if (UOEditorCore.Session.CanvasUI.Controls.Count > 0 && !isMoving)
                        {
                            isMoving = true;

                            moveElements.Clear();

                            for (int i = 0; i < UOEditorCore.Session.CanvasUI.Controls.Count; i++)
                            {
                                if (UOEditorCore.Session.CanvasUI.Controls[i] is ElementControl ec && ec.IsSelected)
                                {
                                    Point newPosition = UOEditorCore.GetMoveAction(keyData, ec);

                                    moveElements[ec] = newPosition;
                                }
                            }

                            Task.Run(() =>
                            {
                                UOEditorCore.Session.CanvasUI.Invoke(new Action(() =>
                                {
                                    UOEditorCore.Session.CanvasUI.SuspendLayout();

                                    foreach (var kvp in moveElements)
                                    {
                                        kvp.Key.Location = kvp.Value;
                                    }

                                    UOEditorCore.Session.CanvasUI.ResumeLayout();
                                }));
                            });

                            isMoving = false;

                            return true;
                        }

                        break;
                    }
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void CheckHandler()
        {
            if (_Handler != null && _Handler.Visible)
            {
                _Handler.Close();
            }
        }

        private void NewButton_Click(object sender, EventArgs e)
        {
            UOEditorCore.ResetEditor();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (UOEditorCore.Session.CanvasUI.Controls.Count > 0)
            {
                CheckHandler();

                _Handler = new(GumpActions.Save);

                _Handler.Show();
            }
            else
            {
                MessageBox.Show("Gump Missing!", "Required!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            if (UOEditorCore.Session.CanvasUI.Controls.Count > 0)
            {
                if (MessageBox.Show("Clearing Canvas, Proceed?", "Load Warning!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.Cancel)
                {
                    return;
                }

                UOEditorCore.ResetEditor();
            }

            CheckHandler();

            _Handler = new(GumpActions.Load);

            _Handler.Show();
        }

        private void ExportButton_Click(object sender, EventArgs e)
        {
            if (UOEditorCore.Session.CanvasUI.Controls.Count > 0 && ExportUIHandle == null)
            {
                List<ElementControl> elementList = [];

                foreach (var element in UOEditorCore.Session.CanvasUI.Controls)
                {
                    if (element is ElementControl ec)
                    {
                        elementList.Add(ec);
                    }
                }

                ElementControl[] elements = [.. elementList];

                ExportUIHandle = new ExportUI(elements);

                ExportUIHandle.Show();
            }
            else
            {
                if (ExportUIHandle == null)
                {
                    MessageBox.Show("Gump Missing!", "Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    ExportUIHandle.Close();
                }
            }
        }

        private void ModeButton_Click(object sender, EventArgs e)
        {
            UOEditorCore.Session.CanvasUI.SetMode();
        }

        private void Settings_Click(object sender, EventArgs e)
        {
            // todo Profile settings

            if (_Settings != null && _Settings.Visible)
            {
                _Settings.Close();
            }

            _Settings = new();

            _Settings.Show();
        }

        private void EditorHelpButton_Click(object sender, EventArgs e)
        {
            UOEditorCore.OpenWebsite("https://www.uoopenai.com/uo_gump_editor");
        }

        private void UOGumpEditorUI_Resize(object sender, EventArgs e)
        {
            if (UOEditorCore.Session.DisplayUI.Visible)
            {
                UOEditorCore.Session.DisplayArtWindow();
            }
        }

        private void AddLabelButton_Click(object sender, EventArgs e)
        {
            UOEditorCore.Session.CanvasUI.OpenEditor(ElementTypes.Label);
        }

        private void AddHTMLButton_Click(object sender, EventArgs e)
        {
            UOEditorCore.Session.CanvasUI.OpenEditor(ElementTypes.Html);
        }

        private void RaiseLayerButton_Click(object sender, EventArgs e)
        {
            if (!UOEditorCore.Session.IsSingleSelected())
            {
                MessageBox.Show("Select one element!", "Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            int index = (UOEditorCore.Session.ElementUI.ElementListbox.SelectedIndex + 1);

            if (UOEditorCore.MoveLayerUp())
            {
                UOEditorCore.Session.ReloadListBox(index);
            }
        }

        private void LowerLayerButton_Click(object sender, EventArgs e)
        {
            if (!UOEditorCore.Session.IsSingleSelected())
            {
                MessageBox.Show("Select one element!", "Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            int index = (UOEditorCore.Session.ElementUI.ElementListbox.SelectedIndex - 1);

            if (UOEditorCore.MoveLayerDown())
            {
                UOEditorCore.Session.ReloadListBox(index);
            }
        }

        private void ElementStrip_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Point mousePosition = UOEditorCore.Session.CanvasUI.PointToClient(Cursor.Position);

            if (!UOEditorCore.Session.CanvasUI.ClientRectangle.Contains(mousePosition))
            {
                e.Cancel = true;
            }
        }
    }
}
