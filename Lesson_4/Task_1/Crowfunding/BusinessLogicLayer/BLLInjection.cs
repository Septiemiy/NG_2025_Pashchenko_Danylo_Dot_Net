using BusinessLogicLayer.Mapping;
using BusinessLogicLayer.Services;
using BusinessLogicLayer.Services.Interface;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public static class BLLInjection
    {
        public static void AddBusinessLogicLayer(
            this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AutoMapBLLProfile));
            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<IProjectService, ProjectService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IVoteService, VoteService>();
        }
    }
}
