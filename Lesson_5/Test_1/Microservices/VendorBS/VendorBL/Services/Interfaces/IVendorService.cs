using DAL_Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendorBL.Models;

namespace VendorBL.Services.Interfaces
{
    public interface IVendorService
    {
        Task<ICollection<VendorDTO>> GetAllVendorsAsync();
        Task<VendorDTO> GetVendorByIdAsync(Guid id);
        Task<Guid> AddVendorAsync(VendorDTO vendorDto);
        Task<Guid> UpdateVendorAsync(Guid id, VendorDTO vendorDto);
        Task DeleteVendorAsync(Guid id);
        Task<ICollection<VendorDTO>> GetVendorsByContractTypeAsync(ContractType type);
        Task<ICollection<HealthCareDTO>> GetVendorHealthCareRecordsAsync(Guid vendorId);
    }
}
