using System.ComponentModel.DataAnnotations;
namespace Quizou.Domain.DTO;

public class CreateTagDto
{
    public required string Name { get; set; }
}