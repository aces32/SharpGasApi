using SharpGas.Encryption;
using SharpGasData.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SharpGasData.Services
{
    public interface IAuthenticationRepository
    {
        Task<IEnumerable<AuthCredentials>> AuthenticateAsync(UserCredentials userCredentials);
    }
}
