using AutoMapper;
using BookSearch.Business.Entities.Dtos;
using BookSearch.DataAccess.Database.Entities;

namespace BookSearch.Business.Services.Mappings
{
    public class MappingProfileFromServices : Profile
    {
        public MappingProfileFromServices()
        {
            CreateMap<Book, BookDto>().ReverseMap();
            CreateMap<Author, AuthorDto>().ReverseMap();
        }
    }
}
