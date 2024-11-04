using AutoMapper;
using HRMatrix.Application.DTOs;
using HRMatrix.Application.DTOs.Country;
using HRMatrix.Application.Services.Interfaces.Directions;
using HRMatrix.Domain.Entities;
using HRMatrix.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace HRMatrix.Application.Services.Directions;

public class CountryService : ICountryService
{
    private readonly HRMatrixDbContext _context;
    private readonly IMapper _mapper;

    public CountryService(HRMatrixDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<CountryDto>> GetAllCountriesAsync()
    {
        var countries = await _context.Countries
            .Include(c => c.Translations)
            .ToListAsync();
        return _mapper.Map<List<CountryDto>>(countries);
    }

    public async Task<CountryDto> GetCountryByIdAsync(int id)
    {
        var country = await _context.Countries
            .Include(c => c.Translations)
            .FirstOrDefaultAsync(c => c.Id == id);
        return _mapper.Map<CountryDto>(country);
    }

    public async Task<int> CreateCountryAsync(CreateCountryDto countryDto)
    {
        var country = _mapper.Map<Country>(countryDto);

        country.Translations = countryDto.Translations.Select(translation => new CountryTranslation
        {
            Name = translation.Name,
            LanguageCode = translation.LanguageCode
        }).ToList();

        _context.Countries.Add(country);
        await _context.SaveChangesAsync();

        return country.Id;
    }

    public async Task<int> UpdateCountryAsync(UpdateCountryDto countryDto)
    {
        var country = await _context.Countries
            .Include(c => c.Translations)
            .FirstOrDefaultAsync(c => c.Id == countryDto.Id);

        if (country == null) return 0;

        country.Name = countryDto.Name;

        foreach (var translationDto in countryDto.Translations)
        {
            var existingTranslation = country.Translations
                .FirstOrDefault(t => t.LanguageCode == translationDto.LanguageCode);

            if (existingTranslation != null)
            {
                existingTranslation.Name = translationDto.Name;
            }
            else
            {
                var newTranslation = new CountryTranslation
                {
                    Name = translationDto.Name,
                    LanguageCode = translationDto.LanguageCode,
                    CountryId = country.Id
                };
                country.Translations.Add(newTranslation);
            }
        }

        await _context.SaveChangesAsync();
        return country.Id;
    }

    public async Task<bool> DeleteCountryAsync(int id)
    {
        var country = await _context.Countries.FindAsync(id);
        if (country == null) return false;

        _context.Countries.Remove(country);
        await _context.SaveChangesAsync();
        return true;
    }
}