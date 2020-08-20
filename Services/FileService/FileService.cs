using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using HomeCloudApi.Controllers;
using HomeCloudApi.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HomeCloudApi.Services.FileService
{
    public class FileService : IFileService
    {
		private readonly IHttpContextAccessor _httpContextAccessor;

		public FileService(IHttpContextAccessor httpContextAccessor)
		{
			_httpContextAccessor = httpContextAccessor;
		}
        public ServiceResponse<string> Upload(List<IFormFile> files, string subDirectory)
        {
            ServiceResponse<string> serviceResponse = new ServiceResponse<string>();
            try
            {
                subDirectory = subDirectory ?? string.Empty;
                var target = Path.Combine($"C:\\homecloud\\{subDirectory}");
                                        
                Directory.CreateDirectory(target);

                files.ForEach(async file =>
                {
                    if (file.Length <= 0) return;
                    var filePath = Path.Combine(target, file.FileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                });
                var size = SizeConverter(files.Sum(f => f.Length));

                serviceResponse.Content = size;
                serviceResponse.Path = _httpContextAccessor.HttpContext.Request.Path.Value;
                serviceResponse.Message = "File successfully uploaded!";
            }
            catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;    
            }

            return serviceResponse;
        }

        //Private helpers
        private string SizeConverter(long bytes)
        {
            var fileSize = new decimal(bytes);
            var kilobyte = new decimal(1024);
            var megabyte = new decimal(1024 * 1024);
            var gigabyte = new decimal(1024 * 1024 * 1024);

            switch (fileSize)
            {
                case var _ when fileSize < kilobyte:
                    return $"Less then 1KB";
                case var _ when fileSize < megabyte:
                    return $"{Math.Round(fileSize / kilobyte, 0, MidpointRounding.AwayFromZero):##,###.##}KB";
                case var _ when fileSize < gigabyte:
                    return $"{Math.Round(fileSize / megabyte, 2, MidpointRounding.AwayFromZero):##,###.##}MB";
                case var _ when fileSize >= gigabyte:
                    return $"{Math.Round(fileSize / gigabyte, 2, MidpointRounding.AwayFromZero):##,###.##}GB";
                default:
                    return "n/a";
            }
        }
    }
}