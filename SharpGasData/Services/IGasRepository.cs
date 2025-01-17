﻿using SharpGasCore.Models;
using SharpGasData.Entites;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SharpGasData.Services
{
    public interface IGasRepository
    {
        bool GasAlreadyTagged(string mobileNumber);

        void UpdateGasWeight(GasRecords weight);

        void InsertGasRecord(GasInformation gas);
        Task<List<GasInformation>> GetGasRecord(int gasID);
        Task<int> Commit();
    }
}
