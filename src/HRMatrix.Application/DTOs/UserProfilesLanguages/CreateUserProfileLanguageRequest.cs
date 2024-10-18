using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMatrix.Application.DTOs.UserProfilesLanguages
{
    public class CreateUserProfileLanguageRequest
    {
        public int LanguageId { get; set; }
        public int ProficiencyLevel { get; set; }
    }
}
