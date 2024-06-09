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
            SettingsTabControl = new TabControl();
            MainTab = new TabPage();
            HeaderLabel = new Label();
            FooterLabel = new Label();
            ElementTab = new TabPage();
            GumpListPanel = new Panel();
            GumpNameTextbox = new TextBox();
            SetNameButton = new Button();
            FontPanel = new Panel();
            FontTextbox = new TextBox();
            SetFontButton = new Button();
            SearchTab = new TabPage();
            FlreeSlotPanel = new Panel();
            FreeSlotTextbox = new TextBox();
            FreeSlotButton = new Button();
            PreviewPanel = new Panel();
            PreviewTextbox = new TextBox();
            PreviewButton = new Button();
            MaxSearchPanel = new Panel();
            MaxSearchTextbox = new TextBox();
            MaxSearchButton = new Button();
            ExportTab = new TabPage();
            VersionPanel = new Panel();
            ExportCombobox = new ComboBox();
            VersionButton = new Button();
            StyleTab = new TabPage();
            CtrlSpeedPanel = new Panel();
            CtrlSpeedTextbox = new TextBox();
            CtrlSpeedButton = new Button();
            ShiftSpeedPanel = new Panel();
            ShiftSpeedTextbox = new TextBox();
            ShiftSpeedButton = new Button();
            ArtDisplayPanel = new Panel();
            ArtDisplayColorPanel = new Panel();
            ArtDisplayButton = new Button();
            BackgroundPanel = new Panel();
            BackgroundTextbox = new TextBox();
            BackgroundButton = new Button();
            LanguagePanel = new Panel();
            LanguageCombobox = new ComboBox();
            LanguageButton = new Button();
            SettingsTabControl.SuspendLayout();
            MainTab.SuspendLayout();
            ElementTab.SuspendLayout();
            GumpListPanel.SuspendLayout();
            FontPanel.SuspendLayout();
            SearchTab.SuspendLayout();
            FlreeSlotPanel.SuspendLayout();
            PreviewPanel.SuspendLayout();
            MaxSearchPanel.SuspendLayout();
            ExportTab.SuspendLayout();
            VersionPanel.SuspendLayout();
            StyleTab.SuspendLayout();
            CtrlSpeedPanel.SuspendLayout();
            ShiftSpeedPanel.SuspendLayout();
            ArtDisplayPanel.SuspendLayout();
            BackgroundPanel.SuspendLayout();
            LanguagePanel.SuspendLayout();
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
            ResetButton.TabIndex = 1;
            ResetButton.Text = "RESET UO DIRECTORY";
            ResetButton.UseVisualStyleBackColor = false;
            ResetButton.Click += ResetButton_Click;
            // 
            // SettingsTabControl
            // 
            SettingsTabControl.Appearance = TabAppearance.Buttons;
            SettingsTabControl.Controls.Add(MainTab);
            SettingsTabControl.Controls.Add(ElementTab);
            SettingsTabControl.Controls.Add(SearchTab);
            SettingsTabControl.Controls.Add(ExportTab);
            SettingsTabControl.Controls.Add(StyleTab);
            SettingsTabControl.Dock = DockStyle.Fill;
            SettingsTabControl.ItemSize = new Size(63, 22);
            SettingsTabControl.Location = new Point(0, 0);
            SettingsTabControl.Margin = new Padding(0);
            SettingsTabControl.Name = "SettingsTabControl";
            SettingsTabControl.SelectedIndex = 0;
            SettingsTabControl.Size = new Size(334, 426);
            SettingsTabControl.SizeMode = TabSizeMode.Fixed;
            SettingsTabControl.TabIndex = 0;
            // 
            // MainTab
            // 
            MainTab.BackColor = Color.Tan;
            MainTab.BackgroundImage = GumpRes.UOGSLogo;
            MainTab.BackgroundImageLayout = ImageLayout.Zoom;
            MainTab.Controls.Add(HeaderLabel);
            MainTab.Controls.Add(FooterLabel);
            MainTab.ForeColor = Color.WhiteSmoke;
            MainTab.Location = new Point(4, 26);
            MainTab.Margin = new Padding(0);
            MainTab.Name = "MainTab";
            MainTab.Padding = new Padding(5);
            MainTab.Size = new Size(326, 396);
            MainTab.TabIndex = 0;
            MainTab.Text = "Main";
            // 
            // HeaderLabel
            // 
            HeaderLabel.Dock = DockStyle.Top;
            HeaderLabel.FlatStyle = FlatStyle.Flat;
            HeaderLabel.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            HeaderLabel.ForeColor = Color.FromArgb(32, 32, 32);
            HeaderLabel.Location = new Point(5, 5);
            HeaderLabel.Name = "HeaderLabel";
            HeaderLabel.Size = new Size(316, 26);
            HeaderLabel.TabIndex = 1;
            HeaderLabel.Text = "Wilson Presents";
            HeaderLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // FooterLabel
            // 
            FooterLabel.Dock = DockStyle.Bottom;
            FooterLabel.FlatStyle = FlatStyle.Flat;
            FooterLabel.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            FooterLabel.ForeColor = Color.FromArgb(32, 32, 32);
            FooterLabel.Location = new Point(5, 365);
            FooterLabel.Name = "FooterLabel";
            FooterLabel.Size = new Size(316, 26);
            FooterLabel.TabIndex = 0;
            FooterLabel.Text = "UO Gump Studio © 2024";
            FooterLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ElementTab
            // 
            ElementTab.BackColor = Color.FromArgb(64, 64, 64);
            ElementTab.BackgroundImageLayout = ImageLayout.None;
            ElementTab.Controls.Add(GumpListPanel);
            ElementTab.Controls.Add(FontPanel);
            ElementTab.ForeColor = Color.WhiteSmoke;
            ElementTab.Location = new Point(4, 26);
            ElementTab.Margin = new Padding(0);
            ElementTab.Name = "ElementTab";
            ElementTab.Padding = new Padding(5);
            ElementTab.Size = new Size(326, 396);
            ElementTab.TabIndex = 1;
            ElementTab.Text = "Element";
            // 
            // GumpListPanel
            // 
            GumpListPanel.BackgroundImageLayout = ImageLayout.None;
            GumpListPanel.Controls.Add(GumpNameTextbox);
            GumpListPanel.Controls.Add(SetNameButton);
            GumpListPanel.Dock = DockStyle.Top;
            GumpListPanel.Location = new Point(5, 40);
            GumpListPanel.Margin = new Padding(0);
            GumpListPanel.Name = "GumpListPanel";
            GumpListPanel.Padding = new Padding(5);
            GumpListPanel.Size = new Size(316, 351);
            GumpListPanel.TabIndex = 1;
            // 
            // GumpNameTextbox
            // 
            GumpNameTextbox.BackColor = Color.WhiteSmoke;
            GumpNameTextbox.BorderStyle = BorderStyle.FixedSingle;
            GumpNameTextbox.Dock = DockStyle.Right;
            GumpNameTextbox.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            GumpNameTextbox.ForeColor = Color.Black;
            GumpNameTextbox.Location = new Point(158, 5);
            GumpNameTextbox.Margin = new Padding(0);
            GumpNameTextbox.MaxLength = 2;
            GumpNameTextbox.Name = "GumpNameTextbox";
            GumpNameTextbox.Size = new Size(153, 29);
            GumpNameTextbox.TabIndex = 2;
            GumpNameTextbox.TextAlign = HorizontalAlignment.Center;
            // 
            // SetNameButton
            // 
            SetNameButton.BackColor = Color.Goldenrod;
            SetNameButton.BackgroundImageLayout = ImageLayout.None;
            SetNameButton.Dock = DockStyle.Left;
            SetNameButton.FlatAppearance.BorderSize = 0;
            SetNameButton.FlatStyle = FlatStyle.Flat;
            SetNameButton.Location = new Point(5, 5);
            SetNameButton.Margin = new Padding(0);
            SetNameButton.Name = "SetNameButton";
            SetNameButton.Size = new Size(153, 341);
            SetNameButton.TabIndex = 1;
            SetNameButton.Text = "Set Name";
            SetNameButton.UseVisualStyleBackColor = false;
            SetNameButton.Click += SetNameButton_Click;
            // 
            // FontPanel
            // 
            FontPanel.Controls.Add(FontTextbox);
            FontPanel.Controls.Add(SetFontButton);
            FontPanel.Dock = DockStyle.Top;
            FontPanel.Location = new Point(5, 5);
            FontPanel.Margin = new Padding(0);
            FontPanel.Name = "FontPanel";
            FontPanel.Padding = new Padding(5);
            FontPanel.Size = new Size(316, 35);
            FontPanel.TabIndex = 0;
            // 
            // FontTextbox
            // 
            FontTextbox.BackColor = Color.WhiteSmoke;
            FontTextbox.BorderStyle = BorderStyle.FixedSingle;
            FontTextbox.Dock = DockStyle.Right;
            FontTextbox.ForeColor = Color.Black;
            FontTextbox.Location = new Point(158, 5);
            FontTextbox.Margin = new Padding(0);
            FontTextbox.MaxLength = 2;
            FontTextbox.Name = "FontTextbox";
            FontTextbox.Size = new Size(153, 25);
            FontTextbox.TabIndex = 1;
            FontTextbox.TextAlign = HorizontalAlignment.Center;
            // 
            // SetFontButton
            // 
            SetFontButton.BackColor = Color.SteelBlue;
            SetFontButton.BackgroundImageLayout = ImageLayout.None;
            SetFontButton.Dock = DockStyle.Left;
            SetFontButton.FlatAppearance.BorderSize = 0;
            SetFontButton.FlatStyle = FlatStyle.Flat;
            SetFontButton.Location = new Point(5, 5);
            SetFontButton.Margin = new Padding(0);
            SetFontButton.Name = "SetFontButton";
            SetFontButton.Size = new Size(153, 25);
            SetFontButton.TabIndex = 0;
            SetFontButton.Text = "Set Font Size";
            SetFontButton.UseVisualStyleBackColor = false;
            SetFontButton.Click += SetFontButton_Click;
            // 
            // SearchTab
            // 
            SearchTab.BackColor = Color.FromArgb(64, 64, 64);
            SearchTab.BackgroundImageLayout = ImageLayout.None;
            SearchTab.Controls.Add(FlreeSlotPanel);
            SearchTab.Controls.Add(PreviewPanel);
            SearchTab.Controls.Add(MaxSearchPanel);
            SearchTab.ForeColor = Color.WhiteSmoke;
            SearchTab.Location = new Point(4, 26);
            SearchTab.Margin = new Padding(0);
            SearchTab.Name = "SearchTab";
            SearchTab.Padding = new Padding(5);
            SearchTab.Size = new Size(326, 396);
            SearchTab.TabIndex = 2;
            SearchTab.Text = "Search";
            // 
            // FlreeSlotPanel
            // 
            FlreeSlotPanel.Controls.Add(FreeSlotTextbox);
            FlreeSlotPanel.Controls.Add(FreeSlotButton);
            FlreeSlotPanel.Dock = DockStyle.Top;
            FlreeSlotPanel.Location = new Point(5, 75);
            FlreeSlotPanel.Margin = new Padding(0);
            FlreeSlotPanel.Name = "FlreeSlotPanel";
            FlreeSlotPanel.Padding = new Padding(5);
            FlreeSlotPanel.Size = new Size(316, 35);
            FlreeSlotPanel.TabIndex = 2;
            // 
            // FreeSlotTextbox
            // 
            FreeSlotTextbox.BackColor = Color.WhiteSmoke;
            FreeSlotTextbox.BorderStyle = BorderStyle.FixedSingle;
            FreeSlotTextbox.Dock = DockStyle.Right;
            FreeSlotTextbox.ForeColor = Color.Black;
            FreeSlotTextbox.Location = new Point(158, 5);
            FreeSlotTextbox.Margin = new Padding(0);
            FreeSlotTextbox.MaxLength = 2;
            FreeSlotTextbox.Name = "FreeSlotTextbox";
            FreeSlotTextbox.ReadOnly = true;
            FreeSlotTextbox.Size = new Size(153, 25);
            FreeSlotTextbox.TabIndex = 1;
            FreeSlotTextbox.TextAlign = HorizontalAlignment.Center;
            // 
            // FreeSlotButton
            // 
            FreeSlotButton.BackColor = Color.SteelBlue;
            FreeSlotButton.BackgroundImageLayout = ImageLayout.None;
            FreeSlotButton.Dock = DockStyle.Left;
            FreeSlotButton.FlatAppearance.BorderSize = 0;
            FreeSlotButton.FlatStyle = FlatStyle.Flat;
            FreeSlotButton.Location = new Point(5, 5);
            FreeSlotButton.Margin = new Padding(0);
            FreeSlotButton.Name = "FreeSlotButton";
            FreeSlotButton.Size = new Size(153, 25);
            FreeSlotButton.TabIndex = 0;
            FreeSlotButton.Text = "Show Free Slots";
            FreeSlotButton.UseVisualStyleBackColor = false;
            FreeSlotButton.Click += FreeSlotButton_Click;
            // 
            // PreviewPanel
            // 
            PreviewPanel.Controls.Add(PreviewTextbox);
            PreviewPanel.Controls.Add(PreviewButton);
            PreviewPanel.Dock = DockStyle.Top;
            PreviewPanel.Location = new Point(5, 40);
            PreviewPanel.Margin = new Padding(0);
            PreviewPanel.Name = "PreviewPanel";
            PreviewPanel.Padding = new Padding(5);
            PreviewPanel.Size = new Size(316, 35);
            PreviewPanel.TabIndex = 1;
            // 
            // PreviewTextbox
            // 
            PreviewTextbox.BackColor = Color.WhiteSmoke;
            PreviewTextbox.BorderStyle = BorderStyle.FixedSingle;
            PreviewTextbox.Dock = DockStyle.Right;
            PreviewTextbox.ForeColor = Color.Black;
            PreviewTextbox.Location = new Point(158, 5);
            PreviewTextbox.Margin = new Padding(0);
            PreviewTextbox.MaxLength = 2;
            PreviewTextbox.Name = "PreviewTextbox";
            PreviewTextbox.ReadOnly = true;
            PreviewTextbox.Size = new Size(153, 25);
            PreviewTextbox.TabIndex = 1;
            PreviewTextbox.TextAlign = HorizontalAlignment.Center;
            // 
            // PreviewButton
            // 
            PreviewButton.BackColor = Color.SteelBlue;
            PreviewButton.BackgroundImageLayout = ImageLayout.None;
            PreviewButton.Dock = DockStyle.Left;
            PreviewButton.FlatAppearance.BorderSize = 0;
            PreviewButton.FlatStyle = FlatStyle.Flat;
            PreviewButton.Location = new Point(5, 5);
            PreviewButton.Margin = new Padding(0);
            PreviewButton.Name = "PreviewButton";
            PreviewButton.Size = new Size(153, 25);
            PreviewButton.TabIndex = 0;
            PreviewButton.Text = "Set Preview Sticky";
            PreviewButton.UseVisualStyleBackColor = false;
            PreviewButton.Click += PreviewButton_Click;
            // 
            // MaxSearchPanel
            // 
            MaxSearchPanel.Controls.Add(MaxSearchTextbox);
            MaxSearchPanel.Controls.Add(MaxSearchButton);
            MaxSearchPanel.Dock = DockStyle.Top;
            MaxSearchPanel.Location = new Point(5, 5);
            MaxSearchPanel.Margin = new Padding(0);
            MaxSearchPanel.Name = "MaxSearchPanel";
            MaxSearchPanel.Padding = new Padding(5);
            MaxSearchPanel.Size = new Size(316, 35);
            MaxSearchPanel.TabIndex = 0;
            // 
            // MaxSearchTextbox
            // 
            MaxSearchTextbox.BackColor = Color.WhiteSmoke;
            MaxSearchTextbox.BorderStyle = BorderStyle.FixedSingle;
            MaxSearchTextbox.Dock = DockStyle.Right;
            MaxSearchTextbox.ForeColor = Color.Black;
            MaxSearchTextbox.Location = new Point(158, 5);
            MaxSearchTextbox.Margin = new Padding(0);
            MaxSearchTextbox.MaxLength = 2;
            MaxSearchTextbox.Name = "MaxSearchTextbox";
            MaxSearchTextbox.Size = new Size(153, 25);
            MaxSearchTextbox.TabIndex = 1;
            MaxSearchTextbox.TextAlign = HorizontalAlignment.Center;
            // 
            // MaxSearchButton
            // 
            MaxSearchButton.BackColor = Color.SteelBlue;
            MaxSearchButton.BackgroundImageLayout = ImageLayout.None;
            MaxSearchButton.Dock = DockStyle.Left;
            MaxSearchButton.FlatAppearance.BorderSize = 0;
            MaxSearchButton.FlatStyle = FlatStyle.Flat;
            MaxSearchButton.Location = new Point(5, 5);
            MaxSearchButton.Margin = new Padding(0);
            MaxSearchButton.Name = "MaxSearchButton";
            MaxSearchButton.Size = new Size(153, 25);
            MaxSearchButton.TabIndex = 0;
            MaxSearchButton.Text = "Set Search Limit";
            MaxSearchButton.UseVisualStyleBackColor = false;
            MaxSearchButton.Click += MaxSearchButton_Click;
            // 
            // ExportTab
            // 
            ExportTab.BackColor = Color.FromArgb(64, 64, 64);
            ExportTab.BackgroundImageLayout = ImageLayout.None;
            ExportTab.Controls.Add(VersionPanel);
            ExportTab.ForeColor = Color.WhiteSmoke;
            ExportTab.Location = new Point(4, 26);
            ExportTab.Margin = new Padding(0);
            ExportTab.Name = "ExportTab";
            ExportTab.Padding = new Padding(5);
            ExportTab.Size = new Size(326, 396);
            ExportTab.TabIndex = 3;
            ExportTab.Text = "Export";
            // 
            // VersionPanel
            // 
            VersionPanel.Controls.Add(ExportCombobox);
            VersionPanel.Controls.Add(VersionButton);
            VersionPanel.Dock = DockStyle.Top;
            VersionPanel.Location = new Point(5, 5);
            VersionPanel.Margin = new Padding(0);
            VersionPanel.Name = "VersionPanel";
            VersionPanel.Padding = new Padding(5);
            VersionPanel.Size = new Size(316, 35);
            VersionPanel.TabIndex = 0;
            // 
            // ExportCombobox
            // 
            ExportCombobox.BackColor = Color.WhiteSmoke;
            ExportCombobox.Dock = DockStyle.Right;
            ExportCombobox.ForeColor = Color.Black;
            ExportCombobox.FormattingEnabled = true;
            ExportCombobox.Items.AddRange(new object[] { "CSharp", "Sphere" });
            ExportCombobox.Location = new Point(158, 5);
            ExportCombobox.Margin = new Padding(0);
            ExportCombobox.Name = "ExportCombobox";
            ExportCombobox.Size = new Size(153, 25);
            ExportCombobox.TabIndex = 2;
            ExportCombobox.SelectedIndexChanged += ExportCombobox_SelectedIndexChanged;
            // 
            // VersionButton
            // 
            VersionButton.BackColor = Color.SteelBlue;
            VersionButton.BackgroundImageLayout = ImageLayout.None;
            VersionButton.Dock = DockStyle.Left;
            VersionButton.FlatAppearance.BorderSize = 0;
            VersionButton.FlatStyle = FlatStyle.Flat;
            VersionButton.Location = new Point(5, 5);
            VersionButton.Margin = new Padding(0);
            VersionButton.Name = "VersionButton";
            VersionButton.Size = new Size(153, 25);
            VersionButton.TabIndex = 0;
            VersionButton.Text = "Select Export Type";
            VersionButton.UseVisualStyleBackColor = false;
            // 
            // StyleTab
            // 
            StyleTab.BackColor = Color.FromArgb(64, 64, 64);
            StyleTab.Controls.Add(CtrlSpeedPanel);
            StyleTab.Controls.Add(ShiftSpeedPanel);
            StyleTab.Controls.Add(ArtDisplayPanel);
            StyleTab.Controls.Add(BackgroundPanel);
            StyleTab.Controls.Add(LanguagePanel);
            StyleTab.ForeColor = Color.WhiteSmoke;
            StyleTab.Location = new Point(4, 26);
            StyleTab.Margin = new Padding(0);
            StyleTab.Name = "StyleTab";
            StyleTab.Padding = new Padding(5);
            StyleTab.Size = new Size(326, 396);
            StyleTab.TabIndex = 4;
            StyleTab.Text = "Style";
            // 
            // CtrlSpeedPanel
            // 
            CtrlSpeedPanel.Controls.Add(CtrlSpeedTextbox);
            CtrlSpeedPanel.Controls.Add(CtrlSpeedButton);
            CtrlSpeedPanel.Dock = DockStyle.Top;
            CtrlSpeedPanel.Location = new Point(5, 145);
            CtrlSpeedPanel.Margin = new Padding(0);
            CtrlSpeedPanel.Name = "CtrlSpeedPanel";
            CtrlSpeedPanel.Padding = new Padding(5);
            CtrlSpeedPanel.Size = new Size(316, 35);
            CtrlSpeedPanel.TabIndex = 4;
            // 
            // CtrlSpeedTextbox
            // 
            CtrlSpeedTextbox.BackColor = Color.WhiteSmoke;
            CtrlSpeedTextbox.BorderStyle = BorderStyle.FixedSingle;
            CtrlSpeedTextbox.Dock = DockStyle.Right;
            CtrlSpeedTextbox.ForeColor = Color.Black;
            CtrlSpeedTextbox.Location = new Point(158, 5);
            CtrlSpeedTextbox.Margin = new Padding(0);
            CtrlSpeedTextbox.MaxLength = 2;
            CtrlSpeedTextbox.Name = "CtrlSpeedTextbox";
            CtrlSpeedTextbox.Size = new Size(153, 25);
            CtrlSpeedTextbox.TabIndex = 1;
            CtrlSpeedTextbox.TextAlign = HorizontalAlignment.Center;
            // 
            // CtrlSpeedButton
            // 
            CtrlSpeedButton.BackColor = Color.SteelBlue;
            CtrlSpeedButton.BackgroundImageLayout = ImageLayout.None;
            CtrlSpeedButton.Dock = DockStyle.Left;
            CtrlSpeedButton.FlatAppearance.BorderSize = 0;
            CtrlSpeedButton.FlatStyle = FlatStyle.Flat;
            CtrlSpeedButton.Location = new Point(5, 5);
            CtrlSpeedButton.Margin = new Padding(0);
            CtrlSpeedButton.Name = "CtrlSpeedButton";
            CtrlSpeedButton.Size = new Size(153, 25);
            CtrlSpeedButton.TabIndex = 0;
            CtrlSpeedButton.Text = "Set Ctrl Speed";
            CtrlSpeedButton.UseVisualStyleBackColor = false;
            CtrlSpeedButton.Click += CtrlSpeedButton_Click;
            // 
            // ShiftSpeedPanel
            // 
            ShiftSpeedPanel.Controls.Add(ShiftSpeedTextbox);
            ShiftSpeedPanel.Controls.Add(ShiftSpeedButton);
            ShiftSpeedPanel.Dock = DockStyle.Top;
            ShiftSpeedPanel.Location = new Point(5, 110);
            ShiftSpeedPanel.Margin = new Padding(0);
            ShiftSpeedPanel.Name = "ShiftSpeedPanel";
            ShiftSpeedPanel.Padding = new Padding(5);
            ShiftSpeedPanel.Size = new Size(316, 35);
            ShiftSpeedPanel.TabIndex = 3;
            // 
            // ShiftSpeedTextbox
            // 
            ShiftSpeedTextbox.BackColor = Color.WhiteSmoke;
            ShiftSpeedTextbox.BorderStyle = BorderStyle.FixedSingle;
            ShiftSpeedTextbox.Dock = DockStyle.Right;
            ShiftSpeedTextbox.ForeColor = Color.Black;
            ShiftSpeedTextbox.Location = new Point(158, 5);
            ShiftSpeedTextbox.Margin = new Padding(0);
            ShiftSpeedTextbox.MaxLength = 2;
            ShiftSpeedTextbox.Name = "ShiftSpeedTextbox";
            ShiftSpeedTextbox.Size = new Size(153, 25);
            ShiftSpeedTextbox.TabIndex = 1;
            ShiftSpeedTextbox.TextAlign = HorizontalAlignment.Center;
            // 
            // ShiftSpeedButton
            // 
            ShiftSpeedButton.BackColor = Color.SteelBlue;
            ShiftSpeedButton.BackgroundImageLayout = ImageLayout.None;
            ShiftSpeedButton.Dock = DockStyle.Left;
            ShiftSpeedButton.FlatAppearance.BorderSize = 0;
            ShiftSpeedButton.FlatStyle = FlatStyle.Flat;
            ShiftSpeedButton.Location = new Point(5, 5);
            ShiftSpeedButton.Margin = new Padding(0);
            ShiftSpeedButton.Name = "ShiftSpeedButton";
            ShiftSpeedButton.Size = new Size(153, 25);
            ShiftSpeedButton.TabIndex = 0;
            ShiftSpeedButton.Text = "Set Shift Speed";
            ShiftSpeedButton.UseVisualStyleBackColor = false;
            ShiftSpeedButton.Click += ShiftSpeedButton_Click;
            // 
            // ArtDisplayPanel
            // 
            ArtDisplayPanel.Controls.Add(ArtDisplayColorPanel);
            ArtDisplayPanel.Controls.Add(ArtDisplayButton);
            ArtDisplayPanel.Dock = DockStyle.Top;
            ArtDisplayPanel.Location = new Point(5, 75);
            ArtDisplayPanel.Margin = new Padding(0);
            ArtDisplayPanel.Name = "ArtDisplayPanel";
            ArtDisplayPanel.Padding = new Padding(5);
            ArtDisplayPanel.Size = new Size(316, 35);
            ArtDisplayPanel.TabIndex = 2;
            // 
            // ArtDisplayColorPanel
            // 
            ArtDisplayColorPanel.BackColor = Color.Black;
            ArtDisplayColorPanel.Dock = DockStyle.Right;
            ArtDisplayColorPanel.Location = new Point(158, 5);
            ArtDisplayColorPanel.Margin = new Padding(0);
            ArtDisplayColorPanel.Name = "ArtDisplayColorPanel";
            ArtDisplayColorPanel.Size = new Size(153, 25);
            ArtDisplayColorPanel.TabIndex = 1;
            // 
            // ArtDisplayButton
            // 
            ArtDisplayButton.BackColor = Color.SteelBlue;
            ArtDisplayButton.BackgroundImageLayout = ImageLayout.None;
            ArtDisplayButton.Dock = DockStyle.Left;
            ArtDisplayButton.FlatAppearance.BorderSize = 0;
            ArtDisplayButton.FlatStyle = FlatStyle.Flat;
            ArtDisplayButton.Location = new Point(5, 5);
            ArtDisplayButton.Margin = new Padding(0);
            ArtDisplayButton.Name = "ArtDisplayButton";
            ArtDisplayButton.Size = new Size(153, 25);
            ArtDisplayButton.TabIndex = 0;
            ArtDisplayButton.Text = "Set Display Color";
            ArtDisplayButton.UseVisualStyleBackColor = false;
            ArtDisplayButton.Click += ArtDisplayButton_Click;
            // 
            // BackgroundPanel
            // 
            BackgroundPanel.Controls.Add(BackgroundTextbox);
            BackgroundPanel.Controls.Add(BackgroundButton);
            BackgroundPanel.Dock = DockStyle.Top;
            BackgroundPanel.Location = new Point(5, 40);
            BackgroundPanel.Margin = new Padding(0);
            BackgroundPanel.Name = "BackgroundPanel";
            BackgroundPanel.Padding = new Padding(5);
            BackgroundPanel.Size = new Size(316, 35);
            BackgroundPanel.TabIndex = 4;
            // 
            // BackgroundTextbox
            // 
            BackgroundTextbox.BackColor = Color.WhiteSmoke;
            BackgroundTextbox.BorderStyle = BorderStyle.FixedSingle;
            BackgroundTextbox.Dock = DockStyle.Right;
            BackgroundTextbox.ForeColor = Color.Black;
            BackgroundTextbox.Location = new Point(158, 5);
            BackgroundTextbox.Margin = new Padding(0);
            BackgroundTextbox.MaxLength = 2;
            BackgroundTextbox.Name = "BackgroundTextbox";
            BackgroundTextbox.ReadOnly = true;
            BackgroundTextbox.Size = new Size(153, 25);
            BackgroundTextbox.TabIndex = 1;
            BackgroundTextbox.Text = "Default Image";
            BackgroundTextbox.TextAlign = HorizontalAlignment.Center;
            // 
            // BackgroundButton
            // 
            BackgroundButton.BackColor = Color.SteelBlue;
            BackgroundButton.BackgroundImageLayout = ImageLayout.None;
            BackgroundButton.Dock = DockStyle.Left;
            BackgroundButton.FlatAppearance.BorderSize = 0;
            BackgroundButton.FlatStyle = FlatStyle.Flat;
            BackgroundButton.Location = new Point(5, 5);
            BackgroundButton.Margin = new Padding(0);
            BackgroundButton.Name = "BackgroundButton";
            BackgroundButton.Size = new Size(153, 25);
            BackgroundButton.TabIndex = 0;
            BackgroundButton.Text = "Set Background";
            BackgroundButton.UseVisualStyleBackColor = false;
            BackgroundButton.Click += BackgroundButton_Click;
            // 
            // LanguagePanel
            // 
            LanguagePanel.Controls.Add(LanguageCombobox);
            LanguagePanel.Controls.Add(LanguageButton);
            LanguagePanel.Dock = DockStyle.Top;
            LanguagePanel.Location = new Point(5, 5);
            LanguagePanel.Margin = new Padding(0);
            LanguagePanel.Name = "LanguagePanel";
            LanguagePanel.Padding = new Padding(5);
            LanguagePanel.Size = new Size(316, 35);
            LanguagePanel.TabIndex = 0;
            // 
            // LanguageCombobox
            // 
            LanguageCombobox.BackColor = Color.WhiteSmoke;
            LanguageCombobox.Dock = DockStyle.Right;
            LanguageCombobox.ForeColor = Color.Black;
            LanguageCombobox.FormattingEnabled = true;
            LanguageCombobox.Items.AddRange(new object[] { "English", "ToDo", "ToDo", "ToDo" });
            LanguageCombobox.Location = new Point(158, 5);
            LanguageCombobox.Margin = new Padding(0);
            LanguageCombobox.Name = "LanguageCombobox";
            LanguageCombobox.Size = new Size(153, 25);
            LanguageCombobox.TabIndex = 1;
            LanguageCombobox.SelectedIndexChanged += LanguageCombobox_SelectedIndexChanged;
            // 
            // LanguageButton
            // 
            LanguageButton.BackColor = Color.SteelBlue;
            LanguageButton.BackgroundImageLayout = ImageLayout.None;
            LanguageButton.Dock = DockStyle.Left;
            LanguageButton.FlatAppearance.BorderSize = 0;
            LanguageButton.FlatStyle = FlatStyle.Flat;
            LanguageButton.Location = new Point(5, 5);
            LanguageButton.Margin = new Padding(0);
            LanguageButton.Name = "LanguageButton";
            LanguageButton.Size = new Size(153, 25);
            LanguageButton.TabIndex = 0;
            LanguageButton.Text = "Select Language";
            LanguageButton.UseVisualStyleBackColor = false;
            // 
            // SettingsUI
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.FromArgb(32, 32, 32);
            BackgroundImageLayout = ImageLayout.None;
            ClientSize = new Size(334, 461);
            Controls.Add(SettingsTabControl);
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
            SettingsTabControl.ResumeLayout(false);
            MainTab.ResumeLayout(false);
            ElementTab.ResumeLayout(false);
            GumpListPanel.ResumeLayout(false);
            GumpListPanel.PerformLayout();
            FontPanel.ResumeLayout(false);
            FontPanel.PerformLayout();
            SearchTab.ResumeLayout(false);
            FlreeSlotPanel.ResumeLayout(false);
            FlreeSlotPanel.PerformLayout();
            PreviewPanel.ResumeLayout(false);
            PreviewPanel.PerformLayout();
            MaxSearchPanel.ResumeLayout(false);
            MaxSearchPanel.PerformLayout();
            ExportTab.ResumeLayout(false);
            VersionPanel.ResumeLayout(false);
            StyleTab.ResumeLayout(false);
            CtrlSpeedPanel.ResumeLayout(false);
            CtrlSpeedPanel.PerformLayout();
            ShiftSpeedPanel.ResumeLayout(false);
            ShiftSpeedPanel.PerformLayout();
            ArtDisplayPanel.ResumeLayout(false);
            BackgroundPanel.ResumeLayout(false);
            BackgroundPanel.PerformLayout();
            LanguagePanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button ResetButton;
        private TabControl SettingsTabControl;
        private TabPage MainTab;
        private TabPage ElementTab;
        private TabPage SearchTab;
        private TabPage ExportTab;
        private TabPage StyleTab;
        private Label HeaderLabel;
        private Label FooterLabel;
        private Panel FontPanel;
        private Button SetFontButton;
        private Panel GumpListPanel;
        private Button SetNameButton;
        private TextBox FontTextbox;
        private TextBox GumpNameTextbox;
        private Panel MaxSearchPanel;
        private TextBox MaxSearchTextbox;
        private Button MaxSearchButton;
        private Panel PreviewPanel;
        private TextBox PreviewTextbox;
        private Button PreviewButton;
        private Panel VersionPanel;
        private Button VersionButton;
        private Panel LanguagePanel;
        private Button LanguageButton;
        private Panel ArtDisplayPanel;
        private Button ArtDisplayButton;
        private Panel BackgroundPanel;
        private TextBox BackgroundTextbox;
        private Button BackgroundButton;
        private Panel ArtDisplayColorPanel;
        private ComboBox LanguageCombobox;
        private ComboBox ExportCombobox;
        private Panel FlreeSlotPanel;
        private TextBox FreeSlotTextbox;
        private Button FreeSlotButton;
        private Panel CtrlSpeedPanel;
        private TextBox CtrlSpeedTextbox;
        private Button CtrlSpeedButton;
        private Panel ShiftSpeedPanel;
        private TextBox ShiftSpeedTextbox;
        private Button ShiftSpeedButton;
    }
}