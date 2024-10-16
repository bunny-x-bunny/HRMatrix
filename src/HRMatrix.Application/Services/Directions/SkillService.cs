using AutoMapper;
using HRMatrix.Application.DTOs.Skill;
using HRMatrix.Application.Services.Interfaces.Directions;
using HRMatrix.Domain.Entities;
using HRMatrix.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace HRMatrix.Application.Services.Directions
{
    public class SkillService : ISkillService
    {
        private readonly HRMatrixDbContext _context;
        private readonly IMapper _mapper;

        public SkillService(HRMatrixDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<SkillDto>> GetAllSkillsAsync()
        {
            var skills = await _context.Skills
                .Include(s => s.Translations)
                .ToListAsync();
            return _mapper.Map<List<SkillDto>>(skills);
        }

        public async Task<SkillDto> GetSkillByIdAsync(int id)
        {
            var skill = await _context.Skills
                .Include(s => s.Translations)
                .FirstOrDefaultAsync(s => s.Id == id);
            return _mapper.Map<SkillDto>(skill);
        }

        public async Task<int> CreateSkillAsync(CreateSkillDto skillDto)
        {
            var skill = _mapper.Map<Skill>(skillDto);

            skill.Translations = skillDto.Translations.Select(translation => new SkillTranslation
            {
                Name = translation.Name,
                LanguageCode = translation.LanguageCode
            }).ToList();

            _context.Skills.Add(skill);
            await _context.SaveChangesAsync();

            return skill.Id;
        }

        public async Task<int> UpdateSkillAsync(UpdateSkillDto skillDto)
        {
            var skill = await _context.Skills
                .Include(s => s.Translations)
                .FirstOrDefaultAsync(s => s.Id == skillDto.Id);

            if (skill == null) return 0;

            skill.Name = skillDto.Name;

            foreach (var translationDto in skillDto.Translations)
            {
                var existingTranslation = skill.Translations
                    .FirstOrDefault(t => t.LanguageCode == translationDto.LanguageCode);

                if (existingTranslation != null)
                {
                    existingTranslation.Name = translationDto.Name;
                }
                else
                {
                    var newTranslation = new SkillTranslation
                    {
                        Name = translationDto.Name,
                        LanguageCode = translationDto.LanguageCode,
                        SkillId = skill.Id
                    };
                    skill.Translations.Add(newTranslation);
                }
            }

            await _context.SaveChangesAsync();
            return skill.Id;
        }

        public async Task<bool> DeleteSkillAsync(int id)
        {
            var skill = await _context.Skills.FindAsync(id);
            if (skill == null) return false;

            _context.Skills.Remove(skill);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
