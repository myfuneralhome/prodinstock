
using BTech.Prodinstock.Products.Domain.Entities;

namespace BTech.Prodinstock.Products.Domain.UseCases
{
    public sealed class ProductCreation
    {

        private readonly IWriteRepository<Product> _writeRepository;

        public ProductCreation(
            IWriteRepository<Product> writeRepository
            )
        {
            _writeRepository = writeRepository;
        }

        public async Task<CommandResult> ExecuteAsync(NewProduct newProduct)
        {
            CommandResult commandResult =
                new(CanExecute(newProduct));

            if (!commandResult.IsFullSuccess())
            {
                return commandResult;
            }

            var product = new Product()
            {
                Id = Guid.NewGuid().ToString(),
                Description = newProduct.Description,
                BuyingPrice = newProduct.BuyingPrice,
                Name = newProduct.Name,
                NumberInStock = newProduct.NumberInStock,
                SalePrice = newProduct.SalePrice,
                VATRate = newProduct.VATRate
            };

            await _writeRepository.AddAsync(product);

            return commandResult;
        }

        private IReadOnlyList<string> CanExecute(NewProduct newProduct)
        {
            var errors = new List<string>();

            if(string.IsNullOrWhiteSpace(newProduct.Name))
            {
                errors.Add("A name is mandatory.");
            }

            if (newProduct.VATRate < 0 || newProduct.VATRate > 100)
            {
                errors.Add("The VAT value must be between 0 and 100.");
            }

            if (newProduct.SalePrice <= 0)
            {
                errors.Add("The product can not be sell at 0.");
            }

            if (newProduct.SalePrice < newProduct.BuyingPrice)
            {
                errors.Add("The sale price is lower than the buying price.");
            }

            return errors;
        }
    }

    public sealed record NewProduct(
        string Name,
        string Description,
        short NumberInStock,
        decimal SalePrice,
        decimal VATRate,
        decimal BuyingPrice) { }
}
