namespace BTech.Prodinstock.Products.Domain
{
    public interface ICurrentUserProvider
    {
        public Task<IUser> Get();
    }
}
