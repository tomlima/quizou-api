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
        public required Category Category { get; set; }
        public required Tag Tag { get; set; }
        public required string Thumb {  get; set; }
        public required QuizStatus Status { get; set; }
    }
}
