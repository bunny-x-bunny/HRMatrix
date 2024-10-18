namespace HRMatrix.Application.DTOs.Languages
{
    public class UpdateLanguageDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<UpdateLanguageTranslationDto> Translations { get; set; }
    }
}
