using Xunit;
using Moq;
using Quizou.Domain.Entities;
using Quizou.Application.Services;
using Quizou.Infrastructure.Interfaces;
using Quizou.Domain.Enums;
using System;
using System.Threading.Tasks;

public class UserServiceTests
{
    [Fact]
    public async Task GetUserByEmail_ReturnsUser_WhenUserExists()
    {
        // Arrange
        var email = "nobody@test.com";

        var expectedUser = new User
        {
            Id = 1,
            Name = "Unknow",
            Email = email,
            Nickname = "Sinevitae",
            Password = "pass123",
            Status = true,
            CreatedAt = DateTime.UtcNow,
            Avatar = "avatar.png",
            Role = Roles.Standard
        };

        var mockRepo = new Mock<IUserRepository>();
        mockRepo.Setup(repo => repo.GetUserByEmail(email))
            .ReturnsAsync(expectedUser);

        var userService = new UserService(mockRepo.Object);

        // Act
        var result = await userService.GetUserByEmail(email);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(expectedUser.Email, result.Email);
        Assert.Equal(expectedUser.Name, result.Name);
        Assert.Equal(expectedUser.Role, result.Role);
    }

    [Fact]
    public async Task GetUserByEmail_ReturnsNull_WhenUserDoesNotExist()
    {
        // Arrange
        var email = "inexistent@teste.com";

        var mockRepo = new Mock<IUserRepository>();
        mockRepo.Setup(repo => repo.GetUserByEmail(email))
            .ReturnsAsync((User)null);

        var userService = new UserService(mockRepo.Object);

        // Act
        var result = await userService.GetUserByEmail(email);

        // Assert
        Assert.Null(result);
    }
}