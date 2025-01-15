using PersonalDiary.Domain.Interfaces;

namespace PersonalDiary.Persistence.Extensions.TaskExtensions
{
    public static class TaskQueryExtensions
    {
        public static IQueryable<T> DeadLineBetweenDates<T>(this IQueryable<T> query, DateTime? startDate, DateTime? endDate) where T : IDeadLine
        {
            return query.Where(x =>
            (!startDate.HasValue || x.DeadLine >= startDate.Value)
            &&
            (!endDate.HasValue || x.DeadLine <= endDate.Value));
        }
    }
}
