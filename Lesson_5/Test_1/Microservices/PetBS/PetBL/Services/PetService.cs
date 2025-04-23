using AutoMapper;
using DAL_Core.Entities;
using DAL_Core.Enums;
using PetBL.Models;
using PetBL.Services.Interfaces;
using PetDAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetBL.Services
{
    public class PetService : IPetService
    {
        private readonly IPetRepository _petRepository;
        private readonly IStoreRepository _storeRepository;
        private readonly IMapper _mapper;

        public PetService(IPetRepository petRepository, IStoreRepository storeRepository,
            IMapper mapper)
        {
            _petRepository = petRepository;
            _storeRepository = storeRepository;
            _mapper = mapper;
        }

        public async Task<Guid> AddPetAsync(PetDTO petDto)
        {
            var pet = _mapper.Map<Pet>(petDto);

            await _petRepository.CreateAsync(pet);

            return pet.Id;
        }

        public async Task<Guid> AdoptPetAsync(Guid petId, Guid customerId)
        {
            var pet = await _petRepository.GetAsync(petId);

            if(pet == null)
            {
                throw new Exception($"PE: Pet with id = {petId} not found");
            }

            pet.CustomerId = customerId;

            await _petRepository.UpdateAsync(pet);

            return pet.Id;
        }

        public async Task<ICollection<PetDTO>> GetAllPetsAsync()
        {
            var pets = await _petRepository.GetAllAsync();

            var petDtos = _mapper.Map<ICollection<PetDTO>>(pets);

            return petDtos;
        }

        public async Task<PetDTO> GetPetByIdAsync(Guid id)
        {
            var pet = await _petRepository.GetAsync(id);

            if(pet == null)
            {
                throw new Exception($"PE: Pet with id = {id} not found");
            }

            var petDto = _mapper.Map<PetDTO>(pet);

            return petDto;
        }

        public async Task<ICollection<PetDTO>> GetPetsByStoreAsync(Guid storeId)
        {
            var stors = await _storeRepository.GetStoreWithPetsAsync(storeId);

            if(stors == null)
            {
                throw new Exception($"PE: Store with id = {storeId} not found");
            }

            var pets = _mapper.Map<ICollection<PetDTO>>(stors.Pets);

            return pets;
        }

        public async Task<ICollection<PetDTO>> GetPetsByTypeAsync(PetTypes type)
        {
            var pets = await _petRepository.GetAllPetsByPetTypeAsync(type);

            if(pets == null)
            {
                throw new Exception($"PE: Pets with type = {type} not found");
            }

            var petDtos = _mapper.Map<ICollection<PetDTO>>(pets);

            return petDtos;
        }

        public async Task<Guid> UpdatePetAsync(Guid id, PetDTO petDto)
        {
            var pet = await _petRepository.GetAsync(id);

            if (pet == null)
            {
                throw new Exception($"PE: Pet with id = {id} not found");
            }

            var newPet = _mapper.Map<Pet>(petDto);

            await _petRepository.UpdateAsync(newPet);

            return newPet.Id;
        }
    }
}
