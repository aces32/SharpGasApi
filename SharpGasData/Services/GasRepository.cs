using Microsoft.EntityFrameworkCore.Internal;
using SharpGasData.Entites;
using SharpGasData.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using SharpGasCore.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SharpGasData.Services
{
    public class GasRepository : IGasRepository, IDisposable
    {
        private readonly SharpGasContext sharpGasContext;

        public GasRepository(SharpGasContext sharpGasContext)
        {
            this.sharpGasContext = sharpGasContext;
        }
        public bool GasAlreadyTagged(string mobileNumber)
        {
            return sharpGasContext.GasInformation.Any(x => x.GasMobileNumber == mobileNumber);
        }

        public void InsertGasRecord(GasInformation gas)
        {
            sharpGasContext.GasInformation.Add(gas);
        }

        public void UpdateGasWeight(GasRecords records)
        {
            sharpGasContext.GasInformation.Where(x => x.GasMobileNumber == records.GasMobileNumber).FirstOrDefault().GasWeight = records.GasWeight;
        }
        public async Task<int> Commit()
        {
            return await sharpGasContext.SaveChangesAsync();
        }

        public async Task<List<GasInformation>> GetGasRecord(int gasID)
        {
            return await sharpGasContext.GasInformation.Where(x => x.GasId == gasID).ToListAsync();
        }

        public void Dispose()
        {
            ((IDisposable)sharpGasContext).Dispose();
        }
    }
}
