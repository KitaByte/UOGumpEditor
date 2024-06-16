namespace UOGumpEditor
{
    public class ArtPictureBox : PictureBox
    {
        private readonly ArtEntity _ArtEntity;

        private readonly Image? _Image;

        private readonly Color _Color; 
        
        public static Form? PreviewBox { get; set; }

        public ArtPictureBox(ArtEntity entity, Image? image, Color color)
        {
            _ArtEntity = entity;

            _Image = image;

            _Color = color;

            InitializePictureBox();
        }

        private void InitializePictureBox()
        {
            BorderStyle = BorderStyle.FixedSingle;

            BackColor = _Color;

            Image = _Image;

            Size = new Size(100, 100);

            SizeMode = _ArtEntity.Width > 100 || _ArtEntity.Height > 100 ? PictureBoxSizeMode.Zoom : PictureBoxSizeMode.CenterImage;

            Tag = _ArtEntity;

            Click += ArtPictureBox_Click;

            MouseHover += ArtPictureBox_MouseHover;

            MouseLeave += ArtPictureBox_MouseLeave;
        }

        private void ArtPictureBox_Click(object? sender, EventArgs e)
        {
            if (Image != null)
            {
                UOEditorCore.MainUI?.DisplayArt(_ArtEntity);
            }
        }

        private void ArtPictureBox_MouseHover(object? sender, EventArgs e)
        {
            UOEditorCore.MainUI?.UpdateElementInfo(_ArtEntity);

            if (_ArtEntity.Name.StartsWith("Background"))
            {
                LoadBackground();

                if (BackgroundArt?.Count > 0 && PreviewBox == null)
                {
                    try
                    {
                        PreviewBox = new BackgroundPreview(BackgroundArt)
                        {
                            Location = new Point(Cursor.Position.X + 10, Cursor.Position.Y + 10)
                        };

                        PreviewBox?.Show();
                    }
                    catch
                    {
                        MessageBox.Show("Preview Failed!", "Bug Report", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void ArtPictureBox_MouseLeave(object? sender, EventArgs e)
        {
            if (!UOSettings.Default.PreviewSticky)
            {
                PreviewBox?.Close();

                PreviewBox = null;
            }
        }

        public List<ArtEntity>? BackgroundArt { get; private set; }

        public async void LoadBackground()
        {
            BackgroundArt = [];

            if (Tag is ArtEntity entity)
            {
                List<ArtEntity> searchList = await UOArtLoader.SearchArtByNameAsync(entity.Name[..^1], true);

                if (searchList.Count > 0)
                {
                    foreach (ArtEntity ae in searchList)
                    {
                        if (ae.Name.Length == entity.Name.Length && ae.Name.StartsWith(entity.Name[..^1]))
                        {
                            BackgroundArt.Add(ae);
                        }
                    }

                    if (BackgroundArt.Count > 0)
                    {
                        BackgroundArt.Sort();
                    }
                }
            }
        }
    }
}

