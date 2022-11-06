using Prodinstock.Core;
using Prodinstock.Products.Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Prodinstock.Infrastructure.Storage.Ef
{
    internal sealed class EfRepository<TEntity>
        : IWriteRepository<TEntity>,
        IReadRepository<TEntity>
        where TEntity : class
    {
        private readonly ProductContext _context;

        public EfRepository(ProductContext expenseSystemContext)
        {
            _context = expenseSystemContext;
        }

        public IQueryable<TEntity> Entities => _context.Set<TEntity>();

        public async Task AddAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> filter)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            return await query.AnyAsync();
        }

        public async Task<IEnumerable<TEntity>> FindAsync(
            Expression<Func<TEntity, bool>> filter
            , Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (orderBy != null)
            {
                return await orderBy(query).ToListAsync();
            }
            else
            {
                return await query.ToListAsync();
            }
        }

        public async Task<TEntity?> GetAsync(object id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> ListAsync()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

    }
}