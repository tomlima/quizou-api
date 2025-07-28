using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Quizou.Domain.Entities;
using Quizou.Infrastructure.Interfaces;
using System.Threading.Tasks;

namespace Quizou.Infrastructure.Repositories;

public class QuestionRepository(ApplicationDbContext _context): IQuestionRepository
{
    public async Task<int> AddQuestion(Question question)
    {
        _context.Questions.Add(question);
        await _context.SaveChangesAsync();
        return question.Id;
    }
    public async Task<ICollection<Question>> GetQuestionsByQuiz(int quizId)
    {
        return await _context.Questions.Where(q => q.QuizId == quizId ).ToListAsync();
    }
    public async Task<Question?> GetQuestionById(int id)
    {
        return await _context.Questions.FindAsync(id); 
    }
    public async Task DeleteQuestion(Question question)
    {
        _context.Questions.Remove(question);
        await _context.SaveChangesAsync();
    }
    public async Task Edit(Question question)
    {
        _context.Questions.Update(question);
        await _context.SaveChangesAsync();
    }
    public async Task<Question?> GetById(int id)
    {
        return await _context.Questions.FindAsync(id);
    }
    public async Task<IEnumerable<Question>> GetQuestionsByIds(IEnumerable<int> ids)
    {
        return await _context.Questions
            .Where(q => ids.Contains(q.Id))
            .ToListAsync();
    }
    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}