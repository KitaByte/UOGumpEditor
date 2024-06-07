namespace UOGumpEditor
{
    public class ArtPictureBox : PictureBox
    {
        private readonly ArtEntity _ArtEntity;

        private readonly Image? _Image;

        private readonly Color _Color;

        public ArtPictureBox(ArtEntity entity, Image? image, Color color)
        {
            _ArtEntity = entity;

            _Image = image;

            _Color = color;

            InitializePictureBox();
        }

        private void InitializePictureBox()
        {
            BorderStyle = BorderStyle.Fixed3D;

            BackColor = _Color;

            Image = _Image;

            Size = new Size(100, 100);

            SizeMode = _ArtEntity.Width > 100 || _ArtEntity.Height > 100 ? PictureBoxSizeMode.Zoom : PictureBoxSizeMode.CenterImage;

            Tag = _ArtEntity;

            Click += ArtPictureBox_Click;

            MouseHover += ArtPictureBox_MouseHover;
        }

        private void ArtPictureBox_Click(object? sender, EventArgs e)
        {
            UOEditorCore.MainUI?.DisplayArt(_ArtEntity);
        }

        private void ArtPictureBox_MouseHover(object? sender, EventArgs e)
        {
            UOEditorCore.MainUI?.UpdateElementInfo(_ArtEntity);
        }
    }
}

