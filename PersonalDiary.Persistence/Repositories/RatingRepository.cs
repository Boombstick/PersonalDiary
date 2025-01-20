using Microsoft.EntityFrameworkCore;
using PersonalDiary.Domain.Models.Reviews;

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
            place.ReviewValue += review.Rating;
            place.ReviewCount++;
            review.Rating = 312_312_312;
            var asdasd = review.Rating;
            await _diaryDbContext.FoodPlaceReviews.AddAsync(review);
            await _diaryDbContext.SaveChangesAsync();
            return review.Id;
        }
        public async Task<IReadOnlyCollection<FoodPlaceReview>> GetAllReviews(Guid foodPlaceId)
        {
            return await _diaryDbContext.FoodPlaceReviews.Where(x => x.FoodPlaceId == foodPlaceId).ToListAsync();
        }
    }
}
