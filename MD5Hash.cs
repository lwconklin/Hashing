using System;
using System.Diagnostics;
using System.Security.Cryptography;

namespace Hashing
{
    
    class MD5Hash
    {
        private Stopwatch sw;
        private MD5 md5;
        private TimeSpan ElapseTime;

       /// A note about timing, this routine does not take into consideration of JIT or other background noise, instead in just accumates the time and at the end averages it out
       /// by the number of interations. My opinion an average is the best bet when doing performance testing. JIT and background noise is going to happen and should be taken 
       /// into consideration but trying to eleminate them from a performance test doen't seem right. 
         public void CalculateHash(string input)
         {
            sw = Stopwatch.StartNew(); 
            md5 = MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);
            // Six lines of code commented out. We want to capture the time creating a hash not printing out an hash. Debug code. 
            //StringBuilder sb = new StringBuilder();
            //foreach (byte b in hash)
            //{
            //    sb.AppendFormat("{0:x2}", b);
            //}
            //Console.WriteLine(sb.ToString());
            ElapseTime += sw.Elapsed;
            sw.Stop();
        }

         public TimeSpan TotalElapseTime()
         {
             return ElapseTime;
         }

    }
}
