using Quizou.Domain.Entities;
namespace Quizou.Infrastructure.Interfaces;

public interface IQuizRepository
{
    public Task<PagedResult<Quiz>> GetQuizzes(int page, int pageSize);
    public Task<List<Quiz>> GetFaturedQuizzes();
    public Task<List<Quiz>> GetQuizzesByCategory(string categorySlug);
    public Task<Quiz?> GetQuizById(int quizzId);
    public Task<List<Quiz>> GetQuizzesBySearch(string termSearched);
}