using BTech.Prodinstock.Products.Domain;

namespace BTech.Prodinstock.WebApi
{
    internal sealed class FakeUserProvider
        : ICurrentUserProvider
    {
        public IUser Get()
        {
            return new Owner(Guid.Empty.ToString(), Guid.Empty.ToString());
        }
    }
}
