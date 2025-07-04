using Quizou.Domain.Enums;

namespace Quizou.Domain.DTO
{
    public  class CreateQuizDto
    {
        public required string Title { get; set; }
        public  required string Description { get; set; }
        public required int Time { get; set; }
        public required string CategoryName { get; set; }
        public required string TagName { get; set; }
        public required string Thumb {  get; set; }
        public required QuizStatus status { get; set; }
    }
}
