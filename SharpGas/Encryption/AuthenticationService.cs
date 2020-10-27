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

        public string Authenticate(UserCredentials userCredentials)
        {
            userService.ValidateCredentials(userCredentials);
            string securityToken = tokenService.GetToken();

            return securityToken;
        }
    }
}
