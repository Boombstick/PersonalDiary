using PersonalDiary.Domain.Models.Places.WalkPlaces;

namespace PersonalDiary.Domain.Repositories
{
    public interface IWalkPlaceRepository
    {
        Task Create(WalkPlace place);
        Task<WalkPlace> GetDetails(Guid id);
        Task<IReadOnlyList<WalkPlace>> GetPagedList(int page, int pageSize, string searchTerm, long? cityId, WalkPlaceType? type);
    }
}