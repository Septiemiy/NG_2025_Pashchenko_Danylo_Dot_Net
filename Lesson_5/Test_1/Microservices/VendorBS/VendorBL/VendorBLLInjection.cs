using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendorBL.Mappings;
using VendorBL.Services;
using VendorBL.Services.Interfaces;

namespace VendorBL
{
    public static class VendorBLLInjection
    {
        public static void AddVendorBLL(
            this IServiceCollection services)
        {
            services.AddScoped<IVendorService, VendorService>();
            
            services.AddAutoMapper(typeof(VendorMappingProfile));
        }
    }
}
