namespace UOGumpEditor
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
            DisplayPictureBox.BackColor = Color.White;
            DisplayPictureBox.BackgroundImageLayout = ImageLayout.None;
            DisplayPictureBox.Dock = DockStyle.Fill;
            DisplayPictureBox.Location = new Point(3, 3);
            DisplayPictureBox.Margin = new Padding(5);
            DisplayPictureBox.Name = "DisplayPictureBox";
            DisplayPictureBox.Padding = new Padding(5);
            DisplayPictureBox.Size = new Size(144, 144);
            DisplayPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            DisplayPictureBox.TabIndex = 0;
            DisplayPictureBox.TabStop = false;
            // 
            // BackgroundPreview
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            AutoSize = true;
            BackColor = Color.Goldenrod;
            BackgroundImageLayout = ImageLayout.None;
            ClientSize = new Size(150, 150);
            Controls.Add(DisplayPictureBox);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "BackgroundPreview";
            Padding = new Padding(3);
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.Manual;
            Text = "Preview";
            TopMost = true;
            FormClosed += BackgroundPreview_FormClosed;
            Load += BackgroundPreview_Load;
            ((System.ComponentModel.ISupportInitialize)DisplayPictureBox).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox DisplayPictureBox;
    }
}