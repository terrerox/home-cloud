using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace HomeCloudApi.Entities
{
    public class Storage
    {
        public List<string> Directories { get; set; }
        public List<string> Files { get; set; }
    }
}