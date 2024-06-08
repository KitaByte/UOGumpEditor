using UOGumpEditor.UOGumps;

namespace UOGumpEditor
{
    public partial class GumpHandler : Form
    {
        private GumpActions _Action;

        public GumpHandler(GumpActions action)
        {
            InitializeComponent();

            _Action = action;
        }

        private void GumpHandler_Load(object sender, EventArgs e)
        {
            switch (_Action)
            {
                case GumpActions.Save:
                    {
                        TitleLabel.Text = "Save Gump";

                        GumpListbox.Visible = false;

                        SaveLoadExportButton.Text = "SAVE";

                        break;
                    }

                case GumpActions.Load:
                    {
                        GumpListbox.DataSource = CSVHelper.LoadAllGumps();

                        TitleLabel.Text = "Load Gump";

                        NameEntryTextBox.Visible = false;

                        SaveLoadExportButton.Text = "LOAD";

                        break;
                    }

                case GumpActions.Export:
                    {
                        TitleLabel.Text = "Export Gump";

                        GumpListbox.Visible = false;

                        SaveLoadExportButton.Text = "EXPORT";

                        break;
                    }
            }
        }

        private BaseGump? gump;

        private void GumpListbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (GumpListbox.SelectedItem != null && GumpListbox.SelectedItem is BaseGump baseGump)
            {
                gump = baseGump;
            }
        }

        private void SaveLoadExportButton_Click(object sender, EventArgs e)
        {
            switch (_Action)
            {
                case GumpActions.Save:
                    {
                        if (!string.IsNullOrEmpty(NameEntryTextBox.Text))
                        {
                            UOEditorCore.SaveGump(NameEntryTextBox.Text);
                        }
                        else
                        {
                            MessageBox.Show("Name Missing!", "Required!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }

                        break;
                    }

                case GumpActions.Load:
                    { 
                        if (gump != null)
                        {
                            UOEditorCore.LoadGump(gump);
                        }
                        else
                        {
                            MessageBox.Show("Selection Missing!", "Required!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }

                        break;
                    }

                case GumpActions.Export:
                    {

                        MessageBox.Show("Testing!", "Test!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        break;
                    }
            }

            Close();
        }
    }
}
