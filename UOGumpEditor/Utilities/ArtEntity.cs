using System.Text.RegularExpressions;
using UOGumpEditor.Assets;

namespace UOGumpEditor
{
    public class ArtEntity(int id, string name, int w, int h, bool isGump) : IComparable<ArtEntity>
    {
        public bool IsGump { get; init; } = isGump;
        public int ID { get; init; } = id;
        public string Name { get; init; } = name;
        public int Width { get; init; } = w;
        public int Height { get; init; } = h;

        public Bitmap? GetImage()
        {
            if (IsGump)
            {
                return AssetData.Gumps.GetGump(ID);
            }
            else
            {
                return AssetData.Art.GetStatic(ID);
            }
        }

        public int CompareTo(ArtEntity? other)
        {
            if (other == null) return 1;

            var nameX = GetAlphabeticPart(Name);

            var nameY = GetAlphabeticPart(other.Name);

            var result = string.Compare(nameX, nameY, StringComparison.Ordinal);

            if (result == 0)
            {
                var numberX = GetNumericPart(Name);

                var numberY = GetNumericPart(other.Name);

                result = numberX.CompareTo(numberY);
            }

            return result;
        }

        private static string GetAlphabeticPart(string name)
        {
            var match = Regex.Match(name, @"^[a-zA-Z]+");

            return match.Value;
        }

        private static int GetNumericPart(string name)
        {
            var match = Regex.Match(name, @"\d+$");

            return match.Success ? int.Parse(match.Value) : 0;
        }

        public override string ToString()
        {
            return $"{ID} : {(IsGump ? $"G-{Name}" : $"I-{Name}")}";
        }
    }
}
