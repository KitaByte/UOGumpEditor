namespace UOGumpEditor.UI
{
    public partial class BackgroundPreview : Form
    {
        private readonly List<ArtEntity> artList;

        public BackgroundPreview(List<ArtEntity> bgList)
        {
            InitializeComponent();

            if (UOSettings.Default.PreviewSticky)
            {
                FormBorderStyle = FormBorderStyle.FixedSingle;
            }

            BackColor = UOSettings.Default.ArtDisplayColor;

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
                DisplayPictureBox.Image = UOEditorCore.CombineBitmaps(UOEditorCore.GetImages(artList));
            }
        }

        private void BackgroundPreview_FormClosed(object sender, FormClosedEventArgs e)
        {
            ArtPictureBox.PreviewBox = null;
        }
    }
}
