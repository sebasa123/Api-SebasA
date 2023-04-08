using System.Security.Cryptography;
using System.Text;

namespace Api_SebasA.Tools
{
    public class Crypto
    {
        string LlavePersonalizada = "APPadgaafagadgasfhjajhset3525432TEMP";
        public string DesEncriptarPassword(string Pass)
        {
            String R = string.Empty;
            using (TripleDESCryptoServiceProvider tripleDESCryptoService = new TripleDESCryptoServiceProvider())
            {
                using (MD5CryptoServiceProvider hashMD5Provider = new MD5CryptoServiceProvider())
                {
                    Byte[] byteHash = hashMD5Provider.ComputeHash(Encoding.UTF8.GetBytes(LlavePersonalizada));
                    tripleDESCryptoService.Key = byteHash;
                    tripleDESCryptoService.Mode = CipherMode.ECB;
                    Byte[] data = Convert.FromBase64String(Pass);
                    R = Encoding.UTF8.GetString(tripleDESCryptoService.CreateDecryptor().
                        TransformFinalBlock(data, 0, data.Length));
                }
            }
            return R;
        }
        public string EncriptarPassword(string Pass)
        {
            String R = string.Empty;
            using (TripleDESCryptoServiceProvider tripleDESCryptoService = new TripleDESCryptoServiceProvider())
            {
                using (MD5CryptoServiceProvider hashMD5Provider = new MD5CryptoServiceProvider())
                {
                    Byte[] byteHash = hashMD5Provider.ComputeHash(Encoding.UTF8.GetBytes(LlavePersonalizada));
                    tripleDESCryptoService.Key = byteHash;
                    tripleDESCryptoService.Mode = CipherMode.ECB;
                    Byte[] data = Encoding.UTF8.GetBytes(Pass);
                    R = Convert.ToBase64String(tripleDESCryptoService.CreateEncryptor().
                        TransformFinalBlock(data, 0, data.Length));
                }
            }
            return R;
        }
        public string EncriptarEnUnSentido(string Entrada)
        {
            string PorEncriptar = EncriptarPassword(Entrada);
            PorEncriptar += "PalabraClave";
            SHA256CryptoServiceProvider ProveedorCrypto = new SHA256CryptoServiceProvider();
            byte[] BytesDeEntrada = Encoding.UTF8.GetBytes(PorEncriptar);
            byte[] BytesConHash = ProveedorCrypto.ComputeHash(BytesDeEntrada);
            StringBuilder Resultado = new StringBuilder();
            for (int i = 0; i < BytesConHash.Length; i++)
                Resultado.Append(BytesConHash[i].ToString("x2").ToLower());
            return Resultado.ToString();
        }
    }
}
