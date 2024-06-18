namespace UOGumpEditor
{
    public class UOGEElementPanel : UOGEPanel
    {
        public readonly UOGEListBox ElementListbox = new UOGEListBox()
        {
            BackColor = Color.FromArgb(32, 32, 32),
            ForeColor = Color.WhiteSmoke,
            SelectionMode = SelectionMode.MultiSimple,
            Dock = DockStyle.Fill
        };

        public readonly UOGEButton SelectAllButton = new UOGEButton()
        {
            Text = "Select All",
            BackColor = Color.Goldenrod,
            Dock = DockStyle.Bottom
        };

        public readonly UOGEButton ClearAllButton = new UOGEButton()
        {
            Text = "Clear Selected",
            BackColor = Color.Brown,
            Dock = DockStyle.Bottom
        };

        public UOGEElementPanel()
        {
            Size = new Size(125, 500);

            Dock = DockStyle.Left;

            Controls.Add(new UOGELabel() { Text = "Elements", BackColor = Color.DarkMagenta, Dock = DockStyle.Top });

            Controls.Add(SelectAllButton);

            SelectAllButton.Click += SelectAllButton_Click;

            Controls.Add(ClearAllButton);

            ClearAllButton.Click += ClearAllButton_Click;

            Controls.Add(ElementListbox);

            ElementListbox.BringToFront();

            ElementListbox.MouseDoubleClick += ElementListbox_MouseDoubleClick;

            ElementListbox.SelectedIndexChanged += ElementListbox_SelectedIndexChanged;
        }

        private void ElementListbox_MouseDoubleClick(object? sender, MouseEventArgs e)
        {
            if (ElementListbox.SelectedItem != null && ElementListbox.SelectedItem is ElementEntity ee)
            {
                UOEditorCore.OpenElementEditor(ee.Element.ElementType, ee.Element);
            }
        }

        private void ElementListbox_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (ElementListbox.Items.Count > 0)
            {
                for (int i = 0; i < ElementListbox.Items.Count; i++)
                {
                    if (ElementListbox.Items[i] is ElementEntity ee)
                    {
                        if (ElementListbox.SelectedItems.Contains(ee))
                        {
                            ee.Element.SetSelected(true);
                        }
                        else
                        {
                            ee.Element.SetSelected(false);
                        }
                    }
                }

                UOEditorCore.Session.CanvasUI.Invalidate();
            }
        }

        private void SelectAllButton_Click(object? sender, EventArgs e)
        {
            if (ElementListbox.Items.Count > 0)
            {
                ElementListbox.SuspendLayout();

                for (int i = 0; i < ElementListbox.Items.Count; i++)
                {
                    if (!ElementListbox.SelectedItems.Contains(ElementListbox.Items[i]))
                    {
                        ElementListbox.SetSelected(i, true);
                    }
                }

                ElementListbox.ResumeLayout();
            }
        }

        private void ClearAllButton_Click(object? sender, EventArgs e)
        {
            ElementListbox.ClearSelected();
        }
    }
}
