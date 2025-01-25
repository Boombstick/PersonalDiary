using PersonalDiary.Domain.Repositories;
using PersonalDiary.Domain.Models.Reviews;
using PersonalDiary.Domain.Models.Places.CulturePlaces;

namespace PersonalDiary.Persistence.Repositories.PlaceRepositories.RateablePlaces
{
    public class CulturePlaceRepository : RateableEntityRepository<CulturePlace, CulturePlaceReview, CulturePlaceType>, ICulturePlaceRepository
    {
        public CulturePlaceRepository(DiaryDbContext diaryDbContext) : base(diaryDbContext)
        {
        }
        public override async Task Create(CulturePlace place)
        {
            await base.Create(place);
        }

        public override async Task<CulturePlace> GetDetails(Guid id)
        {
            return await base.GetDetails(id);
        }
        public override async Task<IReadOnlyList<CulturePlace>> GetPagedList(
            int page,
            int pageSize,
            string searchTerm,
            long? cityId,
            CulturePlaceType? type)
        {
            return await base.GetPagedList(page, pageSize, searchTerm, cityId, type);
        }
    }
}
