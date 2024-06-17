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
            resources.ApplyResources(BottomStatusStrip, "BottomStatusStrip");
            BottomStatusStrip.GripMargin = new Padding(0);
            BottomStatusStrip.Items.AddRange(new ToolStripItem[] { UOProgressBar, GumpInfoLabel });
            BottomStatusStrip.Name = "BottomStatusStrip";
            // 
            // UOProgressBar
            // 
            UOProgressBar.Name = "UOProgressBar";
            resources.ApplyResources(UOProgressBar, "UOProgressBar");
            // 
            // GumpInfoLabel
            // 
            GumpInfoLabel.BackColor = SystemColors.Control;
            resources.ApplyResources(GumpInfoLabel, "GumpInfoLabel");
            GumpInfoLabel.DisplayStyle = ToolStripItemDisplayStyle.Text;
            GumpInfoLabel.ForeColor = Color.FromArgb(32, 32, 32);
            GumpInfoLabel.LinkBehavior = LinkBehavior.NeverUnderline;
            GumpInfoLabel.Margin = new Padding(2, 3, 0, 2);
            GumpInfoLabel.Name = "GumpInfoLabel";
            // 
            // TopMenuStrip
            // 
            TopMenuStrip.BackColor = Color.WhiteSmoke;
            resources.ApplyResources(TopMenuStrip, "TopMenuStrip");
            TopMenuStrip.Items.AddRange(new ToolStripItem[] { NewButton, SaveButton, LoadButton, GetHelpButton, SettingsButton, ExportButton, ModeButton });
            TopMenuStrip.Name = "TopMenuStrip";
            // 
            // NewButton
            // 
            NewButton.AutoToolTip = false;
            NewButton.BackColor = Color.WhiteSmoke;
            resources.ApplyResources(NewButton, "NewButton");
            NewButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            NewButton.Image = GumpRes.RefreshIcon;
            NewButton.Margin = new Padding(0, 2, 2, 2);
            NewButton.Name = "NewButton";
            NewButton.Click += NewButton_Click;
            // 
            // SaveButton
            // 
            SaveButton.AutoToolTip = false;
            SaveButton.BackColor = Color.WhiteSmoke;
            resources.ApplyResources(SaveButton, "SaveButton");
            SaveButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            SaveButton.Image = GumpRes.Save;
            SaveButton.Margin = new Padding(0, 2, 2, 2);
            SaveButton.Name = "SaveButton";
            SaveButton.Click += SaveButton_Click;
            // 
            // LoadButton
            // 
            LoadButton.AutoToolTip = false;
            LoadButton.BackColor = Color.WhiteSmoke;
            resources.ApplyResources(LoadButton, "LoadButton");
            LoadButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            LoadButton.Image = GumpRes.Load;
            LoadButton.Margin = new Padding(0, 2, 2, 2);
            LoadButton.Name = "LoadButton";
            LoadButton.Click += LoadButton_Click;
            // 
            // GetHelpButton
            // 
            GetHelpButton.Alignment = ToolStripItemAlignment.Right;
            GetHelpButton.AutoToolTip = false;
            GetHelpButton.BackColor = Color.WhiteSmoke;
            resources.ApplyResources(GetHelpButton, "GetHelpButton");
            GetHelpButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            GetHelpButton.Image = GumpRes.HelpIcon;
            GetHelpButton.Margin = new Padding(1, 2, 5, 2);
            GetHelpButton.Name = "GetHelpButton";
            GetHelpButton.Click += EditorHelpButton_Click;
            // 
            // SettingsButton
            // 
            SettingsButton.Alignment = ToolStripItemAlignment.Right;
            SettingsButton.AutoToolTip = false;
            SettingsButton.BackColor = Color.WhiteSmoke;
            resources.ApplyResources(SettingsButton, "SettingsButton");
            SettingsButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            SettingsButton.Image = GumpRes.ToolIcon;
            SettingsButton.Margin = new Padding(0, 2, 0, 2);
            SettingsButton.Name = "SettingsButton";
            SettingsButton.Click += Settings_Click;
            // 
            // ExportButton
            // 
            ExportButton.AutoToolTip = false;
            ExportButton.BackColor = Color.WhiteSmoke;
            resources.ApplyResources(ExportButton, "ExportButton");
            ExportButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            ExportButton.Image = GumpRes.ProductIcon;
            ExportButton.Margin = new Padding(0, 2, 1, 2);
            ExportButton.Name = "ExportButton";
            ExportButton.Click += ExportButton_Click;
            // 
            // ModeButton
            // 
            resources.ApplyResources(ModeButton, "ModeButton");
            ModeButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            ModeButton.Image = GumpRes.SplitDisplayIcon;
            ModeButton.Name = "ModeButton";
            ModeButton.Click += ModeButton_Click;
            // 
            // ElementStrip
            // 
            ElementStrip.BackColor = Color.FromArgb(32, 32, 32);
            resources.ApplyResources(ElementStrip, "ElementStrip");
            ElementStrip.DropShadowEnabled = false;
            ElementStrip.Items.AddRange(new ToolStripItem[] { AddLabelButton, AddHTMLButton, RaiseLayerButton, LowerLayerButton });
            ElementStrip.LayoutStyle = ToolStripLayoutStyle.VerticalStackWithOverflow;
            ElementStrip.Name = "ElementStrip";
            ElementStrip.ShowItemToolTips = false;
            ElementStrip.Opening += ElementStrip_Opening;
            // 
            // AddLabelButton
            // 
            resources.ApplyResources(AddLabelButton, "AddLabelButton");
            AddLabelButton.ForeColor = Color.WhiteSmoke;
            AddLabelButton.Image = GumpRes.MenuIcon;
            AddLabelButton.Name = "AddLabelButton";
            AddLabelButton.Click += AddLabelButton_Click;
            // 
            // AddHTMLButton
            // 
            resources.ApplyResources(AddHTMLButton, "AddHTMLButton");
            AddHTMLButton.ForeColor = Color.WhiteSmoke;
            AddHTMLButton.Image = GumpRes.MenuOpenIcon;
            AddHTMLButton.Name = "AddHTMLButton";
            AddHTMLButton.Click += AddHTMLButton_Click;
            // 
            // RaiseLayerButton
            // 
            resources.ApplyResources(RaiseLayerButton, "RaiseLayerButton");
            RaiseLayerButton.ForeColor = Color.WhiteSmoke;
            RaiseLayerButton.Image = GumpRes.Add;
            RaiseLayerButton.Name = "RaiseLayerButton";
            RaiseLayerButton.Click += RaiseLayerButton_Click;
            // 
            // LowerLayerButton
            // 
            resources.ApplyResources(LowerLayerButton, "LowerLayerButton");
            LowerLayerButton.ForeColor = Color.WhiteSmoke;
            LowerLayerButton.Image = GumpRes.Minus;
            LowerLayerButton.Name = "LowerLayerButton";
            LowerLayerButton.Click += LowerLayerButton_Click;
            // 
            // UOGumpEditorUI
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.Tan;
            BackgroundImage = GumpRes.UOGSLogo;
            ContextMenuStrip = ElementStrip;
            Controls.Add(BottomStatusStrip);
            Controls.Add(TopMenuStrip);
            ForeColor = Color.WhiteSmoke;
            Name = "UOGumpEditorUI";
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