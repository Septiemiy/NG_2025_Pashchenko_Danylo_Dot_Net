using DAL_Core;
using DAL_Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendorDAL.Repositories.Interfaces;

namespace VendorDAL.Repositories
{
    public class HealthCareRepository : Repository<HealthCare>, IHealthCareRepository
    {
        public readonly PetStoreDbContext _ctx;
        public HealthCareRepository(PetStoreDbContext ctx) : base(ctx)
        {
            _ctx = ctx;
        }
    }
}
