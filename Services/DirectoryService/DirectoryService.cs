using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using HomeCloudApi.Entities;
using HomeCloudApi.Models;
using Microsoft.AspNetCore.Http;

namespace HomeCloudApi.Services.DirectoryService
{
    public class DirectoryService : IDirectoryService
    {
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public DirectoryService(IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public ServiceResponse<GetStorage> GetDirectories(Storage storage)
        {
           ServiceResponse<GetStorage> serviceResponse = new ServiceResponse<GetStorage>();

           var docPath = @"C:\homecloud\";
           var result = new List<string>();
 
           string[] myDirs = Directory.GetDirectories(docPath);

            foreach (var myDir in myDirs)
            {
                 result.Add(Path.GetFileName(myDir));
                 storage.Directories =  result;
                 storage.Files = new List<string>();
            }
            serviceResponse.Path = _httpContextAccessor.HttpContext.Request.Path.Value;  
            serviceResponse.Content = _mapper.Map<GetStorage>(storage);
            return serviceResponse;
        }

        public ServiceResponse<GetStorage> GetDirectory(Storage storage, string directory)
        {
            ServiceResponse<GetStorage> serviceResponse = new ServiceResponse<GetStorage>();
            var docPath = $@"C:\homecloud\{directory}";
            storage.Directories = Dirs(docPath);
            storage.Files = Files(docPath);    
            serviceResponse.Path = _httpContextAccessor.HttpContext.Request.Path.Value;  
            serviceResponse.Content = _mapper.Map<GetStorage>(storage);
            return serviceResponse;
        }

        //helpers
        private List<string> Files(string docPath)
        {
            var result = new List<string>();
            string[] myFiles = Directory.GetFiles(docPath);

            foreach (var myFile in myFiles)
            {
               result.Add(Path.GetFileName(myFile));
            }
            return result;
        }

        private List<string> Dirs(string docPath)
        {
            var result = new List<string>();
            string[] myDirs = Directory.GetDirectories(docPath);

            foreach (var myDir in myDirs)
            {
               result.Add(Path.GetFileName(myDir));
            }
            return result;
        }
    }
}