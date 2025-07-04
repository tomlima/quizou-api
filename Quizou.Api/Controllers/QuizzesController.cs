using Microsoft.AspNetCore.Mvc;
using Quizou.Application.Interfaces;  // Your service interfaces
using System.Threading.Tasks;

namespace Quizou.Api.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class QuizzesController : ControllerBase
    {
        private readonly IQuizService _quizService;
        private readonly ILogger<QuizzesController> _logger; 

        public QuizzesController(IQuizService quizService,ILogger<QuizzesController> logger)
        {
            _quizService = quizService;
            _logger = logger;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAllQuizzes([FromQuery] int page =1, [FromQuery] int pageSize = 10)
        {
            try
            {
                var quizzes = await _quizService.GetQuizzes(page, pageSize);
                return Ok(quizzes);
            }
            catch (Exception ex)
            {
                
                _logger.LogError(ex, "An error occurred while getting all quizzes.");
                
                // Return 500 Internal Server Error with a generic message
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
        
        // GET: /api/v1/quiz/category/movie
        [HttpGet("category/{categorySlug}")]
        public async Task<IActionResult> GetQuizzesByCategory(string categorySlug)
        {
            try
            {
                var quizzes = await _quizService.GetQuizzesByCategory(categorySlug);
                return Ok(quizzes);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching quizzes by category ID {CategoryId}", categorySlug);
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
        
        // GET: /api/v1/quiz/featured
        [HttpGet("featured")]
        public async Task<IActionResult> GetQuizzesFeatured()
        {
            try
            {
                var quizzes = await _quizService.GetFaturedQuizzes();
                return Ok(quizzes);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching featured quizzes.");
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
        
        // GET: /api/v1/quiz/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetQuizById(int id)
        {
            try
            {
                var quiz = await _quizService.GetQuizById(id);
                return Ok(quiz);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching quiz {QuizId}", id);
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
        
        // GET: /api/v1/quiz/search/harry
        [HttpGet("search/{term}")]
        public async Task<IActionResult> GetQuizzesBySearch(string term)
        {
            try
            {
                var quiz = await _quizService.GetQuizzesBySearch(term);
                return Ok(quiz);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error search the term {term}", term );
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
    }
}