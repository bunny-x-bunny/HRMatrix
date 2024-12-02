using HRMatrix.Application.DTOs.OrderSkill;
using HRMatrix.Domain.Entities;
using HRMatrix.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace HRMatrix.Application.Services;

public class OrderSkillService : IOrderSkillService {
    private readonly HRMatrixDbContext _context;

    public OrderSkillService(HRMatrixDbContext context) {
        _context = context;
    }

    public async Task<int> UpsertOrderSkillsAsync(CreateOrderSkillsRequest skillsRequest, bool withSave = false) { 
        var order = await _context.Orders
            .Include(o => o.OrderSkills)
            .Where(o => o.Id == skillsRequest.OrderId)
            .FirstOrDefaultAsync();

        if (order == null) {
            throw new Exception($"Order with ID {skillsRequest.OrderId} not found.");
        }

        order.OrderSkills.Clear();

        order.OrderSkills = skillsRequest.SkillIds.Select(skillId => new OrderSkill {
            OrderId = skillsRequest.OrderId,
            SkillId = skillId
        }).ToList();

        if (withSave)
            await _context.SaveChangesAsync();

        return skillsRequest.OrderId;
    }

    public async Task<bool> DeleteOrderSkillAsync(OrderSkill orderSkill, bool withSave = false) {
        var order = await _context.Orders
            .Include(o => o.OrderSkills)
            .Where(o => o.Id == orderSkill.OrderId)
            .FirstOrDefaultAsync();

        if (order == null) {
            throw new Exception($"Order with ID {orderSkill.OrderId} not found.");
        }
        order.OrderSkills.Remove(order.OrderSkills.Where(os => os.SkillId == orderSkill.SkillId).First());
        if (withSave)
            await _context.SaveChangesAsync();
        return true;
    }
}