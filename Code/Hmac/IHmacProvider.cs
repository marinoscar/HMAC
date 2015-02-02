using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hmac
{
    public interface IHmacProvider
    {
        byte[] GetSignature(byte[] key, string content);
    }
}
