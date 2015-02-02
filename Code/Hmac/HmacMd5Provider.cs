using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Hmac
{
    public class HmacMd5Provider : IHmacProvider
    {
        public byte[] GetSignature(byte[] key, string content)
        {
            var contentArray = Encoding.UTF8.GetBytes(content);
            using (var hmac = new HMACMD5(key))
            {
                return hmac.ComputeHash(contentArray);
            }
        }
    }
}
