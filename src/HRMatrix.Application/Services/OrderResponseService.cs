using HRMatrix.Application.DTOs.OrderResponse;
using HRMatrix.Application.Services.Interfaces;
using HRMatrix.Domain.Entities;
using HRMatrix.Domain.Enums;
using HRMatrix.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace HRMatrix.Application.Services;

public class OrderResponseService : IOrderResponseService {
    private readonly HRMatrixDbContext _context;

    public OrderResponseService(HRMatrixDbContext context) {
        _context = context;
    }

    public async Task<int> CreateOrderResponse(CreateOrderResponseRequest request, Order order, bool withSave = false) {
        var existingResponse = await _context.OrderResponses
            .FirstOrDefaultAsync(r => r.OrderId == order.Id && r.UserId == request.UserId);
        if (existingResponse != null)
            return existingResponse.Id;

        var response = new OrderResponse {
            OrderId = order.Id,
            UserId = request.UserId,
            CreatedAt = DateTime.UtcNow
        };

        _context.OrderResponses.Add(response);
        if (withSave)
            await _context.SaveChangesAsync();
        return response.Id;
    }

    public async Task<bool> UpdateResponseStatus(int responseId, ResponseStatus status, bool withSave = false) {
        var response = await _context.OrderResponses.FindAsync(responseId);
        if (response == null) return false;

        response.Status = status;
        if(withSave)
            await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteOrderResponse(int responseId, bool withSave = false) {
        var response = await _context.OrderResponses.FindAsync(responseId);
        if (response == null) return false;

        _context.OrderResponses.Remove(response);
        if (withSave)
            await _context.SaveChangesAsync();
        return true;
    }
}