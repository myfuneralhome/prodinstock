namespace Prodinstock.Core
{
    public interface IWriteRepository<in TEntity>
    {
        Task AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
    }
}