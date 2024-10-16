namespace HRMatrix.Domain.Entities;

public class MaritalStatusTranslation
{
    public int Id { get; set; }
    public int MaritalStatusId { get; set; }
    public MaritalStatus MaritalStatus { get; set; }
    public string Name { get; set; }
    public string LanguageCode { get; set; }
}