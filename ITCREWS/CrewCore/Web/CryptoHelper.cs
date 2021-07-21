using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Versioning;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace CrewCore.Web
{
    public class CryptoHelper
    {
        public string Key { get; set; }
        public string Domain { get; set; }
        private readonly AppConfig _config;

        public CryptoHelper(AppConfig config)
        {
            _config = config;
            Key = _config["SEEDKEY"];
            Domain = _config.Domain;

        }

        public string Decrypt(string val)
        {
            var aes = System.Security.Cryptography.Aes.Create();
            aes.KeySize = 256;
            aes.BlockSize = 128;
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;
            aes.Key = Encoding.UTF8.GetBytes(Key);
            aes.IV = new byte[] { 0, 1, 0, 3, 2, 2, 8, 0, 2, 6, 4, 0, 8, 0, 3, 0 };
            //복호화
            var decrypt = aes.CreateDecryptor();
            byte[] xBuff = null;
            using (var ms = new MemoryStream())
            {
                using (var cs = new CryptoStream(ms,decrypt,CryptoStreamMode.Write))
                {
                    byte[] xXml = Convert.FromBase64String(val);
                    cs.Write(xXml, 0, xXml.Length);
                }
                xBuff = ms.ToArray();
            }
            string output = Encoding.UTF8.GetString(xBuff);
                return output;

        }
        public string Encrypt(string val)
        {
            var aes = System.Security.Cryptography.Aes.Create();
            aes.KeySize = 256;
            aes.BlockSize = 128;
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;
            aes.Key = Encoding.UTF8.GetBytes(Key);
            aes.IV = new byte[] { 0, 1, 0, 3, 2, 2, 8, 0, 2, 6, 4, 0, 8, 0, 3, 0 };
            //암호화
            var encrypt = aes.CreateEncryptor(aes.Key, aes.IV);

            byte[] xBuff = null;
            using (var ms = new MemoryStream())
            {
                using (var cs = new CryptoStream(ms,encrypt,CryptoStreamMode.Write))
                {
                    byte[] xXml = Encoding.UTF8.GetBytes(val);
                    cs.Write(xXml, 0, xXml.Length);
                }
                xBuff = ms.ToArray();
            }
            string output = Convert.ToBase64String(xBuff);
                return output;
        }

    }
}
