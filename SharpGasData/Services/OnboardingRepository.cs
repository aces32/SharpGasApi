using Microsoft.EntityFrameworkCore.Internal;
using SharpGasCore.Models;
using SharpGasData.Entites;
using SharpGasData.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using SharpGasCore.Helpers;
using System.Data;
using Microsoft.Extensions.Options;
using SharpGas.Configuration;
using Microsoft.Extensions.Logging;

namespace SharpGasData.Services
{
    public class OnboardingRepository : IOnboardingRepository, IDisposable
    {
        private SharpGasContext sharpGasContext;
        private readonly ILogger<OnboardingRepository> logger;
        private readonly AppSettings sharpGasConn;
        private bool disposedValue;

        public OnboardingRepository(SharpGasContext sharpGasContext, IOptions<AppSettings> options,
            ILogger<OnboardingRepository> logger)
        {
            this.sharpGasContext = sharpGasContext;
            this.logger = logger;
            this.sharpGasConn = options.Value;
        }

        public async Task<int> CommitAsync()
        {
            return await sharpGasContext.SaveChangesAsync();
        }

        public async Task<bool> CustomerExistAsync(string emailAddress)
        {
            return await sharpGasContext.Customers.AnyAsync(data => data.EmailAddress == emailAddress);
        }

        public async Task<IEnumerable<Customers>> LoginAsync(LoginDto login)
        {

            try
            {
                var dbConnection = new SqlConnection(sharpGasConn.SharpGasConnectionString);

                Dictionary<string, string> paras = new Dictionary<string, string>();
                paras.Add("@Email", login.Email);
                paras.Add("@Password", login.Password);
                var returnMessage = await DapperDAO<Customers>.GetListAsync(dbConnection, paras, "Proc_LoginUser",
                CommandType.StoredProcedure);
                return returnMessage;
            }
            catch (Exception ex)
            {
                logger.LogError($"{ex}", $"Unable Login customers {nameof(LoginAsync)}");
                return null;
            }
        }

        public async Task<int?> SignUp(SignUpDto signUp)
        {
            //sharpGasContext.Customers.Add(signUp);
            try
            {
                var dbConnection = new SqlConnection(sharpGasConn.SharpGasConnectionString);

                Dictionary<string, string> paras = new Dictionary<string, string>();
                paras.Add("@email", signUp.Email.Trim());
                paras.Add("@password", signUp.Password.Trim());
                paras.Add("@firstname", signUp.Firstname.Trim());
                paras.Add("@lastname", signUp.LastName.Trim());
                paras.Add("@mobileno", signUp.MobileNumber.Trim());

                var returnMessage = await DapperDAO<int>.SetObject(dbConnection, paras, "Proc_InsertCustomers",
                                CommandType.StoredProcedure);
                return returnMessage;
            }
            catch (Exception ex)
            {
                logger.LogError($"{ex}", $"Unable to SignUp{nameof(SignUp)}");
                return null;
            }
        }

        public async Task<IEnumerable<Customers>> GetCustomerAsync(int customerID)
        {
            return await sharpGasContext.Customers.Where(x => x.CustomerId == customerID).ToListAsync();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                    if (sharpGasContext != null)
                    {
                        sharpGasContext.Dispose();
                        sharpGasContext = null;
                    }
                }

                disposedValue = true;
            }
        }


        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

    }
}
