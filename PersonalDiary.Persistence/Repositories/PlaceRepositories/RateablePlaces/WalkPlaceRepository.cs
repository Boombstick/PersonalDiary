using PersonalDiary.Domain.Repositories;
using PersonalDiary.Domain.Models.Reviews;
using PersonalDiary.Domain.Models.Places.WalkPlaces;

namespace PersonalDiary.Persistence.Repositories.PlaceRepositories.RateablePlaces
{
    public class WalkPlaceRepository : RateableEntityRepository<WalkPlace, WalkPlaceReview, WalkPlaceType>, IWalkPlaceRepository
    {
        public WalkPlaceRepository(DiaryDbContext context) : base(context)
        {
        }
        public override async Task Create(WalkPlace place)
        {
            await base.Create(place);
        }

        public override async Task<WalkPlace> GetDetails(Guid id)
        {
            return await base.GetDetails(id);
        }
        public override async Task<IReadOnlyList<WalkPlace>> GetPagedList(
            int page,
            int pageSize,
            string searchTerm,
            long? cityId,
            WalkPlaceType? type)
        {
            return await base.GetPagedList(page, pageSize, searchTerm, cityId, type);
        }
    }
}
