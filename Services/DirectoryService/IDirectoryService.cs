using HomeCloudApi.Entities;
using HomeCloudApi.Models;

namespace HomeCloudApi.Services.DirectoryService
{
    public interface IDirectoryService
    {
       ServiceResponse<GetStorage> GetDirectories(Storage storage);
       ServiceResponse<GetStorage> GetDirectory(Storage storage ,string directory);
    }
}