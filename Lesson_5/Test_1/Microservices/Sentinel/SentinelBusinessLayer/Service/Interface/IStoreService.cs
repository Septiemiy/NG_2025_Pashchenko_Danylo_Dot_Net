using SentinelBusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SentinelBusinessLayer.Service.Interface
{
    public interface IStoreService
    {
        Task<List<StoreDto>> GetAllStores();
        Task<StoreDto> GetStoreById(Guid id);
        Task<Guid> UpdateStore(Guid id, StoreDto storeDto);
        Task<List<PetDto>> GetStorePets(Guid storeId);
        Task<List<HealthCareDto>> GetStoreHealthcareRecords(Guid storeId);
    }
}
