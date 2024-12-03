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

    public async Task<int> UpsertOrderSkillsAsync(List<int> skillIds, Order order, bool withSave = false) {
        if (order.Id != 0) {
            var existingSkills = await _context.OrderSkill
                .Where(os => os.OrderId == order.Id)
                .ToListAsync();
            _context.OrderSkill.RemoveRange(existingSkills);
        }

        order.OrderSkills = skillIds.Select(skillId => new OrderSkill {
            OrderId = order.Id,
            SkillId = skillId
        }).ToList();

        if (withSave)
            await _context.SaveChangesAsync();

        return order.Id;
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