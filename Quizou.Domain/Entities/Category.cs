using System.ComponentModel.DataAnnotations;
namespace Quizou.Domain.Entities;

public class Category
{
    [Key]
    public int Id { get; set; }
    
    [Required] 
    public string Name { get; set; }
    
    [Required]
    public string Slug { get; set; }
    
    [Required] 
    public string Icon { get; set; }
}   