using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Quizou.Application.Interfaces;
using System.Threading.Tasks;
using Quizou.Domain.Entities;

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

                return Ok(new { Token = token });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Login failed for user {Email}", request.Email);
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
    }
}