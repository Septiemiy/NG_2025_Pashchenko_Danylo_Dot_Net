using SentinelBusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SentinelBusinessLayer.Service.Interface
{
    public interface IHealthCareService
    {
        Task<Guid> AddHealthCareRecord(HealthCareDto healthCareDto);
        Task<Guid> UpdateHealthCareRecord(Guid id, HealthCareDto healthCareDto);
        Task<HealthCareDto> GetHealthCareRecordById(Guid id);
        Task<List<HealthCareDto>> GetAllHealthCareRecords();
        Task DeleteHealthCareRecord(Guid id);
        Task<List<HealthCareDto>> GetHealthCareRecordsByPet(Guid petId);
        Task<List<HealthCareDto>> GetHealthCareRecordsByVendor(Guid vendorId);
        Task<List<HealthCareDto>> GetExpiringHealthCareRecords();
    }
}
