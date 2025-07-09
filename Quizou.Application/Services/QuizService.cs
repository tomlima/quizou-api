using Amazon.Runtime.Internal;
using Quizou.Application.Interfaces;
using Quizou.Common.Interfaces;
using Quizou.Domain.DTO;
using Quizou.Domain.Entities;
using Quizou.Domain.Enums;
using Quizou.Infrastructure.Interfaces;

namespace Quizou.Application.Services;

public class QuizService(IQuizRepository _quizRepository, ICategoryRepository _categoryRepository, ITagRepository _tagRepository, IEncryptionService encryptionService) : IQuizService
{
    public async Task<int> AddQuizz(CreateQuizDto quizDTO)
    {
        if (!Enum.IsDefined(typeof(Difficulty), quizDTO.Difficulty))
            throw new ArgumentException("Invalid difficulty");

        if (!Enum.IsDefined(typeof(QuizStatus), quizDTO.Status))
            throw new ArgumentException("Invalid status");

        var category = await _categoryRepository.GetCategoryById(quizDTO.CategoryId);
        if (category == null)
            throw new ArgumentException("Category was not found");

        var tags = await _tagRepository.GetTagsByIds(quizDTO.Tags);

        var quiz = new Quiz
        {
            Title = quizDTO.Title,
            Description = quizDTO.Description,
            Time = quizDTO.Time,
            Difficulty = (Difficulty)quizDTO.Difficulty,
            Status = (QuizStatus)quizDTO.Status,
            CreatedAt = DateTime.UtcNow,
            Featured = false,
            Category = category,
            Image = quizDTO.Image,
            Tags = tags
        };

        return await _quizRepository.AddQuiz(quiz);
    }
    public async Task<PagedResult<Quiz>> GetQuizzes(int page, int pageSize)
        {
                var quizzes = await _quizRepository.GetQuizzes(page, pageSize);
                return quizzes;
        }
    public async Task<List<Quiz>> GetFaturedQuizzes()
        {
                var quizzes = await _quizRepository.GetFaturedQuizzes();
                return quizzes;
        }
        public async Task<List<Quiz>> GetQuizzesByCategory(string categorySlug)
        {
                var quizzes = await _quizRepository.GetQuizzesByCategory(categorySlug);
                return quizzes;
        }
        public async Task<string?> GetQuizById(int id)
        {
                var quiz = await _quizRepository.GetQuizById(id);
                if (quiz == null) return null;

                return encryptionService.Encrypt(quiz);
        }
        public async Task<List<Quiz>> GetQuizzesBySearch(string termSearched)
        {
                var quizzes = await _quizRepository.GetQuizzesBySearch(termSearched);
                return quizzes;
        }
       

}