using System.Linq.Expressions;

namespace BTech.Prodinstock.Products.Domain
{
    public interface IReadRepository<TEntity>
    {
        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> filter);
        Task<TEntity?> GetAsync(object id);

        Task<IEnumerable<TEntity>> ListAsync();

        Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> filter
            , Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null);
    }
}