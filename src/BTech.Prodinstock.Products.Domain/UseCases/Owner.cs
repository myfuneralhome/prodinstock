namespace BTech.Prodinstock.Products.Domain
{
    public record Owner(
        string UserId)
        : IUserId
    { }
}