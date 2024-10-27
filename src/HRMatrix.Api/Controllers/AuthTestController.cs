using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HRMatrix.Api.Controllers
{
    public class AuthTestController : BaseController
    {
        [HttpGet("hr")]
        [Authorize]
        public string TestExpiredToken()
        {
            return "OK";
        }
    }
}
