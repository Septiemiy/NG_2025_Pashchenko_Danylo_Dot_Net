using DAL_Core;
using DAL_Core.Entities;
using DAL_Core.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendorDAL.Repositories.Interfaces;

namespace VendorDAL.Repositories
{
    public class VendorRepository : Repository<Vendor>, IVendorRepository
    {
        public readonly PetStoreDbContext _ctx;
        
        public VendorRepository(PetStoreDbContext ctx) : base(ctx)
        {
            _ctx = ctx;
        }
        
        public async Task<Vendor?> GetVendorWithHealthCareRecords(Guid vendorId)
        {
            return await _ctx.Vendors
                .Include(v => v.HealthCares)
                .FirstOrDefaultAsync(v => v.Id == vendorId);
        }
        
        public async Task<ICollection<Vendor>?> GetVendorsByContractType(ContractType contractType)
        {
            return await _ctx.Vendors
                .Where(v => v.ContractType == contractType)
                .ToListAsync();
        }
    }
}
