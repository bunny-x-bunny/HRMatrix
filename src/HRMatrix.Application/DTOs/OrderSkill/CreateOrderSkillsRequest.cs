namespace HRMatrix.Application.DTOs.OrderSkill;

public class CreateOrderSkillsRequest {
    public int OrderId { get; set; }
    public List<int> SkillIds { get; set; }
}