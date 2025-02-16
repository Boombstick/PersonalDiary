using Microsoft.EntityFrameworkCore;
using PersonalDiary.Domain.Models.Reviews;
using PersonalDiary.Domain.Repositories.Reviews;
using PersonalDiary.Domain.Models.Places.FoodPlaces;

namespace PersonalDiary.Persistence.Repositories.PlaceRepositories.Reviews
{
    public class FoodPlaceReviewRepository : ReviewsRepository<FoodPlace, FoodPlaceReview>, IFoodPlaceReviewRepository
    {
        private readonly DiaryDbContext _dbContext;
        public FoodPlaceReviewRepository(DiaryDbContext diaryDbContext) : base(diaryDbContext)
        {
            _dbContext = diaryDbContext;
        }

        public async override Task<long> AddReview(FoodPlaceReview review)
        {
            return await base.AddReview(review);
        }

        public override Task<IReadOnlyCollection<FoodPlaceReview>> GetPagedList(int page, int pageSize, Guid placeId)
        {
            return base.GetPagedList(page, pageSize, placeId);
        }

        protected override async Task UpdatePlaceRating(FoodPlace place)
        {

            //TODO переделать без вытаскивания всего списка отзывов
            var reviews = await _dbContext.FoodPlaceReviews
                .AsNoTracking()
                .Where(r => r.PlaceId == place.Id)
                .ToListAsync();

            var averageRating = reviews.Average(r => (r.FoodRating + r.VibeRating + r.ServiceRating) / 3.0f);
            var reviewCount = reviews.Count;

            place.AverageRating = averageRating;
            place.ReviewCount = reviewCount;
            await _dbContext.SaveChangesAsync();
        }
    }
}
