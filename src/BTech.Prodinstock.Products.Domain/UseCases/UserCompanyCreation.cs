using BTech.Prodinstock.Core;
using BTech.Prodinstock.Products.Domain.Entities;

namespace BTech.Prodinstock.Products.Domain.UseCases
{
    public sealed class UserCompanyCreation
    {
        private readonly IWriteRepository<UserCompany> _writeRepository;
        private readonly IReadRepository<UserCompany> _readRepository;

        public UserCompanyCreation(
            IWriteRepository<UserCompany> writeRepository,
            IReadRepository<UserCompany> readRepository
            )
        {
            _writeRepository = writeRepository;
            _readRepository = readRepository;
        }

        public async Task<CommandResult> ExecuteAsync(NewCompany newCompany)
        {
            CommandResult commandResult =
                new(await CanExecuteAsync(newCompany));

            if (!commandResult.IsFullSuccess())
            {
                return commandResult;
            }

            var company = new UserCompany()
            {
                Id = Guid.NewGuid().ToString(),
                LegalName = newCompany.LegalName
            };

            await _writeRepository.AddAsync(company);

            return commandResult;
        }

        private async Task<IReadOnlyList<string>> CanExecuteAsync(NewCompany newCompany)
        {
            var errors = new List<string>();

            if (string.IsNullOrWhiteSpace(newCompany.LegalName))
            {
                errors.Add("The legal name of the company is mandatory.");
            }

            if (newCompany.LegalName != null
                && await _readRepository.AnyAsync(c => c.LegalName == newCompany.LegalName))
            {
                errors.Add("This name has already been taken for another existing company. You must contact the support.");
            }

            return errors;
        }
    }

    public sealed record NewCompany(
        string LegalName)
    {
    }
}
