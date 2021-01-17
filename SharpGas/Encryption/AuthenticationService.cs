using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharpGas.Encryption
{
    public class AuthenticationService
    {
        private readonly UserService userService;
        private readonly TokenServiceAssyMetric tokenService;

        public AuthenticationService(UserService userService,
            TokenServiceAssyMetric tokenService)
        {
            this.userService = userService;
            this.tokenService = tokenService;
        }

        public (string, DateTime?) Authenticate(int expiryPeriod)
        {
            //userService.ValidateCredentials(userCredentials);
            var (securityToken, expiryTime)= tokenService.GetToken(expiryPeriod);

            return (securityToken, expiryTime);
        }
    }
}
