namespace Prodinstock.Products.Domain
{
    public record Owner(
        string UserId
        , string UserCompanyId)
        : IUser
    { }
}
