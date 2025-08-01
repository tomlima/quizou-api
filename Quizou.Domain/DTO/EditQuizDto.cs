using Quizou.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Quizou.Domain.DTO
{
    public class EditQuizDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public required string Title { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]
        public required int Time { get; set; }
        [Required]
        public required Difficulty Difficulty { get; set; }
        [Required]
        public required int CategoryId { get; set; }
        [Required]
        public required ICollection<int> Tags { get; set; } = new List<int>();
        [Required]
        public required string Image { get; set; }
        [Required]
        public required QuizStatus Status { get; set; }
    }
}
