using UOGumpEditor.UOElements;

namespace UOGumpEditor
{
    public class UOGECanvasPanel : UOGEPanel
    {
        private readonly Image _ModeImage;

        public UOGECanvasPanel()
        {
            BackColor = Color.Black;

            Size = new Size(557, 312);

            Padding = new Padding(0);

            if (File.Exists(UOArtLoader.BGImageFile))
            {
                _ModeImage = Image.FromFile(UOArtLoader.BGImageFile);
            }
            else
            {
                _ModeImage = GumpRes.UOScreen;
            }

            AllowDrop = true;

            Dock = DockStyle.Fill;

            BringToFront();

            ControlAdded += UOGECanvasPanel_ControlAdded;

            ControlRemoved += UOGECanvasPanel_ControlRemoved;

            DragDrop += UOGECanvasPanel_DragDrop;

            DragEnter += UOGECanvasPanel_DragEnter;

            MouseClick += UOGECanvasPanel_MouseClick;
        }

        private void UOGECanvasPanel_MouseClick(object? sender, MouseEventArgs e)
        {
            if (UOEditorCore.Session.MainUI.ElementToolStrip.Visible)
            {
                UOEditorCore.Session.MainUI.ElementToolStrip.Visible = false;
            }
        }

        private void UOGECanvasPanel_ControlAdded(object? sender, ControlEventArgs e)
        {
            if (e.Control is ElementControl ec)
            {
                UOEditorCore.Session.ElementUI.ElementListbox.Items.Add(new ElementEntity(ec));

                UOEditorCore.Session.ElementUI.ElementListbox.SelectedIndex = UOEditorCore.Session.ElementUI.ElementListbox.Items.Count - 1;

                Controls.SetChildIndex(ec, Controls.Count - 1);

                if (ec.Tag != null && ec.Tag is ArtEntity entity)
                {
                    UOEditorCore.Session.AddToHistory(entity);
                }

                UOEditorCore.Session.UpdateElementPosition(ec);

                Invalidate();
            }
        }

        private void UOGECanvasPanel_ControlRemoved(object? sender, ControlEventArgs e)
        {
            if (e.Control is ElementControl ec)
            {
                for (int i = 0; i < UOEditorCore.Session.ElementUI.ElementListbox.Items.Count; i++)
                {
                    if (UOEditorCore.Session.ElementUI.ElementListbox.Items[i] is ElementEntity ee && ee.Element == ec)
                    {
                        UOEditorCore.Session.ElementUI.ElementListbox.Items.Remove(ee);

                        break;
                    }
                }

                Invalidate();
            }
        }

        private void UOGECanvasPanel_DragDrop(object? sender, DragEventArgs e)
        {
            if (e.Data != null && e.Data.GetDataPresent(typeof(ArtEntity)))
            {
                if (e.Data.GetData(typeof(ArtEntity)) is ArtEntity entity)
                {
                    var dropLocation = PointToClient(new Point(e.X, e.Y));

                    ElementControl element = new()
                    {
                        Tag = entity
                    };

                    element.SetImage(entity);

                    if (UOEditorCore.Session.IsGump())
                    {
                        UOEditorCore.InitGumpConditions(entity, element);
                    }
                    else
                    {
                        element.ElementType = ElementTypes.Item;
                    }

                    UOEditorCore.Session.AddToCanvas(element, dropLocation);
                }
            }
        }

        private void UOGECanvasPanel_DragEnter(object? sender, DragEventArgs e)
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

        public void SetMode()
        {
            if (BackgroundImage == null)
            {
                BackgroundImage = _ModeImage;
            }
            else
            {
                BackgroundImage = null;
            }
        }
    }
}
