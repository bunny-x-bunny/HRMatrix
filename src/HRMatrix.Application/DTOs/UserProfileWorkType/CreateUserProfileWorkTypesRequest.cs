namespace HRMatrix.Application.DTOs.UserProfileWorkType;

public class CreateUserProfileWorkTypesRequest
{
    public int UserProfileId { get; set; }
    public List<CreateUserProfileWorkTypeRequest> WorkTypes { get; set; }
}