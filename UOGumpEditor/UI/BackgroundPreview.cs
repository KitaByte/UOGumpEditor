namespace UOGumpEditor.UI
{
    public partial class BackgroundPreview : Form
    {
        private readonly List<ArtEntity> artList;

        public BackgroundPreview(List<ArtEntity> bgList)
        {
            InitializeComponent();

            artList = bgList;
        }

        private void BackgroundPreview_Load(object sender, EventArgs e)
        {
            DisplayGrid();
        }

        private void DisplayGrid()
        {
            if (artList.Count > 0)
            {
                List<Bitmap> imageList = [];

                foreach (var entity in artList)
                {
                    Bitmap? image = entity.GetImage();

                    if (image != null)
                    {
                        imageList.Add(image);
                    }
                }

                if (imageList.Count > 0)
                {
                    DisplayPictureBox.Image = UOEditorCore.CombineBitmaps(imageList);
                }
            }
        }
    }
}
