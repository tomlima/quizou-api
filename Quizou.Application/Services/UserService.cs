using Quizou.Application.Interfaces;
using Quizou.Infrastructure.Interfaces;
using Quizou.Domain.Entities;

namespace Quizou.Application.Services;

public class UserService(IUserRepository repository): IUserService
{
    public async Task<User?> GetUserByEmail(string email)
    {
        User? user = await repository.GetUserByEmail(email);
        return user;    
    }

    public async Task<User?> GetUserById(int id)
    {
        User? user = await repository.GetUserById(id);
        return user;    
    }
}