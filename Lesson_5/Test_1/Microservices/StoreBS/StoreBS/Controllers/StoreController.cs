using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using StoreBL.Models;
using StoreBL.Services.Interfaces;

namespace StoreBS.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StoreController : Controller
{
    private readonly IStoreService _storeService;

    public StoreController(IStoreService storeService)
    {
        _storeService = storeService;
    }

    [HttpGet("GetAllStores")]
    public async Task<IActionResult> GetAllStores()
    {
        var stores = await _storeService.GetAllStoresAsync();

        return Ok(stores);
    }

    [HttpGet("GetStore/{id}")]
    public async Task<IActionResult> GetStoreById(Guid id)
    {
        var store = await _storeService.GetStoreByIdAsync(id);

        if (store == null)
        {
            return BadRequest("Store is null");
        }

        return Ok(store);
    }

    [HttpPut("UpdateStore/{id}")]
    public async Task<IActionResult> UpdateStore(Guid id, [FromBody] StoreDTO storeDto)
    {
        if (storeDto == null)
        {
            return BadRequest("Store is null");
        }

        var updatedStoreId = await _storeService.UpdateStoreAsync(id, storeDto);

        if (updatedStoreId == Guid.Empty)
        {
            return BadRequest("Failed to update");
        }

        return Ok(updatedStoreId);
    }

    [HttpGet("GetStorePets/{storeId}")]
    public async Task<IActionResult> GetStorePets(Guid storeId)
    {
        var pets = await _storeService.GetStorePetsAsync(storeId);

        if (pets == null)
        {
            return BadRequest("Pets are null");
        }

        return Ok(pets);
    }

    [HttpGet("GetStoreHealthcareRecords/{storeId}")]
    public async Task<IActionResult> GetStoreHealthcareRecords(Guid storeId)
    {
        var healthRecords = await _storeService.GetStoreHealthcareRecordsAsync(storeId);

        if (healthRecords == null)
        {
            return BadRequest("Health records are null");
        }

        return Ok(healthRecords);
    }
}
