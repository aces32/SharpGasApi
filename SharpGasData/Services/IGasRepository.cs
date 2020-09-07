using SharpGasCore.Models;
using SharpGasData.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharpGasData.Services
{
    public interface IGasRepository
    {
        bool GasAlreadyTagged(string mobileNumber);

        void UpdateGasWeight(GasRecords weight);

        void InsertGasRecord(GasInformation gas);
        GasInformation GetGasRecord(Guid gasID);
        void Commit();
    }
}
