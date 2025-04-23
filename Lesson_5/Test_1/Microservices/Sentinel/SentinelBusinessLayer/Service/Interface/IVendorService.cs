using SentinelBusinessLayer.Enums;
using SentinelBusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SentinelBusinessLayer.Service.Interface
{
    public interface IVendorService
    {
        Task<List<VendorDto>> GetAllVendors();
        Task<VendorDto> GetVendorById(Guid id);
        Task<Guid> AddVendor(VendorDto vendorDto);
        Task<Guid> UpdateVendor(Guid id, VendorDto vendorDto);
        Task DeleteVendor(Guid id);
        Task<List<VendorDto>> GetVendorsByContractType(ContractType type);
        Task<List<HealthCareDto>> GetVendorHealthCareRecords(Guid vendorId);
    }
}
