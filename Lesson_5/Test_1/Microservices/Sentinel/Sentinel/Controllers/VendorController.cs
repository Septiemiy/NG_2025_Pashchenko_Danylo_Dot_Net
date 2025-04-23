using Microsoft.AspNetCore.Mvc;
using SentinelBusinessLayer.Enums;
using SentinelBusinessLayer.Models;
using SentinelBusinessLayer.Service.Interface;

namespace Sentinel.Controllers
{
    [Route("api/[controller]")]
    [Controller]
    public class VendorController : ControllerBase
    {
        private readonly IVendorService _vendorService;

        public VendorController(IVendorService vendorService)
        {
            _vendorService = vendorService;
        }

        [HttpGet("GetAllVendors")]
        public async Task<IActionResult> GetAllVendors()
        {
            var vendors = await _vendorService.GetAllVendors();

            return Ok(vendors);
        }

        [HttpGet("GetVendorById/{id}")]
        public async Task<IActionResult> GetVendorById(Guid id)
        {
            var vendor = await _vendorService.GetVendorById(id);

            return Ok(vendor);
        }

        [HttpPost("AddVendor")]
        public async Task<IActionResult> AddVendor([FromBody] VendorDto vendorDto)
        {
            var vendorId = await _vendorService.AddVendor(vendorDto);

            return Ok(vendorId);
        }

        [HttpPut("UpdateVendor/{id}")]
        public async Task<IActionResult> UpdateVendor(Guid id, [FromBody] VendorDto vendorDto)
        {
            var updatedVendorId = await _vendorService.UpdateVendor(id, vendorDto);

            return Ok(updatedVendorId);
        }

        [HttpDelete("DeleteVendor/{id}")]
        public async Task<IActionResult> DeleteVendor(Guid id)
        {
            await _vendorService.DeleteVendor(id);

            return Ok();
        }

        [HttpGet("GetVendorByContractType/{type}")]
        public async Task<IActionResult> GetVendorsByContractType(ContractType type)
        {
            var vendors = await _vendorService.GetVendorsByContractType(type);
            
            return Ok(vendors);
        }

        [HttpGet("GetVendorHealthCareRecords/{vendorId}")]
        public async Task<IActionResult> GetVendorHealthCareRecords(Guid vendorId)
        {
            var healthCareRecords = await _vendorService.GetVendorHealthCareRecords(vendorId);
            
            return Ok(healthCareRecords);
        }
    }
}
