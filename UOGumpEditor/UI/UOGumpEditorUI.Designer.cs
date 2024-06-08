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
            ElementStrip = new ContextMenuStrip(components);
            AddLabelButton = new ToolStripMenuItem();
            AddHTMLButton = new ToolStripMenuItem();
            RaiseLayerButton = new ToolStripMenuItem();
            LowerLayerButton = new ToolStripMenuItem();
            ArtPanel = new Panel();
            HistoryListbox = new ListBox();
            ClearHistoryButton = new Button();
            HistoryLabel = new Label();
            SizePanel = new Panel();
            ArtHeightSearchBox = new TextBox();
            ArtWidthSearchBox = new TextBox();
            ArtNameSearchBox = new TextBox();
            ArtIDSearchBox = new TextBox();
            AllArtButton = new Button();
            ArtPicturebox = new PictureBox();
            ArtSelectPanel = new Panel();
            ItemArtButton = new Button();
            GumpArtButton = new Button();
            SearchFlowPanel = new FlowLayoutPanel();
            TopMenuStrip = new ToolStrip();
            NewButton = new ToolStripButton();
            SaveButton = new ToolStripButton();
            LoadButton = new ToolStripButton();
            GetHelpButton = new ToolStripButton();
            SettingsButton = new ToolStripButton();
            ExportButton = new ToolStripButton();
            ModeButton = new ToolStripButton();
            CanvasPanel = new Panel();
            NextButton = new Button();
            PreviousButton = new Button();
            SearchPanel = new Panel();
            FocusPanel = new Panel();
            LayerListbox = new ListBox();
            ClearSelectedButton = new Button();
            LayerLabel = new Label();
            BottomStatusStrip.SuspendLayout();
            ElementStrip.SuspendLayout();
            ArtPanel.SuspendLayout();
            SizePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ArtPicturebox).BeginInit();
            ArtSelectPanel.SuspendLayout();
            TopMenuStrip.SuspendLayout();
            SearchPanel.SuspendLayout();
            FocusPanel.SuspendLayout();
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
            // ElementStrip
            // 
            ElementStrip.BackColor = Color.FromArgb(32, 32, 32);
            resources.ApplyResources(ElementStrip, "ElementStrip");
            ElementStrip.DropShadowEnabled = false;
            ElementStrip.Items.AddRange(new ToolStripItem[] { AddLabelButton, AddHTMLButton, RaiseLayerButton, LowerLayerButton });
            ElementStrip.LayoutStyle = ToolStripLayoutStyle.VerticalStackWithOverflow;
            ElementStrip.Name = "ElementStrip";
            ElementStrip.ShowItemToolTips = false;
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
            // ArtPanel
            // 
            ArtPanel.BackColor = Color.FromArgb(32, 32, 32);
            ArtPanel.Controls.Add(HistoryListbox);
            ArtPanel.Controls.Add(ClearHistoryButton);
            ArtPanel.Controls.Add(HistoryLabel);
            ArtPanel.Controls.Add(SizePanel);
            ArtPanel.Controls.Add(ArtNameSearchBox);
            ArtPanel.Controls.Add(ArtIDSearchBox);
            ArtPanel.Controls.Add(AllArtButton);
            ArtPanel.Controls.Add(ArtPicturebox);
            ArtPanel.Controls.Add(ArtSelectPanel);
            resources.ApplyResources(ArtPanel, "ArtPanel");
            ArtPanel.Name = "ArtPanel";
            // 
            // HistoryListbox
            // 
            HistoryListbox.BackColor = Color.WhiteSmoke;
            HistoryListbox.BorderStyle = BorderStyle.FixedSingle;
            resources.ApplyResources(HistoryListbox, "HistoryListbox");
            HistoryListbox.ForeColor = Color.Black;
            HistoryListbox.FormattingEnabled = true;
            HistoryListbox.Name = "HistoryListbox";
            HistoryListbox.SelectedIndexChanged += HistoryListbox_SelectedIndexChanged;
            // 
            // ClearHistoryButton
            // 
            ClearHistoryButton.BackColor = Color.Brown;
            resources.ApplyResources(ClearHistoryButton, "ClearHistoryButton");
            ClearHistoryButton.FlatAppearance.BorderSize = 0;
            ClearHistoryButton.Name = "ClearHistoryButton";
            ClearHistoryButton.UseVisualStyleBackColor = false;
            ClearHistoryButton.Click += ClearHistoryButton_Click;
            // 
            // HistoryLabel
            // 
            HistoryLabel.BackColor = Color.Indigo;
            resources.ApplyResources(HistoryLabel, "HistoryLabel");
            HistoryLabel.ForeColor = Color.WhiteSmoke;
            HistoryLabel.Name = "HistoryLabel";
            // 
            // SizePanel
            // 
            SizePanel.Controls.Add(ArtHeightSearchBox);
            SizePanel.Controls.Add(ArtWidthSearchBox);
            resources.ApplyResources(SizePanel, "SizePanel");
            SizePanel.Name = "SizePanel";
            // 
            // ArtHeightSearchBox
            // 
            ArtHeightSearchBox.BackColor = Color.Khaki;
            ArtHeightSearchBox.BorderStyle = BorderStyle.FixedSingle;
            resources.ApplyResources(ArtHeightSearchBox, "ArtHeightSearchBox");
            ArtHeightSearchBox.ForeColor = Color.Black;
            ArtHeightSearchBox.Name = "ArtHeightSearchBox";
            ArtHeightSearchBox.MouseClick += ArtSearchBox_MouseClick;
            ArtHeightSearchBox.TextChanged += ArtSizeSearchBox_TextChanged;
            // 
            // ArtWidthSearchBox
            // 
            ArtWidthSearchBox.BackColor = Color.Khaki;
            ArtWidthSearchBox.BorderStyle = BorderStyle.FixedSingle;
            resources.ApplyResources(ArtWidthSearchBox, "ArtWidthSearchBox");
            ArtWidthSearchBox.ForeColor = Color.Black;
            ArtWidthSearchBox.Name = "ArtWidthSearchBox";
            ArtWidthSearchBox.MouseClick += ArtSearchBox_MouseClick;
            ArtWidthSearchBox.TextChanged += ArtSizeSearchBox_TextChanged;
            // 
            // ArtNameSearchBox
            // 
            ArtNameSearchBox.BackColor = Color.PaleGoldenrod;
            ArtNameSearchBox.BorderStyle = BorderStyle.FixedSingle;
            resources.ApplyResources(ArtNameSearchBox, "ArtNameSearchBox");
            ArtNameSearchBox.ForeColor = Color.Black;
            ArtNameSearchBox.Name = "ArtNameSearchBox";
            ArtNameSearchBox.MouseClick += ArtSearchBox_MouseClick;
            ArtNameSearchBox.TextChanged += ArtNameSearchBox_TextChanged;
            // 
            // ArtIDSearchBox
            // 
            ArtIDSearchBox.BackColor = Color.LightGoldenrodYellow;
            ArtIDSearchBox.BorderStyle = BorderStyle.FixedSingle;
            resources.ApplyResources(ArtIDSearchBox, "ArtIDSearchBox");
            ArtIDSearchBox.ForeColor = Color.Black;
            ArtIDSearchBox.Name = "ArtIDSearchBox";
            ArtIDSearchBox.MouseClick += ArtSearchBox_MouseClick;
            ArtIDSearchBox.TextChanged += ArtIDSearchBox_TextChanged;
            // 
            // AllArtButton
            // 
            AllArtButton.BackColor = Color.Goldenrod;
            resources.ApplyResources(AllArtButton, "AllArtButton");
            AllArtButton.FlatAppearance.BorderSize = 0;
            AllArtButton.Name = "AllArtButton";
            AllArtButton.UseVisualStyleBackColor = false;
            AllArtButton.Click += AllArtButton_Click;
            // 
            // ArtPicturebox
            // 
            ArtPicturebox.BackColor = Color.Black;
            resources.ApplyResources(ArtPicturebox, "ArtPicturebox");
            ArtPicturebox.BorderStyle = BorderStyle.FixedSingle;
            ArtPicturebox.Name = "ArtPicturebox";
            ArtPicturebox.TabStop = false;
            ArtPicturebox.MouseDown += ArtPicturebox_MouseDown;
            // 
            // ArtSelectPanel
            // 
            ArtSelectPanel.Controls.Add(ItemArtButton);
            ArtSelectPanel.Controls.Add(GumpArtButton);
            resources.ApplyResources(ArtSelectPanel, "ArtSelectPanel");
            ArtSelectPanel.Name = "ArtSelectPanel";
            // 
            // ItemArtButton
            // 
            ItemArtButton.BackColor = Color.RoyalBlue;
            resources.ApplyResources(ItemArtButton, "ItemArtButton");
            ItemArtButton.FlatAppearance.BorderSize = 0;
            ItemArtButton.ForeColor = Color.Black;
            ItemArtButton.Name = "ItemArtButton";
            ItemArtButton.UseVisualStyleBackColor = false;
            ItemArtButton.Click += ItemArtButton_Click;
            // 
            // GumpArtButton
            // 
            GumpArtButton.BackColor = Color.DodgerBlue;
            resources.ApplyResources(GumpArtButton, "GumpArtButton");
            GumpArtButton.FlatAppearance.BorderSize = 0;
            GumpArtButton.ForeColor = Color.WhiteSmoke;
            GumpArtButton.Name = "GumpArtButton";
            GumpArtButton.UseVisualStyleBackColor = false;
            GumpArtButton.Click += GumpArtButton_Click;
            // 
            // SearchFlowPanel
            // 
            resources.ApplyResources(SearchFlowPanel, "SearchFlowPanel");
            SearchFlowPanel.BackColor = Color.FromArgb(64, 64, 64);
            SearchFlowPanel.Name = "SearchFlowPanel";
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
            // CanvasPanel
            // 
            CanvasPanel.AllowDrop = true;
            CanvasPanel.BackColor = Color.Black;
            resources.ApplyResources(CanvasPanel, "CanvasPanel");
            CanvasPanel.Name = "CanvasPanel";
            CanvasPanel.DragDrop += CanvasPanel_DragDrop;
            CanvasPanel.DragEnter += CanvasPanel_DragEnter;
            // 
            // NextButton
            // 
            NextButton.BackColor = Color.WhiteSmoke;
            resources.ApplyResources(NextButton, "NextButton");
            NextButton.FlatAppearance.BorderSize = 0;
            NextButton.ForeColor = Color.Black;
            NextButton.Name = "NextButton";
            NextButton.UseVisualStyleBackColor = false;
            NextButton.Click += NextButton_Click;
            // 
            // PreviousButton
            // 
            PreviousButton.BackColor = Color.WhiteSmoke;
            resources.ApplyResources(PreviousButton, "PreviousButton");
            PreviousButton.FlatAppearance.BorderSize = 0;
            PreviousButton.ForeColor = Color.Black;
            PreviousButton.Name = "PreviousButton";
            PreviousButton.UseVisualStyleBackColor = false;
            PreviousButton.Click += PreviousButton_Click;
            // 
            // SearchPanel
            // 
            SearchPanel.BackColor = Color.FromArgb(32, 32, 32);
            SearchPanel.Controls.Add(SearchFlowPanel);
            SearchPanel.Controls.Add(PreviousButton);
            SearchPanel.Controls.Add(NextButton);
            resources.ApplyResources(SearchPanel, "SearchPanel");
            SearchPanel.Name = "SearchPanel";
            // 
            // FocusPanel
            // 
            FocusPanel.BackColor = Color.FromArgb(32, 32, 32);
            resources.ApplyResources(FocusPanel, "FocusPanel");
            FocusPanel.Controls.Add(LayerListbox);
            FocusPanel.Controls.Add(ClearSelectedButton);
            FocusPanel.Controls.Add(LayerLabel);
            FocusPanel.Name = "FocusPanel";
            // 
            // LayerListbox
            // 
            LayerListbox.BackColor = Color.FromArgb(64, 64, 64);
            LayerListbox.BorderStyle = BorderStyle.FixedSingle;
            resources.ApplyResources(LayerListbox, "LayerListbox");
            LayerListbox.ForeColor = Color.White;
            LayerListbox.FormattingEnabled = true;
            LayerListbox.Name = "LayerListbox";
            LayerListbox.SelectionMode = SelectionMode.MultiSimple;
            LayerListbox.TabStop = false;
            LayerListbox.SelectedIndexChanged += LayerListbox_SelectedIndexChanged;
            // 
            // ClearSelectedButton
            // 
            ClearSelectedButton.BackColor = Color.Brown;
            resources.ApplyResources(ClearSelectedButton, "ClearSelectedButton");
            ClearSelectedButton.FlatAppearance.BorderSize = 0;
            ClearSelectedButton.Name = "ClearSelectedButton";
            ClearSelectedButton.UseVisualStyleBackColor = false;
            ClearSelectedButton.Click += ClearSelectedButton_Click;
            // 
            // LayerLabel
            // 
            LayerLabel.BackColor = Color.DarkMagenta;
            resources.ApplyResources(LayerLabel, "LayerLabel");
            LayerLabel.Name = "LayerLabel";
            // 
            // UOGumpEditorUI
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.White;
            BackgroundImage = GumpRes.UOScreen;
            ContextMenuStrip = ElementStrip;
            Controls.Add(FocusPanel);
            Controls.Add(SearchPanel);
            Controls.Add(CanvasPanel);
            Controls.Add(ArtPanel);
            Controls.Add(BottomStatusStrip);
            Controls.Add(TopMenuStrip);
            DoubleBuffered = true;
            ForeColor = Color.WhiteSmoke;
            Name = "UOGumpEditorUI";
            Load += UOGumpEditorUI_Load;
            Resize += UOGumpEditorUI_Resize;
            BottomStatusStrip.ResumeLayout(false);
            BottomStatusStrip.PerformLayout();
            ElementStrip.ResumeLayout(false);
            ArtPanel.ResumeLayout(false);
            ArtPanel.PerformLayout();
            SizePanel.ResumeLayout(false);
            SizePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)ArtPicturebox).EndInit();
            ArtSelectPanel.ResumeLayout(false);
            TopMenuStrip.ResumeLayout(false);
            TopMenuStrip.PerformLayout();
            SearchPanel.ResumeLayout(false);
            FocusPanel.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private StatusStrip BottomStatusStrip;
        private ToolStripStatusLabel GumpInfoLabel;
        private ToolStripProgressBar UOProgressBar;
        private ContextMenuStrip ElementStrip;
        private ToolStripMenuItem AddLabelButton;
        private Panel ArtPanel;
        private PictureBox ArtPicturebox;
        private TextBox ArtIDSearchBox;
        private Label HistoryLabel;
        private Panel ArtSelectPanel;
        private Button ItemArtButton;
        private Button GumpArtButton;
        private Button ClearHistoryButton;
        private TextBox ArtWidthSearchBox;
        private TextBox ArtNameSearchBox;
        private FlowLayoutPanel SearchFlowPanel;
        private ToolStrip TopMenuStrip;
        private ToolStripButton NewButton;
        private ToolStripButton SaveButton;
        private ToolStripButton LoadButton;
        private ToolStripButton SettingsButton;
        private ToolStripButton GetHelpButton;
        private ToolStripButton ExportButton;
        private Panel SizePanel;
        private TextBox ArtHeightSearchBox;
        private ToolStripButton ModeButton;
        private ToolStripMenuItem AddHTMLButton;
        private Button PreviousButton;
        private Button NextButton;
        private ToolStripMenuItem RaiseLayerButton;
        private ToolStripMenuItem LowerLayerButton;
        private Panel SearchPanel;
        internal Panel CanvasPanel;
        private Panel FocusPanel;
        private Label LayerLabel;
        private Button ClearSelectedButton;
        internal ListBox HistoryListbox;
        internal ListBox LayerListbox;
        private Button AllArtButton;
    }
}