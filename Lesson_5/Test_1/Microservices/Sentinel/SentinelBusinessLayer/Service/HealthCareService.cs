using SentinelBusinessLayer.Clients;
using SentinelBusinessLayer.Models;
using SentinelBusinessLayer.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SentinelBusinessLayer.Service
{
    public class HealthCareService : IHealthCareService
    {
        private readonly IHealthCareClient _healthCareClient;

        public HealthCareService(IHealthCareClient healthCareClient)
        {
            _healthCareClient = healthCareClient;
        }

        public async Task<Guid> AddHealthCareRecord(HealthCareDto healthCareDto)
        {
            return await _healthCareClient.AddHealthCareRecord(healthCareDto);
        }

        public async Task<Guid> UpdateHealthCareRecord(Guid id, HealthCareDto healthCareDto)
        {
            return await _healthCareClient.UpdateHealthCareRecord(id, healthCareDto);
        }

        public async Task<HealthCareDto> GetHealthCareRecordById(Guid id)
        {
            return await _healthCareClient.GetHealthCareRecordById(id);
        }

        public async Task<List<HealthCareDto>> GetAllHealthCareRecords()
        {
            return await _healthCareClient.GetAllHealthCareRecords();
        }
        
        public async Task DeleteHealthCareRecord(Guid id)
        {
            await _healthCareClient.DeleteHealthCareRecord(id);
        }
        
        public async Task<List<HealthCareDto>> GetHealthCareRecordsByPet(Guid petId)
        {
            return await _healthCareClient.GetHealthCareRecordsByPet(petId);
        }
        
        public async Task<List<HealthCareDto>> GetHealthCareRecordsByVendor(Guid vendorId)
        {
            return await _healthCareClient.GetHealthCareRecordsByVendor(vendorId);
        }
        
        public async Task<List<HealthCareDto>> GetExpiringHealthCareRecords()
        {
            return await _healthCareClient.GetExpiringHealthCareRecords();
        }
    }
}
