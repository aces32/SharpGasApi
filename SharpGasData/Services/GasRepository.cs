﻿using Microsoft.EntityFrameworkCore.Internal;
using SharpGasData.Entites;
using SharpGasData.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using SharpGasCore.Models;

namespace SharpGasData.Services
{
    public class GasRepository : IGasRepository
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
        public void Commit()
        {
            sharpGasContext.SaveChanges();
        }

        public GasInformation GetGasRecord(Guid gasID)
        {
            return sharpGasContext.GasInformation.Where(x => x.GasId == Convert.ToInt32(gasID)).FirstOrDefault();
        }
    }
}
