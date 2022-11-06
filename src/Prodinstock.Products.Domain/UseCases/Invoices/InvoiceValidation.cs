using Prodinstock.Core;
using Prodinstock.Products.Domain.Entities;
using Prodinstock.Products.Domain.UseCases.Invoices;

namespace Prodinstock.Products.Domain.UseCases
{
    public sealed class InvoiceValidation
    {
        private readonly IWriteRepository<Invoice> _writeRepository;
        private readonly IReadRepository<Invoice> _readRepository;
        private readonly InvoiceNumberGenerator _invoiceNumberGenerator;

        public InvoiceValidation(
            IWriteRepository<Invoice> writeRepository,
            IReadRepository<Invoice> readRepository,
            InvoiceNumberGenerator invoiceNumberGenerator
            )
        {
            _writeRepository = writeRepository;
            _readRepository = readRepository;
            _invoiceNumberGenerator = invoiceNumberGenerator;
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

            invoiceToUpdate!.Number = await _invoiceNumberGenerator.ExecuteAsync();

            invoiceToUpdate.State = InvoiceState.Validated;

            await _writeRepository.UpdateAsync(invoiceToUpdate);

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

            if (string.IsNullOrWhiteSpace(invoiceToUpdate.BuyerFullName))
            {
                errors.Add("Buyer name is mandatory.");
            }

            if (string.IsNullOrWhiteSpace(invoiceToUpdate.BuyerPostalAddress?.Street)
                || string.IsNullOrWhiteSpace(invoiceToUpdate.BuyerPostalAddress?.City)
                || string.IsNullOrWhiteSpace(invoiceToUpdate.BuyerPostalAddress?.PostalCode))
            {
                errors.Add("Address is mandatory.");
            }

            return errors;
        }
    }

}