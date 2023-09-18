using BaseAPI.Business.Interface.Security;
using BaseAPI.Util;
using System.Security.Cryptography;
using System.Text;

namespace BaseAPI.Business.Security
{
    public class CryptographyBusiness : ICryptographyBusiness
    {
        readonly MasterConfiguration configuration;
        private string clave;
        private static string Hex;
        private static byte[] IV;
        private readonly Aes aesAlg;
        public CryptographyBusiness()
        {
            this.configuration = new MasterConfiguration();
            this.clave = this.configuration.cryptography.Clave;
            Hex = this.configuration.cryptography.Hex;
            GenerateIV();
            this.aesAlg = Aes.Create();
            this.aesAlg.Key = Encoding.UTF8.GetBytes(this.clave);
            this.aesAlg.Mode = CipherMode.CFB;
            this.aesAlg.Padding = PaddingMode.PKCS7;
        }

        public string Encrypting(string text)
        {
            ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, IV);

            using MemoryStream msEncrypt = new MemoryStream();
            using CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write);

            // Convierte el texto a bytes y encripta
            byte[] textoBytes = Encoding.UTF8.GetBytes(text);
            csEncrypt.Write(textoBytes, 0, textoBytes.Length);
            csEncrypt.FlushFinalBlock();

            // Devuelve la representación Base64 del texto encriptado
            return Convert.ToBase64String(msEncrypt.ToArray());
        }
        public string Decrypting(string text)
        {
            ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, IV);

            // Convierte el texto encriptado de Base64 a bytes
            byte[] textoEncriptadoBytes = Convert.FromBase64String(text);

            using MemoryStream msDecrypt = new MemoryStream(textoEncriptadoBytes);
            using CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read);
            using StreamReader srDecrypt = new StreamReader(csDecrypt);

            // Lee y devuelve el texto desencriptado
            return srDecrypt.ReadToEnd();
        }
        private static void GenerateIV()
        {
            string ss = "";
            int ssi = 0;
            dynamic r = new byte[Hex.Length / 2];
            for (int i = 0; i <= Hex.Length - 1; i += 2)
            {
                ss = Hex.Substring(i, 2);
                ssi = Convert.ToInt32(ss, 16);
                r[i / 2] = Convert.ToByte(Convert.ToInt32(Hex.Substring(i, 2), 16));
            };
            IV = r;
        }
    }
}
