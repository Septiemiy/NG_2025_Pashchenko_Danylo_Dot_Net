using DAL_Core.Enums;
using PetBL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetBL.Services.Interfaces
{
    public interface IPetService
    {
        Task<ICollection<PetDTO>> GetAllPetsAsync();
        Task<PetDTO> GetPetByIdAsync(Guid id);
        Task<Guid> AddPetAsync(PetDTO petDto);
        Task<Guid> UpdatePetAsync(Guid id, PetDTO petDto);
        Task<ICollection<PetDTO>> GetPetsByStoreAsync(Guid storeId);
        Task<ICollection<PetDTO>> GetPetsByTypeAsync(PetTypes type);
        Task<Guid> AdoptPetAsync(Guid petId, Guid customerId);
    }
}
