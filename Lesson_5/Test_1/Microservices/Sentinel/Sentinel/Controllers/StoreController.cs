using Microsoft.AspNetCore.Mvc;
using SentinelBusinessLayer.Models;
using SentinelBusinessLayer.Service.Interface;

namespace Sentinel.Controllers
{
    [Route("api/[controller]")]
    [Controller]
    public class StoreController : ControllerBase
    {
        private readonly IStoreService _storeService;

        public StoreController(IStoreService storeService)
        {
            _storeService = storeService;
        }

        [HttpGet("GetAllStores")]
        public async Task<IActionResult> GetAllStores()
        {
            var stores = await _storeService.GetAllStores();
            
            return Ok(stores);
        }

        [HttpGet("GetStoreById/{id}")]
        public async Task<IActionResult> GetStoreById(Guid id)
        {
            var store = await _storeService.GetStoreById(id);

            return Ok(store);
        }

        [HttpPut("UpdateStore/{id}")]
        public async Task<IActionResult> UpdateStore(Guid id, [FromBody] StoreDto storeDto)
        {
            var updatedStoreId = await _storeService.UpdateStore(id, storeDto);
            
            return Ok(updatedStoreId);
        }

        [HttpGet("GetStorePets/{storeId}")]
        public async Task<IActionResult> GetStorePets(Guid storeId)
        {
            var pets = await _storeService.GetStorePets(storeId);

            return Ok(pets);
        }

        [HttpGet("GetStoreHealthcareRecords/{storeId}")]
        public async Task<IActionResult> GetStoreHealthcareRecords(Guid storeId)
        {
            var healthcareRecords = await _storeService.GetStoreHealthcareRecords(storeId);
            
            return Ok(healthcareRecords);
        }
    }
}
