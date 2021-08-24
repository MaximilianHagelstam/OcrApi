using System.ComponentModel.DataAnnotations;

namespace OcrApi.Dtos
{
    public class ParseResponseDto
    {
        [Required]
        public string ParsedText { get; set; }

        [Required]
        public int ProcessingTimeInMilliseconds { get; set; }
    }
}
