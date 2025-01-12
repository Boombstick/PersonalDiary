using System.Numerics;
using Microsoft.EntityFrameworkCore;
using PersonalDiary.Domain.Repositories;

namespace PersonalDiary.Persistence.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DiaryDbContext _context;
        protected readonly DbSet<TEntity> _dbSet;

        public Repository(DiaryDbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        private async Task<TEntity?> GetByIdAsync<T>(T? id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task DeleteAsync<T>(T id) where T : notnull
        {
            var entity = await GetByIdAsync(id) ?? throw new KeyNotFoundException();
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteByGuidIdAsync(Guid id) => await DeleteAsync(id);
        public async Task DeleteByNumberIdAsync<T>(T id) where T : IBinaryInteger<T> => await DeleteAsync(id);
    }
}
