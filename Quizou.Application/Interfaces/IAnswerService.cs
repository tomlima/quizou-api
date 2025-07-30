using Quizou.Domain.DTO;
using Quizou.Domain.Entities;

namespace Quizou.Application.Interfaces
{
    public interface IAnswerService
    {
        public Task<int> Create(CreateAnswerDto answer);
        public Task<bool> Edit(EditAnswerDto payload);
        public Task Delete(int id);
        public Task Reorder(IEnumerable<ReorderDto> payload);
        public Task<ICollection<Answer>> GetByQuestion(int id);
        public Task<Answer?> GetCorrectAnswerByQuestion(int id);
    }
}
