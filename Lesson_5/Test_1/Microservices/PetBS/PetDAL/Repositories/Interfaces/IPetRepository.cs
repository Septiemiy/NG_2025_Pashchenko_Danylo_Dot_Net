using DAL_Core.Entities;
using DAL_Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetDAL.Repositories.Interfaces
{
    public interface IPetRepository : IRepository<Pet>
    {
        Task<ICollection<Pet>?> GetAllPetsByPetTypeAsync(PetTypes petType);
    }
}
