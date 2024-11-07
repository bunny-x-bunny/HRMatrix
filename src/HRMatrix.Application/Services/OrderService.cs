using AutoMapper;
using HRMatrix.Application.DTOs.City;
using HRMatrix.Application.DTOs.Common;
using HRMatrix.Application.DTOs.Order;
using HRMatrix.Application.DTOs.Skill;
using HRMatrix.Application.DTOs.Specialization;
using HRMatrix.Application.DTOs.WorkType;
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

    public async Task<PagedResult<OrderDto>> GetFilteredOrdersAsync(string titleQuery = null,
                    List<int> categoryIds = null,
                    List<int> specializationIds = null,
                    List<int> workTypeIds = null,
                    List<int> cityIds = null,
                    int pageNumber = 1,
                    int pageSize = 10)
    {
        var query = _context.Orders
            .Include(o => o.OrderSkills)
                .ThenInclude(os => os.Skill)
                .ThenInclude(s => s.Translations)
            .Include(o => o.OrderSkills)
                .ThenInclude(os => os.Skill)
                .ThenInclude(s => s.Specialization)
                .ThenInclude(spec => spec.Translations)
            .Include(o => o.OrderWorkTypes)
                .ThenInclude(owt => owt.WorkType)
                .ThenInclude(wt => wt.Translations)
            .Include(o => o.City)
                .ThenInclude(c => c.Translations)
            .AsQueryable();

        if (!string.IsNullOrWhiteSpace(titleQuery))
        {
            var tokens = titleQuery.ToUpper().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            foreach (var token in tokens)
            {
                query = query.Where(o => EF.Functions.Like(o.Title.ToUpper(), $"%{token}%"));
            }
        }

        if (specializationIds != null && specializationIds.Any())
        {
            query = query.Where(o => o.OrderSkills.Any(os => specializationIds.Contains(os.Skill.SpecializationId.Value)));
        }

        if (workTypeIds != null && workTypeIds.Any())
        {
            query = query.Where(o => o.OrderWorkTypes.Any(owt => workTypeIds.Contains(owt.WorkTypeId)));
        }

        if (categoryIds != null && categoryIds.Any())
        {
            query = query.Where(x => x.OrderSkills.Any(owt => categoryIds.Contains(owt.SkillId)));
        }

        if (cityIds != null && cityIds.Any())
        {
            query = query.Where(o => cityIds.Contains(o.CityId.Value));
        }

        // Получаем общее количество записей
        int totalCount = await query.CountAsync();

        // Применяем пагинацию
        query = query.Skip((pageNumber - 1) * pageSize).Take(pageSize);

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
            City = order.City != null ? new CityDto
            {
                Id = order.City.Id,
                Name = order.City.Name,
                Translations = order.City.Translations.Select(t => new CityTranslationDto
                {
                    Id = t.Id,
                    Name = t.Name,
                    LanguageCode = t.LanguageCode
                }).ToList()
            } : null,
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
            }).ToList(),
            WorkTypes = order.OrderWorkTypes.Select(owt => new WorkTypeDto
            {
                Id = owt.WorkType.Id,
                Name = owt.WorkType.Name,
                Translations = owt.WorkType.Translations.Select(t => new WorkTypeTranslationDto
                {
                    Id = t.Id,
                    Name = t.Name,
                    LanguageCode = t.LanguageCode
                }).ToList()
            }).ToList()
        }).ToList();

        return new PagedResult<OrderDto>(orderDtos, totalCount);
    }



    public async Task<List<OrderDto>> GetOrdersByUserIdAsync(int userId)
    {
        var orders = await _context.Orders
            .Include(o => o.OrderSkills)
                .ThenInclude(os => os.Skill)
                .ThenInclude(s => s.Translations)
            .Include(o => o.OrderSkills)
                .ThenInclude(os => os.Skill)
                .ThenInclude(s => s.Specialization)
                .ThenInclude(spec => spec.Translations)
            .Include(o => o.OrderWorkTypes)
                .ThenInclude(owt => owt.WorkType)
                .ThenInclude(wt => wt.Translations)
            .Include(o => o.City)
                .ThenInclude(c => c.Translations)
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
            City = order.City != null ? new CityDto
            {
                Id = order.City.Id,
                Name = order.City.Name,
                Translations = order.City.Translations.Select(t => new CityTranslationDto
                {
                    Id = t.Id,
                    Name = t.Name,
                    LanguageCode = t.LanguageCode
                }).ToList()
            } : null,
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
            }).ToList(),
            WorkTypes = order.OrderWorkTypes.Select(owt => new WorkTypeDto
            {
                Id = owt.WorkType.Id,
                Name = owt.WorkType.Name,
                Translations = owt.WorkType.Translations.Select(t => new WorkTypeTranslationDto
                {
                    Id = t.Id,
                    Name = t.Name,
                    LanguageCode = t.LanguageCode
                }).ToList()
            }).ToList()
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
            .Include(o => o.OrderWorkTypes)
                .ThenInclude(owt => owt.WorkType)
                .ThenInclude(wt => wt.Translations)
            .Include(o => o.City)
                .ThenInclude(c => c.Translations)
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

        orderDto.WorkTypes = order.OrderWorkTypes.Select(owt => new WorkTypeDto
        {
            Id = owt.WorkType.Id,
            Name = owt.WorkType.Name,
            Translations = owt.WorkType.Translations.Select(t => new WorkTypeTranslationDto
            {
                Id = t.Id,
                Name = t.Name,
                LanguageCode = t.LanguageCode
            }).ToList()
        }).ToList();

        orderDto.City = new CityDto
        {
            Id = order.City.Id,
            Name = order.City.Name,
            Translations = order.City.Translations.Select(t => new CityTranslationDto
            {
                Id = t.Id,
                Name = t.Name,
                LanguageCode = t.LanguageCode
            }).ToList()
        };

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

        order.OrderWorkTypes = orderDto.WorkTypeIds.Select(workTypeId => new OrderWorkType
        {
            WorkTypeId = workTypeId
        }).ToList();

        if (orderDto.CityId.HasValue)
        {
            order.CityId = orderDto.CityId.Value;
        }

        _context.Orders.Add(order);
        await _context.SaveChangesAsync();
        return order.Id;
    }

    public async Task<int> UpdateOrderAsync(UpdateOrderDto orderDto)
    {
        var order = await _context.Orders
            .Include(o => o.OrderSkills)
            .Include(o => o.OrderWorkTypes)
            .FirstOrDefaultAsync(o => o.Id == orderDto.Id);

        if (order == null) return 0;

        _mapper.Map(orderDto, order);

        order.OrderSkills.Clear();
        foreach (var skillId in orderDto.SkillIds)
            order.OrderSkills.Add(new OrderSkill { SkillId = skillId });

        order.OrderWorkTypes.Clear();
        foreach (var workTypeId in orderDto.WorkTypeIds)
            order.OrderWorkTypes.Add(new OrderWorkType { WorkTypeId = workTypeId });

        if (orderDto.CityId.HasValue)
            order.CityId = orderDto.CityId.Value;

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

    public async Task<int> AddReviewToOrderAsync(int orderId, int userId, int rating, string reviewText)
    {
        var order = await _context.Orders.FindAsync(orderId);
        if (order == null) return 0;

        var review = new OrderReview
        {
            OrderId = orderId,
            UserId = userId,
            Rating = rating,
            ReviewText = reviewText,
            CreatedAt = DateTime.UtcNow
        };

        _context.OrderReviews.Add(review);
        await _context.SaveChangesAsync();
        return review.Id;
    }

    public async Task<List<OrderReviewDto>> GetReviewsByOrderIdAsync(int orderId)
    {
        var reviews = await _context.OrderReviews
            .Where(r => r.OrderId == orderId)
            .Select(r => new OrderReviewDto
            {
                Id = r.Id,
                OrderId = r.OrderId,
                UserId = r.UserId,
                Rating = r.Rating,
                ReviewText = r.ReviewText,
                CreatedAt = r.CreatedAt
            })
            .ToListAsync();

        return reviews;
    }

    public async Task<bool> DeleteReviewAsync(int reviewId)
    {
        var review = await _context.OrderReviews.FindAsync(reviewId);
        if (review == null) return false;

        _context.OrderReviews.Remove(review);
        await _context.SaveChangesAsync();
        return true;
    }
}