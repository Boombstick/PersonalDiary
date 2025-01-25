using PersonalDiary.Domain.Repositories;
using PersonalDiary.Domain.Models.Reviews;
using PersonalDiary.Domain.Models.Places.FoodPlaces;

namespace PersonalDiary.Persistence.Repositories.PlaceRepositories.RateablePlaces
{
    public class FoodPlaceRepository : RateableEntityRepository<FoodPlace, FoodPlaceReview, FoodPlaceType>, IFoodPlaceRepository
    {
        public FoodPlaceRepository(DiaryDbContext diaryDbContext) : base(diaryDbContext)
        {
        }
        public override async Task Create(FoodPlace foodPlace)
        {
            await base.Create(foodPlace);
        }

        public override async Task<FoodPlace> GetDetails(Guid id)
        {
            return await base.GetDetails(id);
        }
        public override async Task<IReadOnlyList<FoodPlace>> GetPagedList(
            int page,
            int pageSize,
            string searchTerm,
            long? cityId,
            FoodPlaceType? cuisine)
        {
            return await base.GetPagedList(page, pageSize, searchTerm, cityId, cuisine);
        }
    }
}
