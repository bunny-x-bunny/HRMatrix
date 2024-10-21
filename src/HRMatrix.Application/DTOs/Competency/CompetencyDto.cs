using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMatrix.Application.DTOs.Competency;

public class CompetencyDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<CompetencyTranslationDto> Translations { get; set; }
}