using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.Interface
{
    public interface ICommentRepository : IRepository<Comment>
    {
        Task<ICollection<Comment>?> GetCommentsByProjectId(Guid projectId);
        Task<ICollection<Comment>?> GetCommentsByUserId(Guid userId);
        Task<ICollection<Comment>?> GetAllCommentsWithUsersAsync();
        Task<ICollection<Comment>?> GetAllCommentsWithProjectsAsync();
    }
}
