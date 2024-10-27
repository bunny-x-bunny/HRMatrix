namespace HRMatrix.Domain.Entities;

public class WorkTypeTranslation
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string LanguageCode { get; set; }
    public int WorkTypeId { get; set; }
    public WorkType WorkType { get; set; }
}