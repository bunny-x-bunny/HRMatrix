﻿namespace HRMatrix.Application.DTOs.Order;

public class CreateOrderDto
{
    public string Title { get; set; }
    public DateTime ExpectedCompletionDate { get; set; }
    public decimal PaymentAmount { get; set; }
    public string Description { get; set; }
    public string? CustomerEmail { get; set; }
    public string? CustomerPhone { get; set; }
    public int? AssignedUserProfileId { get; set; }
    public string Location { get; set; }
    public List<int> SkillIds { get; set; }
}