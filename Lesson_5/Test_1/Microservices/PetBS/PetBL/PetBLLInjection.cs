using Microsoft.Extensions.DependencyInjection;
using PetBL.Profiles;
using PetBL.Services;
using PetBL.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PetBL
{
    public static class PetBLLInjection
    {
        public static void AddPetBLL(
            this IServiceCollection services)
        {
            services.AddScoped<IPetService, PetService>();

            services.AddAutoMapper(typeof(PetMapperProfile));
        }
    }
}
