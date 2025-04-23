using SentinelBusinessLayer.Clients;
using SentinelBusinessLayer.Enums;
using SentinelBusinessLayer.Models;
using SentinelBusinessLayer.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SentinelBusinessLayer.Service
{
    public class PetService : IPetService
    {
        private readonly IPetClient _petClient;

        public PetService(IPetClient petClient)
        {
            _petClient = petClient;
        }

        public async Task<List<PetDto>> GetAllPets()
        {
            return await _petClient.GetAllPets();
        }

        public async Task<PetDto> GetPetById(Guid id)
        {
            return await _petClient.GetPetById(id);
        }

        public async Task<Guid> AddPet(PetDto petDto)
        {
            return await _petClient.AddPet(petDto);
        }

        public async Task<Guid> UpdatePet(Guid id, PetDto petDto)
        {
            return await _petClient.UpdatePet(id, petDto);
        }

        public async Task<List<PetDto>> GetPetsByStore(Guid storeId)
        {
            return await _petClient.GetPetsByStore(storeId);
        }

        public async Task<List<PetDto>> GetPetsByType(PetTypes type)
        {
            return await _petClient.GetPetsByType(type);
        }

        public async Task<Guid> AdoptPet(Guid petId, Guid customerId)
        {
            return await _petClient.AdoptPet(petId, customerId);
        }
    }
}
