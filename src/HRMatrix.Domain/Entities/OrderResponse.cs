using HRMatrix.Domain.Enums;

namespace HRMatrix.Domain.Entities;

public class OrderResponse
{
    public int Id { get; set; } 

    public int OrderId { get; set; }

    public Order Order { get; set; }

    public int UserId { get; set; }

    public DateTime CreatedAt { get; set; }

    public ResponseStatus Status { get; set; } = ResponseStatus.Pending;
}