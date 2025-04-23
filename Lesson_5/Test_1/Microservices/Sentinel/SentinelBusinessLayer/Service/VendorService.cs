using SentinelBusinessLayer.Enums;
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
    public class VendorService : IVendorService
    {
        private readonly IVendorClient _vendorClient;
        
        public VendorService(IVendorClient vendorClient)
        {
            _vendorClient = vendorClient;
        }
        
        public async Task<List<VendorDto>> GetAllVendors()
        {
            return await _vendorClient.GetAllVendors();
        }
        
        public async Task<VendorDto> GetVendorById(Guid id)
        {
            return await _vendorClient.GetVendorById(id);
        }

        public async Task<Guid> AddVendor(VendorDto vendorDto)
        {
            return await _vendorClient.AddVendor(vendorDto);
        }

        public async Task<Guid> UpdateVendor(Guid id, VendorDto vendorDto)
        {
            return await _vendorClient.UpdateVendor(id, vendorDto);
        }

        public async Task DeleteVendor(Guid id)
        {
            await _vendorClient.DeleteVendor(id);
        }

        public async Task<List<VendorDto>> GetVendorsByContractType(ContractType type)
        {
            return await _vendorClient.GetVendorsByContractType(type);
        }

        public async Task<List<HealthCareDto>> GetVendorHealthCareRecords(Guid vendorId)
        {
            return await _vendorClient.GetVendorHealthCareRecords(vendorId);
        }
    }
}
