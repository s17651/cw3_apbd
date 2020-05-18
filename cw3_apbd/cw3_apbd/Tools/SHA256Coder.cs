using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace cw3_apbd.Tools
{
    public class SHA256Coder
    {
        public static string GetHashFromString(string value)
        {
            var hash = SHA256.Create();
            var byteArray = hash.ComputeHash(Encoding.UTF8.GetBytes(value));
            var stringBuilder = new StringBuilder();
            for (int i = 0; i < byteArray.Length; i++)
            {
                stringBuilder.Append(byteArray[i].ToString("x2"));
            }
            return stringBuilder.ToString();
        }
    }
}
