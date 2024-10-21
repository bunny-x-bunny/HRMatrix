using HRMatrix.Application.DTOs.Order;

namespace HRMatrix.Application.Services.Interfaces;

public interface IOrderService
{
    Task<List<OrderDto>> GetOrdersByUserIdAsync(int userId);

    Task<OrderDto> GetOrderByIdAsync(int id);

    Task<int> CreateOrderAsync(CreateOrderDto orderDto, int createdByUserId);

    Task<int> UpdateOrderAsync(UpdateOrderDto orderDto);

    Task<bool> DeleteOrderAsync(int id);
}