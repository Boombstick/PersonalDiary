using PersonalDiary.Domain.Models.Places.FoodPlaces;

namespace PersonalDiary.Domain.Repositories
{
    public interface IFoodPlaceRepository
    {
        Task Create(FoodPlace foodPlace);
        Task<FoodPlace> GetDetails(Guid id);
        Task<IReadOnlyList<FoodPlace>> GetPagedList(int page, int pageSize, string searchTerm, long? cityId, FoodPlaceType? cuisineId);
    }
}
