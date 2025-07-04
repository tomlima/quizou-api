using System.ComponentModel.DataAnnotations;

namespace Quizou.Domain.Entities;

public class Answer
{
    [Key]
    public int Id { get; set; }

    [Required]
    public required string Text { get; set; }

    [Required]
    public required bool Correct { get; set; }

    [Required]
    public required int QuestionId { get; set; }
    public Question? Question { get; set; }
}   