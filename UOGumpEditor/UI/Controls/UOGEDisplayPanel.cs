namespace UOGumpEditor
{
    public class UOGEDisplayPanel : UOGEPanel
    {
        public readonly UOGEButton PrevButton = new ()
        {
            Text = "Prev",
            BackColor = Color.Goldenrod,
            Dock = DockStyle.Top
        };

        public readonly UOGEButton NextButton = new ()
        {
            Text = "Next",
            BackColor = Color.Goldenrod,
            Dock = DockStyle.Bottom
        };

        public FlowLayoutPanel DisplayFlowPanel = new ()
        {
            BackColor = Color.FromArgb(32, 32, 32),
            Dock = DockStyle.Fill
        };

        public UOGEDisplayPanel()
        {
            Size = new Size(557, 312);

            Padding = new Padding(10);

            DisplayFlowPanel.AutoScroll = true;

            Controls.Add(PrevButton);

            Controls.Add(NextButton);

            Controls.Add(DisplayFlowPanel);

            DisplayFlowPanel.BringToFront();

            PrevButton.Click += PrevButton_Click;

            NextButton.Click += NextButton_Click;

            Visible = false;
        }

        private void PrevButton_Click(object? sender, EventArgs e)
        {
            PrevButton.Visible = false;

            if (UOEditorCore.Session.ArtCacheHandle != null)
            {
                UOEditorCore.Session.ArtCacheHandle.ScrollPrev();

                UOEditorCore.Session.SetSearchDisplay();
            }
        }

        private void NextButton_Click(object? sender, EventArgs e)
        {
            NextButton.Visible = false;

            if (UOEditorCore.Session.ArtCacheHandle != null)
            {
                UOEditorCore.Session.ArtCacheHandle.ScrollNext();

                UOEditorCore.Session.SetSearchDisplay();
            }
        }
    }
}
