using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Guoli.Utilities.Extensions
{
    public static class StreamExtensions
    {
        public static string GetMd5(this Stream stream)
        {
            if (stream == null)
            {
                throw new ArgumentNullException(nameof(stream));
            }

            var hashBytes = MD5.Create().ComputeHash(stream);
            var stringBuilder = new StringBuilder();
            foreach (var hashByte in hashBytes)
            {
                stringBuilder.Append(hashByte.ToString("x2"));
            }

            return stringBuilder.ToString();
        }
    }
}
