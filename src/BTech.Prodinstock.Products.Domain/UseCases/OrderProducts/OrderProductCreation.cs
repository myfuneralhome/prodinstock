using BTech.Prodinstock.Core;
using BTech.Prodinstock.Products.Domain.Entities;

namespace BTech.Prodinstock.Products.Domain.UseCases.OrderProducts
{
    public sealed class OrderProductCreation
    {
        private readonly IReadRepository<Invoice> _invoicesStorage;
        private readonly IReadRepository<Product> _productStorage;
        private readonly IWriteRepository<OrderProduct> _orderProductsStorage;

        public OrderProductCreation(
            IReadRepository<Invoice> invoicesStorage,
            IWriteRepository<OrderProduct> orderProductsStorage,
            IReadRepository<Product> productStorage
            )
        {
            _invoicesStorage = invoicesStorage;
            _orderProductsStorage = orderProductsStorage;
            _productStorage = productStorage;
        }

        public async Task<CommandResult> ExecuteAsync(NewOrderProduct newOrderProduct)
        {
            CommandResult commandResult =
                new(await CanExecuteAsync(newOrderProduct));

            if (!commandResult.IsFullSuccess())
            {
                return commandResult;
            }

            await _orderProductsStorage.AddAsync(new OrderProduct()
            {
                Id = Guid.NewGuid().ToString(),
                InvoiceId = newOrderProduct.InvoiceId,
                Price = newOrderProduct.Price,
                ProductId = newOrderProduct.ProductId,
                ProductName = newOrderProduct.ProductName,
                Quantity = newOrderProduct.Quantity
            });

            return commandResult;
        }

        private async Task<IReadOnlyList<string>> CanExecuteAsync(NewOrderProduct newOrderProduct)
        {
            var errors = new List<string>();

            if (!await _invoicesStorage.AnyAsync(f => f.Id == newOrderProduct.InvoiceId))
            {
                errors.Add("The invoice does not exist.");
            }

            if (!await _productStorage.AnyAsync(p => p.Id == newOrderProduct.ProductId))
            {
                errors.Add("The product does not exist.");
            }

            if (string.IsNullOrWhiteSpace(newOrderProduct.ProductName)
                || newOrderProduct.Quantity == 0)
            {
                errors.Add("A choosen product must have a name.");
            }

            if (newOrderProduct.Quantity == 0)
            {
                errors.Add("A quantity can not be set to 0.");
            }

            return errors;
        }
    }

    public sealed record NewOrderProduct(
        string InvoiceId, 
        string ProductId, 
        string ProductName, 
        decimal Price, 
        int Quantity)
    { }
}