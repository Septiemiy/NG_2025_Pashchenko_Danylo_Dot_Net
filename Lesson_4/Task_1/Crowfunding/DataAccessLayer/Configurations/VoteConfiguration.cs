using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Configurations
{
    public class VoteConfiguration : IEntityTypeConfiguration<Vote>
    {
        public void Configure(EntityTypeBuilder<Vote> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(u => u.User)
                .WithOne(v => v.Vote)
                .HasForeignKey<Vote>(x => x.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(p => p.Project)
                .WithOne(v => v.Vote)
                .HasForeignKey<Vote>(x => x.ProjectId);
        }
    }
}
