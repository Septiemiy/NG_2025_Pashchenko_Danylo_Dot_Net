using DAL_Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetDAL.Repositories.Interfaces
{
    public interface IStoreRepository : IRepository<Store>
    {
        Task<Store?> GetStoreWithPetsAsync(Guid Id);
    }
}
