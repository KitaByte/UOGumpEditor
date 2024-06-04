using System.Drawing.Imaging;

namespace UOGumpEditor.Assets
{
    public sealed class ArtData
    {
        [ThreadStatic]
        private static byte[]? _Buffer;

        private readonly Bitmap?[] _Cache = new Bitmap[81920];

        private readonly bool[] _Invalid = new bool[81920];

        private FileIndex? _FileIndex;

        public int Length => _Cache.Length;

        public int MaxLandID { get; private set; }

        public int MaxItemID { get; private set; }

        public bool UOP { get; private set; }

        public bool MUL { get; private set; }

        public string? Directory { get; private set; }

        public void Clear()
        {
            Directory = null;

            _FileIndex = null;

            MaxLandID = MaxItemID = 0;

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
                var uopPath = UOEditorCore.FindDataFile(directoryPath, "artLegacyMUL.uop");

                if (File.Exists(uopPath))
                {
                    Directory = directoryPath;

                    _FileIndex = new FileIndex(uopPath, 81920, ".tga", false);

                    UOP = true;
                }
            }

            if (!UOP)
            {
                var mulPath = UOEditorCore.FindDataFile(directoryPath, "art.mul");

                var idxPath = UOEditorCore.FindDataFile(directoryPath, "artidx.mul");

                if (File.Exists(mulPath) && File.Exists(idxPath))
                {
                    Directory = directoryPath;

                    _FileIndex = new FileIndex(idxPath, mulPath, 81920);

                    MUL = true;
                }
            }

            if (_FileIndex != null)
            {
                MaxLandID = 16383;

                MaxItemID = _FileIndex.IdxCount - (MaxLandID + 1);
            }
        }

        public unsafe Bitmap? GetLand(int index)
        {
            if (index < 0 || index > MaxLandID)
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

            if (!_FileIndex.Seek(index, ref _Buffer, out var length, out var extra))
            {
                _Invalid[index] = true;

                return null;
            }

            fixed (byte* data = _Buffer)
            {
                var dat = (ushort*)data;

                var xOffset = 21;

                var xRun = 2;

                var bmp = new Bitmap(44, 44, PixelFormat.Format32bppArgb);

                var bd = bmp.LockBits(new Rectangle(0, 0, 44, 44), ImageLockMode.WriteOnly, bmp.PixelFormat);

                try
                {
                    var line = (int*)bd.Scan0;

                    var delta = bd.Stride >> 2;

                    for (var y = 0; y < 22; ++y, --xOffset, xRun += 2, line += delta)
                    {
                        var cur = line + xOffset;

                        var end = cur + xRun;

                        while (cur < end)
                        {
                            *cur++ = HueData.Convert32((ushort)(*dat++ | 0x8000));
                        }
                    }

                    xOffset = 0;

                    xRun = 44;

                    for (var y = 0; y < 22; ++y, ++xOffset, xRun -= 2, line += delta)
                    {
                        var cur = line + xOffset;

                        var end = cur + xRun;

                        while (cur < end)
                        {
                            *cur++ = HueData.Convert32((ushort)(*dat++ | 0x8000));
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

        public unsafe Bitmap? GetStatic(int index)
        {
            if (index < 0 || index > MaxItemID)
            {
                return null;
            }

            index += MaxLandID + 1;

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

            if (!_FileIndex.Seek(index, ref _Buffer, out var length, out var extra))
            {
                _Invalid[index] = true;

                return null;
            }

            fixed (byte* data = _Buffer)
            {
                var dat = (ushort*)data;

                var count = 2;

                int width = dat[count++];

                int height = dat[count++];

                if (width <= 0 || height <= 0)
                {
                    return null;
                }

                var lookups = new int[height];

                var start = height + 4;

                for (var i = 0; i < height; ++i)
                {
                    lookups[i] = start + dat[count++];
                }

                var bmp = new Bitmap(width, height, PixelFormat.Format32bppArgb);

                var bd = bmp.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.WriteOnly, bmp.PixelFormat);

                try
                {
                    var line = (int*)bd.Scan0;

                    var delta = bd.Stride >> 2;

                    for (var y = 0; y < height; ++y, line += delta)
                    {
                        count = lookups[y];

                        int* cur = line, end;

                        int xOffset, xRun;

                        while (((xOffset = dat[count++]) + (xRun = dat[count++])) != 0)
                        {
                            if (xOffset > delta)
                            {
                                break;
                            }

                            cur += xOffset;

                            if (xOffset + xRun > delta)
                            {
                                break;
                            }

                            end = cur + xRun;

                            while (cur < end)
                            {
                                *cur++ = HueData.Convert32((ushort)(dat[count++] ^ 0x8000));
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

        public unsafe void Measure(Bitmap bmp, out int xMin, out int yMin, out int xMax, out int yMax)
        {
            xMin = yMin = 0;

            xMax = yMax = -1;

            if (bmp == null || bmp.Width <= 0 || bmp.Height <= 0)
            {
                return;
            }

            var bd = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);

            try
            {
                var lineDelta = bd.Stride >> 2;

                var pBuffer = (uint*)bd.Scan0;

                var pLineEnd = pBuffer + bd.Width;

                var pEnd = pBuffer + (bd.Height * lineDelta);

                var delta = lineDelta - bd.Width;

                var foundPixel = false;

                int x = 0, y = 0;

                while (pBuffer < pEnd)
                {
                    while (pBuffer < pLineEnd)
                    {
                        var c = *pBuffer++;

                        if ((c & 0x80000000) != 0)
                        {
                            if (!foundPixel)
                            {
                                foundPixel = true;

                                xMin = xMax = x;

                                yMin = yMax = y;
                            }
                            else
                            {
                                if (x < xMin)
                                {
                                    xMin = x;
                                }

                                if (y < yMin)
                                {
                                    yMin = y;
                                }

                                if (x > xMax)
                                {
                                    xMax = x;
                                }

                                if (y > yMax)
                                {
                                    yMax = y;
                                }
                            }
                        }

                        ++x;
                    }

                    pBuffer += delta;

                    pLineEnd += lineDelta;

                    ++y;

                    x = 0;
                }
            }
            finally
            {
                bmp.UnlockBits(bd);
            }
        }
    }
}
