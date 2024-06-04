namespace UOGumpEditor
{
    public class ArtEntity(int id, string name, Bitmap? image, int w = 0, int h = 0)
    {
        public int ID { get; set; } = id;
        public string Name { get; set; } = name;
        public Bitmap? Image { get; set; } = image;
        public int Width { get; set; } = w;
        public int Height { get; set; } = h;
    }
}
