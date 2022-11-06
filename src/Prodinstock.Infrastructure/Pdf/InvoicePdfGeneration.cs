using Prodinstock.Products.Domain.UseCases.Invoices;
using QuestPDF.Fluent;

namespace Prodinstock.Infrastructure.Pdf
{
    internal class InvoicePdfGeneration
        : IInvoiceFileGeneration
    {
        public void Generate(
            InvoiceDocument invoiceDocument,
            Stream streamUsedToGenerate)
        {
            var document = new InvoicePdfDocument(invoiceDocument);

            document.GeneratePdf(streamUsedToGenerate);
        }
    }
}