using System.ComponentModel.DataAnnotations;

namespace Quizou.Domain.Entities;

public class Battle
{
    [Key]
    public int Id { get; init; }
    
    [Required]
    public required string Name { get; init; }
    
    [Required]
    public required User UserA { get; init; }
    
    [Required]
    public required User UserB { get; init; }
    
    [Required]
    public required User Winner { get; init; }
    
    [Required]
    public required string Link { get; init; }
    
    [Required]
    public DateTime Date { get; init; }
}