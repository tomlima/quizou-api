using System.Security.Claims;

namespace Quizou.Application.Interfaces;

public interface IAuthService
{
    Task<string?> AuthenticateAsync(string username, string password);
    ClaimsPrincipal? ValidateToken(string token);
}