using Quizou.Domain.DTO;
using Quizou.Domain.Entities;

namespace Quizou.Application.Interfaces
{
    public interface IQuestionService
    {
        public Task<int> AddQuestion(CreateQuestionDto question);
        public Task<ICollection<Question>> GetQuestionsByQuiz(int quizId);
        public Task DeleteQuestion(int questionId);
        public Task<Boolean> Edit(int id, string newQuestion);
        public Task Reorder(IEnumerable<ReorderDto> payload);
    }
}
