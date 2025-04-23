using AutoMapper;
using DAL_Core.Entities;
using HealthCareBL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCareBL.Mapping
{
    public class HealthCareMappingProfile : Profile
    {
        public HealthCareMappingProfile() 
        {
            CreateMap<HealthCareDTO, HealthCare>()
                .ReverseMap();
        }
    }
}
