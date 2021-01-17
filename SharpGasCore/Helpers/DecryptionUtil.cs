
using SharpGasCore.ConfigurationSettings;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SharpGasCore.Helpers
{
    /// <summary>
    /// Encryption Helper
    /// </summary>
    public static class DecryptionUtil
    {

        /// <summary>
        /// MD5 Encryption
        /// </summary>

        public static string RSADecrypt(string strText)
        {

            var testData = Encoding.UTF8.GetBytes(strText);

            using (var rsa = new RSACryptoServiceProvider(1024))
            {
                try
                {
                    var base64Encrypted = strText;

                    // server decrypting data with private key                    
                    rsa.FromXmlString(StaticConfiguration.PRIVATEXML);

                    var resultBytes = Convert.FromBase64String(base64Encrypted);
                    if (resultBytes.Length < rsa.KeySize / 8)
                    {
                        byte[] tmp = new byte[rsa.KeySize / 8];
                        Buffer.BlockCopy(resultBytes, 0, tmp, tmp.Length - resultBytes.Length, resultBytes.Length);
                        resultBytes = tmp;
                    }
                    var decryptedBytes = rsa.Decrypt(resultBytes, false);

                    var decryptedData = Encoding.UTF8.GetString(decryptedBytes);
                    return decryptedData.ToString();
                }
                catch (Exception ex)
                {
                    throw ex;
                    
                }
                finally
                {
                    rsa.PersistKeyInCsp = false;

                }
            }


        }


        //public static string GetDecryptionPrivateKey(string channel)
        //{
        //    try
        //    {
        //        var conn = new SqlConnection(StaticConfiguration.EoneConnectionString);

        //        DynamicParameters parameters = new DynamicParameters();
        //        parameters.Add("@channel", channel);

        //        var privateKey = SqlMapper.Query<string>(conn, "dbo.GetPrivateKeyToDecrypt", parameters,
        //            commandType: CommandType.StoredProcedure);
        //        return privateKey.FirstOrDefault();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }

        //}
    }
}
