using Refit;
using SentinelBusinessLayer.Models;

namespace SentinelBusinessLayer.Clients
{
    public interface IHealthCareClient
    {
        [Get("api/healthcare/add")]
        Task<Guid> AddHealthCareRecord([Body] HealthCareDto healthCareDto);

        [Get("api/healthcare/update/{id}")]
        Task<Guid> UpdateHealthCareRecord(Guid id, [Body] HealthCareDto healthCareDto);

        [Get("api/healthcare/get/{id}")]
        Task<HealthCareDto> GetHealthCareRecordById(Guid id);

        [Get("api/healthcare/getAll")]
        Task<List<HealthCareDto>> GetAllHealthCareRecords();

        [Get("api/healthcare/delete")]
        Task DeleteHealthCareRecord(Guid id);

        [Get("api/healthcare/getByPet/{petId}")]
        Task<List<HealthCareDto>> GetHealthCareRecordsByPet(Guid petId);

        [Get("api/healthcare/getByVendor/{vendorId}")]
        Task<List<HealthCareDto>> GetHealthCareRecordsByVendor(Guid vendorId);

        [Get("api/healthcare/getExpiring")]
        Task<List<HealthCareDto>> GetExpiringHealthCareRecords();
    }
}
