using Microsoft.AspNetCore.Http;
using Quizou.Domain.Entities;
using Quizou.Infrastructure.Interfaces;

namespace Quizou.Infrastructure.Repositories;

public class QuestionRepository(ApplicationDbContext context): IQuestionRepository
{
    public List<Question> GetQuestionsByQuiz(int quizId)
    {
        List<Question> questions = new List<Question>();
        return questions;
    }
}