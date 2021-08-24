using AutoMapper;
using OcrApi.Dtos;
using OcrApi.Models;

namespace OcrApi.Profiles
{
    public class ParseProfile : Profile
    {
        public ParseProfile()
        {
            CreateMap<Parse, ParseResponseDto>();
            CreateMap<ParseRequestDto, Parse>();
        }
    }
}
