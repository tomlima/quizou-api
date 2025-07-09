using System.ComponentModel.DataAnnotations;
using Quizou.Domain.Enums;

namespace Quizou.Domain.Entities;

public class Quiz
{
    [Key]
    public int Id { get; set; }
   
    [Required]
    public required string Title { get; set; }

    [Required]
    public required Difficulty Difficulty { get; set; }
    
    public string? Description { get; set; }

    [Required]
    public required int Time { get; set; }
    
    public ICollection<Question> Questions { get; set; } =new List<Question>();

    [Required]
    public required QuizStatus Status { get; set; }

    [Required]
    public required DateTime CreatedAt { get; set; }
    
    public DateTime? UpdatedAt { get; set; }
    
    [Required]
    public required bool Featured { get; set; }
    
    [Required]
    public required Category Category { get; set; }
    
    [Required]
    public required string Image { get; set; }
    
    public  ICollection<Tag> Tags { get; set; } = new List<Tag>();
}