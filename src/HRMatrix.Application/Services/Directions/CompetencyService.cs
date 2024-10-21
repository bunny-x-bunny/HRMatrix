using AutoMapper;
using HRMatrix.Application.DTOs.Competency;
using HRMatrix.Application.Services.Interfaces.Directions;
using HRMatrix.Domain.Entities;
using HRMatrix.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace HRMatrix.Application.Services.Directions
{
    public class CompetencyService : ICompetencyService
    {
        private readonly HRMatrixDbContext _context;
        private readonly IMapper _mapper;

        public CompetencyService(HRMatrixDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<CompetencyDto>> GetAllCompetenciesAsync()
        {
            var competencies = await _context.Competencies
                .Include(c => c.Translations)
                .ToListAsync();
            return _mapper.Map<List<CompetencyDto>>(competencies);
        }

        public async Task<CompetencyDto> GetCompetencyByIdAsync(int id)
        {
            var competency = await _context.Competencies
                .Include(c => c.Translations)
                .FirstOrDefaultAsync(c => c.Id == id);
            return _mapper.Map<CompetencyDto>(competency);
        }

        public async Task<int> CreateCompetencyAsync(CreateCompetencyDto competencyDto)
        {
            var competency = _mapper.Map<Competency>(competencyDto);

            competency.Translations = competencyDto.Translations.Select(translation => new CompetencyTranslation
            {
                Name = translation.Name,
                LanguageCode = translation.LanguageCode
            }).ToList();

            _context.Competencies.Add(competency);
            await _context.SaveChangesAsync();

            return competency.Id;
        }

        public async Task<int> UpdateCompetencyAsync(UpdateCompetencyDto competencyDto)
        {
            var competency = await _context.Competencies
                .Include(c => c.Translations)
                .FirstOrDefaultAsync(c => c.Id == competencyDto.Id);

            if (competency == null) return 0;

            competency.Name = competencyDto.Name;

            foreach (var translationDto in competencyDto.Translations)
            {
                var existingTranslation = competency.Translations
                    .FirstOrDefault(t => t.LanguageCode == translationDto.LanguageCode);

                if (existingTranslation != null)
                {
                    existingTranslation.Name = translationDto.Name;
                }
                else
                {
                    var newTranslation = new CompetencyTranslation
                    {
                        Name = translationDto.Name,
                        LanguageCode = translationDto.LanguageCode,
                        CompetencyId = competency.Id
                    };
                    competency.Translations.Add(newTranslation);
                }
            }

            await _context.SaveChangesAsync();
            return competency.Id;
        }

        public async Task<bool> DeleteCompetencyAsync(int id)
        {
            var competency = await _context.Competencies.FindAsync(id);
            if (competency == null) return false;

            _context.Competencies.Remove(competency);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
