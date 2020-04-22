using System.Security.Cryptography;
using System.Text;

namespace Web.Util
{
    public static class Security
    {
        public static string ToHash(string password)
        {
            SHA256 shaM = new SHA256Managed();
            return  Encoding.Default.GetString(shaM.ComputeHash(Encoding.Unicode.GetBytes(password)));
        }
    }
}
