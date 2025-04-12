using PersonalDiary.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace PersonalDiary.Persistence.Repositories
{
    public class CityRepository
    {
        private readonly DiaryDbContext _dbContext;
        public CityRepository(DiaryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<City> GetCity(long id)
        {
            return await _dbContext.Cities
                .Include(x => x.WalkPlaces)
                .ThenInclude(x => x.Reviews.Take(2))
                .Include(x => x.FoodPlaces)
                .ThenInclude(x => x.Reviews.Take(2))
                .Include(x => x.CulturePlaces)
                .ThenInclude(x => x.Reviews.Take(2))
                .FirstOrDefaultAsync(x => x.Id == id)
                ?? throw new KeyNotFoundException();
        }
    }
}
