using System.Runtime.CompilerServices;

namespace UOGumpEditor.Assets
{
    public static class UOPHash
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void Aggregate(ref uint val, ref int i, ref int l, ReadOnlySpan<char> buffer)
        {
            val += ((uint)buffer[i++] << 0) + ((uint)buffer[i++] << 8) + ((uint)buffer[i++] << 16) + ((uint)buffer[i++] << 24);

            l -= 4;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void Finalize(ref uint val, ref int i, ref int l, ReadOnlySpan<char> buffer)
        {
            val += (uint)buffer[i + --l] << (8 * (l % 4));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void Hash(ref uint a, ref uint b, ref uint c, ref int i, ref int l, ReadOnlySpan<char> buffer)
        {
            if (l > 12)
            {
                Aggregate(ref a, ref i, ref l, buffer);

                Aggregate(ref b, ref i, ref l, buffer);

                Aggregate(ref c, ref i, ref l, buffer);

                a -= c;
                a ^= (c << 4) | (c >> 28);
                c += b;

                b -= a;
                b ^= (a << 6) | (a >> 26);
                a += c;

                c -= b;
                c ^= (b << 8) | (b >> 24);
                b += a;

                a -= c;
                a ^= (c << 16) | (c >> 16);
                c += b;

                b -= a;
                b ^= (a << 19) | (a >> 13);
                a += c;

                c -= b;
                c ^= (b << 4) | (b >> 28);
                b += a;
            }
            else if (l > 0)
            {
                while (l > 0)
                {
                    switch ((l - 1) / 4)
                    {
                        case 0: Finalize(ref a, ref i, ref l, buffer); break;

                        case 1: Finalize(ref b, ref i, ref l, buffer); break;

                        case 2: Finalize(ref c, ref i, ref l, buffer); break;
                    }
                }

                c ^= b;
                c -= (b << 14) | (b >> 18);

                a ^= c;
                a -= (c << 11) | (c >> 21);

                b ^= a;
                b -= (a << 25) | (a >> 7);

                c ^= b;
                c -= (b << 16) | (b >> 16);

                a ^= c;
                a -= (c << 4) | (c >> 28);

                b ^= a;
                b -= (a << 14) | (a >> 18);

                c ^= b;
                c -= (b << 24) | (b >> 8);
            }
        }

        public static unsafe ulong Compute(string path)
        {
            var r = 0UL;

            if (path?.Length > 0)
            {
                var length = path.Length;

                var buffer = path.AsSpan();

                var h = 0xDEADBEEFU + (uint)length;

                uint a = h, b = h, c = h;

                var index = 0;

                while (length > 0)
                {
                    Hash(ref a, ref b, ref c, ref index, ref length, buffer);
                }

                r = b;

                r <<= 32;

                r |= c;
            }

            return r;
        }
    }
}
