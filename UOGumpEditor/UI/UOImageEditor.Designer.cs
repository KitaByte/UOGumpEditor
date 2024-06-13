namespace UOGumpEditor
{
    partial class UOImageEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UOImageEditor));
            WidthButton = new Button();
            HeightButton = new Button();
            HueButton = new Button();
            IDButton = new Button();
            HeightPanel = new Panel();
            HeightTextbox = new TextBox();
            WidthPanel = new Panel();
            WidthTextbox = new TextBox();
            IDPanel = new Panel();
            IDTextbox = new TextBox();
            BottomButtonPanel = new Panel();
            DeleteButton = new Button();
            CloseButton = new Button();
            HuePanel = new Panel();
            HueTextbox = new TextBox();
            TextPanel = new Panel();
            TextTextbox = new TextBox();
            TextButton = new Button();
            HeightPanel.SuspendLayout();
            WidthPanel.SuspendLayout();
            IDPanel.SuspendLayout();
            BottomButtonPanel.SuspendLayout();
            HuePanel.SuspendLayout();
            TextPanel.SuspendLayout();
            SuspendLayout();
            // 
            // WidthButton
            // 
            WidthButton.BackColor = Color.Gainsboro;
            WidthButton.BackgroundImageLayout = ImageLayout.None;
            WidthButton.Dock = DockStyle.Left;
            WidthButton.FlatAppearance.BorderSize = 0;
            WidthButton.FlatStyle = FlatStyle.Flat;
            WidthButton.ForeColor = Color.Black;
            WidthButton.Location = new Point(0, 0);
            WidthButton.Margin = new Padding(0);
            WidthButton.Name = "WidthButton";
            WidthButton.Size = new Size(132, 25);
            WidthButton.TabIndex = 0;
            WidthButton.Text = "Set Width";
            WidthButton.UseVisualStyleBackColor = false;
            WidthButton.Click += WidthButton_Click;
            // 
            // HeightButton
            // 
            HeightButton.BackColor = Color.LightGray;
            HeightButton.BackgroundImageLayout = ImageLayout.None;
            HeightButton.Dock = DockStyle.Left;
            HeightButton.FlatAppearance.BorderSize = 0;
            HeightButton.FlatStyle = FlatStyle.Flat;
            HeightButton.ForeColor = Color.Black;
            HeightButton.Location = new Point(0, 0);
            HeightButton.Margin = new Padding(0);
            HeightButton.Name = "HeightButton";
            HeightButton.Size = new Size(132, 25);
            HeightButton.TabIndex = 0;
            HeightButton.Text = "Set Height";
            HeightButton.UseVisualStyleBackColor = false;
            HeightButton.Click += HeightButton_Click;
            // 
            // HueButton
            // 
            HueButton.BackColor = Color.Silver;
            HueButton.BackgroundImageLayout = ImageLayout.None;
            HueButton.Dock = DockStyle.Left;
            HueButton.FlatAppearance.BorderSize = 0;
            HueButton.FlatStyle = FlatStyle.Flat;
            HueButton.ForeColor = Color.Black;
            HueButton.Location = new Point(0, 0);
            HueButton.Margin = new Padding(0);
            HueButton.Name = "HueButton";
            HueButton.Size = new Size(132, 25);
            HueButton.TabIndex = 0;
            HueButton.Text = "Set Hue";
            HueButton.UseVisualStyleBackColor = false;
            HueButton.Click += HueButton_Click;
            // 
            // IDButton
            // 
            IDButton.BackColor = Color.FromArgb(64, 64, 64);
            IDButton.BackgroundImageLayout = ImageLayout.None;
            IDButton.Dock = DockStyle.Left;
            IDButton.FlatAppearance.BorderSize = 0;
            IDButton.FlatStyle = FlatStyle.Flat;
            IDButton.ForeColor = Color.WhiteSmoke;
            IDButton.Location = new Point(0, 0);
            IDButton.Margin = new Padding(0);
            IDButton.Name = "IDButton";
            IDButton.Size = new Size(132, 25);
            IDButton.TabIndex = 0;
            IDButton.Text = "Set ID";
            IDButton.UseVisualStyleBackColor = false;
            IDButton.Click += IDButton_Click;
            // 
            // HeightPanel
            // 
            HeightPanel.BackgroundImageLayout = ImageLayout.None;
            HeightPanel.Controls.Add(HeightTextbox);
            HeightPanel.Controls.Add(HeightButton);
            HeightPanel.Dock = DockStyle.Top;
            HeightPanel.Location = new Point(10, 85);
            HeightPanel.Margin = new Padding(0);
            HeightPanel.Name = "HeightPanel";
            HeightPanel.Size = new Size(264, 25);
            HeightPanel.TabIndex = 2;
            // 
            // HeightTextbox
            // 
            HeightTextbox.BackColor = Color.WhiteSmoke;
            HeightTextbox.BorderStyle = BorderStyle.FixedSingle;
            HeightTextbox.Dock = DockStyle.Right;
            HeightTextbox.ForeColor = Color.Black;
            HeightTextbox.Location = new Point(132, 0);
            HeightTextbox.Margin = new Padding(0);
            HeightTextbox.MaxLength = 100;
            HeightTextbox.Name = "HeightTextbox";
            HeightTextbox.PlaceholderText = "0";
            HeightTextbox.Size = new Size(132, 25);
            HeightTextbox.TabIndex = 1;
            HeightTextbox.TextAlign = HorizontalAlignment.Center;
            // 
            // WidthPanel
            // 
            WidthPanel.BackgroundImageLayout = ImageLayout.None;
            WidthPanel.Controls.Add(WidthTextbox);
            WidthPanel.Controls.Add(WidthButton);
            WidthPanel.Dock = DockStyle.Top;
            WidthPanel.Location = new Point(10, 60);
            WidthPanel.Margin = new Padding(0);
            WidthPanel.Name = "WidthPanel";
            WidthPanel.Size = new Size(264, 25);
            WidthPanel.TabIndex = 1;
            // 
            // WidthTextbox
            // 
            WidthTextbox.BackColor = Color.WhiteSmoke;
            WidthTextbox.BorderStyle = BorderStyle.FixedSingle;
            WidthTextbox.Dock = DockStyle.Right;
            WidthTextbox.ForeColor = Color.Black;
            WidthTextbox.Location = new Point(132, 0);
            WidthTextbox.Margin = new Padding(0);
            WidthTextbox.MaxLength = 100;
            WidthTextbox.Name = "WidthTextbox";
            WidthTextbox.PlaceholderText = "0";
            WidthTextbox.Size = new Size(132, 25);
            WidthTextbox.TabIndex = 1;
            WidthTextbox.TextAlign = HorizontalAlignment.Center;
            // 
            // IDPanel
            // 
            IDPanel.BackgroundImageLayout = ImageLayout.None;
            IDPanel.Controls.Add(IDTextbox);
            IDPanel.Controls.Add(IDButton);
            IDPanel.Dock = DockStyle.Top;
            IDPanel.Location = new Point(10, 10);
            IDPanel.Margin = new Padding(0);
            IDPanel.Name = "IDPanel";
            IDPanel.Size = new Size(264, 25);
            IDPanel.TabIndex = 0;
            // 
            // IDTextbox
            // 
            IDTextbox.BackColor = Color.WhiteSmoke;
            IDTextbox.BorderStyle = BorderStyle.FixedSingle;
            IDTextbox.Dock = DockStyle.Right;
            IDTextbox.ForeColor = Color.Black;
            IDTextbox.Location = new Point(132, 0);
            IDTextbox.Margin = new Padding(0);
            IDTextbox.MaxLength = 100;
            IDTextbox.Name = "IDTextbox";
            IDTextbox.PlaceholderText = "0";
            IDTextbox.Size = new Size(132, 25);
            IDTextbox.TabIndex = 1;
            IDTextbox.TextAlign = HorizontalAlignment.Center;
            // 
            // BottomButtonPanel
            // 
            BottomButtonPanel.AutoSize = true;
            BottomButtonPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BottomButtonPanel.Controls.Add(DeleteButton);
            BottomButtonPanel.Controls.Add(CloseButton);
            BottomButtonPanel.Dock = DockStyle.Bottom;
            BottomButtonPanel.Location = new Point(10, 135);
            BottomButtonPanel.Margin = new Padding(0);
            BottomButtonPanel.Name = "BottomButtonPanel";
            BottomButtonPanel.Size = new Size(264, 58);
            BottomButtonPanel.TabIndex = 3;
            // 
            // DeleteButton
            // 
            DeleteButton.BackColor = Color.Firebrick;
            DeleteButton.BackgroundImageLayout = ImageLayout.None;
            DeleteButton.Dock = DockStyle.Bottom;
            DeleteButton.FlatAppearance.BorderSize = 0;
            DeleteButton.FlatStyle = FlatStyle.Flat;
            DeleteButton.ForeColor = Color.Gold;
            DeleteButton.Location = new Point(0, 0);
            DeleteButton.Margin = new Padding(0);
            DeleteButton.Name = "DeleteButton";
            DeleteButton.Size = new Size(264, 29);
            DeleteButton.TabIndex = 4;
            DeleteButton.Text = "DELETE";
            DeleteButton.UseVisualStyleBackColor = false;
            DeleteButton.Click += DeleteButton_Click;
            // 
            // CloseButton
            // 
            CloseButton.BackColor = Color.SteelBlue;
            CloseButton.BackgroundImageLayout = ImageLayout.None;
            CloseButton.Dock = DockStyle.Bottom;
            CloseButton.FlatAppearance.BorderSize = 0;
            CloseButton.FlatStyle = FlatStyle.Flat;
            CloseButton.ForeColor = Color.WhiteSmoke;
            CloseButton.Location = new Point(0, 29);
            CloseButton.Margin = new Padding(0);
            CloseButton.Name = "CloseButton";
            CloseButton.Size = new Size(264, 29);
            CloseButton.TabIndex = 5;
            CloseButton.Text = "CLOSE";
            CloseButton.UseVisualStyleBackColor = false;
            CloseButton.Click += CloseButton_Click;
            // 
            // HuePanel
            // 
            HuePanel.BackgroundImageLayout = ImageLayout.None;
            HuePanel.Controls.Add(HueTextbox);
            HuePanel.Controls.Add(HueButton);
            HuePanel.Dock = DockStyle.Top;
            HuePanel.Location = new Point(10, 110);
            HuePanel.Margin = new Padding(0);
            HuePanel.Name = "HuePanel";
            HuePanel.Size = new Size(264, 25);
            HuePanel.TabIndex = 3;
            // 
            // HueTextbox
            // 
            HueTextbox.BackColor = Color.WhiteSmoke;
            HueTextbox.BorderStyle = BorderStyle.FixedSingle;
            HueTextbox.Dock = DockStyle.Right;
            HueTextbox.ForeColor = Color.Black;
            HueTextbox.Location = new Point(132, 0);
            HueTextbox.Margin = new Padding(0);
            HueTextbox.MaxLength = 100;
            HueTextbox.Name = "HueTextbox";
            HueTextbox.PlaceholderText = "0";
            HueTextbox.Size = new Size(132, 25);
            HueTextbox.TabIndex = 1;
            HueTextbox.TextAlign = HorizontalAlignment.Center;
            // 
            // TextPanel
            // 
            TextPanel.BackgroundImageLayout = ImageLayout.None;
            TextPanel.Controls.Add(TextTextbox);
            TextPanel.Controls.Add(TextButton);
            TextPanel.Dock = DockStyle.Top;
            TextPanel.Location = new Point(10, 35);
            TextPanel.Margin = new Padding(0);
            TextPanel.Name = "TextPanel";
            TextPanel.Size = new Size(264, 25);
            TextPanel.TabIndex = 0;
            // 
            // TextTextbox
            // 
            TextTextbox.BackColor = Color.WhiteSmoke;
            TextTextbox.BorderStyle = BorderStyle.FixedSingle;
            TextTextbox.Dock = DockStyle.Right;
            TextTextbox.ForeColor = Color.Black;
            TextTextbox.Location = new Point(132, 0);
            TextTextbox.Margin = new Padding(0);
            TextTextbox.MaxLength = 100;
            TextTextbox.Name = "TextTextbox";
            TextTextbox.PlaceholderText = "label";
            TextTextbox.Size = new Size(132, 25);
            TextTextbox.TabIndex = 1;
            TextTextbox.TextAlign = HorizontalAlignment.Center;
            // 
            // TextButton
            // 
            TextButton.BackColor = Color.FromArgb(64, 64, 64);
            TextButton.BackgroundImageLayout = ImageLayout.None;
            TextButton.Dock = DockStyle.Left;
            TextButton.FlatAppearance.BorderSize = 0;
            TextButton.FlatStyle = FlatStyle.Flat;
            TextButton.ForeColor = Color.WhiteSmoke;
            TextButton.Location = new Point(0, 0);
            TextButton.Margin = new Padding(0);
            TextButton.Name = "TextButton";
            TextButton.Size = new Size(132, 25);
            TextButton.TabIndex = 0;
            TextButton.Text = "Set Text";
            TextButton.UseVisualStyleBackColor = false;
            TextButton.Click += TextButton_Click;
            // 
            // UOImageEditor
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = Color.WhiteSmoke;
            BackgroundImageLayout = ImageLayout.None;
            ClientSize = new Size(284, 203);
            Controls.Add(HuePanel);
            Controls.Add(HeightPanel);
            Controls.Add(WidthPanel);
            Controls.Add(BottomButtonPanel);
            Controls.Add(TextPanel);
            Controls.Add(IDPanel);
            DoubleBuffered = true;
            Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ForeColor = Color.Black;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            MinimumSize = new Size(300, 191);
            Name = "UOImageEditor";
            Padding = new Padding(10);
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Editor";
            TopMost = true;
            Load += UOImageEditor_Load;
            HeightPanel.ResumeLayout(false);
            HeightPanel.PerformLayout();
            WidthPanel.ResumeLayout(false);
            WidthPanel.PerformLayout();
            IDPanel.ResumeLayout(false);
            IDPanel.PerformLayout();
            BottomButtonPanel.ResumeLayout(false);
            HuePanel.ResumeLayout(false);
            HuePanel.PerformLayout();
            TextPanel.ResumeLayout(false);
            TextPanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button WidthButton;
        private Button HeightButton;
        private Button HueButton;
        private Button IDButton;
        private Panel BottomButtonPanel;
        private Button CloseButton;
        private Button DeleteButton;
        private Panel IDPanel;
        private Panel WidthPanel;
        private Panel HeightPanel;
        private Panel HuePanel;
        private TextBox IDTextbox;
        private TextBox WidthTextbox;
        private TextBox HeightTextbox;
        private TextBox HueTextbox;
        private Panel TextPanel;
        private TextBox TextTextbox;
        private Button TextButton;
    }
}