using System.ComponentModel.DataAnnotations;
using Quizou.Domain.Enums;

namespace Quizou.Domain.Entities;

public class Question
{
    [Key]
    public int Id { get; set; }
    [Required]
    public required string Text { get; set; }
    [Required]
    public required List<Answer> Answers { get; set; }
    [Required]
    public Difficulty Difficulty { get; set; }
    [Required]
    public int Order { get; set; }
    public int QuizId { get; set; } 
    public Tag Tag { get; set; }
}