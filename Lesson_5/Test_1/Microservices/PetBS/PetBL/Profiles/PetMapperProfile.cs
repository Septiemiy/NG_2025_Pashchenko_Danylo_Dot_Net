using AutoMapper;
using DAL_Core.Entities;
using PetBL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetBL.Profiles
{
    public class PetMapperProfile : Profile
    {
        public PetMapperProfile() 
        {
            CreateMap<Pet, PetDTO>()
                .ReverseMap();
        }
    }
}
