using Microsoft.AspNetCore.Http;

namespace OcrApi.Models
{
    public class FileUpload
    {
        public IFormFile Files { get; set; }
    }
}
