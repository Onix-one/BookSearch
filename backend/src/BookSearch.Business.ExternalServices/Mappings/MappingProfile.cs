using System.Text.Json.Nodes;
using AutoMapper;
using BookSearch.Business.Entities.Dtos;
using BookSearch.DataAccess.ExternalDatabase.Entities;
using Newtonsoft.Json;

namespace BookSearch.Business.ExternalServices.Mappings
{
    public class ExternalMappingProfile : Profile
    {
        public ExternalMappingProfile()
        {
            CreateMap<BookEntity, BookDto>()
                .ForMember(p => p.GoogleId,
                    o => o.MapFrom(s => s.Id))
                .ForMember(p => p.Title,
                    o => o.MapFrom(s => s.VolumeInfo!.Title))
                .ForMember(p => p.Subtitle,
                    o => o.MapFrom(s => s.VolumeInfo!.Subtitle))
                .ForMember(p => p.Authors,
                    o => o.MapFrom(s => s.VolumeInfo!.Authors))
                .ForMember(p => p.PublishedDate,
                    o => o.MapFrom(s => s.VolumeInfo!.PublishedDate))
                .ForMember(p => p.Description,
                    o => o.MapFrom(s => s.VolumeInfo!.Description))
                .ForMember(p => p.PageCount,
                    o => o.MapFrom(s => s.VolumeInfo!.PageCount))
                .ForMember(p => p.SmallThumbnail,
                    o => o.MapFrom(s => s.VolumeInfo!.ImageLinks!.SmallThumbnail))
                .ForMember(p => p.Thumbnail,
                    o => o.MapFrom(s => s.VolumeInfo!.ImageLinks!.Thumbnail))
                .ForMember(p => p.Language,
                    o => o.MapFrom(s => s.VolumeInfo!.Language));

        }
    }
}
