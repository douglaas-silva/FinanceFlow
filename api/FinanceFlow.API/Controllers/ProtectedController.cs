using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinanceFlow.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProtectedController : ControllerBase
    {
        [Authorize]
        [HttpGet]
        public IActionResult GetSecret()
        {
            var identity = User.Identity;

            if (identity?.IsAuthenticated == true)
                return Ok($"Token válido. Usuário: {identity.Name}");
            else
                return Unauthorized("Token inválido");
        }
    }
}
