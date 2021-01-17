using Microsoft.VisualStudio.Services.WebApi.Jwt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharpGas.Encryption
{
    /// <summary>
    /// Used for authenticate usesers before generating token
    /// </summary>
    public class UserService
    {
        private readonly IEnumerable<UserCredentials> users;

        /// <summary>
        /// UserCredentials credentials
        /// </summary>
        public UserService()
        {
            users = new List<UserCredentials>
            {
                new UserCredentials
                {
                    Username = "john.doe",
                    Password = "john.password"
                }
            };
        }

        /// <summary>
        /// Validate users credentials
        /// </summary>
        /// <param name="userCredentials"></param>
        public void ValidateCredentials(UserCredentials userCredentials)
        {
            bool isValid =
                users.Any(u =>
                    u.Username == userCredentials.Username &&
                    u.Password == userCredentials.Password);

            if (!isValid)
            {
                throw new InvalidCredentialsException("invalid Credentials");
            }
        }
    }
}
