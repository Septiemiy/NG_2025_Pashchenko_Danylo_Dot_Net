using DAL_Core;
using HealthCareDAL.Repositories;
using HealthCareDAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCareDAL
{
    public static class HealthCareDALInjection
    {
        public static void AddHealthCareDAL(
            this IServiceCollection service,
            IConfiguration configuration)
        {
            service.AddDbContext<PetStoreDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DbConnectionString")));

            service.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            service.AddScoped<IHealthCareRepository, HealthCareRepository>();
            service.AddScoped<IPetRepository, PetRepository>();
            service.AddScoped<IStoreRepository, StoreRepository>();
            service.AddScoped<IVendorRepository, VendorRepository>();
        }
    }
}
