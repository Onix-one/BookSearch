using BookSearch.Business.Entities.Dtos;

namespace BookSearch.Business.Services.Interfaces
{
    public interface IBookService
    {
        public Task<IEnumerable<BookDto>> GetBooksBySearchAsync(string search);

    }
}
