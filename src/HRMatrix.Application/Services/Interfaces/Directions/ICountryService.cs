using HRMatrix.Application.DTOs;
using HRMatrix.Application.DTOs.Country;

namespace HRMatrix.Application.Services.Interfaces.Directions;

public interface ICountryService
{
    Task<List<CountryDto>> GetAllCountriesAsync();
    Task<CountryDto> GetCountryByIdAsync(int id);
    Task<int> CreateCountryAsync(CreateCountryDto countryDto);
    Task<int> UpdateCountryAsync(UpdateCountryDto countryDto);
    Task<bool> DeleteCountryAsync(int id);
}