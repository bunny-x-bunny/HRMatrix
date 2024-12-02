using HRMatrix.Application.DTOs.OrderReview;
using HRMatrix.Domain.Entities;

namespace HRMatrix.Application.Services.Interfaces;

public interface IOrderReviewService {
    Task<int> CreateOrderReview(CreateOrderReviewRequest request, Order order, bool withSave = false);
    Task<bool> UpdateOrderReview(int reviewId, string reviewText, bool withSave = false);
    Task<bool> DeleteOrderReview(int reviewId, bool withSave = false);
}
