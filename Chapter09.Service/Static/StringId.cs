using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Chapter09.Service.Static
{
    [Flags]
    public enum StringIdRanges
    {
        AlphaLower = 1,
        AlphaUpper = 2,
        Numeric = 4,
        Special = 8
    }

    /// <summary>
    /// this is a way to generate random string Ids of a desired length and format
    /// </summary>
    public static class StringId
    {
        // idea from https://scottlilly.com/create-better-random-numbers-in-c/
        private static readonly RNGCryptoServiceProvider _generator = new RNGCryptoServiceProvider();

        public static string NewId(int length, StringIdRanges idRanges = StringIdRanges.AlphaLower | StringIdRanges.Numeric)
        {
            var ranges = new Dictionary<StringIdRanges, string>()
            {
                [StringIdRanges.AlphaLower] = "abcdefghijklmnopqrstuvwxyz",
                [StringIdRanges.AlphaUpper] = "ABCDEFGHIJKLMNOPQRSTUVWXYZ",
                [StringIdRanges.Numeric] = "1234567890",
                [StringIdRanges.Special] = ".<>?!@#$%^&*()"
            };

            string source = string.Join(string.Empty, ranges.Where(r => (idRanges & r.Key) == r.Key).Select(kp => kp.Value));
            var sourceBytes = Encoding.ASCII.GetBytes(source);
            StringBuilder result = new StringBuilder();

            do
            {
                byte[] randomBytes = new byte[length - result.Length];
                _generator.GetNonZeroBytes(randomBytes);
                var allowedBytes = randomBytes.Where(b => sourceBytes.Contains(b)).Select(b => (char)b).ToArray();
                result.Append(new string(allowedBytes));
            } while (result.Length < length);

            return result.ToString();            
        }
    }
}
