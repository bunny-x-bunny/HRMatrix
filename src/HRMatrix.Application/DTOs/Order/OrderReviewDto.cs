namespace HRMatrix.Application.DTOs.Order;

public class OrderReviewDto
{
    public int Id { get; set; }
    public int OrderId { get; set; }
    public int UserId { get; set; }
    public int Rating { get; set; }
    public string ReviewText { get; set; }
    public DateTime CreatedAt { get; set; }
}