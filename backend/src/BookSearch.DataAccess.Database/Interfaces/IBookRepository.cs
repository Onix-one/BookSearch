using BookSearch.DataAccess.Database.Entities;

namespace BookSearch.DataAccess.Database.Interfaces
{
    public interface IBookRepository: IGenericRepository<Book>
    {
        Task<IEnumerable<Book>> GetBySearchAsync(string search);
    }
}
