using Microsoft.Extensions.DependencyInjection;
using StoreBL.Mapping;
using StoreBL.Services;
using StoreBL.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreBL
{
    public static class StoreBLLInjection
    {
        public static void AddStoreBLL(
            this IServiceCollection services)
        {
            services.AddScoped<IStoreService, StoreService>();
            
            services.AddAutoMapper(typeof(StoreMappingProfile));
        }
    }
}
