using AutoMapper;
using HRMatrix.Application.DTOs.City;
using HRMatrix.Application.DTOs.Common;
using HRMatrix.Application.DTOs.Competency;
using HRMatrix.Application.DTOs.EducationLevel;
using HRMatrix.Application.DTOs.Order;
using HRMatrix.Application.DTOs.Skill;
using HRMatrix.Application.DTOs.Specialization;
using HRMatrix.Application.DTOs.UserProfile;
using HRMatrix.Application.DTOs.UserProfileCompetency;
using HRMatrix.Application.DTOs.UserProfileEducation;
using HRMatrix.Application.DTOs.UserProfileSkills;
using HRMatrix.Application.DTOs.UserProfileWorkType;
using HRMatrix.Application.DTOs.OrderReview;
using HRMatrix.Application.DTOs.WorkType;
using HRMatrix.Application.DTOs.OrderResponse;
using HRMatrix.Application.Extensions;
using HRMatrix.Application.Services.Interfaces;
using HRMatrix.Domain.Entities;
using HRMatrix.Domain.Enums;
using HRMatrix.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;

namespace HRMatrix.Application.Services;

public class OrderService : IOrderService
{
    private readonly HRMatrixDbContext _context;
    private readonly IMapper _mapper;
    private readonly IOrderResponseService _responseService;
    private readonly IOrderReviewService _reviewService;
    private readonly IOrderWorkTypeService _workTypeService;
    private readonly IOrderSkillService _skillService;

    public OrderService(
        HRMatrixDbContext context,
        IMapper mapper,
        IOrderResponseService responseService,
        IOrderSkillService skillService,
        IOrderWorkTypeService workTypeService,
        IOrderReviewService reviewService) {
        _context = context;
        _mapper = mapper;
        _responseService = responseService;
        _skillService = skillService;
        _workTypeService = workTypeService;
        _reviewService = reviewService;
    }

    public async Task<int> RespondToOrderAsync(int orderId, int userId)
    {
        var order = await _context.Orders.FindAsync(orderId);
        if (order == null)
            throw new Exception($"Order with ID {orderId} not found.");
        return await _responseService.CreateOrderResponse(new CreateOrderResponseRequest {
            UserId = userId
        }, order, true);
    }

    public async Task<PaginatedResult<OrderDto>> GetFilteredOrdersAsync(
        string titleQuery = null,
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
            .AsNoTracking();

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
            query = query.Where(o =>
                o.OrderSkills.Any(os => specializationIds.Contains(os.Skill.SpecializationId.Value)));
        }

        if (workTypeIds != null && workTypeIds.Any())
        {
            query = query.Where(o => o.OrderWorkTypes.Any(owt => workTypeIds.Contains(owt.WorkTypeId)));
        }

        if (categoryIds != null && categoryIds.Any())
        {
            query = query.Where(o => o.OrderSkills.Any(os => categoryIds.Contains(os.SkillId)));
        }

        if (cityIds != null && cityIds.Any())
        {
            query = query.Where(o => cityIds.Contains(o.CityId.Value));
        }

        var totalItems = await query.CountAsync();

        var orders = await query
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .Select(order => new OrderDto
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
                City = order.City != null
                    ? new CityDto
                    {
                        Id = order.City.Id,
                        Name = order.City.Name,
                        Translations = order.City.Translations.Select(t => new CityTranslationDto
                        {
                            Id = t.Id,
                            Name = t.Name,
                            LanguageCode = t.LanguageCode
                        }).ToList()
                    }
                    : null,
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
                    Specialization = os.Skill.Specialization != null
                        ? new SpecializationDto
                        {
                            Id = os.Skill.Specialization.Id,
                            Name = os.Skill.Specialization.Name,
                            Translations = os.Skill.Specialization.Translations.Select(st =>
                                new SpecializationTranslationDto
                                {
                                    Id = st.Id,
                                    Name = st.Name,
                                    LanguageCode = st.LanguageCode
                                }).ToList()
                        }
                        : null
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
            })
            .ToListAsync();

        return new PaginatedResult<OrderDto>
        {
            Items = orders,
            TotalItems = totalItems,
            Page = pageNumber,
            PageSize = pageSize,
            TotalPages = (int)Math.Ceiling(totalItems / (double)pageSize)
        };
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
            City = order.City != null
                ? new CityDto
                {
                    Id = order.City.Id,
                    Name = order.City.Name,
                    Translations = order.City.Translations.Select(t => new CityTranslationDto
                    {
                        Id = t.Id,
                        Name = t.Name,
                        LanguageCode = t.LanguageCode
                    }).ToList()
                }
                : null,
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

    public async Task<List<OrderDto>> GetRespondedOrdersByUserIdAsync(int userId)
    {
        var orders = await _context.Orders
            .Include(o => o.OrderResponses)
            .ThenInclude(r => r.UserId) // Загружаем пользователя, который оставил отклик
            .Include(o => o.OrderSkills)
            .ThenInclude(os => os.Skill)
            .Include(o => o.OrderWorkTypes)
            .ThenInclude(owt => owt.WorkType)
            .Include(o => o.City)
            .Where(o => o.OrderResponses.Any(r => r.UserId == userId))
            .ToListAsync();

        var orderDtos = orders.Select(order => new OrderDto
        {
            Id = order.Id,
            Title = order.Title,
            ExpectedCompletionDate = order.ExpectedCompletionDate!.Value,
            PaymentAmount = order.PaymentAmount,
            Description = order.Description,
            CustomerEmail = order.CustomerEmail,
            CustomerPhone = order.CustomerPhone,
            CreatedAt = order.CreatedAt,
            Status = order.Status,
            CreatedByUserId = order.CreatedByUserId,
            AssignedUserProfileId = order.AssignedUserProfileId,
            City = order.City != null
                ? new CityDto
                {
                    Id = order.City.Id,
                    Name = order.City.Name
                }
                : null,
            Skills = order.OrderSkills.Select(os => new SkillDto
            {
                Id = os.Skill.Id,
                Name = os.Skill.Name
            }).ToList(),
            WorkTypes = order.OrderWorkTypes.Select(owt => new WorkTypeDto
            {
                Id = owt.WorkType.Id,
                Name = owt.WorkType.Name
            }).ToList(),

            Responses = order.OrderResponses.Select(response => new ResponseDto
            {
                Id = response.Id,
                UserId = response.UserId,
                Status = response.Status,
                StatusName = response.Status.GetDisplayName(),
                CreatedAt = response.CreatedAt
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
        var order = new Order {
            Title = orderDto.Title,
            ExpectedCompletionDate = orderDto.ExpectedCompletionDate,
            PaymentAmount = orderDto.PaymentAmount,
            Description = orderDto.Description,
            CustomerEmail = orderDto.CustomerEmail,
            CustomerPhone = orderDto.CustomerPhone,
            AssignedUserProfileId = orderDto.AssignedUserProfileId,
            CreatedByUserId = createdByUserId,
            CreatedAt = DateTime.UtcNow,
            Status = OrderStatus.Pending
        };

        if (orderDto.CityId.HasValue)
            order.CityId = orderDto.CityId.Value;

        await _skillService.UpsertOrderSkillsAsync(orderDto.SkillIds, order);
        await _workTypeService.UpsertOrderWorkTypes(orderDto.WorkTypeIds, order);

        _context.Orders.Add(order);
        await _context.SaveChangesAsync();
        return order.Id;
    }

    public async Task<int> UpdateOrderAsync(UpdateOrderDto orderDto)
    {
        var order = await _context.Orders
            .FirstOrDefaultAsync(o => o.Id == orderDto.Id);

        if (order == null) return 0;

        order.Title = orderDto.Title;
        order.ExpectedCompletionDate = orderDto.ExpectedCompletionDate;
        order.PaymentAmount = orderDto.PaymentAmount;
        order.Description = orderDto.Description;
        order.CustomerEmail = orderDto.CustomerEmail;
        order.CustomerPhone = orderDto.CustomerPhone;
        order.Status = orderDto.Status;

        if (orderDto.CityId.HasValue)
            order.CityId = orderDto.CityId.Value;

        await _skillService.UpsertOrderSkillsAsync(orderDto.SkillIds, order);
        await _workTypeService.UpsertOrderWorkTypes(orderDto.WorkTypeIds, order);

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
        if (order == null)
            throw new Exception($"Order with ID {orderId} not found.");

        return await _reviewService.CreateOrderReview(new CreateOrderReviewRequest {
            rating = rating,
            reviewText = reviewText,
            userId = userId
        }, order, true);
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

    private int CalculateEducationScore(UserProfileDto userProfileDto)
    {
        if (userProfileDto.UserEducations.Any(ue => ue.EducationLevelId is 1 or 3 or 4))
            return 10;
        return userProfileDto.UserEducations.Any(ue => ue.EducationLevelId == 2) ? 5 : 1;
    }

    private int CalculateFamilyStatusScore(UserProfileDto userProfileDto)
    {
        var familyStatus = userProfileDto.FamilyStatus;

        if (familyStatus == null)
        {
            return 1;
        }

        if (familyStatus.Id == 1)
        {
            return familyStatus.NumberOfChildren >= 2 ? 10 : 5;
        }
        else
        {
            return familyStatus.NumberOfChildren == 0 ? 1 : 5;
        }
    }

    private int CalculateAgeScore(UserProfileDto userProfileDto)
    {
        var currentDate = DateTime.Now;
        var age = currentDate.Year - userProfileDto.DateOfBirth.Year;

        if (userProfileDto.DateOfBirth.Date > currentDate.AddYears(-age)) age--;

        return age switch
        {
            >= 30 and <= 55 => 10,
            >= 27 and <= 57 => 5,
            _ => 1
        };
    }

    private int CalculateLanguageScore(UserProfileDto userProfileDto)
    {
        int languageCount = userProfileDto.Languages?.Count ?? 0;

        return languageCount switch
        {
            >= 3 => 10,
            2 => 6,
            1 => 3,
            _ => 0
        };
    }

    private int CalculateSkillScore(UserProfileDto userProfileDto)
    {
        if (userProfileDto.UserProfileSkills == null || userProfileDto.UserProfileSkills.Count == 0)
            return 0;

        var totalProficiency = userProfileDto.UserProfileSkills.Sum(skill => skill.ProficiencyLevel);
        var averageProficiency = totalProficiency / userProfileDto.UserProfileSkills.Count;

        return (int)Math.Round((decimal)averageProficiency);

    }
}