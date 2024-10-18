namespace HRMatrix.Application.DTOs.Languages
{
    public class LanguageDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<LanguageTranslationDto> Translations { get; set; }
    }
}
