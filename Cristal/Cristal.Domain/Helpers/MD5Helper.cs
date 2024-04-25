using System.Security.Cryptography;
using System.Text;

namespace Cristal.Domain.Helpers
{
    public static class MD5Helper
    {
        public static string Encrypt(string input)
        {
            using (var md5Hash = MD5.Create())
            {
                var data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
                var stringBuilder = new StringBuilder();

                foreach (var item in data)
                {
                    stringBuilder.Append(item.ToString("x2"));
                }

                return stringBuilder.ToString();
            }
        }
    }
}
