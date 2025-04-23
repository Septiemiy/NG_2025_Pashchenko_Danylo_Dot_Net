using Refit;
using SentinelBusinessLayer.Models;

namespace SentinelBusinessLayer.Clients
{
    public interface IStoreClient
    {
        [Get("/api/store/GetAllStores")]
        Task<List<StoreDto>> GetAllStores();

        [Get("/api/store/GetStore/{id}")]
        Task<StoreDto> GetStoreById(Guid id);

        [Put("/api/store/UpdateStore/{id}")]
        Task<Guid> UpdateStore(Guid id, [Body] StoreDto storeDto);

        [Get("/api/store/GetStorePets/{storeId}")]
        Task<List<PetDto>> GetStorePets(Guid storeId);

        [Get("/api/store/GetStoreHealthcareRecords/{storeId}")]
        Task<List<HealthCareDto>> GetStoreHealthcareRecords(Guid storeId);
    }
}
