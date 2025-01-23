using Microsoft.EntityFrameworkCore;
using PersonalDiary.Domain.Repositories;
using PersonalDiary.Domain.Models.Reviews;
using PersonalDiary.Domain.Models.FoodPlaces;

namespace PersonalDiary.Persistence.Repositories
{
    public class RatingRepository : IRatingRepository
    {
        private readonly DiaryDbContext _diaryDbContext;
        public RatingRepository(DiaryDbContext diaryDbContext)
        {
            _diaryDbContext = diaryDbContext;
        }

        public async Task<long> AddReview(FoodPlaceReview review)
        {
            var place = await _diaryDbContext.FoodPlaces.FindAsync(review.FoodPlaceId) ?? throw new KeyNotFoundException();
            await _diaryDbContext.FoodPlaceReviews.AddAsync(review);
            await _diaryDbContext.SaveChangesAsync();
            await UpdateFoodPlaceRating(place);
            return review.Id;
        }
        public async Task<IReadOnlyCollection<FoodPlaceReview>> GetPagedList(int page, int pageSize,Guid foodPlaceId)
        {
            return await _diaryDbContext.FoodPlaceReviews.Where(x => x.FoodPlaceId == foodPlaceId).ToListAsync();
        }
        private async Task UpdateFoodPlaceRating(FoodPlace foodPlace)
        {
            var reviews = await _diaryDbContext.FoodPlaceReviews
                .AsNoTracking()
                .Where(r => r.FoodPlaceId == foodPlace.Id)
                .ToListAsync();

            var averageRating = reviews.Average(r => (r.FoodRating + r.VibeRating + r.ServiceRating) / 3.0f);
            var reviewCount = reviews.Count;

            foodPlace.AverageRating = averageRating;
            foodPlace.ReviewCount = reviewCount;
            await _diaryDbContext.SaveChangesAsync();
        }
    }
}
