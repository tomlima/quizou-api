using System.ComponentModel.DataAnnotations;

namespace Quizou.Domain.Entities;

public class History
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    public DateTime Date { get; set; }
    
    public List<Battle>? Battles { get; set; }
}