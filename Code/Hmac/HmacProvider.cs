using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Hmac
{
    public class HmacProvider
    {

        public IHmacProvider Provider { get; private set; }

        public HmacProvider() : this(new HmacMd5Provider())
        {
            
        }

        public HmacProvider(IHmacProvider hmacProvider)
        {
            Provider = hmacProvider;
        }

        public string GetRandomKey()
        {
            var secretkey = new Byte[64];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(secretkey);
            }
            return Encode(secretkey);
        }

        public string Encode(IEnumerable<byte> key)
        {
            return Convert.ToBase64String(key.ToArray());
        }

        public byte[] Decode(string key)
        {
            return Convert.FromBase64String(key);
        }

        public byte[] GetSignature(byte[] key, string content)
        {
            return Provider.GetSignature(key, content);
        }

        public string GetSignature(string key, string content)
        {
            return Encode(GetSignature(Decode(key), content));
        }
    }
}
