using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizou.Infrastructure.Interfaces
{
    public interface IS3Repository
    {
        Task<string> UploadFileAsync(IFormFile file, string key);
    }
}
