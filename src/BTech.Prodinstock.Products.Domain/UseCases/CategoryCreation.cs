using BTech.Prodinstock.Core;
using BTech.Prodinstock.Products.Domain.Entities;

namespace BTech.Prodinstock.Products.Domain.UseCases
{
    public sealed class CategoryCreation
    {
        private readonly IWriteRepository<Category> _writeRepository;
        private readonly IReadRepository<Category> _readRepository;

        public CategoryCreation(
            IWriteRepository<Category> writeRepository,
            IReadRepository<Category> readRepository
            )
        {
            _writeRepository = writeRepository;
            _readRepository = readRepository;
        }

        public async Task<CommandResult> ExecuteAsync(NewCategory newCategory)
        {
            CommandResult commandResult =
                new(await CanExecuteAsync(newCategory));

            if (!commandResult.IsFullSuccess())
            {
                return commandResult;
            }

            var category = new Category()
            {
                Id = Guid.NewGuid().ToString(),
                Name = newCategory.Name,
                UserCompanyId = newCategory.User.UserCompanyId
            };

            await _writeRepository.AddAsync(category);

            return commandResult;
        }

        private async Task<IReadOnlyList<string>> CanExecuteAsync(NewCategory newCategory)
        {
            var errors = new List<string>();

            if (string.IsNullOrWhiteSpace(newCategory.Name))
            {
                errors.Add("A name is mandatory.");
            }

            if (newCategory.Name != null
                && await _readRepository.AnyAsync(c => c.Name == newCategory.Name))
            {
                errors.Add("This name has already been taken for another existing category.");
            }

            return errors;
        }
    }

    public sealed record NewCategory(
        string Name
        , IUser User)
    { }
}
