using AutoMapper;
using BookSearch.Business.Entities.Dtos;
using BookSearch.DataAccess.Database.Entities;

namespace BookSearch.Business.Services.Tests.Mapper
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<Book, BookDto>().ReverseMap();
            CreateMap<Author, AuthorDto>().ReverseMap();
        }
    }
}
