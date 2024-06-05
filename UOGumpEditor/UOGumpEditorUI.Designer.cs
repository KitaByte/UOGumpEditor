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
            AddTextBoxButton = new ToolStripMenuItem();
            AddHTMLButton = new ToolStripMenuItem();
            ArtPanel = new Panel();
            HistoryListbox = new ListBox();
            ClearHistoryButton = new Button();
            HistoryLabel = new Label();
            SizePanel = new Panel();
            ArtHeightSearchBox = new TextBox();
            ArtWidthSearchBox = new TextBox();
            ArtNameSearchBox = new TextBox();
            ArtIDSearchBox = new TextBox();
            ArtPicturebox = new PictureBox();
            ArtSelectPanel = new Panel();
            ItemArtButton = new Button();
            GumpArtButton = new Button();
            SearchFlowPanel = new FlowLayoutPanel();
            TopMenuStrip = new ToolStrip();
            NewButton = new ToolStripButton();
            SaveButton = new ToolStripButton();
            LoadButton = new ToolStripButton();
            SettingsButton = new ToolStripButton();
            GetHelpButton = new ToolStripButton();
            ExportButton = new ToolStripButton();
            CanvasPanel = new Panel();
            BottomStatusStrip.SuspendLayout();
            ElementStrip.SuspendLayout();
            ArtPanel.SuspendLayout();
            SizePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ArtPicturebox).BeginInit();
            ArtSelectPanel.SuspendLayout();
            TopMenuStrip.SuspendLayout();
            CanvasPanel.SuspendLayout();
            SuspendLayout();
            // 
            // BottomStatusStrip
            // 
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
            ElementStrip.BackColor = Color.DimGray;
            resources.ApplyResources(ElementStrip, "ElementStrip");
            ElementStrip.Items.AddRange(new ToolStripItem[] { AddLabelButton, AddTextBoxButton, AddHTMLButton });
            ElementStrip.LayoutStyle = ToolStripLayoutStyle.VerticalStackWithOverflow;
            ElementStrip.Name = "ElementStrip";
            // 
            // AddLabelButton
            // 
            AddLabelButton.ForeColor = Color.WhiteSmoke;
            AddLabelButton.Name = "AddLabelButton";
            resources.ApplyResources(AddLabelButton, "AddLabelButton");
            // 
            // AddTextBoxButton
            // 
            AddTextBoxButton.ForeColor = Color.WhiteSmoke;
            AddTextBoxButton.Name = "AddTextBoxButton";
            resources.ApplyResources(AddTextBoxButton, "AddTextBoxButton");
            // 
            // AddHTMLButton
            // 
            AddHTMLButton.ForeColor = Color.WhiteSmoke;
            AddHTMLButton.Name = "AddHTMLButton";
            resources.ApplyResources(AddHTMLButton, "AddHTMLButton");
            // 
            // ArtPanel
            // 
            ArtPanel.BackColor = Color.FromArgb(64, 64, 64);
            ArtPanel.Controls.Add(HistoryListbox);
            ArtPanel.Controls.Add(ClearHistoryButton);
            ArtPanel.Controls.Add(HistoryLabel);
            ArtPanel.Controls.Add(SizePanel);
            ArtPanel.Controls.Add(ArtNameSearchBox);
            ArtPanel.Controls.Add(ArtIDSearchBox);
            ArtPanel.Controls.Add(ArtPicturebox);
            ArtPanel.Controls.Add(ArtSelectPanel);
            resources.ApplyResources(ArtPanel, "ArtPanel");
            ArtPanel.Name = "ArtPanel";
            // 
            // HistoryListbox
            // 
            HistoryListbox.BackColor = Color.Gainsboro;
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
            resources.ApplyResources(HistoryLabel, "HistoryLabel");
            HistoryLabel.ForeColor = Color.Gold;
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
            ArtHeightSearchBox.TextChanged += ArtSizeSearchBox_TextChanged;
            // 
            // ArtWidthSearchBox
            // 
            ArtWidthSearchBox.BackColor = Color.Khaki;
            ArtWidthSearchBox.BorderStyle = BorderStyle.FixedSingle;
            resources.ApplyResources(ArtWidthSearchBox, "ArtWidthSearchBox");
            ArtWidthSearchBox.ForeColor = Color.Black;
            ArtWidthSearchBox.Name = "ArtWidthSearchBox";
            ArtWidthSearchBox.TextChanged += ArtSizeSearchBox_TextChanged;
            // 
            // ArtNameSearchBox
            // 
            ArtNameSearchBox.BackColor = Color.PaleGoldenrod;
            ArtNameSearchBox.BorderStyle = BorderStyle.FixedSingle;
            resources.ApplyResources(ArtNameSearchBox, "ArtNameSearchBox");
            ArtNameSearchBox.ForeColor = Color.Black;
            ArtNameSearchBox.Name = "ArtNameSearchBox";
            ArtNameSearchBox.TextChanged += ArtNameSearchBox_TextChanged;
            // 
            // ArtIDSearchBox
            // 
            ArtIDSearchBox.BackColor = Color.LightGoldenrodYellow;
            ArtIDSearchBox.BorderStyle = BorderStyle.FixedSingle;
            resources.ApplyResources(ArtIDSearchBox, "ArtIDSearchBox");
            ArtIDSearchBox.ForeColor = Color.Black;
            ArtIDSearchBox.Name = "ArtIDSearchBox";
            ArtIDSearchBox.TextChanged += ArtIDSearchBox_TextChanged;
            // 
            // ArtPicturebox
            // 
            ArtPicturebox.BackColor = Color.White;
            resources.ApplyResources(ArtPicturebox, "ArtPicturebox");
            ArtPicturebox.BorderStyle = BorderStyle.FixedSingle;
            ArtPicturebox.Name = "ArtPicturebox";
            ArtPicturebox.TabStop = false;
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
            SearchFlowPanel.BackColor = Color.FromArgb(32, 32, 32);
            SearchFlowPanel.Name = "SearchFlowPanel";
            // 
            // TopMenuStrip
            // 
            TopMenuStrip.BackColor = Color.WhiteSmoke;
            resources.ApplyResources(TopMenuStrip, "TopMenuStrip");
            TopMenuStrip.Items.AddRange(new ToolStripItem[] { NewButton, SaveButton, LoadButton, SettingsButton, GetHelpButton, ExportButton });
            TopMenuStrip.Name = "TopMenuStrip";
            // 
            // NewButton
            // 
            resources.ApplyResources(NewButton, "NewButton");
            NewButton.BackColor = Color.ForestGreen;
            NewButton.DisplayStyle = ToolStripItemDisplayStyle.Text;
            NewButton.Margin = new Padding(0, 2, 2, 2);
            NewButton.Name = "NewButton";
            NewButton.Click += NewButton_Click;
            // 
            // SaveButton
            // 
            resources.ApplyResources(SaveButton, "SaveButton");
            SaveButton.BackColor = Color.SteelBlue;
            SaveButton.DisplayStyle = ToolStripItemDisplayStyle.Text;
            SaveButton.Margin = new Padding(0, 2, 2, 2);
            SaveButton.Name = "SaveButton";
            SaveButton.Click += SaveButton_Click;
            // 
            // LoadButton
            // 
            resources.ApplyResources(LoadButton, "LoadButton");
            LoadButton.BackColor = Color.RoyalBlue;
            LoadButton.DisplayStyle = ToolStripItemDisplayStyle.Text;
            LoadButton.Margin = new Padding(0, 2, 2, 2);
            LoadButton.Name = "LoadButton";
            LoadButton.Click += LoadButton_Click;
            // 
            // SettingsButton
            // 
            resources.ApplyResources(SettingsButton, "SettingsButton");
            SettingsButton.BackColor = Color.Goldenrod;
            SettingsButton.DisplayStyle = ToolStripItemDisplayStyle.Text;
            SettingsButton.Margin = new Padding(0, 2, 0, 2);
            SettingsButton.Name = "SettingsButton";
            SettingsButton.Click += Settings_Click;
            // 
            // GetHelpButton
            // 
            GetHelpButton.Alignment = ToolStripItemAlignment.Right;
            resources.ApplyResources(GetHelpButton, "GetHelpButton");
            GetHelpButton.BackColor = Color.Goldenrod;
            GetHelpButton.DisplayStyle = ToolStripItemDisplayStyle.Text;
            GetHelpButton.Margin = new Padding(1, 2, 5, 2);
            GetHelpButton.Name = "GetHelpButton";
            GetHelpButton.Click += EditorHelpButton_Click;
            // 
            // ExportButton
            // 
            ExportButton.Alignment = ToolStripItemAlignment.Right;
            resources.ApplyResources(ExportButton, "ExportButton");
            ExportButton.BackColor = Color.MediumPurple;
            ExportButton.DisplayStyle = ToolStripItemDisplayStyle.Text;
            ExportButton.Margin = new Padding(0, 2, 1, 2);
            ExportButton.Name = "ExportButton";
            ExportButton.Click += ExportButton_Click;
            // 
            // CanvasPanel
            // 
            resources.ApplyResources(CanvasPanel, "CanvasPanel");
            CanvasPanel.Controls.Add(SearchFlowPanel);
            CanvasPanel.Name = "CanvasPanel";
            // 
            // UOGumpEditorUI
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.Black;
            ContextMenuStrip = ElementStrip;
            Controls.Add(CanvasPanel);
            Controls.Add(ArtPanel);
            Controls.Add(BottomStatusStrip);
            Controls.Add(TopMenuStrip);
            DoubleBuffered = true;
            ForeColor = Color.WhiteSmoke;
            Name = "UOGumpEditorUI";
            Load += UOGumpEditorUI_Load;
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
            CanvasPanel.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private StatusStrip BottomStatusStrip;
        private ToolStripStatusLabel GumpInfoLabel;
        private ToolStripProgressBar UOProgressBar;
        private ContextMenuStrip ElementStrip;
        private ToolStripMenuItem AddLabelButton;
        private ToolStripMenuItem AddTextBoxButton;
        private ToolStripMenuItem AddHTMLButton;
        private Panel ArtPanel;
        private PictureBox ArtPicturebox;
        private TextBox ArtIDSearchBox;
        private ListBox HistoryListbox;
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
        private Panel CanvasPanel;
    }
}