
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace PressGatherer.References.Logics
{
    public class HashLogics
    {
        public static byte[] Hash(string value, string salt)
        {
            return Hash(Encoding.UTF8.GetBytes(value), Encoding.UTF8.GetBytes(salt));
        }

        public static byte[] Hash(string value, byte[] salt)
        {
            return Hash(Encoding.UTF8.GetBytes(value), salt);
        }

        public static byte[] Hash(byte[] value, byte[] salt)
        {
            byte[] saltedValue = value.Concat(salt).ToArray();
            return new SHA256Managed().ComputeHash(saltedValue);
        }

        public static bool ConfirmPassword(string password, byte[] comparehash, string comparesalt)
        {
            byte[] passwordHash = Hash(password, comparesalt);
            passwordHash = Encoding.UTF8.GetBytes(Encoding.UTF8.GetString(passwordHash));
            return comparehash.SequenceEqual(passwordHash);
        }
    }
}
