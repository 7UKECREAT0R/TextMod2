using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TextMod_2.Core
{
    /// <summary>
    /// Does the tasks for the encryptor/decryptor in utilities.
    /// </summary>
    static class EncryptorBase
    {
        static char sc(char c, int a)
        {
            bool r = a < 0; for (int i = 0; r ? i > a : i < a; i += (r ? -1 : 1))
            {c = (char)(c + (r ? -1 : 1)); if (c > 126) c = (char)32; else if (c < 32) c = (char)126;}
            return c;
        }
        static string ss(string s, int a)
        {
            if (a > 0) return s.Substring(s.Length - 1 - a) + s.Remove(s.Length - 1 - a);
            else if (a < 0)
            { a -= 1; return s.Substring(-a) + s.Remove(-a); }
            else return s;
        }
        static string el(string t)
        {
            char[] s = new char[t.Length]; for (int i = 0; i < t.Length; i++)
            { char c = t[i]; c = sc(c, 2); s[i] = c; }
            return new string(s);
        }
        static string ee(string t)
        {
            t = el(t); char[] a = t.ToCharArray(); Array.Reverse(a);
            t = new string(a); t = ss(t, 3); return t;
        }
        static string dl(string t)
        {
            char[] s = new char[t.Length]; for (int i = 0; i < t.Length; i++)
            { char c = t[i]; c = sc(c, -2); s[i] = c; }
            return new string(s);
        }
        static string de(string t)
        {
            t = ss(t, -3); char[] a = t.ToCharArray(); Array.Reverse(a); t = new string(a); return dl(t);
        }

        public static string EncryptTextMod(string t)
        {
            t = ee(t); Random rs = new Random(t[0]); int s = rs.Next();
            Random r = new Random(s); byte[] b = new byte[sizeof(int) * t.Length];
            int[] ia = new int[t.Length]; r.NextBytes(b);
            int ii = -1; for (int i = 0; i < b.Length; i += sizeof(int))
                ia[++ii] = BitConverter.ToInt32(b, i);
            char[] c = t.ToCharArray(); for (int i = 0; i < ia.Length; i++)
            { int sf = ia[i] % 10; c[i] = sc(c[i], sf); }
            string f = new string(c); int sl = s.ToString().Length;
            string sr = sl + "s" + s + f; return ss(sr, sr.Length / 2);
        }
        public static string DecryptTextMod(string t)
        {
            t = ss(t, -(t.Length / 2)); string _ = t.Split('s')[0];
            int _s = _.Length + 1; int a = int.Parse(_); t = t.Substring(_s);
            string __s = t.Substring(0, a); t = t.Substring(a);
            int s = int.Parse(__s); Random r = new Random(s);
            byte[] b = new byte[sizeof(int) * t.Length]; int[] ia = new int[t.Length];
            r.NextBytes(b); int ii = -1; for (int i = 0; i < b.Length; i += sizeof(int))
                ia[++ii] = BitConverter.ToInt32(b, i); char[] c = t.ToCharArray();
            for (int i = 0; i < ia.Length; i++) { int f = ia[i] % 10; c[i] = sc(c[i], -f); }
            string z = de(new string(c)); return z;
        }

        public static string EncryptBase64(string s)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(s);
            return Convert.ToBase64String(bytes);
        }
        public static string DecryptBase64(string s)
        {
            byte[] bytes = Convert.FromBase64String(s);
            return Encoding.UTF8.GetString(bytes);
        }

        public static string EncryptSeedShift(string s, string seed)
        {
            using (SHA256 hasher = SHA256.Create())
            {
                byte[] hash = hasher.ComputeHash(Encoding.UTF8.GetBytes(seed));
                BigInteger big = new BigInteger(hash);
                int hashSeed = (int)BigInteger.Remainder(big, new BigInteger(int.MaxValue));
                Random random = new Random(hashSeed);

                char[] copy = s.ToCharArray();

                for (int i = 0; i < copy.Length; i++)
                {
                    char _c = copy[i];
                    if (_c == '\n' || _c == '\r' ||
                        _c == '\f' || _c == '\t')
                        continue;

                    short c = (short)copy[i];
                    c += (short)random.Next(12);
                    copy[i] = (char)c;
                }

                return new string(copy);
            }
        }
        public static string DecryptSeedShift(string s, string seed)
        {
            using (SHA256 hasher = SHA256.Create())
            {
                byte[] hash = hasher.ComputeHash(Encoding.UTF8.GetBytes(seed));
                BigInteger big = new BigInteger(hash);
                int hashSeed = (int)BigInteger.Remainder(big, new BigInteger(int.MaxValue));
                Random random = new Random(hashSeed);
                char[] copy = s.ToCharArray();

                for (int i = 0; i < copy.Length; i++)
                {
                    char _c = copy[i];
                    if (_c == '\n' || _c == '\r' ||
                        _c == '\f' || _c == '\t')
                        continue;

                    short c = (short)copy[i];
                    c -= (short)random.Next(12);
                    copy[i] = (char)c;
                }

                return new string(copy);
            }
        }
    }
}
