using FinanceFlow.API.Services;
using FinanceFlow.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace FinanceFlow.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserDto request)
        {
            if (await _authService.UserExists(request.Email))
            {
                return BadRequest("Usuario já existe.");
            }

            var user = new User
            {
                Email = request.Email
            };

            var token = await _authService.Register(user, request.Password);

            return Ok(new { token });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserDto request)
        {
            var token = await _authService.Login(request.Email, request.Password);
            
            if (token == null)
            {
                return Unauthorized("Credenciais inválidas.");
            }
            return Ok(new { token });
        }
    }
    
    public class UserDto
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}