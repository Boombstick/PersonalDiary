using PersonalDiary.Domain.Models.Reviews;

namespace PersonalDiary.Domain.Repositories.Reviews
{
    public interface IFoodPlaceReviewRepository
    {
        Task<long> AddReview(FoodPlaceReview review);
        Task<IReadOnlyCollection<FoodPlaceReview>> GetPagedList(int page, int pageSize, Guid placeId);
    }
}