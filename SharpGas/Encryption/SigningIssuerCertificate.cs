using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SharpGas.Configuration;
using SharpGasData.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace SharpGas.Encryption
{
    public class SigningIssuerCertificate
    {
        public RsaSecurityKey GetIssuerSigningKey(string privateXML)
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();

            string publicXmlKey = privateXML;
            rsa.FromXmlString(publicXmlKey);

            return new RsaSecurityKey(rsa);
        }
    }
}
