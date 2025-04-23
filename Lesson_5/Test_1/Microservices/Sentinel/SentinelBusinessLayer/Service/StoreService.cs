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
    public class StoreService : IStoreService
    {
        private readonly IStoreClient _storeClient;
        
        public StoreService(IStoreClient storeClient)
        {
            _storeClient = storeClient;
        }
        
        public async Task<List<StoreDto>> GetAllStores()
        {
            return await _storeClient.GetAllStores();
        }
        
        public async Task<StoreDto> GetStoreById(Guid id)
        {
            return await _storeClient.GetStoreById(id);
        }
        
        public async Task<Guid> UpdateStore(Guid id, StoreDto storeDto)
        {
            return await _storeClient.UpdateStore(id, storeDto);
        }
        
        public async Task<List<PetDto>> GetStorePets(Guid storeId)
        {
            return await _storeClient.GetStorePets(storeId);
        }
        
        public async Task<List<HealthCareDto>> GetStoreHealthcareRecords(Guid storeId)
        {
            return await _storeClient.GetStoreHealthcareRecords(storeId);
        }
    }    
}
