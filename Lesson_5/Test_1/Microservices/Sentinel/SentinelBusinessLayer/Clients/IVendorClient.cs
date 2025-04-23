using SentinelBusinessLayer.Enums;
using Refit;
using SentinelBusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SentinelBusinessLayer.Clients
{
    public interface IVendorClient
    {
        [Get("/api/vendor/getAll")]
        Task<List<VendorDto>> GetAllVendors();

        [Get("/api/vendor/getById/{id}")]
        Task<VendorDto> GetVendorById(Guid id);

        [Post("/api/vendor/add")]
        Task<Guid> AddVendor([Body] VendorDto vendorDto);

        [Put("/api/vendor/update/{id}")]
        Task<Guid> UpdateVendor(Guid id, [Body] VendorDto vendorDto);

        [Delete("api/vendor/delete/{id}")]
        Task DeleteVendor(Guid id);

        [Get("/api/vendor/getByContractType/{type}")]
        Task<List<VendorDto>> GetVendorsByContractType(ContractType type);

        [Get("/api/vendor/getHealthCareRecords/{vendorId}")]
        Task<List<HealthCareDto>> GetVendorHealthCareRecords(Guid vendorId);
    }
}
