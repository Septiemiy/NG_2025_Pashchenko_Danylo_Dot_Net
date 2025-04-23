using HealthCareBL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCareBL.Services.Interfaces
{
    public interface IHealthCareService
    {
        Task<ICollection<HealthCareDTO>> GetAllHealthCareRecordsAsync();
        Task<HealthCareDTO> GetHealthCareRecordByIdAsync(Guid id);
        Task<Guid> AddHealthCareRecordAsync(HealthCareDTO healthCareDTO);
        Task<Guid> UpdateHealthCareRecordAsync(Guid id, HealthCareDTO healthCareDTO);
        Task DeleteHealthCareRecordAsync(Guid id);
        Task<ICollection<HealthCareDTO>> GetHealthCareRecordsByPetAsync(Guid petId);
        Task<ICollection<HealthCareDTO>> GetHealthCareRecordsByVendorAsync(Guid vendorId);
        Task<ICollection<HealthCareDTO>> GetExpiringHealthCareRecordsAsync();
    }
}
