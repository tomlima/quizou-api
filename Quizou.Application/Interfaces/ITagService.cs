using Quizou.Domain.DTO;
using Quizou.Domain.Entities;
namespace Quizou.Application.Interfaces;

public interface ITagService
{
    public Task<Tag?>AddTag(CreateTagDto tag);
    public Task<Boolean> EditTag(int id, string newName); 
    public Task<Boolean> DeleteTag(int id);
    public Task<Tag?> GetTagById(int id);
    public Task<Tag?> GetTagByName(string name);
    public Task<PagedResult<Tag>> GetTags(int page, int pageSize);
}