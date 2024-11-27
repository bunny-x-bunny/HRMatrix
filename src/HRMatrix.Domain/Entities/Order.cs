using HRMatrix.Domain.Enums;

namespace HRMatrix.Domain.Entities;

public class Order
{
    public int Id { get; set; }

    public string Title { get; set; }

    public DateTime? ExpectedCompletionDate { get; set; }

    public decimal PaymentAmount { get; set; }

    public string Description { get; set; }

    public string? CustomerEmail { get; set; }

    public string CustomerPhone { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime DueDate { get; set; }

    public OrderStatus Status { get; set; }

    public int CreatedByUserId { get; set; }

    public int? AssignedUserProfileId { get; set; }

    public UserProfile? AssignedUserProfile { get; set; }

    public ICollection<OrderSkill> OrderSkills { get; set; }

    public int? CityId { get; set; }

    public City City { get; set; }

    public ICollection<OrderWorkType> OrderWorkTypes { get; set; }
    public ICollection<OrderResponse> OrderResponses { get; set; }
}