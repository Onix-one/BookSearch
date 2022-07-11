using AutoMapper;
using BookSearch.Business.Entities.Dtos;
using BookSearch.WebApi.ViewModels;

namespace BookSearch.WebApi.Mapping
{
    public class MappingProfileUi : Profile
    {
        public MappingProfileUi()
        {
            CreateMap<BookViewModel, BookDto>().ReverseMap();
            CreateMap<AuthorViewModel, AuthorDto>().ReverseMap();
        }
    }
}
