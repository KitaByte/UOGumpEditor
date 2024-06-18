namespace UOGumpEditor
{
    partial class UOGumpEditorUI
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UOGumpEditorUI));
            BottomStatusStrip = new StatusStrip();
            UOProgressBar = new ToolStripProgressBar();
            GumpInfoLabel = new ToolStripStatusLabel();
            TopMenuStrip = new ToolStrip();
            NewButton = new ToolStripButton();
            SaveButton = new ToolStripButton();
            LoadButton = new ToolStripButton();
            GetHelpButton = new ToolStripButton();
            SettingsButton = new ToolStripButton();
            ExportButton = new ToolStripButton();
            ModeButton = new ToolStripButton();
            ElementStrip = new ContextMenuStrip(components);
            AddLabelButton = new ToolStripMenuItem();
            AddHTMLButton = new ToolStripMenuItem();
            RaiseLayerButton = new ToolStripMenuItem();
            LowerLayerButton = new ToolStripMenuItem();
            BottomStatusStrip.SuspendLayout();
            TopMenuStrip.SuspendLayout();
            ElementStrip.SuspendLayout();
            SuspendLayout();
            // 
            // BottomStatusStrip
            // 
            BottomStatusStrip.BackColor = Color.WhiteSmoke;
            BottomStatusStrip.BackgroundImageLayout = ImageLayout.None;
            BottomStatusStrip.GripMargin = new Padding(0);
            BottomStatusStrip.Items.AddRange(new ToolStripItem[] { UOProgressBar, GumpInfoLabel });
            BottomStatusStrip.Location = new Point(0, 639);
            BottomStatusStrip.Margin = new Padding(5, 0, 5, 0);
            BottomStatusStrip.Name = "BottomStatusStrip";
            BottomStatusStrip.Size = new Size(884, 22);
            BottomStatusStrip.TabIndex = 1;
            BottomStatusStrip.Text = "Tool Status";
            // 
            // UOProgressBar
            // 
            UOProgressBar.Name = "UOProgressBar";
            UOProgressBar.RightToLeft = RightToLeft.No;
            UOProgressBar.Size = new Size(120, 16);
            // 
            // GumpInfoLabel
            // 
            GumpInfoLabel.BackColor = SystemColors.Control;
            GumpInfoLabel.BackgroundImageLayout = ImageLayout.None;
            GumpInfoLabel.DisplayStyle = ToolStripItemDisplayStyle.Text;
            GumpInfoLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            GumpInfoLabel.ForeColor = Color.FromArgb(32, 32, 32);
            GumpInfoLabel.LinkBehavior = LinkBehavior.NeverUnderline;
            GumpInfoLabel.Margin = new Padding(2, 3, 0, 2);
            GumpInfoLabel.Name = "GumpInfoLabel";
            GumpInfoLabel.Size = new Size(64, 17);
            GumpInfoLabel.Text = "Gump X/Y";
            // 
            // TopMenuStrip
            // 
            TopMenuStrip.BackColor = Color.WhiteSmoke;
            TopMenuStrip.BackgroundImageLayout = ImageLayout.None;
            TopMenuStrip.Items.AddRange(new ToolStripItem[] { NewButton, SaveButton, LoadButton, GetHelpButton, SettingsButton, ExportButton, ModeButton });
            TopMenuStrip.Location = new Point(0, 0);
            TopMenuStrip.Name = "TopMenuStrip";
            TopMenuStrip.Size = new Size(884, 25);
            TopMenuStrip.TabIndex = 0;
            TopMenuStrip.Text = "MainMenuStrip";
            // 
            // NewButton
            // 
            NewButton.AutoToolTip = false;
            NewButton.BackColor = Color.WhiteSmoke;
            NewButton.BackgroundImageLayout = ImageLayout.None;
            NewButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            NewButton.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            NewButton.Image = GumpRes.RefreshIcon;
            NewButton.ImageTransparentColor = Color.Magenta;
            NewButton.Margin = new Padding(0, 2, 2, 2);
            NewButton.Name = "NewButton";
            NewButton.Size = new Size(23, 21);
            NewButton.TextImageRelation = TextImageRelation.Overlay;
            NewButton.ToolTipText = "Refresh";
            NewButton.Click += NewButton_Click;
            // 
            // SaveButton
            // 
            SaveButton.AutoToolTip = false;
            SaveButton.BackColor = Color.WhiteSmoke;
            SaveButton.BackgroundImageLayout = ImageLayout.None;
            SaveButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            SaveButton.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            SaveButton.Image = GumpRes.Save;
            SaveButton.ImageTransparentColor = Color.Magenta;
            SaveButton.Margin = new Padding(0, 2, 2, 2);
            SaveButton.Name = "SaveButton";
            SaveButton.Size = new Size(23, 21);
            SaveButton.TextImageRelation = TextImageRelation.Overlay;
            SaveButton.ToolTipText = "Save";
            SaveButton.Click += SaveButton_Click;
            // 
            // LoadButton
            // 
            LoadButton.AutoToolTip = false;
            LoadButton.BackColor = Color.WhiteSmoke;
            LoadButton.BackgroundImageLayout = ImageLayout.None;
            LoadButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            LoadButton.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            LoadButton.Image = GumpRes.Load;
            LoadButton.ImageTransparentColor = Color.Magenta;
            LoadButton.Margin = new Padding(0, 2, 2, 2);
            LoadButton.Name = "LoadButton";
            LoadButton.Size = new Size(23, 21);
            LoadButton.TextImageRelation = TextImageRelation.Overlay;
            LoadButton.ToolTipText = "Load";
            LoadButton.Click += LoadButton_Click;
            // 
            // GetHelpButton
            // 
            GetHelpButton.Alignment = ToolStripItemAlignment.Right;
            GetHelpButton.AutoToolTip = false;
            GetHelpButton.BackColor = Color.WhiteSmoke;
            GetHelpButton.BackgroundImageLayout = ImageLayout.None;
            GetHelpButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            GetHelpButton.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            GetHelpButton.Image = GumpRes.HelpIcon;
            GetHelpButton.ImageTransparentColor = Color.Magenta;
            GetHelpButton.Margin = new Padding(1, 2, 5, 2);
            GetHelpButton.Name = "GetHelpButton";
            GetHelpButton.Size = new Size(23, 21);
            GetHelpButton.TextImageRelation = TextImageRelation.Overlay;
            GetHelpButton.ToolTipText = "Help";
            GetHelpButton.Click += EditorHelpButton_Click;
            // 
            // SettingsButton
            // 
            SettingsButton.Alignment = ToolStripItemAlignment.Right;
            SettingsButton.AutoToolTip = false;
            SettingsButton.BackColor = Color.WhiteSmoke;
            SettingsButton.BackgroundImageLayout = ImageLayout.None;
            SettingsButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            SettingsButton.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            SettingsButton.Image = GumpRes.ToolIcon;
            SettingsButton.ImageTransparentColor = Color.Magenta;
            SettingsButton.Margin = new Padding(0, 2, 0, 2);
            SettingsButton.Name = "SettingsButton";
            SettingsButton.Size = new Size(23, 21);
            SettingsButton.TextImageRelation = TextImageRelation.Overlay;
            SettingsButton.ToolTipText = "Settings";
            SettingsButton.Click += Settings_Click;
            // 
            // ExportButton
            // 
            ExportButton.AutoToolTip = false;
            ExportButton.BackColor = Color.WhiteSmoke;
            ExportButton.BackgroundImageLayout = ImageLayout.None;
            ExportButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            ExportButton.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            ExportButton.Image = GumpRes.ProductIcon;
            ExportButton.ImageTransparentColor = Color.Magenta;
            ExportButton.Margin = new Padding(0, 2, 1, 2);
            ExportButton.Name = "ExportButton";
            ExportButton.Size = new Size(23, 21);
            ExportButton.TextImageRelation = TextImageRelation.Overlay;
            ExportButton.ToolTipText = "Export";
            ExportButton.Click += ExportButton_Click;
            // 
            // ModeButton
            // 
            ModeButton.BackgroundImageLayout = ImageLayout.None;
            ModeButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            ModeButton.Image = GumpRes.SplitDisplayIcon;
            ModeButton.ImageTransparentColor = Color.Magenta;
            ModeButton.Name = "ModeButton";
            ModeButton.Size = new Size(23, 22);
            ModeButton.TextImageRelation = TextImageRelation.Overlay;
            ModeButton.ToolTipText = "Canvas Mode";
            ModeButton.Click += ModeButton_Click;
            // 
            // ElementStrip
            // 
            ElementStrip.BackColor = Color.FromArgb(32, 32, 32);
            ElementStrip.BackgroundImageLayout = ImageLayout.None;
            ElementStrip.DropShadowEnabled = false;
            ElementStrip.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            ElementStrip.Items.AddRange(new ToolStripItem[] { AddLabelButton, AddHTMLButton, RaiseLayerButton, LowerLayerButton });
            ElementStrip.LayoutStyle = ToolStripLayoutStyle.VerticalStackWithOverflow;
            ElementStrip.Name = "ElementStrip";
            ElementStrip.ShowItemToolTips = false;
            ElementStrip.Size = new Size(168, 92);
            ElementStrip.Opening += ElementStrip_Opening;
            // 
            // AddLabelButton
            // 
            AddLabelButton.BackgroundImageLayout = ImageLayout.None;
            AddLabelButton.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            AddLabelButton.ForeColor = Color.WhiteSmoke;
            AddLabelButton.Image = GumpRes.MenuIcon;
            AddLabelButton.Name = "AddLabelButton";
            AddLabelButton.Size = new Size(167, 22);
            AddLabelButton.Text = "Label";
            AddLabelButton.Click += AddLabelButton_Click;
            // 
            // AddHTMLButton
            // 
            AddHTMLButton.BackgroundImageLayout = ImageLayout.None;
            AddHTMLButton.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            AddHTMLButton.ForeColor = Color.WhiteSmoke;
            AddHTMLButton.Image = GumpRes.MenuOpenIcon;
            AddHTMLButton.Name = "AddHTMLButton";
            AddHTMLButton.Size = new Size(167, 22);
            AddHTMLButton.Text = "HTML";
            AddHTMLButton.Click += AddHTMLButton_Click;
            // 
            // RaiseLayerButton
            // 
            RaiseLayerButton.BackgroundImageLayout = ImageLayout.None;
            RaiseLayerButton.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            RaiseLayerButton.ForeColor = Color.WhiteSmoke;
            RaiseLayerButton.Image = GumpRes.Add;
            RaiseLayerButton.Name = "RaiseLayerButton";
            RaiseLayerButton.Size = new Size(167, 22);
            RaiseLayerButton.Text = "Raise Selected";
            RaiseLayerButton.Click += RaiseLayerButton_Click;
            // 
            // LowerLayerButton
            // 
            LowerLayerButton.BackgroundImageLayout = ImageLayout.None;
            LowerLayerButton.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            LowerLayerButton.ForeColor = Color.WhiteSmoke;
            LowerLayerButton.Image = GumpRes.Minus;
            LowerLayerButton.Name = "LowerLayerButton";
            LowerLayerButton.Size = new Size(167, 22);
            LowerLayerButton.Text = "Lower Selected";
            LowerLayerButton.Click += LowerLayerButton_Click;
            // 
            // UOGumpEditorUI
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.Tan;
            BackgroundImage = GumpRes.UOGSLogo;
            BackgroundImageLayout = ImageLayout.Center;
            ClientSize = new Size(884, 661);
            ContextMenuStrip = ElementStrip;
            Controls.Add(BottomStatusStrip);
            Controls.Add(TopMenuStrip);
            Font = new Font("Segoe UI", 9.75F);
            ForeColor = Color.WhiteSmoke;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(900, 700);
            Name = "UOGumpEditorUI";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "UO Gump Editor";
            Load += UOGumpEditorUI_Load;
            Resize += UOGumpEditorUI_Resize;
            BottomStatusStrip.ResumeLayout(false);
            BottomStatusStrip.PerformLayout();
            TopMenuStrip.ResumeLayout(false);
            TopMenuStrip.PerformLayout();
            ElementStrip.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private StatusStrip BottomStatusStrip;
        private ToolStripProgressBar UOProgressBar;
        private ToolStrip TopMenuStrip;
        private ToolStripButton NewButton;
        private ToolStripButton SaveButton;
        private ToolStripButton LoadButton;
        private ToolStripButton SettingsButton;
        private ToolStripButton GetHelpButton;
        private ToolStripButton ExportButton;
        private ToolStripButton ModeButton;
        internal ToolStripStatusLabel GumpInfoLabel;
        private ContextMenuStrip ElementStrip;
        private ToolStripMenuItem AddLabelButton;
        private ToolStripMenuItem AddHTMLButton;
        private ToolStripMenuItem RaiseLayerButton;
        private ToolStripMenuItem LowerLayerButton;
    }
}