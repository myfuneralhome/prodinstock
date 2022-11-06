using Prodinstock.Core;
using Prodinstock.Products.Domain.Entities;

namespace Prodinstock.Products.Domain.UseCases.OrderProducts
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

            var invoice = await _invoicesStorage.GetAsync(newOrderProduct.InvoiceId);
            if (invoice is null)
            {
                errors.Add("The invoice does not exist.");
                return errors;
            }

            var product = await _productStorage.GetAsync(newOrderProduct.ProductId);
            if (product is null)
            {
                errors.Add("The product does not exist.");
                return errors;
            }

            if (invoice != null 
                && invoice.State == InvoiceState.Validated)
            {
                errors.Add("The invoice have been validated. You can not add or update order product.");
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