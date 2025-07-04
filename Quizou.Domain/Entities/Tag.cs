using System.ComponentModel.DataAnnotations;

namespace Quizou.Domain.Entities;

public class Tag
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }    
    [Required]
    public required DateTime CreatedAt { get; set; }
    [Required]
    public required Boolean Status { get; set; }
}