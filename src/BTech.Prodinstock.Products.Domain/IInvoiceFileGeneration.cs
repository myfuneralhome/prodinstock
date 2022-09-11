using BTech.Prodinstock.Prodicts.Domain;

namespace BTech.Prodinstock.Core
{
    public interface IInvoiceFileGeneration
    {
        void Generate(InvoiceDocument invoiceDocument, Stream stream);
    }
}