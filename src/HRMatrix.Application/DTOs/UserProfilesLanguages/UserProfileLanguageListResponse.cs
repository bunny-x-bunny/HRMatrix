using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMatrix.Application.DTOs.UserProfilesLanguages
{
    public class UserProfileLanguageListResponse
    {
        public int UserProfileId { get; set; }
        public List<UserProfileLanguageResponse> Languages { get; set; }
    }
}
