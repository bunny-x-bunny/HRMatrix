namespace HRMatrix.Application.DTOs.FamilyStatus;

public class FamilyStatusBaseDto
{
    public int MaritalStatusId { get; set; }

    public int TimesMarried { get; set; }
    
    public string MarriagePeriods { get; set; }
    
    public int NumberOfChildren { get; set; }
}