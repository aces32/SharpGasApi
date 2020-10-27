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

namespace SharpGasData.Services
{
    public class OnboardingRepository : IOnboardingRepository, IDisposable
    {
        private SharpGasContext sharpGasContext;
        private bool disposedValue;

        public OnboardingRepository(SharpGasContext sharpGasContext)
        {
            this.sharpGasContext = sharpGasContext;
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
            return await sharpGasContext.Customers.Where(s => s.EmailAddress == login.email && s.Password == login.password).ToListAsync();
        }

        public void SignUp(Customers signUp)
        {
            sharpGasContext.Customers.Add(signUp);
        }

        public async Task<IEnumerable<Customers>> GetCustomerAsync(Guid customerID)
        {
            return await sharpGasContext.Customers.Where(x => x.CustomerId == Convert.ToInt32(customerID)).ToListAsync();
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
