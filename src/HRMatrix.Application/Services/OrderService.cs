﻿using AutoMapper;
using HRMatrix.Application.DTOs.Order;
using HRMatrix.Application.DTOs.Skill;
using HRMatrix.Application.DTOs.Specialization;
using HRMatrix.Application.Services.Interfaces;
using HRMatrix.Domain.Entities;
using HRMatrix.Domain.Enums;
using HRMatrix.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

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

    public async Task<int> RespondToOrderAsync(int orderId, int userId)
    {
        var order = await _context.Orders.FindAsync(orderId);
        if (order == null) return 0;
        
        var existingResponse = await _context.OrderResponses
            .FirstOrDefaultAsync(r => r.OrderId == orderId && r.UserId == userId);
        if (existingResponse != null)
        {
            return existingResponse.Id;
        }
        
        var response = new OrderResponse
        {
            OrderId = orderId,
            UserId = userId,
            CreatedAt = DateTime.UtcNow
        };

        _context.OrderResponses.Add(response);
        await _context.SaveChangesAsync();
        return response.Id;
    }

    public async Task<List<OrderDto>> GetFilteredOrdersAsync(
        List<int> categoryIds = null,
        List<int> specializationIds = null,
        string workType = null,
        string location = null)
    {
        var query = _context.Orders
             .Include(o => o.OrderSkills)
                 .ThenInclude(os => os.Skill)
                 .ThenInclude(s => s.Translations)
             .Include(o => o.OrderSkills)
                 .ThenInclude(os => os.Skill)
                 .ThenInclude(s => s.Specialization)
                 .ThenInclude(spec => spec.Translations)
             .AsQueryable();

        // Фильтрация по специализациям
        if (specializationIds != null && specializationIds.Any())
        {
            query = query.Where(o => o.OrderSkills.Any(os => specializationIds.Contains(os.Skill.SpecializationId.Value)));
        }

        //// Фильтрация по типу работы
        //if (!string.IsNullOrEmpty(workType))
        //{
        //    query = query.Where(o => o.WorkType == workType);
        //}

        // Фильтрация по локации
        if (!string.IsNullOrEmpty(location))
        {
            query = query.Where(o => o.Location == location);
        }

        //// Применение сортировки
        //query = sortBy switch
        //{
        //    "Лучшие" => query.OrderByDescending(o => o.Rating),
        //    "Самые популярные" => query.OrderByDescending(o => o.Views),
        //    _ => query
        //};

        // Выполняем запрос и вручную маппим результат
        var orders = await query.ToListAsync();

        var orderDtos = orders.Select(order => new OrderDto
        {
            Id = order.Id,
            Title = order.Title,
            PaymentAmount = order.PaymentAmount,
            Description = order.Description,
            CustomerEmail = order.CustomerEmail,
            CustomerPhone = order.CustomerPhone,
            CreatedAt = order.CreatedAt,
            Status = order.Status,
            CreatedByUserId = order.CreatedByUserId,
            AssignedUserProfileId = order.AssignedUserProfileId,
            Location = order.Location,
            Skills = order.OrderSkills.Select(os => new SkillDto
            {
                Id = os.Skill.Id,
                Name = os.Skill.Name,
                Translations = os.Skill.Translations.Select(t => new SkillTranslationDto
                {
                    Id = t.Id,
                    Name = t.Name,
                    LanguageCode = t.LanguageCode
                }).ToList(),
                Specialization = new SpecializationDto
                {
                    Id = os.Skill.Specialization.Id,
                    Name = os.Skill.Specialization.Name,
                    Translations = os.Skill.Specialization.Translations.Select(st => new SpecializationTranslationDto
                    {
                        Id = st.Id,
                        Name = st.Name,
                        LanguageCode = st.LanguageCode
                    }).ToList()
                }
            }).ToList()
        }).ToList();

        return orderDtos;
    }


    public async Task<List<OrderDto>> GetOrdersByUserIdAsync(int userId)
    {
        var orders = await _context.Orders
            .Include(o => o.AssignedUserProfile)
            .Include(o => o.OrderSkills)
                .ThenInclude(os => os.Skill)
            .Where(o => o.CreatedByUserId == userId)
            .ToListAsync();

        var orderDtos = orders.Select(order => new OrderDto
        {
            Id = order.Id,
            Title = order.Title,
            PaymentAmount = order.PaymentAmount,
            Description = order.Description,
            CustomerEmail = order.CustomerEmail,
            CustomerPhone = order.CustomerPhone,
            CreatedAt = order.CreatedAt,
            Status = order.Status,
            CreatedByUserId = order.CreatedByUserId,
            AssignedUserProfileId = order.AssignedUserProfileId,
            Location = order.Location
        }).ToList();

        return orderDtos;
    }

    public async Task<OrderDto> GetOrderByIdAsync(int id)
    {
        var order = await _context.Orders
            .Include(o => o.OrderSkills)
            .ThenInclude(os => os.Skill)
            .ThenInclude(s => s.Translations)
            .Include(o => o.OrderSkills)
            .ThenInclude(os => os.Skill)
            .ThenInclude(s => s.Specialization)
            .ThenInclude(spec => spec.Translations)
            .FirstOrDefaultAsync(o => o.Id == id);

        if (order == null) return null;

        var orderDto = _mapper.Map<OrderDto>(order);
        
        orderDto.Skills = order.OrderSkills.Select(os => new SkillDto
        {
            Id = os.Skill.Id,
            Name = os.Skill.Name,
            Translations = os.Skill.Translations.Select(t => new SkillTranslationDto
            {
                Id = t.Id,
                Name = t.Name,
                LanguageCode = t.LanguageCode
            }).ToList(),
            Specialization = new SpecializationDto
            {
                Id = os.Skill.Specialization.Id,
                Name = os.Skill.Specialization.Name,
                Translations = os.Skill.Specialization.Translations.Select(st => new SpecializationTranslationDto
                {
                    Id = st.Id,
                    Name = st.Name,
                    LanguageCode = st.LanguageCode
                }).ToList()
            }
        }).ToList();

        return orderDto;
    }

    public async Task<int> CreateOrderAsync(CreateOrderDto orderDto, int createdByUserId)
    {
        var order = _mapper.Map<Order>(orderDto);
        order.CreatedByUserId = createdByUserId;
        order.CreatedAt = DateTime.UtcNow;
        order.Status = OrderStatus.Pending;
        
        order.OrderSkills = orderDto.SkillIds.Select(skillId => new OrderSkill
        {
            SkillId = skillId
        }).ToList();

        _context.Orders.Add(order);
        await _context.SaveChangesAsync();
        return order.Id;
    }

    public async Task<int> UpdateOrderAsync(UpdateOrderDto orderDto)
    {
        var order = await _context.Orders
            .Include(o => o.OrderSkills)
            .FirstOrDefaultAsync(o => o.Id == orderDto.Id);

        if (order == null) return 0;

        _mapper.Map(orderDto, order);
        
        order.OrderSkills.Clear();
        foreach (var skillId in orderDto.SkillIds)
            order.OrderSkills.Add(new OrderSkill { SkillId = skillId });

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