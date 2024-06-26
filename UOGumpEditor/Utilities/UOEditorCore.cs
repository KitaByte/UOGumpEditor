﻿using System.Diagnostics;
using UOGumpEditor.UOGumps;
using UOGumpEditor.UOElements;

namespace UOGumpEditor
{
    public static class UOEditorCore
    {
        public static SessionEntity Session => Program.Session;

        public static UOArtLoader? ArtLoader { get; private set; }

        public static ArtEntity? CurrentArtDisplayed { get; private set; }

        public static bool IsSearching { get; set; } = false;

        private static Point CurrentPosition = new(0,0);

        private const string LineBreakMarker = "*BR*";

        private static int moveAmount = 1;

        public static Point GetMoveAction(Keys keyData, ElementControl element)
        {
            if ((Control.ModifierKeys & Keys.Shift) == Keys.Shift)
            {
                moveAmount = UOSettings.Default.ShiftSpeed;
            }
            else if ((Control.ModifierKeys & Keys.Control) == Keys.Control)
            {
                moveAmount = UOSettings.Default.CtrlSpeed;
            }
            else
            {
                moveAmount = 1;
            }

            CurrentPosition = element.Location;

            switch (keyData & Keys.KeyCode)
            {
                case Keys.Up:
                    {
                        CurrentPosition = MoveElement(element, 0, -moveAmount);

                        break;
                    }

                case Keys.Down:
                    {
                        CurrentPosition = MoveElement(element, 0, moveAmount);

                        break;
                    }

                case Keys.Left:
                    {
                        CurrentPosition = MoveElement(element, -moveAmount, 0);

                        break;
                    }

                case Keys.Right:
                    {
                        CurrentPosition = MoveElement(element, moveAmount, 0);

                        break;
                    }
            }

            return CurrentPosition;
        }

        private static Point MoveElement(ElementControl element, int dx, int dy)
        {
            return new Point(element.Location.X + dx, element.Location.Y + dy);
        }

        public static bool IsValidMoveKey(Keys keyData)
        {
            switch (keyData)
            {
                case (Keys.Up):
                    {
                        return true;
                    }

                case (Keys.Control | Keys.Up):
                    {
                        return true;
                    }

                case (Keys.Shift | Keys.Up):
                    {
                        return true;
                    }

                case (Keys.Down):
                    {
                        return true;
                    }

                case (Keys.Control | Keys.Down):
                    {
                        return true;
                    }

                case (Keys.Shift | Keys.Down):
                    {
                        return true;
                    }

                case (Keys.Left):
                    {
                        return true;
                    }

                case (Keys.Control | Keys.Left):
                    {
                        return true;
                    }

                case (Keys.Shift | Keys.Left):
                    {
                        return true;
                    }

                case (Keys.Right):
                    {
                        return true;
                    }

                case (Keys.Control | Keys.Right):
                    {
                        return true;
                    }

                case (Keys.Shift | Keys.Right):
                    {
                        return true;
                    }
            }

            return false;
        }

        public static bool MoveLayerUp()
        {
            if (Session.CanvasUI.Controls.Count > 0)
            {
                foreach (Control control in Session.CanvasUI.Controls)
                {
                    if (control is ElementControl ec && ec.IsSelected)
                    {
                        int currentIndex = Session.CanvasUI.Controls.GetChildIndex(ec);

                        if (currentIndex < Session.CanvasUI.Controls.Count - 1)
                        {
                            Session.CanvasUI.Controls.SetChildIndex(ec, currentIndex + 1);

                            Session.CanvasUI.Invalidate();

                            return true;
                        }
                    }
                }
            }

            return false;
        }

        public static bool MoveLayerDown()
        {
            if (Session.CanvasUI.Controls.Count > 0)
            {
                foreach (Control control in Session.CanvasUI.Controls)
                {
                    if (control is ElementControl ec && ec.IsSelected)
                    {
                        int currentIndex = Session.CanvasUI.Controls.GetChildIndex(ec);

                        if (currentIndex > 0)
                        {
                            Session.CanvasUI.Controls.SetChildIndex(ec, currentIndex - 1);

                            Session.CanvasUI.Invalidate();

                            return true;
                        }
                    }
                }
            }

            return false;
        }

        public static void OpenElementEditor(ElementTypes element, ElementControl? elementControl = null)
        {
            Session.CurrentElementType = element;

            Session.CurrentElement = elementControl;

            Session.MainUI.ElementToolStrip.Visible = true;
        }

        public static void ResetEditor()
        {
            if (Session.CanvasUI.BackgroundImage != null)
            {
                Session.CanvasUI.BackgroundImageLayout = ImageLayout.Stretch;

                Session.CanvasUI.BackgroundImage = null;
            }

            Session.CanvasUI.Controls.Clear();

            Session.SearchUI.HistoryListbox.Items.Clear();

            Session.ElementUI.ElementListbox.Items.Clear();

            Session.MainUI.Refresh();
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

                Session.UpdateElementInfo(entity);
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

        public static void InitElement(ElementTypes element, out bool isID, out bool isText, out bool isHue)
        {
            if (element == ElementTypes.Label || element == ElementTypes.Html)
            {
                isID = false;
                isText = true;
            }
            else
            {
                isID = true;
                isText = false;
            }

            switch (element)
            {
                case ElementTypes.Background:
                    {
                        isHue = true;

                        break;
                    }

                case ElementTypes.Image:
                    {
                        isHue = true;

                        break;
                    }

                case ElementTypes.Item:
                    {
                        isHue = true;

                        break;
                    }

                case ElementTypes.TiledImage:
                    {
                        isHue = true;

                        break;
                    }

                case ElementTypes.Label:
                    {
                        isHue = true;

                        break;
                    }

                case ElementTypes.TextEntry:
                    {
                        isHue = true;

                        break;
                    }

                case ElementTypes.Html:
                    {
                        isHue = true;

                        break;
                    }

                default:
                    {
                        isHue = false;

                        break;
                    }
            }
        }

        public static List<Bitmap> GetImages(List<ArtEntity> entities)
        {
            List<Bitmap> images = [];

            if (entities.Count > 0)
            {
                Bitmap? tempImage;
                
                foreach (var entity in entities)
                {
                    tempImage = entity.GetImage();

                    if (tempImage != null)
                    {
                        images.Add(tempImage);
                    }
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

                // Draw corners
                g.DrawImage(bitmaps[0], new Rectangle(0, 0, bitmaps[0].Width, bitmaps[0].Height));
                g.DrawImage(bitmaps[2], new Rectangle(width - bitmaps[2].Width, 0, bitmaps[2].Width, bitmaps[2].Height));
                g.DrawImage(bitmaps[6], new Rectangle(0, height - bitmaps[6].Height, bitmaps[6].Width, bitmaps[6].Height));
                g.DrawImage(bitmaps[8], new Rectangle(width - bitmaps[8].Width, height - bitmaps[8].Height, bitmaps[8].Width, bitmaps[8].Height));

                // Draw edges
                g.DrawImage(bitmaps[1], new Rectangle(bitmaps[0].Width, 0, width - bitmaps[0].Width - bitmaps[2].Width, bitmaps[1].Height));
                g.DrawImage(bitmaps[3], new Rectangle(0, bitmaps[0].Height, bitmaps[3].Width, height - bitmaps[0].Height - bitmaps[6].Height));
                g.DrawImage(bitmaps[5], new Rectangle(width - bitmaps[5].Width, bitmaps[2].Height, bitmaps[5].Width, height - bitmaps[2].Height - bitmaps[8].Height));
                g.DrawImage(bitmaps[7], new Rectangle(bitmaps[6].Width, height - bitmaps[7].Height, width - bitmaps[6].Width - bitmaps[8].Width, bitmaps[7].Height));

                // Draw center
                g.DrawImage(bitmaps[4], new Rectangle(bitmaps[3].Width, bitmaps[1].Height, width - bitmaps[3].Width - bitmaps[5].Width, height - bitmaps[1].Height - bitmaps[7].Height));
            }

            return combinedBitmap;
        }

        public static Bitmap TileImage(Bitmap image, Size size)
        {
            Bitmap tiledBitmap = new(size.Width, size.Height);

            using (Graphics g = Graphics.FromImage(tiledBitmap))
            {
                for (int x = 0; x < size.Width; x += image.Width)
                {
                    for (int y = 0; y < size.Height; y += image.Height)
                    {
                        g.DrawImage(image, new Rectangle(x, y, image.Width, image.Height));
                    }
                }

                // Crop the edges to fit the exact size
                if (size.Width % image.Width != 0 || size.Height % image.Height != 0)
                {
                    g.Clip = new Region(new Rectangle(0, 0, size.Width, size.Height));
                }
            }

            return tiledBitmap;
        }

        public static void PromptUserForImage()
        {
            using OpenFileDialog openFileDialog = new();

            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);

            openFileDialog.Filter = "PNG files (*.png)|*.png|All files (*.*)|*.*";

            openFileDialog.FilterIndex = 1;

            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (File.Exists(UOArtLoader.BGImageFile) && Session.CanvasUI.BackgroundImage != null)
                {
                    Image? image = Session.CanvasUI.BackgroundImage;

                    Session.CanvasUI.BackgroundImage = GumpRes.UOGSLogo;

                    image?.Dispose();

                    GC.Collect();

                    GC.WaitForPendingFinalizers();
                }

                Thread.Sleep(500);

                try
                {
                    File.Copy(openFileDialog.FileName, UOArtLoader.BGImageFile, true);
                }
                catch
                {
                    MessageBox.Show("Error copying image!", "Image Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                Session.CanvasUI.BackgroundImage = Image.FromFile(UOArtLoader.BGImageFile);
            }
        }

        public static Color PromptUserForColor()
        {
            using (ColorDialog colorDialog = new())
            {
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    return colorDialog.Color;
                }
            }

            return Color.Black;
        }

        private static readonly List<Color> _TextColors =
        [
            Color.Blue,
            Color.Purple,
            Color.Pink,
            Color.Red,
            Color.Orange,
            Color.Yellow,
            Color.YellowGreen,
            Color.Green,
            Color.Cyan,
            Color.SteelBlue,
            Color.White
        ];

        public static Color GetColorFromNumber(int number)
        {
            if (number == 0)
            {
                return Color.Black;
            }
            else
            {
                int colorIndex = (number % 100) / 10;

                if (colorIndex < 0)
                {
                    colorIndex = 0;
                }

                if (colorIndex >= _TextColors.Count)
                {
                    colorIndex = _TextColors.Count - 1;
                }

                return _TextColors[colorIndex];
            }
        }

        public static int GetNumberFromColor(Color color)
        {
            if (color == Color.Black || !_TextColors.Contains(color))
            {
                return 0;
            }

            return _TextColors.IndexOf(color) * 10;
        }

        public static void OpenWebsite(string url)
        {
            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = url,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not open the website. Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static string CombineMultiString(string multiLine, bool useMarker = true)
        {
            string[] text = multiLine.Split('\n');

            if (text.Length > 0)
            {
                for (int i = 0; i < text.Length; i++)
                {
                    text[i] = text[i].TrimEnd('\r').Trim();

                    if (i > 0)
                    {
                        if (useMarker)
                        {
                            text[0] += $"{LineBreakMarker}{text[i]}";
                        }
                        else
                        {
                            text[0] += $"{"\\r\\n"}{text[i]}";
                        }
                    }
                }
            }
            else
            {
                text[0] = multiLine;
            }

            return text[0];
        }

        public static string ReturnMultiString(string combinedString)
        {
            return combinedString.Replace(LineBreakMarker, "\r\n");
        }

        public static void SaveGump(string name)
        {
            BaseGump gump = new(Path.GetFileNameWithoutExtension(name));

            foreach (Control control in Session.CanvasUI.Controls)
            {
                if (control is ElementControl elementControl)
                {
                    gump.Elements.Add(new GumpElement(elementControl));
                }
            }

            CSVHelper.SaveGump(gump);

            MessageBox.Show($"{gump.Name} Saved!", "System", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void LoadGump(BaseGump gump)
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
                else
                {
                    control.SetText(element.Text, element.Color);
                }

                Session.CanvasUI.Controls.Add(control);
            }
        }
    }
}
