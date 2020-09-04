using System.Collections.Generic;

namespace HomeCloudApi.Models
{
    public class GetStorage
    {
        public List<string> Directories { get; set; }
        public List<string> Files { get; set; }
    }
}