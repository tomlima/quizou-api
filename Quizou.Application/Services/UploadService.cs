using Microsoft.AspNetCore.Http;
using Quizou.Application.Interfaces;
using Quizou.Infrastructure.Interfaces;


namespace Quizou.Application.Services
{
    public class UploadService(IS3Repository _s3Repository) : IUploadService
    {
        public async Task<string> UploadImageAsync(IFormFile file)
        {
            var key = $"quizzes/{Guid.NewGuid()}_{file.FileName}";
            return await _s3Repository.UploadFileAsync(file, key);
        }
    }
}
