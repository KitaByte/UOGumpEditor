namespace UOGumpEditor
{
    partial class UOTextEntry
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UOTextEntry));
            TextEntryBox = new TextBox();
            OKButton = new Button();
            HueButton = new Button();
            DeleteButton = new Button();
            SuspendLayout();
            // 
            // TextEntryBox
            // 
            TextEntryBox.BackColor = Color.WhiteSmoke;
            TextEntryBox.BorderStyle = BorderStyle.FixedSingle;
            TextEntryBox.Dock = DockStyle.Top;
            TextEntryBox.ForeColor = Color.Black;
            TextEntryBox.Location = new Point(10, 10);
            TextEntryBox.Margin = new Padding(0);
            TextEntryBox.Multiline = true;
            TextEntryBox.Name = "TextEntryBox";
            TextEntryBox.ScrollBars = ScrollBars.Vertical;
            TextEntryBox.Size = new Size(264, 59);
            TextEntryBox.TabIndex = 0;
            // 
            // OKButton
            // 
            OKButton.BackColor = Color.ForestGreen;
            OKButton.DialogResult = DialogResult.OK;
            OKButton.Dock = DockStyle.Left;
            OKButton.FlatAppearance.BorderSize = 0;
            OKButton.FlatStyle = FlatStyle.Flat;
            OKButton.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            OKButton.ForeColor = Color.WhiteSmoke;
            OKButton.Location = new Point(10, 69);
            OKButton.Margin = new Padding(0);
            OKButton.Name = "OKButton";
            OKButton.Size = new Size(90, 32);
            OKButton.TabIndex = 1;
            OKButton.Text = "OK";
            OKButton.UseVisualStyleBackColor = false;
            OKButton.Click += OKButton_Click;
            // 
            // HueButton
            // 
            HueButton.BackColor = Color.Black;
            HueButton.DialogResult = DialogResult.OK;
            HueButton.Dock = DockStyle.Fill;
            HueButton.FlatAppearance.BorderSize = 0;
            HueButton.FlatStyle = FlatStyle.Flat;
            HueButton.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            HueButton.ForeColor = Color.WhiteSmoke;
            HueButton.Location = new Point(100, 69);
            HueButton.Margin = new Padding(0);
            HueButton.Name = "HueButton";
            HueButton.Size = new Size(84, 32);
            HueButton.TabIndex = 2;
            HueButton.Text = "Hue";
            HueButton.UseVisualStyleBackColor = false;
            HueButton.Click += HueButton_Click;
            // 
            // DeleteButton
            // 
            DeleteButton.BackColor = Color.Brown;
            DeleteButton.DialogResult = DialogResult.OK;
            DeleteButton.Dock = DockStyle.Right;
            DeleteButton.FlatAppearance.BorderSize = 0;
            DeleteButton.FlatStyle = FlatStyle.Flat;
            DeleteButton.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            DeleteButton.ForeColor = Color.WhiteSmoke;
            DeleteButton.Location = new Point(184, 69);
            DeleteButton.Margin = new Padding(0);
            DeleteButton.Name = "DeleteButton";
            DeleteButton.Size = new Size(90, 32);
            DeleteButton.TabIndex = 3;
            DeleteButton.Text = "Delete";
            DeleteButton.UseVisualStyleBackColor = false;
            DeleteButton.Click += DeleteButton_Click;
            // 
            // UOTextEntry
            // 
            AcceptButton = OKButton;
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.WhiteSmoke;
            BackgroundImageLayout = ImageLayout.None;
            ClientSize = new Size(284, 111);
            Controls.Add(HueButton);
            Controls.Add(DeleteButton);
            Controls.Add(OKButton);
            Controls.Add(TextEntryBox);
            DoubleBuffered = true;
            Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ForeColor = Color.Black;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MaximumSize = new Size(300, 150);
            MinimizeBox = false;
            MinimumSize = new Size(300, 116);
            Name = "UOTextEntry";
            Padding = new Padding(10);
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Text Entry";
            TopMost = true;
            Load += UOTextEntry_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox TextEntryBox;
        private Button OKButton;
        private Button HueButton;
        private Button DeleteButton;
    }
}