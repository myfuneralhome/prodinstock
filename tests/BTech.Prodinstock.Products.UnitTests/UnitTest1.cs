using BTech.Prodinstock.Infrastructure.Pdf;
using BTech.Prodinstock.Prodicts.Domain;

namespace BTech.Prodinstock.Products.UnitTests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var invoicePdfGeneration = new InvoicePdfGeneration();
            using (var stream = new MemoryStream())
            {
            }
            invoicePdfGeneration.Generate(new InvoiceDocument(), stream));
        }
    }
}