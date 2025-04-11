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
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly CrowdfundingDbContext _ctx;
        public CategoryRepository(CrowdfundingDbContext ctx) : base(ctx)
        {
            _ctx = ctx;
        }

        public async Task<ICollection<Category>?> GetAllCategoriesWithProjectsAsync()
        {
            return await _ctx.Categories.Include(x => x.Projects).ToListAsync();
        }

        public async Task<Category?> GetCategoryWithProjectsAsync(Guid id)
        {
            return await _ctx.Categories.Include(x => x.Projects).FirstOrDefaultAsync(x => x.Id.Equals(id));
        }
    }
}
