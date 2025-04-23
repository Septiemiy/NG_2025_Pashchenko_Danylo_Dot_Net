using Microsoft.AspNetCore.Mvc;
using SentinelBusinessLayer.Models;
using SentinelBusinessLayer.Service.Interface;

namespace Sentinel.Controllers
{
    [Route("api/[controller]")]
    [Controller]
    public class HealthCareController : ControllerBase
    {
        private readonly IHealthCareService _healthCareService;

        public HealthCareController(IHealthCareService healthCareService)
        {
            _healthCareService = healthCareService;
        }

        [HttpGet("GetAllHealthCare")]
        public async Task<IActionResult> GetAllHealthCareRecords()
        {
            var healthCareRecords = await _healthCareService.GetAllHealthCareRecords();

            return Ok(healthCareRecords);
        }

        [HttpGet("GetHealthCareById/{id}")]
        public async Task<IActionResult> GetHealthCareRecordById(Guid id)
        {
            var healthCareRecord = await _healthCareService.GetHealthCareRecordById(id);

            return Ok(healthCareRecord);
        }

        [HttpGet("AddHealthCare")]
        public async Task<IActionResult> AddHealthCareRecord([FromBody] HealthCareDto healthCareDto)
        {
            var healthCareRecordId = await _healthCareService.AddHealthCareRecord(healthCareDto);

            return Ok(healthCareRecordId);
        }

        [HttpGet("UpdateHealthCare/{id}")]
        public async Task<IActionResult> UpdateHealthCareRecord(Guid id, [FromBody] HealthCareDto healthCareDto)
        {
            var updatedHealthCareRecordId = await _healthCareService.UpdateHealthCareRecord(id, healthCareDto);

            return Ok(updatedHealthCareRecordId);
        }

        [HttpGet("DeleteHealthCare/{id}")]
        public async Task<IActionResult> DeleteHealthCareRecord(Guid id)
        {
            await _healthCareService.DeleteHealthCareRecord(id);

            return NoContent();
        }

        [HttpGet("GetHealthCareByPet/{petId}")]
        public async Task<IActionResult> GetHealthCareRecordsByPet(Guid petId)
        {
            var healthCareRecords = await _healthCareService.GetHealthCareRecordsByPet(petId);

            return Ok(healthCareRecords);
        }

        [HttpGet("GetHealthCareByVendor/{vendorId}")]
        public async Task<IActionResult> GetHealthCareRecordsByVendor(Guid vendorId)
        {
            var healthCareRecords = await _healthCareService.GetHealthCareRecordsByVendor(vendorId);

            return Ok(healthCareRecords);
        }

        [HttpGet("GetExpiringHealthCare")]
        public async Task<IActionResult> GetExpiringHealthCareRecords()
        {
            var expiringHealthCareRecords = await _healthCareService.GetExpiringHealthCareRecords();

            return Ok(expiringHealthCareRecords);
        }
    }
}
