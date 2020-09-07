using Microsoft.EntityFrameworkCore.Internal;
using SharpGasCore.Models;
using SharpGasData.Entites;
using SharpGasData.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SharpGasData.Services
{
    public class OnboardingRepository : IOnboardingRepository
    {
        private readonly SharpGasContext sharpGasContext;

        public OnboardingRepository(SharpGasContext sharpGasContext)
        {
            this.sharpGasContext = sharpGasContext;
        }

        public int Commit()
        {
            return sharpGasContext.SaveChanges();
        }

        public bool CustomerExist(string emailAddress)
        {
            return sharpGasContext.Customers.Any(data => data.EmailAddress == emailAddress);
        }

        public IEnumerable<Customers> Login(LoginDto login)
        {
            return sharpGasContext.Customers.Where(s => s.EmailAddress == login.email && s.Password == login.password);
        }

        public void SignUp(Customers signUp)
        {
            sharpGasContext.Customers.Add(signUp);
        }

        public Customers GetCustomer(Guid customerID)
        {
            return sharpGasContext.Customers.Where(x => x.CustomerId == Convert.ToInt32(customerID)).FirstOrDefault();
        }
    }
}
