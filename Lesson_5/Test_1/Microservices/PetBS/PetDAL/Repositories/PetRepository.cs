using DAL_Core;
using DAL_Core.Entities;
using DAL_Core.Enums;
using Microsoft.EntityFrameworkCore;
using PetDAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetDAL.Repositories
{
    public class PetRepository : Repository<Pet>, IPetRepository
    {
        private readonly PetStoreDbContext _ctx;
        public PetRepository(PetStoreDbContext ctx) : base(ctx)
        {
            _ctx = ctx;
        }

        public async Task<ICollection<Pet>?> GetAllPetsByPetTypeAsync(PetTypes petType)
        {
            return await _ctx.Pets
                .Where(p => p.Type == petType)
                .ToListAsync();
        }
    }
}
