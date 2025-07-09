using Microsoft.EntityFrameworkCore;
using Quizou.Domain.Entities;
using Quizou.Infrastructure.Interfaces;

namespace Quizou.Infrastructure.Repositories;

public class CategoryRepository(ApplicationDbContext context):ICategoryRepository
{
    
    public async Task<List<Category>> GetCategories()
    {
        List<Category> categories = context.Categories.ToList();
        return categories;
    }

    public async Task<Category> GetCategoryBySlug(string categorySlug)
    {
        Category category = context.Categories.SingleOrDefault(c => c.Slug == categorySlug);
        return category;
    }
    public async Task<Category?> GetCategoryById(int id)
    {
        return await context.Categories.FindAsync(id);
    }

}