using BTech.Prodinstock.Core;
using BTech.Prodinstock.Products.Domain.Entities;

namespace BTech.Prodinstock.Products.Domain.Queries
{
    public sealed class ListProducts
    {
        private readonly IReadRepository<Product> _readRepository;

        public ListProducts(IReadRepository<Product> readRepository)
        {
            _readRepository = readRepository;
        }

        public async ValueTask<IEnumerable<ExistingProduct>> ExecuteAsync()
        {
            return (await _readRepository.ListAsync())
                .Select(c => new ExistingProduct
                {
                    Id = c.Id,
                    Name = c.Name,
                    BuyingPrice = c.BuyingPrice,
                    VATRate = c.VATRate,
                    CreationDate = c.CreationDate,
                    Description = c.Description,
                    NumberInStock = c.NumberInStock,
                    SalePrice = c.SalePrice
                });
        }
    }

    public sealed class ExistingProduct
    {
        public string Id { get; set; } = null!;
        public DateTime CreationDate { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public short NumberInStock { get; set; }
        public decimal SalePrice { get; set; }
        public decimal VATRate { get; set; }
        public decimal BuyingPrice { get; set; }
    }
}
