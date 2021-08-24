using System;

namespace OcrApi.Models
{
    public class Parse
    {
        public string ParsedText { get; set; }
        public int ProcessingTimeInMilliseconds { get; set; }
        public string InputFile { get; set; }
        public string InputLanguage { get; set; }
    }
}
