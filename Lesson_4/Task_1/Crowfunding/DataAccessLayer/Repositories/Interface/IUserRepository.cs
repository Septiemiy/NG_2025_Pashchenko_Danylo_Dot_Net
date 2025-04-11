using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.Interface
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User?> GetUserWithProjectsAsync(Guid id);
        Task<User?> GetUserWithVoteAsync(Guid id);
        Task<User?> GetUserWithCommentaryAsync(Guid id);
        Task<ICollection<User>> GetAllUsersWithProjectsAsync();
    }
}
