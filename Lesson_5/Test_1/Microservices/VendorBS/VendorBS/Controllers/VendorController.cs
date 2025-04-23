using System.Diagnostics;
using DAL_Core.Enums;
using Microsoft.AspNetCore.Mvc;
using VendorBL.Models;
using VendorBL.Services.Interfaces;

namespace VendorBS.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VendorController : Controller
{
    private readonly IVendorService _vendorService;

    public VendorController(IVendorService vendorService)
    {
        _vendorService = vendorService;
    }

    [HttpGet("getAll")]
    public async Task<IActionResult> GetAllVendors()
    {
        var vendors = await _vendorService.GetAllVendorsAsync();
        
        return Ok(vendors);
    }

    [HttpGet("getById/{id}")]
    public async Task<IActionResult> GetVendorById(Guid id)
    {
        var vendor = await _vendorService.GetVendorByIdAsync(id);

        return Ok(vendor);
    }

    [HttpPost("add")]
    public async Task<IActionResult> AddVendor([FromBody] VendorDTO vendorDto)
    {
        if (vendorDto == null)
        {
            return BadRequest("Vendor data is null.");
        }

        var vendorId = await _vendorService.AddVendorAsync(vendorDto);
        
        return Ok(vendorId);
    }

    [HttpPut("update/{id}")]
    public async Task<IActionResult> UpdateVendor(Guid id, [FromBody] VendorDTO vendorDto)
    {
        if (vendorDto == null)
        {
            return BadRequest("Vendor data is null.");
        }

        var updatedVendorId = await _vendorService.UpdateVendorAsync(id, vendorDto);

        return Ok(updatedVendorId);
    }

    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> DeleteVendor(Guid id)
    {
        await _vendorService.DeleteVendorAsync(id);
        
        return Ok();
    }

    [HttpGet("getByContractType/{type}")]
    public async Task<IActionResult> GetVendorsByContractType(ContractType type)
    {
        var vendors = await _vendorService.GetVendorsByContractTypeAsync(type);

        return Ok(vendors);
    }

    [HttpGet("getHealthCareRecords/{vendorId}")]
    public async Task<IActionResult> GetVendorHealthCareRecords(Guid vendorId)
    {
        var healthCareRecords = await _vendorService.GetVendorHealthCareRecordsAsync(vendorId);
        
        return Ok(healthCareRecords);
    }
}
