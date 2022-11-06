using Prodinstock.Infrastructure.Pdf;
using Prodinstock.Products.Domain.UseCases.Invoices;

namespace Prodinstock.Products.UnitTests
{
    public class InvoicePdfGenerationTest
    {
        [Fact]
        public void Generate()
        {
            var invoicePdfGeneration = new InvoicePdfGeneration();
            using (var stream = new MemoryStream())
            {
                invoicePdfGeneration.Generate(new InvoiceDocument(), stream);
                Assert.NotNull(stream);
            }
        }
    }
}