using BusinessLogicLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services.Interface
{
    public interface IVoteService
    {
        Task<ICollection<VoteModel>?> GetAllVotesAsync();
        Task<VoteModel?> GetVoteByUserIdAndProjectIdAsync(Guid userId, Guid projectId);
        Task<ICollection<VoteModel>?> GetVotesByProjectIdAsync(Guid projectId);
        Task<ICollection<VoteModel>?> GetVotesByUserIdAsync(Guid userId);
    }
}
