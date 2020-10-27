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

        public string GetToken()
        {
            SecurityTokenDescriptor tokenDescriptor = GetTokenDescriptor();
            var tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken securityToken = tokenHandler.CreateToken(tokenDescriptor);
            string token = tokenHandler.WriteToken(securityToken);

            return token;
        }

        private SecurityTokenDescriptor GetTokenDescriptor()
        {
            const int expiringDays = 7;

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Expires = DateTime.UtcNow.AddDays(expiringDays),
                SigningCredentials = signingAudienceCertificate.GetAudienceSigningKey()
            };

            return tokenDescriptor;
        }
    }
}
