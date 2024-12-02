namespace HRMatrix.Application.DTOs.OrderWorkType;

public class CreateOrderWorkTypesRequest {
    public int orderId { get; set; }
    public List<CreateOrderWorkTypeRequest> WorkTypes { get; set; }
}