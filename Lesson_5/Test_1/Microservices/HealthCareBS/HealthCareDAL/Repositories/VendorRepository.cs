using DAL_Core;
using DAL_Core.Entities;
using HealthCareDAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCareDAL.Repositories
{
    public class VendorRepository : Repository<Vendor>, IVendorRepository
    {
        private readonly PetStoreDbContext _ctx;

        public VendorRepository(PetStoreDbContext ctx) : base(ctx)
        {
            _ctx = ctx;
        }
    }
}
