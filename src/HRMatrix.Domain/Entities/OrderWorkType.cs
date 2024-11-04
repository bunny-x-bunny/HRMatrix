namespace HRMatrix.Domain.Entities;

public class OrderWorkType
{
    public int Id { get; set; }
    public int OrderId { get; set; }
    public Order Order { get; set; }

    public int WorkTypeId { get; set; }
    public WorkType WorkType { get; set; }
}