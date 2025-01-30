using CRS.Offer.Core.Entities;
using CRS.Offer.Core.Repositories.Base;
using CRS.Offer.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CRS.Offer.Infrastructure.Repositories.Base
{
    public class EfRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly DataBaseContext _context;

        public EfRepository(DataBaseContext context)
        {
            _context = context;
        }

        public async Task<T> AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteByIdAsync(Guid id)
        {
            T entity = await GetByIdAsync(id);
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            var findResult = await _context.Set<T>().FindAsync(id);

            return findResult!;
        }

        public async Task UpdateAsync(T entity)
        {
            await _context.SaveChangesAsync();
        }

    }
}
