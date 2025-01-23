using PersonalDiary.Domain.Models.Reviews;

namespace PersonalDiary.Domain.Repositories
{
    public interface IRatingRepository
    {
        Task<long> AddReview(FoodPlaceReview review);
        Task<IReadOnlyCollection<FoodPlaceReview>> GetPagedList(int page, int pageSize, Guid foodPlaceId);
    }
}