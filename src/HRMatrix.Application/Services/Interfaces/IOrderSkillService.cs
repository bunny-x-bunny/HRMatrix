using HRMatrix.Application.DTOs.OrderSkill;
using HRMatrix.Domain.Entities;

namespace HRMatrix.Application.Services;

public interface IOrderSkillService {
    //Task<OrderSkillListResponse> GetOrderSkillsAsync(int orderId);
    Task<int> CreateOrderSkillsAsync(List<int> skillIds, Order order, bool withSave = false);
    Task<int> UpdateOrderSkillsAsync(List<int> skillIds, Order order, bool withSave = false);
    Task<bool> DeleteOrderSkillAsync(OrderSkill orderSkill, bool withSave = false);
}