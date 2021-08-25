using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using OcrApi.Models;
using Tesseract;

namespace OcrApi.Controllers
{
    [ApiController]
    [Route("api/parse")]
    public class ParseController : ControllerBase
    {
        [HttpPost]
        public ActionResult<Parse> ParseFile()
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            var image = Pix.LoadFromFile("hello.jpg");
            TesseractEngine engine = new TesseractEngine("./tessdata", "eng", EngineMode.Default);

            Page page = engine.Process(image, PageSegMode.Auto);
            string result = page.GetText();

            stopWatch.Stop();
            long timeSpan = stopWatch.ElapsedMilliseconds;

            Parse parsedData = new Parse(result, timeSpan);

            return Ok(parsedData);
        }
    }
}
