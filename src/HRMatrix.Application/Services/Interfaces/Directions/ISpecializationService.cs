using HRMatrix.Application.DTOs.Specialization;

namespace HRMatrix.Application.Services.Interfaces.Directions;

public interface ISpecializationService
{
    Task<List<SpecializationDto>> GetAllSpecializationsAsync();
    Task<SpecializationDto> GetSpecializationByIdAsync(int id);
    Task<int> CreateSpecializationAsync(CreateSpecializationDto specializationDto);
    Task<int> UpdateSpecializationAsync(UpdateSpecializationDto specializationDto);
    Task<bool> DeleteSpecializationAsync(int id);
}