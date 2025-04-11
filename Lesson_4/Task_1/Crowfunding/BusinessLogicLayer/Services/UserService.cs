using AutoMapper;
using BusinessLogicLayer.Models;
using BusinessLogicLayer.Services.Interface;
using DataAccessLayer.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserModel?> GetUserAsync(Guid id)
        {
            var user = await _userRepository.GetAsync(id);
            return _mapper.Map<UserModel>(user);
        }

        public async Task<ICollection<UserModel>?> GetAllUsersAsync()
        {
            var users = await _userRepository.GetAllAsync();
            return _mapper.Map<ICollection<UserModel>>(users);
        }

        public async Task<ICollection<UserModel>?> GetAllUsersWithProjectsAsync()
        {
            var users = await _userRepository.GetAllUsersWithProjectsAsync();
            return _mapper.Map<ICollection<UserModel>>(users);
        }

        public async Task<UserModel?> GetUserWithCommentaryAsync(Guid id)
        {
            var user = await _userRepository.GetUserWithCommentaryAsync(id);
            return _mapper.Map<UserModel>(user);
        }

        public async Task<UserModel?> GetUserWithVoteAsync(Guid id)
        {
            var user = await _userRepository.GetUserWithVoteAsync(id);
            return _mapper.Map<UserModel>(user);
        }

        public async Task<UserModel?> GetUserWithProjectsAsync(Guid id)
        {
            var user = await _userRepository.GetUserWithProjectsAsync(id);
            return _mapper.Map<UserModel>(user);
        }
    }
}
