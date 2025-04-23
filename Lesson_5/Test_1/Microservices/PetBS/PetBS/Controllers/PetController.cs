using System.Diagnostics;
using DAL_Core.Enums;
using Microsoft.AspNetCore.Mvc;
using PetBL.Models;
using PetBL.Services.Interfaces;

namespace PetBS.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PetController : Controller
{
    private readonly IPetService _petService;

    public PetController(IPetService petService)
    {
        _petService = petService;
    }

    [HttpGet("GetAllPets")]
    public async Task<IActionResult> GetAllPets()
    {
        var pets = await _petService.GetAllPetsAsync();

        return Ok(pets);
    }

    [HttpGet("GetPetById/{id}")]
    public async Task<IActionResult> GetPetById(Guid id)
    {
        var pet = await _petService.GetPetByIdAsync(id);
        
        if (pet == null)
        {
            return BadRequest("Pet data is null");
        }

        return Ok(pet);
    }

    [HttpPost("AddPet")]
    public async Task<IActionResult> AddPet([FromBody] PetDTO petDto)
    {
        if (petDto == null)
        {
            return BadRequest("Pet data is null");
        }

        var petId = await _petService.AddPetAsync(petDto);

        if(petId != Guid.Empty)
        {
            return Ok();
        }

        return BadRequest("Failed to add pet");
    }

    [HttpPut("UpdatePet/{id}")]
    public async Task<IActionResult> UpdatePet(Guid id, [FromBody] PetDTO petDto)
    {
        if (petDto == null)
        {
            return BadRequest("Pet data is null");
        }

        var updatedPetId = await _petService.UpdatePetAsync(id, petDto);

        if(updatedPetId != Guid.Empty)
        {
            return Ok();
        }

        return BadRequest("Failed to update pet");
    }

    [HttpGet("GetPetsByStore/{storeId}")]
    public async Task<IActionResult> GetPetsByStore(Guid storeId)
    {
        var pets = await _petService.GetPetsByStoreAsync(storeId);
        
        if (pets == null)
        {
            return NotFound();
        }

        return Ok(pets);
    }

    [HttpGet("GetPetsByType/{type}")]
    public async Task<IActionResult> GetPetsByType(PetTypes type)
    {
        var pets = await _petService.GetPetsByTypeAsync(type);

        if (pets == null)
        {
            return NotFound();
        }

        return Ok(pets);
    }

    [HttpPost("AdoptPet/{petId}/{customerId}")]
    public async Task<IActionResult> AdoptPet(Guid petId, Guid customerId)
    {
        var adoptedPetId = await _petService.AdoptPetAsync(petId, customerId);
        
        if (adoptedPetId != Guid.Empty)
        {
            return Ok();
        }

        return BadRequest("Failed to adopt pet");
    }
}
