using Microsoft.AspNetCore.Mvc;
using Quizou.Application.Interfaces;  // Your service interfaces
using System.Threading.Tasks;

namespace Quizou.Api.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly ILogger<CategoriesController> _logger; 


        public CategoriesController(ICategoryService categoryService,ILogger<CategoriesController> logger)
        {
            _categoryService = categoryService;
            _logger = logger;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            try
            {
                var categories = await _categoryService.GetCategories();
                return Ok(categories);
            }
            catch (Exception ex)
            {
                
                _logger.LogError(ex, "An error occurred while getting all categories.");
                
                // Return 500 Internal Server Error with a generic message
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

    }
}