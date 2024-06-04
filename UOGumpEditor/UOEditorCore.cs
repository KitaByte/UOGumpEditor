namespace UOGumpEditor
{
    public static class UOEditorCore
    {
        public static UltimaArtLoader? ArtLoader { get; private set; }

        public static void LoadArt()
        {
            ArtLoader = new UltimaArtLoader();
        }

        public static void SetImageRenderer(PictureBox pb, ArtEntity entity, ToolStripLabel label)
        {
            if (entity != null)
            {
                pb.Image = entity.Image;

                if (entity.Width > pb.Width || entity.Height > pb.Height)
                {
                    pb.SizeMode = PictureBoxSizeMode.Zoom;
                }
                else
                {
                    pb.SizeMode = PictureBoxSizeMode.CenterImage;
                }

                label.Text = $"{entity.ID} : [{entity.Name}] - width: {entity.Width} / hieght: {entity.Height}";
            }
        }

        public static void SwapButtonOn(Button btnOn, Button btnOff)
        {
            btnOn.BackColor = Color.DodgerBlue;
            btnOn.ForeColor = Color.WhiteSmoke;

            btnOff.BackColor = Color.RoyalBlue;
            btnOff.ForeColor = Color.Black;
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
    }
}
