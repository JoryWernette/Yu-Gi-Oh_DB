using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace LogicLayer
{
    public static class StringHelpers
    {
        public static string SHA256Value(this string source)
        {
            string result = "";

            // create a byte array - cryptography is byte oriented
            byte[] data;

            // create a .NET hash provider object
            using (SHA256 sha256hash = SHA256.Create())
            {
                // hash the source
                data = sha256hash.ComputeHash(Encoding.UTF8.GetBytes(source));
            }

            // now to build the result string
            var s = new StringBuilder();

            // loop through the byte array
            for (int i = 0; i < data.Length; i++)
            {
                s.Append(data[i].ToString("x2"));
            }

            // convert the string builder to a string
            result = s.ToString();

            return result;
        }
    }
}
