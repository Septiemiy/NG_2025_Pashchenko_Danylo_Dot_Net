using DAL_Core;
using DAL_Core.Entities;
using Microsoft.EntityFrameworkCore;
using PetDAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetDAL.Repositories
{
    public class StoreRepository : Repository<Store>, IStoreRepository
    {
        private readonly PetStoreDbContext _ctx;
        public StoreRepository(PetStoreDbContext ctx) : base(ctx)
        {
            _ctx = ctx;
        }

        public async Task<Store?> GetStoreWithPetsAsync(Guid Id)
        {
            return await _ctx.Stores
                .Include(s => s.Pets)
                .FirstOrDefaultAsync(x => x.Id == Id);
        }
    }
}
