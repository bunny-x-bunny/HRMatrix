namespace HRMatrix.Application.DTOs.OrderReview;
public class CreateOrderReviewRequest {
    public int userId { get; set; }
    public int rating { get; set; }
    public string reviewText { get; set; }
}
