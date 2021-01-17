using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SharpGas.Configuration;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace SharpGas.Encryption
{
    public class TokenServiceAssyMetric
    {
        private readonly SigningAudienceCertificate signingAudienceCertificate;

        public TokenServiceAssyMetric(IOptions<AppSettings> options)
        {
            signingAudienceCertificate = new SigningAudienceCertificate(options);
        }

        public (string, DateTime?) GetToken(int expiryPeriod)
        {
            SecurityTokenDescriptor tokenDescriptor = GetTokenDescriptor(expiryPeriod);
            var tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken securityToken = tokenHandler.CreateToken(tokenDescriptor);
            string token = tokenHandler.WriteToken(securityToken);

            return (token, tokenDescriptor.Expires);
        }

        private SecurityTokenDescriptor GetTokenDescriptor(int expiryPeriod)
        {
            int expiringHrs = expiryPeriod + 1;

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Expires = DateTime.UtcNow.AddHours(expiringHrs),
                SigningCredentials = signingAudienceCertificate.GetAudienceSigningKey()
            };

            return tokenDescriptor;
        }
    }
}
