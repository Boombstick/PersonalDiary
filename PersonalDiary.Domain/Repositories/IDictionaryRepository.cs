using PersonalDiary.Domain.Models;

namespace PersonalDiary.Domain.Repositories
{
    public interface IDictionaryRepository
    {
        Task<IReadOnlyCollection<City>> GetCities();
    }
}