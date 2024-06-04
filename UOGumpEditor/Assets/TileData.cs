using System.Text;

namespace UOGumpEditor.Assets
{
    public struct LandData(string name, TileFlag flags)
    {
        public string Name { get; set; } = name;

        public TileFlag Flags { get; set; } = flags;
    }

    public struct ItemData(string name, TileFlag flags, byte weight, byte quality, ushort animation, byte quantity, byte value, byte height)
    {
        public string Name { get; set; } = name;

        public TileFlag Flags { get; set; } = flags;

        public byte Weight { get; set; } = weight;

        public byte Quality { get; set; } = quality;

        public ushort Animation { get; set; } = animation;

        public byte Quantity { get; set; } = quantity;

        public byte Value { get; set; } = value;

        public byte Height { get; set; } = height;
    }

    [Flags]
    public enum TileFlag : ulong
    {
        None = 0x0000000000000000,

        Background = 0x0000000000000001,
        Weapon = 0x0000000000000002,
        Transparent = 0x0000000000000004,
        Translucent = 0x0000000000000008,
        Wall = 0x0000000000000010,
        Damaging = 0x0000000000000020,
        Impassable = 0x0000000000000040,
        Wet = 0x0000000000000080,
        Unknown1 = 0x0000000000000100,
        Surface = 0x0000000000000200,
        Bridge = 0x0000000000000400,
        Generic = 0x0000000000000800,
        Window = 0x0000000000001000,
        NoShoot = 0x0000000000002000,
        ArticleA = 0x0000000000004000,
        ArticleAn = 0x0000000000008000,
        Internal = 0x0000000000010000,
        Foliage = 0x0000000000020000,
        PartialHue = 0x0000000000040000,
        Unknown2 = 0x0000000000080000,
        Map = 0x0000000000100000,
        Container = 0x0000000000200000,
        Wearable = 0x0000000000400000,
        LightSource = 0x0000000000800000,
        Animation = 0x0000000001000000,
        HoverOver = 0x0000000002000000,
        Unknown3 = 0x0000000004000000,
        Armor = 0x0000000008000000,
        Roof = 0x0000000010000000,
        Door = 0x0000000020000000,
        StairBack = 0x0000000040000000,
        StairRight = 0x0000000080000000,

        HS33 = 0x0000000100000000,
        HS34 = 0x0000000200000000,
        HS35 = 0x0000000400000000,
        HS36 = 0x0000000800000000,
        HS37 = 0x0000001000000000,
        HS38 = 0x0000002000000000,
        HS39 = 0x0000004000000000,
        HS40 = 0x0000008000000000,
        HS41 = 0x0000010000000000,
        HS42 = 0x0000020000000000,
        HS43 = 0x0000040000000000,
        HS44 = 0x0000080000000000,
        HS45 = 0x0000100000000000,
        HS46 = 0x0000200000000000,
        HS47 = 0x0000400000000000,
        HS48 = 0x0000800000000000,
        HS49 = 0x0001000000000000,
        HS50 = 0x0002000000000000,
        HS51 = 0x0004000000000000,
        HS52 = 0x0008000000000000,
        HS53 = 0x0010000000000000,
        HS54 = 0x0020000000000000,
        HS55 = 0x0040000000000000,
        HS56 = 0x0080000000000000,
        HS57 = 0x0100000000000000,
        HS58 = 0x0200000000000000,
        HS59 = 0x0400000000000000,
        HS60 = 0x0800000000000000,
        HS61 = 0x1000000000000000,
        HS62 = 0x2000000000000000,
        HS63 = 0x4000000000000000,
        HS64 = 0x8000000000000000
    }

    public sealed class TileData
    {
        private static unsafe string ReadNameString(BinaryReader bin)
        {
            Span<byte> buffer = stackalloc byte[20];

            _ = bin.Read(buffer);

            var count = 0;

            while (count < buffer.Length && buffer[count] != 0)
            {
                ++count;
            }

            return Encoding.ASCII.GetString(buffer.Slice(0, count));
        }

        public LandData[] LandTable { get; } = new LandData[16384];

        public ItemData[] ItemTable { get; } = new ItemData[65536];

        public int MaxLandID { get; private set; }

        public int MaxItemID { get; private set; }

        public bool Is64BitFlags { get; private set; }

        public string? Directory { get; private set; }

        public void Clear()
        {
            Directory = null;

            Is64BitFlags = false;

            MaxLandID = MaxItemID = 0;

            Array.Clear(LandTable);

            Array.Clear(ItemTable);
        }

        public void Load(string directoryPath)
        {
            Clear();

            var path = UOEditorCore.FindDataFile(directoryPath, "tiledata.mul");

            if (File.Exists(path))
            {
                Directory = directoryPath;

                using var file = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

                using var reader = new BinaryReader(file);

                if (file.Length >= 3188736) // 7.0.9.0
                {
                    Is64BitFlags = true;

                    MaxLandID = 16383;

                    MaxItemID = 65535;
                }
                else if (file.Length >= 1644544) // 7.0.0.0
                {
                    MaxLandID = 16383;

                    MaxItemID = 32767;
                }
                else
                {
                    MaxLandID = 16383;

                    MaxItemID = 16383;
                }

                for (var i = 0; i <= MaxLandID; ++i)
                {
                    if (Is64BitFlags ? (i == 1 || (i > 0 && (i & 0x1F) == 0)) : ((i & 0x1F) == 0))
                    {
                        _ = reader.ReadInt32(); // header
                    }

                    var flags = (TileFlag)(Is64BitFlags ? reader.ReadUInt64() : reader.ReadUInt32());

                    _ = reader.ReadInt16(); // skip 2 bytes -- textureID

                    LandTable[i] = new LandData(ReadNameString(reader), flags);
                }

                for (var i = 0; i <= MaxItemID; ++i)
                {
                    if ((i & 0x1F) == 0)
                    {
                        _ = reader.ReadInt32(); // header
                    }

                    var flags = (TileFlag)(Is64BitFlags ? reader.ReadUInt64() : reader.ReadUInt32());

                    var weight = reader.ReadByte();

                    var quality = reader.ReadByte();

                    var anim = reader.ReadUInt16();

                    _ = reader.ReadByte();

                    var quantity = reader.ReadByte();

                    _ = reader.ReadInt32();

                    _ = reader.ReadByte();

                    var value = reader.ReadByte();

                    var height = reader.ReadByte();

                    var name = ReadNameString(reader);

                    ItemTable[i] = new ItemData(name, flags, weight, quality, anim, quantity, value, height);
                }
            }
        }
    }
}
