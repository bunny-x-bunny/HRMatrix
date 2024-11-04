using HRMatrix.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace HRMatrix.Domain.Configurations;

public class OrderWorkTypeConfiguration : IEntityTypeConfiguration<OrderWorkType>
{
    public void Configure(EntityTypeBuilder<OrderWorkType> builder)
    {
        builder.HasKey(owt => owt.Id);

        builder.HasOne(owt => owt.Order)
            .WithMany(o => o.OrderWorkTypes)
            .HasForeignKey(owt => owt.OrderId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(owt => owt.WorkType)
            .WithMany()
            .HasForeignKey(owt => owt.WorkTypeId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}