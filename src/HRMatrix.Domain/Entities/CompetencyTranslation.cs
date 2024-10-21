namespace HRMatrix.Domain.Entities
{
    public class CompetencyTranslation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LanguageCode { get; set; }
        public int CompetencyId { get; set; }
        public Competency Competency { get; set; }
    }
}
