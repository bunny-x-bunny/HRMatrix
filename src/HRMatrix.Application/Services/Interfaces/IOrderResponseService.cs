using HRMatrix.Application.DTOs.OrderResponse;
using HRMatrix.Domain.Entities;
using HRMatrix.Domain.Enums;

namespace HRMatrix.Application.Services.Interfaces {
    public interface IOrderResponseService {
        Task<int> CreateOrderResponse(CreateOrderResponseRequest request, Order order, bool withSave = false);
        Task<bool> UpdateResponseStatus(int responseId, ResponseStatus status, bool withSave = false);
        Task<bool> DeleteOrderResponse(int responseId, bool withSave = false);
    }
}
