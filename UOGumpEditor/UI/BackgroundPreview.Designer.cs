namespace UOGumpEditor.UI
{
    partial class BackgroundPreview
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BackgroundPreview));
            DisplayPictureBox = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)DisplayPictureBox).BeginInit();
            SuspendLayout();
            // 
            // DisplayPictureBox
            // 
            DisplayPictureBox.BackgroundImageLayout = ImageLayout.None;
            DisplayPictureBox.Dock = DockStyle.Fill;
            DisplayPictureBox.Location = new Point(0, 0);
            DisplayPictureBox.Margin = new Padding(0);
            DisplayPictureBox.MinimumSize = new Size(149, 151);
            DisplayPictureBox.Name = "DisplayPictureBox";
            DisplayPictureBox.Size = new Size(149, 151);
            DisplayPictureBox.SizeMode = PictureBoxSizeMode.CenterImage;
            DisplayPictureBox.TabIndex = 0;
            DisplayPictureBox.TabStop = false;
            // 
            // BackgroundPreview
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            AutoSize = true;
            BackColor = Color.Black;
            BackgroundImageLayout = ImageLayout.None;
            ClientSize = new Size(149, 151);
            Controls.Add(DisplayPictureBox);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "BackgroundPreview";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Preview";
            TopMost = true;
            Load += BackgroundPreview_Load;
            ((System.ComponentModel.ISupportInitialize)DisplayPictureBox).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox DisplayPictureBox;
    }
}