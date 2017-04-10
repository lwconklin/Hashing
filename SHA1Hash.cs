using System;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;

namespace Hashing
{
    class SHA1Hash
    {
        private Stopwatch sw;
        private SHA1 sha1;
        private TimeSpan ElapseTime;

        public void CalculateHash(string input)
        {
            sw = Stopwatch.StartNew();
            sha1 = SHA1.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hash = sha1.ComputeHash(inputBytes);
            ElapseTime += sw.Elapsed;
            sw.Stop();
        }

        public TimeSpan TotalElapseTime()
        {
            return ElapseTime;
        }

    }
}
