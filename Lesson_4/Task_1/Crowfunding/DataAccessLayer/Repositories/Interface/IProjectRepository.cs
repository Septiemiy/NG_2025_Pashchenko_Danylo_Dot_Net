using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.Interface
{
    public interface IProjectRepository : IRepository<Project>
    {
        Task<Project?> GetProjectWithUserAsync(Guid id);
        Task<Project?> GetProjectWithCategoriesAsync(Guid id);
        Task<Project?> GetProjectWithVoteAsync(Guid id);
        Task<Project?> GetProjectWithCommentaryAsync(Guid id);
        Task<ICollection<Project>?> GetAllProjectsWithUsersAsync();
    }
}
