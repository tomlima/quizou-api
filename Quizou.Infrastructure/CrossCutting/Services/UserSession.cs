using Microsoft.AspNetCore.Http;
using Quizou.Domain.DTO;
using Quizou.Domain.Entities;
namespace Quizou.Infrastructure.CrossCutting.Services;

public static class UserSession
{
    public static bool IsLoggedIn(HttpContext httpContext)
    {
       string? email = httpContext.Session.GetString("email");
       int? id = httpContext.Session.GetInt32("id");
       string? name = httpContext.Session.GetString("name");
       string? role = httpContext.Session.GetString("role");
       string? avatar = httpContext.Session.GetString("avatar");

       if (email != null && id != null && name != null && role != null && avatar != null)
       {
           return true;
       }
       return false;
    }

    public static void CreateSession(HttpContext httpContext, User user)
    {
        httpContext.Session.SetString("email", user.Email);
        httpContext.Session.SetInt32("id", user.Id);
        httpContext.Session.SetString("name", user.Name);
        httpContext.Session.SetString("role" , user.Role.ToString());
        httpContext.Session.SetString("avatar", user.Avatar);
    }

    public static UserSessionDto GetSession(HttpContext httpContext)
    {
        UserSessionDto userSessionDto = new UserSessionDto
        {
            Id = httpContext.Session.GetInt32("id"),
            Email = httpContext.Session.GetString("email"),
            Name = httpContext.Session.GetString("name"),
            Role = httpContext.Session.GetString("role"),
            Avatar = httpContext.Session.GetString("avatar")
        };
        
        return userSessionDto;
       
    }
    
}