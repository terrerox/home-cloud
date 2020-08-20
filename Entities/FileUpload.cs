using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace HomeCloudApi.Models
{
    public class FileUpload
    {
        public List<IFormFile> files { get; set; }
    }
}