using PersonalDiary.Domain.Models.Reviews;

namespace PersonalDiary.Domain.Repositories.Reviews
{
    public interface ICulturePlaceReviewRepository
    {
        Task<long> AddReview(CulturePlaceReview review);
        Task<IReadOnlyCollection<CulturePlaceReview>> GetPagedList(int page, int pageSize, Guid placeId);
    }
}