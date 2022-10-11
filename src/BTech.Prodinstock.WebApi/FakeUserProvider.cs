using BTech.Prodinstock.Products.Domain;

namespace BTech.Prodinstock.WebApi
{
    internal sealed class FakeUserProvider
        : ICurrentUserProvider
    {
        public IUserId Get()
        {
            return new Owner(Guid.NewGuid().ToString());
        }
    }
}
