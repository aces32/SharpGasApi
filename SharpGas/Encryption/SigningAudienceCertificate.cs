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
    public class SigningAudienceCertificate
    {
        private readonly AppSettings appSettings;
        public SigningAudienceCertificate(IOptions<AppSettings> options)
        {
            appSettings = options.Value;
        }

        public SigningCredentials GetAudienceSigningKey()
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            string privateXmlKey = appSettings.PRIVATEXML;
            rsa.FromXmlString(privateXmlKey);

            return new SigningCredentials(
                key: new RsaSecurityKey(rsa),
                algorithm: SecurityAlgorithms.RsaSha256);
        }
    }
}
