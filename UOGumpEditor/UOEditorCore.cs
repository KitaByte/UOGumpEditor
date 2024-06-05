using UOGumpEditor.UOElements;

namespace UOGumpEditor
{
    public static class UOEditorCore
    {
        public static UOGumpEditorUI? MainUI;

        public static UltimaArtLoader? ArtLoader { get; private set; }

        public static readonly List<Control> Z_Layer = [];

        public static void ReorderZLayers()
        {
            for (int i = 0; i < Z_Layer.Count; i++)
            {
                if (Z_Layer[i] is ImageElement)
                {
                    Z_Layer[i].SendToBack();
                }
            }

            Z_Layer[0].Parent?.Invalidate();
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

        internal static void ReLoadArt()
        {
            UltimaArtLoader.ClearArt();

            LoadArt();
        }

        public static void SetImageRenderer(PictureBox pb, ArtEntity entity, ToolStripLabel label)
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

                label.Text = $"{(entity.IsGump ? "Gump" : "Item")} {entity.ID} : [{entity.Name}] - width: {entity.Width} / hieght: {entity.Height}";
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
