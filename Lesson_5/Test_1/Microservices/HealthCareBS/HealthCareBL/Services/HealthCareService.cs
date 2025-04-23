using AutoMapper;
using DAL_Core.Entities;
using HealthCareBL.Models;
using HealthCareBL.Services.Interfaces;
using HealthCareDAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCareBL.Services
{
    public class HealthCareService : IHealthCareService
    {
        private readonly IHealthCareRepository _healthCareRepository;
        private readonly IPetRepository _petRepository;
        private readonly IVendorRepository _vendorRepository;
        private readonly IMapper _mapper;

        public HealthCareService(IHealthCareRepository healthCareRepository, IPetRepository petRepository,
            IVendorRepository vendorRepository, IMapper mapper)
        {
            _healthCareRepository = healthCareRepository;
            _petRepository = petRepository;
            _vendorRepository = vendorRepository;
            _mapper = mapper;
        }

        public async Task<Guid> AddHealthCareRecordAsync(HealthCareDTO healthCareDTO)
        {
            var healthCare = _mapper.Map<HealthCare>(healthCareDTO);

            await _healthCareRepository.CreateAsync(healthCare);

            return healthCare.Id;
        }

        public async Task DeleteHealthCareRecordAsync(Guid id)
        {
            await _healthCareRepository.DeleteAsync(id);
        }

        public async Task<ICollection<HealthCareDTO>> GetAllHealthCareRecordsAsync()
        {
            var healthCareRecords = await _healthCareRepository.GetAllAsync();

            var healthCareDTOs = _mapper.Map<ICollection<HealthCareDTO>>(healthCareRecords);

            return healthCareDTOs;
        }

        public async Task<ICollection<HealthCareDTO>> GetExpiringHealthCareRecordsAsync()
        {
            var expiringHealthCareRecords = await _healthCareRepository.GetExpiringHealthCareRecordsAsync();
            
            var healthCareDTOs = _mapper.Map<ICollection<HealthCareDTO>>(expiringHealthCareRecords);
            
            return healthCareDTOs;
        }

        public async Task<HealthCareDTO> GetHealthCareRecordByIdAsync(Guid id)
        {
            var healthCareRecord = await _healthCareRepository.GetAsync(id);

            if (healthCareRecord == null)
            {
                throw new Exception($"HCE: Health care record with ID = {id} not found.");
            }

            var healthCareDTO = _mapper.Map<HealthCareDTO>(healthCareRecord);

            return healthCareDTO;
        }

        public async Task<ICollection<HealthCareDTO>> GetHealthCareRecordsByPetAsync(Guid petId)
        {
            var pet = await _petRepository.GetAsync(petId);

            if (pet == null)
            {
                throw new Exception($"HCE: Pet with ID = {petId} not found.");
            }

            var healthCareRecords = pet.HealthCares;

            var healthCareDTOs = _mapper.Map<ICollection<HealthCareDTO>>(healthCareRecords);

            return healthCareDTOs;
        }

        public async Task<ICollection<HealthCareDTO>> GetHealthCareRecordsByVendorAsync(Guid vendorId)
        {
            var vendor = await _vendorRepository.GetAsync(vendorId);
            
            if (vendor == null)
            {
                throw new Exception($"HCE: Vendor with ID = {vendorId} not found.");
            }
            
            var healthCareRecords = vendor.HealthCares;
            
            var healthCareDTOs = _mapper.Map<ICollection<HealthCareDTO>>(healthCareRecords);
            
            return healthCareDTOs;
        }

        public async Task<Guid> UpdateHealthCareRecordAsync(Guid id, HealthCareDTO healthCareDTO)
        {
            var healthCare = await _healthCareRepository.GetAsync(id);

            if (healthCare == null)
            {
                throw new Exception($"HCE: Health care record with ID = {id} not found.");
            }

            var newHealthCare = _mapper.Map<HealthCare>(healthCareDTO);

            await _healthCareRepository.UpdateAsync(newHealthCare);

            return newHealthCare.Id;
        }
    }
}
