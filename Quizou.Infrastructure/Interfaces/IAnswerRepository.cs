using Quizou.Domain.Entities;

namespace Quizou.Infrastructure.Interfaces;

public interface IAnswerRepository
{
    public Task<List<Answer>> GetAnswersByQuestion(int questionId);
}