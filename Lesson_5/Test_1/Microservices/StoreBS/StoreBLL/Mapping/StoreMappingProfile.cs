using AutoMapper;
using DAL_Core.Entities;
using StoreBL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreBL.Mapping
{
    public class StoreMappingProfile : Profile
    {
        public StoreMappingProfile() 
        {
            CreateMap<Store, StoreDTO>()
                .ReverseMap();

            CreateMap<Pet, PetDTO>()
                .ReverseMap();

            CreateMap<HealthCare, HealthCareDTO>()
                .ReverseMap();
        }
    }
}
