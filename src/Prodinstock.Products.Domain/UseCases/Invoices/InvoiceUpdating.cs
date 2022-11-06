using BTech.Prodinstock.Core;
using BTech.Prodinstock.Products.Domain.Entities;

namespace BTech.Prodinstock.Products.Domain.UseCases
{
    public sealed class InvoiceUpdating
    {
        private readonly IWriteRepository<Invoice> _writeRepository;
        private readonly IReadRepository<Invoice> _readRepository;

        public InvoiceUpdating(
            IWriteRepository<Invoice> writeRepository,
            IReadRepository<Invoice> readRepository
            )
        {
            _writeRepository = writeRepository;
            _readRepository = readRepository;
        }

        public async Task<CommandResult> ValidateAsync(string invoiceId)
        {
            var invoiceToUpdate = await _readRepository.GetAsync(invoiceId);

            CommandResult commandResult =
                new(CanValidate(invoiceToUpdate));

            if (!commandResult.IsFullSuccess())
            {
                return commandResult;
            }

            invoiceToUpdate!.Number = 

            await _writeRepository.AddAsync(invoice);

            return commandResult;
        }

        private IReadOnlyList<string> CanValidate(Invoice? invoiceToUpdate)
        {
            var errors = new List<string>();

            if(invoiceToUpdate is null)
            {
                errors.Add($"The invoice was not found.");
                return errors;
            }

            if (invoiceToUpdate.State == InvoiceState.Validated)
            {
                errors.Add("The invoice is already validated.");
            }

            if (string.IsNullOrWhiteSpace(invoiceToUpdate.Name))
            {
                errors.Add("A name is mandatory.");
            }

            if (string.IsNullOrWhiteSpace(invoiceToUpdate.Buyer.FullName))
            {
                errors.Add("Buyer name is mandatory.");
            }

            if (string.IsNullOrWhiteSpace(invoiceToUpdate.Buyer.PostalAddress.Street)
                || string.IsNullOrWhiteSpace(invoiceToUpdate.Buyer.PostalAddress.City)
                || string.IsNullOrWhiteSpace(invoiceToUpdate.Buyer.PostalAddress.PostalCode))
            {
                errors.Add("Address is mandatory.");
            }

            return errors;
        }
    }

}