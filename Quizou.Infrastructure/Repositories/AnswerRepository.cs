using Microsoft.EntityFrameworkCore;
using Quizou.Domain.Entities;
using Quizou.Infrastructure.Interfaces;

namespace Quizou.Infrastructure.Repositories;

public class AnswerRepository(ApplicationDbContext _context) : IAnswerRepository
{
    public async Task<int> Create(Answer answer)
    {
        _context.Answers.Add(answer);
        await _context.SaveChangesAsync();
        return answer.Id;
    }
    public async Task Edit(Answer answer)
    {
        _context.Answers.Update(answer);
        await _context.SaveChangesAsync();
    }
    public async Task Delete(Answer answer)
    {
        _context.Answers.Remove(answer);
        await _context.SaveChangesAsync();
    }
    public async Task<Answer?> GetById(int id)
    {
        return await _context.Answers.FindAsync(id);
    }
    public async Task<Answer?> GetCorrectAnswerByQuestion(int id)
    {
        return await _context.Answers
            .Where(a => a.QuestionId == id && a.Correct == true)
            .FirstOrDefaultAsync();
    }
    public async Task<IEnumerable<Answer>> GetByIds(IEnumerable<int> ids)
    {
        return await _context.Answers
            .Where(a => ids.Contains(a.Id))
            .ToListAsync();
    }
    public async Task<ICollection<Answer>> GetByQuestion(int id)
    {
        return await _context.Answers.Where(q => q.QuestionId == id).ToListAsync();
    }
    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}