using AutoMapper;
using BookSearch.Business.Entities.Dtos;
using BookSearch.WebApi.ViewModels;

namespace BookSearch.WebApi.Tests.Mapper
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<BookViewModel, BookDto>().ReverseMap();
            CreateMap<AuthorViewModel, AuthorDto>().ReverseMap();
        }
    }
}
