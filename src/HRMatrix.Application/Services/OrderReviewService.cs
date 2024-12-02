using HRMatrix.Application.DTOs.OrderReview;
using HRMatrix.Application.Services.Interfaces;
using HRMatrix.Domain.Entities;
using HRMatrix.Persistence.Contexts;

namespace HRMatrix.Application.Services;

public class OrderReviewService : IOrderReviewService {
    private readonly HRMatrixDbContext _context;

    public OrderReviewService(HRMatrixDbContext context) {
        _context = context;
    }

    public async Task<int> CreateOrderReview(CreateOrderReviewRequest request, Order order, bool withSave = false) {
        var review = new OrderReview {
            OrderId = order.Id,
            UserId = request.userId,
            Rating = request.rating,
            ReviewText = request.reviewText,
            CreatedAt = DateTime.UtcNow
        };
        _context.OrderReviews.Add(review);
        if (withSave)
            await _context.SaveChangesAsync();
        return review.Id;
    }
    public async Task<bool> UpdateOrderReview(int reviewId, string reviewText, bool withSave = false) {
        var review = await _context.OrderReviews.FindAsync(reviewId);
        if (review == null)
            throw new Exception($"Review with ID {reviewId} not found.");
        review.ReviewText = reviewText;
        if (withSave)
            await _context.SaveChangesAsync();
        return true;
    }
    public async Task<bool> DeleteOrderReview(int reviewId, bool withSave = false) {
        var review = await _context.OrderReviews.FindAsync(reviewId);
        if (review == null)
            return false;
        _context.OrderReviews.Remove(review);
        if (withSave)
            await _context.SaveChangesAsync();
        return true;
    }
}
