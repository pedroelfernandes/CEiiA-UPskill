using System.Text;
using System.Security.Cryptography;
using System.Security;

namespace MainAPI.Helpers.Implementations
{
    public static class PwdEncryptor
    {
        public static string Encrypt(string pwd)
        {
            byte[] dataToEncrypt = Encoding.UTF8.GetBytes(pwd);

            dataToEncrypt = System.Security.Cryptography.SHA256.Create().ComputeHash(dataToEncrypt);

            string dataEncrypted = Encoding.UTF8.GetString(dataToEncrypt);

            return dataEncrypted;
        }
    }
}
