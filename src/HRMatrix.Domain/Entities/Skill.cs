﻿namespace HRMatrix.Domain.Entities;

public class Skill
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<SkillTranslation> Translations { get; set; }
    public int? SpecializationId { get; set; }
    public Specialization Specialization { get; set; }
}
