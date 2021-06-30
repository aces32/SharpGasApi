using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SharpGasCore.Models;
using SharpGasData.Entities;
using SharpGasData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpGasData.Services
{
    public class VendorRepository : IVendorRepository
    {
        private readonly SharpGasContext sharpGasContext;
        private readonly ILogger<OnboardingRepository> logger;

        public VendorRepository(SharpGasContext sharpGasContext,
            ILogger<OnboardingRepository> logger)
        {
            this.sharpGasContext = sharpGasContext;
            this.logger = logger;
        }
        public async Task<IEnumerable<Vendors>> GetAllVendors()
        {
            try
            {
                return await sharpGasContext.Vendors.Where(x => x.Active == true).ToListAsync();
            }
            catch (Exception ex)
            {
                logger.LogError($"{ex}", $"Unable Get all active Vendors {nameof(GetAllVendors)}");
                return null;
            }

        }

        public async Task<IEnumerable<Vendors>> GetAllVendorsByCountryLocation(string country, string state, string lga)
        {
            try
            {
                if (true)
                {

                }
                return await sharpGasContext.Vendors.Where(x => x.Active == true).ToListAsync();
            }
            catch (Exception ex)
            {
                logger.LogError($"{ex}", $"Unable Get all active Vendors {nameof(GetAllVendors)}");
                return null;
            }
        }
    }  
}
