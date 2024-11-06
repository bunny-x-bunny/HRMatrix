namespace HRMatrix.Domain.Entities;

public class OrderReview
{
    public int Id { get; set; }
        
    public int OrderId { get; set; }

    public Order Order { get; set; }

    public int UserId { get; set; }

    public int Rating { get; set; }

    public string ReviewText { get; set; }

    public DateTime CreatedAt { get; set; }
}