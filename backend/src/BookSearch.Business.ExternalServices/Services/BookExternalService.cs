using BookSearch.Business.Entities.Dtos;
using BookSearch.Business.ExternalServices.Interfaces;
using BookSearch.DataAccess.ExternalDatabase.Interfaces;

namespace BookSearch.Business.ExternalServices.Services
{
    public sealed class BookExternalService : IBookExternalService
    {

        private readonly IBookHttpService _bookHttpService;
        public BookExternalService(IBookHttpService bookHttpService)
        {
            _bookHttpService = bookHttpService;
        }

        public async Task<IEnumerable<BookDto>> GetBooksBySearchAsync(string search)
        {
            var bookEntities = await _bookHttpService.GetBooksBySearchAsync(search);
            if (bookEntities == null) return new List<BookDto>();

            var bookList = new List<BookDto>();
            foreach (var bookEntity in bookEntities)
            {
                var listWithAuthors = new List<AuthorDto>();

                if (bookEntity.VolumeInfo!.Authors != null)
                {
                    foreach (var authorEntity in bookEntity.VolumeInfo.Authors)
                    {
                        var authorDto = new AuthorDto()
                        {
                            FullName = authorEntity
                        };
                        listWithAuthors.Add(authorDto);
                    }
                }

                var bookDto = new BookDto()
                {
                    GoogleId = bookEntity.Id,
                    Title = bookEntity.VolumeInfo.Title,
                    Subtitle = bookEntity.VolumeInfo.Subtitle,
                    Authors = listWithAuthors,
                    PublishedDate = bookEntity.VolumeInfo.PublishedDate,
                    Description = bookEntity.VolumeInfo.Description,
                    PageCount = bookEntity.VolumeInfo.PageCount,
                    SmallThumbnail = bookEntity.VolumeInfo.ImageLinks != null ? bookEntity.VolumeInfo.ImageLinks!.SmallThumbnail : null,
                    Thumbnail = bookEntity.VolumeInfo.ImageLinks != null ? bookEntity.VolumeInfo.ImageLinks!.Thumbnail : null,
                    Language = bookEntity.VolumeInfo.Language
                };
                bookList.Add(bookDto);
            }
            return bookList;
        }
    }
}
