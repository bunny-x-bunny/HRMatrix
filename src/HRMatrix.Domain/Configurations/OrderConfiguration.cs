using HRMatrix.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace HRMatrix.Domain.Configurations;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(o => o.Id);

        builder.Property(o => o.Title)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(o => o.Specialization)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(o => o.Description)
            .HasMaxLength(1000);

        builder.Property(o => o.CustomerEmail)
            .HasMaxLength(255);

        builder.Property(o => o.CustomerPhone)
            .HasMaxLength(20);

        builder.Property(o => o.CreatedAt)
            .IsRequired();

        builder.Property(o => o.ExpectedCompletionDate)
            .IsRequired();

        builder.Property(o => o.PaymentAmount)
            .IsRequired()
            .HasColumnType("decimal(18,2)");

        builder.Property(o => o.Status)
            .IsRequired();

        builder.HasOne(o => o.AssignedUserProfile)
            .WithMany()
            .HasForeignKey(o => o.AssignedUserProfileId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}