using HRMatrix.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace HRMatrix.Domain.Configurations;

public class OrderReviewConfiguration : IEntityTypeConfiguration<OrderReview>
{
    public void Configure(EntityTypeBuilder<OrderReview> builder)
    {
        builder.HasKey(or => or.Id);

        builder.Property(or => or.Rating)
            .IsRequired();

        builder.Property(or => or.ReviewText)
            .HasMaxLength(1000);

        builder.Property(or => or.CreatedAt)
            .IsRequired();

        builder.HasOne(or => or.Order)
            .WithMany()
            .HasForeignKey(or => or.OrderId)
            .OnDelete(DeleteBehavior.Cascade);
            
        builder.Property(or => or.UserId)
            .IsRequired();
    }
}