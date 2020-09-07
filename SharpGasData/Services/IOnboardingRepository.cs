using SharpGasCore.Models;
using SharpGasData.Entites;
using System;
using System.Collections.Generic;

namespace SharpGasData.Services
{
    public interface IOnboardingRepository
    {
        void SignUp(Customers signUp);
        bool CustomerExist(string emailAddress);
        IEnumerable<Customers> Login(LoginDto login);
        Customers GetCustomer(Guid customerID);
        int Commit();

    }
}
