using Microsoft.AspNetCore.Mvc;
using Quizou.Application.Interfaces;  // Your service interfaces
using Quizou.Domain.DTO;

namespace Quizou.Api.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class QuizzesController : ControllerBase
    {
        private readonly IQuizService _quizService;
        private readonly ILogger<QuizzesController> _logger;

        public QuizzesController(IQuizService quizService, ILogger<QuizzesController> logger)
        {
            _quizService = quizService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllQuizzes([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
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
                _logger.LogError(ex, "Error search the term {term}", term);
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddQuizz([FromBody] CreateQuizDto quiz)
        {
            try
            {
                int createdQuizId = await _quizService.AddQuizz(quiz);
                return Ok(new { id = createdQuizId });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error to create a new quiz");
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] EditQuizDto payload)
        {
            try
            {
                await _quizService.Edit(payload);
                return Ok($"Quiz with id {payload.Id} was edited.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while editing a quiz.");
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _quizService.Delete(id);
                return Ok($"Quiz deleted");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting a quiz.");
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
    }
}