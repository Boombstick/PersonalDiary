using Microsoft.EntityFrameworkCore;
using PersonalDiary.Domain.AbstractClasses;

namespace PersonalDiary.Persistence.Repositories
{
    public class RateableEntityRepository<TEntity, TReviewCollection, TType>
        where TEntity : RateablePlaceEntity<TEntity, TReviewCollection, TType>
        where TReviewCollection : Review<TEntity>
        where TType : struct, Enum

    {
        protected readonly DiaryDbContext _context;
        protected readonly DbSet<TEntity> _dbSet;
        public RateableEntityRepository(DiaryDbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }
        public virtual async Task Create(TEntity place)
        {
            _dbSet.Add(place);
            await _context.SaveChangesAsync();
        }

        public virtual async Task<TEntity> GetDetails(Guid id)
        {
            return await _dbSet
                .Include(x => x.City)
                .Include(x => x.Reviews.OrderByDescending(x => x.CreatedAt).Take(2))
                .FirstOrDefaultAsync(x => x.Id == id) ?? throw new KeyNotFoundException();
        }
        public virtual async Task<IReadOnlyList<TEntity>> GetPagedList(
            int page,
            int pageSize,
            string searchTerm,
            long? cityId,
            TType? cuisineId)
        {
            var skip = (page - 1) * pageSize;
            return await _dbSet
                .AsNoTracking()
                .Include(x => x.City)
                .Where(x => !cityId.HasValue || x.CityId == cityId)
                .Where(x => !cuisineId.HasValue || x.Type.Equals(cuisineId.Value))
                .Where(x => string.IsNullOrEmpty(searchTerm) || x.Name.Contains(searchTerm))
                .Skip(skip)
                .Take(pageSize)
                .ToListAsync();
        }
    }
}
