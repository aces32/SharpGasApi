using SharpGasCore.Models;
using SharpGasData.Entites;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SharpGasData.Services
{
    public interface IOnboardingRepository
    {
        Task<int?> SignUp(SignUpDto signUp);
        Task<bool> CustomerExistAsync(string emailAddress);
        Task<IEnumerable<Customers>> LoginAsync(LoginDto login);
        Task<IEnumerable<Customers>> GetCustomerAsync(int customerID);
        Task<int> CommitAsync();

    }
}
