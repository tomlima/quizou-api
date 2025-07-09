using Microsoft.EntityFrameworkCore;
using Quizou.Domain.Entities;
using Quizou.Infrastructure.Interfaces;

namespace Quizou.Infrastructure.Repositories;


public class QuizRepository(ApplicationDbContext context): IQuizRepository
{
    public async Task<int> AddQuiz(Quiz quiz)
    {
        context.Quizzes.Add(quiz);
        await context.SaveChangesAsync();
        return quiz.Id;
    }
    public async Task<PagedResult<Quiz>> GetQuizzes(int page, int pageSize)
    {
        var query = context.Quizzes
            .Include(q => q.Category)
            .OrderByDescending(q => q.CreatedAt);

        var totalItems = await query.CountAsync();
        var items = await query
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return new PagedResult<Quiz>
        {
            Items = items,
            Page = page,
            PageSize = pageSize,
            TotalItems = totalItems
        };
    }
    public async Task<List<Quiz>> GetFaturedQuizzes()
    {
        return  await context.Quizzes
            .Include(q => q.Category)
            .Where(q => q.Featured == true)
            .ToListAsync();
    }
    public async Task<List<Quiz>> GetQuizzesByCategory(string categorySlug)
    {
        List<Quiz> quizzes = await context.Quizzes
            .Include(q => q.Category)
            .Where(q => q.Category.Slug == categorySlug)
            .ToListAsync();
        return quizzes;
    }
    public async Task<Quiz?> GetQuizById(int id)
    {
        Quiz? quiz = await context.Quizzes
            .Include(q => q.Questions)         
            .ThenInclude(question => question.Answers) 
            .FirstOrDefaultAsync(q => q.Id == id);
        return quiz;
    }
    public async Task<List<Quiz>> GetQuizzesBySearch(string termSearched)
    {
        List<Quiz> quiz = await context.Quizzes
            .Include(q => q.Category)
            .Where(q => q.Title.ToLower().Contains(termSearched.ToLower()))
            .ToListAsync();
        return quiz;
    }
}