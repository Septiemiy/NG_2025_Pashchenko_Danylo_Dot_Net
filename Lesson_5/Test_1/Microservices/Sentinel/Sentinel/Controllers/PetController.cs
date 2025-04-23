using Microsoft.AspNetCore.Mvc;
using SentinelBusinessLayer.Clients;
using SentinelBusinessLayer.Models;
using SentinelBusinessLayer.Enums;

namespace Sentinel.Controllers
{
    [Route("api/[controller]")]
    [Controller]
    public class PetController : ControllerBase
    {
        private readonly IPetClient _petClient;

        public PetController(IPetClient petClient)
        {
            _petClient = petClient;
        }

        [HttpGet("GetAllPets")]
        public async Task<IActionResult> GetAllPets()
        {
            var pets = await _petClient.GetAllPets();
            
            return Ok(pets);
        }

        [HttpGet("GetPetById/{id}")]
        public async Task<IActionResult> GetPetById(Guid id)
        {
            var pet = await _petClient.GetPetById(id);

            return Ok(pet);
        }

        [HttpPost("AddPet")]
        public async Task<IActionResult> AddPet([FromBody] PetDto petDto)
        {
            var petId = await _petClient.AddPet(petDto);
            
            return Ok(petId);
        }

        [HttpPut("UpdatePet/{id}")]
        public async Task<IActionResult> UpdatePet(Guid id, [FromBody] PetDto petDto)
        {
            var petId = await _petClient.UpdatePet(id, petDto);

            return Ok(petId);
        }

        [HttpGet("GetPetsByStore/{storeId}")]
        public async Task<IActionResult> GetPetsByStore(Guid storeId)
        {
            var pets = await _petClient.GetPetsByStore(storeId);
            
            return Ok(pets);
        }

        [HttpGet("GetPetsByType/{type}")]
        public async Task<IActionResult> GetPetsByType(PetTypes type)
        {
            var pets = await _petClient.GetPetsByType(type);

            return Ok(pets);
        }

        [HttpPost("AdoptPet/{petId}/{customerId}")]
        public async Task<IActionResult> AdoptPet(Guid petId, Guid customerId)
        {
            var adoptionId = await _petClient.AdoptPet(petId, customerId);
            
            return Ok(adoptionId);
        }
    }
}
