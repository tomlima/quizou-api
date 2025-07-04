using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Quizou.Application.Interfaces;

namespace Quizou.Api.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class UploadController : ControllerBase
    {
        private readonly IUploadService _uploadService;
        private readonly ILogger<TagsController> _logger;

        public UploadController(IUploadService uploadService, ILogger<TagsController> logger) { 
            _uploadService = uploadService;
            _logger = logger;
        }
            
        [HttpPost]
        [RequestSizeLimit (10 * 1024 * 1024)]
        public async Task<IActionResult> UploadImage(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest(new { message = "Nenhum arquivo enviado ou arquivo vazio." });
            }
            try
            {
                var url = await _uploadService.UploadImageAsync(file);
                return Ok(url);
            }
            catch (Exception ex) {
                _logger.LogError(ex, "An error occurred while getting all tags.");
                // Return 500 Internal Server Error with a generic message
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
    }
}
