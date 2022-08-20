namespace BTech.Prodinstock.Products.Domain
{
    public interface IWriteRepository<in TEntity>
    {
        Task AddAsync(TEntity entity);
    }
}