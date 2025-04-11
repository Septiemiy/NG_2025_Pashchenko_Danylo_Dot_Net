using BusinessLogicLayer.Models;
using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services.Interface
{
    public interface IProjectService
    {
        Task<ProjectModel?> GetProjectAsync(Guid id);
        Task<ICollection<ProjectModel>?> GetAllProjectsAsync();
        Task<ProjectModel?> GetProjectWithUserAsync(Guid id);
        Task<ProjectModel?> GetProjectWithCategoriesAsync(Guid id);
        Task<ProjectModel?> GetProjectWithVoteAsync(Guid id);
        Task<ProjectModel?> GetProjectWithCommentaryAsync(Guid id);
        Task<ICollection<ProjectModel>?> GetAllProjectsWithUsersAsync();
    }
}
