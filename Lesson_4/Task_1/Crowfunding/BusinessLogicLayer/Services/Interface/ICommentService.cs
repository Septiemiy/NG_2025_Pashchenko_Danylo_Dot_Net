using BusinessLogicLayer.Models;
using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services.Interface
{
    public interface ICommentService
    {
        Task<CommentModel?> GetCommentAsync(Guid id);
        Task<ICollection<CommentModel>?> GetAllCommentsAsync();
        Task<ICollection<CommentModel>?> GetCommentsByProjectIdAsync(Guid projectId);
        Task<ICollection<CommentModel>?> GetCommentsByUserIdAsync(Guid userId);
        Task<ICollection<CommentModel>?> GetAllCommentsWithUsersAsync();
        Task<ICollection<CommentModel>?> GetAllCommentsWithProjectsAsync();
    }
}
