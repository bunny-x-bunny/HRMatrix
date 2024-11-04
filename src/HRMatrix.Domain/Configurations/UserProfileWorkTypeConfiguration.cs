using HRMatrix.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMatrix.Domain.Configurations
{
    public class UserProfileWorkTypeConfiguration : IEntityTypeConfiguration<UserProfileWorkType>
    {
        public void Configure(EntityTypeBuilder<UserProfileWorkType> builder)
        {
            builder.HasKey(uwt => uwt.Id);

            builder.HasOne(uwt => uwt.UserProfile)
                .WithMany(up => up.UserProfileWorkTypes)
                .HasForeignKey(uwt => uwt.UserProfileId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(uwt => uwt.WorkType)
                .WithMany()
                .HasForeignKey(uwt => uwt.WorkTypeId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
