using AutoMapper;
using DAL_Core.Entities;
using DAL_Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendorBL.Models;
using VendorBL.Services.Interfaces;
using VendorDAL.Repositories.Interfaces;

namespace VendorBL.Services
{
    public class VendorService : IVendorService
    {
        private readonly IVendorRepository _vendorRepository;
        private readonly IHealthCareRepository _healthCareRepository;
        private readonly IMapper _mapper;

        public VendorService(IVendorRepository vendorRepository, IHealthCareRepository healthCareRepository,
            IMapper mapper)
        {
            _vendorRepository = vendorRepository;
            _healthCareRepository = healthCareRepository;
            _mapper = mapper;
        }

        public async Task<Guid> AddVendorAsync(VendorDTO vendorDto)
        {
            var vendor = _mapper.Map<Vendor>(vendorDto);

            await _vendorRepository.AddAsync(vendor);

            return vendor.Id;
        }

        public async Task DeleteVendorAsync(Guid id)
        {
            await _vendorRepository.DeleteAsync(id);
        }

        public async Task<ICollection<VendorDTO>> GetAllVendorsAsync()
        {
            var vendors = await _vendorRepository.GetAllAsync();

            var vendorDtos = _mapper.Map<ICollection<VendorDTO>>(vendors);

            return vendorDtos;
        }

        public async Task<VendorDTO> GetVendorByIdAsync(Guid id)
        {
            var vendor = await _vendorRepository.GetAsync(id);

            if (vendor == null)
            {
                throw new Exception($"VE: Vendor with id = {id} not found.");
            }

            var vendorDto = _mapper.Map<VendorDTO>(vendor);

            return vendorDto;
        }

        public async Task<ICollection<HealthCareDTO>> GetVendorHealthCareRecordsAsync(Guid vendorId)
        {
            var vendor = await _vendorRepository.GetVendorWithHealthCareRecords(vendorId);

            if (vendor == null)
            {
                throw new Exception($"VE: Vendor with id = {vendorId} not found.");
            }

            var healthCareRecords = vendor.HealthCares;

            var healthCareDTOs =  _mapper.Map<ICollection<HealthCareDTO>>(healthCareRecords);

            return healthCareDTOs;
        }

        public async Task<ICollection<VendorDTO>> GetVendorsByContractTypeAsync(ContractType type)
        {
            var vendors = await _vendorRepository.GetVendorsByContractType(type);

            if (vendors == null)
            {
                throw new Exception($"VE: No vendors found with contract type = {type}.");
            }

            var vendorDtos = _mapper.Map<ICollection<VendorDTO>>(vendors);

            return vendorDtos;
        }

        public async Task<Guid> UpdateVendorAsync(Guid id, VendorDTO vendorDto)
        {
            var vendor = await _vendorRepository.GetAsync(id);

            if (vendor == null)
            {
                throw new Exception($"VE: Vendor with id = {id} not found.");
            }

            var newVendor = _mapper.Map<Vendor>(vendorDto);

            await _vendorRepository.UpdateAsync(newVendor);

            return newVendor.Id;
        }
    }
}
