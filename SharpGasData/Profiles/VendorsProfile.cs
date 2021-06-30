using AutoMapper;
using SharpGasCore.Models;
using SharpGasData.Entites;
using SharpGasData.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharpGasData.Profiles
{
    public class VendorsProfile : Profile
    {
        public VendorsProfile()
        {
            CreateMap<Vendors, VendorsResponseDto>();
        }
    }
}
