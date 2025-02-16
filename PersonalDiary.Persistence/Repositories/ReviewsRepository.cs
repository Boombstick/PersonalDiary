using Microsoft.EntityFrameworkCore;
using PersonalDiary.Domain.Models.Reviews;

namespace PersonalDiary.Persistence.Repositories
{
    public abstract class ReviewsRepository<TPlaceEntity, TReviewEntity>
        where TReviewEntity : Review<TPlaceEntity>
        where TPlaceEntity : class
    {
        protected readonly DiaryDbContext _diaryDbContext;
        protected readonly DbSet<TReviewEntity> _dbSet;
        public ReviewsRepository(DiaryDbContext diaryDbContext)
        {
            _diaryDbContext = diaryDbContext;
            _dbSet = diaryDbContext.Set<TReviewEntity>();
        }
        /// <summary>
        /// Добавление отзыва на место
        /// </summary>
        /// <param name="review"></param>
        /// <returns></returns>
        /// <exception cref="KeyNotFoundException"></exception>
        public virtual async Task<long> AddReview(TReviewEntity review)
        {
            var place = await _diaryDbContext.Set<TPlaceEntity>().FindAsync(review.PlaceId)
                ?? throw new KeyNotFoundException();
            await _dbSet.AddAsync(review);
            await UpdatePlaceRating(place);
            return review.Id;
        }
        /// <summary>
        /// Получение отзвывов постранично
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="placeId"></param>
        /// <returns></returns>
        public virtual async Task<IReadOnlyCollection<TReviewEntity>> GetPagedList(int page, int pageSize, Guid placeId)
        {
            var skip = --page * pageSize;
            return await _dbSet
                .Include(x => x.Author)
                .Where(x => x.PlaceId == placeId)
                .Skip(skip)
                .Take(pageSize)
                .ToListAsync();
        }
        /// <summary>
        /// Обновляет средний рейтинг места
        /// </summary>
        /// <param name="place">Место на которое был оставлен отзыв</param>
        /// <returns>Task</returns>
        protected abstract Task UpdatePlaceRating(TPlaceEntity place);
    }
}
