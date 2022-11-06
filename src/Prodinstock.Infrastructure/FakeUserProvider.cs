using Prodinstock.Core;
using Prodinstock.Products.Domain;
using Prodinstock.Products.Domain.Entities;

namespace Prodinstock.Infrastructure
{
    internal sealed class FakeUserProvider
        : ICurrentUserProvider
    {
        private readonly IReadRepository<UserCompany> _readRepository;
        private readonly IWriteRepository<UserCompany> _writeRepository;

        public FakeUserProvider(
            IReadRepository<UserCompany> readRepository,
            IWriteRepository<UserCompany> writeRepository)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
        }

        public async Task<IUser> Get()
        {
            var companies = await _readRepository.ListAsync();

            var firstCompany = companies.FirstOrDefault();
            if (firstCompany == null)
            {
                firstCompany = new UserCompany() { Id = Guid.NewGuid().ToString(), LegalName = "Test" };
                await _writeRepository.AddAsync(firstCompany);
            }

            return new Owner(Guid.Empty.ToString(), firstCompany.Id);
        }
    }
}
