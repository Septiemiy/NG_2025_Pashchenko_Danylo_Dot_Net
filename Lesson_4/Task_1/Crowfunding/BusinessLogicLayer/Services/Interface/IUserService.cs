using BusinessLogicLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services.Interface
{
    public interface IUserService
    {
        Task<UserModel?> GetUserAsync(Guid id);
        Task<ICollection<UserModel>?> GetAllUsersAsync();
        Task<UserModel?> GetUserWithProjectsAsync(Guid id);
        Task<UserModel?> GetUserWithVoteAsync(Guid id);
        Task<UserModel?> GetUserWithCommentaryAsync(Guid id);
        Task<ICollection<UserModel>?> GetAllUsersWithProjectsAsync();
    }
}
