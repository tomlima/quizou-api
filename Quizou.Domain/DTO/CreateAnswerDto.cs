using System.ComponentModel.DataAnnotations;

namespace Quizou.Domain.DTO
{
    public class CreateAnswerDto
    {

        [Required]
        public required string Text { get; set; }
        [Required]
        public required int QuestionId { get; set; } 
        [Required]
        public required int Order {  get; set; }
        [Required]
        public required bool Correct { get; set; }
    }
}
