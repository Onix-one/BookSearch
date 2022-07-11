using BookSearch.Business.Entities.Dtos;
using BookSearch.Business.ExternalServices.Interfaces;

namespace BookSearch.Business.Services.Tests.Stubs
{
    public class StubBookExternalService : IBookExternalService
    {
        private readonly List<BookDto> _books = new()
        {
            new BookDto
            {
                Id = 850,
                GoogleId = "C9vevwEACAAJ",
                Title = "Nika's Adventures",
                Subtitle = "Sex in Africa",
                Authors = new AuthorDto[]
                {
                    new(){ FullName = "John Smottly"}
                },
                PublishedDate = "2018-12-12",
                Description = "The African man knows how to satisfy his woman sexually. Being primitive " +
                              "in nature, they have sex without inhibitions. In fact, legend has it that " +
                              "the reason why most of them go about naked is so they can satisfy their " +
                              "sexual urges at any point in time without the hindrance of clothing.",
                PageCount = 26,
                SmallThumbnail = "http://books.google.com/books/content?id=C9vevwEACAAJ&printsec=frontcover&img=1&zoom=5&source=gbs_api",
                Thumbnail = "http://books.google.com/books/content?id=C9vevwEACAAJ&printsec=frontcover&img=1&zoom=1&source=gbs_api",
                Language = "en"
            }
        };


        public Task<IEnumerable<BookDto>> GetBooksBySearchAsync(string search)
        {
            return Task.FromResult(_books
                .Where(u => u.Title!.Contains(search, StringComparison.OrdinalIgnoreCase)));
        }
    }
}
