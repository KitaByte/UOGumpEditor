using System.Runtime.InteropServices;

namespace UOGumpEditor.Assets
{
    public sealed class FileIndex
    {
        public static readonly int EntryDataSize = Marshal.SizeOf<Entry3D>();

        public Entry3D[] Index { get; }

        public long IdxLength { get; }

        public int IdxCount { get; }

        private readonly string? _BinPath, _IdxPath;

        private FileIndex(int entryCount)
        {
            IdxLength = entryCount * EntryDataSize;

            IdxCount = entryCount;

            Index = new Entry3D[entryCount];
        }

        public FileIndex(string idxFile, string mulFile, int entryCount) : this(entryCount)
        {
            _IdxPath = idxFile;

            _BinPath = mulFile;

            using var index = new FileStream(_IdxPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

            var buffer = new byte[index.Length];

            IdxLength = index.Read(buffer, 0, buffer.Length);

            IdxCount = buffer.Length / EntryDataSize;

            index.Close();

            if (Index.Length != IdxCount)
            {
                Index = new Entry3D[IdxCount];
            }

            var gc = GCHandle.Alloc(Index, GCHandleType.Pinned);

            try
            {
                Marshal.Copy(buffer, 0, gc.AddrOfPinnedObject(), buffer.Length);
            }
            finally
            {
                gc.Free();
            }
        }

        public FileIndex(string uopFile, int entryCount, string entryExt, bool extended) : this(entryCount)
        {
            _IdxPath = _BinPath = uopFile;

            using var stream = new FileStream(_BinPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

            using var reader = new BinaryReader(stream);

            if (reader.ReadInt32() == 0x50594D)
            {
                _ = reader.ReadInt64(); // version + signature

                var nextBlock = reader.ReadInt64();

                _ = reader.ReadInt32(); // block capacity

                _ = reader.ReadInt32(); // block count

                var hashes = new Dictionary<ulong, int>();

                var root = $"build/{Path.GetFileNameWithoutExtension(_IdxPath).ToLowerInvariant()}";

                for (var i = 0; i < entryCount; i++)
                {
                    var hash = UOPHash.Compute($"{root}/{i:D8}{entryExt}");

                    hashes[hash] = i;
                }

                _ = stream.Seek(nextBlock, SeekOrigin.Begin);

                do
                {
                    var filesCount = reader.ReadInt32();

                    nextBlock = reader.ReadInt64();

                    for (var i = 0; i < filesCount; i++)
                    {
                        var offset = reader.ReadInt64();

                        var headerLength = reader.ReadInt32();

                        var compressedLength = reader.ReadInt32();

                        var decompressedLength = reader.ReadInt32();

                        var hash = reader.ReadUInt64();

                        _ = reader.ReadUInt32(); // Adler32

                        var flag = reader.ReadInt16();

                        var entryLength = flag == 1 ? compressedLength : decompressedLength;

                        if (offset == 0 || !hashes.TryGetValue(hash, out var idx))
                        {
                            continue;
                        }

                        if (idx < 0 || idx > Index.Length)
                        {
                            continue;
                        }

                        Index[idx].Offset = (int)(offset + headerLength);

                        Index[idx].Size = entryLength;

                        if (!extended)
                        {
                            continue;
                        }

                        var curPos = stream.Position;

                        _ = stream.Seek(offset + headerLength, SeekOrigin.Begin);

                        var extra = reader.ReadBytes(8);

                        var extra1 = (ushort)((extra[3] << 24) | (extra[2] << 16) | (extra[1] << 8) | extra[0]);

                        var extra2 = (ushort)((extra[7] << 24) | (extra[6] << 16) | (extra[5] << 8) | extra[4]);

                        Index[idx].Offset += 8;

                        Index[idx].Data = (extra1 << 16) | extra2;

                        _ = stream.Seek(curPos, SeekOrigin.Begin);
                    }
                }
                while (stream.Seek(nextBlock, SeekOrigin.Begin) != 0);
            }
        }

        public IEnumerable<(int Index, byte[] Buffer, int Length, int Data)> SeekAll()
        {
            return SeekRange(0, IdxCount);
        }

        public IEnumerable<(int Index, byte[] Buffer, int Length, int Data)> SeekRange(int index, int count)
        {
            if (!File.Exists(_BinPath))
            {
                yield break;
            }

            using var file = new FileStream(_BinPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

            while (--count >= 0 && index < IdxCount)
            {
                var e = Index[index];

                if (e.Offset < 0 || e.Size < 0)
                {
                    continue;
                }

                _ = file.Seek(e.Offset, SeekOrigin.Begin);

                var buffer = new byte[e.Size];

                var length = file.Read(buffer, 0, e.Size);

                yield return (index, buffer, length, e.Data);

                ++index;
            }
        }

        public bool Seek(int index, ref byte[]? buffer, out int length, out int data)
        {
            length = data = 0;

            if (!File.Exists(_BinPath))
            {
                return false;
            }

            if (index < 0 || index >= Index.Length)
            {
                return false;
            }

            var e = Index[index];

            if (e.Offset < 0 || e.Size < 0)
            {
                return false;
            }

            length = e.Size;

            data = e.Data;

            using var file = new FileStream(_BinPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

            _ = file.Seek(e.Offset, SeekOrigin.Begin);

            if (buffer == null || buffer.Length < e.Size)
            {
                buffer = new byte[e.Size];
            }

            length = file.Read(buffer, 0, e.Size);

            return true;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 12)]
        public struct Entry3D
        {
            public int Offset;

            public int Size;

            public int Data;
        }
    }
}
