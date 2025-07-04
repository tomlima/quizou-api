using Quizou.Domain.Entities;
namespace Quizou.Infrastructure.Interfaces;

public interface ITagRepository
{
    public Task<Tag> AddTag(Tag tag);
    public Task EditTag(Tag tag);
    public Task DeleteTag(Tag tag);
    public Task<Tag?> GetTagById(int id);
    public Task<Tag?> GetTagByName(string name); 
    public Task<PagedResult<Tag>> GetTags(int page, int pageSize);
}