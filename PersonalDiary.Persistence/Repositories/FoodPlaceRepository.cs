using Microsoft.EntityFrameworkCore;
using PersonalDiary.Domain.Models.FoodPlace;
using PersonalDiary.Domain.Repositories;

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
            return await _diaryDbContext.FoodPlaces.Include(x => x.City).FirstOrDefaultAsync(x => x.Id == id) ?? new FoodPlace();
        }
        public async Task<IReadOnlyList<FoodPlace>> GetPagedList(int page, int pageSize)
        {
            var skip = (page - 1) * pageSize;
            return await _diaryDbContext.FoodPlaces
                .Include(x=>x.City)
                .Skip(skip)
                .Take(pageSize)
                .ToListAsync();
        }
    }
}
