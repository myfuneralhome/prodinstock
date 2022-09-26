namespace BTech.Prodinstock.Products.Domain.UseCases.Invoices
{
    public interface IInvoiceFileGeneration
    {
        void Generate(InvoiceDocument invoiceDocument, Stream streamUsedToGenerate);
    }
}