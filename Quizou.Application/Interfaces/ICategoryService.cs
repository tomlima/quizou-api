using Quizou.Domain.Entities;

namespace Quizou.Application.Interfaces;

public interface ICategoryService
{
    public Task<List<Category>> GetCategories();
    public Task<Category> GetCategoryBySlug(string categorySlug);
}