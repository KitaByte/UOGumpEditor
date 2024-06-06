using UOGumpEditor.UOElements;

namespace UOGumpEditor
{
    public static class UOEditorCore
    {
        public static UOGumpEditorUI? MainUI;

        public static UltimaArtLoader? ArtLoader { get; private set; }

        public static IElement? LastElementControl { get; private set; }

        public static void UpdateElementMove(IElement element)
        {
            LastElementControl = element;
        }

        public static readonly List<Control> Z_Layer = [];

        public static void ReorderZLayers()
        {
            if (Z_Layer.Count > 0 && Z_Layer[0].Parent != null && Z_Layer[0].Parent is Panel panel)
            {
                for (int i = 0; i < Z_Layer.Count; i++)
                {
                    Z_Layer[i].Parent?.Controls.SetChildIndex(Z_Layer[i], i);
                }

                foreach (var control in panel.Controls)
                {
                    if (control is TextElement te)
                    {
                        te.BringToFront();
                    }
                }

                panel.Invalidate();
            }
        }

        public static void MoveLayerUp()
        {
            if (LastElementControl is Control control && Z_Layer.Contains(control))
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
            if (LastElementControl is Control control && Z_Layer.Contains(control))
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

        public static void AddElement(Control control)
        {
            if (!Z_Layer.Contains(control))
            {
                Z_Layer.Add(control);

                if (control is ImageElement ie && ie.Tag != null && ie.Tag is ArtEntity ae)
                {
                    MainUI?.AddToHistory(ae);
                }
            }
        }

        public static void ResetGumpElements()
        {
            Z_Layer.Clear();
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
            ArtLoader = new UltimaArtLoader();
        }

        public static void ReLoadArt()
        {
            UltimaArtLoader.ClearArt();

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
    }
}
