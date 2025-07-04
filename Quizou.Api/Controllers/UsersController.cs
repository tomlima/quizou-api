using Microsoft.AspNetCore.Mvc;
using Quizou.Application.Interfaces;  
using Quizou.Domain.DTO;

namespace Quizou.Api.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger<UsersController> _logger; 


        public UsersController(IUserService userService,ILogger<UsersController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            try
            {
                var user = await _userService.GetUserById(id);
                var sessionUser = new UserSessionDto()
                {
                    Email = user?.Email,
                    Id = user?.Id,
                    Name = user?.Name,
                    Role = user?.Role.ToString(),
                    Avatar = user?.Avatar,
                    Nickname = user?.Nickname,
                };
                return Ok(sessionUser);
            }
            catch (Exception ex)
            {
                
                _logger.LogError(ex, "An error occurred while getting user {id}.", id);
                
                // Return 500 Internal Server Error with a generic message
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

    }
}