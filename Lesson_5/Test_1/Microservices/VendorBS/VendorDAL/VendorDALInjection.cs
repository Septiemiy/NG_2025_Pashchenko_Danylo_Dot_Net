using DAL_Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendorDAL.Repositories;
using VendorDAL.Repositories.Interfaces;

namespace VendorDAL
{
    public static class VendorDALInjection
    {
        public static void AddVendorDAL(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<PetStoreDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DbConnectionString")));

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IHealthCareRepository, HealthCareRepository>();
            services.AddScoped<IVendorRepository, VendorRepository>();
        }
    }
}
