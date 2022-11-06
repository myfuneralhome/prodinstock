namespace Prodinstock.Products.Domain.Entities
{
    public class UserCompany
    {
        public string Id { get; set; } = null!;
        public string LegalName { get; set; } = null!;
        public string? CompanyRegistrationNumber { get; set; }
    }
}
