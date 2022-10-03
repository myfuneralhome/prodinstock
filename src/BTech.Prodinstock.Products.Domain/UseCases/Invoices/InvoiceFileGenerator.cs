using BTech.Prodinstock.Core;
using BTech.Prodinstock.Products.Domain.Entities;

namespace BTech.Prodinstock.Products.Domain.UseCases.Invoices
{
    public sealed class InvoiceFileGenerator
    {
        private readonly IReadRepository<Invoice> _readRepository;
        private readonly IInvoiceFileGeneration _invoiceFileGeneration;

        public InvoiceFileGenerator(
            IReadRepository<Invoice> readRepository,
            IInvoiceFileGeneration invoiceFileGeneration)
        {
            _readRepository = readRepository;
            _invoiceFileGeneration = invoiceFileGeneration;
        }

        public async Task<bool> TryGetAsync(string invoiceId, Stream fileHandler)
        {
            var invoice = await _readRepository.GetAsync(invoiceId);

            if (invoice is null)
            {
                return false;
            }

            var invoiceDocument = new InvoiceDocument()
            {
                InvoiceNumber = invoice.Number ?? "DRAFT",
                IssueDate = DateTime.UtcNow,
                DueDate = DateTime.UtcNow.AddDays(30),
                SellerAddress = new Address(
                    "N/A",
                    "N/A",
                    "N/A",
                    "N/A"),
                CustomerAddress = new Address(
                    invoice.BuyerFullName ?? "N/A",
                    invoice.BuyerPostalAddress?.Street ?? "N/A",
                    invoice.BuyerPostalAddress?.City ?? "N/A",
                    invoice.BuyerPostalAddress?.PostalCode ?? "N/A")
            };

            foreach (var orderProductsItem in invoice.OrderProducts)
            {
                invoiceDocument.Items.Add(new OrderItem()
                {
                    Name = orderProductsItem.ProductName,
                    Price = orderProductsItem.Price,
                    Quantity = orderProductsItem.Quantity
                });
            }

            _invoiceFileGeneration.Generate(invoiceDocument, fileHandler);

            return true;
        }
    }
}