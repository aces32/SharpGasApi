using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using SharpGasCore.Models;
using SharpGasData.Entites;

namespace SharpGasCore.Profiles
{
    public class OnboardingProfile : Profile
    {
        public OnboardingProfile()
        {
            CreateMap<Customers, LoginResponseDto>();
            CreateMap<SignUpDto, SignUpResponseDto>();
            CreateMap<SignUpDto, Customers>().ForMember(
                                dest => dest.EmailAddress, 
                                opt => opt.MapFrom(src => src.Email));
        }

    }
}
