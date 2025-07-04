using Quizou.Domain.Entities;

namespace Quizou.Application.Interfaces;

public interface IAnswerService
{
    public Task<List<Answer>> GetAnswersByQuestion(int questionId);
}