using HRMatrix.Application.DTOs.MaterialStatus;

namespace HRMatrix.Application.Services.Interfaces;

public interface IMaritalStatusService
{
    Task<List<MaritalStatusDto>> GetAllMaritalStatusesAsync();
    Task<MaritalStatusDto> GetMaritalStatusByIdAsync(int id);
    Task<MaritalStatusDto> CreateMaritalStatusAsync(MaritalStatusDto maritalStatusDto);
    Task<MaritalStatusDto> UpdateMaritalStatusAsync(MaritalStatusDto maritalStatusDto);
    Task<bool> DeleteMaritalStatusAsync(int id);
}