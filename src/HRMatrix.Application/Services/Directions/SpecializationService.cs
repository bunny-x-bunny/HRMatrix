using AutoMapper;
using HRMatrix.Application.DTOs.Specialization;
using HRMatrix.Application.Services.Interfaces.Directions;
using HRMatrix.Domain.Entities;
using HRMatrix.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace HRMatrix.Application.Services.Directions
{
    public class SpecializationService : ISpecializationService
    {
        private readonly HRMatrixDbContext _context;
        private readonly IMapper _mapper;

        public SpecializationService(HRMatrixDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<SpecializationDto>> GetAllSpecializationsAsync()
        {
            var specializations = await _context.Specializations
                .Include(s => s.Translations)
                .ToListAsync();
            return _mapper.Map<List<SpecializationDto>>(specializations);
        }

        public async Task<SpecializationDto> GetSpecializationByIdAsync(int id)
        {
            var specialization = await _context.Specializations
                .Include(s => s.Translations)
                .FirstOrDefaultAsync(s => s.Id == id);
            return _mapper.Map<SpecializationDto>(specialization);
        }

        public async Task<int> CreateSpecializationAsync(CreateSpecializationDto specializationDto)
        {
            var specialization = _mapper.Map<Specialization>(specializationDto);

            specialization.Translations = specializationDto.Translations.Select(translation => new SpecializationTranslation
            {
                Name = translation.Name,
                LanguageCode = translation.LanguageCode
            }).ToList();

            _context.Specializations.Add(specialization);
            await _context.SaveChangesAsync();

            return specialization.Id;
        }

        public async Task<int> UpdateSpecializationAsync(UpdateSpecializationDto specializationDto)
        {
            var specialization = await _context.Specializations
                .Include(s => s.Translations)
                .FirstOrDefaultAsync(s => s.Id == specializationDto.Id);

            if (specialization == null) return 0;

            specialization.Name = specializationDto.Name;

            foreach (var translationDto in specializationDto.Translations)
            {
                var existingTranslation = specialization.Translations
                    .FirstOrDefault(t => t.LanguageCode == translationDto.LanguageCode);

                if (existingTranslation != null)
                {
                    existingTranslation.Name = translationDto.Name;
                }
                else
                {
                    var newTranslation = new SpecializationTranslation
                    {
                        Name = translationDto.Name,
                        LanguageCode = translationDto.LanguageCode,
                        SpecializationId = specialization.Id
                    };
                    specialization.Translations.Add(newTranslation);
                }
            }

            await _context.SaveChangesAsync();
            return specialization.Id;
        }

        public async Task<bool> DeleteSpecializationAsync(int id)
        {
            var specialization = await _context.Specializations.FindAsync(id);
            if (specialization == null) return false;

            _context.Specializations.Remove(specialization);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
