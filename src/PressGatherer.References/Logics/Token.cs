
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace PressGatherer.References.Logics
{
    public class TokenLogics
    {
        public static string GetToken()
        {
            return Convert.ToBase64String(Guid.NewGuid().ToByteArray());
        }
    }
}
