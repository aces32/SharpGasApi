using AutoMapper;
using SharpGasCore.Models;
using SharpGasData.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharpGasData.Profiles
{
    public class GasProfiles : Profile
    {
        public GasProfiles()
        {
            CreateMap<GasRecords, GasInformation>();
            CreateMap<GasInformation, GasResponseDto>();
        }
    }
}
