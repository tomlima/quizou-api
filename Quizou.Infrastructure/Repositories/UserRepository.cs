using Microsoft.EntityFrameworkCore;
using Quizou.Domain.Entities;
using Quizou.Infrastructure.Interfaces;

namespace Quizou.Infrastructure.Repositories;

public class UserRepository(ApplicationDbContext context):IUserRepository
{
    public async Task<User?> GetUserByEmail(string email)
    {
        User? user =  await context.Users.SingleOrDefaultAsync(user => user.Email == email);
        return user;
    }

    public async Task<User?> GetUserById(int userId)
    {
        User? user =  await context.Users.SingleOrDefaultAsync(user => user.Id == userId);
        return user; 
    }
}