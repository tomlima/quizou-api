using System.ComponentModel.DataAnnotations;

namespace Quizou.Domain.Entities;

public class Battle
{
    [Key]
    public int Id { get; init; }

    [Required]
    public required string Name { get; init; }

    [Required]
    public int UserAId { get; init; }
    public required User UserA { get; init; }

    [Required]
    public int UserBId { get; init; }
    public required User UserB { get; init; }

    [Required]
    public int WinnerId { get; init; }
    public required User Winner { get; init; }

    [Url]
    public required string Link { get; init; }

    [Required]
    public DateTime Date { get; init; }
}