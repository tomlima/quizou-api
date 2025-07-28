using Microsoft.AspNetCore.Mvc;
using Quizou.Application.Interfaces;
using Quizou.Domain.DTO;

namespace Quizou.Api.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class QuestionsController : ControllerBase
    {
        private readonly IQuestionService _questionService;
        private readonly ILogger<QuestionsController> _logger;

        public QuestionsController(IQuestionService questionService, ILogger<QuestionsController> logger)
        {
            _questionService = questionService;
            _logger = logger; 
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateQuestionDto question)
        {
            try
            {
                int createdQuestionId = await _questionService.AddQuestion(question);
                return Ok(new { id = createdQuestionId });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error to create a new question");
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
        [HttpGet("quiz/{id}")]
        public async Task<IActionResult> GetByQuiz(int id)
        {
            try
            {
                var questions = await _questionService.GetQuestionsByQuiz(id);
                return Ok(questions);
            }
            catch (Exception ex) {
                _logger.LogError(ex, "Error fetching questions");
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _questionService.DeleteQuestion(id);
                return Ok(new { result =  "success" });
            }catch(Exception ex)
            {
                _logger.LogError($"{ex.Message}");
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] EditQuestionDto questionDto)
        {
            try
            {
                var editedQuestion = await _questionService.Edit(questionDto.QuestionId, questionDto.NewQuestion);
                if (!editedQuestion)
                    return NotFound($"Question with id {questionDto.QuestionId} not found.");
                return Ok($"Question with id {questionDto.QuestionId} was edited.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while editing a question.");
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
        [HttpPut("reorder")]
        public async Task<IActionResult> Reorder([FromBody] IEnumerable<ReorderQuestionDto> payload)
        {
            try
            {
                await _questionService.Reorder(payload);
                return Ok("Success to reorder questions");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while reorder questions");
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
    }
}
