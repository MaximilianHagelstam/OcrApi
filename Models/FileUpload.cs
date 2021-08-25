using Microsoft.AspNetCore.Http;

namespace OcrApi.Models
{
    public class FileUpload
    {
        public IFormFile files { get; set; }
    }
}
