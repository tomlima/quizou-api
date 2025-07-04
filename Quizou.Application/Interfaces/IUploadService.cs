using Microsoft.AspNetCore.Http;
using Quizou.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizou.Application.Interfaces
{
    public  interface IUploadService
    {
        public Task<string> UploadImageAsync(IFormFile file); 
    }
}
