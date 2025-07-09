using Quizou.Domain.DTO;
using Quizou.Domain.Entities;

namespace Quizou.Application.Interfaces;

public interface IQuizService
{
    public Task<int> AddQuizz(CreateQuizDto quizz);
    public Task<PagedResult<Quiz>> GetQuizzes(int page, int pageSize);
    public Task<List<Quiz>> GetFaturedQuizzes();
    public Task<List<Quiz>> GetQuizzesByCategory(string categorySlug);
    public Task<string?> GetQuizById(int quizId);
    public Task<List<Quiz>> GetQuizzesBySearch(string termSearched);
}