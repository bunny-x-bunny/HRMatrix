using HRMatrix.Application.DTOs.MaterialStatus;

namespace HRMatrix.Application.DTOs.FamilyStatus;

public class FamilyStatusDto : FamilyStatusBaseDto
{
    public int Id { get; set; }
    public int MaritalStatusId { get; set; }
    public string MaritalStatusDescription { get; set; }
    public List<MaritalStatusTranslationDto> MaritalStatusTranslations { get; set; }
}