using HealthCareBL.Mapping;
using HealthCareBL.Services;
using HealthCareBL.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCareBL
{
    public static class HealthCareBLLInjection
    {
        public static void AddHealthCareBLL(
            this IServiceCollection service)
        {
            service.AddScoped<IHealthCareService, HealthCareService>();

            service.AddAutoMapper(typeof(HealthCareMappingProfile));
        }
    }
}
