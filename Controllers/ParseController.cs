using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OcrApi.Dtos;
using OcrApi.Models;

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

            var parseResponseDto = _mapper.Map<ParseResponseDto>(parseModel);

            return Ok(parseResponseDto);
        }
    }
}
