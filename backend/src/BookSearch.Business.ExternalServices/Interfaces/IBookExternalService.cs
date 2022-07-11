using BookSearch.Business.Entities.Dtos;

namespace BookSearch.Business.ExternalServices.Interfaces
{
    public interface IBookExternalService
    {
        public Task<IEnumerable<BookDto>> GetBooksBySearchAsync(string search);

    }
}
