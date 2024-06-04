using System.Text;
using System.Text.RegularExpressions;

namespace UOGumpEditor.Assets
{
    public sealed class ClilocData
    {
        public Dictionary<int, ClilocEntry> Entries { get; } = [];

        public int Count => Entries.Count;

        public string? Directory { get; private set; }

        public string? Language { get; private set; }

        public void Clear()
        {
            Directory = Language = null;

            Entries.Clear();
        }

        public void Load(string directoryPath)
        {
            Load(directoryPath, "enu");
        }

        public void Load(string directoryPath, string language)
        {
            Clear();

            Directory = directoryPath;

            Language = language;

            var path = UOEditorCore.FindDataFile(Directory, $"Cliloc.{Language}");

            if (!File.Exists(path))
            {
                return;
            }

            using var file = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

            using var reader = new BinaryReader(file);

            var buffer = new byte[1024];

            _ = reader.ReadInt32();

            _ = reader.ReadInt16();

            while (reader.BaseStream.Position < reader.BaseStream.Length)
            {
                var number = reader.ReadInt32();

                _ = reader.ReadByte(); // flag

                var length = reader.ReadInt16();

                if (length > buffer.Length)
                {
                    buffer = new byte[(length + 1023) & ~1023];
                }

                _ = reader.Read(buffer, 0, length);

                var text = Encoding.UTF8.GetString(buffer, 0, length);

                Entries[number] = new ClilocEntry(number, text);
            }
        }

        public ClilocEntry GetEntry(int number)
        {
            _ = Entries.TryGetValue(number, out var entry);

            return entry;
        }

        public string GetString(int number, params object[] args)
        {
            _ = Entries.TryGetValue(number, out var entry);

            return entry.ToString(args);
        }
    }

    public struct ClilocEntry
    {
        private const RegexOptions _RegexOptions = RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.CultureInvariant;

        private string? _Formatted;

        public int Number { get; }
        public string String { get; }

        public ClilocEntry(int number, string text)
        {
            Number = number;

            String = text;
        }

        public override readonly int GetHashCode()
        {
            return Number;
        }

        public override readonly string ToString()
        {
            return String;
        }

        public string ToString(params object[] args)
        {
            if (args?.Length > 0)
            {
                _Formatted ??= Regex.Replace(String, @"~(\d+)[_\w]+~", @"{$1}", _RegexOptions);

                return String.Format(_Formatted, args);
            }

            return String;
        }
    }
}
