using PersonalDiary.Domain.Models.Places.CulturePlaces;

namespace PersonalDiary.Domain.Repositories
{
    public interface ICulturePlaceRepository
    {
        Task Create(CulturePlace place);
        Task<CulturePlace> GetDetails(Guid id);
        Task<IReadOnlyList<CulturePlace>> GetPagedList(int page, int pageSize, string searchTerm, long? cityId, CulturePlaceType? type);
    }
}