using Microsoft.EntityFrameworkCore;
using Quizou.Application.Interfaces;
using Quizou.Domain.DTO;
using Quizou.Domain.Entities;
using Quizou.Domain.Enums;
using Quizou.Infrastructure.Interfaces;
using Quizou.Infrastructure.Repositories;

namespace Quizou.Application.Services
{
    public class QuestionService(IQuestionRepository _repository, ITagRepository _tagRepository): IQuestionService 
    {
        public async Task<int> AddQuestion(CreateQuestionDto questionDto)
        {
            var tags = await _tagRepository.GetTagsByIds(questionDto.Tags);
            var question = new Question
            {
                Text = questionDto.Text,
                QuizId = questionDto.QuizId,
                Difficulty = (Difficulty)questionDto.Difficulty,
                CreatedAt = DateTime.UtcNow,
                Order = questionDto.Order,
                Tags = tags
            };
            return await _repository.AddQuestion(question);
        }
        public async Task<ICollection<Question>>  GetQuestionsByQuiz(int quizId)
        {
            return await _repository.GetQuestionsByQuiz(quizId);
        }
        public async Task DeleteQuestion(int quizzId)
        {
            var question = await _repository.GetQuestionById(quizzId);
            if (question == null)
                throw new Exception($"Question with ID {quizzId} was not found");
            await _repository.DeleteQuestion(question); 
        }
        public async Task<Boolean> Edit(int id, string newQuestion)
        {
            var question = await _repository.GetById(id);
            if (question == null)
            {
                return false;
            }
            question.Text = newQuestion;
            await _repository.Edit(question);
            return true;
        }
        public async Task Reorder(IEnumerable<ReorderQuestionDto> payload)
        {
            var ids = payload.Select(p => p.Id).ToList();
            var questions = await _repository.GetQuestionsByIds(ids);
            var payloadMap = payload.ToDictionary(p => p.Id, p => p.Order);

            foreach (var question in questions)
            {
                if (payloadMap.TryGetValue(question.Id, out var newOrder))
                {
                    question.Order = newOrder;
                }
            }

            await _repository.SaveChangesAsync();
        }

    }
}
