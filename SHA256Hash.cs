using System;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;

namespace Hashing
{
    class SHA256Hash
    {
        private Stopwatch sw;
        private SHA256 sha256;
        private TimeSpan ElapseTime;
        public void CalculateHash(string input)
        {
            sw = Stopwatch.StartNew();
            sha256 = SHA256.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hash = sha256.ComputeHash(inputBytes);
            ElapseTime += sw.Elapsed;
            sw.Stop();
        }

        public TimeSpan TotalElapseTime()
        {
            return ElapseTime;
        }

    }
}
