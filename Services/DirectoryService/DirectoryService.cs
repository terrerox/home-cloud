using System.IO;

namespace HomeCloudApi.Services.DirectoryService
{
    public class DirectoryService : IDirectoryService
    {

        public string GetDirectories()
        {
            var docPath = @"C:\homecloud\";

            string[] myDirs = Directory.GetDirectories(docPath);

            foreach (var myDir in myDirs)
            {
                return Path.GetFileName(myDir);
            }

            return null;
        }

        public (string Directory, string Files) GetDirectory(string directory)
        {
            var docPath = $@"C:\homecloud\{directory}";
            var dirs = myDirs(docPath);
            var files = myFiles(docPath);
            return (dirs, files);
        }

        //helpers
        private string myFiles(string docPath)
        {
            string[] myFiles = Directory.GetFiles(docPath);

            foreach (var myFile in myFiles)
            {
                return Path.GetFileName(myFile);
            }
            return null;
        }

        private string myDirs(string docPath)
        {
           string[] myDirs = Directory.GetDirectories(docPath);

            foreach (var myDir in myDirs)
            {
                return Path.GetFileName(myDir);
            }

            return null;
        }
    }
}