
using BTech.Prodinstock.Core;
using BTech.Prodinstock.Products.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace BTech.Prodinstock.Products.Domain.UseCases
{
    public sealed class CategoryCreation
    {

        private readonly IWriteRepository<Category> _writeRepository;

        public CategoryCreation(
            IWriteRepository<Category> writeRepository
            )
        {
            _writeRepository = writeRepository;
        }

        public async Task<CommandResult> ExecuteAsync(NewCategory newCategory)
        {
            CommandResult commandResult =
                new(CanExecute(newCategory));

            if (!commandResult.IsFullSuccess())
            {
                return commandResult;
            }

            var category = new Category()
            {
                Id = Guid.NewGuid().ToString(),
                Name = newCategory.Name
            };

            await _writeRepository.AddAsync(category);

            return commandResult;
        }

        private IReadOnlyList<string> CanExecute(NewCategory newCategory)
        {
            var errors = new List<string>();

            if(string.IsNullOrWhiteSpace(newCategory.Name))
            {
                errors.Add("A name is mandatory.");
            }

            return errors;
        }
    }

    public sealed class NewCategory {
        [Required]
        public string Name { get; set; } = null!;
    }
}
