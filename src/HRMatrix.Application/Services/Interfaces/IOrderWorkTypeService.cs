using HRMatrix.Application.DTOs.OrderWorkType;
using HRMatrix.Domain.Entities;

namespace HRMatrix.Application.Services.Interfaces {
    public interface IOrderWorkTypeService {
        //Task<List<OrderWorkTypeResponse>> GetOrderWorkTypes(Order order);
        Task<int> CreateOrderWorkType(CreateOrderWorkTypeRequest workTypeDto, Order order, bool withSave = false);
        Task<List<int>> UpsertOrderWorkTypes(List<int> workTypes, Order order, bool withSave = false);
        Task<bool> DeleteOrderWorkType(int orderWorkTypeId, bool withSave = false);
    }
}