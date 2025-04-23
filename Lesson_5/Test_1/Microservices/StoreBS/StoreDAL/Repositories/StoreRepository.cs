using DAL_Core;
using DAL_Core.Entities;
using StoreDAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreDAL.Repositories
{
    public class StoreRepository : Repository<Store>, IStoreRepository
    {
        private readonly PetStoreDbContext _ctx;

        public StoreRepository(PetStoreDbContext ctx) : base(ctx)
        {
            _ctx = ctx;
        }
    }
}
