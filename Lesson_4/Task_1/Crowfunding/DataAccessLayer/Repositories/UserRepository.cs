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
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly CrowdfundingDbContext _ctx;

        public UserRepository(CrowdfundingDbContext ctx) : base(ctx)
        {
            _ctx = ctx;
        }

        public async Task<ICollection<User>> GetAllUsersWithProjectsAsync()
        {
            return await _ctx.Users.Include(x => x.Projects).ToListAsync();
        }

        public async Task<User?> GetUserWithCommentaryAsync(Guid id)
        {
            return await _ctx.Users.Include(x => x.Comments).FirstOrDefaultAsync(x => x.Id.Equals(id));
        }

        public async Task<User?> GetUserWithVoteAsync(Guid id)
        {
            return await _ctx.Users.Include(x => x.Vote).FirstOrDefaultAsync(x => x.Id.Equals(id));
        }

        public async Task<User?> GetUserWithProjectsAsync(Guid id)
        {
            return await _ctx.Users.Include(x => x.Projects).FirstOrDefaultAsync(x => x.Id.Equals(id));
        }
    }
}
