using Quizou.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Quizou.Domain.DTO
{
    public class CreateQuestionDto
    {
        [Required]
        public required string Text { get; set; }

        [Required]
        public required Difficulty Difficulty { get; set; }

        [Required]
        public int Order { get; set; }

        [Required]
        public required int QuizId { get; set; }

        public ICollection<int> Tags { get; set; } = new List<int>();

    }
}
