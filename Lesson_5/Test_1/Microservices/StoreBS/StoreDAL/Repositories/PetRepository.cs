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
    public class PetRepository : Repository<Pet>, IPetRepository
    {
        private readonly PetStoreDbContext _ctx;
        public PetRepository(PetStoreDbContext ctx) : base(ctx)
        {
            _ctx = ctx;
        }

        public async Task<ICollection<Pet>> GetAllByStoreIdAsync(Guid storeId)
        {
            return await _ctx.Pets
                .Where(p => p.StoreId == storeId)
                .ToListAsync();
        }
    }
}
