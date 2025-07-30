using Microsoft.AspNetCore.Mvc;
using Quizou.Application.Interfaces;
using Quizou.Domain.DTO;

namespace Quizou.Api.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class AnswersController : ControllerBase
    {
        private readonly IAnswerService _answerService;
        private readonly ILogger<AnswersController> _logger;

        public AnswersController(IAnswerService answerService, ILogger<AnswersController> logger)
        {
            _answerService = answerService;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateAnswerDto answer)
        {
            try
            {
                int createdAnswerId = await _answerService.Create(answer);
                return Ok(new { id = createdAnswerId });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error to create a new answer");
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
        [HttpGet("question/{id}")]
        public async Task<IActionResult> GetByQuestion(int id)
        {
            try
            {
                var answers = await _answerService.GetByQuestion(id);
                return Ok(answers);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching answers");
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _answerService.Delete(id);
                return Ok(new { result = "success" });
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex.Message}");
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] EditAnswerDto payload)
        {
            try
            {
                var editedAnswer = await _answerService.Edit(payload);
                if (!editedAnswer)
                    return StatusCode(403, "Each question must have only one correct answer.    ");
                return Ok($"Answer with id {payload.Id} was edited.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while editing a question.");
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
        [HttpPut("reorder")]
        public async Task<IActionResult> Reorder([FromBody] IEnumerable<ReorderDto> payload)
        {
            try
            {
                await _answerService.Reorder(payload);
                return Ok("Success to reorder answers");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while reorder answers");
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
    }
}
