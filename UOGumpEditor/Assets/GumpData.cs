using System.Drawing.Imaging;

namespace UOGumpEditor.Assets
{
    public sealed class GumpData
    {
        [ThreadStatic]
        private static byte[]? _Buffer;

        private readonly Bitmap?[] _Cache = new Bitmap[65535];

        private readonly bool[] _Invalid = new bool[65535];

        private FileIndex? _FileIndex;

        public int Length => _Cache.Length;

        public int MaxGumpID { get; private set; }

        public bool UOP { get; private set; }

        public bool MUL { get; private set; }

        public string? Directory { get; private set; }

        public void Clear()
        {
            Directory = null;

            _Buffer = null;

            _FileIndex = null;

            MaxGumpID = 0;

            UOP = MUL = false;

            Array.Clear(_Cache);

            Array.Clear(_Invalid);
        }

        public void Load(string directoryPath)
        {
            Load(directoryPath, false);
        }

        public void Load(string directoryPath, bool uop)
        {
            Clear();

            if (uop)
            {
                var uopPath = UOEditorCore.FindDataFile(directoryPath, "gumpartLegacyMUL.uop");

                if (File.Exists(uopPath))
                {
                    Directory = directoryPath;

                    _FileIndex = new FileIndex(uopPath, 65535, ".tga", true);

                    UOP = true;
                }
            }

            if (!UOP)
            {
                var mulPath = UOEditorCore.FindDataFile(directoryPath, "gumpart.mul");

                var idxPath = UOEditorCore.FindDataFile(directoryPath, "gumpidx.mul");

                if (File.Exists(mulPath) && File.Exists(idxPath))
                {
                    Directory = directoryPath;

                    _FileIndex = new FileIndex(idxPath, mulPath, 65535);

                    MUL = true;
                }
            }

            if (_FileIndex != null)
            {
                MaxGumpID = _FileIndex.IdxCount - 1;
            }
        }

        public unsafe Bitmap? GetGump(int index)
        {
            if (index < 0 || index > MaxGumpID)
            {
                return null;
            }

            if (_Invalid[index])
            {
                return null;
            }

            if (_Cache[index] != null)
            {
                return _Cache[index];
            }

            if (_FileIndex == null)
            {
                return null;
            }

            if (!_FileIndex.Seek(index, ref _Buffer, out var length, out var extra) || extra == -1)
            {
                _Invalid[index] = true;

                return null;
            }

            var width = (extra >> 16) & 0xFFFF;

            var height = extra & 0xFFFF;

            if (width <= 0 || height <= 0)
            {
                return null;
            }

            fixed (byte* data = _Buffer)
            {
                var bin = (int*)data;

                var dat = (ushort*)data;

                var bmp = new Bitmap(width, height, PixelFormat.Format32bppArgb);

                var bd = bmp.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.WriteOnly, bmp.PixelFormat);

                try
                {
                    var line = (int*)bd.Scan0;

                    var delta = bd.Stride >> 2;

                    int count = 0, argb;

                    for (var y = 0; y < height; ++y, line += delta)
                    {
                        count = *bin++ * 2;

                        var cur = line;

                        var end = line + delta;

                        while (cur < end)
                        {
                            var color = dat[count++];

                            var next = cur + dat[count++];

                            if (color != 0)
                            {
                                color ^= 0x8000;

                                argb = ((color & 0x7C00) << 9) | ((color & 0x03E0) << 6) | ((color & 0x1F) << 3);

                                argb = ((color & 0x8000) * 0x1FE00) | argb | ((argb >> 5) & 0x070707);

                                while (cur < next)
                                {
                                    *cur++ = argb;
                                }
                            }
                            else
                            {
                                cur = next;
                            }
                        }
                    }
                }
                catch
                {
                    _Invalid[index] = true;

                    return null;
                }
                finally
                {
                    bmp.UnlockBits(bd);

                    if (_Invalid[index])
                    {
                        bmp.Dispose();

                        bmp = null;
                    }
                }

                return _Cache[index] = bmp;
            }
        }
    }
}
