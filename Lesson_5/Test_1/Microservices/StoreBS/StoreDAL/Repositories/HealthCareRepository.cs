using DAL_Core;
using DAL_Core.Entities;
using Microsoft.EntityFrameworkCore;
using StoreDAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreDAL.Repositories
{
    public class HealthCareRepository : Repository<HealthCare>, IHealthCareRepository
    {
        private readonly PetStoreDbContext _ctx;
        public HealthCareRepository(PetStoreDbContext ctx) : base(ctx)
        {
            _ctx = ctx;
        }

        public async Task<ICollection<HealthCare>> GetAllByStoreIdAsync(Guid storeId)
        {
            return await _ctx.HealthCares
                .Where(h => h.StoreId == storeId)
                .ToListAsync();
        }
    }   
}
