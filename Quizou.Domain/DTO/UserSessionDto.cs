using Quizou.Domain.Enums;
namespace Quizou.Domain.DTO;

public class UserSessionDto
{
    public  int? Id { get; set; }
    public string? Email { get; set; }
    
    public  string? Name { get; set; }
    
    public  string? Role { get; set; }
    
    public string? Avatar { get; set; }
    
    public string? Nickname { get; set; }
}