using System.ComponentModel.DataAnnotations;
namespace Quizou.Domain.Entities;

public class Category
{
    [Key]
    public int Id { get; set; }
    
    [Required] 
    public required string Name { get; set; }
    
    [Required]
    public required string Slug { get; set; }
    
    [Required] 
    public required string Icon { get; set; }
}   