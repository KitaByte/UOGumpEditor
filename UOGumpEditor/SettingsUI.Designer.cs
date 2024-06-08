namespace UOGumpEditor
{
    partial class SettingsUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsUI));
            ResetButton = new Button();
            SuspendLayout();
            // 
            // ResetButton
            // 
            ResetButton.BackColor = Color.Brown;
            ResetButton.BackgroundImageLayout = ImageLayout.None;
            ResetButton.Dock = DockStyle.Bottom;
            ResetButton.FlatAppearance.BorderSize = 0;
            ResetButton.FlatStyle = FlatStyle.Flat;
            ResetButton.ForeColor = Color.WhiteSmoke;
            ResetButton.Location = new Point(0, 426);
            ResetButton.Margin = new Padding(0);
            ResetButton.Name = "ResetButton";
            ResetButton.Size = new Size(334, 35);
            ResetButton.TabIndex = 0;
            ResetButton.Text = "RESET UO DIRECTORY";
            ResetButton.UseVisualStyleBackColor = false;
            ResetButton.Click += ResetButton_Click;
            // 
            // SettingsUI
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.FromArgb(32, 32, 32);
            BackgroundImageLayout = ImageLayout.None;
            ClientSize = new Size(334, 461);
            Controls.Add(ResetButton);
            Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "SettingsUI";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Settings";
            TopMost = true;
            Load += SettingsUI_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button ResetButton;
    }
}