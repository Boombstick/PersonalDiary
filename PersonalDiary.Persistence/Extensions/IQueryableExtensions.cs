using Microsoft.EntityFrameworkCore;
using PersonalDiary.Domain.Interfaces;

namespace PersonalDiary.Persistence.Extensions
{
    public static class IQueryableExtensions
    {
        public static IQueryable<T> CreatedBetweenDates<T>(this IQueryable<T> query, DateTime? startDate, DateTime? endDate) where T : ICreatedAt
        {
            return query.Where(x =>
            (!startDate.HasValue || EF.Functions.ToDate(x.CreatedAt.ToString(), "yy-MM-dd") >= DateOnly.FromDateTime(startDate.Value))
            &&
            (!endDate.HasValue || EF.Functions.ToDate(x.CreatedAt.ToString(), "yy-MM-dd") >= DateOnly.FromDateTime(endDate.Value)));
        }
    }
}
