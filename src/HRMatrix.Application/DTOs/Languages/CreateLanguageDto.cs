namespace HRMatrix.Application.DTOs.Languages
{
    public class CreateLanguageDto
    {
        public string Name { get; set; }
        public List<CreateLanguageTranslationDto> Translations { get; set; }
    }
}
