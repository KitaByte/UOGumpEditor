namespace UOGumpEditor
{
    partial class GumpHandler
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GumpHandler));
            TitleLabel = new Label();
            NameEntryTextBox = new TextBox();
            GumpListbox = new ListBox();
            SaveLoadExportButton = new Button();
            SuspendLayout();
            // 
            // TitleLabel
            // 
            TitleLabel.Dock = DockStyle.Top;
            TitleLabel.FlatStyle = FlatStyle.Flat;
            TitleLabel.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            TitleLabel.ForeColor = Color.SteelBlue;
            TitleLabel.Location = new Point(0, 0);
            TitleLabel.Name = "TitleLabel";
            TitleLabel.Size = new Size(284, 35);
            TitleLabel.TabIndex = 0;
            TitleLabel.Text = "TITLE";
            TitleLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // NameEntryTextBox
            // 
            NameEntryTextBox.BackColor = Color.White;
            NameEntryTextBox.BorderStyle = BorderStyle.FixedSingle;
            NameEntryTextBox.Dock = DockStyle.Top;
            NameEntryTextBox.ForeColor = Color.Black;
            NameEntryTextBox.Location = new Point(0, 35);
            NameEntryTextBox.Margin = new Padding(0);
            NameEntryTextBox.MaxLength = 256;
            NameEntryTextBox.Name = "NameEntryTextBox";
            NameEntryTextBox.PlaceholderText = "NAME";
            NameEntryTextBox.Size = new Size(284, 25);
            NameEntryTextBox.TabIndex = 1;
            NameEntryTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // GumpListbox
            // 
            GumpListbox.BackColor = Color.White;
            GumpListbox.BorderStyle = BorderStyle.FixedSingle;
            GumpListbox.Dock = DockStyle.Top;
            GumpListbox.ForeColor = Color.Black;
            GumpListbox.FormattingEnabled = true;
            GumpListbox.ItemHeight = 17;
            GumpListbox.Location = new Point(0, 60);
            GumpListbox.Margin = new Padding(0);
            GumpListbox.Name = "GumpListbox";
            GumpListbox.ScrollAlwaysVisible = true;
            GumpListbox.Size = new Size(284, 87);
            GumpListbox.TabIndex = 2;
            GumpListbox.SelectedIndexChanged += GumpListbox_SelectedIndexChanged;
            // 
            // SaveLoadExportButton
            // 
            SaveLoadExportButton.BackColor = Color.SteelBlue;
            SaveLoadExportButton.BackgroundImageLayout = ImageLayout.None;
            SaveLoadExportButton.Dock = DockStyle.Top;
            SaveLoadExportButton.FlatAppearance.BorderSize = 0;
            SaveLoadExportButton.FlatStyle = FlatStyle.Flat;
            SaveLoadExportButton.ForeColor = Color.WhiteSmoke;
            SaveLoadExportButton.Location = new Point(0, 147);
            SaveLoadExportButton.Margin = new Padding(0);
            SaveLoadExportButton.Name = "SaveLoadExportButton";
            SaveLoadExportButton.Size = new Size(284, 35);
            SaveLoadExportButton.TabIndex = 3;
            SaveLoadExportButton.Text = "SUBMIT";
            SaveLoadExportButton.UseVisualStyleBackColor = false;
            SaveLoadExportButton.Click += SaveLoadExportButton_Click;
            // 
            // GumpHandler
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = Color.WhiteSmoke;
            BackgroundImageLayout = ImageLayout.None;
            ClientSize = new Size(284, 184);
            Controls.Add(SaveLoadExportButton);
            Controls.Add(GumpListbox);
            Controls.Add(NameEntryTextBox);
            Controls.Add(TitleLabel);
            Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ForeColor = Color.Black;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            MinimumSize = new Size(300, 0);
            Name = "GumpHandler";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gump Processor";
            TopMost = true;
            Load += GumpHandler_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label TitleLabel;
        private TextBox NameEntryTextBox;
        private ListBox GumpListbox;
        private Button SaveLoadExportButton;
    }
}