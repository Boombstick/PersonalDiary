using Microsoft.EntityFrameworkCore;
using PersonalDiary.Domain.Models.Reviews;
using PersonalDiary.Domain.Repositories.Reviews;
using PersonalDiary.Domain.Models.Places.CulturePlaces;

namespace PersonalDiary.Persistence.Repositories.PlaceRepositories.Reviews
{
    public class CulturePlaceReviewRepository : ReviewsRepository<CulturePlace, CulturePlaceReview>, ICulturePlaceReviewRepository
    {
        private readonly DiaryDbContext _dbContext;
        public CulturePlaceReviewRepository(DiaryDbContext diaryDbContext) : base(diaryDbContext)
        {
            _dbContext = diaryDbContext;
        }

        public async override Task<long> AddReview(CulturePlaceReview review)
        {
            return await base.AddReview(review);
        }

        public override Task<IReadOnlyCollection<CulturePlaceReview>> GetPagedList(int page, int pageSize, Guid placeId)
        {
            return base.GetPagedList(page, pageSize, placeId);
        }

        protected override async Task UpdatePlaceRating(CulturePlace place)
        {

            //TODO переделать без вытаскивания всего списка отзывов
            var reviews = await _dbContext.CulturePlaceReviews
                .AsNoTracking()
                .Where(r => r.PlaceId == place.Id)
                .ToListAsync();

            var averageRating = reviews.Average(r => (r.VibeRating + r.InterestingRating) / 2.0f);
            var reviewCount = reviews.Count;

            place.AverageRating = averageRating;
            place.ReviewCount = reviewCount;
            await _dbContext.SaveChangesAsync();
        }
    }
}
