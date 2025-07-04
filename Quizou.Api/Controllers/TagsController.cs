using Microsoft.AspNetCore.Mvc;
using Quizou.Application.Interfaces;
using Quizou.Domain.DTO;
using Quizou.Domain.Entities;

namespace Quizou.Api.Controllers;

[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiVersion("1.0")]
public class TagsController: ControllerBase
{
    private readonly ITagService _tagService;
    private readonly ILogger<TagsController> _logger; 
    
    public TagsController(ITagService tagService,ILogger<TagsController> logger)
    {
        _tagService = tagService;
        _logger = logger;
    }
    [HttpPost]
    public async Task<IActionResult> AddTag([FromBody] CreateTagDto tagDto)
    {
        try
        {
            Tag? createdTag = await _tagService.AddTag(tagDto);
            if (createdTag is null)
            {
                return Conflict(new { message = "A tag with the same name already exists." });
            }
            return CreatedAtAction(nameof(GetAllTags), new { id = createdTag.Id }, createdTag);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while creating a new tag.");
            return StatusCode(500, "An error occurred while processing your request.");
        }
    }
    [HttpPut]
    public async Task<IActionResult> EditTag([FromBody] EditTagDto tagDto)
    {
        try
        {
            var editedTag = await _tagService.EditTag(tagDto.TagId,tagDto.Name);
            if (!editedTag)
                return NotFound($"Tag with id {tagDto.TagId} not found.");
            return Ok($"Tag with id {tagDto.TagId} was edited.");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while editing a tag.");
            return StatusCode(500, "An error occurred while processing your request.");
        }
    }
    [HttpDelete]
    public async Task<IActionResult> DeleteTag([FromQuery] int tagId)
    {
        try
        {
            var deletedTag = await _tagService.DeleteTag(tagId);
            if(!deletedTag)
                return NotFound($"Tag with id {tagId} not found or already deleted.");
            return Ok($"Tag with id {tagId} was deleted.");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while deleting a tag.");
            return StatusCode(500, "An error occurred while processing your request.");
        }
    }
    [HttpGet]
    public async Task<IActionResult> GetAllTags([FromQuery] int page =1, [FromQuery] int pageSize = 100)
    {
        try
        {
            var tags = await _tagService.GetTags(page, pageSize);
            return Ok(tags);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while getting all tags.");
            // Return 500 Internal Server Error with a generic message
            return StatusCode(500, "An error occurred while processing your request.");
        }
    }
    
}