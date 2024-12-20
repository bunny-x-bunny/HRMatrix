﻿namespace HRMatrix.Domain.Entities;

public class CityTranslation
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string LanguageCode { get; set; }
    public int CityId { get; set; }
    public City City { get; set; }
}