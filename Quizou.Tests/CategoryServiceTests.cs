using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using Xunit;
using Quizou.Application.Services;
using Quizou.Domain.Entities;
using Quizou.Infrastructure.Interfaces;

namespace Quizou.Tests
{
    public class CategoryServiceTests
    {
        [Fact]
        public async Task GetCategories_ReturnsCategoryList()
        {
            // Arrange
            var mockRepo = new Mock<ICategoryRepository>();
            mockRepo.Setup(repo => repo.GetCategories())
                .ReturnsAsync(new List<Category>
                {
                    new Category { Id = 1, Name = "Tecnology", Slug = "tecnology", Icon="tecnology" },
                    new Category { Id = 2, Name = "History", Slug = "history", Icon="history" }
                });

            var service = new CategoryService(mockRepo.Object);

            // Act
            var result = await service.GetCategories();

            // Assert
            Assert.Equal(2, result.Count);
            Assert.Contains(result, c => c.Name == "Tecnology");
        }

        [Fact]
        public async Task GetCategoryBySlug_ReturnsCorrectCategory()
        {
            // Arrange
            var slug = "historia";
            var mockRepo = new Mock<ICategoryRepository>();
            mockRepo.Setup(repo => repo.GetCategoryBySlug(slug))
                .ReturnsAsync(new Category { Id = 2, Name = "History", Slug = "history", Icon="history" });

            var service = new CategoryService(mockRepo.Object);

            // Act
            var result = await service.GetCategoryBySlug(slug);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("History", result.Name);
        }
    }
}
