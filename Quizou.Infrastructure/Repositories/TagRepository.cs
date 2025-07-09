using Microsoft.EntityFrameworkCore;
using Quizou.Domain.Entities;
using Quizou.Infrastructure.Interfaces;
namespace Quizou.Infrastructure.Repositories;

public class TagRepository(ApplicationDbContext context):ITagRepository
{
    public async Task<Tag> AddTag(Tag tag)
    {
        context.Tags.Add(tag);
        await context.SaveChangesAsync();
        return tag;
    }
    public async Task DeleteTag(Tag tag)
    {
        tag.Status = false;
        context.Tags.Update(tag);
        await context.SaveChangesAsync();
    }
    public async Task EditTag(Tag tag)
    {
        context.Tags.Update(tag);
        await context.SaveChangesAsync(); 
    }
    public async Task<Tag?> GetTagById(int id)
    {
        return await context.Tags.FindAsync(id);
    }
    public async Task<ICollection<Tag>> GetTagsByIds(ICollection<int> ids)
    {
        return await context.Tags
           .Where(t => ids.Contains(t.Id))
           .ToListAsync();
    }

    public async Task<Tag?> GetTagByName(string name)
    {
        return await context.Tags.FirstOrDefaultAsync(t => t.Name == name); 
    }
    public async Task<PagedResult<Tag>> GetTags(int page, int pageSize)
    {
        var query = context.Tags
            .Where(t => t.Status == true)
            .OrderBy(t => t.Name);

        var totalItems = await query.CountAsync();
        var items = await query
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return new PagedResult<Tag>
        {
            Items = items,
            Page = page,
            PageSize = pageSize,
            TotalItems = totalItems
        };
    }
}