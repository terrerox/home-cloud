using HomeCloudApi.Models;
using HomeCloudApi.Services.FileService;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HomeCloudApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FileController : ControllerBase
    {
        public static IFileService _fileService;

        public FileController(IFileService FileService)
        {
            _fileService = FileService;
        }

        [HttpPost("upload")]
        public IActionResult Upload([FromForm(Name = "files")] List<IFormFile> files, string subDirectory)
        { 
            return Ok(_fileService.Upload(files, subDirectory));
        }

        [HttpGet("download/{subDirectory}")]
        public IActionResult DownloadFiles(string subDirectory)
        {
            try
            {
                var (fileType, archiveData, archiveName) = _fileService.FetchFiles(subDirectory);

                return File(archiveData, fileType, archiveName);
            }
            catch (Exception ex)
            {
                return BadRequest(new {message = ex.Message});
            }
        }

    }
}