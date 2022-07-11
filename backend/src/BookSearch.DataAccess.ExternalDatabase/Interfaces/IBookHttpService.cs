using BookSearch.DataAccess.ExternalDatabase.Entities;

namespace BookSearch.DataAccess.ExternalDatabase.Interfaces
{
    public interface IBookHttpService
    {
        Task<IEnumerable<BookEntity>> GetBooksBySearchAsync(string search);
    }
}
