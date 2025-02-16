using PersonalDiary.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace PersonalDiary.Persistence.Repositories.DictionaryRepository
{
    public partial class DictionaryRepository
    {
        public async Task<IReadOnlyCollection<City>> GetCities()
        {
            return await _diaryDbContext.Cities.ToListAsync();
        }
    }
}
