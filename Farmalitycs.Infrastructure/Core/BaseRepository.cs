using Farmalitycs.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Farmalitycs.Infrastructure.Core
{
    public abstract class BaseRepository<T> where T : class
    {
        protected readonly FarmalitycsContext _context;

        public BaseRepository(FarmalitycsContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<T>> GetAllAsync() =>
            await _context.Set<T>().ToListAsync();

        public async Task<T> GetByIdAsync(int id) =>
            await _context.Set<T>().FindAsync(id);

        public async Task AddAsync(T entity)
        {
            _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}

