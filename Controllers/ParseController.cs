using System;
using System.Diagnostics;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using OcrApi.Models;
using Tesseract;

namespace OcrApi.Controllers
{
    [ApiController]
    [Route("api/parse")]
    public class ParseController : ControllerBase
    {
        public static IWebHostEnvironment _webHostEnvironment;

        public ParseController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpPost]
        public ActionResult<Parse> ParseFile([FromForm] FileUpload objectFile)
        {
            Stopwatch stopWatch = new Stopwatch();

            stopWatch.Start();

            string path = _webHostEnvironment.WebRootPath + "\\uploads\\";

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            using (FileStream fileStream = System.IO.File.Create(path + objectFile.files.FileName))
            {
                objectFile.files.CopyTo(fileStream);
                fileStream.Flush();
            }

            var image = Pix.LoadFromFile("wwwroot/uploads/" + objectFile.files.FileName);
            TesseractEngine engine = new TesseractEngine("./tessdata", "eng", EngineMode.Default);

            Page page = engine.Process(image, PageSegMode.Auto);
            string result = page.GetText();

            long timeSpan = stopWatch.ElapsedMilliseconds;

            Parse parsedData = new Parse(result, timeSpan);

            stopWatch.Stop();

            return Ok(parsedData);
        }
    }
}
