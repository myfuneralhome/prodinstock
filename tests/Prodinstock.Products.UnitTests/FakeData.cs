using Prodinstock.Products.Domain.UseCases.Invoices;
using QuestPDF.Helpers;

namespace Prodinstock.Products.UnitTests
{
    public static class InvoiceDocumentDataSource
    {
        private static Random Random = new Random();

        public static InvoiceDocument GetInvoiceDetails()
        {
            var items = Enumerable
                .Range(1, 8)
                .Select(i => GenerateRandomOrderItem())
                .ToList();

            var invoiceDocument = new InvoiceDocument
            {
                InvoiceNumber = "F" + Random.Next(1_000, 10_000),
                IssueDate = DateTime.Now,
                DueDate = DateTime.Now + TimeSpan.FromDays(14),

                SellerAddress = GenerateRandomAddress(),
                CustomerAddress = GenerateRandomAddress(),

                Comments = Placeholders.Paragraph()
            };

            invoiceDocument.Items.AddRange(items);

            return invoiceDocument;
        }

        private static OrderItem GenerateRandomOrderItem()
        {
            return new OrderItem
            {
                Name = Placeholders.Label(),
                Price = (decimal)Math.Round(Random.NextDouble() * 100, 2),
                Quantity = Random.Next(1, 10)
            };
        }

        private static Address GenerateRandomAddress()
        {
            return new Address(
                Placeholders.Name(),
                Placeholders.Label(),
                Placeholders.Label(),
                Placeholders.Label(),
                Placeholders.Email(),
                Placeholders.PhoneNumber());
        }
    }
}