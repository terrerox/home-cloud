using System.Collections.Generic;
using HomeCloudApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HomeCloudApi.Services.FileService
{
    public interface IFileService
    {
       ServiceResponse<string> Upload(List<IFormFile> files, string subDirectory);

       (string fileType, byte[] archiveData, string archiveName) FetchFiles(string subDirectory);
    }
}