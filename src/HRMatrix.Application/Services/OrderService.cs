using AutoMapper;
using HRMatrix.Application.DTOs.Order;
using HRMatrix.Application.Services.Interfaces;
using HRMatrix.Domain.Entities;
using HRMatrix.Domain.Enums;
using HRMatrix.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace HRMatrix.Application.Services;

public class OrderService : IOrderService
{
    private readonly HRMatrixDbContext _context;
    private readonly IMapper _mapper;

    public OrderService(HRMatrixDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<OrderDto>> GetOrdersByUserIdAsync(int userId)
    {
        var orders = await _context.Orders
            .Include(o => o.AssignedUserProfile)
            .Where(o => o.CreatedByUserId == userId)
            .ToListAsync();

        var orderDtos = orders.Select(order => new OrderDto
        {
            Id = order.Id,
            Title = order.Title,
            Specialization = order.Specialization,
            ExpectedCompletionDate = order.ExpectedCompletionDate,
            PaymentAmount = order.PaymentAmount,
            Description = order.Description,
            CustomerEmail = order.CustomerEmail,
            CustomerPhone = order.CustomerPhone,
            CreatedAt = order.CreatedAt,
            Status = order.Status,
            CreatedByUserId = order.CreatedByUserId,
            AssignedUserProfileId = order.AssignedUserProfileId,
        }).ToList();

        return orderDtos;
    }

    public async Task<OrderDto> GetOrderByIdAsync(int id)
    {
        var order = await _context.Orders
            .Include(o => o.AssignedUserProfile)
            .FirstOrDefaultAsync(o => o.Id == id);

        if (order == null) return null;

        var orderDto = _mapper.Map<OrderDto>(order);
        return orderDto;
    }

    public async Task<int> CreateOrderAsync(CreateOrderDto orderDto, int createdByUserId)
    {
        var order = _mapper.Map<Order>(orderDto);
        order.CreatedByUserId = createdByUserId;
        order.CreatedAt = DateTime.UtcNow;
        order.Status = OrderStatus.Pending;

        _context.Orders.Add(order);
        await _context.SaveChangesAsync();
        return order.Id;
    }

    public async Task<int> UpdateOrderAsync(UpdateOrderDto orderDto)
    {
        var order = await _context.Orders
            .FirstOrDefaultAsync(o => o.Id == orderDto.Id);

        if (order == null) return 0;

        _mapper.Map(orderDto, order);
        await _context.SaveChangesAsync();
        return order.Id;
    }

    public async Task<bool> DeleteOrderAsync(int id)
    {
        var order = await _context.Orders.FindAsync(id);
        if (order == null) return false;

        _context.Orders.Remove(order);
        await _context.SaveChangesAsync();
        return true;
    }
}