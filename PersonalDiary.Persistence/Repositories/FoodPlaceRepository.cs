using Microsoft.EntityFrameworkCore;
using PersonalDiary.Domain.Repositories;
using PersonalDiary.Domain.Models.FoodPlaces;

namespace PersonalDiary.Persistence.Repositories
{
    public class FoodPlaceRepository : IFoodPlaceRepository
    {
        private readonly DiaryDbContext _diaryDbContext;
        public FoodPlaceRepository(DiaryDbContext diaryDbContext)
        {
            _diaryDbContext = diaryDbContext;
        }
        public async Task Add(FoodPlace foodPlace)
        {
            _diaryDbContext.FoodPlaces.Add(foodPlace);
            await _diaryDbContext.SaveChangesAsync();
        }

        public async Task<FoodPlace> GetDetails(Guid id)
        {
            return await _diaryDbContext.FoodPlaces.Include(x => x.City).FirstOrDefaultAsync(x => x.Id == id) ?? throw new KeyNotFoundException();
        }
        public async Task<IReadOnlyList<FoodPlace>> GetPagedList(
            int page,
            int pageSize,
            string searchTerm,
            long? cityId,
            long? cuisineId)
        {
            var skip = (page - 1) * pageSize;
            return await _diaryDbContext.FoodPlaces
                .Include(x => x.City)
                .Where(x => cityId == null || x.CityId == cityId)
                .Where(x => cuisineId == null || x.Cousine == (Cousine)cuisineId!)
                .Where(x => searchTerm == null || x.Name.Contains(searchTerm))
                .Skip(skip)
                .Take(pageSize)
                .ToListAsync();
        }
    }
}
