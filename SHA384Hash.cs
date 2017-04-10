using System;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;

namespace Hashing
{
    class SHA384Hash
    {
        private Stopwatch sw;
        private SHA384 sha384;
        private TimeSpan ElapseTime;
        public void CalculateHash(string input)
        {
            sw = Stopwatch.StartNew();
            sha384 = SHA384.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hash = sha384.ComputeHash(inputBytes);
            ElapseTime += sw.Elapsed;
            sw.Stop();
        }

        public TimeSpan TotalElapseTime()
        {
            return ElapseTime;
        }

    }
}
