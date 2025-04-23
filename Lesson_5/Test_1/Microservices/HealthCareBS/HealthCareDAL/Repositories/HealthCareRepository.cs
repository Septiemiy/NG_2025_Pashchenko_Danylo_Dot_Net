using DAL_Core;
using DAL_Core.Entities;
using HealthCareDAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCareDAL.Repositories
{
    public class HealthCareRepository : Repository<HealthCare>, IHealthCareRepository
    {
        private readonly PetStoreDbContext _ctx;

        public HealthCareRepository(PetStoreDbContext ctx) : base(ctx)
        {
            _ctx = ctx;
        }

        public async Task<ICollection<HealthCare>> GetExpiringHealthCareRecordsAsync()
        {
            var expiringHealthCareRecords = await _ctx.HealthCares
                .Where(h => h.ExpirationDate <= DateTime.Now)
                .ToListAsync();
            
            return expiringHealthCareRecords;
        }
    }
}
