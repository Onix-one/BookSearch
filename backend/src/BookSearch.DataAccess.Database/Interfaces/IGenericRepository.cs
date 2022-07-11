using BookSearch.DataAccess.Database.Entities;

namespace BookSearch.DataAccess.Database.Interfaces
{
    public interface IGenericRepository<TEntity>
        where TEntity : BaseEntity
    {
        IQueryable<TEntity> Query { get; }

        Task<IEnumerable<TEntity>> GetAllAsync();

        Task<TEntity> GetByIdAsync(int id);

        Task InsertAsync(TEntity entity);

        Task InsertAsync(IEnumerable<TEntity> entities);

        Task<TEntity> UpdateAsync(TEntity entity);

        Task UpdateAsync(IEnumerable<TEntity> entities);

        Task DeleteAsync(int id);

        Task DeleteAsync(TEntity entity);

        Task DeleteAsync(IEnumerable<TEntity> entities);
    }
}
