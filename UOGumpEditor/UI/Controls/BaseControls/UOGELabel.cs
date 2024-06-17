namespace UOGumpEditor
{
    public class UOGELabel : Label
    {
        public UOGELabel()
        {
            AutoSize = false;

            Size = new Size(70, 35);

            BorderStyle = BorderStyle.FixedSingle;

            Font = new Font("Segoe UI", 11, FontStyle.Bold);

            ForeColor = Color.WhiteSmoke;

            TextAlign = ContentAlignment.MiddleCenter;
        }
    }
}
