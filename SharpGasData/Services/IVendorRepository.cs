using SharpGasCore.Models;
using SharpGasData.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SharpGasData.Services
{
    public interface IVendorRepository
    {
        Task<IEnumerable<Vendors>> GetAllVendors();
        Task<IEnumerable<Vendors>> GetAllVendorsByCountryLocation(string country, string state, string lga);
    }
}
