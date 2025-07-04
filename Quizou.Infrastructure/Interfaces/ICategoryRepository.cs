using Quizou.Domain.Entities;

namespace Quizou.Infrastructure.Interfaces;

public interface ICategoryRepository
{
    public Task<List<Category>> GetCategories();
    public Task<Category> GetCategoryBySlug(string categorySlug);
}