namespace UOGumpEditor.UI
{
    public partial class BackgroundPreview : Form
    {
        private List<PictureBox>? picturesBoxes;

        private List<ArtEntity> artList;

        public BackgroundPreview(List<ArtEntity> bgList)
        {
            InitializeComponent();

            artList = bgList;
        }

        private void BackgroundPreview_Load(object sender, EventArgs e)
        {
            LoadPictureBoxes();
        }

        private void LoadPictureBoxes()
        {
            picturesBoxes = [];

            picturesBoxes.Add(BG1PictureBox);

            picturesBoxes.Add(BG2PictureBox);

            picturesBoxes.Add(BG3PictureBox);

            picturesBoxes.Add(BG4PictureBox);

            picturesBoxes.Add(BG5PictureBox);

            picturesBoxes.Add(BG6PictureBox);

            picturesBoxes.Add(BG7PictureBox);

            picturesBoxes.Add(BG8PictureBox);

            picturesBoxes.Add(BG9PictureBox);

            DisplayGrid();
        }

        private void DisplayGrid()
        {
            if (artList.Count > 0 && picturesBoxes?.Count > 0)
            {
                for (int i = 0; i < artList.Count; i++)
                {
                    if (i < 9)
                    {
                        picturesBoxes[i].Image = artList[i].GetImage();
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }
    }
}
