using PersonalDiary.Domain.Models.Reviews;

namespace PersonalDiary.Domain.Repositories.Reviews
{
    public interface IWalkPlaceReviewRepository
    {
        Task<long> AddReview(WalkPlaceReview review);
        Task<IReadOnlyCollection<WalkPlaceReview>> GetPagedList(int page, int pageSize, Guid placeId);
    }
}