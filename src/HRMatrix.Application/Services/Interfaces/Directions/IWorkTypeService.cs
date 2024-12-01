using HRMatrix.Application.DTOs.WorkType;

namespace HRMatrix.Application.Services.Interfaces.Directions;

public interface IWorkTypeService
{
    //<List<WorkTypeDto>> GetAllWorkTypesAsync();
    //Task<WorkTypeDto> GetWorkTypeByIdAsync(int id);
    Task<int> CreateWorkTypeAsync(CreateWorkTypeDto workTypeDto);
    Task<int> UpdateWorkTypeAsync(UpdateWorkTypeDto workTypeDto);
    Task<bool> DeleteWorkTypeAsync(int id);
}