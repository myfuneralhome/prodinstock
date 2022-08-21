namespace BTech.Prodinstock.Products.Domain.Queries
{
    public interface IQuery<TResult> { }

    public interface IQueryHandler<IQuery, TResult>
        where IQuery : IQuery<TResult>
    {
        Task<TResult> HandleAsync(IQuery query);
    }
}
