using System;
using System.Diagnostics;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OcrApi.Dtos;
using OcrApi.Models;
using Tesseract;

namespace OcrApi.Controllers
{
    [ApiController]
    [Route("api/parse")]
    public class ParseController : ControllerBase
    {
        private readonly IMapper _mapper;

        public ParseController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpPost]
        public ActionResult<ParseResponseDto> ParseFile(ParseRequestDto parseRequestDto)
        {
            var parseModel = _mapper.Map<Parse>(parseRequestDto);

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            var image = Pix.LoadFromFile("hello.jpg");
            TesseractEngine engine = new TesseractEngine("./tessdata", "eng", EngineMode.Default);

            Page page = engine.Process(image, PageSegMode.Auto);
            string result = page.GetText();

            stopWatch.Stop();
            long timeSpan = stopWatch.ElapsedMilliseconds;

            parseModel.ParsedText = result;
            parseModel.ProcessingTimeInMilliseconds = timeSpan;

            var parseResponseDto = _mapper.Map<ParseResponseDto>(parseModel);

            return Ok(parseResponseDto);
        }
    }
}
