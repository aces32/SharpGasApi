using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SharpGas.Configuration;
using SharpGas.Encryption;
using SharpGasCore.Helpers;
using SharpGasCore.Models;
using SharpGasData.Entities;
using SharpGasData.Migrations;
using SharpGasData.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace SharpGasData.Services
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private SharpGasContext sharpGasContext;
        private readonly ILogger<AuthenticationRepository> logger;
        private readonly AppSettings sharpGasConn;

        public AuthenticationRepository(SharpGasContext sharpGasContext, IOptions<AppSettings> options,
            ILogger<AuthenticationRepository> logger)
        {
            this.sharpGasContext = sharpGasContext;
            this.logger = logger;
            this.sharpGasConn = options.Value;
        }

        public async Task<IEnumerable<AuthCredentials>> AuthenticateAsync(UserCredentials userCredentials)
        {

            try
            {
                var dbConnection = new SqlConnection(sharpGasConn.SharpGasConnectionString);

                Dictionary<string, string> paras = new Dictionary<string, string>();
                paras.Add("@username", userCredentials.Username);
                paras.Add("@Password", userCredentials.Password);
                var returnMessage = await DapperDAO<AuthCredentials>.GetListAsync(dbConnection, paras, "Proc_AuthenticateApiUser",
                CommandType.StoredProcedure);
                return returnMessage;
            }
            catch (Exception ex)
            {
                logger.LogError($"{ex}", $"Unable Authenticate Admin {nameof(AuthenticateAsync)}");
                return null;
            }
        }
    }
}
