using DAL_Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PetDAL.Repositories;
using PetDAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetDAL
{
    public static class PetDALInjection
    {
        public static void AddPetDAL(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<PetStoreDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DbConnectionString"));
            });

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IHealthCareRepository, HealthCareRepository>();
            services.AddScoped<IStoreRepository, StoreRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IPetRepository, PetRepository>();
        }
    }
}
