using HRMatrix.Application.DTOs.City;

namespace HRMatrix.Application.Services.Interfaces.Directions;

public interface ICityService
{
    Task<List<CityDto>> GetAllCitiesAsync();
    Task<CityDto> GetCityByIdAsync(int id);
    Task<int> CreateCityAsync(CreateCityDto cityDto);
    Task<int> UpdateCityAsync(UpdateCityDto cityDto);
    Task<bool> DeleteCityAsync(int id);
}