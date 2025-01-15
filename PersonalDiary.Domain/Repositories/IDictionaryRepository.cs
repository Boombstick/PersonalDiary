using PersonalDiary.Domain.Models.Dictionaries;

namespace PersonalDiary.Domain.Repositories
{
    public interface IDictionaryRepository
    {
        Task<IReadOnlyCollection<City>> GetCities();
    }
}