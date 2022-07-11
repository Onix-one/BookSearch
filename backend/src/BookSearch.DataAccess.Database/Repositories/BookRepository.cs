using BookSearch.DataAccess.Database.Contexts;
using BookSearch.DataAccess.Database.Entities;
using BookSearch.DataAccess.Database.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookSearch.DataAccess.Database.Repositories
{
    public class BookRepository : GenericRepository<Book>, IBookRepository
    {
        public BookRepository(ApplicationDbContext context) : base(context) { }


        public async Task<IEnumerable<Book>> GetBySearchAsync(string search)
        {
            var result = await EntityDbSet
                .Where(u => u.Title!.Contains(search)).ToListAsync();
            return result!;
        }


    }
}
