using Microsoft.AspNetCore.Mvc;
using Quizou.Application.Interfaces;
using Quizou.Domain.DTO;
using Quizou.Domain.Entities;
using System.Security.Claims;

namespace Quizou.Api.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly ILogger<AuthController> _logger;

        public AuthController(IAuthService authService, ILogger<AuthController> logger)
        {
            _authService = authService;
            _logger = logger;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            try
            {
                var token = await _authService.AuthenticateAsync(request.Email, request.Password);

                if (string.IsNullOrEmpty(token))
                {
                    return Unauthorized("Invalid credentials.");
                }

                var cookieOptions = new CookieOptions
                {
                    HttpOnly = true,         // Against XSS
                    Secure = true,           // HTTPS only
                    SameSite = SameSiteMode.None, // Against CSRF
                    Expires = DateTime.UtcNow.AddMinutes(10),
                    Path = "/"
                };

                Response.Cookies.Append("jwt", token, cookieOptions);
                return Ok(new { message = "Login realizado com sucesso" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Login failed for user {Email}", request.Email);
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        [HttpGet("me")]
        public IActionResult Me()
        {
            var token = Request.Cookies["jwt"];
            if (string.IsNullOrEmpty(token))
                return Unauthorized();

            var principal = _authService.ValidateToken(token);
            if (principal == null)
                return Unauthorized();

            // Extrair claims e retornar dados do usuário
            var email = principal.FindFirst(ClaimTypes.Email)?.Value;
            var avatar = principal.FindFirst("avatar")?.Value;
            var nickname = principal.FindFirst("nickname")?.Value;
            var role = principal.FindFirst("role")?.Value;
            var id = principal.FindFirst("id")?.Value;
            var name = principal.FindFirst("name")?.Value;

            var userSession = new UserSessionDto
            {
                Id = id,
                Avatar = avatar,
                Nickname = nickname,
                Name = name,
                Role = role,
                Email = email
            };

            return Ok(userSession);
        }
    }
}