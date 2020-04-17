using System.Security.Cryptography;
using System.Text;

namespace Web.Util
{
    public static class Security
    {
        public static string ToHash(string password)
        {
            SHA512 shaM = new SHA512Managed();
            return shaM.ComputeHash(Encoding.Unicode.GetBytes(password)).ToString();
        }
    }
}
