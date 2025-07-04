using System.ComponentModel.DataAnnotations;
using Quizou.Domain.Entities;

public class UserFriend
{
    [Required]
    public required int UserId { get; set; }
    public User? User { get; set; }

    [Required]
    public required int FriendId { get; set; }
    public User? Friend { get; set; }

    [Required]
    public required DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}