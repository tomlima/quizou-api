using Quizou.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Quizou.Domain.Entities;

public class Question
{
    [Key]
    public int Id { get; set; }

    [Required]
    public required string Text { get; set; }

    public ICollection<Answer> Answers { get; set; } = new List<Answer>();

    [Required]
    public required Difficulty Difficulty { get; set; }

    [Required]
    public required int Order { get; set; }

    [Required]
    public required int QuizId { get; set; }
    [JsonIgnore]
    public Quiz? Quiz { get; set; }

    public ICollection<Tag> Tags { get; set; } = new List<Tag>();

    [Required]
    public required DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}