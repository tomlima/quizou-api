using Microsoft.EntityFrameworkCore;
using Quizou.Application.Interfaces;
using Quizou.Domain.DTO;
using Quizou.Domain.Entities;
using Quizou.Domain.Enums;
using Quizou.Infrastructure.Interfaces;
using Quizou.Infrastructure.Repositories;

namespace Quizou.Application.Services
{
    public class AnswerService(IAnswerRepository _repository) : IAnswerService
    {
        public async Task<int> Create(CreateAnswerDto payload)
        {
            var answer = new Answer
            {
                Text = payload.Text,
                Correct = payload.Correct,
                QuestionId = payload.QuestionId,
                Order = payload.Order
            };
            return await _repository.Create(answer);
        }
        public async Task<ICollection<Answer>> GetByQuestion(int id)
        {
            return await _repository.GetByQuestion(id);
        }
        public async Task Delete(int id)
        {
            var answer = await _repository.GetById(id);
            if (answer == null)
                throw new Exception($"Answer with ID {id} was not found");
            await _repository.Delete(answer);
        }
        public async Task<bool> Edit(EditAnswerDto payload)
        {
            // If a user try to set the answer as correct and already exist 
            // a correct one for this question we must return false because 
            // a question must have only one correct answer.
            var existCorrectAnswerInQuestion =  await _repository.GetCorrectAnswerByQuestion(payload.QuestionId);
            if (existCorrectAnswerInQuestion != null && payload.Correct == true) 
            {
                return false;
            }

            // Check if answer exist before update it.
            Answer? answer = await _repository.GetById(payload.Id);
            if(answer == null)
            {
                return false;
            }

            answer.Text = payload.NewAnswer;
            answer.Correct = payload.Correct;
            await _repository.Edit(answer);
            return true;
        }
        public async Task Reorder(IEnumerable<ReorderDto> payload)
        {
            var ids = payload.Select(p => p.Id).ToList();
            var answers = await _repository.GetByIds(ids);
            var payloadMap = payload.ToDictionary(p => p.Id, p => p.Order);

            foreach (var answer in answers)
            {
                if (payloadMap.TryGetValue(answer.Id, out var newOrder))
                {
                    answer.Order = newOrder;
                }
            }

            await _repository.SaveChangesAsync();
        }
        public async Task<Answer?> GetCorrectAnswerByQuestion(int id)
        {
            Answer? correctAnswer = await _repository.GetCorrectAnswerByQuestion(id);
            return correctAnswer;
        }
    }
}
