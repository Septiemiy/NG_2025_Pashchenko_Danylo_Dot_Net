using System.Diagnostics;
using HealthCareBL.Models;
using HealthCareBL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HealthCareBS.Controllers;

[Route("api/[controller]")]
[ApiController]
public class HealthCareController : Controller
{
    private readonly IHealthCareService _healthCareService;
    public HealthCareController(IHealthCareService healthCareService)
    {
        _healthCareService = healthCareService;
    }

    [HttpGet("add")]
    public async Task<IActionResult> AddHealthCareRecord([FromBody] HealthCareDTO healthCareDTO)
    {
        if (healthCareDTO == null)
        {
            return BadRequest("Health care record cannot be null");
        }

        var id = await _healthCareService.AddHealthCareRecordAsync(healthCareDTO);

        return Ok(id);
    }

    [HttpGet("update/{id}")]
    public async Task<IActionResult> UpdateHealthCareRecord(Guid id, [FromBody] HealthCareDTO healthCareDTO)
    {
        if (healthCareDTO == null)
        {
            return BadRequest("Health care record cannot be null");
        }

        var updatedId = await _healthCareService.UpdateHealthCareRecordAsync(id, healthCareDTO);
        
        return Ok(updatedId);
    }

    [HttpGet("get/{id}")]
    public async Task<IActionResult> GetHealthCareRecordById(Guid id)
    {
        var healthCareRecord = await _healthCareService.GetHealthCareRecordByIdAsync(id);

        if (healthCareRecord == null)
        {
            return BadRequest($"Health care record with id {id} not found");
        }

        return Ok(healthCareRecord);
    }

    [HttpGet("getAll")]
    public async Task<IActionResult> GetAllHealthCareRecords()
    {
        var healthCareRecords = await _healthCareService.GetAllHealthCareRecordsAsync();
        
        return Ok(healthCareRecords);
    }

    [HttpGet("delete")]
    public async Task<IActionResult> DeleteHealthCareRecord(Guid id)
    {
        await _healthCareService.DeleteHealthCareRecordAsync(id);

        return Ok();
    }

    [HttpGet("getByPet/{petId}")]
    public async Task<IActionResult> GetHealthCareRecordsByPet(Guid petId)
    {
        var healthCareRecords = await _healthCareService.GetHealthCareRecordsByPetAsync(petId);
        
        if (healthCareRecords == null)
        {
            return BadRequest($"No health care records found for pet with id {petId}");
        }

        return Ok(healthCareRecords);
    }

    [HttpGet("getByVendor/{vendorId}")]
    public async Task<IActionResult> GetHealthCareRecordsByVendor(Guid vendorId)
    {
        var healthCareRecords = await _healthCareService.GetHealthCareRecordsByVendorAsync(vendorId);

        if (healthCareRecords == null)
        {
            return BadRequest($"No health care records found for vendor with id {vendorId}");
        }

        return Ok(healthCareRecords);
    }

    [HttpGet("getExpiring")]
    public async Task<IActionResult> GetExpiringHealthCareRecords()
    {
        var expiringHealthCareRecords = await _healthCareService.GetExpiringHealthCareRecordsAsync();
        
        if (expiringHealthCareRecords == null)
        {
            return BadRequest("No expiring health care records found");
        }
        
        return Ok(expiringHealthCareRecords);
    }
}
