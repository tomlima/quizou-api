using Quizou.Application.Interfaces;
using Quizou.Common.Interfaces;
using Quizou.Domain.Entities;
using Quizou.Infrastructure.Interfaces;

namespace Quizou.Application.Services;

public class QuizService(IQuizRepository repository, IEncryptionService encryptionService) : IQuizService
{
        public async Task<PagedResult<Quiz>> GetQuizzes(int page, int pageSize)
        {
                var quizzes = await repository.GetQuizzes(page, pageSize);
                return quizzes;
        }
        public async Task<List<Quiz>> GetFaturedQuizzes()
        {
                var quizzes = await repository.GetFaturedQuizzes();
                return quizzes;
        }
        public async Task<List<Quiz>> GetQuizzesByCategory(string categorySlug)
        {
                var quizzes = await repository.GetQuizzesByCategory(categorySlug);
                return quizzes;
        }
        public async Task<string?> GetQuizById(int id)
        {
                var quiz = await repository.GetQuizById(id);
                if (quiz == null) return null;

                return encryptionService.Encrypt(quiz);
        }
        public async Task<List<Quiz>> GetQuizzesBySearch(string termSearched)
        {
                var quizzes = await repository.GetQuizzesBySearch(termSearched);
                return quizzes;
        }


}