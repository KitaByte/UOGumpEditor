namespace UOGumpEditor
{
    public class UOGETextBox : TextBox
    {
        public UOGETextBox()
        {
            Size = new Size(70, 25);

            BorderStyle = BorderStyle.FixedSingle;

            Font = new Font("Segoe UI", 10, FontStyle.Bold);

            ForeColor = Color.Black;

            TextAlign = HorizontalAlignment.Center;
        }
    }
}
