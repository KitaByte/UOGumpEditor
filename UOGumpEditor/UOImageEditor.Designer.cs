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
            PropertyTextBox = new TextBox();
            WidthButton = new Button();
            HeightButton = new Button();
            HueButton = new Button();
            MaxButton = new Button();
            IDButton = new Button();
            MainButtonPanel = new Panel();
            BottomButtonPanel = new Panel();
            DeleteButton = new Button();
            CloseButton = new Button();
            ElementComboBox = new ComboBox();
            MainButtonPanel.SuspendLayout();
            BottomButtonPanel.SuspendLayout();
            SuspendLayout();
            // 
            // PropertyTextBox
            // 
            PropertyTextBox.BackColor = Color.WhiteSmoke;
            PropertyTextBox.BorderStyle = BorderStyle.FixedSingle;
            PropertyTextBox.Dock = DockStyle.Top;
            PropertyTextBox.ForeColor = Color.Black;
            PropertyTextBox.Location = new Point(10, 35);
            PropertyTextBox.Margin = new Padding(0);
            PropertyTextBox.MaxLength = 100;
            PropertyTextBox.Name = "PropertyTextBox";
            PropertyTextBox.PlaceholderText = "< Enter Value Here >";
            PropertyTextBox.Size = new Size(264, 25);
            PropertyTextBox.TabIndex = 1;
            PropertyTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // WidthButton
            // 
            WidthButton.BackColor = Color.Gainsboro;
            WidthButton.BackgroundImageLayout = ImageLayout.None;
            WidthButton.Dock = DockStyle.Left;
            WidthButton.FlatAppearance.BorderSize = 0;
            WidthButton.FlatStyle = FlatStyle.Flat;
            WidthButton.ForeColor = Color.Black;
            WidthButton.Location = new Point(0, 29);
            WidthButton.Margin = new Padding(0);
            WidthButton.Name = "WidthButton";
            WidthButton.Size = new Size(132, 29);
            WidthButton.TabIndex = 1;
            WidthButton.Text = "Set Width";
            WidthButton.UseVisualStyleBackColor = false;
            WidthButton.Click += WidthButton_Click;
            // 
            // HeightButton
            // 
            HeightButton.BackColor = Color.Silver;
            HeightButton.BackgroundImageLayout = ImageLayout.None;
            HeightButton.Dock = DockStyle.Right;
            HeightButton.FlatAppearance.BorderSize = 0;
            HeightButton.FlatStyle = FlatStyle.Flat;
            HeightButton.ForeColor = Color.Black;
            HeightButton.Location = new Point(132, 29);
            HeightButton.Margin = new Padding(0);
            HeightButton.Name = "HeightButton";
            HeightButton.Size = new Size(132, 29);
            HeightButton.TabIndex = 2;
            HeightButton.Text = "Set Height";
            HeightButton.UseVisualStyleBackColor = false;
            HeightButton.Click += HeightButton_Click;
            // 
            // HueButton
            // 
            HueButton.BackColor = Color.SteelBlue;
            HueButton.BackgroundImageLayout = ImageLayout.None;
            HueButton.Dock = DockStyle.Bottom;
            HueButton.FlatAppearance.BorderSize = 0;
            HueButton.FlatStyle = FlatStyle.Flat;
            HueButton.ForeColor = Color.MidnightBlue;
            HueButton.Location = new Point(0, 0);
            HueButton.Margin = new Padding(0);
            HueButton.Name = "HueButton";
            HueButton.Size = new Size(264, 29);
            HueButton.TabIndex = 0;
            HueButton.Text = "Set Hue";
            HueButton.UseVisualStyleBackColor = false;
            HueButton.Click += HueButton_Click;
            // 
            // MaxButton
            // 
            MaxButton.BackColor = Color.Goldenrod;
            MaxButton.BackgroundImageLayout = ImageLayout.None;
            MaxButton.Dock = DockStyle.Bottom;
            MaxButton.FlatAppearance.BorderSize = 0;
            MaxButton.FlatStyle = FlatStyle.Flat;
            MaxButton.ForeColor = Color.Maroon;
            MaxButton.Location = new Point(0, 29);
            MaxButton.Margin = new Padding(0);
            MaxButton.Name = "MaxButton";
            MaxButton.Size = new Size(264, 29);
            MaxButton.TabIndex = 1;
            MaxButton.Text = "Set Text Max Length";
            MaxButton.UseVisualStyleBackColor = false;
            MaxButton.Click += MaxButton_Click;
            // 
            // IDButton
            // 
            IDButton.BackColor = Color.FromArgb(32, 32, 32);
            IDButton.BackgroundImageLayout = ImageLayout.None;
            IDButton.Dock = DockStyle.Top;
            IDButton.FlatAppearance.BorderSize = 0;
            IDButton.FlatStyle = FlatStyle.Flat;
            IDButton.ForeColor = Color.WhiteSmoke;
            IDButton.Location = new Point(0, 0);
            IDButton.Margin = new Padding(0);
            IDButton.Name = "IDButton";
            IDButton.Size = new Size(264, 29);
            IDButton.TabIndex = 0;
            IDButton.Text = "Set ID";
            IDButton.UseVisualStyleBackColor = false;
            IDButton.Click += IDButton_Click;
            // 
            // MainButtonPanel
            // 
            MainButtonPanel.Controls.Add(WidthButton);
            MainButtonPanel.Controls.Add(HeightButton);
            MainButtonPanel.Controls.Add(IDButton);
            MainButtonPanel.Dock = DockStyle.Top;
            MainButtonPanel.Location = new Point(10, 60);
            MainButtonPanel.Margin = new Padding(0);
            MainButtonPanel.Name = "MainButtonPanel";
            MainButtonPanel.Size = new Size(264, 58);
            MainButtonPanel.TabIndex = 2;
            // 
            // BottomButtonPanel
            // 
            BottomButtonPanel.AutoSize = true;
            BottomButtonPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BottomButtonPanel.Controls.Add(HueButton);
            BottomButtonPanel.Controls.Add(MaxButton);
            BottomButtonPanel.Controls.Add(DeleteButton);
            BottomButtonPanel.Controls.Add(CloseButton);
            BottomButtonPanel.Dock = DockStyle.Top;
            BottomButtonPanel.Location = new Point(10, 118);
            BottomButtonPanel.Margin = new Padding(0);
            BottomButtonPanel.Name = "BottomButtonPanel";
            BottomButtonPanel.Size = new Size(264, 116);
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
            DeleteButton.Location = new Point(0, 58);
            DeleteButton.Margin = new Padding(0);
            DeleteButton.Name = "DeleteButton";
            DeleteButton.Size = new Size(264, 29);
            DeleteButton.TabIndex = 2;
            DeleteButton.Text = "DELETE";
            DeleteButton.UseVisualStyleBackColor = false;
            DeleteButton.Click += DeleteButton_Click;
            // 
            // CloseButton
            // 
            CloseButton.BackColor = Color.DarkRed;
            CloseButton.BackgroundImageLayout = ImageLayout.None;
            CloseButton.Dock = DockStyle.Bottom;
            CloseButton.FlatAppearance.BorderSize = 0;
            CloseButton.FlatStyle = FlatStyle.Flat;
            CloseButton.ForeColor = Color.WhiteSmoke;
            CloseButton.Location = new Point(0, 87);
            CloseButton.Margin = new Padding(0);
            CloseButton.Name = "CloseButton";
            CloseButton.Size = new Size(264, 29);
            CloseButton.TabIndex = 3;
            CloseButton.Text = "CLOSE";
            CloseButton.UseVisualStyleBackColor = false;
            CloseButton.Click += CloseButton_Click;
            // 
            // ElementComboBox
            // 
            ElementComboBox.BackColor = Color.Goldenrod;
            ElementComboBox.Dock = DockStyle.Top;
            ElementComboBox.FlatStyle = FlatStyle.Flat;
            ElementComboBox.ForeColor = Color.WhiteSmoke;
            ElementComboBox.FormattingEnabled = true;
            ElementComboBox.Location = new Point(10, 10);
            ElementComboBox.Margin = new Padding(0);
            ElementComboBox.Name = "ElementComboBox";
            ElementComboBox.Size = new Size(264, 25);
            ElementComboBox.Sorted = true;
            ElementComboBox.TabIndex = 0;
            ElementComboBox.SelectedIndexChanged += ElementComboBox_SelectedIndexChanged;
            // 
            // UOImageEditor
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = Color.WhiteSmoke;
            BackgroundImageLayout = ImageLayout.None;
            ClientSize = new Size(284, 251);
            Controls.Add(BottomButtonPanel);
            Controls.Add(MainButtonPanel);
            Controls.Add(PropertyTextBox);
            Controls.Add(ElementComboBox);
            DoubleBuffered = true;
            Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ForeColor = Color.Black;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MaximumSize = new Size(300, 290);
            MinimizeBox = false;
            MinimumSize = new Size(300, 150);
            Name = "UOImageEditor";
            Padding = new Padding(10);
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Image Editor";
            TopMost = true;
            Load += UOImageEditor_Load;
            MainButtonPanel.ResumeLayout(false);
            BottomButtonPanel.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox PropertyTextBox;
        private Button WidthButton;
        private Button HeightButton;
        private Button HueButton;
        private Button MaxButton;
        private Button IDButton;
        private Panel MainButtonPanel;
        private Panel BottomButtonPanel;
        private Button CloseButton;
        private Button DeleteButton;
        private ComboBox ElementComboBox;
    }
}