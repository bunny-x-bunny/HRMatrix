﻿using HRMatrix.Application.DTOs.Skill;
using HRMatrix.Domain.Enums;

namespace HRMatrix.Application.DTOs.Order;

public class OrderDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public DateTime ExpectedCompletionDate { get; set; }
    public decimal PaymentAmount { get; set; }
    public string Description { get; set; }
    public string CustomerEmail { get; set; }
    public string CustomerPhone { get; set; }
    public DateTime CreatedAt { get; set; }
    public OrderStatus Status { get; set; }
    public int CreatedByUserId { get; set; }
    public int? AssignedUserProfileId { get; set; }
    public string Location { get; set; }
    public List<SkillDto> Skills { get; set; }
}