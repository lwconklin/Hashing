using System;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;

namespace Hashing
{
    class SHA512Hash
    {
        private Stopwatch sw;
        private SHA512 sha512;
        private TimeSpan ElapseTime;
        public void CalculateHash(string input)
        {
            sw = Stopwatch.StartNew();
            sha512 = SHA512.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hash = sha512.ComputeHash(inputBytes);
            ElapseTime += sw.Elapsed;
            sw.Stop();
        }

        public TimeSpan TotalElapseTime()
        {
            return ElapseTime;
        }

    }
}
