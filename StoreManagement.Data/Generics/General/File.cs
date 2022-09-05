using Microsoft.AspNetCore.Http;

namespace StoreManagement.Data.Generics.General
{
    public class File
    {
        public IFormFile FileData { get; set; }
        public string FileExtension { get; set; }
        public string FileName { get; set; }
        public string ActualFileName { get; set; }
        public string FileDirectory { get; set; }
        public string FileDirectoryKey { get; set; }
        public string FilePath { get; set; }
        public bool IsNewUpload { get; set; }
    }
}