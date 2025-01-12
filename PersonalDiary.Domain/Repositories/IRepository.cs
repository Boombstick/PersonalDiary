using System.Numerics;

namespace PersonalDiary.Domain.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task DeleteByGuidIdAsync(Guid id);
        Task DeleteByNumberIdAsync<T>(T id) where T : IBinaryInteger<T>;
    }
}
