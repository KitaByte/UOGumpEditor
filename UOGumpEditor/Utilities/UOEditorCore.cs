using UOGumpEditor.UOElements;
using UOGumpEditor.UOGumps;

namespace UOGumpEditor
{
    public static class UOEditorCore
    {
        public static UOGumpEditorUI? MainUI { get; private set; }

        internal static void SetMainHandle(UOGumpEditorUI ui)
        {
            MainUI = ui;
        }

        public static UOArtLoader? ArtLoader { get; private set; }

        public static ElementControl? CurrentEleControl { get; private set; }

        public static void UpdateElementMove(ElementControl element, bool clearList = true)
        {
            CurrentEleControl = element;

            if (clearList)
            {
                MainUI?.ClearSelected();
            }
        }

        public static void SendMoveAction(Keys keyData, ElementControl element)
        {
            switch (keyData)
            {
                case Keys.Up:
                    MoveElement(element, 0, -1);
                    break;
                case Keys.Down:
                    MoveElement(element, 0, 1);
                    break;
                case Keys.Left:
                    MoveElement(element, -1, 0);
                    break;
                case Keys.Right:
                    MoveElement(element, 1, 0);
                    break;
            }
        }

        public static void MoveElement(ElementControl element, int dx, int dy)
        {
            if (MainUI != null)
            {
                element.Location = new Point(element.Location.X + dx, element.Location.Y + dy);

                MainUI.CanvasPanel.Invalidate();
            }
        }

        public static readonly List<ElementControl> Z_Layer = [];

        public static void ReorderZLayers()
        {
            if (Z_Layer.Count > 0 && MainUI?.CanvasPanel != null)
            {
                for (int i = 0; i < Z_Layer.Count; i++)
                {
                    MainUI.CanvasPanel.Controls.SetChildIndex(Z_Layer[i], Z_Layer.Count - 1 - i);
                }

                MainUI.CanvasPanel.Invalidate();

                MainUI.ReorderLayerList();
            }
        }

        public static void MoveLayerUp()
        {
            if (CurrentEleControl is ElementControl control && Z_Layer.Contains(control))
            {
                int currentIndex = Z_Layer.IndexOf(control);

                if (currentIndex > 0)
                {
                    Z_Layer.RemoveAt(currentIndex);

                    Z_Layer.Insert(currentIndex - 1, control);

                    ReorderZLayers();
                }
            }
        }

        public static void MoveLayerDown()
        {
            if (CurrentEleControl is ElementControl control && Z_Layer.Contains(control))
            {
                int currentIndex = Z_Layer.IndexOf(control);

                if (currentIndex < Z_Layer.Count - 1)
                {
                    Z_Layer.RemoveAt(currentIndex);

                    Z_Layer.Insert(currentIndex + 1, control);

                    ReorderZLayers();
                }
            }
        }

        public static void AddElement(ElementControl control)
        {
            if (!Z_Layer.Contains(control))
            {
                Z_Layer.Insert(0, control);

                if (control.Tag is ArtEntity ae)
                {
                    MainUI?.AddToHistory(ae);
                }
            }
        }

        public static void ResetEditor()
        {
            Z_Layer.Clear();

            if (MainUI != null)
            {
                MainUI.CanvasPanel.Controls.Clear();

                MainUI.HistoryListbox.Items.Clear();

                MainUI.LayerListbox.Items.Clear();
            }
        }

        public static string? FindDataFile(string dataPath, string search)
        {
            var fullName = Path.Combine(dataPath, search);

            if (File.Exists(fullName))
            {
                return fullName;
            }

            foreach (var file in Directory.EnumerateFiles(dataPath, search, SearchOption.AllDirectories))
            {
                return file;
            }

            return null;
        }

        public static void LoadArt()
        {
            ArtLoader = new UOArtLoader();
        }

        public static void ReLoadArt()
        {
            UOArtLoader.ClearArt();

            LoadArt();
        }

        public static ArtEntity? CurrentArtDisplayed { get; private set; }

        public static void SetImageRenderer(PictureBox pb, ArtEntity entity)
        {
            if (entity != null)
            {
                pb.Tag = entity;

                pb.Image = entity.GetImage();

                if (entity.Width > pb.Width || entity.Height > pb.Height)
                {
                    pb.SizeMode = PictureBoxSizeMode.Zoom;
                }
                else
                {
                    pb.SizeMode = PictureBoxSizeMode.CenterImage;
                }

                CurrentArtDisplayed = entity;

                MainUI?.UpdateElementInfo(entity);
            }
        }

        public static void SwapButtonOn(Button btnOn, Button btnOff)
        {
            btnOn.BackColor = Color.DodgerBlue;
            btnOn.ForeColor = Color.WhiteSmoke;

            btnOff.BackColor = Color.RoyalBlue;
            btnOff.ForeColor = Color.Black;
        }

        public static Size GetTextSize(string text, Font font)
        {
            return TextRenderer.MeasureText(text, font);
        }

        public static void InitGumpConditions(ArtEntity entity, ElementControl element) 
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

        public static void InitElement(ElementTypes element, ComboBox comboBox, Button hue)
        {
            switch (element)
            {
                case ElementTypes.AlphaRegion:
                    {
                        comboBox.Items.Add(ElementTypes.AlphaRegion);

                        break;
                    }

                case ElementTypes.Background:
                    {
                        comboBox.Items.Add(ElementTypes.Background);
                        comboBox.Items.Add(ElementTypes.TiledImage);
                        hue.Visible = true;

                        break;
                    }

                case ElementTypes.Button:
                    {
                        comboBox.Items.Add(ElementTypes.Button);

                        break;
                    }

                case ElementTypes.CheckBox:
                    {
                        comboBox.Items.Add(ElementTypes.CheckBox);

                        break;
                    }

                case ElementTypes.Image:
                    {
                        comboBox.Items.Add(ElementTypes.Image);
                        comboBox.Items.Add(ElementTypes.TiledImage);
                        hue.Visible = true;

                        break;
                    }

                case ElementTypes.Item:
                    {
                        comboBox.Items.Add(ElementTypes.Item);
                        hue.Visible = true;

                        break;
                    }

                case ElementTypes.RadioButton:
                    {
                        comboBox.Items.Add(ElementTypes.RadioButton);

                        break;
                    }

                case ElementTypes.TextEntry:
                    {
                        comboBox.Items.Add(ElementTypes.TextEntry);
                        comboBox.Items.Add(ElementTypes.TextEntryLimited);

                        break;
                    }

                case ElementTypes.TextEntryLimited:
                    {
                        comboBox.Items.Add(ElementTypes.TextEntry);
                        comboBox.Items.Add(ElementTypes.TextEntryLimited);

                        break;
                    }

                case ElementTypes.TiledImage:
                    {
                        comboBox.Items.Add(ElementTypes.Image);
                        comboBox.Items.Add(ElementTypes.TiledImage);
                        hue.Visible = true;

                        break;
                    }
            }
        }

        public static List<Bitmap> GetImages(List<ArtEntity> entities)
        {
            List<Bitmap> images = [];

            if (entities.Count > 0)
            {
                foreach (var entity in entities)
                {
                    images.Add(entity.GetImage());
                }
            }

            return images;
        }

        public static Bitmap? CombineBitmaps(List<Bitmap> bitmaps)
        {
            if (bitmaps == null || bitmaps.Count != 9)
            {
                MessageBox.Show("Invalid number of images!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return null;
            }

            Bitmap centerBitmap = bitmaps[4];

            int width = centerBitmap.Width * 3;

            int height = centerBitmap.Height * 3;

            Bitmap combinedBitmap = new(width, height);

            using (Graphics g = Graphics.FromImage(combinedBitmap))
            {
                g.Clear(Color.Transparent);

                // Top-left
                g.DrawImage(bitmaps[0], new Rectangle(0, 0, centerBitmap.Width, centerBitmap.Height));
                // Top-center
                g.DrawImage(bitmaps[1], new Rectangle(centerBitmap.Width, 0, centerBitmap.Width, centerBitmap.Height));
                // Top-right
                g.DrawImage(bitmaps[2], new Rectangle(centerBitmap.Width * 2, 0, centerBitmap.Width, centerBitmap.Height));
                // Middle-left
                g.DrawImage(bitmaps[3], new Rectangle(0, centerBitmap.Height, centerBitmap.Width, centerBitmap.Height));
                // Middle-center (fill)
                g.DrawImage(centerBitmap, new Rectangle(centerBitmap.Width, centerBitmap.Height, centerBitmap.Width, centerBitmap.Height));
                // Middle-right
                g.DrawImage(bitmaps[5], new Rectangle(centerBitmap.Width * 2, centerBitmap.Height, centerBitmap.Width, centerBitmap.Height));
                // Bottom-left
                g.DrawImage(bitmaps[6], new Rectangle(0, centerBitmap.Height * 2, centerBitmap.Width, centerBitmap.Height));
                // Bottom-center
                g.DrawImage(bitmaps[7], new Rectangle(centerBitmap.Width, centerBitmap.Height * 2, centerBitmap.Width, centerBitmap.Height));
                // Bottom-right
                g.DrawImage(bitmaps[8], new Rectangle(centerBitmap.Width * 2, centerBitmap.Height * 2, centerBitmap.Width, centerBitmap.Height));
            }

            return combinedBitmap;
        }

        public static void SaveGump(string name)
        {
            if (MainUI != null)
            {
                BaseGump gump = new(Path.GetFileNameWithoutExtension(name));

                foreach (Control control in MainUI.CanvasPanel.Controls)
                {
                    if (control is ElementControl elementControl)
                    {
                        gump.Elements.Add(new GumpElement(elementControl));
                    }
                }

                CSVHelper.SaveGump(gump);

                MessageBox.Show($"{gump.Name} Saved!", "System", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public static void LoadGump(BaseGump gump)
        {
            if (MainUI != null)
            {
                foreach (var element in gump.Elements)
                {
                    ElementControl control = new()
                    {
                        Text = element.Text,
                        ElementType = (ElementTypes)Enum.Parse(typeof(ElementTypes), element.Type),
                        Location = element.Location,
                        Size = element.Size,
                        ForeColor = element.Color,
                        Tag = element.ToArtEntity()
                    };

                    if (control.Tag is ArtEntity entity)
                    {
                        if (control.ElementType != ElementTypes.Item)
                        {
                            InitGumpConditions(entity, control);
                        }

                        control.SetImage(entity);
                    }

                    MainUI.CanvasPanel.Controls.Add(control);

                    AddElement(control);
                }

                ReorderZLayers();
            }
        }
    }
}
