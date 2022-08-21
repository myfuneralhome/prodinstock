namespace BTech.Prodinstock.Core
{
    public interface IWriteRepository<in TEntity>
    {
        Task AddAsync(TEntity entity);
    }
}