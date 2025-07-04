using System.ComponentModel.DataAnnotations;

namespace Quizou.Domain.Entities;

public class Tag
{
    [Key]
    public int Id { get; set; }

    [Required]
    public required string Name { get; set; }    

    [Required]
    public required DateTime CreatedAt { get; set; }

    [Required]
    public required Boolean Status { get; set; }

    public ICollection<Quiz> Quizzes { get; set; } = new List<Quiz>();

    public ICollection<Question> Questions { get; set; } = new List<Question>();
}