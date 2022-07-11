using BookSearch.Business.Entities.Base;

namespace BookSearch.Business.Entities.Dtos
{
    public class BookDto : BaseDto
    {
        public string? GoogleId { get; set; }

        public string? Title { get; set; }

        public string? Subtitle { get; set; }

        public IEnumerable<AuthorDto>? Authors { get; set; }

        public string? PublishedDate { get; set; }

        public string? Description { get; set; }

        public int PageCount { get; set; }

        public string? SmallThumbnail { get; set; }

        public string? Thumbnail { get; set; }

        public string? Language { get; set; }

    }
}
