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
    public class VoteService : IVoteService
    {
        private readonly IVoteRepository _voteRepository;
        private readonly IMapper _mapper;

        public VoteService(IVoteRepository voteRepository, IMapper mapper)
        {
            _voteRepository = voteRepository;
            _mapper = mapper;
        }

        public async Task<ICollection<VoteModel>?> GetAllVotesAsync()
        {
            var votes = await _voteRepository.GetAllAsync();
            return _mapper.Map<ICollection<VoteModel>?>(votes);
        }

        public async Task<VoteModel?> GetVoteByUserIdAndProjectIdAsync(Guid userId, Guid projectId)
        {
            var vote = await _voteRepository.GetVoteByUserIdAndProjectIdAsync(userId, projectId);
            return _mapper.Map<VoteModel?>(vote);
        }

        public async Task<ICollection<VoteModel>?> GetVotesByProjectIdAsync(Guid projectId)
        {
            var votes = await _voteRepository.GetVotesByProjectIdAsync(projectId);
            return _mapper.Map<ICollection<VoteModel>?>(votes);
        }

        public async Task<ICollection<VoteModel>?> GetVotesByUserIdAsync(Guid userId)
        {
            var votes = await _voteRepository.GetVotesByUserIdAsync(userId);
            return _mapper.Map<ICollection<VoteModel>?>(votes);
        }
    }
}
