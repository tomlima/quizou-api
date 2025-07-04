using System.ComponentModel.DataAnnotations;
using Quizou.Domain.Enums;

namespace Quizou.Domain.Entities;

public class Quiz
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    public required string Title { get; set; }
    
    public Difficulty Difficulty { get; set; }
    
    public string? Description { get; set; }
    
    public int Time { get; set; }
    
    [Required]
    public List<Question> Questions { get; set; }
    
    public QuizStatus Status { get; set; }
    
    public DateTime CreatedAt { get; set; }
    
    public DateTime UpdatedAt { get; set; }
    
    [Required]
    public required bool Featured { get; set; }
    
    [Required]
    public required Category Category { get; set; }
    
    [Required]
    public required string Image { get; set; }
    [Required]
    public required List<Tag> Tag { get; set; }
}