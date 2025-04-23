using SentinelBusinessLayer.Enums;
using SentinelBusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SentinelBusinessLayer.Service.Interface
{
    public interface IPetService
    {
        Task<List<PetDto>> GetAllPets();
        Task<PetDto> GetPetById(Guid id);
        Task<Guid> AddPet(PetDto petDto);
        Task<Guid> UpdatePet(Guid id, PetDto petDto);
        Task<List<PetDto>> GetPetsByStore(Guid storeId);
        Task<List<PetDto>> GetPetsByType(PetTypes type);
        Task<Guid> AdoptPet(Guid petId, Guid customerId);
    }
}
