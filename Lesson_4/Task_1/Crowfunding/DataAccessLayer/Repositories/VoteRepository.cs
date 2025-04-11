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
    public class VoteRepository : Repository<Vote>, IVoteRepository
    {
        private readonly CrowdfundingDbContext _ctx;

        public VoteRepository(CrowdfundingDbContext ctx) : base(ctx)
        {
            _ctx = ctx;
        }

        public async Task<Vote?> GetVoteByUserIdAndProjectIdAsync(Guid userId, Guid projectId)
        {
            return await _ctx.Votes.Include(x => x.User).Include(x => x.Project).FirstOrDefaultAsync(x => x.UserId.Equals(userId) && x.ProjectId.Equals(projectId));
        }

        public async Task<ICollection<Vote>?> GetVotesByProjectIdAsync(Guid projectId)
        {
            return await _ctx.Votes.Include(x => x.Project).Where(x => x.ProjectId.Equals(projectId)).ToListAsync();
        }

        public async Task<ICollection<Vote>?> GetVotesByUserIdAsync(Guid userId)
        {
            return await _ctx.Votes.Include(x => x.User).Where(x => x.UserId.Equals(userId)).ToListAsync();
        }
    }
}
