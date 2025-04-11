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
    public class ProjectRepository : Repository<Project>, IProjectRepository
    {
        private readonly CrowdfundingDbContext _ctx;
        public ProjectRepository(CrowdfundingDbContext ctx) : base(ctx)
        {
            _ctx = ctx;
        }

        public async Task<ICollection<Project>?> GetAllProjectsWithUsersAsync()
        {
            return await _ctx.Projects.Include(x => x.User).ToListAsync();
        }

        public async Task<Project?> GetProjectWithCategoriesAsync(Guid id)
        {
            return await _ctx.Projects.Include(x => x.Categories).FirstOrDefaultAsync(x => x.Id.Equals(id));
        }

        public async Task<Project?> GetProjectWithCommentaryAsync(Guid id)
        {
            return await _ctx.Projects.Include(x => x.Comments).FirstOrDefaultAsync(x => x.Id.Equals(id));
        }

        public async Task<Project?> GetProjectWithUserAsync(Guid id)
        {
            return await _ctx.Projects.Include(x => x.User).FirstOrDefaultAsync(x => x.CreatorId.Equals(id));
        }

        public async Task<Project?> GetProjectWithVoteAsync(Guid id)
        {
            return await _ctx.Projects.Include(x => x.Vote).FirstOrDefaultAsync(x => x.Id.Equals(id));
        }
    }
}
