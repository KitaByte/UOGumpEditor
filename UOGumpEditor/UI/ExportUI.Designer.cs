namespace UOGumpEditor
{
    partial class ExportUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExportUI));
            NameTextbox = new TextBox();
            SubmitButton = new Button();
            SuspendLayout();
            // 
            // NameTextbox
            // 
            NameTextbox.BackColor = Color.WhiteSmoke;
            NameTextbox.BorderStyle = BorderStyle.FixedSingle;
            NameTextbox.Dock = DockStyle.Top;
            NameTextbox.ForeColor = Color.Black;
            NameTextbox.Location = new Point(10, 10);
            NameTextbox.Margin = new Padding(0);
            NameTextbox.MaxLength = 25;
            NameTextbox.Name = "NameTextbox";
            NameTextbox.Size = new Size(214, 27);
            NameTextbox.TabIndex = 0;
            NameTextbox.TextAlign = HorizontalAlignment.Center;
            // 
            // SubmitButton
            // 
            SubmitButton.BackColor = Color.SteelBlue;
            SubmitButton.BackgroundImageLayout = ImageLayout.None;
            SubmitButton.Dock = DockStyle.Bottom;
            SubmitButton.FlatAppearance.BorderSize = 0;
            SubmitButton.FlatStyle = FlatStyle.Flat;
            SubmitButton.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            SubmitButton.Location = new Point(10, 38);
            SubmitButton.Margin = new Padding(0);
            SubmitButton.Name = "SubmitButton";
            SubmitButton.Size = new Size(214, 30);
            SubmitButton.TabIndex = 1;
            SubmitButton.Text = "Export";
            SubmitButton.UseVisualStyleBackColor = false;
            SubmitButton.Click += SubmitButton_Click;
            // 
            // ExportUI
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.FromArgb(32, 32, 32);
            BackgroundImageLayout = ImageLayout.None;
            ClientSize = new Size(234, 78);
            Controls.Add(SubmitButton);
            Controls.Add(NameTextbox);
            Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ForeColor = Color.WhiteSmoke;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ExportUI";
            Padding = new Padding(10);
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Export";
            TopMost = true;
            FormClosed += ExportUI_FormClosed;
            Load += ExportUI_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox NameTextbox;
        private Button SubmitButton;
    }
}