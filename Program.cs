using System;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Hashing
{
    class Program
    {
        static Random random = new Random();
        static Int64 MaxIterations = 10000;
        static TimeSpan TotalTotal = TimeSpan.Zero;
        static Int16 TotalHashLength = 1024;
        static System.IO.StreamWriter file;
        static Stopwatch sw;

        static void Main(string[] args)
        {
            file = new System.IO.StreamWriter(@"C:\HashPerformananceData.csv");
            sw = Stopwatch.StartNew();
            MD5();
            SHA1();
            SHA256();
            SHA384();
            SHA512();
            sw.Stop();
            file.WriteLine("Total, {0}", sw.Elapsed);
            file.Flush();
            file.Close();
        }

        static void MD5()
        {
            MD5Hash md5Hash = new MD5Hash();
            for (int i = 0; i < MaxIterations - 1; i++)
            {
                md5Hash.CalculateHash(RandomString(TotalHashLength));
            }

            file.WriteLine("MD5 , {0}", md5Hash.TotalElapseTime().ToString());
        }

        static void SHA1()
        {
            SHA1Hash sha1Hash = new SHA1Hash();
            for (int i = 0; i < MaxIterations - 1; i++)
            {
                sha1Hash.CalculateHash(RandomString(TotalHashLength));
            }

            file.WriteLine("SHA1 , {0}", sha1Hash.TotalElapseTime().ToString());
        }

        static void SHA256()
        {
            SHA256Hash sha256Hash = new SHA256Hash();
            for (int i = 0; i < MaxIterations - 1; i++)
            {
                sha256Hash.CalculateHash(RandomString(TotalHashLength));
            }

            file.WriteLine("SHA256 , {0}", sha256Hash.TotalElapseTime().ToString());
        }

        static void SHA384()
        {
            SHA384Hash sha384Hash = new SHA384Hash();
            for (int i = 0; i < MaxIterations - 1; i++)
            {
                sha384Hash.CalculateHash(RandomString(TotalHashLength));
            }

            file.WriteLine("SHA384 , {0}", sha384Hash.TotalElapseTime().ToString());
        }

        static void SHA512()
        {
            SHA512Hash sha512Hash = new SHA512Hash();
            for (int i = 0; i < MaxIterations - 1; i++)
            {
                sha512Hash.CalculateHash(RandomString(TotalHashLength));
            }

            file.WriteLine("SHA512 , {0}", sha512Hash.TotalElapseTime().ToString());
        }

        static string RandomString(int length)
        {
            const string chars = "Aa0BbCcDd1+EeFf2_GgHh3(IiJj4)KkLl5*MmNn6&OoPp7^QqRr8%SsTt9#UuVv@WwXxYyZz!";
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < length; i++)
            {
                sb.Append(new string(Enumerable.Repeat(chars, 1).Select(s => s[random.Next(s.Length)]).ToArray()));
            }
            return sb.ToString();
        }

    }
}
