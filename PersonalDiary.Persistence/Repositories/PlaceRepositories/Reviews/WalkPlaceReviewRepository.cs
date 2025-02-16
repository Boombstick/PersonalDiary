using Microsoft.EntityFrameworkCore;
using PersonalDiary.Domain.Models.Reviews;
using PersonalDiary.Domain.Repositories.Reviews;
using PersonalDiary.Domain.Models.Places.WalkPlaces;

namespace PersonalDiary.Persistence.Repositories.PlaceRepositories.Reviews
{
    public class WalkPlaceReviewRepository : ReviewsRepository<WalkPlace, WalkPlaceReview>, IWalkPlaceReviewRepository
    {
        private readonly DiaryDbContext _dbContext;
        public WalkPlaceReviewRepository(DiaryDbContext diaryDbContext) : base(diaryDbContext)
        {
            _dbContext = diaryDbContext;
        }

        public async override Task<long> AddReview(WalkPlaceReview review)
        {
            return await base.AddReview(review);
        }

        public override Task<IReadOnlyCollection<WalkPlaceReview>> GetPagedList(int page, int pageSize, Guid placeId)
        {
            return base.GetPagedList(page, pageSize, placeId);
        }

        protected override async Task UpdatePlaceRating(WalkPlace place)
        {
            //TODO переделать без вытаскивания всего списка отзывов
            var reviews = await _dbContext.WalkPlacesReviews
                .AsNoTracking()
                .Where(r => r.PlaceId == place.Id)
                .ToListAsync();

            var averageRating = reviews.Average(r => (r.VibeRating) / 1.0f);
            var reviewCount = reviews.Count;

            place.AverageRating = averageRating;
            place.ReviewCount = reviewCount;
            await _dbContext.SaveChangesAsync();
        }
    }
}
