using AutoMapper;
using DAL_Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendorBL.Models;

namespace VendorBL.Mappings
{
    public class VendorMappingProfile : Profile
    {
        public VendorMappingProfile() 
        {
            CreateMap<HealthCare, HealthCareDTO>()
                .ReverseMap();

            CreateMap<Vendor, VendorDTO>()
                .ReverseMap();
        }
    }
}
