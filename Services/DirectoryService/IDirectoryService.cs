using HomeCloudApi.Models;

namespace HomeCloudApi.Services.DirectoryService
{
    public interface IDirectoryService
    {
       string GetDirectories();
       (string Directory, string Files) GetDirectory(string directory);
    }
}