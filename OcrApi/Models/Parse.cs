using System;

namespace OcrApi.Models
{
    public class Parse
    {
        public Parse(string parsedText, long processingTimeInMilliseconds)
        {
            ParsedText = parsedText;
            ProcessingTimeInMilliseconds = processingTimeInMilliseconds;
        }

        public string ParsedText { get; set; }
        public long ProcessingTimeInMilliseconds { get; set; }
    }
}
