using BTech.Prodinstock.Core;
using BTech.Prodinstock.Prodicts.Domain;
using QuestPDF.Fluent;

namespace BTech.Prodinstock.Infrastructure.Pdf
{
    internal class InvoicePdfGeneration
        : IInvoiceFileGeneration
    {
        public void Generate(
            InvoiceDocument invoiceDocument,
            Stream stream)
        {
            var model = InvoiceDocumentDataSource.GetInvoiceDetails();
            var document = new InvoicePdfDocument(model);

            document.GeneratePdf(stream);
        }
    }
}