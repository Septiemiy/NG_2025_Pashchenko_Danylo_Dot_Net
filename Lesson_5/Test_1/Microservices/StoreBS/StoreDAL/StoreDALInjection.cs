using DAL_Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StoreDAL.Repositories;
using StoreDAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreDAL
{
    public static class StoreDALInjection
    {
        public static void AddStoreDAL(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<PetStoreDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DbConnectionString")));

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IPetRepository, PetRepository>();
            services.AddScoped<IHealthCareRepository, HealthCareRepository>();
            services.AddScoped<IStoreRepository, StoreRepository>();
        }
    }
}
