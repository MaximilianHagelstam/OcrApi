using System.Diagnostics;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using OcrApi.Models;
using Tesseract;

namespace OcrApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ParseController : ControllerBase
    {
        [HttpPost]
        public ActionResult<Parse> ParseFile([FromForm] FileUpload objectFile)
        {
            Stopwatch stopWatch = new();

            stopWatch.Start();

            string path = Path.GetTempPath();

            using (FileStream fileStream = System.IO.File.Create(path + objectFile.Files.FileName))
            {
                objectFile.Files.CopyTo(fileStream);
                fileStream.Flush();
            }

            var image = Pix.LoadFromFile(path + objectFile.Files.FileName);
            TesseractEngine engine = new("./tessdata", "eng", EngineMode.Default);

            Page page = engine.Process(image, PageSegMode.Auto);
            string result = page.GetText();

            long timeSpan = stopWatch.ElapsedMilliseconds;

            Parse parsedData = new(result, timeSpan);

            System.IO.File.Delete(path + objectFile.Files.FileName);

            stopWatch.Stop();

            return Ok(parsedData);
        }
    }
}
