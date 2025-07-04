using Quizou.Domain.Entities;
using Quizou.Domain.Enums;
namespace Quizou.Infrastructure.Data;
using BCrypt.Net;

public class DbInitializer
{
    public static void Seed(ApplicationDbContext context)
    {
        
        /*
         * Users instances
         * And creation
         */
        User U_1 = new User
        {
            Name = "admin", 
            Email = "tom.lima@nzn.io", 
            Password = BCrypt.HashPassword("123456"), 
            Role = Roles.Admin, 
            Status = true, 
            CreatedAt = DateTime.Now, 
            Nickname = "NZN",
            Avatar = "default.png"
        };
        
        if (!context.Users.Any())
        {
            context.Users.AddRange(U_1);
            context.SaveChanges(); 
        }
        
      
        /*
         * Categories instances
         * And creation
         */
        Category C_serie = new Category {  Name = "Séries", Slug = "series", Icon = "serie"};
        Category C_movie = new Category {  Name = "Filmes", Slug = "filmes", Icon = "movie"};
        Category C_game = new Category {   Name = "Games", Slug = "games", Icon = "game"};
        
        if (!context.Categories.Any())
        {
            context.Categories.AddRange(C_serie, C_movie, C_game);
            context.SaveChanges(); 
        }

    }
}