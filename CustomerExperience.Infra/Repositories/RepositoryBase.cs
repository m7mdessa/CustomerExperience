using CustomerExperience.Domain.Shared;
using CustomerExperience.Infra;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;


namespace Infrastructure.Repositories
{
    public class RepositoryBase<T> : IGenericRepository<T> where T :BaseEntity
    {

        protected readonly AppDbContext _context;

        public RepositoryBase(AppDbContext context)
        {

            _context = context;
        }
        public async Task AddAsync(T entity)
        {
            await _context.AddAsync(entity);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _context.Remove(entity);

            await _context.SaveChangesAsync();
        }

  
        public async Task<IReadOnlyList<T>> GetAllAsync(params Expression<Func<T, object>>[] includeExpressions)
        {
            IQueryable<T> query = _context.Set<T>().AsNoTracking();

            foreach (var includeExpression in includeExpressions)
            {
                query = query.Include(includeExpression);
            }

            return await query.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id, params Expression<Func<T, object>>[] includeExpressions)
        {
            IQueryable<T> query = _context.Set<T>();

            foreach (var includeExpression in includeExpressions)
            {
                query = query.Include(includeExpression);
            }

            return await query.FirstOrDefaultAsync(q => q.Id == id);
        }
 
        public async Task<T> GetAsync(int id)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(q => q.Id == id);
        }

        public async Task UpdateAsync(T entity)
        {
            _context.ChangeTracker.DetectChanges();

            await _context.SaveChangesAsync();

        }


    }
}
