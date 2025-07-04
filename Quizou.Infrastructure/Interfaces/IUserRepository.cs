using Quizou.Domain.Entities;
namespace Quizou.Infrastructure.Interfaces;

public interface IUserRepository
{
    public Task<User?> GetUserByEmail(string email);
    public Task<User?> GetUserById(int userId);
}