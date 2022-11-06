using Prodinstock.Core;
using Prodinstock.Products.Domain.Entities;

namespace Prodinstock.Products.Domain.UseCases
{
    public sealed class SupplierCreation
    {
        private readonly IWriteRepository<Supplier> _writeRepository;
        private readonly IReadRepository<Supplier> _readRepository;

        public SupplierCreation(
            IWriteRepository<Supplier> writeRepository,
            IReadRepository<Supplier> readRepository
            )
        {
            _writeRepository = writeRepository;
            _readRepository = readRepository;
        }

        public async Task<CommandResult> ExecuteAsync(NewSupplier newSupplier)
        {
            CommandResult commandResult =
                new(await CanExecuteAsync(newSupplier));

            if (!commandResult.IsFullSuccess())
            {
                return commandResult;
            }

            var supplier = new Supplier()
            {
                Id = Guid.NewGuid().ToString(),
                Name = newSupplier.Name,
                UserCompanyId = newSupplier.Owner.UserCompanyId
            };

            await _writeRepository.AddAsync(supplier);

            return commandResult;
        }

        private async Task<IReadOnlyList<string>> CanExecuteAsync(NewSupplier newSupplier)
        {
            var errors = new List<string>();

            if (string.IsNullOrWhiteSpace(newSupplier.Name))
            {
                errors.Add("A name is mandatory.");
            }

            if (newSupplier.Name != null
                && await _readRepository.AnyAsync(c => c.Name == newSupplier.Name))
            {
                errors.Add("This name has already been taken for another existing supplier.");
            }

            return errors;
        }
    }

    public sealed record NewSupplier(
        string Name,
        IUser Owner)
    {
    }
}
