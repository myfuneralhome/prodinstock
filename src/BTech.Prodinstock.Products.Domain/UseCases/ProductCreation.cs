
using BTech.Prodinstock.Core;
using BTech.Prodinstock.Products.Domain.Entities;

namespace BTech.Prodinstock.Products.Domain.UseCases
{
    public sealed class ProductCreation
    {

        private readonly IWriteRepository<Product> _writeRepository;
        private readonly IReadRepository<Category> _categoryRepository;
        private readonly IReadRepository<Supplier> _supplierRepository;
        private readonly IReadRepository<AccountingAccount> _accountingAccountRepository;

        public ProductCreation(
            IWriteRepository<Product> writeRepository,
            IReadRepository<Category> categoryRepository,
            IReadRepository<Supplier> supplierRepository,
            IReadRepository<AccountingAccount> accountingAccountRepository
            )
        {
            _writeRepository = writeRepository;
            _categoryRepository = categoryRepository;
            _supplierRepository = supplierRepository;
            _accountingAccountRepository = accountingAccountRepository;
        }

        public async Task<CommandResult> ExecuteAsync(NewProduct newProduct)
        {
            CommandResult commandResult =
                new(await CanExecuteAsync(newProduct));

            if (!commandResult.IsFullSuccess())
            {
                return commandResult;
            }

            var product = new Product()
            {
                Id = Guid.NewGuid().ToString(),
                CreationDate = DateTime.UtcNow,
                Description = newProduct.Description,
                BuyingPrice = newProduct.BuyingPrice,
                Name = newProduct.Name,
                NumberInStock = newProduct.NumberInStock,
                SalePrice = newProduct.SalePrice,
                VATRate = newProduct.VATRate,
                CategoryId = newProduct.CategoryId,
                SupplierId = newProduct.SupplierId,
                AccountingAccountId = newProduct.AccoutingAccountId
            };

            await _writeRepository.AddAsync(product);

            return commandResult;
        }

        private async Task<IReadOnlyList<string>> CanExecuteAsync(NewProduct newProduct)
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

            if(newProduct.CategoryId != null
                && !(await _categoryRepository.AnyAsync(c => c.Id == newProduct.CategoryId)))
            {
                errors.Add("The category does not exist.");
            }

            if (newProduct.AccoutingAccountId != null
                && !(await _accountingAccountRepository.AnyAsync(c => c.Id == newProduct.AccoutingAccountId)))
            {
                errors.Add("The accounting account does not exist.");
            }

            return errors;
        }
    }

    public sealed record NewProduct(
        string? SupplierId,
        string? CategoryId,
        string Name,
        string Description,
        short NumberInStock,
        decimal SalePrice,
        decimal VATRate,
        int? AccoutingAccountId,
        decimal BuyingPrice) { }
}
