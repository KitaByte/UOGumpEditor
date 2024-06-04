using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Text;

namespace UOGumpEditor.Assets
{
    public sealed class HueData
    {
        public static int Convert32(ushort value)
        {
            int argb;

            argb = ((value & 0x7C00) << 9) | ((value & 0x03E0) << 6) | ((value & 0x1F) << 3);

            argb = ((value & 0x8000) * 0x1FE00) | argb | ((argb >> 5) & 0x070707);

            return argb;
        }

        public static ushort Convert16(int value)
        {
            return (ushort)(((value >> 16) & 0x8000) | ((value >> 9) & 0x7C00) | ((value >> 6) & 0x03E0) | ((value >> 3) & 0x1F));
        }

        public Hue[] Entries { get; private set; } = [];

        public int Length => Entries.Length;

        public string? Directory { get; private set; }

        public void Clear()
        {
            Directory = null;

            Entries = [];
        }

        public void Load(string directoryPath)
        {
            Clear();

            var index = 0;

            var path = UOEditorCore.FindDataFile(directoryPath, "hues.mul");

            if (File.Exists(path))
            {
                Directory = directoryPath;

                using var file = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

                var blockCount = Math.Min(375, (int)file.Length / 708);

                var header = new int[blockCount];

                var structsize = Marshal.SizeOf(typeof(HueEntry));

                var buffer = new byte[blockCount * (4 + (8 * structsize))];

                var gc = GCHandle.Alloc(buffer, GCHandleType.Pinned);

                try
                {
                    var pin = gc.AddrOfPinnedObject();

                    _ = file.Read(buffer, 0, buffer.Length);

                    var currpos = 0L;

                    var list = new Hue[blockCount * 8];

                    for (var i = 0; i < blockCount; ++i)
                    {
                        var ptrheader = new IntPtr(pin + currpos);

                        currpos += 4L;

                        header[i] = (int)Marshal.PtrToStructure(ptrheader, typeof(int))!;

                        for (var j = 0; j < 8; ++j, ++index)
                        {
                            var ptr = new IntPtr(pin + currpos);

                            currpos += structsize;

                            var cur = (HueEntry)Marshal.PtrToStructure(ptr, typeof(HueEntry))!;

                            list[index] = new Hue(index, cur);
                        }
                    }

                    Entries = list;
                }
                finally
                {
                    gc.Free();
                }
            }

            while (index < Entries.Length)
            {
                Entries[index] = new Hue(index);

                ++index;
            }
        }

        public Hue GetHue(int index)
        {
            if (index >= 0 && index < Entries.Length)
            {
                return Entries[index];
            }

            return Entries[0];
        }

        public void ApplyTo(Bitmap bmp, int hue, bool onlyHueGrayPixels)
        {
            ApplyTo(bmp, GetHue(hue), onlyHueGrayPixels);
        }

        public void ApplyTo(Bitmap bmp, Hue hue, bool onlyHueGrayPixels)
        {
            ApplyTo(bmp, hue.Colors, onlyHueGrayPixels);
        }

        public unsafe void ApplyTo(Bitmap bmp, Color[] colors, bool onlyHueGrayPixels)
        {
            var bd = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);

            try
            {
                var stride = bd.Stride >> 2;

                var width = bd.Width;

                var height = bd.Height;

                var delta = stride - width;

                var pBuffer = (int*)bd.Scan0;

                var pLineEnd = pBuffer + width;

                var pImageEnd = pBuffer + (stride * height);

                int c, r, g, b;

                while (pBuffer < pImageEnd)
                {
                    while (pBuffer < pLineEnd)
                    {
                        c = Convert16(*pBuffer);

                        if (c != 0)
                        {
                            r = (c >> 10) & 0x1F;

                            if (onlyHueGrayPixels)
                            {
                                g = (c >> 5) & 0x1F;
                                b = c & 0x1F;

                                if (r == g && r == b)
                                {
                                    *pBuffer = colors[r].ToArgb();
                                }
                            }
                            else
                            {
                                *pBuffer = colors[r].ToArgb();
                            }
                        }

                        ++pBuffer;
                    }

                    pBuffer += delta;

                    pLineEnd += stride;
                }
            }
            finally
            {
                bmp.UnlockBits(bd);
            }
        }

        public readonly struct Hue
        {
            public int Index { get; }

            public Color[] Colors { get; } = new Color[32];

            public Color TableStart { get; }

            public Color TableEnd { get; }

            public string Name { get; }

            internal Hue(int index)
            {
                Index = index;

                Name = "Null";
            }

            internal Hue(int index, HueEntry entry)
            {
                Index = index;

                for (var i = 0; i < 32; ++i)
                {
                    Colors[i] = Color.FromArgb(Convert32((ushort)(entry.Colors[i] | 0x8000)));
                }

                TableStart = Color.FromArgb(Convert32((ushort)(entry.TableStart | 0x8000)));

                TableEnd = Color.FromArgb(Convert32((ushort)(entry.TableEnd | 0x8000)));

                var count = 0;

                while (count < 20 && count < entry.Name.Length && entry.Name[count] != 0)
                {
                    ++count;
                }

                Name = Encoding.UTF8.GetString(entry.Name, 0, count);

                Name = Name.Replace("\n", " ").TrimEnd('\0');
            }
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        internal struct HueEntry
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
            public ushort[] Colors;

            public ushort TableStart;

            public ushort TableEnd;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
            public byte[] Name;
        }
    }
}
