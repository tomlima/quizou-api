using Quizou.Domain.Entities;
namespace Quizou.Application.Interfaces;

public interface IUserService
{
    public Task<User?> GetUserByEmail(string email);
    public Task<User?> GetUserById(int id);
}