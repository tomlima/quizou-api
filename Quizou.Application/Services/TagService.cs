using Quizou.Application.Interfaces;
using Quizou.Domain.DTO;
using Quizou.Domain.Entities;
using Quizou.Infrastructure.Interfaces;

namespace Quizou.Application.Services;

public class TagService(ITagRepository repository): ITagService
{
    public async Task<Tag?> AddTag(CreateTagDto tagDto)
    {
        Tag? tagAlreadyExist = await GetTagByName(tagDto.Name);

        if (tagAlreadyExist is not null)
        {
            return null;
        }
        var tag = new Tag
        {
            Name = tagDto.Name,
            CreatedAt = DateTime.UtcNow,
            Status = true
        };
        return await repository.AddTag(tag);
    }
    public async Task<Boolean> EditTag(int id, string name)
    {
        var tag = await repository.GetTagById(id); 
        if (tag == null || tag.Status == false)
        {
            return false; 
        }
        tag.Name = name;
        await repository.EditTag(tag);
        return true; 
    }
    public async Task<Boolean> DeleteTag(int id)
    {
        var tag = await repository.GetTagById(id);
        if (tag == null)
            return false;
        tag.Status = false;
        await repository.DeleteTag(tag);
        return true;
    } 
    public Task<Tag?> GetTagById(int id)
    {
        return repository.GetTagById(id);
    }
    public Task<Tag?> GetTagByName(string name)
    { 
        return repository.GetTagByName(name);
    }
    public async Task<PagedResult<Tag>> GetTags(int page, int pageSize)
    {
        return await repository.GetTags(page, pageSize);
    }

}