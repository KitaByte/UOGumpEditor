using UOGumpEditor.UOElements;

namespace UOGumpEditor
{
    public partial class UOGumpEditorUI : Form
    {
        private GumpHandler? _Handler;

        private SettingsUI? _Settings;

        private bool isMoving = false;

        public UOGumpEditorUI()
        {
            InitializeComponent();

            KeyPreview = true;

            Text = $"{Text} - Ver 1.0.0.13";
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
                        UOEditorCore.Session.UpdateCopyList();

                        return true;
                    }

                case (Keys.Control | Keys.V):
                    {
                        UOEditorCore.Session.PlaceCopyList();

                        return true;
                    }

                case Keys.Delete:
                    {
                        if (UOEditorCore.Session.SelectedElements.Count > 0)
                        {
                            if (MessageBox.Show("Delete element?", "Warning!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                            {
                                List<ElementControl> removeList = [];

                                foreach (ElementControl element in UOEditorCore.Session.CanvasUI.Controls)
                                {
                                    if (element.IsSelected)
                                    {
                                        removeList.Add(element);
                                    }
                                }

                                foreach (ElementControl element in removeList)
                                {
                                    UOEditorCore.Session.RemoveFromCanvas(element);
                                }
                            }
                        }

                        return true;
                    }

                default:
                    {
                        if (UOEditorCore.IsValidMoveKey(keyData))
                        {
                            if (!isMoving && UOEditorCore.Session.SelectedElements.Count > 0)
                            {
                                isMoving = true;

                                foreach (ElementControl element in UOEditorCore.Session.SelectedElements.Keys)
                                {
                                    UOEditorCore.Session.SelectedElements[element] = UOEditorCore.GetMoveAction(keyData, element);
                                }

                                UOEditorCore.Session.CanvasUI.BeginInvoke(new Action(() =>
                                {
                                    UOEditorCore.Session.CanvasUI.SuspendLayout();

                                    foreach (var kvp in UOEditorCore.Session.SelectedElements)
                                    {
                                        kvp.Key.Location = kvp.Value;
                                    }

                                    UOEditorCore.Session.CanvasUI.ResumeLayout(true);

                                    UOEditorCore.Session.CanvasUI.Invalidate();

                                    isMoving = false;
                                }));

                                return true;
                            }
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
            if (UOEditorCore.Session.CanvasUI.Controls.Count > 0 && UOEditorCore.Session.ExportUIHandle == null)
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

                UOEditorCore.Session.ExportUIHandle = new ExportUI(elements);

                UOEditorCore.Session.ExportUIHandle.Show();
            }
            else
            {
                if (UOEditorCore.Session.ExportUIHandle == null)
                {
                    MessageBox.Show("Gump Missing!", "Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    UOEditorCore.Session.ExportUIHandle.Close();
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
            UOEditorCore.OpenElementEditor(ElementTypes.Label);
        }

        private void AddHTMLButton_Click(object sender, EventArgs e)
        {
            UOEditorCore.OpenElementEditor(ElementTypes.Html);
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

        private void ElementToolStrip_VisibleChanged(object sender, EventArgs e)
        {
            if (ElementToolStrip.Visible)
            {
                UOEditorCore.InitElement(UOEditorCore.Session.CurrentElementType, out bool isID, out bool isText, out bool isHue);

                ElementIDLabel.Visible = isID;

                ElementIDTextbox.Visible = isID;

                ElementTextLabel.Visible = isText;

                ElementTextTextbox.Visible = isText;

                ElementHueLabel.Visible = isHue;

                ElementHueTextbox.Visible = isHue;

                if (UOEditorCore.Session.CurrentElementType == ElementTypes.Html)
                {
                    ElementTextTextbox.AcceptsReturn = true;

                    ElementTextTextbox.Multiline = true;

                    ElementTextTextbox.MaxLength *= 10;

                    ElementTextTextbox.Text = "HTML";
                }

                if (UOEditorCore.Session.CurrentElementType == ElementTypes.Label || UOEditorCore.Session.CurrentElementType == ElementTypes.TextEntry)
                {
                    ElementTextTextbox.Text = "Content";
                }

                if (UOEditorCore.Session.CurrentElement != null)
                {
                    if (UOEditorCore.Session.CurrentElement.Tag is ArtEntity entity)
                    {
                        ElementIDTextbox.Text = entity.ID.ToString();

                        ElementHueTextbox.Text = entity.Hue.ToString();
                    }
                    else
                    {
                        ElementTextTextbox.Text = UOEditorCore.Session.CurrentElement.Text;

                        ElementTextTextbox.ForeColor = UOEditorCore.Session.CurrentElement.TextColor;

                        ElementHueTextbox.Text = UOEditorCore.GetNumberFromColor(UOEditorCore.Session.CurrentElement.TextColor).ToString();

                        if (UOEditorCore.Session.CurrentElement.TextColor == Color.White)
                        {
                            ElementTextTextbox.BackColor = Color.Black;
                        }
                    }

                    ElementWidthTextbox.Text = UOEditorCore.Session.CurrentElement.Width.ToString();

                    ElementHeightTextbox.Text = UOEditorCore.Session.CurrentElement.Height.ToString();
                }
            }
        }

        private void ElementApplyButton_Click(object sender, EventArgs e)
        {
            if (ElementIDLabel.Visible)
            {
                UOEditorCore.Session.SetElementID(ElementIDTextbox.Text);
            }

            if (ElementTextLabel.Visible)
            {
                UOEditorCore.Session.SetElementText(ElementTextTextbox.Text, ElementTextTextbox.ForeColor);
            }

            if (ElementHueLabel.Visible)
            {
                UOEditorCore.Session.SetElementHue(ElementHueTextbox.Text, out Color color);

                ElementHueTextbox.ForeColor = color;
            }

            UOEditorCore.Session.UpdateElementSize(ElementWidthTextbox.Text, ElementHeightTextbox.Text);

            ElementToolStrip.Visible = false;
        }

        private void ElementDeleteButton_Click(object sender, EventArgs e)
        {
            UOEditorCore.Session.DeleteElement();

            ElementToolStrip.Visible = false;
        }
    }
}
