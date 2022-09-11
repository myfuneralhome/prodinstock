using BTech.Prodinstock.Core;
using BTech.Prodinstock.Products.Domain.Entities;
using BTech.Prodinstock.Products.Domain.UseCases.Invoices;
using System.ComponentModel.DataAnnotations;

namespace BTech.Prodinstock.Products.Domain.UseCases
{
    public sealed class InvoiceCreation
    {
        private readonly IWriteRepository<Invoice> _writeRepository;

        public InvoiceCreation(
            IWriteRepository<Invoice> writeRepository
            )
        {
            _writeRepository = writeRepository;
        }

        public async Task<CommandResult> ExecuteAsync(NewInvoice newInvoice)
        {
            CommandResult commandResult =
                new(CanExecute(newInvoice));

            if (!commandResult.IsFullSuccess())
            {
                return commandResult;
            }

            var invoice = new Invoice()
            {
                Id = Guid.NewGuid().ToString(),
                Name = newInvoice.Name,
                CreationDate = DateOnly.FromDateTime(DateTime.UtcNow),
                Buyer = newInvoice.Buyer,
                State = InvoiceState.Draft
            };

            await _writeRepository.AddAsync(invoice);

            return commandResult;
        }

        private IReadOnlyList<string> CanExecute(NewInvoice newInvoice)
        {
            var errors = new List<string>();

            if (string.IsNullOrWhiteSpace(newInvoice.Name))
            {
                errors.Add("A name is mandatory.");
            }

            if (string.IsNullOrWhiteSpace(newInvoice.Buyer.FullName))
            {
                errors.Add("Buyer name is mandatory.");
            }

            if (string.IsNullOrWhiteSpace(newInvoice.Buyer.PostalAddress.Street)
                || string.IsNullOrWhiteSpace(newInvoice.Buyer.PostalAddress.City)
                || string.IsNullOrWhiteSpace(newInvoice.Buyer.PostalAddress.PostalCode))
            {
                errors.Add("Address is mandatory.");
            }

            return errors;
        }
    }

    public sealed record NewInvoice(
        [property: Required] string Name,
        [property: Required] Buyer Buyer
        )
    { }
}