using AutoMapper;
using DAL_Core.Entities;
using StoreBL.Models;
using StoreBL.Services.Interfaces;
using StoreDAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreBL.Services
{
    public class StoreService : IStoreService
    {
        private readonly IStoreRepository _storeRepository;
        private readonly IPetRepository _petRepository;
        private readonly IHealthCareRepository _healthCareRepository;
        private readonly IMapper _mapper;

        public StoreService(IStoreRepository storeRepository, IPetRepository petRepository, 
            IHealthCareRepository healthCareRepository, IMapper mapper)
        {
            _storeRepository = storeRepository;
            _petRepository = petRepository;
            _healthCareRepository = healthCareRepository;
            _mapper = mapper;
        }

        public async Task<ICollection<StoreDTO>> GetAllStoresAsync()
        {
            var stores = await _storeRepository.GetAllAsync();

            var storeDtos = _mapper.Map<ICollection<StoreDTO>>(stores);

            return storeDtos;
        }

        public async Task<StoreDTO> GetStoreByIdAsync(Guid id)
        {
            var store = await _storeRepository.GetAsync(id);

            if (store == null)
            {
                throw new Exception($"SE: Store with id = {id} not found");
            }

            var storeDto = _mapper.Map<StoreDTO>(store);

            return storeDto;
        }

        public async Task<ICollection<HealthCareDTO>> GetStoreHealthcareRecordsAsync(Guid storeId)
        {
            var healthCares = await _healthCareRepository.GetAllByStoreIdAsync(storeId);

            if (healthCares == null)
            {
                throw new Exception($"SE: No healthcare records found for store with id = {storeId}");
            }

            var healthCareDtos = _mapper.Map<ICollection<HealthCareDTO>>(healthCares);

            return healthCareDtos;
        }

        public async Task<ICollection<PetDTO>> GetStorePetsAsync(Guid storeId)
        {
            var pets = await _petRepository.GetAllByStoreIdAsync(storeId);

            if (pets == null)
            {
                throw new Exception($"SE: No pets found for store with id = {storeId}");
            }

            var petDtos = _mapper.Map<ICollection<PetDTO>>(pets);

            return petDtos;
        }

        public async Task<Guid> UpdateStoreAsync(Guid id, StoreDTO storeDto)
        {
            var store = await _storeRepository.GetAsync(id);

            if (store == null)
            {
                throw new Exception($"SE: Store with id = {id} not found");
            }

            var newStore = _mapper.Map<Store>(storeDto);

            await _storeRepository.UpdateAsync(newStore);

            return newStore.Id;
        }
    }
}
