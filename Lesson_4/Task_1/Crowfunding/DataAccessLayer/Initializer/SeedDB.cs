using DataAccessLayer.DataBaseContext;
using DataAccessLayer.Entities;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Initializer
{
    public class SeedDB
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public SeedDB(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        public void SeedLocalDB()
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var userId1 = Guid.NewGuid();
                var userId2 = Guid.NewGuid();

                var projectId1 = Guid.NewGuid();
                var projectId2 = Guid.NewGuid();

                var categoryId1 = Guid.NewGuid();
                var categoryId2 = Guid.NewGuid();

                using (var context = scope.ServiceProvider.GetRequiredService<CrowdfundingDbContext>())
                {

                    if (!context.Users.Any())
                    {
                        var users = new List<User>
                        {
                            new User { Id = userId1, Username = "User1", SecondName = "SecondName1" },
                            new User { Id = userId2, Username = "User2", SecondName = "SecondName2" }
                        };

                        context.Users.AddRange(users);
                    }

                    if (!context.Projects.Any())
                    {
                        var projects = new List<Project>
                        {
                            new Project { Id = projectId1, Name = "Project1", CreatorId = userId1, CategoryId = categoryId1, CreationDate = DateTime.Now },
                            new Project { Id = projectId2, Name = "Project2", CreatorId = userId2, CategoryId = categoryId2, CreationDate = DateTime.Now }
                        };

                        context.Projects.AddRange(projects);
                    }

                    if (!context.Categories.Any())
                    {
                        var categories = new List<Category>
                        {
                            new Category { Id = categoryId1, Description = "Category1" },
                            new Category { Id = categoryId2, Description = "Category2" }
                        };

                        context.Categories.AddRange(categories);
                    }

                    if (!context.Comments.Any())
                    {
                        var comments = new List<Comment>
                        {
                            new Comment { Id = Guid.NewGuid(), Text = "Comment1", Date = DateTime.Now, UserId = userId1, ProjectId = projectId1 },
                            new Comment { Id = Guid.NewGuid(), Text = "Comment2", Date = DateTime.Now, UserId = userId2, ProjectId = projectId2 }
                        };

                        context.Comments.AddRange(comments);
                    }

                    if (!context.Votes.Any())
                    {
                        var votes = new List<Vote>
                        {
                            new Vote { Id = Guid.NewGuid(), UserId = userId1, ProjectId = projectId1 },
                            new Vote { Id = Guid.NewGuid(), UserId = userId2, ProjectId = projectId2 }
                        };

                        context.Votes.AddRange(votes);
                    }

                    context.SaveChanges();
                }
            }
        }
    }
}