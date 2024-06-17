namespace UOGumpEditor
{
    public class UOGEButton : Button
    {
        public UOGEButton()
        {
            Size = new Size(70, 35);

            FlatStyle = FlatStyle.Flat;

            FlatAppearance.BorderSize = 0;

            Font = new Font("Segoe UI", 10, FontStyle.Bold);

            ForeColor = Color.WhiteSmoke;
        }
    }
}
