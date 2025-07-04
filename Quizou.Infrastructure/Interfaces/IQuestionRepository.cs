using Quizou.Domain.Entities;

namespace Quizou.Infrastructure.Interfaces;

public interface IQuestionRepository
{
    public List<Question> GetQuestionsByQuiz(int quizId);
}