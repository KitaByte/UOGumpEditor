using UOGumpEditor.UOGumps;

namespace UOGumpEditor
{
    public static class CSVHelper
    {
        private static readonly string SaveDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SavedGumps");

        static CSVHelper()
        {
            if (!Directory.Exists(SaveDirectory))
            {
                Directory.CreateDirectory(SaveDirectory);
            }
        }

        public static void SaveGump(BaseGump gump)
        {
            string filePath = Path.Combine(SaveDirectory, $"{gump.Name}.csv");

            using StreamWriter writer = new(filePath);

            writer.WriteLine("ID,Name,Width,Height,IsGump,Text,Type,LocationX,LocationY,SizeWidth,SizeHeight,Color");

            foreach (var element in gump.Elements)
            {
                var line = 
                    $"{element.ArtID}," +
                    $"{element.ArtName}," +
                    $"{element.ArtWidth}," +
                    $"{element.ArtHeight}," +
                    $"{element.IsGump}," +
                    $"{element.Text}," +
                    $"{element.Type}," +
                    $"{element.Location.X}," +
                    $"{element.Location.Y}," +
                    $"{element.Size.Width}," +
                    $"{element.Size.Height}," +
                    $"{element.Color.ToArgb()}";

                writer.WriteLine(line);
            }
        }

        private static List<BaseGump>? _cachedGumps;

        public static List<BaseGump> LoadAllGumps()
        {
            if (_cachedGumps == null)
            {
                _cachedGumps = [];
            }
            else
            {
                return _cachedGumps;
            }

            foreach (string file in Directory.GetFiles(SaveDirectory, "*.csv"))
            {
                using StreamReader reader = new(file);

                BaseGump gump = new(Path.GetFileNameWithoutExtension(file));

                string? headerLine = reader.ReadLine(); // Skip header

                while (!reader.EndOfStream)
                {
                    string? line = reader.ReadLine();

                    if (line != null)
                    {
                        string[] values = line.Split(',');

                        GumpElement element = new()
                        {
                            ArtID = int.Parse(values[0]),
                            ArtName = values[1],
                            ArtWidth = int.Parse(values[2]),
                            ArtHeight = int.Parse(values[3]),
                            IsGump = bool.Parse(values[4]),
                            Text = values[5],
                            Type = values[6],
                            Location = new Point(int.Parse(values[7]), int.Parse(values[8])),
                            Size = new Size(int.Parse(values[9]), int.Parse(values[10])),
                            Color = Color.FromArgb(int.Parse(values[11]))
                        };

                        gump.Elements.Add(element);
                    }
                }

                _cachedGumps.Add(gump);
            }

            return _cachedGumps;
        }
    }
}

