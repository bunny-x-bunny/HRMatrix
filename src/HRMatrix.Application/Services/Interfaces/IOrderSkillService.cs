using HRMatrix.Application.DTOs.OrderSkill;
using HRMatrix.Domain.Entities;

namespace HRMatrix.Application.Services;

public interface IOrderSkillService {
    //Task<OrderSkillListResponse> GetOrderSkillsAsync(int orderId);
    Task<int> UpsertOrderSkillsAsync(CreateOrderSkillsRequest skillsRequest, bool withSave = false);
    Task<bool> DeleteOrderSkillAsync(OrderSkill orderSkill, bool withSave = false);
}