using Microsoft.EntityFrameworkCore;
using PersonalDiary.Domain.Models.Dictionaries;

namespace PersonalDiary.Persistence.Repositories.DictionaryRepository
{
    public partial class DictionaryRepository
    {
        public async Task<IReadOnlyCollection<City>> GetCities()
        {
            return await _diaryDbContext.Cities.Skip(1).ToListAsync();
        }
    }
}
