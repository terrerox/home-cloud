using HomeCloudApi.Entities;
using HomeCloudApi.Models;
using HomeCloudApi.Services.DirectoryService;
using HomeCloudApi.Services.FileService;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
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
    public class ApiController : ControllerBase
    {
        public static IFileService _fileService;
        public static IDirectoryService _directoryService;

        public ApiController(IFileService FileService, IDirectoryService DirectoryService)
        {
            _fileService = FileService;
            _directoryService = DirectoryService;
        }

        [HttpPost("upload")]
        public IActionResult Upload([FromForm(Name = "files")] List<IFormFile> files, string subDirectory)
        { 
            return Ok(_fileService.Upload(files, subDirectory));
        }

        [HttpGet]
        public IActionResult GetDirectories([FromForm]Storage storage)
        { 
            return Ok(_directoryService.GetDirectories(storage));
        }

        [HttpGet("{directory}")]
        public IActionResult GetDirectory([FromForm]Storage storage, string directory)
        { 
            return Ok(_directoryService.GetDirectory(storage, directory));
        }
    }
}