using PersonalDiary.Domain.Models.FoodPlace;

namespace PersonalDiary.Domain.Repositories
{
    public interface IFoodPlaceRepository
    {
        Task Add(FoodPlace foodPlace);
        Task<FoodPlace> GetDetails(Guid id);
        Task<IReadOnlyList<FoodPlace>> GetPagedList(int page, int pageSize, string searchTerm, long? cityId, long? cuisineId);
    }
}
