using HRMatrix.Application.DTOs.Common;
using HRMatrix.Application.DTOs.Order;
using HRMatrix.Domain.Enums;

namespace HRMatrix.Application.Services.Interfaces;

public interface IOrderService
{
    Task<List<OrderDto>> GetOrdersByUserIdAsync(int userId);

    Task<List<OrderDto>> GetRespondedOrdersByUserIdAsync(int userId);

    Task<OrderDto> GetOrderByIdAsync(int id);

    Task<int> CreateOrderAsync(CreateOrderDto orderDto, int createdByUserId);

    Task<int> UpdateOrderAsync(UpdateOrderDto orderDto);

    Task<bool> DeleteOrderAsync(int id);

    Task<int> RespondToOrderAsync(int orderId, int userId);

    Task<PaginatedResult<OrderDto>> GetFilteredOrdersAsync(string titleQuery = null, List<int> categoryIds = null, List<int> specializationIds = null, List<int> workTypeIds = null, List<int> cityIds = null,
        int pageNumber = 1,
        int pageSize = 10);

    Task<int> AddReviewToOrderAsync(int orderId, int userId, int rating, string reviewText);

    Task<List<OrderReviewDto>> GetReviewsByOrderIdAsync(int orderId);

    Task<bool> DeleteReviewAsync(int reviewId);

    Task<bool> UpdateResponseStatusAsync(int responseId, ResponseStatus status);
}