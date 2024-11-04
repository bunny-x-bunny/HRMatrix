namespace HRMatrix.Application.DTOs.UserProfileWorkType;

public class UserProfileWorkTypeListResponse
{
    public int UserProfileId { get; set; }
    public List<UserProfileWorkTypeResponse> WorkTypes { get; set; }
}