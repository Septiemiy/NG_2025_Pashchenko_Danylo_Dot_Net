using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.Interface
{
    public interface IVoteRepository : IRepository<Vote>
    {
        Task<Vote?> GetVoteByUserIdAndProjectIdAsync(Guid userId, Guid projectId);
        Task<ICollection<Vote>?> GetVotesByProjectIdAsync(Guid projectId);
        Task<ICollection<Vote>?> GetVotesByUserIdAsync(Guid userId);
    }
}
