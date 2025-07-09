using Quizou.Domain.Entities;
using Quizou.Domain.Enums;

namespace Quizou.Domain.DTO
{
    public  class CreateQuizDto
    {
        public required string Title { get; set; }
        public string? Description { get; set; }
        public required int Time { get; set; }
        public required Difficulty Difficulty { get; set; }
        public required int CategoryId { get; set; }
        public required ICollection<int> Tags { get; set; } = new List<int>();
        public required string Image {  get; set; }
        public required QuizStatus Status { get; set; }
    }
}
