using DataAccessLayer.DataBaseContext;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class CommentRepository : Repository<Comment>, ICommentRepository
    {
        private readonly CrowdfundingDbContext _ctx;
        public CommentRepository(CrowdfundingDbContext ctx) : base(ctx)
        {
            _ctx = ctx;
        }

        public async Task<ICollection<Comment>?> GetAllCommentsWithProjectsAsync()
        {
            return await _ctx.Comments.Include(x => x.Project).ToListAsync();
        }

        public async Task<ICollection<Comment>?> GetAllCommentsWithUsersAsync()
        {
            return await _ctx.Comments.Include(x => x.User).ToListAsync();
        }

        public async Task<ICollection<Comment>?> GetCommentsByProjectId(Guid projectId)
        {
            return await _ctx.Comments.Include(x => x.Project).Where(x => x.ProjectId.Equals(projectId)).ToListAsync();
        }

        public async Task<ICollection<Comment>?> GetCommentsByUserId(Guid userId)
        {
            return await _ctx.Comments.Include(x => x.User).Where(x => x.UserId.Equals(userId)).ToListAsync();
        }
    }
}
