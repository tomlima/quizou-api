using Quizou.Domain.Entities;

namespace Quizou.Infrastructure.Interfaces;

public interface IQuestionRepository
{
    public Task<int> AddQuestion(Question question);
    public Task DeleteQuestion(Question question);
    public Task<ICollection<Question>> GetQuestionsByQuiz(int quizId);
    public Task<Question?> GetQuestionById(int id);
    public Task Edit(Question question);
    public Task<Question?> GetById(int id);
    public Task<IEnumerable<Question>> GetQuestionsByIds(IEnumerable<int> ids);
    public Task SaveChangesAsync();
}