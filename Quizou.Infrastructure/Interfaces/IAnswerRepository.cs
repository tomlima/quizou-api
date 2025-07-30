using Quizou.Domain.Entities;

namespace Quizou.Infrastructure.Interfaces;

public interface IAnswerRepository
{
    public Task<int> Create(Answer answer);
    public Task Delete(Answer answer);
    public Task Edit(Answer answer);
    public Task<Answer?> GetById(int id);
    public Task<IEnumerable<Answer>> GetByIds(IEnumerable<int> ids);
    public Task<ICollection<Answer>> GetByQuestion(int id);
    public Task<Answer?> GetCorrectAnswerByQuestion(int id);
    public Task SaveChangesAsync();
}