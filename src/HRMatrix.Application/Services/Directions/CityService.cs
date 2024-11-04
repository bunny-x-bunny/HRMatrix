using AutoMapper;
using HRMatrix.Application.DTOs.City;
using HRMatrix.Application.Services.Interfaces.Directions;
using HRMatrix.Domain.Entities;
using HRMatrix.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace HRMatrix.Application.Services.Directions;

public class CityService : ICityService
{
    private readonly HRMatrixDbContext _context;
    private readonly IMapper _mapper;

    public CityService(HRMatrixDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<CityDto>> GetAllCitiesAsync()
    {
        var cities = await _context.Cities
            .Include(c => c.Translations)
            .Include(c => c.Country)
            .ThenInclude(co => co.Translations)
            .ToListAsync();
        return _mapper.Map<List<CityDto>>(cities);
    }

    public async Task<CityDto> GetCityByIdAsync(int id)
    {
        var city = await _context.Cities
            .Include(c => c.Translations)
            .Include(c => c.Country)
            .ThenInclude(co => co.Translations)
            .FirstOrDefaultAsync(c => c.Id == id);
        return _mapper.Map<CityDto>(city);
    }

    public async Task<int> CreateCityAsync(CreateCityDto cityDto)
    {
        var country = await _context.Countries.FindAsync(cityDto.CountryId);
        if (country == null)
        {
            throw new Exception("Country not found.");
        }

        var city = _mapper.Map<City>(cityDto);
        city.CountryId = cityDto.CountryId;

        city.Translations = cityDto.Translations.Select(translation => new CityTranslation
        {
            Name = translation.Name,
            LanguageCode = translation.LanguageCode
        }).ToList();

        _context.Cities.Add(city);
        await _context.SaveChangesAsync();

        return city.Id;
    }

    public async Task<int> UpdateCityAsync(UpdateCityDto cityDto)
    {
        var city = await _context.Cities
            .Include(c => c.Translations)
            .FirstOrDefaultAsync(c => c.Id == cityDto.Id);

        if (city == null) return 0;

        city.Name = cityDto.Name;

        foreach (var translationDto in cityDto.Translations)
        {
            var existingTranslation = city.Translations
                .FirstOrDefault(t => t.LanguageCode == translationDto.LanguageCode);

            if (existingTranslation != null)
            {
                existingTranslation.Name = translationDto.Name;
            }
            else
            {
                var newTranslation = new CityTranslation
                {
                    Name = translationDto.Name,
                    LanguageCode = translationDto.LanguageCode,
                    CityId = city.Id
                };
                city.Translations.Add(newTranslation);
            }
        }

        await _context.SaveChangesAsync();
        return city.Id;
    }

    public async Task<bool> DeleteCityAsync(int id)
    {
        var city = await _context.Cities.FindAsync(id);
        if (city == null) return false;

        _context.Cities.Remove(city);
        await _context.SaveChangesAsync();
        return true;
    }
}