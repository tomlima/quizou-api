using System.ComponentModel.DataAnnotations;

namespace Quizou.Domain.DTO
{
    public class EditAnswerDto
    {
        [Required]
        public required int Id { get; set; }
        [Required]
        public required string NewAnswer { get; set; }
        [Required]
        public required bool Correct { get; set; }
        [Required]
        public required int QuestionId { get; set; }
    }
}
