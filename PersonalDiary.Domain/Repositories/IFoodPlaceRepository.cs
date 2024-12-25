using PersonalDiary.Domain.Models.Food;

namespace PersonalDiary.Domain.Repositories
{
    public interface IFoodPlaceRepository
    {
        Task Add(FoodPlace foodPlace);
        Task<FoodPlace> GetDetails(Guid id);
    }
}
