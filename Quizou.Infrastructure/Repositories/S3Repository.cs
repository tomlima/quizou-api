using Amazon;
using Amazon.S3;
using Amazon.S3.Transfer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Quizou.Infrastructure.Interfaces;

namespace Quizou.Infrastructure.Repositories
{
    public class S3Repository : IS3Repository
    {
        private readonly IAmazonS3 _s3Client;
        private readonly string _bucketName;

        public S3Repository(IConfiguration configuration) {
             var region = RegionEndpoint.GetBySystemName(configuration["AWS:Region"]);
            _bucketName = configuration["AWS:BucketName"] ?? throw new ArgumentNullException("AWS:BucketName is not configured");
            _s3Client = new AmazonS3Client(
                configuration["AWS:AccessKey"], 
                configuration["AWS:SecretKey"],
                region
            );
        }

        public async Task<string> UploadFileAsync(IFormFile file, string key)
        {
            using var stream = file.OpenReadStream();

            var request = new TransferUtilityUploadRequest
            {
                InputStream = stream,
                BucketName = _bucketName,
                Key = key,
                ContentType = file.ContentType
            };

            var transferUtility = new TransferUtility(_s3Client);
            await transferUtility.UploadAsync(request); 

            return $"https://{_bucketName}.s3.amazonaws.com/{key}";
        }

    }
}
