using System.ComponentModel.DataAnnotations;

namespace OcrApi.Dtos
{
    public class ParseRequestDto
    {
        [Required]
        public string InputFile { get; set; }

        [Required]
        public string InputLanguage { get; set; }
    }
}
