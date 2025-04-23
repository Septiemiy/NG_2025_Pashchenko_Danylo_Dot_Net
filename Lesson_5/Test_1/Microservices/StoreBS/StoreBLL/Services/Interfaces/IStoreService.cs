using StoreBL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreBL.Services.Interfaces
{
    public interface IStoreService
    {
        Task<ICollection<StoreDTO>> GetAllStoresAsync();
        Task<StoreDTO> GetStoreByIdAsync(Guid id);
        Task<Guid> UpdateStoreAsync(Guid id, StoreDTO storeDto);
        Task<ICollection<PetDTO>> GetStorePetsAsync(Guid storeId);
        Task<ICollection<HealthCareDTO>> GetStoreHealthcareRecordsAsync(Guid storeId);
    }
}
