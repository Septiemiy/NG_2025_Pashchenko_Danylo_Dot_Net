using SentinelBusinessLayer.Enums;
using Refit;
using SentinelBusinessLayer.Enums;
using SentinelBusinessLayer.Models;

namespace SentinelBusinessLayer.Clients
{
    public interface IPetClient
    {
        [Get("/api/pet/GetAllPets")]
        Task<List<PetDto>> GetAllPets();

        [Get("/api/pet/GetPetById/{id}")]
        Task<PetDto> GetPetById(Guid id);

        [Post("/api/pet/AddPet")]
        Task<Guid> AddPet([Body] PetDto petDto);

        [Put("/api/pet/UpdatePet/{id}")]
        Task<Guid> UpdatePet(Guid id, [Body] PetDto petDto);

        [Get("/api/pet/GetPetsByStore/{storeId}")]
        Task<List<PetDto>> GetPetsByStore(Guid storeId);

        [Get("/api/pet/GetPetsByType/{type}")]
        Task<List<PetDto>> GetPetsByType(PetTypes type);

        [Post("/api/pet/AdoptPet/{petId}/{customerId}")]
        Task<Guid> AdoptPet(Guid petId, Guid customerId);
    }
}
