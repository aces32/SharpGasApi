using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using SharpGas.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SharpGasCore.MidddleWare
{
    public class EncryptionMiddleWare
    {
        private readonly RequestDelegate _next;

        public AppSettings appsettings { get; }

        public EncryptionMiddleWare(RequestDelegate next,
            IOptions<AppSettings> options)
        {
            _next = next;
            appsettings = options.Value;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            var status = string.Empty;
            (httpContext.Request.Body, status) = await Decryption(httpContext.Request.Body);

            if (httpContext.Request.QueryString.HasValue)
            {
                string decryptedString = Decryption(httpContext.Request.QueryString.Value.Substring(1));
                httpContext.Request.QueryString = new QueryString($"?{decryptedString}");
            }
            await _next(httpContext);
            if (httpContext.Request.Body != null)
            {
                await httpContext.Request.Body.DisposeAsync();
            }

        }

        private static Stream DecryptStream(Stream cipherStream)
        {
            Aes aes = GetEncryptionAlgorithm();

            FromBase64Transform base64Transform = new FromBase64Transform(FromBase64TransformMode.IgnoreWhiteSpaces);
            CryptoStream base64DecodedStream = new CryptoStream(cipherStream, base64Transform, CryptoStreamMode.Read);
            ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
            CryptoStream decryptedStream = new CryptoStream(base64DecodedStream, decryptor, CryptoStreamMode.Read);
            return decryptedStream;
        }

        public async Task<(Stream, string)> Decryption(Stream strText)
        {
            StreamReader reader = new StreamReader(strText);
            string text = await reader.ReadToEndAsync();
            if (!string.IsNullOrEmpty(text))
            {
                var testData = Encoding.UTF8.GetBytes(text);

                using (var rsa = new RSACryptoServiceProvider(1024))
                {
                    try
                    {
                        var base64Encrypted = text;

                        // server decrypting data with private key                    
                        rsa.FromXmlString(appsettings.PRIVATEXML);

                        var resultBytes = Convert.FromBase64String(base64Encrypted);
                        var decryptedBytes = rsa.Decrypt(resultBytes, true);
                        var decryptedData = Encoding.UTF8.GetString(decryptedBytes);
                        byte[] byteArray = Encoding.ASCII.GetBytes(decryptedData.ToString());
                        MemoryStream stream = new MemoryStream(byteArray);
                        return (stream, "Success");
                    }
                    catch (Exception ex)
                    {
                        return (strText, "Exception");
                    }
                    finally
                    {
                        rsa.PersistKeyInCsp = false;
                    }
                }
            }
            else
            {
                return (strText, "No Data Passed");
            }

        }

        public string Decryption(string strText)
        {
            if (!string.IsNullOrEmpty(strText))
            {
                var testData = Encoding.UTF8.GetBytes(strText);

                using (var rsa = new RSACryptoServiceProvider(1024))
                {
                    try
                    {
                        var base64Encrypted = strText;

                        // server decrypting data with private key                    
                        rsa.FromXmlString(appsettings.PRIVATEXML);

                        var resultBytes = Convert.FromBase64String(base64Encrypted);
                        var decryptedBytes = rsa.Decrypt(resultBytes, true);
                        var decryptedData = Encoding.UTF8.GetString(decryptedBytes);
                        return decryptedData.ToString();
                    }
                    catch (Exception)
                    {
                        return strText;
                    }
                    finally
                    {
                        rsa.PersistKeyInCsp = false;

                    }
                }
            }
            else
            {
                return strText;
            }

        }

        private static string DecryptString(string cipherText)
        {
            Aes aes = GetEncryptionAlgorithm();
            byte[] buffer = Convert.FromBase64String(cipherText);

            using MemoryStream memoryStream = new MemoryStream(buffer);
            using ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
            using CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
            using StreamReader streamReader = new StreamReader(cryptoStream);
            return streamReader.ReadToEnd();
        }

        private static Aes GetEncryptionAlgorithm()
        {
            Aes aes = Aes.Create();
            //aes.Key = secret_key;
            aes.Key = null;
            //aes.IV = initialization_vector;
            aes.IV = null;

            return aes;
        }
    }
}
